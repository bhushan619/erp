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

public partial class Personnel_customer_CreateOrder : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    static string custstate = string.Empty,status=string.Empty;
    static string pname = string.Empty, ordernumber = string.Empty;
    static int packing = 0, orderrow = 0, custId = 0, prices = 0;
    DataTable dt;
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
        {    getCustomerdata();
            ordernumber = dbc.max_tblOrderId().ToString();
            lblOrderNo.Text = ordernumber.ToString();
            lblOrderNo.Text = ordernumber.ToString();
            lblProductTotalSack.Text = 0.ToString();
            lblProductTotalPrice.Text = 0.ToString();
            lblProductTotalNag.Text = 0.ToString();
         
            getImage();
            notifications();
            SqlDataSource2.SelectCommand = "SELECT distinct CONCAT(nvarProductName,' ',nvarProductSubType ,' ', intSize,' ', varUnit) as ProductName FROM sanghaviunbreakables.tblsuproducts where nvarStatus!='-'";
            dt = new DataTable();
            MakeDataTable();
            orderrow = 0;
        }
        else
        {
            dt = (DataTable)ViewState["DataTable"];
        }
        ViewState["DataTable"] = dt;
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["custid"].ToString()), "Customer").ToString();
    }
    
    private void MakeDataTable()
    {
        dt.Columns.Add("SrNo");
        dt.Columns.Add("Product Name");
        dt.Columns.Add("Sack");
        dt.Columns.Add("Nag");
        dt.Columns.Add("Total");
        dt.Columns.Add("Price");
        dt.Columns.Add("Remark");
    }

    private void AddToDataTable()
    {
        DataRow dr = dt.NewRow();
        orderrow= orderrow+1;
        dr["SrNo"] =orderrow;
        dr["Product Name"] = ddlProName.Text;
        dr["Sack"] = lblSack.Text;
        dr["Nag"] = lblNug.Text;
        dr["Total"] = txtTotalProducts.Text;
        dr["Price"] = txtPrice.Text;
        dr["Remark"] = txtRemark.Text;

        dt.Rows.Add(dr);

        lblProductTotalSack.Text = (Convert.ToInt32(lblSack.Text) + Convert.ToInt32(lblProductTotalSack.Text)).ToString();
        lblProductTotalNag.Text = (Convert.ToInt32(lblNug.Text) + Convert.ToInt32(lblProductTotalNag.Text)).ToString();
        lblProductTotalPrice.Text = (Convert.ToInt32(txtPrice.Text) + Convert.ToInt32(lblProductTotalPrice.Text)).ToString();
    }

    private void BindGrid()
    {
        grdOrderDetails.DataSource = dt;
        grdOrderDetails.DataBind();
    }
 
    public void getCustomerdata()
    {
        try
        {

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varCompanyName,varRepresentativeName, varMobile, varEmail,varAddress, varCity, varState, varPanCardNo, varVatNo, varTinNo, dtDateOfEstd,varStatus FROM sanghaviunbreakables.tblsucustomer where intId=" + Session["custid"].ToString() + "", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblCustName.Text = dbc.dr["varCompanyName"].ToString();
                custstate = dbc.dr["varState"].ToString();
                status = dbc.dr["varStatus"].ToString();
                if (status == "blacklist")
                {
                    Response.Write("<script>alert('You are blacklisted by Owner and CANNOT Place Order.');window.location='Default.aspx';</script>");
                }
                else if (status == "Blacklist")
                {
                    Response.Write("<script>alert('You are blacklisted by Owner and CANNOT Place Order.');window.location='Default.aspx';</script>");
                }
                dbc.con.Close();
                dbc.dr.Close();
            }
            dbc.con.Close();
            dbc.dr.Close();
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

    protected void ddlProName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        { 
            string price = string.Empty;
            string myStr = ddlProName.Text;
            string[] ssize = myStr.Split(new char[0]);
            //char[] whitespace = new char[] { ' ', '\t' };
            if (custstate == "Maharashtra" || custstate == "Madhya Pradesh")
            {
                price = "intMMSMPDealer";
            }
            else
            {
                price = "intAllStateDealer";
            }
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT " + price + " as prices,intPacking FROM sanghaviunbreakables.tblsuproducts where nvarProductName='" + ssize[0].ToString() + "' and nvarProductSubType='" + ssize[1].ToString() + "' and intSize='" + ssize[2].ToString() + "'", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                txtPrice.Text = dbc.dr["prices"].ToString();
                prices = Convert.ToInt32(dbc.dr["prices"].ToString());
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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                int insert_order_ok = 0, insert_ok_orderdetails = 0;
                if (lblProductTotalNag.Text.Equals(0.ToString()))
                {
                    if (lblProductTotalSack.Text.Equals(0.ToString()))
                    {
                        Response.Write("<script>alert('Please add products order');</script>");
                    }
                    else
                    {
                        insert_order_ok = dbc.insert_order(ordernumber, Convert.ToInt32(Session["custid"].ToString()), 0.ToString(), lblProductTotalSack.Text, lblProductTotalNag.Text, lblProductTotalPrice.Text, txtModeOfPayment.Text, txtDestination.Text, "NA");
                        if (insert_order_ok == 1)
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                insert_ok_orderdetails = dbc.insert_orderdetails(ordernumber, r["Product Name"].ToString(), r["Sack"].ToString(), r["Nag"].ToString(), r["Price"].ToString(), r["Remark"].ToString());
                            }
                            if (insert_ok_orderdetails == 1)
                            {
                                int ok = notification();
                                if (ok == 1)
                                {
                                    Response.Write("<script>alert('Order Added');window.location='CreateOrder.aspx';</script>");
                                }
                            }
                        }
                    }
                }
                else
                {
                    insert_order_ok = dbc.insert_order(ordernumber, Convert.ToInt32(Session["custid"].ToString()), 0.ToString(), lblProductTotalSack.Text, lblProductTotalNag.Text, lblProductTotalPrice.Text, txtModeOfPayment.Text, txtDestination.Text, "NA");
                    if (insert_order_ok == 1)
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            insert_ok_orderdetails = dbc.insert_orderdetails(ordernumber, r["Product Name"].ToString(), r["Sack"].ToString(), r["Nag"].ToString(), r["Price"].ToString(), r["Remark"].ToString());
                        }
                        if (insert_ok_orderdetails == 1)
                        {
                            int ok = notification();
                            if (ok == 1)
                            {
                                Response.Write("<script>alert('Order Added');window.location='CreateOrder.aspx';</script>");
                            }
                        }
                    }
                }
                orderrow = 0;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");

        }
    }
    public int notification()
    {
        try
        {
            int okn = 0;
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdn = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId FROM tblsupersonnel WHERE varSubDesig='Sub Admin'", dbc.con);

            MySql.Data.MySqlClient.MySqlDataReader drn;
            drn = cmdn.ExecuteReader();
            while (drn.Read())
            {
                okn = dbc.insert_tblsunotifications("Session", Convert.ToInt32(Session["custid"].ToString()), lblCustName.Text, "Customer", Convert.ToInt32(drn["intId"].ToString()), "Sub Admin", "New Order from : " + lblCustName.Text + "", "~/Personnel/employee/subadmin/ViewOrderFull.aspx", lblOrderNo.Text, "Unread", "Order");
            }
            dbc.con.Close();
            dbc.dr.Close();
            return okn;
        }
        catch(Exception ex)
        {
            return 0;
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
                if (txtTotalProducts.Text == "0")
                {
                    Response.Write("<script>alert('Please enter value more than 0');</script>");
                }
                else
                {
                    lblSack.Text = (Convert.ToInt64(txtTotalProducts.Text) / packing).ToString();
                    Int64 temp = Convert.ToInt64(lblSack.Text) * packing;
                    lblNug.Text = (Convert.ToInt64(txtTotalProducts.Text) - temp).ToString();
                    txtPrice.Text = (Convert.ToInt32(txtTotalProducts.Text) * Convert.ToInt32(prices)).ToString();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
     
    protected void btnAddToOrder_Click(object sender, EventArgs e)
    {
        if (txtTotalProducts.Text == "0")
        {
            ScriptManager.RegisterStartupScript(
                    this,
                    this.GetType(),
                    "MessageBox",
                    "alert('Please enter value more than 0');", true);

        }
        else
        {
            AddToDataTable();
            BindGrid();
            clear();
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
        txtPrice.Text = "";
        txtRemark.Text = "";
        lblNug.Text = "Nug";
        txtTotalProducts.Text = 0.ToString();
    }
    protected void grdOrderDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            string id = commandArgs[0];
            string sacks = commandArgs[1];
            string nags = commandArgs[2];
            string price = commandArgs[3];

            if (e.CommandName == "remove")
            {
                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int RemoveAt = gvr.RowIndex;
                dt = (DataTable)ViewState["DataTable"];
                dt.Rows.RemoveAt(RemoveAt);
                dt.AcceptChanges();

                orderrow = orderrow - 1;
                ViewState["DataTable"] = dt;
                BindGrid();
                lblProductTotalSack.Text = (Convert.ToInt32(lblProductTotalSack.Text) - Convert.ToInt32(sacks)).ToString();
                lblProductTotalNag.Text = (Convert.ToInt32(lblProductTotalNag.Text) - Convert.ToInt32(nags)).ToString();
                lblProductTotalPrice.Text = (Convert.ToInt32(lblProductTotalPrice.Text) - Convert.ToInt32(price)).ToString();
                clear();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
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