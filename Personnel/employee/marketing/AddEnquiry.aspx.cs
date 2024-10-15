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
    public static string empdesig = string.Empty;
    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();
    DatabaseConnection dbc1 = new DatabaseConnection();
   
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

        }
        lbldate.Text = System.DateTime.Now.ToShortDateString();
       lblTime.Text = System.DateTime.Now.ToShortTimeString();
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

    public void clear()
    {
        txtMsg.Text = "";
        txtSubject.Text = "";
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

    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {

                int empid = 0;
                string desig = string.Empty;
                if (ddlSelectDesig.Text == "-- Select List --")
                {
                    Response.Write("<script>alert('Please select an Item');</script>");
                }
                else if (ddlSelectDesig.Text == "Employee")
                {
                    dbc1.con1.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varName, varMobile, varMobileVerify, varEmail, varEmailVerify, varPassword, varAddress, varCity, varState, varDesignation, varSubDesig, varStatus, varIDProof, varIDProofNo, varPanCardNo, imgImage, dtDateOfBirth FROM tblsupersonnel WHERE varName='" + ddlDesigs.Text + "'", dbc1.con1);

                    dbc1.dr = cmd.ExecuteReader();
                    if (dbc1.dr.Read())
                    {
                        empid = Convert.ToInt32(dbc1.dr["intId"].ToString());
                        desig = dbc1.dr["varSubDesig"].ToString();
                        int insert_ok = dbc1.insert_tblsuenquiry(Convert.ToInt32(Session["empid"].ToString()), lblCustName.Text, empdesig, empid, ddlDesigs.Text, desig, txtSubject.Text, txtMsg.Text, lbldate.Text, lblTime.Text);

                        if (insert_ok == 1)
                        {
                            int ok = notification(empid, desig, pagetosend(desig));
                            if (ok == 1)
                            {
                                Response.Write("<script>alert('Message Send Successfully');</script>");
                                clear();
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
                }
                else
                {
                    string[] arry = ddlDesigs.Text.Split(new char[] { '_' });
                    int custId = 0;
                    dbc1.con1.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varRepresentativeName, varMobile,varState FROM sanghaviunbreakables.tblsucustomer where varCompanyName='" + arry[0] + "' and varCity='" + arry[1] + "'", dbc1.con1);

                    dbc1.dr = cmd.ExecuteReader();
                    if (dbc1.dr.Read())
                    {
                        custId = Convert.ToInt32(dbc1.dr["intId"].ToString());
                        int insert_ok = dbc1.insert_tblsuenquiry(Convert.ToInt32(Session["empid"].ToString()), lblCustName.Text, empdesig, custId, ddlDesigs.Text, "Customer", txtSubject.Text, txtMsg.Text, lbldate.Text, lblTime.Text);

                        if (insert_ok == 1)
                        {
                            int ok = notification(custId, "Customer", "~/Personnel/customer/ViewConversation.aspx");
                            if (ok == 1)
                            {
                                Response.Write("<script>alert('Message Send Successfully');</script>");
                                clear();
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

            int okn = dbc.insert_tblsunotifications("Page", Convert.ToInt32(Session["empid"].ToString()), lblCustName.Text, empdesig, idToNotification, desigToNotification, "New Message from " + lblCustName.Text + "", pageToView, "NA", "Unread", "Order");

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
            return "~/Personnel/employee/marketing/InboxMsg.aspx";
        }
        else if (desig == "Marketing Head")
        {
            return "~/Personnel/employee/marketing/InboxMsg.aspx";
        }
        else if (desig == "Inventory")
        {
            return "~/Personnel/employee/inventory/InboxMsg.aspx";
        }
        else if (desig == "Dispatch")
        {
            return "~/Personnel/employee/dispatch/InboxMsg.aspx";
        }
        else if (desig == "Production")
        {
            return "~/Personnel/employee/production/InboxMsg.aspx";
        }
        else
        {
            return "~/Personnel/Admin/ViewMessages.aspx";
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Personnel/employee/Default.aspx");
    }
    protected void ddlSelectDesig_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlSelectDesig.Text == "-- Select List --")
        {
            Response.Write("<script>alert('Please select an Item');</script>");
        }
        else if (ddlSelectDesig.Text == "Employee")
        {
            ddlDesigs.Items.Clear();
            SqlDataSource1.SelectCommand = "SELECT tblsupersonnel.varName FROM sanghaviunbreakables.tblsupersonnel where intId<>" + Session["empid"].ToString() + "";
            ddlDesigs.DataTextField = "varName";
        }
        else
        {
            ddlDesigs.Items.Clear();
            SqlDataSource1.SelectCommand = "SELECT distinct concat(varCompanyName,'_',varCity) as  CompanyName FROM sanghaviunbreakables.tblsucustomer where varMobile<> '-'";
            ddlDesigs.DataTextField = "CompanyName";
        }
    }
}