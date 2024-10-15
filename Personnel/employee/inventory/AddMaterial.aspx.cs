using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

public partial class Personnel_employee_inventory_AddMaterial : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    static string empdesig = string.Empty;
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

    public void clear()
    {
        txtName.Text = "";
        ddlUnits.Text = "-- Select Unit --";
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (ddlUnits.Text == "-- Select Unit --")
                {

                    ScriptManager.RegisterStartupScript(
                  this,
                  this.GetType(),
                  "MessageBox",
                  "alert('Please select Unit');", true);
                }
                else
                {
                    int insert_ok = dbc.insert_sumaterials(txtName.Text, ddlUnits.Text);

                    if (insert_ok == 1)
                    {
                        int ok = notification();
                        if (ok == 1)
                        {
                            ScriptManager.RegisterStartupScript(
                          this,
                          this.GetType(),
                          "MessageBox",
                          "alert('Added Succesfully');window.location='AddMaterial.aspx';", true);
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
                okn = dbc.insert_tblsunotifications("Message", Convert.ToInt32(Session["empid"].ToString()), lblCustName.Text, empdesig, Convert.ToInt32(drn["intId"].ToString()), "Admin ", "Product Added From Inventory Product Name: " + txtName.Text + "", "NA", "NA", "Unread", "Emp");
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
    protected void btnReset_Click(object sender, EventArgs e)
    {
        clear();
    }
}