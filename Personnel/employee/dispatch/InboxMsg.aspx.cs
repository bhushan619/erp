using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Collections.Generic;
using System.IO;

public partial class Personnel_employee_InboxMsg : System.Web.UI.Page
{
    static string empdesig = string.Empty;
    DatabaseConnection dbc = new DatabaseConnection();
    DataTable dt = new DataTable();
    string name = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["empid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../../SignUpLogin.aspx';</script>");
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        else if (!IsPostBack)
        {
            getImage();
            getempname();
            notifications();
            name = "EMP:" + lblCustName.Text;
            SqlDataSourceMessages.SelectCommand = "SELECT varMessageByName, varMessageToName, varEnquirySubject, dtDate, tmTime, intId FROM tblsuenquiry WHERE intMessageToId= " + Convert.ToInt32(Session["empid"].ToString()) + " order by CAST( STR_TO_DATE( dtDate,  '%d-%m-%Y' ) AS DATE )";

        }
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["empid"].ToString()), empdesig).ToString();
    }
    public void getempname()
    {
        try
        {

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varName,varSubDesig FROM sanghaviunbreakables.tblsupersonnel where intId=" + Session["empid"].ToString() + "", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblCustName.Text = dbc.dr["varName"].ToString();
                empdesig = dbc.dr["varSubDesig"].ToString();
                dbc.con.Close();
                dbc.dr.Close();
            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
        }
    }
    public void getImage()
    {
        string ImageUr = dbc.select_empProfilePic(Convert.ToInt32(Session["empid"].ToString()));
        if (ImageUr == "")
        {
            imgProPic.ImageUrl = "~/Personnel/employee/media/NoProfile.png";
        }
        else
        {

            imgProPic.ImageUrl = "~/Personnel/employee/media/" + ImageUr;
        }
        //  SqlDataSourceMedia.SelectCommand = "SELECT [imgImage] FROM tblsucustomer where intId=" + Convert.ToInt32(Session["empid"].ToString()) + "";
    }
    protected void lnkLogoutUp_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Session["empid"] = "";
        Session.Remove("empid");

        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();

        Response.Redirect("~/Default.aspx");
    }   
    
    //protected void listproduct_ItemCommand(object sender, ListViewCommandEventArgs e)
    //{
    //    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
    //    string id = commandArgs[0];
    //    name = "EMP:" + lblCustName.Text;

    //    if (e.CommandName == "Edits")
    //    {
    //        Session.Add("EnquirybyEmp", id);
    //        Response.Redirect("ReplyMessage.aspx");
    //    }

    //    //else if (e.CommandName == "Deletes")
    //    //{
    //    //    dbc.con.Open();
    //    //    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from sanghaviunbreakables.tblsuenquiry WHERE intId=" + id + "", dbc.con);
    //    //    cmd.ExecuteReader();
    //    //    dbc.con.Close();
    //    //    dbc.con.Open();
    //    //    MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("delete from sanghaviunbreakables.tblsuconversation WHERE intId=" + id + "", dbc.con);
    //    //    cmd1.ExecuteReader();
    //    //    dbc.con.Close();
    //    //}
    //    SqlDataSource2.SelectCommand = "SELECT sanghaviunbreakables.tblsuenquiry.intId, sanghaviunbreakables.tblsuenquiry.intTicketNo,  sanghaviunbreakables.tblsuenquiry.nvarEnquiryBy, sanghaviunbreakables.tblsuenquiry.nvarEnquirySubject, sanghaviunbreakables.tblsuenquiry.dtDate, sanghaviunbreakables.tblsuconversation.nvarMsgFromEnquirer,sanghaviunbreakables.tblsuconversation.nvarMsgFromAdmin FROM sanghaviunbreakables.tblsuenquiry INNER JOIN sanghaviunbreakables.tblsuconversation ON sanghaviunbreakables.tblsuenquiry.intTicketNo = sanghaviunbreakables.tblsuconversation.intTicketNo and nvarEnquiryBy = '" + name + "' ORDER BY intId desc";
    //    listenquiry.DataBind();
    //}
    protected void lstFullMessage_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            string id = commandArgs[0];


            if (e.CommandName == "Edits")
            {
                Session.Add("Enquirybyadmin", id);
                Response.Redirect("ReplyMessage.aspx");
            }

            else if (e.CommandName == "Deletes")
            {
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from sanghaviunbreakables.tblsuenquiry WHERE intId=" + id + "", dbc.con);
                cmd.ExecuteReader();
                dbc.con.Close();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("delete from sanghaviunbreakables.tblsuconversation WHERE intMessageId=" + id + "", dbc.con);
                cmd1.ExecuteReader();
                dbc.con.Close();
            }
            else if (e.CommandName == "Views")
            {
                lblSubject.Text = commandArgs[1].ToString();
                SqlDataSourceFull.SelectCommand = "SELECT intId, nvarMsgFrom, nvarMsgTo FROM tblsuconversation where intMessageId=" + id + "";
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void lstMessages_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (lstMessages.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        SqlDataSourceMessages.SelectCommand = "SELECT varMessageByName, varMessageToName, varEnquirySubject, dtDate, tmTime, intId FROM tblsuenquiry WHERE intMessageToId= " + Convert.ToInt32(Session["empid"].ToString()) + " order by CAST( STR_TO_DATE( dtDate,  '%d-%m-%Y' ) AS DATE )";
        SqlDataSourceMessages.DataBind();
    }
}