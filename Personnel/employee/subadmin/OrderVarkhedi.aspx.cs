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

public partial class Personnel_employee_subadmin_OrderVarkhedi : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    static string custstate = string.Empty;
    static string pname = string.Empty, ordernumber = string.Empty, unita = string.Empty,empdesig=string.Empty;
    static int packing = 0, orderrow = 0, custId = 0, prices = 0, pId = 0;
    static int sack = 0, nug = 0, ppid = 0, pid = 0, rowid = 0;
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
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
            ordernumber = dbc.max_tblOrderVarkhediId().ToString();
            lblOrderNo.Text = ordernumber.ToString();
            getImage();
            notifications();
            getempname();
            SqlDataSource2.SelectCommand = "SELECT distinct CONCAT(nvarProductName,' ',nvarProductSubType ,' ', intSize,' ', varUnit) as ProductName FROM sanghaviunbreakables.tblsuproducts where nvarStatus!='-'";
            dt = new DataTable();
            MakeDataTable();
            expiring_data(); 
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
        dt.Columns.Add("Remark");
    }

    private void AddToDataTable()
    {
        DataRow dr = dt.NewRow();
        orderrow = orderrow + 1;
        dr["SrNo"] = orderrow;
        dr["Product Name"] = ddlProName.Text;
        dr["Sack"] = lblSack.Text;
        dr["Nag"] = lblNug.Text;
        dr["Total"] = txtTotalProducts.Text;
        dr["Remark"] = txtRemark.Text;

        dt.Rows.Add(dr);
     }

    private void BindGrid()
    {
        grdOrderDetails.DataSource = dt;
        grdOrderDetails.DataBind();
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
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
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
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
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
                clear();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void expiring_data()
    {

        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT sanghaviunbreakables.tblsuproducts.intId, CONCAT(tblsuproducts.nvarProductName,' ', tblsuproducts.intSize,' ', tblsuproducts.varUnit) as nvarProductName, sanghaviunbreakables.tblsustockjalgaon.intSack, sanghaviunbreakables.tblsustockjalgaon.intNug, tblsuproducts.intPacking * tblsustockjalgaon.intSack + tblsustockjalgaon.intNug AS total FROM sanghaviunbreakables.tblsuproducts INNER JOIN sanghaviunbreakables.tblsustockjalgaon ON sanghaviunbreakables.tblsuproducts.intId = sanghaviunbreakables.tblsustockjalgaon.intProductId", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);

            ad.Fill(dt1);

            gridexp.DataSource = dt1;
            gridexp.DataBind();
            dbc.con.Close();

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT sanghaviunbreakables.tblsuproducts.intId, CONCAT(tblsuproducts.nvarProductName,' ', tblsuproducts.intSize,' ', tblsuproducts.varUnit) as nvarProductName, sanghaviunbreakables.tblsustockvarkhedi.intSack, sanghaviunbreakables.tblsustockvarkhedi.intNug, tblsuproducts.intPacking * tblsustockvarkhedi.intSack + tblsustockvarkhedi.intNug AS total FROM sanghaviunbreakables.tblsuproducts INNER JOIN sanghaviunbreakables.tblsustockvarkhedi ON sanghaviunbreakables.tblsuproducts.intId = sanghaviunbreakables.tblsustockvarkhedi.intProductId", dbc.con);
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int ok = insertVarkediOrderDetails();
        if (ok == 1)
        {
            insertOrderVarkhedi();
            int okn = notification();
            if (okn == 1)
            {
                ScriptManager.RegisterStartupScript(
                                this,
                                this.GetType(),
                                "MessageBox",
                                "alert('Order to Varkhedi Sent');window.location='ViewOrderVarkhedi.aspx';", true);

            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(
                              this,
                              this.GetType(),
                              "MessageBox",
                              "alert('Some Error');", true);
        }

    }
    public int notification()
    {
        try
        {
            int okn = 0;
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdn = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId FROM tblsupersonnel WHERE varSubDesig='Production'", dbc.con);

            MySql.Data.MySqlClient.MySqlDataReader drn;
            drn = cmdn.ExecuteReader();
            while (drn.Read())
            {
                okn = dbc.insert_tblsunotifications("Page", Convert.ToInt32(Session["empid"].ToString()), lblCustName.Text, empdesig, Convert.ToInt32(drn["intId"].ToString()), "Production", "New Order from Jalgaon", "~/Personnel/employee/production/ViewJalgaonOrder.aspx", "NA", "Unread", "Cust");
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
    public int insertVarkediOrderDetails()
    {
        int ok = 0;
        try
        {
            if (grdOrderDetails.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(
                              this,
                              this.GetType(),
                              "MessageBox",
                              "alert('Please add products to order');", true);
            }
            else
            {
                foreach (GridViewRow dr in grdOrderDetails.Rows)
                {
                    string myStra = dr.Cells[2].Text.ToString();
                    string[] ssizea = myStra.Split(new char[0]);
                    string mmm = ssizea[0].ToString();

                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand("SELECT sanghaviunbreakables.tblsustockjalgaon.intSack, sanghaviunbreakables.tblsustockjalgaon.intNug, sanghaviunbreakables.tblsuproducts.intPacking, sanghaviunbreakables.tblsuproducts.varUnit, sanghaviunbreakables.tblsustockjalgaon.intProductId FROM sanghaviunbreakables.tblsuproducts INNER JOIN sanghaviunbreakables.tblsustockjalgaon ON sanghaviunbreakables.tblsuproducts.intId = sanghaviunbreakables.tblsustockjalgaon.intProductId where CONCAT(tblsuproducts.nvarProductName,' ', tblsuproducts.intSize,' ', tblsuproducts.varUnit) as ProductName= '" + ssizea[0].ToString() + "' and intSize='" + ssizea[2].ToString() + "'", dbc.con);

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

                    rowid = dbc.max_VarkhediOrderDetailsId() + 1;
                    dbc.con.Close();
                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblsuodervarkhedidetails VALUES(" + rowid + "," + Convert.ToInt32(lblOrderNo.Text) + "," + ppid + ",'" + dr.Cells[2].Text.ToString() + "','" + dr.Cells[3].Text.ToString() + "','" + dr.Cells[4].Text.ToString() + "','" + dr.Cells[5].Text.ToString() + "')", dbc.con);
                    cmd.ExecuteNonQuery();
                    dbc.con.Close();
                }
                ok = 1;
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('" + ex.Message + "');", true);
            ok = 0;
        }

        return ok;
    }
    public void insertOrderVarkhedi()
    {
        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsuvarkhediorder VALUES (" + Convert.ToInt64(lblOrderNo.Text) + ",'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','NA','NEW','Sent')", dbc.con);
            cmd.ExecuteNonQuery();
            dbc.con.Close();
            cmd.Dispose();
        }
        catch (Exception ex)
        {
            dbc.con.Close();
            ScriptManager.RegisterStartupScript(
                              this,
                              this.GetType(),
                              "MessageBox",
                              "alert('" + ex.Message + "');", true);
        }
    }
}