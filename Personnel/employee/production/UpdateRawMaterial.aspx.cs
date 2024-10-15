using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Personnel_employee_production_UpdateRawMaterial : System.Web.UI.Page
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
                int insert_ok = dbc.update_rawMaterial(ddlNameRaw.Text, txtweightkg.Text, txtweightton.Text, txtDate.Text, txtTime.Text, lblCustName.Text, txtreason.Text, "NA", txtBillno.Text, txtvendorName.Text, Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtDiscount.Text), Convert.ToDouble(txtAmount.Text));

                if (insert_ok == 1)
                {
                    ScriptManager.RegisterStartupScript(
                     this,
                     this.GetType(),
                     "MessageBox",
                     "alert('Raw Material Added Successfully');window.location='UpdateRawMaterial.aspx';", true);

                    clear();
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
    public void clear()
    {
        ddlNameRaw.SelectedIndex =1;
       
        txtreason.Text = "";
        txtweightkg.Text = "";
        txtweightton.Text = "";
        txtBillno.Text = "";
        txtDiscount.Text = "";
        txtRate.Text = "";
        txtvendorName.Text = "";

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void txtweightkg_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtweightkg.Text == "")
            {
            }
            else
            {
                if (ddlNameRaw.Text != "-- Select Product --")
                {
                    txtweightton.Text = (Convert.ToDouble(txtweightkg.Text) / 1000).ToString();
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
    protected void txtweightton_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtweightton.Text == "")
            {
            }
            else
            {
                if (ddlNameRaw.Text != "-- Select Product --")
                {
                    txtweightkg.Text = (1000 * Convert.ToDouble(txtweightton.Text)).ToString();
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