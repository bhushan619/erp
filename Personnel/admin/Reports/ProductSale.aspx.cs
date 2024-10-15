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

public partial class Personnel_admin_Reports_ProductSale : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    DateTime datef, datet;
    
    MySql.Data.MySqlClient.MySqlCommand cmd, cmd1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../../SignUpLogin.aspx';</script>");
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        else if (!IsPostBack)
        {
            getAdmindata();
            getImage();
            txtFromDate.Text = "01-01-" + DateTime.Now.Year + "";
            txtToDate.Text = DateTime.Now.ToShortDateString();
            BindGrid(txtFromDate.Text, txtToDate.Text, "");
            grdReport.AllowPaging = true;
            notifications();
        }
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["adminid"].ToString()), "Admin").ToString();
    }
    public void getAdmindata()
    {
        try
        {

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varName FROM sanghaviunbreakables.tblsupersonnel where intId=" + Session["adminid"].ToString() + "", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblCustName.Text = dbc.dr["varName"].ToString();

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
        string ImageUr = dbc.select_empProfilePic(Convert.ToInt32(Session["adminid"].ToString()));
        if (ImageUr == "")
        {
            imgProPic.ImageUrl = "~/Personnel/admin/media/NoProfile.png";
        }
        else
        {

            imgProPic.ImageUrl = "~/Personnel/admin/media/" + ImageUr;
        }
        //  SqlDataSourceMedia.SelectCommand = "SELECT [imgImage] FROM tblsucustomer where intId=" + Convert.ToInt32(Session["adminid"].ToString()) + "";
    }
    protected void lnkLogoutUp_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Session["adminid"] = "";
        Session.Remove("adminid");

        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();

        Response.Redirect("~/Default.aspx");
    }

    protected void txtView_Click(object sender, EventArgs e)
    {
        
        string temp = string.Empty, where = string.Empty;
        if (ddlNameRaw.Text != "-- Select Product --")
        {
            if (ddlNameRaw.Text == "All Products")
            {
                BindGrid(txtFromDate.Text, txtToDate.Text, "");
            }
            else
            {
                BindGrid(txtFromDate.Text, txtToDate.Text, "WHERE varProductName='" + ddlNameRaw.Text + "'");
            }
        }
        else
        {
            Response.Write("<script>alert('Please Select Product Name');</script>");
        }

    }
    protected void grdReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdReport.PageIndex = e.NewPageIndex;
        BindGrid(txtFromDate.Text,txtToDate.Text,"");
    }

    int srno = 0;
    string productname = string.Empty;
    string sack = string.Empty;
    string nug = string.Empty;
    string total = string.Empty;
    string totalkg = string.Empty;
    string amount = string.Empty;

    public void BindGrid(string fromdate, string todate, string where)
    {

        ////data reader we will use to read data from our tables
         MySql.Data.MySqlClient.MySqlDataReader rdr2, rdr3;
        if (!IsPostBack)
        {
            BoundField bfield = new BoundField();
            bfield.HeaderText = "Sr. No.";
            bfield.DataField = "Sr. No.";
            grdReport.Columns.Add(bfield);

            BoundField efield = new BoundField();
            efield.HeaderText = "Product Name";
            efield.DataField = "Product Name";
            grdReport.Columns.Add(efield);

            BoundField cfield = new BoundField();
            cfield.HeaderText = "Sack";
            cfield.DataField = "Sack";
            grdReport.Columns.Add(cfield);

            BoundField ffield = new BoundField();
            ffield.HeaderText = "Nug";
            ffield.DataField = "Nug";
            grdReport.Columns.Add(ffield);

            BoundField gfield = new BoundField();
            gfield.HeaderText = "Total Nug";
            gfield.DataField = "Total Nug";
            grdReport.Columns.Add(gfield);

            BoundField kfield = new BoundField();
            kfield.HeaderText = "Total Kg";
            kfield.DataField = "Total Kg";
            grdReport.Columns.Add(kfield);

            BoundField pfield = new BoundField();
            pfield.HeaderText = "Amount";
            pfield.DataField = "Amount";
            grdReport.Columns.Add(pfield);
             
        }
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[7] {             
                        new DataColumn("Sr. No.", typeof(string)),                         
                        new DataColumn("Product Name", typeof(string)),
                        new DataColumn("Sack", typeof(string)),
                        new DataColumn("Nug", typeof(string)), 
                        new DataColumn("Total Nug", typeof(string)),   
                         new DataColumn("Total Kg", typeof(string)),
                         new DataColumn("Amount", typeof(string)),  
        });

        DataRow dr = dt.NewRow();

        MySql.Data.MySqlClient.MySqlConnection cnnd = new MySql.Data.MySqlClient.MySqlConnection();
        cnnd.ConnectionString = ConfigurationManager.ConnectionStrings["sanghaviConnectionString"].ConnectionString;

        //send a sql command to select everything from the first table
        MySql.Data.MySqlClient.MySqlCommand cmdd = new MySql.Data.MySqlClient.MySqlCommand("SELECT DISTINCT varProductName as Products FROM tblsuorderdetails " + where + " order by intProductId asc", cnnd);
       
        cmdd.CommandType = CommandType.Text;

        using (cnnd)
        {
            //open connection
            cnnd.Open();
            //read data from the table to our data reader
            rdr2 = cmdd.ExecuteReader();
            //loop through each row we have read
            while (rdr2.Read())
            {
                productname = rdr2["Products"].ToString();

                MySql.Data.MySqlClient.MySqlConnection cnn = new MySql.Data.MySqlClient.MySqlConnection();
                cnn.ConnectionString = ConfigurationManager.ConnectionStrings["sanghaviConnectionString"].ConnectionString;

                //send a sql command to select everything from the second table
                cmdd = new MySql.Data.MySqlClient.MySqlCommand("SELECT tblsuorderdetails.varProductName ,SUM( tblsuorderdetails.varQuantity ) AS Sack, SUM( tblsuorderdetails.varNag ) AS Nug, SUM( tblsuorderdetails.varQuantity ) * tblsuproducts.intPacking + SUM( tblsuorderdetails.varNag ) AS  'Total',(SUM( tblsuorderdetails.varQuantity ) * tblsuproducts.intPacking + SUM( tblsuorderdetails.varNag ))*tblsuproducts.varWeight AS 'Total Kg',SUM(tblsuorderdetails.varPrice) as Amount FROM tblsuorder JOIN tblsuorderdetails ON tblsuorder.intOrderId = tblsuorderdetails.intOrderId JOIN tblsuproducts ON tblsuorderdetails.intProductId = tblsuproducts.intId WHERE tblsuorderdetails.varProductName =  '" + productname + "' AND CAST( STR_TO_DATE( tblsuorder.dtDate,  '%d-%m-%Y' ) AS DATE ) BETWEEN CAST( STR_TO_DATE(  '" + fromdate + "',  '%d-%m-%Y' ) AS DATE ) AND CAST( STR_TO_DATE(  '" + todate + "',  '%d-%m-%Y' ) AS DATE )", cnn);
                cmdd.CommandType = CommandType.Text;

                using (cnn)
                {
                    cnn.Open();
                    rdr3 = cmdd.ExecuteReader();
                    while (rdr3.Read())
                    {
                        //add data to our row
                        sack = rdr3["Sack"].ToString();
                        nug = rdr3["Nug"].ToString();
                        total = rdr3["Total"].ToString();
                        totalkg = rdr3["Total Kg"].ToString();                      
                        amount=rdr3["Amount"].ToString();
                        //increment our counter
                    }
                    cnn.Close();
                    rdr3.Close();
                }
                srno = srno + 1;
                dt.Rows.Add(srno, productname, sack, nug, total,totalkg,amount);
            }
            cnnd.Close();
            rdr2.Close();
        }

        grdReport.DataSource = dt;
        grdReport.DataBind();

    }
    protected DataTable GetDatafromDatabase()
    {
        DataTable dt = new DataTable();
        //using (MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection("Data Source=50.62.209.38;Integrated Security=true;Initial Catalog=sanghaviunbreakables"))
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT tblsuorderdetails.varProductName AS 'Product Name' , tblsuorderdetails.varQuantity  AS Sack, tblsuorderdetails.varNag AS Nug,  (tblsuorderdetails.varQuantity  * tblsuproducts.intPacking +  tblsuorderdetails.varNag)  AS  'Total Nug',( tblsuorderdetails.varQuantity  * tblsuproducts.intPacking +  tblsuorderdetails.varNag )*tblsuproducts.varWeight AS 'Total Kg',tblsuorderdetails.varPrice as Amount FROM tblsuorder JOIN tblsuorderdetails ON tblsuorder.intOrderId = tblsuorderdetails.intOrderId JOIN tblsuproducts ON tblsuorderdetails.intProductId = tblsuproducts.intId WHERE varRemark='Sell'", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            da.Fill(dt);
            dbc.con.Close();
        }
        return dt;
    }
    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //    return;
    //}
    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (ddlNameRaw.Text != "All Products")
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "ProductSale.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grdReport.AllowPaging = false;
            grdReport.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        else 
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "ProductSale.xls"));
            Response.ContentType = "application/ms-excel";
            DataTable dt = GetDatafromDatabase();
            string str = string.Empty;
            foreach (DataColumn dtcol in dt.Columns)
            {
                Response.Write(str + dtcol.ColumnName);
                str = "\t";
            }
            Response.Write("\n");
            foreach (DataRow dr in dt.Rows)
            {
                str = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Response.Write(str + Convert.ToString(dr[j]));
                    str = "\t";
                }
                Response.Write("\n");
            }
            Response.End();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }
    // this does all the work to export to excel
  
}