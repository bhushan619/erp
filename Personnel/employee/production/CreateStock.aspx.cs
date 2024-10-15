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
            dt = new DataTable();
            MakeDataTable();
        }
        else
        {
            dt = (DataTable)ViewState["DataTable"];
        }
        ViewState["DataTable"] = dt;
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
    private void MakeDataTable()
    { 
        dt.Columns.Add("Product Name");
        dt.Columns.Add("Qty"); 
    }

    private void AddToDataTable()
    {
        DataRow dr = dt.NewRow();

      
        dr["Product Name"] = ddlMaterial.Text;
        dr["Qty"] = txtQty.Text; 

        dt.Rows.Add(dr);
 

    }

    private void BindGrid()
    {
        grdMatDetails.DataSource = dt;
        grdMatDetails.DataBind();
    }
    protected void grdOrderDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            string id = commandArgs[0]; 
            string qty = commandArgs[1];

            if (e.CommandName == "remove")
            {
                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int RemoveAt = gvr.RowIndex;
                dt = (DataTable)ViewState["DataTable"];
                dt.Rows.RemoveAt(RemoveAt);
                dt.AcceptChanges();
                orderrow--;
                ViewState["DataTable"] = dt;
                BindGrid();
                lblTotal.Text = (Convert.ToInt32(lblTotal.Text) - Convert.ToInt32(qty)).ToString();
           
            }
        }
        catch (Exception ex)
        {
            throw;
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
                if (dt.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(
                         this,
                         this.GetType(),
                         "MessageBox",
                         "alert('Please select Raw Material');", true);
                }
                else
                {
                    foreach (DataRow row in dt.Rows)
                    {

                        rawmaterial = rawmaterial + row["Product Name"].ToString() + " " + row["Qty"].ToString() + " Kg ";

                        string ton = (Convert.ToDouble(row["Qty"].ToString()) / 1000).ToString();

                        int rawid = dbcs.get_RawId(row["Product Name"].ToString());

                        Double newtsockkg = dbcs.get_RawIdStockKg(rawid) - Convert.ToDouble(row["Qty"].ToString());
                        Double newtsockton = dbcs.get_RawIdStockTon(rawid) - Convert.ToDouble(ton);

                        dbcs.con.Open();
                        MySql.Data.MySqlClient.MySqlCommand cmdd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblrawmaterial SET varWeightKg ='" + newtsockkg + "', varWeightTon ='" + newtsockton + "' WHERE intId = " + rawid + "", dbcs.con);
                        cmdd.ExecuteNonQuery();
                        dbcs.con.Close();
                    }

                    int maxrawid = dbcs.max_tblrawmaterialhistoryId();
                    maxrawid++;

                    dbcs.con.Open();                                                                                         //  intId, intProductId, pname intSack, intNug, varUnit, dtDate, tmTime, varUpdater, varReason, varTransport, varRemark
                    MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblrawmaterialhistory VALUES (" + maxrawid + ",'" + rawmaterial + "','" + lblTotal.Text + "','Kg','" + (Convert.ToDouble(lblTotal.Text) / 1000).ToString() + "','Ton','" + txtDate.Text + "','" + txtTime.Text + "','" + lblCustName.Text + "','" + txtReason.Text + "','StockRemoved','Remove','NA','NA',0,0,0)", dbcs.con);
                    cmd1.ExecuteNonQuery();
                    dbcs.con.Close();
                    cmd1.Dispose();


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
                         "alert('Product Added Successfully');window.location='CreateStock.aspx';", true);
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
    protected void btnReset_Click(object sender, EventArgs e)
    {
        clear();

    }
    
    public void clear()
    {
        ddlProName.SelectedIndex = 0; 
        txtReason.Text = "";
        txtDate.Text = ""; 
        txtTotalProduct.Text = 0.ToString();
        txtTime.Text = "";
        lblNug.Text = "Nug";
        lblSack.Text = "Sack";
        lblTotal.Text = "Total Material";
        dt.Rows.Clear();
        BindGrid();
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
   
    
    public void onclearfocus()
    {
        txtQty.Attributes.Add("onblur", "javascript:if(this.value=='') this.value='0';");
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
    protected void btnAddMaterial_Click(object sender, EventArgs e)
    {
        if (ddlMaterial.Text == "-- Material Used --")
        {
            ScriptManager.RegisterStartupScript(
                     this,
                     this.GetType(),
                     "MessageBox",
                     "alert('Please select Material');", true);

        }
        else if (txtQty.Text == "0")
        {
            ScriptManager.RegisterStartupScript(
                     this,
                     this.GetType(),
                     "MessageBox",
                     "alert('Quantity must not be 0');", true);
        }
        else
        {
            if (dbc.get_RawIdStockKg(dbc.get_RawId(ddlMaterial.Text)) < Convert.ToDouble(txtQty.Text))
            {
                ScriptManager.RegisterStartupScript(
                       this,
                       this.GetType(),
                       "MessageBox",
                       "alert('Please enter less than " + dbc.get_RawIdStockKg(dbc.get_RawId(ddlMaterial.Text)).ToString() + "');", true);

                //  Response.Write("<script>alert('Please enter less than " + dbc.get_RawIdStockKg(dbc.get_RawId("LLDP")).ToString() + "');</script>");
                txtQty.Text = 0.ToString();
            }
            else if (dbc.get_RawIdStockKg(dbc.get_RawId(ddlMaterial.Text)) == Convert.ToDouble(txtQty.Text))
            {
                lblTotal.Text = (Convert.ToInt64(lblTotal.Text) + Convert.ToInt64(txtQty.Text)).ToString();
                AddToDataTable();
                BindGrid();
                addclear();
            }
            else
            {
                lblTotal.Text = (Convert.ToInt64(lblTotal.Text) + Convert.ToInt64(txtQty.Text)).ToString();
                AddToDataTable();
                BindGrid();
                addclear();
            }
        }       
    }
    public void addclear()
    {
        ddlMaterial.Text = "-- Material Used --";
        txtQty.Text = 0.ToString();
    }
}