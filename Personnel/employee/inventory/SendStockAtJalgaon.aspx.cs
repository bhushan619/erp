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

public partial class Personnel_employee_SendStockAtJalgaon : System.Web.UI.Page
{
    public static string empdesig = string.Empty;
    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();
    static string custstate = string.Empty, reason = string.Empty;
    static string unita = string.Empty, ordernumber = string.Empty, dat = string.Empty, tim = string.Empty;
    static int sack = 0, nug = 0, ppid = 0;
    static int pId = 0, orderrow = 1, custId = 0, prices = 0, packing = 0, packingj = 0;
    DataTable dt;
    private string r;
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
            lblProductTotalSack.Text = 0.ToString();
           
            lblProductTotalNag.Text = 0.ToString();
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
    private void MakeDataTable()
    {
        dt.Columns.Add("Product Name");
        dt.Columns.Add("Sack");
        dt.Columns.Add("Nag");
        dt.Columns.Add("Total");      
    }

    private void AddToDataTable()
    {
        DataRow dr = dt.NewRow();
        
        dr["Product Name"] = ddlprodj.SelectedItem;
        dr["Sack"] = lblSack.Text;
        dr["Nag"] = lblNug.Text;
        dr["Total"] = txtTotalProducts.Text;

        dt.Rows.Add(dr);

        lblProductTotalSack.Text = (Convert.ToInt32(lblSack.Text) + Convert.ToInt32(lblProductTotalSack.Text)).ToString();
        lblProductTotalNag.Text = (Convert.ToInt32(lblNug.Text) + Convert.ToInt32(lblProductTotalNag.Text)).ToString();        
    }

    private void BindGrid()
    {
        grdOrderDetails.DataSource = dt;
        grdOrderDetails.DataBind();
    }
    protected void grdOrderDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            string id = commandArgs[0];
            string sacks = commandArgs[1];
            string nags = commandArgs[2];

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
                lblProductTotalSack.Text = (Convert.ToInt32(lblProductTotalSack.Text) - Convert.ToInt32(sacks)).ToString();
                lblProductTotalNag.Text = (Convert.ToInt32(lblProductTotalNag.Text) - Convert.ToInt32(nags)).ToString();
                clearj();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    protected void SendStockJ_Click(object sender, EventArgs e)
    {
        AddToDataTable();
        BindGrid();
        clearj();
    }


    protected void ddlprodj_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
               
