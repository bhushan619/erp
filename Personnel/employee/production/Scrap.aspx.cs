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
using MySql.Data.MySqlClient;

public partial class Personnel_employee_production_Scrap : System.Web.UI.Page
{
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();
    static string custstate = string.Empty, reason = string.Empty, empdesig = string.Empty;
    static string unita = string.Empty, ordernumber = string.Empty, dat = string.Empty, tim = string.Empty;
    static int sack = 0, nug = 0, ppid = 0;
    static int pId = 0, orderrow = 1, custId = 0, prices = 0, packing = 0, packingj = 0;
    DataTable dt, dt2;
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
            SqlDataSource2.SelectCommand = "SELECT distinct CONCAT(nvarProductName,' ',nvarProductSubType ,' ', intSize,' ', varUnit) as ProductName FROM sanghaviunbreakables.tblsuproducts where nvarStatus!='-'";

            expiring_data();
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
        try
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
        }
        catch (Exception ex)
        {
            Response.Redirect("~/SignUpLogin.aspx");
        }
        //  SqlDataSourceMedia.SelectCommand = "SELECT [imgImage] FROM tblsucustomer where intId=" + Convert.ToInt32(Session["empid"].ToString()) + "";
    }

    protected void ddlProName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string myStr = ddlProName.Text;
            string[] ssize = myStr.Split(new char[0]);
            //char[] whitespace = new char[] { ' ', '\t' };

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intPacking,intId FROM sanghaviunbreakables.tblsuproducts where nvarProductName='" + ssize[0].ToString() + "' and nvarProductSubType='" + ssize[1].ToString() + "' and intSize='" + ssize[2].ToString() + "'", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                pId = Convert.ToInt32(dbc.dr["intId"].ToString());
                packing = Convert.ToInt32(dbc.dr["intPacking"].ToString());
                dbc.con.Close();
                dbc.dr.Close();
            }
            lblSack.Text = "Sack";
            lblNug.Text = "Nug";
            txtTotalProducts.Text = 0.ToString();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
        }
    }
    protected void txtSack_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlProName.Text == "-- Select Product --")
            {
                ScriptManager.RegisterStartupScript(
                 this,
                 this.GetType(),
                 "MessageBox",
                 "alert('Please select product');", true);
                txtTotalProducts.Text = 0.ToString();
            }
            else
            {

                lblSack.Text = (Convert.ToInt64(txtTotalProducts.Text) / packing).ToString();
                Int64 temp = Convert.ToInt64(lblSack.Text) * packing;
                lblNug.Text = (Convert.ToInt64(txtTotalProducts.Text) - temp).ToString();

            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnAddToOrder_Click(object sender, EventArgs e)
    {
        try
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
            DatabaseConnection dbcs = new DatabaseConnection();
            string rawmaterial = string.Empty;

            int pid = dbcs.max_tblstockhistory();
            pid = pid + 1;
            dbcs.con.Open();                                                                                       //  intId, intProductId, pname intSack, intNug, varUnit, dtDate, tmTime, varUpdater, varReason, varTransport, varRemark
           
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsustockhistory VALUES(" + pid + "," + pId + ",'" + ddlProName.Text + "','" + rawmaterial + "'," + lblSack.Text + "," + lblNug.Text + ",'" + unita + "','" + txtDate.Text + "','" + txtTime.Text + "','" + lblCustName.Text + "','" + txtRemark.Text + "','NA','" + txtRemark.Text + "','Remove','NA','')", dbcs.con);
            cmd.ExecuteNonQuery();
            dbcs.con.Close();
            cmd.Dispose();

            dbcs.con.Open();                                                                                         //  intId, intProductId, pname intSack, intNug, varUnit, dtDate, tmTime, varUpdater, varReason, varTransport, varRemark
            MySql.Data.MySqlClient.MySqlCommand cmdaa = new MySql.Data.MySqlClient.MySqlCommand("select intSack,intNug from sanghaviunbreakables.tblsustockvarkhedi where intProductId=" + pId + " ", dbcs.con);
            dr = cmdaa.ExecuteReader();
            string oldsack = string.Empty, oldnug = string.Empty;
            if (dr.Read())
            {
                oldsack = dr["intSack"].ToString();
                oldnug = dr["intNug"].ToString();
            }
            dbcs.con.Close();
            cmdaa.Dispose();

            //lblSack.Text = (Convert.ToInt64(txtTotalProduct.Text) / packing).ToString();
            //Int64 temp = Convert.ToInt64(lblSack.Text) * packing;
            //lblNug.Text = (Convert.ToInt64(txtTotalProduct.Text) - temp).ToString();
            string allnug = ((Convert.ToInt64(oldsack) * packing) + Convert.ToInt64(oldnug)).ToString();
            string newnug = ((Convert.ToInt64(lblSack.Text) * packing) + Convert.ToInt64(lblNug.Text)).ToString();

            string upall = (Convert.ToInt64(allnug) - Convert.ToInt64(newnug)).ToString();

            string upsack = (Convert.ToInt64(upall) / packing).ToString();
            Int64 temp = Convert.ToInt64(upsack) * packing;
            string upnug = (Convert.ToInt64(upall) - temp).ToString();


            dbcs.con.Open();                                                                                         //  intId, intProductId, pname intSack, intNug, varUnit, dtDate, tmTime, varUpdater, varReason, varTransport, varRemark
            MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsustockvarkhedi set intSack=" + upsack + ",intNug=" + upnug + " where intProductId=" + pId + " ", dbcs.con);
            cmda.ExecuteNonQuery();
            dbcs.con.Close();
            cmda.Dispose();

            ScriptManager.RegisterStartupScript(
                 this,
                 this.GetType(),
                 "MessageBox",
                 "alert('Product Rejected Successfully');window.location='Scrap.aspx';", true);


            //DatabaseConnection dbcs = new DatabaseConnection();
            //string rawmaterial = string.Empty;

            //int pid = dbcs.max_tblstockhistoryjalgaon();
            //pid = pid + 1;
            //dbcs.con.Open();                                                                                         //  intId, intProductId, pname intSack, intNug, varUnit, dtDate, tmTime, varUpdater, varReason, varTransport, varRemark
            //MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsustockhistoryjalgaon VALUES(" + pid + "," + pId + ",'" + ddlProName.Text + "'," + lblSack.Text + "," + lblNug.Text + ",'" + unita + "','" + txtDate.Text + "','" + txtTime.Text + "','" + lblCustName.Text + "','" + txtRemark.Text + "','NA','NA','Reject')", dbcs.con);
            //cmd.ExecuteNonQuery();                                                                                                                       
            //dbcs.con.Close();
            //cmd.Dispose();

            //dbcs.con.Open();                                                                                         //  intId, intProductId, pname intSack, intNug, varUnit, dtDate, tmTime, varUpdater, varReason, varTransport, varRemark
            //MySql.Data.MySqlClient.MySqlCommand cmdaa = new MySql.Data.MySqlClient.MySqlCommand("select intSack,intNug from sanghaviunbreakables.tblsustockjalgaon where intProductId=" + pId + " ", dbcs.con);
            //dr = cmdaa.ExecuteReader();
            //string oldsack = string.Empty, oldnug = string.Empty;
            //if (dr.Read())
            //{
            //    oldsack = dr["intSack"].ToString();
            //    oldnug = dr["intNug"].ToString();
            //}
            //dbcs.con.Close();
            //cmdaa.Dispose();

            ////lblSack.Text = (Convert.ToInt64(txtTotalProduct.Text) / packing).ToString();
            ////Int64 temp = Convert.ToInt64(lblSack.Text) * packing;
            ////lblNug.Text = (Convert.ToInt64(txtTotalProduct.Text) - temp).ToString();
            //string allnug = ((Convert.ToInt64(oldsack) * packing) + Convert.ToInt64(oldnug)).ToString();
            //string newnug = ((Convert.ToInt64(lblSack.Text) * packing) + Convert.ToInt64(lblNug.Text)).ToString();

            //string upall = (Convert.ToInt64(allnug) - Convert.ToInt64(newnug)).ToString();

            //string upsack = (Convert.ToInt64(upall) / packing).ToString();
            //Int64 temp = Convert.ToInt64(upsack) * packing;
            //string upnug = (Convert.ToInt64(upall) - temp).ToString();


            //dbcs.con.Open();                                                                                         //  intId, intProductId, pname intSack, intNug, varUnit, dtDate, tmTime, varUpdater, varReason, varTransport, varRemark
            //MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsustockjalgaon set intSack=" + upsack + ",intNug=" + upnug + " where intProductId=" + pId + " ", dbcs.con);
            //cmda.ExecuteNonQuery();
            //dbcs.con.Close();
            //cmda.Dispose();

            //ScriptManager.RegisterStartupScript(
            //     this,
            //     this.GetType(),
            //     "MessageBox",
            //     "alert('Product Rejected Successfully');window.location='Rejection.aspx';", true);
            
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
    protected void btnReset_Click(object sender, EventArgs e)
    {
        clear();
    }

    public void clear()
    {
        ddlProName.SelectedIndex = 0;
        lblSack.Text = "Sack";
        txtDate.Text = "";
        txtTime.Text = "";
        txtRemark.Text = "";
        lblNug.Text = "Nug";
        txtTotalProducts.Text = 0.ToString();
    }

    public void expiring_data()
    {

        try
        {
            dt2 = new DataTable();
            dbc.con.Open();
            // MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT sanghaviunbreakables.tblsuproducts.intId, CONCAT(tblsuproducts.nvarProductName,' ', tblsuproducts.intSize,' ', tblsuproducts.varUnit) as nvarProductName, sanghaviunbreakables.tblsustockjalgaon.intSack, sanghaviunbreakables.tblsustockjalgaon.intNug, tblsuproducts.intPacking * tblsustockjalgaon.intSack + tblsustockjalgaon.intNug AS total FROM sanghaviunbreakables.tblsuproducts INNER JOIN sanghaviunbreakables.tblsustockjalgaon ON sanghaviunbreakables.tblsuproducts.intId = sanghaviunbreakables.tblsustockjalgaon.intProductId", dbc.con);

            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT sanghaviunbreakables.tblsuproducts.intId, CONCAT(tblsuproducts.nvarProductName,' ', tblsuproducts.intSize,' ', tblsuproducts.varUnit) as nvarProductName, sanghaviunbreakables.tblsustockvarkhedi.intSack, sanghaviunbreakables.tblsustockvarkhedi.intNug, tblsuproducts.intPacking * tblsustockvarkhedi.intSack + tblsustockvarkhedi.intNug AS total FROM sanghaviunbreakables.tblsuproducts INNER JOIN sanghaviunbreakables.tblsustockvarkhedi ON sanghaviunbreakables.tblsuproducts.intId = sanghaviunbreakables.tblsustockvarkhedi.intProductId", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);

            ad1.Fill(dt2);

            gridvar.DataSource = dt2;
            gridvar.DataBind();
            dbc.con.Close();

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void gridvar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridvar.PageIndex = e.NewPageIndex;
        expiring_data();
    }
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

}