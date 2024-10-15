using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

public partial class Personnel_customer_AddEnquiry : System.Web.UI.Page
{
    //public static string empdesig = string.Empty;
    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new MySql.Data.MySqlClient.MySqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["sanghaviConnectionString"].ConnectionString;
        if (Session["custid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../SignUpLogin.aspx';</script>");
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        else if (!IsPostBack)
        {
            getCustomerdata();
            getImage();
           
            notifications();
        }
        lbldate.Text = System.DateTime.Now.ToShortDateString();
        lblTime.Text = System.DateTime.Now.ToShortTimeString();
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["custid"].ToString()), "Customer").ToString();
    }
  
    DatabaseConnection dbc = new DatabaseConnection();
    public void getCustomerdata()
    {
        try
        {

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varCompanyName,varRepresentativeName, varMobile, varEmail,varAddress, varCity, varState, varPanCardNo, varVatNo, varTinNo, dtDateOfEstd FROM sanghaviunbreakables.tblsucustomer where intId=" + Session["custid"].ToString() + "", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblCustName.Text = dbc.dr["varCompanyName"].ToString();
              
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
        string ImageUr = dbc.select_custProfilePic(Convert.ToInt32(Session["custid"].ToString()));
        if (ImageUr == "")
        {
            imgProPic.ImageUrl = "~/Personnel/customer/media/NoProfile.png";
        }
        else
        {

            imgProPic.ImageUrl = "~/Personnel/customer/media/" + ImageUr;
        }
        //  SqlDataSourceMedia.SelectCommand = "SELECT [imgImage] FROM tblsucustomer where intId=" + Convert.ToInt32(Session["custid"].ToString()) + "";
    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Session["custid"] = "";
        Session.Remove("custid");

        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();

        Response.Redirect("~/Default.aspx");
    }

    public void clear()
    {
        txtMsg.Text = "";
        txtSubject.Text = "";
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                int okn = 0, insert_ok = 0;
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmdn = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId FROM tblsupersonnel WHERE varSubDesig='Sub Admin'", con);

                MySql.Data.MySqlClient.MySqlDataReader drn;
                drn = cmdn.ExecuteReader();
                while (drn.Read())
                {
                    insert_ok = dbc.insert_tblsuenquiry(Convert.ToInt32(Session["custid"].ToString()), lblCustName.Text, "Customer", Convert.ToInt32(drn["intId"].ToString()), "Sub Admin", "Sub Admin", txtSubject.Text, txtMsg.Text, lbldate.Text, lblTime.Text);
                    okn = dbc.insert_tblsunotifications("Page", Convert.ToInt32(Session["custid"].ToString()), lblCustName.Text, "Customer", Convert.ToInt32(drn["intId"].ToString()), "Sub Admin", "New Message from : " + lblCustName.Text + "", "~/Personnel/employee/dispatch/InboxMsg.aspx", "NA", "Unread", "Sub Admin");
                }
                con.Close();
                drn.Close();

                if (insert_ok == 1)
                {
                    if (okn == 1)
                    {
                        Response.Write("<script>alert('Message Send Successfully');</script>");
                        clear();
                    }
                    else
                    {
                        Response.Write("<script>alert('Please Try Again');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please Try Again');</script>");
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
     
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Personnel/customer/Default.aspx");
    }
}