            //string myStr = ddlprodj.Text;
           // string[] ssize = myStr.Split(new char[0]);     
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT tblsuproducts.intId,tblsuproducts.varUnit ,tblsuproducts.intPacking FROM   sanghaviunbreakables.tblsuproducts INNER JOIN sanghaviunbreakables.tblsustockvarkhedi ON sanghaviunbreakables.tblsuproducts.intId = sanghaviunbreakables.tblsustockvarkhedi.intId and sanghaviunbreakables.tblsuproducts.intId='" + ddlprodj.SelectedValue + "'", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                pId = Convert.ToInt32(dbc.dr["intId"].ToString());
                unita = dbc.dr["varUnit"].ToString();
                packingj = Convert.ToInt32(dbc.dr["intPacking"].ToString());
                dbc.con.Close();
                dbc.dr.Close();
            }          
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
            if (ddlprodj.Text == "-- Select Product --")
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
                if (txtTotalProducts.Text == "0")
                {
                    Response.Write("<script>alert('Please enter value more than 0');</script>");
                }
                else if (dbc.get_ProductStock(pId.ToString()) < Convert.ToInt64(txtTotalProducts.Text))
                {
                    ScriptManager.RegisterStartupScript(
                         this,
                         this.GetType(),
                         "MessageBox",
                         "alert('Please add value less than " + dbc.get_ProductStock(pId.ToString()) + "');", true);
                }
                else if (dbc.get_ProductStock(pId.ToString()) == Convert.ToInt64(txtTotalProducts.Text))
                {
                    lblSack.Text = (Convert.ToInt64(txtTotalProducts.Text) / packingj).ToString();
                    Int64 temp = Convert.ToInt64(lblSack.Text) * packingj;
                    lblNug.Text = (Convert.ToInt64(txtTotalProducts.Text) - temp).ToString();
                }
                else
                {
                    lblSack.Text = (Convert.ToInt64(txtTotalProducts.Text) / packingj).ToString();
                    Int64 temp = Convert.ToInt64(lblSack.Text) * packingj;
                    lblNug.Text = (Convert.ToInt64(txtTotalProducts.Text) - temp).ToString();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
        }

    }
    public void clearj()
    {
        ddlprodj.SelectedIndex = 0;
        txtTotalProducts.Text = 0.ToString(); 
        txtreasonj.Text = "";         
        txttransj.Text = "";
        lblNug.Text = "Nug";
        lblSack.Text = "Sack";
    }
    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        clearj();
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

        Response.Redirect("~/Default.aspx",false);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        { string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {

            int insert_ok = 0;
            foreach (DataRow r in dt.Rows)
            {
                string myStr = r["Product Name"].ToString();
                string[] ssize = myStr.Split(new char[0]);
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand("SELECT sanghaviunbreakables.tblsustockvarkhedi.intSack, sanghaviunbreakables.tblsustockvarkhedi.intNug, sanghaviunbreakables.tblsuproducts.intPacking, sanghaviunbreakables.tblsuproducts.varUnit, sanghaviunbreakables.tblsustockvarkhedi.intProductId FROM sanghaviunbreakables.tblsuproducts INNER JOIN sanghaviunbreakables.tblsustockvarkhedi ON sanghaviunbreakables.tblsuproducts.intId = sanghaviunbreakables.tblsustockvarkhedi.intProductId where sanghaviunbreakables.tblsuproducts.nvarProductName= '" + ssize[0].ToString() + "' and sanghaviunbreakables.tblsuproducts.nvarProductSubType='"+ ssize[1].ToString() + "' and intSize='" + ssize[2].ToString() + "'", dbc.con);

                dbc.dr = cmda.ExecuteReader();
                if (dbc.dr.Read())
                {
                    ppid = Convert.ToInt32(dbc.dr["intProductId"].ToString());
                    unita = dbc.dr["varUnit"].ToString();
                    sack = Convert.ToInt32(dbc.dr["intSack"].ToString());
                    nug = Convert.ToInt32(dbc.dr["intNug"].ToString());
                    packing = Convert.ToInt32(dbc.dr["intPacking"].ToString());
                    dbc.con.Close();
                    dbc.dr.Close();
                }

                string allnug = ((Convert.ToInt64(sack) * packing) + nug).ToString();

                string sendallnug = ((Convert.ToInt64(r["Sack"].ToString()) * packing) + Convert.ToInt64(r["Nag"].ToString())).ToString();

                string newnugvar = (Convert.ToInt64(allnug) - Convert.ToInt64(sendallnug)).ToString();

                string newsacku = (Convert.ToInt64(newnugvar) / packing).ToString();
                Int64 tempvaru = Convert.ToInt64(newsacku) * packing;
                string newnugsu = (Convert.ToInt64(newnugvar) - tempvaru).ToString();

                string newsacki = (Convert.ToInt64(sendallnug) / packing).ToString();
                Int64 tempvari = Convert.ToInt64(newsacki) * packing;
                string newnugsi = (Convert.ToInt64(sendallnug) - tempvari).ToString();
                // lblSack.Text = (Convert.ToInt64(txtTotalProduct.Text) / packing).ToString();
                // Int64 temp = Convert.ToInt64(lblSack.Text) * packing;
                // lblNug.Text = (Convert.ToInt64(txtTotalProduct.Text) - temp).ToString();
                insert_ok = dbc.insert_update_stockVerkhedisendjal(ppid, r["Product Name"].ToString(), Convert.ToInt64(newsacku), Convert.ToInt64(newnugsu), Convert.ToInt64(newsacki), Convert.ToInt64(newnugsi), unita, txtDate.Text, txtTime.Text, lblCustName.Text, txtreasonj.Text, txttransj.Text, "SentToJalgaon", txtChallnoNo.Text);

            }
            if (insert_ok == 1)
            {
                int ok = notification();
                if (ok == 1)
                {
                    Response.Write("<script>alert('Sent Stock To Jalgaon');window.location='SendStockAtJalgaon.aspx';</script>");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(
            this,
            this.GetType(),
            "MessageBox",
            "alert('Please Try Again');", true);
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
             "alert('Please Try Again');", true);
        }
    }
 
    public int notification()
    {
        try
        {
            int okn = 0;

           
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId FROM tblsupersonnel WHERE varSubDesig='Admin'", dbc.con);

            MySql.Data.MySqlClient.MySqlDataReader dre;
            dre = cmde.ExecuteReader();
            while (dre.Read())
            {
                okn = dbc.insert_tblsunotifications("Message", Convert.ToInt32(Session["empid"].ToString()), lblCustName.Text, empdesig, Convert.ToInt32(dre["intId"].ToString()), "Admin", "Stock Sent at Jalgaon from Varkhedi on " + txtDate.Text + "", "NA", "NA", "Unread", "Order");
            }
            dbc.con.Close();
            
                
              
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId FROM tblsupersonnel WHERE varSubDesig='Sub Admin'", dbc.con);

            MySql.Data.MySqlClient.MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                okn = dbc.insert_tblsunotifications("Page", Convert.ToInt32(Session["empid"].ToString()), lblCustName.Text, empdesig, Convert.ToInt32(dr["intId"].ToString()), "Sub Admin", "Stock Sent at Jalgaon from Varkhedi", "~/Personnel/employee/subadmin/RecieveStockJalgaon.aspx", "NA", "Unread", "Order");
            }
            dbc.con.Close();
           
            return okn;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
}