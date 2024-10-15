using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Personnel_employee_marketing_ViewFullProduct : System.Web.UI.Page
{

    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();
    public static string empdesig = string.Empty;
    string imgurl = string.Empty;
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
            getProductdata();
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
    public void getProductdata()
    {
        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, nvarProductName, nvarProductType, nvarProductSubType, tblsuproductcode, intSize, intPacking, intDealerPrice, intMRP, nvarDescription, imgImage, nvarStatus, varUnit, varWeight, intMMSMPDealer, intMSMPMRP, intAllStateDealer, intAllStateMRP FROM sanghaviunbreakables.tblsuproducts where intId=" + Session["productbyMark"].ToString() + "", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
               // txtCode.Text = dbc.dr["tblsuproductcode"].ToString();
            
                lblProductName.Text = dbc.dr["nvarProductName"].ToString();
               lblproductnmaespec.Text = dbc.dr["nvarProductName"].ToString();
                lblsize.Text = dbc.dr["intSize"].ToString();
                lblpacking.Text = dbc.dr["intPacking"].ToString();
                lblprice.Text = dbc.dr["intDealerPrice"].ToString();
                lblmrp.Text = dbc.dr["intMRP"].ToString();
                lbldescrip.Text = dbc.dr["nvarDescription"].ToString();
                //txtMSMPPrice.Text = dbc.dr["intMSMPMRP"].ToString();
                //txtMSMPDealer.Text = dbc.dr["intMMSMPDealer"].ToString();
                //txtAllStateMRP.Text = dbc.dr["intAllStateMRP"].ToString();
                //txtAllStatePrice.Text = dbc.dr["intAllStateDealer"].ToString();
                lblunit.Text = dbc.dr["varUnit"].ToString();
                lblweight.Text = dbc.dr["varWeight"].ToString();
                ImgProduct.ImageUrl = "~/Personnel/admin/media/product/" + dbc.dr["imgImage"].ToString();

               prodimg.HRef = "~/Personnel/admin/media/product/" + dbc.dr["imgImage"].ToString();
                lblproducttype.Text = dbc.dr["nvarProductType"].ToString();
               // changeProType(dbc.dr["nvarProductType"].ToString());
                lblproductsubtype.Text = dbc.dr["nvarProductSubType"].ToString();
                lblpsub.Text = dbc.dr["nvarProductSubType"].ToString();
                lblimgtitle.Text = string.Concat(lblProductName.Text, lblproductsubtype.Text);
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
}