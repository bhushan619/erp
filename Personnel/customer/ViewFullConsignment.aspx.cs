using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Personnel_employee_subadmin_ViewFullConsignment : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    static Uri previousUri;
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
            getconno();
           notifications();
            previousUri = Request.UrlReferrer;
        //    SqlDataSource2.SelectCommand = "SELECT intSrNo AS Srno, intConsigmentNo, varProductName AS `Product Name`, varSack AS Sack, varNug AS Nug, varRate AS Rate, varPer AS PER, varVat AS VAT, varDisc AS Disc, varPrice AS Price FROM sanghaviunbreakables.tblsuconsignmentdetails WHERE (tblsuconsignmentdetails.intConsigmentNo = " + Convert.ToInt32(Session["consno"].ToString()) + ")";
        //    SqlDataSource1.SelectCommand = "SELECT   intConsigmentNo AS ConsignmentNo, intBillNo AS BillNo, intOrderId AS OrderNo, dtDate AS `Date`, tmTime AS `Time`, varStatus AS Status FROM tblsuconsignment WHERE (intConsigmentNo =" + Convert.ToInt32(Session["consno"].ToString()) + ")  ORDER BY varStatus";
        }
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["custid"].ToString()), "Customer").ToString();
    }
  
    public void getconno()
    {
        try
        {

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT   intConsigmentNo AS ConsignmentNo FROM sanghaviunbreakables.tblsuconsignment WHERE (intConsigmentNo =" + Convert.ToInt32(Session["consno"].ToString()) + ")", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblConsNo.Text = dbc.dr["ConsignmentNo"].ToString();

                dbc.con.Close();
                dbc.dr.Close();
            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
        }
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

    protected void lnkBack_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect(previousUri.ToString());
        }
        catch (Exception ex)
        {

        }
    }
}