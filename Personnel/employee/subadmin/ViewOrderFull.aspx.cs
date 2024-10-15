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
        if (Session["empid"] == null)
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
            setbuttons();
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
    public void setbuttons()
    {
        if (dbc.get_OrderStatus(Convert.ToInt64(lblOrderNo.Text)) == "Approved")
        {
            lnkApprove.Enabled = false;
            lnkReject.Enabled = false;   
            lstOrderDetails.Enabled = false;
            btnUpdate.Enabled = false;
            btnReset.Enabled = false;
            lnkApprove.CssClass = "btn btn-success disabled";
            lnkReject.CssClass = "btn btn-danger disabled";
            btnUpdate.CssClass = "btn btn-info disabled";
            btnReset.CssClass = "btn btn-danger disabled";
        }
        else
        {
            lnkApprove.Enabled = true;
            lnkReject.Enabled = true;
            lstOrderDetails.Enabled = true;
            btnUpdate.Enabled = true;
            btnReset.Enabled = true;
        }
    }
    public void getData()
    {
        try
        {
            dbc.con.Open(); 
            DataSet ds = new DataSet();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intOrderId, varBookingId,(SELECT varCompanyName from sanghaviunbreakables.tblsucustomer WHERE (intId =" + Session["empcustid"] + ") ) as comname,(SELECT varMobile from sanghaviunbreakables.tblsucustomer WHERE (intId = " + Session["empcustid"] + ") ) as mobile, varStatus, dtDate, varProductTotal, varTotalNag, varPriceTotal, ex1, ex2, varTransport FROM sanghaviunbreakables.tblsuorder WHERE (intOrderId = " + Session["orderid"] + ")", dbc.con);
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
                txtLRNo.Text = dr1["ex1"].ToString();
                txtDiscount.Text = dr1["ex2"].ToString();
                txtTransport.Text = dr1["varTransport"].ToString();
            }
            dbc.con.Close();
            cmd.Dispose();
            adp.Dispose();

            dbc.con.Open(); 
            DataSet dt = new DataSet();
            cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct CONCAT(nvarProductName,' ',nvarProductSubType ,' ', intSize,' ', varUnit) as ProductName FROM sanghaviunbreakables.tblsuproducts where nvarStatus!='-'", dbc.con);
            adp = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            adp.Fill(dt);
            lblProductName.DataSource = dt;
            lblProductName.DataBind();
            dbc.con.Close();

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
    protected void lnkApprove_Click(object sender, EventArgs e)
    {
        DateTime dateValue;
        
        if (txtTransport.Text == "")
        {
            ScriptManager.RegisterStartupScript(
                           this,
                           this.GetType(),
                           "MessageBox",
                           "alert('Please enter Transport details');", true);
        }
        else if (txtDate.Text == "")
        {
            ScriptManager.RegisterStartupScript(
                           this,
                           this.GetType(),
                           "MessageBox",
                           "alert('Please enter Date');", true);
        }
        else if (!DateTime.TryParseExact(txtDate.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
        {
            ScriptManager.RegisterStartupScript(
                           this,
                           this.GetType(),
                           "MessageBox",
                           "alert('Please enter proper date');", true);
        }       
        else if (txtBookingId.Text == "0")
        {
            ScriptManager.RegisterStartupScript(
                           this,
                           this.GetType(),
                           "MessageBox",
                           "alert('Please enter Booking ID');", true);
        }
        else if (txtBookingId.Text == "")
        {
            ScriptManager.RegisterStartupScript(
                           this,
                           this.GetType(),
                           "MessageBox",
                           "alert('Please enter Booking ID');", true);
        }
        else
        {
            int ok = checkStock();
            if (ok == 1)
            {
                int ks = insertConsignmentDetails();
                int updateok = dbc.Update_OrderStatus(Convert.ToInt64(Session["orderid"].ToString()), "Approved", lblCustName.Text, txtBookingId.Text, txtTotalPrice.Text, txtDate.Text, txtLRNo.Text, txtDiscount.Text, txtTransport.Text);
                if (updateok == 1)
                {
                    insertConsignment();
                    Response.Write("<script>alert('Order number : " + Convert.ToInt64(Session["orderid"].ToString()) + "  Approved');window.location='ViewOrder.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Please try again');window.location='ViewOrderFull.aspx';</script>");
                }
            }
            else if (ok == 2)
            {
                ScriptManager.RegisterStartupScript(
                          this,
                          this.GetType(),
                          "MessageBox",
                          "alert('Add product in consignment');", true);
            }
            else if (ok == 3)
            {
                ScriptManager.RegisterStartupScript(
                                  this,
                                  this.GetType(),
                                  "MessageBox",
                                  "alert('Product not in stock. Please add less');", true);
            }
        }
    }
    protected void lnkReject_Click(object sender, EventArgs e)
    {
        int updateok = dbc.Update_OrderStatus(Convert.ToInt64(Session["orderid"].ToString()), "Rejected", lblCustName.Text, txtBookingId.Text, txtTotalPrice.Text, txtDate.Text, txtLRNo.Text, txtDiscount.Text, txtTransport.Text);
        if (updateok == 1)
        {
            Response.Write("<script>alert('Order number : " + Convert.ToInt64(Session["orderid"].ToString()) + "  Rejected');window.location='ViewOrder.aspx';</script>");
        }
        else
        {
            Response.Write("<script>alert('Please try again');window.location='ViewOrder.aspx';</script>");
        }
    }
    public void insertConsignment()
    {
        try
        {
            int insert_ok = dbc.insert_Consignment(Convert.ToInt64(lblOrderNo.Text), txtTransport.Text);
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

    static int sack = 0, nug = 0, ppid = 0, pid = 0, rowid = 0;
    static string unita = string.Empty;
    public int checkStock()
    {
        int ok = 0;
        try
        {
            if (lstOrderDetails.Items.Count() == 0)
            {
                return ok = 2;
            }
            else
            {
                ok = 1;
                for (int i = 0; i < lstOrderDetails.Items.Count(); i++)
                {
                    DatabaseConnection dbcs = new DatabaseConnection();

                    Label pname = (Label)lstOrderDetails.Items[i].FindControl("varProductNameLabel");
                    string pronamelabel = pname.Text;
                    Label varQuantityLabel = (Label)lstOrderDetails.Items[i].FindControl("varQuantityLabel");
                    string sacklabel = varQuantityLabel.Text;
                    Label varNagLabel = (Label)lstOrderDetails.Items[i].FindControl("varNagLabel");
                    string nuglabel = varNagLabel.Text;
                    Label varPriceLabel = (Label)lstOrderDetails.Items[i].FindControl("varPriceLabel");
                    string pricelabel = varPriceLabel.Text;

                    string[] ssizea = pronamelabel.Split(new char[0]);
                    string mmm = ssizea[0].ToString();

                    dbcs.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand("SELECT sanghaviunbreakables.tblsustockjalgaon.intSack, sanghaviunbreakables.tblsustockjalgaon.intNug, sanghaviunbreakables.tblsuproducts.intPacking, sanghaviunbreakables.tblsuproducts.varUnit, sanghaviunbreakables.tblsustockjalgaon.intProductId FROM sanghaviunbreakables.tblsuproducts INNER JOIN sanghaviunbreakables.tblsustockjalgaon ON sanghaviunbreakables.tblsuproducts.intId = sanghaviunbreakables.tblsustockjalgaon.intProductId where sanghaviunbreakables.tblsuproducts.nvarProductName= '" + ssizea[0].ToString() + "' and intSize='" + ssizea[2].ToString() + "'", dbcs.con);

                    dbcs.dr = cmda.ExecuteReader();
                    if (dbcs.dr.Read())
                    {
                        ppid = Convert.ToInt32(dbcs.dr["intProductId"].ToString());
                        unita = dbcs.dr["varUnit"].ToString();
                        sack = Convert.ToInt32(dbcs.dr["intSack"].ToString());
                        nug = Convert.ToInt32(dbcs.dr["intNug"].ToString());
                        packing = Convert.ToInt32(dbcs.dr["intPacking"].ToString());
                        dbcs.con.Close();
                        dbcs.dr.Close();
                        string allnug = ((Convert.ToInt64(sack) * packing) + nug).ToString();

                        string sendallnug = ((Convert.ToInt64(sacklabel) * packing) + Convert.ToInt64(nuglabel)).ToString();

                        if (Convert.ToInt32(allnug) < Convert.ToInt32(sendallnug))
                        {

                            ok = 3;
                        }
                    } 
                } 
                return ok;
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('" + ex.Message + "');", true);
            return ok = 0;
        }
    }
   
   public int insertConsignmentDetails()
    {
        int ok = 0;
        try
        {
            if (lstOrderDetails.Items.Count() == 0)
            {
                return ok = 2;
            }
            else
            {
                for (int i = 0; i < lstOrderDetails.Items.Count(); i++)
                {
                    DatabaseConnection dbcs = new DatabaseConnection();

                    Label pname = (Label)lstOrderDetails.Items[i].FindControl("varProductNameLabel");
                    string pronamelabel = pname.Text;
                    Label varQuantityLabel = (Label)lstOrderDetails.Items[i].FindControl("varQuantityLabel");
                    string sacklabel = varQuantityLabel.Text;
                    Label varNagLabel = (Label)lstOrderDetails.Items[i].FindControl("varNagLabel");
                    string nuglabel = varNagLabel.Text;
                    Label varPriceLabel = (Label)lstOrderDetails.Items[i].FindControl("varPriceLabel");
                    string pricelabel = varPriceLabel.Text;

                    string[] ssizea = pronamelabel.Split(new char[0]);
                    string mmm = ssizea[0].ToString();

                    dbcs.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand("SELECT sanghaviunbreakables.tblsustockjalgaon.intSack, sanghaviunbreakables.tblsustockjalgaon.intNug, sanghaviunbreakables.tblsuproducts.intPacking, sanghaviunbreakables.tblsuproducts.varUnit, sanghaviunbreakables.tblsustockjalgaon.intProductId FROM sanghaviunbreakables.tblsuproducts INNER JOIN sanghaviunbreakables.tblsustockjalgaon ON sanghaviunbreakables.tblsuproducts.intId = sanghaviunbreakables.tblsustockjalgaon.intProductId where sanghaviunbreakables.tblsuproducts.nvarProductName= '" + ssizea[0].ToString() + "' and intSize='" + ssizea[2].ToString() + "'", dbcs.con);

                    dbcs.dr = cmda.ExecuteReader();
                    if (dbcs.dr.Read())
                    {
                        ppid = Convert.ToInt32(dbcs.dr["intProductId"].ToString());
                        unita = dbcs.dr["varUnit"].ToString();
                        sack = Convert.ToInt32(dbcs.dr["intSack"].ToString());
                        nug = Convert.ToInt32(dbcs.dr["intNug"].ToString());
                        packing = Convert.ToInt32(dbcs.dr["intPacking"].ToString());
                        dbcs.con.Close();
                        dbcs.dr.Close();
                        string allnug = ((Convert.ToInt64(sack) * packing) + nug).ToString();

                        string sendallnug = ((Convert.ToInt64(sacklabel) * packing) + Convert.ToInt64(nuglabel)).ToString();

                        string newnugvar = (Convert.ToInt64(allnug) - Convert.ToInt64(sendallnug)).ToString();

                        string newsacku = (Convert.ToInt64(newnugvar) / packing).ToString();
                        Int64 tempvaru = Convert.ToInt64(newsacku) * packing;
                        string newnugsu = (Convert.ToInt64(newnugvar) - tempvaru).ToString();

                        string newsacki = (Convert.ToInt64(sendallnug) / packing).ToString();
                        Int64 tempvari = Convert.ToInt64(newsacki) * packing;
                        string newnugsi = (Convert.ToInt64(sendallnug) - tempvari).ToString();

                        int srno = i + 1;
                        rowid = dbcs.max_cosignmentDetailsId() + 1;
                        dbcs.con.Close();
                        dbcs.con.Open();
                        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblsuconsignmentdetails VALUES(" + rowid + "," + srno + "," + Convert.ToInt32(lblOrderNo.Text) + ",'" + ppid + "','" + pronamelabel + "','" + sacklabel + "','" + nuglabel + "','" + prices + "','Nag','NA','NA','" + pricelabel + "')", dbcs.con);
                        cmd.ExecuteNonQuery();
                        dbcs.con.Close();

                        dbcs.con.Close();
                        dbcs.con.Open();
                        MySql.Data.MySqlClient.MySqlCommand cmdup = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsustockjalgaon set intSack=" + newsacku + ",intNug=" + newnugsu + ",varRemark='Stock Updated On Consignment Created' where intProductId=" + ppid + " ", dbcs.con);
                        cmdup.ExecuteNonQuery();
                        dbcs.con.Close();

                        pid = dbcs.max_tblstockhistoryjalgaon();
                        pid = pid + 1;
                        dbcs.con.Close();
                        dbcs.con.Open();                                                                               //  intId`, `intProductId`, pname `intSack`, `intNug`, `varUnit`, `dtDate`, `tmTime`, `varUpdater`, `varReason`, `varTransport`, `varRemark
                        MySql.Data.MySqlClient.MySqlCommand cmdaa = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsustockhistoryjalgaon VALUES(" + pid + "," + ppid + ",'" + pronamelabel + "'," + newsacki + "," + newnugsi + ",'" + ssizea[3].ToString() + "','" + txtDate.Text + "','" + DateTime.UtcNow.ToShortTimeString() + "','" + lblCustName.Text + "','For Order No.: " + lblOrderNo.Text + "','" + txtTransport.Text + "','In Transit','Remove')", dbcs.con);
                        cmdaa.ExecuteNonQuery();
                        dbcs.con.Close();
                        cmd.Dispose();
                        ok = 1;
                    }
                }

                return ok;
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('" + ex.Message + "');", true);
            return ok = 0;
        }
    }
 
    protected void btnReset_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (lblProductName.Text == "-- Select Product --")
            {
                ClientScript.RegisterStartupScript(this.GetType(),
                             "popup",
                             "alert('Please Select Product');",
                             true);
            }
            else
            {
                int updateok = 0;
                int insert_ok_orderdetails = 0;
                if (lblId.Text == "id")
                {
                    insert_ok_orderdetails = dbc.insert_orderdetailsediting(lblOrderNo.Text, lblProductName.Text, lblSack.Text, lblNug.Text, txtPrice.Text, "AddedWhileEditing");
                    if (insert_ok_orderdetails == 1)
                    {

                        ClientScript.RegisterStartupScript(this.GetType(),
                                   "popup",
                                   "alert('Order Updated');window.location='ViewOrderFull.aspx';",
                                   true);
                        clear();
                    }
                }
                else
                {
                    updateok = dbc.updateOrderDetailsFull(lblSack.Text, lblNug.Text, txtPrice.Text, lblId.Text, lblOrderNo.Text,lblProductName.Text);
                    if (updateok == 1)
                    {

                        ClientScript.RegisterStartupScript(this.GetType(),
                                    "popup",
                                    "alert('Order Updated');window.location='ViewOrderFull.aspx';",
                                    true);
                        clear();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(),
                                   "popup",
                                   "alert('Order Not Updated');",
                                   true);
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    public void clear()
    {
        lblId.Text = "id";
        lblProductName.Text = "-- Select Product --";
        lblSack.Text = "Sack";
        lblNug.Text = "Nug";
        txtTotalProducts.Text = 0.ToString();
        txtPrice.Text = "";
    }
    protected void txtSack_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (lblProductName.Text == "-- Select Product --")
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
                    txtPrice.Text = "";
                    txtPrice.Text = (Convert.ToInt32(txtTotalProducts.Text) * Convert.ToInt32(prices)).ToString();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
       
    protected void lstOrderDetails_ItemCommand(object sender, ListViewCommandEventArgs e)
    {

        try
        {
            if (e.CommandName == "Edita")
            {
                dbc.con.Open();
                dbc.cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varProductName, varQuantity, varNag, varPrice FROM tblsuorderdetails WHERE intId=" + Convert.ToInt32(e.CommandArgument) + "", dbc.con);
                dbc.dr = dbc.cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    lblId.Text = e.CommandArgument.ToString();
                    lblProductName.Text = dbc.dr[1].ToString();
                    lblSack.Text = dbc.dr[2].ToString();
                    lblNug.Text = dbc.dr[3].ToString();
                    txtPrice.Text = dbc.dr[4].ToString();
                    dbc.con.Close();
                    dbc.dr.Close();
                }
                dbc.con.Close();
                string custstate = dbc.get_CustState(Convert.ToInt32(lblOrderNo.Text));
                string price = string.Empty;
                string myStr = lblProductName.Text;
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
                    prices = Convert.ToInt32(dbc.dr["prices"].ToString());
                    packing = Convert.ToInt32(dbc.dr["intPacking"].ToString());
                    dbc.con.Close();
                    dbc.dr.Close();
                }
            }
            else if (e.CommandName == "Deletea")
            {
                int updateok = 0;
                updateok = dbc.updateOrderDetailsFullDelete(e.CommandArgument.ToString(), lblOrderNo.Text);
                if (updateok == 1)
                {

                    ClientScript.RegisterStartupScript(this.GetType(),
                                "popup",
                                "alert('Order Updated');window.location='ViewOrderFull.aspx';",
                                true);
                    clear();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(),
                               "popup",
                               "alert('Order Not Updated');",
                               true);
                }
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    protected void ddlProName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string price = string.Empty;
            string custstate = dbc.get_CustState(Convert.ToInt32(lblOrderNo.Text));
            string myStr = lblProductName.Text;
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
                txtPrice.Text = dbc.dr["prices"].ToString();
                prices = Convert.ToInt32(dbc.dr["prices"].ToString());
                packing = Convert.ToInt32(dbc.dr["intPacking"].ToString());
             //   lblId.Text =dbc.dr["intId"].ToString();
                dbc.con.Close();
                dbc.dr.Close();
            }
            lblSack.Text = "Sack";
            lblNug.Text = "Nug";
            txtTotalProducts.Text = 0.ToString();
        }
        catch (Exception ex)
        {
        }

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
}