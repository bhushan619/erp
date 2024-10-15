using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Personnel_customer_EditProfileOther : System.Web.UI.Page
{
    
    DatabaseConnection dbc = new DatabaseConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
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
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["custid"].ToString()), "Customer").ToString();
    }
  
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
    protected void lnkLogoutUp_Click(object sender, EventArgs e)
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            int insert_ok = dbc.update_tblsucustomeradminother(Session["custid"].ToString(), txtRepName.Text, txtDesig.Text, txtContact.Text, txtDOB.Text, txtRemark.Text);
            if (insert_ok == 1)
            {
                Response.Write("<script>alert('Data Updated');window.location='EditProfileOther.aspx';</script>");
            }

        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
        }
    }
    public void clear()
    {
        txtContact.Text = "";
        txtDesig.Text = "";
        txtDOB.Text = "";
        txtRemark.Text = "";
        txtRepName.Text = "";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Personnel/admin/ViewCustomer.aspx");
    }
    protected void grdOrderDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "remove")
            {
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("DELETE from tblsucustomerotherdetails WHERE intId = " + Convert.ToInt32(e.CommandArgument) + "", dbc.con);
                cmd.ExecuteNonQuery();
                dbc.con.Close();
                Response.Write("<script>alert('Data Updated');window.location='EditProfileOther.aspx';</script>");
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}