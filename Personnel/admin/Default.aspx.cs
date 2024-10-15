using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

public partial class Personnel_Admin_Default : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataTable dt2= new DataTable();
    DataTable dt3 = new DataTable();
    int wsack, pack, wnug;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../SignUpLogin.aspx';</script>");
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        else if (!IsPostBack)
        {
            try
            {
                getAdmindata();

                getImage();
                getAdmin();
                SqlDataSourceDSR.SelectCommand = "SELECT intId, varEmpName, varDate, varLocation, varCallType, varCustName, varRepersentName, varLandline, varMobile, varRemark, varNextDate FROM tblsudsrdetails WHERE CAST(STR_TO_DATE(varNextDate,'%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd-MM-yyyy", CultureInfo.InvariantCulture) + "','%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd-MM-yyyy", CultureInfo.InvariantCulture) + "','%d-%m-%Y') AS DATE)";
                notifications();
            }
            catch (Exception ex) { Response.Write(ex.Message); }
        }
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["adminid"].ToString()), "Admin").ToString();
    }
 
    DatabaseConnection dbc = new DatabaseConnection();

    public void getAdmindata()
    {
        try
        {

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varName FROM sanghaviunbreakables.tblsupersonnel where intId=" + Session["adminid"].ToString() + "", dbc.con);

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
        string ImageUr = dbc.select_empProfilePic(Convert.ToInt32(Session["adminid"].ToString()));
        if (ImageUr == "")
        {
            imgProPic.ImageUrl = "~/Personnel/admin/media/NoProfile.png";
        }
        else
        {

            imgProPic.ImageUrl = "~/Personnel/admin/media/" + ImageUr;
        }
        //  SqlDataSourceMedia.SelectCommand = "SELECT [imgImage] FROM tblsucustomer where intId=" + Convert.ToInt32(Session["adminid"].ToString()) + "";
    }

    private void getAdmin()
    {
        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varName as  Name, varMobile as Mobile,dtDateOfBirth as ' Date of Birth', varAddress as Address, varCity as City, varState as State   FROM sanghaviunbreakables.tblsupersonnel where intId=" + Session["adminid"].ToString() + "", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            ad.Fill(dt);
            dtlsViewProfile.DataSource = dt;
            dtlsViewProfile.DataBind();
            dbc.con.Close();
        }
        catch (Exception ex)
        {
             Response.Write("<script>alert('Please Try Again');</script>");
        }
    }

    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Session["adminid"] = "";
        Session.Remove("adminid");

        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();

        Response.Redirect("~/Default.aspx");
    }
    //protected void gridexp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    gridexp.PageIndex = e.NewPageIndex;
    //    expiring_data();

    //}
    //protected void gridvar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    gridvar.PageIndex = e.NewPageIndex;
    //    expiring_data();
    //}
}