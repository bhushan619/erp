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
using System.Globalization;

public partial class Personnel_employee_subadmin_CrediteNote : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    DateTime datef, datet;
    MySql.Data.MySqlClient.MySqlCommand cmd, cmd1;
    static string custstate = string.Empty;
    static string pname = string.Empty, ordernumber = string.Empty, unita = string.Empty, empdesig = string.Empty;

    static int custId = 0, prices = 0, pId = 0, packing = 0;
    static int sack = 0, nug = 0, ppid = 0, pid = 0;


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
            getImage();
            getempname();
            notifications();
            // billno =Convert.ToInt32(txtBookingId.Text);
            lblProductTotalSack.Text = 0.ToString();
            lblProductTotalPrice.Text = 0.ToString();
            lblProductTotalNag.Text = 0.ToString();
            SqlDataSource2.SelectCommand = "SELECT distinct CONCAT(nvarProductName,' ',nvarProductSubType ,' ', intSize,' ', varUnit) as ProductName FROM sanghaviunbreakables.tblsuproducts where nvarStatus!='-'";


            dt3 = new DataTable();
            MakeDataTableOrder();
            grdOrderDetails.DataBind();
            GetDatafromDatabase("");
        }
        else
        {

            dt3 = (DataTable)ViewState["DataTable1"];
        }

        ViewState["DataTable1"] = dt3;
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["empid"].ToString()), empdesig).ToString();
    }
    //SELECT     tblsucustomer.varRepresentativeName, tblsucustomer.varMobile, tblsucustomer.varCompanyName FROM            tblsuorder INNER JOIN                         tblsucustomer ON tblsuorder.intCustId = tblsucustomer.intId WHERE        (tblsuorder.intOrderId = 1)
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


    private void MakeDataTableOrder()
    {

        dt3.Columns.Add("Product Name");
        dt3.Columns.Add("Sack");
        dt3.Columns.Add("Nag");
        dt3.Columns.Add("Total");
        dt3.Columns.Add("Price");
        dt3.Columns.Add("Remark");
    }
    private void AddToDataTable()
    {
        DataRow dr = dt3.NewRow();

        dr["Product Name"] = ddlProName.Text;
        dr["Sack"] = lblSack.Text;
        dr["Nag"] = lblNug.Text;
        dr["Total"] = txtTotalProducts.Text;
        dr["Price"] = txtPrice.Text;
        dr["Remark"] = txtRemark.Text;

        dt3.Rows.Add(dr);

        lblProductTotalSack.Text = (Convert.ToInt32(lblSack.Text) + Convert.ToInt32(lblProductTotalSack.Text)).ToString();
        lblProductTotalNag.Text = (Convert.ToInt32(lblNug.Text) + Convert.ToInt32(lblProductTotalNag.Text)).ToString();
        lblProductTotalPrice.Text = (Math.Round(Convert.ToDouble(txtPrice.Text) + Convert.ToDouble(lblProductTotalPrice.Text), 2)).ToString();
    }
    private void BindGridData()
    {

    }
    protected void btnview_Click(object sender, EventArgs e)
    {
        try
        {

            dbc.oDt = new System.Data.DataTable();
            datef = DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            datet = DateTime.ParseExact(txtToDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            dbc.con.Open();
            cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT tblsucreditnote.varCrediteNoteNo as 'CNote No', tblsucreditnote.varDate as 'Date', tblsucreditnote.varNoteType as 'Note Type', tblsucustomer.varCompanyName as 'Customer', tblsucreditnote.ex1 as 'Added to'  ,tblsucreditnotedetails.varProductName as 'Product', tblsuproducts.varWeight as 'Standard Weight',Round((tblsucreditnotedetails.varSack * tblsuproducts.intPacking + tblsucreditnotedetails.varNag) * tblsuproducts.varWeight, 2) AS 'Total Kg',tblsucreditnotedetails.varSack * tblsuproducts.intPacking + tblsucreditnotedetails.varNag AS Qty, tblsucreditnote.varCreditNoteAmount as 'Credit Note Amt', tblsucreditnote.varDiscount as 'Disc', tblsucreditnote.varTransportName as 'Transport', tblsucreditnote.varTransportAmount as 'Trans Amt', tblsucreditnote.varWages as Wages, tblsucreditnote.varLorry as Lorry FROM tblsucreditnote LEFT OUTER JOIN tblsucreditnotedetails ON tblsucreditnote.intId = tblsucreditnotedetails.intcreditenoteId LEFT OUTER JOIN tblsucustomer ON tblsucreditnote.intCustid = tblsucustomer.intId LEFT OUTER JOIN tblsuproducts ON tblsucreditnotedetails.intProductId = tblsuproducts.intId where  CAST(STR_TO_DATE(tblsucreditnote.varDate,'%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + txtFromDate.Text + "','%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + txtToDate.Text + "','%d-%m-%Y') AS DATE)", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            ad.Fill(dbc.oDt);
            grdReport.DataSource = dbc.oDt;
            grdReport.DataBind();
            dbc.con.Close();
            dbc.oDt.Dispose();
            cmd.Dispose();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Pls Try Again...');window.location='CreditNote.aspx';</script>");
        }
    }
    protected void GetDatafromDatabase(string where)
    {

        DataTable dt1 = new DataTable();
        dbc.con.Open();
        string queryStr = "SELECT tblsucreditnote.varCrediteNoteNo as 'CNote No', tblsucreditnote.varDate as 'Date', tblsucreditnote.varNoteType as 'Note Type', tblsucustomer.varCompanyName as 'Customer', tblsucreditnote.ex1 as 'Added to'  ,tblsucreditnotedetails.varProductName as 'Product', tblsuproducts.varWeight as 'Standard Weight',Round((tblsucreditnotedetails.varSack * tblsuproducts.intPacking + tblsucreditnotedetails.varNag) * tblsuproducts.varWeight, 2) AS 'Total Kg',tblsucreditnotedetails.varSack * tblsuproducts.intPacking + tblsucreditnotedetails.varNag AS Qty, tblsucreditnote.varCreditNoteAmount as 'Credit Note Amt', tblsucreditnote.varDiscount as 'Disc', tblsucreditnote.varTransportName as 'Transport', tblsucreditnote.varTransportAmount as 'Trans Amt', tblsucreditnote.varWages as Wages, tblsucreditnote.varLorry as Lorry FROM tblsucreditnote LEFT OUTER JOIN tblsucreditnotedetails ON tblsucreditnote.intId = tblsucreditnotedetails.intcreditenoteId LEFT OUTER JOIN tblsucustomer ON tblsucreditnote.intCustid = tblsucustomer.intId LEFT OUTER JOIN tblsuproducts ON tblsucreditnotedetails.intProductId = tblsuproducts.intId" + where;
        MySql.Data.MySqlClient.MySqlDataAdapter sda = new MySql.Data.MySqlClient.MySqlDataAdapter(queryStr, dbc.con);
        sda.Fill(dt1);
        grdReport.DataSource = dt1;
        grdReport.DataBind();
        dbc.con.Close();

    }
    protected void btnExportSale_Click(object sender, EventArgs e)
    {
        try
        {
            GetDatafromDatabase(" where  CAST(STR_TO_DATE(tblsucreditnote.varDate,'%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + txtFromDate.Text + "','%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + txtToDate.Text + "','%d-%m-%Y') AS DATE)");
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "CreditNote.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grdReport.AllowPaging = false;
            //Change the Header Row back to white color
            // grdReport.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //Applying stlye to gridview header cells


            grdReport.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Pls Try Again...');window.location='CreditNote.aspx';</script>");
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
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
    ///////


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {

            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                int insert_order_ok = 0, insert_ok_orderdetails = 0;
                if (txtCrediteNoteNo.Text=="")
                {
                    Response.Write("<script>alert('Please enter credit note number..!!');</script>");
                }
                else if (dbc.check_tblcreditnote(txtCrediteNoteNo.Text) == 1)
                {
                    Response.Write("<script>alert('Credit note already added..!!');</script>");
                }
                else if (dt3.Rows.Count == 0)
                {
                    insert_order_ok = dbc.insert_CreditNote_subadmin("NA", txtCrediteNoteNo.Text, txtNodeType.Text, custId, Convert.ToInt32(Session["empid"].ToString()), Convert.ToDouble(txtCreditNoteAmount.Text), txtDiscount.Text, txtTransportName.Text, Convert.ToDouble(txtTransportAmount.Text), Convert.ToDouble(txtWages.Text), Convert.ToDouble(txtLorry.Text), ddlPlace.Text == "--Select Stock Added To--" ? "NA" : ddlPlace.Text, txtDate.Text);
                }
                else if (ddlPlace.Text == "--Select Stock Added To--")
                {
                    Response.Write("<script>alert('Please select where to add stock..!!');</script>");
                }
                else
                {
                    if (ddlPlace.Text == "Jalgaon")
                    {
                        insert_order_ok = dbc.insert_CreditNote_subadmin("NA", txtCrediteNoteNo.Text, txtNodeType.Text, custId, Convert.ToInt32(Session["empid"].ToString()), Convert.ToDouble(txtCreditNoteAmount.Text), txtDiscount.Text, txtTransportName.Text, Convert.ToDouble(txtTransportAmount.Text), Convert.ToDouble(txtWages.Text), Convert.ToDouble(txtLorry.Text), ddlPlace.Text == "--Select Stock Added To--" ? "NA" : ddlPlace.Text, txtDate.Text);

                        if (!(insert_order_ok == 0))
                        {
                            foreach (DataRow dr in dt3.Rows)
                            {

                                string myStra = dr["Product Name"].ToString();
                                string[] ssizea = myStra.Split(new char[0]);
                                string mmm = ssizea[0].ToString();

                                dbc.con.Open();
                                MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand("SELECT sanghaviunbreakables.tblsustockjalgaon.intSack, sanghaviunbreakables.tblsustockjalgaon.intNug, sanghaviunbreakables.tblsuproducts.intPacking, sanghaviunbreakables.tblsuproducts.varUnit, sanghaviunbreakables.tblsustockjalgaon.intProductId FROM sanghaviunbreakables.tblsuproducts INNER JOIN sanghaviunbreakables.tblsustockjalgaon ON sanghaviunbreakables.tblsuproducts.intId = sanghaviunbreakables.tblsustockjalgaon.intProductId where tblsuproducts.nvarProductName= '" + ssizea[0].ToString() + "' and intSize='" + ssizea[2].ToString() + "'", dbc.con);

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

                                string sendallnug = ((Convert.ToInt64(dr["Sack"].ToString()) * packing) + Convert.ToInt64(dr["Nag"].ToString())).ToString();

                                string newnugvar = (Convert.ToInt64(allnug) + Convert.ToInt64(sendallnug)).ToString();

                                string newsacku = (Convert.ToInt64(newnugvar) / packing).ToString();
                                Int64 tempvaru = Convert.ToInt64(newsacku) * packing;
                                string newnugsu = (Convert.ToInt64(newnugvar) - tempvaru).ToString();

                                string newsacki = (Convert.ToInt64(sendallnug) / packing).ToString();
                                Int64 tempvari = Convert.ToInt64(newsacki) * packing;
                                string newnugsi = (Convert.ToInt64(sendallnug) - tempvari).ToString();

                                dbc.con.Close();
                                dbc.con.Open();
                                MySql.Data.MySqlClient.MySqlCommand cmdup = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsustockjalgaon set intSack=" + newsacku + ",intNug=" + newnugsu + ",varRemark='Stock Updated On Credit Note Created' where intProductId=" + ppid + " ", dbc.con);
                                cmdup.ExecuteNonQuery();
                                dbc.con.Close();

                                pid = dbc.max_tblstockhistoryjalgaon();
                                pid = pid + 1;
                                dbc.con.Close();
                                dbc.con.Open();                                                                               //  intId, intProductId, pname intSack, intNug, varUnit, dtDate, tmTime, varUpdater, varReason, varTransport, varRemark
                                MySql.Data.MySqlClient.MySqlCommand cmdaa = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsustockhistoryjalgaon VALUES(" + pid + "," + ppid + ",'" + dr["Product Name"].ToString() + "'," + dr["Sack"].ToString() + "," + dr["Nag"].ToString() + ",'" + ssizea[3].ToString() + "','" + txtDate.Text + "','" + DateTime.UtcNow.ToShortTimeString() + "','" + lblCustName.Text + "','For Credit Note No.: " + txtCrediteNoteNo.Text + "','" + txtTransportName.Text + "','Returned','Added')", dbc.con);
                                cmdaa.ExecuteNonQuery();
                                dbc.con.Close();
                                cmdaa.Dispose();
                                insert_ok_orderdetails = dbc.insert_creditnotedetails(insert_order_ok.ToString(), dr["Product Name"].ToString(), dr["Sack"].ToString(), dr["Nag"].ToString(), dr["Price"].ToString());
                            }
                        }
                    }
                    else if (ddlPlace.Text == "Verkhedi")
                    {
                        insert_order_ok = dbc.insert_CreditNote_subadmin("NA", txtCrediteNoteNo.Text, txtNodeType.Text, custId, Convert.ToInt32(Session["empid"].ToString()), Convert.ToDouble(txtCreditNoteAmount.Text), txtDiscount.Text, txtTransportName.Text, Convert.ToDouble(txtTransportAmount.Text), Convert.ToDouble(txtWages.Text), Convert.ToDouble(txtLorry.Text), ddlPlace.Text == "--Select Stock Added To--" ? "NA" : ddlPlace.Text, txtDate.Text);

                        if (!(insert_order_ok == 0))
                        {
                            foreach (DataRow dr in dt3.Rows)
                            {

                                string myStra = dr["Product Name"].ToString();
                                string[] ssizea = myStra.Split(new char[0]);
                                string mmm = ssizea[0].ToString();

                                dbc.con.Open();
                                MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand("SELECT sanghaviunbreakables.tblsustockvarkhedi.intSack, sanghaviunbreakables.tblsustockvarkhedi.intNug, sanghaviunbreakables.tblsuproducts.intPacking, sanghaviunbreakables.tblsuproducts.varUnit, sanghaviunbreakables.tblsustockvarkhedi.intProductId FROM sanghaviunbreakables.tblsuproducts INNER JOIN sanghaviunbreakables.tblsustockvarkhedi ON sanghaviunbreakables.tblsuproducts.intId = sanghaviunbreakables.tblsustockvarkhedi.intProductId where tblsuproducts.nvarProductName= '" + ssizea[0].ToString() + "' and intSize='" + ssizea[2].ToString() + "'", dbc.con);

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

                                string sendallnug = ((Convert.ToInt64(dr["Sack"].ToString()) * packing) + Convert.ToInt64(dr["Nag"].ToString())).ToString();

                                string newnugvar = (Convert.ToInt64(allnug) + Convert.ToInt64(sendallnug)).ToString();

                                string newsacku = (Convert.ToInt64(newnugvar) / packing).ToString();
                                Int64 tempvaru = Convert.ToInt64(newsacku) * packing;
                                string newnugsu = (Convert.ToInt64(newnugvar) - tempvaru).ToString();

                                string newsacki = (Convert.ToInt64(sendallnug) / packing).ToString();
                                Int64 tempvari = Convert.ToInt64(newsacki) * packing;
                                string newnugsi = (Convert.ToInt64(sendallnug) - tempvari).ToString();

                                dbc.con.Close();
                                dbc.con.Open();
                                MySql.Data.MySqlClient.MySqlCommand cmdup = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsustockvarkhedi set intSack=" + newsacku + ",intNug=" + newnugsu + ",varRemark='Stock Updated On Credit Note Created' where intProductId=" + ppid + " ", dbc.con);
                                cmdup.ExecuteNonQuery();
                                dbc.con.Close();

                                pid = dbc.max_tblstockhistory();
                                pid = pid + 1;
                                dbc.con.Close();
                                dbc.con.Open();                                                                               //  intId, intProductId, pname intSack, intNug, varUnit, dtDate, tmTime, varUpdater, varReason, varTransport, varRemark
                                MySql.Data.MySqlClient.MySqlCommand cmdaa = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsustockhistory VALUES(" + pid + "," + ppid + ",'" + dr["Product Name"].ToString() + "','NA'," + dr["Sack"].ToString() + "," + dr["Nag"].ToString() + ",'" + unita + "','" + txtDate.Text + "','" + DateTime.UtcNow.ToShortTimeString() + "','" + lblCustName.Text + "','Returned in Credit note No " + txtCrediteNoteNo.Text + "','NA','Returned in Credit note No " + txtCrediteNoteNo.Text + "','Add','NA','')", dbc.con);
                                cmdaa.ExecuteNonQuery();
                                dbc.con.Close();
                                cmdaa.Dispose();

                                insert_ok_orderdetails = dbc.insert_creditnotedetails(insert_order_ok.ToString(), dr["Product Name"].ToString(), dr["Sack"].ToString(), dr["Nag"].ToString(), dr["Price"].ToString());

                            }
                        }
                    }
                }
                if (insert_ok_orderdetails == 1)
                {
                    Response.Write("<script>alert('Credit Note Created Successfully');window.location='CrediteNote.aspx';</script>");
                    clear();
                }
                else if (insert_order_ok != 0)
                {
                    Response.Write("<script>alert('Credit Note Created Successfully');window.location='CrediteNote.aspx';</script>");
                    clear();
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

    protected void btnReset_Click(object sender, EventArgs e)
    {
        clear();
    }
    private void BindGrid()
    {
        grdOrderDetails.DataSource = dt3;
        grdOrderDetails.DataBind();
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

    public void clear()
    {

        txtCrediteNoteNo.Text = "";
        txtCreditNoteAmount.Text = "";
        txtCustomerName.Text = "";
        txtDate.Text = "";
        txtDiscount.Text = "";
        txtLorry.Text = "";
        txtNodeType.Text = "";
        txtTransportAmount.Text = "";
        txtTransportName.Text = "";
        txtWages.Text = "";


        lblRepresentativeName.Text = "";
        lblMob.Text = "";
        lblProductTotalPrice.Text = "0";
        ddlPlace.SelectedIndex = 0;

        txtPrice.Text = "";

        lblProductTotalSack.Text = "0";
        lblProductTotalNag.Text = "0";
        lblCustName.Text = "";
        lblMob.Text = "";

    
        dt3.Clear();
        grdOrderDetails.DataSource = dt3;
        grdOrderDetails.DataBind();


    }
    public void clearmyoder()
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
                dt3 = (DataTable)ViewState["DataTable1"];
                dt3.Rows.RemoveAt(RemoveAt);
                dt3.AcceptChanges();
                ViewState["DataTable1"] = dt3;
                BindGrid();
                lblProductTotalSack.Text = (Convert.ToInt32(lblProductTotalSack.Text) - Convert.ToInt32(sacks)).ToString();
                lblProductTotalNag.Text = (Convert.ToInt32(lblProductTotalNag.Text) - Convert.ToInt32(nags)).ToString();
                lblProductTotalPrice.Text = (Math.Round(Convert.ToDouble(lblProductTotalPrice.Text) - Convert.ToDouble(price), 2)).ToString();
                clear();
            }


        }
        catch (Exception ex)
        {
            throw;
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
                    "alert('Please Enter value more than 0');", true);

        }
        else
        {
            AddToDataTable();
            BindGrid();
            clearmyoder();
        }
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


    protected void grdReturn_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });

            string id = commandArgs[0];
            string prname = commandArgs[1];
            string sacks = commandArgs[2];
            string nags = commandArgs[3];
            string price = commandArgs[4];


            if (e.CommandName == "Return")
            {
                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                int ok = 0;
                if (grdOrderDetails.Rows.Count == 0)
                {
                    DataRow dr;
                    dr = dt3.NewRow();

                    dr["PrId"] = id;
                    dr["Product Name"] = prname;
                    dr["Sack"] = sacks;
                    dr["Nag"] = nags;
                    dr["Price"] = price;

                    dt3.Rows.Add(dr);
                    grdOrderDetails.DataSource = dt3;
                    grdOrderDetails.DataBind();

                }
                else
                {
                    foreach (GridViewRow drg in grdOrderDetails.Rows)
                    {
                        if (drg.Cells[1].Text == id.ToString())
                        {
                            ok = 0;
                        }
                        else
                        {
                            ok = 1;
                        }
                    }
                    if (ok == 0)
                    {
                        lblmsg.Text = "Product already added";


                    }
                    else
                    {
                        DataRow dr;
                        dr = dt3.NewRow();

                        dr["PrId"] = id;
                        dr["Product Name"] = prname;
                        dr["Sack"] = sacks;
                        dr["Nag"] = nags;
                        dr["Price"] = price;

                        dt3.Rows.Add(dr);
                        grdOrderDetails.DataSource = dt3;
                        grdOrderDetails.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }


    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static List<string> GetCompletionListNode(string prefixText, int count, string contextKey)
    {

        List<string> CompanyName = new List<string>();


        CompanyName.Add("CD");
        CompanyName.Add("Freight");
        CompanyName.Add("Scheme");
        CompanyName.Add("Goods Return");



        return CompanyName;
    }

    protected void txtNodeType_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Personnel/employee/subadmin/CrediteNote.aspx");
    }

    protected void ddlProName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            string price = string.Empty;
            string myStr = ddlProName.Text;
            string[] ssize = myStr.Split(new char[0]);
            pId = 0;
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
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
        }
    }
    protected void btnReset1_Click(object sender, EventArgs e)
    {
        clearmyoder();
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
    protected void grdReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdReport.PageIndex = e.NewPageIndex;
        GetDatafromDatabase("");
    }
    protected void grdReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "edits")
            {
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT tblsucreditnote.varCrediteNoteNo as 'CNote No', tblsucreditnote.varDate as 'Date', tblsucreditnote.varNoteType as 'Note Type', tblsucustomer.varCompanyName as 'Customer', tblsucreditnote.ex1 as 'Added to'  ,tblsucreditnotedetails.varProductName as 'Product', tblsuproducts.varWeight as 'Standard Weight',Round((tblsucreditnotedetails.varSack * tblsuproducts.intPacking + tblsucreditnotedetails.varNag) * tblsuproducts.varWeight, 2) AS 'Total Kg',tblsucreditnotedetails.varSack * tblsuproducts.intPacking + tblsucreditnotedetails.varNag AS Qty, tblsucreditnote.varCreditNoteAmount as 'Credit Note Amt', tblsucreditnote.varDiscount as 'Disc', tblsucreditnote.varTransportName as 'Transport', tblsucreditnote.varTransportAmount as 'Trans Amt', tblsucreditnote.varWages as Wages, tblsucreditnote.varLorry as Lorry FROM tblsucreditnote LEFT OUTER JOIN tblsucreditnotedetails ON tblsucreditnote.intId = tblsucreditnotedetails.intcreditenoteId LEFT OUTER JOIN tblsucustomer ON tblsucreditnote.intCustid = tblsucustomer.intId LEFT OUTER JOIN tblsuproducts ON tblsucreditnotedetails.intProductId = tblsuproducts.intId where tblsucreditnote.varCrediteNoteNo='" + e.CommandArgument + "'", dbc.con);

                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    txtCrediteNoteNo.Text = e.CommandArgument.ToString();
                    txtCrediteNoteNo.Enabled = false;
                    txtDate.Text = dbc.dr["Date"].ToString();
                    txtCustomerName.Text = dbc.dr["Customer"].ToString();
                    txtCustomerName.Enabled = false;
                    txtNodeType.Text = dbc.dr["Note Type"].ToString();
                    txtCreditNoteAmount.Text = dbc.dr["Credit Note Amt"].ToString();
                    txtDiscount.Text = dbc.dr["Disc"].ToString();
                    txtTransportName.Text = dbc.dr["Transport"].ToString();
                    txtTransportAmount.Text = dbc.dr["Trans Amt"].ToString();
                    txtWages.Text = dbc.dr["Wages"].ToString();
                    txtLorry.Text = dbc.dr["Lorry"].ToString();
                    ddlPlace.Enabled = false;
                }
                dbc.con.Close();
                btnEditUpdate.Visible = true;
                btnAdd.Visible = false;
            }
            else if (e.CommandName == "del")
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    dbc.con.Close();
                    dbc.con.Open();
                    dbc.cmd = new MySqlCommand("DELETE from tblsucreditnote WHERE varCrediteNoteNo='" + txtCrediteNoteNo.Text + "'", dbc.con);
                    dbc.cmd.ExecuteNonQuery();
                    dbc.con.Close();


                    dbc.con.Close();
                    dbc.con.Open();
                    dbc.cmd = new MySqlCommand("DELETE from tblsucreditnotedetails WHERE varCrediteNoteNo='" + txtCrediteNoteNo.Text + "'", dbc.con);
                    dbc.cmd.ExecuteNonQuery();
                    dbc.con.Close();
                }
                else
                {
                }
            }
        }
        catch (Exception es)
        {
        }
    }
    protected void btnEditUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            dbc.con.Close();
            dbc.con.Open();
            dbc.cmd = new MySqlCommand("UPDATE tblsucreditnote SET  varDate='" + txtDate.Text + "', varNoteType='" + txtNodeType.Text + "', varCreditNoteAmount='" + txtCreditNoteAmount.Text + "',varDiscount='" + txtDiscount.Text + "',varTransportName='" + txtTransportName.Text + "',varTransportAmount='" + txtTransportAmount.Text + "',varWages='" + txtWages.Text + "',varLorry='" + txtLorry.Text + "' WHERE varCrediteNoteNo='" + txtCrediteNoteNo.Text + "'", dbc.con);
            dbc.cmd.ExecuteNonQuery();
            dbc.con.Close();

            Response.Write("<script>alert('Credit Note Updated Successfully');window.location='CrediteNote.aspx';</script>");
            clear();
             
        }
        catch (Exception ecc)
        {
            Response.Write("<script>alert('" + ecc.Message + "');window.location='CrediteNote.aspx';</script>");
        }
    }
}