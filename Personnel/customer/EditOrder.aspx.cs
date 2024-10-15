using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Personnel_customer_EditOrder : System.Web.UI.Page
{
   
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
}