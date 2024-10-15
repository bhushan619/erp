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

public partial class Personnel_employee_CreateStock : System.Web.UI.Page
{
    public static string empdesig = string.Empty;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();
    static string custstate = string.Empty, reason = string.Empty;
    static string unita = string.Empty, ordernumber = string.Empty, dat = string.Empty, tim = string.Empty;
    static int sack = 0, nug = 0, ppid = 0;
    static int pId = 0, orderrow = 1, custId = 0, prices = 0, packing = 0, packingj=0;
    DataTable dt;
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
            onclearfocus();
           
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
    protected void ddlProName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string price = string.Empty;
            string myStr = ddlProName.Text;
            string[] ssize = myStr.Split(new char[0]);
            pId = 0;
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varUnit,intPacking FROM sanghaviunbreakables.tblsuproducts where nvarProductName='" + ssize[0].ToString() + "' and nvarProductSubType='" + ssize[1].ToString() + "' and intSize='" + ssize[2].ToString() + "'", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                pId = Convert.ToInt32(dbc.dr["intId"].ToString());
                unita = dbc.dr["varUnit"].ToString();
                packing = Convert.ToInt32(dbc.dr["intPacking"].ToString());
                dbc.con.Close();
                dbc.dr.Close();
            }
           

        }
        catch (Exception ex)
        {
            dbc.con.Close();
            dbc.dr.Close();
            Response.Write("<script>alert('Please Try Again');</script>");
        }
    }
    public void getall()
    {
      
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
                dbcs.con.Open();                                                                                         //  intId, intProductId, pname intSack, intNug, varUnit, dtDate, tmTime, varUpdater, varReason, varTransport, varRemark
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsustockhistory VALUES(" + pid + "," + pId + ",'" + ddlProName.Text + "','" + rawmaterial + "'," + lblSack.Text + "," + lblNug.Text + ",'" + unita + "','" + txtDate.Text + "','" + txtTime.Text + "','" + lblCustName.Text + "','" + txtReason.Text + "','NA','" + txtReason.Text + "','Add','NA','')", dbcs.con);
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

                string upall = (Convert.ToInt64(allnug) + Convert.ToInt64(newnug)).ToString();

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
                     "alert('Product Added Successfully');window.location='InwardStock.aspx';", true);
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
        txtReason.Text = "";
       // txtDate.Text = ""; 
        txtTotalProduct.Text = 0.ToString();
     //  txtTime.Text = "";
        lblNug.Text = "Nug";
        lblSack.Text = "Sack";
        //lblTotal.Text = "Total Material";
        
     
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

        Response.Redirect("~/Default.aspx", false);
    }
   
    
    public void onclearfocus()
    {
       // txtQty.Attributes.Add("onblur", "javascript:if(this.value=='') this.value='0';");
        txtTotalProduct.Attributes.Add("onblur", "javascript:if(this.value=='') this.value='0';");
    }
    protected void txtTotalProduct_TextChanged(object sender, EventArgs e)
    {
        if (ddlProName.Text == "-- Select Product --")
        {
             ScriptManager.RegisterStartupScript(
              this,
              this.GetType(),
              "MessageBox",
              "alert('Please select product');", true);
            txtTotalProduct.Text = 0.ToString();
        }
        else
        {
            if (txtTotalProduct.Text == "0")
            {
                Response.Write("<script>alert('Please enter value more than 0');</script>");
            }
            else
            {
                lblSack.Text = (Convert.ToInt64(txtTotalProduct.Text)/packing).ToString();
                Int64 temp = Convert.ToInt64(lblSack.Text) * packing;
                lblNug.Text = (Convert.ToInt64(txtTotalProduct.Text) - temp).ToString();
            }
        }
    }
  
}