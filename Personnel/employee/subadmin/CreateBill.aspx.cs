using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

public partial class Personnel_employee_CreateBill : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
   
    static string custstate = string.Empty;
    string pname = string.Empty, ordernumber = string.Empty, empdesig = string.Empty;
    static int packing = 0, orderrow = 1, custId = 0, prices = 0;
    DataTable dt;
    static Int64 order = 0;
    static int stock = 0, nugg = 0, prid = 0, rowid = 0, minusStock = 0, minusnugg = 0, pid = 0;
    static string unita = string.Empty, dat = string.Empty, tim = string.Empty;
    static int sack = 0, nug = 0, ppid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../../SignUpLogin.aspx';</script>");
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        else if (Session["orderid"] == null)
        {
            Response.Redirect("ViewApprovedOrders.aspx");
        }
        else if (!IsPostBack)
        {
            int billno = dbc.max_BillNo();
            billno = billno + 1;

            int conid = dbc.max_suconsignment();
            conid = conid + 1;
            getImage();
            getempname();
            orderdetails();
            notifications();
            lblInvoice.Text = billno.ToString();
            lblconsi.Text = conid.ToString();
            lblProductTotalSack.Text = 0.ToString();
            lblProductTotalPrice.Text = 0.ToString();
            lblProductTotalNag.Text = 0.ToString();
            lblVat.Text = 0.ToString();
            lblOrderNo.Text = Session["orderid"].ToString();
            order = Convert.ToInt64(lblOrderNo.Text);
            dt = new DataTable();
            MakeDataTable();

        }
        else
        {
            dt = (DataTable)ViewState["DataTable"];
        }
        ViewState["DataTable"] = dt;
    }

    private void MakeDataTable()
    {
        dt.Columns.Add("SrNo");
        dt.Columns.Add("Product Name");
        dt.Columns.Add("Sack");
        dt.Columns.Add("Nag");
        dt.Columns.Add("Total");
        dt.Columns.Add("Rate");
        dt.Columns.Add("Per");
        dt.Columns.Add("VAT");
        dt.Columns.Add("Disc");
        dt.Columns.Add("Price");
    }

    private void AddToDataTable()
    {
        DataRow dr = dt.NewRow();

        dr["SrNo"] = orderrow++ ;
        dr["Product Name"] = ddlProName.Text;
        dr["Sack"] = lblSack.Text;
        dr["Nag"] = lblNug.Text;
        dr["Total"] = txtTotalProducts.Text;
        dr["Rate"] = prices;
        dr["Per"] = "ng";
        dr["VAT"] = "5%";
        dr["Disc"] = txtDiscount.Text;
        dr["Price"] = txtPrice.Text;


        dt.Rows.Add(dr);
          
        lblProductTotalSack.Text = (Convert.ToInt32(lblSack.Text) + Convert.ToInt32(lblProductTotalSack.Text)).ToString();
        lblProductTotalNag.Text = (Convert.ToInt32(lblNug.Text) + Convert.ToInt32(lblProductTotalNag.Text)).ToString();
        lblProductTotalPrice.Text = (Convert.ToDouble(txtPrice.Text) + Convert.ToDouble(lblProductTotalPrice.Text)).ToString();
        lblVat.Text = ((Convert.ToDouble(lblProductTotalPrice.Text) * 5 / 100)).ToString();
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
    private void BindGrid()
    {
        grdOrderDetails.DataSource = dt;
        grdOrderDetails.DataBind();
    }
    public void orderdetails()
    {
        try
        {

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT VarModePayment,varDestination FROM tblsuorder WHERE intOrderId=" + Session["orderid"].ToString() + "", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                txtDestination.Text = dbc.dr["varDestination"].ToString();
                txtModePayment.Text = dbc.dr["VarModePayment"].ToString();
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
            Response.Write("<script>alert('Please Try Again');</script>");
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

    
    protected void listorder_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        int updateok = 0;
        string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
        string orderid = commandArgs[0];
        string empcustid = commandArgs[1];

        if (e.CommandName == "View")
        {
            Session.Add("orderid", orderid);
            Session.Add("empcustid", empcustid);
            Response.Redirect("ViewOrderFull.aspx");
        }
        else if (e.CommandName == "Bill")
        {

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
    
    protected void ddlProName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string price = string.Empty;
            string myStr = ddlProName.Text;
            string[] ssize = myStr.Split(new char[0]);
            //char[] whitespace = new char[] { ' ', '\t' };
            custstate = dbc.select_CustState(Convert.ToInt32(Session["empcustid"].ToString()));
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
    protected void btnAddToOrder_Click(object sender, EventArgs e)
    {
        if (lblSack.Text == "")
        {
            Response.Write("<script>alert('Sack Value is not Blank ');</script>");
        }
        else if (lblSack.Text == "0")
        {
            Response.Write("<script>alert('Sack Value is not  Zero');</script>");
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
                orderrow--;
               
                ViewState["DataTable"] = dt;
                BindGrid();
                lblProductTotalSack.Text = (Convert.ToInt32(lblProductTotalSack.Text) - Convert.ToInt32(sacks)).ToString();
                lblProductTotalNag.Text = (Convert.ToInt32(lblProductTotalNag.Text) - Convert.ToInt32(nags)).ToString();
                lblProductTotalPrice.Text = (Convert.ToDouble(lblProductTotalPrice.Text) - Convert.ToDouble(price)).ToString();

                txtRoundup.Text = "";

                if (RemoveAt == 0)
                {
                    txtRoundup.Text = "";
                    lblProductTotalPrice.Text = 0.ToString();
                    lblVat.Text = 0.ToString();
                }

                clear();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void clear()
    {
        ddlProName.SelectedIndex = 0;
      
        txtPrice.Text = "";
        txtDiscount.Text = "";
        lblSack.Text = "Sack";  
        lblNug.Text = "Nug";
        txtTotalProducts.Text = 0.ToString();
    }
    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        if (txtDiscount.Text == "")
        {
        }
        else
        {
            txtPrice.Text = (Convert.ToDouble(txtPrice.Text) - (Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtDiscount.Text) / 100)).ToString();
        }
    }
    protected void txtRoundup_TextChanged(object sender, EventArgs e)
    {
        if (txtRoundup.Text == "")
        {
        }
        else
        {
            lblProductTotalPrice.Text = (Convert.ToDouble(lblProductTotalPrice.Text) + Convert.ToDouble(txtRoundup.Text)).ToString();
            lblVat.Text = ((Convert.ToDouble(lblProductTotalPrice.Text) * 5 / 100)).ToString();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {  
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                insertConsignment();
                insertConsignmentDetails();
                updateorder();
                insertbill();

                Session["orderid"] = "";
                Session.Remove("orderid");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            }
    }
    public void insertbill()
    {
        try
        {
            
            int insert_ok = dbc.insert_Bill( Convert.ToInt16( lblInvoice.Text), order, Convert.ToInt16(lblconsi.Text), txtModePayment.Text,txtDispatch.Text,txtDestination.Text,  txtTransport.Text,"In Transit", lblProductTotalSack.Text,lblProductTotalNag.Text,lblProductTotalPrice.Text );

            if (insert_ok == 1)
            {
                Response.Write("<script>alert('Bill Created Successfully');window.location='ViewApprovedOrders.aspx'</script>");
               // clear(); after that msg, page txtbnox clear and also occur pageload for getting neww bill no .........................
            }
            else
            {
                ScriptManager.RegisterStartupScript(
              this,
              this.GetType(),
              "MessageBox",
              "alert('Some problem Please try again');", true);
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
    public void insertConsignment()
    {
        try
        {

        //s    int insert_ok = dbc.insert_Consignment(Convert.ToInt16(lblconsi.Text), Convert.ToInt16(lblInvoice.Text), order);
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
    public void insertConsignmentDetails()
    {
        try
        {
            foreach (GridViewRow dr in grdOrderDetails.Rows)
            {
                rowid = dbc.max_cosignmentDetailsId() + 1;
                dbc.con.Close();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblsuconsignmentdetails VALUES(" + rowid + "," + dr.Cells[1].Text.ToString() + "," + Convert.ToInt32(lblconsi.Text) + ",'" + dr.Cells[2].Text.ToString() + "','" + dr.Cells[3].Text.ToString() + "','" + dr.Cells[4].Text.ToString() + "','" + dr.Cells[6].Text.ToString() + "','" + dr.Cells[7].Text.ToString() + "','" + dr.Cells[8].Text.ToString() + "','" + dr.Cells[9].Text.ToString() + "','" + dr.Cells[10].Text.ToString() + "')", dbc.con);
                cmd.ExecuteNonQuery();
                dbc.con.Close();
                
                string myStra = dr.Cells[2].Text.ToString();
                string[] ssizea = myStra.Split(new char[0]);
                string mmm = ssizea[0].ToString();

                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand("SELECT sanghaviunbreakables.tblsustockjalgaon.intSack, sanghaviunbreakables.tblsustockjalgaon.intNug, sanghaviunbreakables.tblsuproducts.intPacking, sanghaviunbreakables.tblsuproducts.varUnit, sanghaviunbreakables.tblsustockjalgaon.intProductId FROM sanghaviunbreakables.tblsuproducts INNER JOIN sanghaviunbreakables.tblsustockjalgaon ON sanghaviunbreakables.tblsuproducts.intId = sanghaviunbreakables.tblsustockjalgaon.intProductId where sanghaviunbreakables.tblsuproducts.nvarProductName= '" + ssizea[0].ToString() + "' and intSize='" + ssizea[2].ToString() + "'", dbc.con);

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

                string sendallnug = ((Convert.ToInt64(dr.Cells[3].Text.ToString()) * packing) + Convert.ToInt64(dr.Cells[4].Text.ToString())).ToString();

                string newnugvar = (Convert.ToInt64(allnug) - Convert.ToInt64(sendallnug)).ToString();

                string newsacks = (Convert.ToInt64(newnugvar) / packing).ToString();
                Int64 tempvar = Convert.ToInt64(newsacks) * packing;
                string newnugs = (Convert.ToInt64(newnugvar) - tempvar).ToString();  

                dbc.con.Close();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmdup = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsustockjalgaon set intSack=" + newsacks + ",intNug=" + newnugs + ",varRemark='Stock Updated On Consignment Created' where intProductId=" + prid + " ", dbc.con);
                cmdup.ExecuteNonQuery();
                dbc.con.Close();

                pid = dbc.max_tblstockhistoryjalgaon();
                pid = pid + 1;
                dbc.con.Close();
                dbc.con.Open();                                                                               //  intId`, `intProductId`, pname `intSack`, `intNug`, `varUnit`, `dtDate`, `tmTime`, `varUpdater`, `varReason`, `varTransport`, `varRemark
                MySql.Data.MySqlClient.MySqlCommand cmdaa = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsustockhistoryjalgaon VALUES(" + pid + "," + ppid + ",'" + dr.Cells[2].Text.ToString() + "'," + newsacks + "," + newnugs + ",'" + ssizea[3].ToString() + "','" + DateTime.UtcNow.ToShortDateString() + "','" + DateTime.UtcNow.ToShortTimeString() + "','" + lblCustName.Text + "','For Order No.: "+lblOrderNo.Text+"','" + txtTransport.Text + "','In Transit','Remove')", dbc.con);
                cmdaa.ExecuteNonQuery();
                dbc.con.Close();
                cmd.Dispose();
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
    public void updateorder()
    {
        dbc.con.Close();
        dbc.con.Open();
        MySql.Data.MySqlClient.MySqlCommand cmdup = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsuorder set varStatus='In Transit' where intOrderId=" + lblOrderNo.Text + " ", dbc.con);
        cmdup.ExecuteNonQuery();
        dbc.con.Close();
    }

    protected void grdOrderDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdOrderDetails.PageIndex = e.NewPageIndex;
        BindGrid();

    }
}