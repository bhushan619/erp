using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Personnel_employee_production_AddRawMaterial : System.Web.UI.Page
{
    public static string empdesig = string.Empty;
    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();
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
            lbldate.Text = System.DateTime.Now.ToShortDateString();
            lbltime.Text = System.DateTime.Now.ToShortTimeString();
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
    protected void btnAddToOrder_Click(object sender, EventArgs e)
    {

        try
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {

                int insert_ok = dbc.insert_rowMaterial(txtname.Text, "0", "Kg", "0", "Ton", txtWarningTon.Text, txtWarningKg.Text, txtremark.Text, "NA");

                if (insert_ok == 1)
                {
                    int ok = notification();
                    if (ok == 1)
                    {
                        Response.Write("<script>alert('Raw Material Added Successfully');window.location='AddRawMaterial.aspx';</script>");
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
                okn = dbc.insert_tblsunotifications("Page", Convert.ToInt32(Session["empid"].ToString()), lblCustName.Text, empdesig, Convert.ToInt32(drn["intId"].ToString()), "Admin", "New Raw Material : " + txtname.Text + " added by " + lblCustName.Text + "", "~/Personnel/admin/", "NA", "Unread", "Order");
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
    public void clear()
    {
        txtname.Text = ""; 
        txtremark.Text = "";
        
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void txtWarningTon_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtWarningTon.Text == "")
            {
            }
            else
            {
                if (txtname.Text != "-- Select Product --")
                {
                    txtWarningKg.Text = (1000 * Convert.ToDouble(txtWarningTon.Text)).ToString();
                }
                else
                {
                    Response.Write("<script>alert('Please select Product');</script>");
                    clear();
                }
            }
        }
        catch (Exception ex)
        {

        } 
    }
    protected void txtWarningKg_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtWarningKg.Text == "")
            {
            }
            else
            {
                if (txtname.Text != "-- Select Product --")
                {
                    txtWarningTon.Text = (Convert.ToDouble(txtWarningKg.Text) / 1000).ToString();
                }
                else
                {
                    Response.Write("<script>alert('Please select Product');</script>");
                    clear();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
}