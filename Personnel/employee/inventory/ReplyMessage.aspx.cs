using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Personnel_admin_ReplyMessage : System.Web.UI.Page
{
    static int empReplyToId = 0;
    // string desig = string.Empty;
    static string empdesig = string.Empty;
    static string empReplyTodesig = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["empid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../SignUpLogin.aspx';</script>");
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        else if (!IsPostBack)
        {
            getAdmindata();
            getImage();
            getEnquirymsg();
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
    public void getAdmindata()
    {
        try
        {

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varName FROM sanghaviunbreakables.tblsupersonnel where intId=" + Session["empid"].ToString() + "", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblCustName.Text = dbc.dr["varName"].ToString();

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
    DatabaseConnection dbc = new DatabaseConnection();

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
    public void getEnquirymsg()
    {
        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varEnquirySubject, dtDate, tmTime, intId FROM tblsuenquiry  where intId=" + Session["Enquirybyadmin"].ToString() + "", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblSubject.Text = dbc.dr["varEnquirySubject"].ToString();
               // txtMobile.Text = dbc.dr["varMobile"].ToString();  
                dbc.con.Close();
                dbc.dr.Close();
            }
            SqlDataSourceFull.SelectCommand = "SELECT intId, nvarMsgFrom, nvarMsgTo FROM tblsuconversation where intMessageId=" + Session["Enquirybyadmin"].ToString() + "";
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {

                string adminreply = txtreplyadminmsg.Text;
                int insert_ok = dbc.Update_tblsuEnquiryReplySendAdmin(Session["Enquirybyadmin"].ToString(), adminreply);

                if (insert_ok == 1)
                {
                    int ok = notification(empReplyToId, empReplyTodesig, pagetosend(empReplyTodesig));
                    if (ok == 1)
                    {
                        Response.Write("<script>alert('Reply Send Successfully');window.location='ViewMessages.aspx';</script>");
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(
                  this,
                  this.GetType(),
                  "MessageBox",
                  "alert('Some problem Please try again');", true);
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('" + ex.Message + "');", true);
        }
    }
    public int notification(int idToNotification, string desigToNotification, string pageToView)
    {
        try
        {

            int okn = dbc.insert_tblsunotifications("Page", Convert.ToInt32(Session["empid"].ToString()), lblCustName.Text, empdesig, idToNotification, desigToNotification, "Reply from Sub Admin", pageToView, "NA", "Unread", "Order");

            return okn;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
    public string pagetosend(string desig)
    {
        if (desig == "Marketing Executive")
        {
            return "~/Personnel/employee/marketing/ViewSentMessages.aspx";
        }
        else if (desig == "Marketing Head")
        {
            return "~/Personnel/employee/marketing/ViewSentMessages.aspx";
        }
        else if (desig == "Inventory")
        {
            return "~/Personnel/employee/inventory/ViewSentMessages.aspx";
        }
        else if (desig == "Dispatch")
        {
            return "~/Personnel/employee/dispatch/ViewSentMessages.aspx";
        }
        else if (desig == "Production")
        {
            return "~/Personnel/employee/production/ViewSentMessages.aspx";
        }
        else if (desig == "Admin")
        {
            return "~/Personnel/Admin/ViewSentMessages.aspx";
        }
        else
        {
            return "~/Personnel/customer/ViewSentMessages.aspx";
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Personnel/employee/production/Default.aspx");
    }
}
