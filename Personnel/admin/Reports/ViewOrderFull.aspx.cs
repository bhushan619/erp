using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class Personnel_employee_View_Order_Full : System.Web.UI.Page
{
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();
    DataTable dt1 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt2 = new DataTable();
    static int packing = 0, orderrow = 1, custId = 0, prices = 0;
    static string empdesig = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../../SignUpLogin.aspx';</script>");
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }

        else if (Session["orderid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='ViewOrder.aspx';</script>");

        }
        else if (!IsPostBack)
        {
            getImage();
            getempname();
            notifications();
            lblOrderNo.Text = Session["orderid"].ToString();
            getData();
            expiring_data();
        }
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["adminid"].ToString()), empdesig).ToString();
    }
    public void getempname()
    {
        try
        {

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varName,varSubDesig FROM sanghaviunbreakables.tblsupersonnel where intId=" + Session["adminid"].ToString() + "", dbc.con);

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
    public void getData()
    {
        try
        {
            dbc.con.Open();
            DataSet ds = new DataSet();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intOrderId,varTransport, varBookingId,(SELECT varCompanyName from sanghaviunbreakables.tblsucustomer WHERE (intId =" + Session["empcustid"] + ") ) as comname,(SELECT varMobile from sanghaviunbreakables.tblsucustomer WHERE (intId = " + Session["empcustid"] + ") ) as mobile, varStatus, dtDate, varProductTotal, varTotalNag, varPriceTotal,intEmpId, ex1, ex2, varTransport FROM sanghaviunbreakables.tblsuorder WHERE (intOrderId = " + Session["orderid"] + ")", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);

            adp.Fill(ds);
            listorder.DataSource = ds;
            listorder.DataBind();

            MySql.Data.MySqlClient.MySqlDataReader dr1;
            dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                txtBookingId.Text = dr1["varBookingId"].ToString();
                txtTotalPrice.Text = dr1["varPriceTotal"].ToString();
                txtDate.Text = dr1["dtDate"].ToString();
                ddlEmployee.SelectedValue = dr1["intEmpId"].ToString();
                txtLRNo.Text = dr1["ex1"].ToString();
                txtDiscount.Text = dr1["ex2"].ToString();
                txtTransport.Text = dr1["varTransport"].ToString();
            }
            dbc.con.Close();
            cmd.Dispose();
            adp.Dispose();


            SqlDataSourceEmp.SelectCommand = "SELECT intId, varName, varMobile, varMobileVerify, varEmail, varEmailVerify, varPassword, varAddress, varCity, varState, varDesignation, varSubDesig, varStatus, varIDProof, varIDProofNo, varPanCardNo, imgImage, dtDateOfBirth FROM tblsupersonnel WHERE varDesignation='Employee'";
            ddlEmployee.DataValueField = "intId";
            ddlEmployee.DataTextField = "varName";
        }
        catch (Exception ex)
        {
            dbc.con.Close();
        }



    }
    public void getImage()
    {
        try
        {
            string ImageUr = dbc.select_empProfilePic(Convert.ToInt32(Session["adminid"].ToString()));
            if (ImageUr == "")
            {
                imgProPic.ImageUrl = "~/Personnel/employee/media/NoProfile.png";
            }
            else
            {

                imgProPic.ImageUrl = "~/Personnel/admin/media/" + ImageUr;
            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
        }
        //  SqlDataSourceMedia.SelectCommand = "SELECT [imgImage] FROM tblsucustomer where intId=" + Convert.ToInt32(Session["adminid"].ToString()) + "";
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

    public void expiring_data()
    {

        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT sanghaviunbreakables.tblsuproducts.intId, sanghaviunbreakables.tblsuproducts.nvarProductName, sanghaviunbreakables.tblsustockjalgaon.intSack, sanghaviunbreakables.tblsustockjalgaon.intNug, tblsuproducts.intPacking * tblsustockjalgaon.intSack + tblsustockjalgaon.intNug AS total FROM sanghaviunbreakables.tblsuproducts INNER JOIN sanghaviunbreakables.tblsustockjalgaon ON sanghaviunbreakables.tblsuproducts.intId = sanghaviunbreakables.tblsustockjalgaon.intProductId", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);

            ad.Fill(dt1);

            gridexp.DataSource = dt1;
            gridexp.DataBind();
            dbc.con.Close();

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT sanghaviunbreakables.tblsuproducts.intId, sanghaviunbreakables.tblsuproducts.nvarProductName, sanghaviunbreakables.tblsustockvarkhedi.intSack, sanghaviunbreakables.tblsustockvarkhedi.intNug, tblsuproducts.intPacking * tblsustockvarkhedi.intSack + tblsustockvarkhedi.intNug AS total FROM sanghaviunbreakables.tblsuproducts INNER JOIN sanghaviunbreakables.tblsustockvarkhedi ON sanghaviunbreakables.tblsuproducts.intId = sanghaviunbreakables.tblsustockvarkhedi.intProductId", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);

            ad1.Fill(dt2);

            gridvar.DataSource = dt2;
            gridvar.DataBind();
            dbc.con.Close();

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varName AS Name, varWeightKg AS Kg, varWeightTon AS Ton FROM tblrawmaterial", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad2 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd2);

            ad2.Fill(dt3);

            grdRaw.DataSource = dt3;
            grdRaw.DataBind();
            dbc.con.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void grdRaw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdRaw.PageIndex = e.NewPageIndex;
        expiring_data();


    }
    protected void gridexp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridexp.PageIndex = e.NewPageIndex;
        expiring_data();

    }
    protected void gridvar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridvar.PageIndex = e.NewPageIndex;
        expiring_data();
    }
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                dbc.con.Open();
                dbc.cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblsuorder SET intEmpId=" + ddlEmployee.SelectedValue + ", varPriceTotal='" + txtTotalPrice.Text + "', varTransport='" + txtTransport.Text + "',dtDate='" + txtDate.Text + "',ex1='" + txtLRNo.Text + "',ex2='" + txtDiscount.Text + "',varTransport='" + txtTransport.Text + "' WHERE intOrderId = " + Session["orderid"] + "", dbc.con);
                dbc.cmd.ExecuteNonQuery();
                dbc.con.Close();

                Response.Write("<script>alert('Order number : " + Session["orderid"] + "  Upadated');window.location='ViewOrder.aspx';</script>");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            }
        }
        catch (Exception ex)
        {
            string esx = ex.Message;
        }
    }
}