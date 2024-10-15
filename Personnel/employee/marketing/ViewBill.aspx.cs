using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Personnel_employee_ViewBill : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    public static string empdesig = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../../SignUpLogin.aspx';</script>");
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }

        else  if (!IsPostBack)
        {
            getImage();
            getempname();
            notifications();
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


    protected void lnkLogout_Click(object sender, EventArgs e)
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }
    protected void listorder_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        int updateok = 0;
        
        string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
        string billno = commandArgs[0];
        string orderid = commandArgs[1];
        if (e.CommandName == "View")
        {
            Session.Add("billno", billno);
            Session.Add("orderid", orderid);
            Response.Redirect("ViewBillFull.aspx");
        }
        else if (e.CommandName == "Print")
        {
            Session.Add("billnoprint", billno);
            Session.Add("orderidprint", orderid);
            ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>openNewWin('BillPrint.aspx')</script>");

        }
    }
}