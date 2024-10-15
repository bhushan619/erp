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

public partial class Personnel_employee_CreateOrder : System.Web.UI.Page
{
    public static string empdesig = string.Empty;
    DatabaseConnection dbc = new DatabaseConnection();
    static string custstate = string.Empty;
    static string pname = string.Empty, ordernumber = string.Empty;
    static int packing = 0, orderrow = 1, custId = 0, prices = 0, pId = 0;
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
            ordernumber = dbc.max_tblOrderId().ToString();
            lblOrderNo.Text = ordernumber.ToString();
            lblProductTotalSack.Text = 0.ToString();
            lblProductTotalPrice.Text = 0.ToString();
            lblProductTotalNag.Text = 0.ToString();
            getImage();
            getempname();
            notifications();
            SqlDataSource2.SelectCommand = "SELECT distinct CONCAT(nvarProductName,' ',nvarProductSubType ,' ', intSize,' ', varUnit) as ProductName FROM sanghaviunbreakables.tblsuproducts where nvarStatus!='-'";
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

        dr["SrNo"] = orderrow++;
        dr["Product Name"] = ddlProName.Text;
        dr["Sack"] = lblSack.Text;
        dr["Nag"] = lblNug.Text;
        dr["Total"] = txtTotalProducts.Text;
        dr["Price"] = txtPrice.Text;
        dr["Remark"] = txtRemark.Text;

        dt.Rows.Add(dr);

        lblProductTotalSack.Text = (Convert.ToInt32(lblSack.Text) + Convert.ToInt32(lblProductTotalSack.Text)).ToString();
        lblProductTotalNag.Text = (Convert.ToInt32(lblNug.Text) + Convert.ToInt32(lblProductTotalNag.Text)).ToString();
        lblProductTotalPrice.Text = (Convert.ToDouble(txtPrice.Text) + Convert.ToDouble(lblProductTotalPrice.Text)).ToString();


    }

    private void BindGrid()
    {
        grdOrderDetails.DataSource = dt;
        grdOrderDetails.DataBind();
    }

    protected void txtCustomerName_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string[] arry = txtCustomerName.Text.Split(new char[] { '_' });

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varRepresentativeName, varMobile,varState FROM sanghaviunbreakables.tblsucustomer where varCompanyName='" + arry[0] + "' and varCity='" + arry[1] + "'", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblRepresentativeName.Text = dbc.dr["varRepresentativeName"].ToString();
                lblMob.Text = dbc.dr["varMobile"].ToString();
                custstate = dbc.dr["varState"].ToString();
                custId = Convert.ToInt32(dbc.dr["intId"].ToString());
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
            if (txtCustomerName.Text == "")
            {
                Response.Write("<script>alert('Please Select Customer');</script>");
                ddlProName.SelectedIndex = 0;
            }
            else
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
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT " + price + " as prices,intPacking,intId FROM sanghaviunbreakables.tblsuproducts where nvarProductName='" + ssize[0].ToString() + "' and nvarProductSubType='" + ssize[1].ToString() + "' and intSize='" + ssize[2].ToString() + "'", dbc.con);

                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    pId = Convert.ToInt32(dbc.dr["intId"].ToString());
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
                if (txtBookingId.Text == "")
                {
                    Response.Write("<script>alert('Please Enter Order ID');</script>");
                }
                else
                {
                    if (lblProductTotalNag.Text.Equals(0.ToString()))
                    {
                        if (lblProductTotalSack.Text.Equals(0.ToString()))
                        {
                            Response.Write("<script>alert('Please add products order');</script>");
                        }
                        else
                        {
                            insert_order_ok = dbc.insert_order(ordernumber, custId, Session["empid"].ToString(), lblProductTotalSack.Text, lblProductTotalNag.Text, lblProductTotalPrice.Text, txtModeOfPayment.Text, txtDestination.Text, txtBookingId.Text);
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
                        insert_order_ok = dbc.insert_order(ordernumber, custId, Session["empid"].ToString(), lblProductTotalSack.Text, lblProductTotalNag.Text, lblProductTotalPrice.Text, txtModeOfPayment.Text, txtDestination.Text, txtBookingId.Text);
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
                okn = dbc.insert_tblsunotifications("Session", Convert.ToInt32(Session["empid"].ToString()), lblCustName.Text, empdesig, Convert.ToInt32(drn["intId"].ToString()), "Sub Admin", "New Order from Employee : " + lblCustName.Text + " of Customer " + txtCustomerName.Text + "", "~/Personnel/employee/subadmin/ViewOrderFull.aspx", lblOrderNo.Text, "Unread", "Order");
            }
            dbc.con.Close();
            dbc.dr.Close();
            return okn;
        }
        catch (Exception ex)
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
                orderrow--;
                ViewState["DataTable"] = dt;
                BindGrid();
                lblProductTotalSack.Text = (Convert.ToInt32(lblProductTotalSack.Text) - Convert.ToInt32(sacks)).ToString();
                lblProductTotalNag.Text = (Convert.ToInt32(lblProductTotalNag.Text) - Convert.ToInt32(nags)).ToString();
                lblProductTotalPrice.Text = (Convert.ToDouble(lblProductTotalPrice.Text) - Convert.ToDouble(price)).ToString();
                clear();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static List<string> GetCompletionList(string prefixText, int count, string contextKey)
    {
        String connStr = System.Configuration.ConfigurationManager.ConnectionStrings["sanghaviConnectionString"].ConnectionString;

        MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(connStr);
        con.Open();
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varCompanyName,'_',varCity) as  varCompanyName FROM sanghaviunbreakables.tblsucustomer where varCompanyName like '%" + prefixText + "%' AND intId between 1 and 500", con);
        //     cmd.Parameters.AddWithValue("@Name", prefixText);
        MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);


        MySql.Data.MySqlClient.MySqlConnection con1 = new MySql.Data.MySqlClient.MySqlConnection(connStr);
        con1.Open();
        MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varCompanyName,'_',varCity) as  varCompanyName FROM sanghaviunbreakables.tblsucustomer where varCompanyName like '%" + prefixText + "%' AND intId between 501 and 1000", con1);
        //     cmd.Parameters.AddWithValue("@Name", prefixText);
        MySql.Data.MySqlClient.MySqlDataAdapter da1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);

        List<string> CompanyName = new List<string>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            CompanyName.Add(dt.Rows[i][0].ToString());
            //  CompanyName[j++] =dt.Rows[i][0].ToString();
        }
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            CompanyName.Add(dt1.Rows[i][0].ToString());
            //  CompanyName[j++] =dt.Rows[i][0].ToString();
        }
        con.Close();
        con1.Close();
        return CompanyName;
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Personnel/employee/marketing/CreateOrder.aspx");
    }
}