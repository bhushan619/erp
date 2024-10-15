using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Personnel_admin_EditCustomer : System.Web.UI.Page
{
    public static string empdesig = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["empid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../SignUpLogin.aspx';</script>");
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        else   if (!IsPostBack)
        {
            getAdmindata();
            getImage();
            getcustdata();
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
    public void getcustdata()
    {
        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varCompanyName,varRepresentativeName ,varMobile , varAddress,varCity ,varState ,varPanCardNo,varVatNo ,varTinNo,imgImage,dtDateOfEstd FROM sanghaviunbreakables.tblsucustomer   WHERE intId=" + Session["custbyemp"].ToString() + "", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {

                txtCmpName.Text = dbc.dr["varCompanyName"].ToString();
                txtRepName.Text = dbc.dr["varRepresentativeName"].ToString();
                txtMobile.Text = dbc.dr["varMobile"].ToString();
                txtADD.Text = dbc.dr["varAddress"].ToString(); 
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
            imgProPic.ImageUrl = "~/Personnel/admin/media/NoProfile.png";
        }
        else
        {

            imgProPic.ImageUrl = "~/Personnel/admin/media/" + ImageUr;
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {

                int insert_ok = dbc.update_tblsucustomeremp(Session["custbyemp"].ToString(), txtRepName.Text, txtMobile.Text, txtLandline.Text, txtADD.Text);
                if (insert_ok == 1)
                {
                    int ok = notification();
                    if (ok == 1)
                    {
                        Response.Write("<script>alert('Data Updated');window.location='ViewCustomer.aspx';</script>");
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
                   "alert('Data Not Updated');", true);

        }
    }

    public int notification()
    {
        try
        {
            int okn = 0;
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdn = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId FROM tblsupersonnel WHERE varSubDesig='Admin'", dbc.con);

            MySql.Data.MySqlClient.MySqlDataReader drn;
            drn = cmdn.ExecuteReader();
            while (drn.Read())
            {
                okn = dbc.insert_tblsunotifications("Page", Convert.ToInt32(Session["empid"].ToString()), lblCustName.Text, empdesig, Convert.ToInt32(drn["intId"].ToString()), "Admin", "Customer :" + txtCmpName.Text + ", Updated by Employee " + lblCustName.Text + "", "~/Personnel/admin/ViewCustomer.aspx", "NA", "Unread", "Cust");
            }
            dbc.con.Close();
            dbc.dr.Close();
            return okn;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Personnel/employee/marketing/ViewCustomer.aspx");
    }  
}