using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.Configuration;
using System.IO;
using Microsoft.Office.Interop.Excel;


	


public partial class Personnel_admin_Reports_Transport : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    DateTime datef, datet;
    System.Data.DataTable dt = new System.Data.DataTable();
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
            txtFromDate.Text = "01-01-" + DateTime.Now.Year + "";
            txtToDate.Text = DateTime.Now.ToShortDateString();
            BindGrid(txtFromDate.Text, txtToDate.Text, "");
            grdReport.AllowPaging = true;
            grdReport.Visible = false;
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
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static List<string> GetCompletionList(string prefixText, int count, string contextKey)
    {
        String connStr = System.Configuration.ConfigurationManager.ConnectionStrings["sanghaviConnectionString"].ConnectionString;
       
        MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(connStr);
        con.Open();
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT DISTINCT varTransportName FROM tblsuconsignment", con);
        //     cmd.Parameters.AddWithValue("@Name", prefixText);
        MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
       System.Data.DataTable dt=new System.Data.DataTable();
        da.Fill(dt);
        int j = 0;
        List<string> CompanyName = new List<string>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            CompanyName.Add(dt.Rows[i][0].ToString());
            //  CompanyName[j++] =dt.Rows[i][0].ToString();
        }
        con.Close();
        return CompanyName;
    }
    public static Double sacks = 0, nugs = 0, totals = 0, kgs = 0, prices = 0;
    protected void txtView_Click(object sender, EventArgs e)
    {
        sacks = 0; nugs = 0; totals = 0; kgs = 0; prices = 0;
        if (txtCmpName.Text != "-- Select Transport --")
        {

            BindGrid(txtFromDate.Text, txtToDate.Text, "tblsuconsignment.varTransportName ='" + txtCmpName.Text + "' AND");
            foreach (GridViewRow grow in grdReport.Rows)
            {
                sacks = sacks + Convert.ToDouble(grow.Cells[2].Text.ToString());
                nugs = nugs + Convert.ToDouble(grow.Cells[3].Text.ToString());
                totals = totals + Convert.ToDouble(grow.Cells[4].Text.ToString());
                kgs = kgs + Convert.ToDouble(grow.Cells[5].Text.ToString());
                prices = prices + Convert.ToDouble(grow.Cells[6].Text.ToString());
            }
            lblSackSent.Text = sacks.ToString();
            lblNugSent.Text = nugs.ToString();
            lblTotal.Text = totals.ToString();
            lblKg.Text = kgs.ToString();
            lblPrice.Text = prices.ToString();
            grdReport.Visible = true;
            
        }
        else
        {
            Response.Write("<script>alert('Please Select Product Name');</script>");
        }

    }
    protected void grdReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdReport.PageIndex = e.NewPageIndex;
        BindGrid(txtFromDate.Text, txtToDate.Text, "tblsuconsignment.varTransportName =" + txtCmpName.Text + " AND");
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
        MySql.Data.MySqlClient.MySqlCommand cmdd = new MySql.Data.MySqlClient.MySqlCommand("SELECT DISTINCT varProductName as Products FROM tblsuconsignmentdetails order by intProductId asc", cnnd);

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
                //"SELECT intId FROM sanghaviunbreakables.tblsucustomer where varCompanyName='" + arry[0] + "' and varCity='" + arry[1] + "' and varStatus!='-'"
                //send a sql command to select everything from the second table
                cmdd = new MySql.Data.MySqlClient.MySqlCommand("SELECT SUM( tblsuconsignmentdetails.varSack ) AS Sack, SUM( tblsuconsignmentdetails.varNug ) AS Nug, SUM( tblsuconsignmentdetails.varSack ) * tblsuproducts.intPacking + SUM( tblsuconsignmentdetails.varNug ) AS  'Total',(SUM( tblsuconsignmentdetails.varSack ) * tblsuproducts.intPacking + SUM( tblsuconsignmentdetails.varNug ))*tblsuproducts.varWeight AS 'Total Kg',SUM(tblsuconsignmentdetails.varPrice) as Amount FROM tblsuconsignment JOIN tblsuconsignmentdetails ON tblsuconsignment.intConsigmentNo = tblsuconsignmentdetails.intConsigmentNo JOIN tblsuproducts ON tblsuconsignmentdetails.intProductId = tblsuproducts.intId WHERE " + where + " tblsuconsignmentdetails.varProductName =  '" + productname + "' AND CAST( STR_TO_DATE( tblsuconsignment.dtDate,  '%d-%m-%Y' ) AS DATE ) BETWEEN CAST( STR_TO_DATE(  '" + fromdate + "',  '%d-%m-%Y' ) AS DATE ) AND CAST( STR_TO_DATE(  '" + todate + "',  '%d-%m-%Y' ) AS DATE )", cnn);
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
                        amount = rdr3["Amount"].ToString();
                        //increment our counter
                    }
                    cnn.Close();
                    rdr3.Close();
                }

                if (sack == "")
                {
                }
                else if (nug == "")
                {
                }
                else if (total == "")
                {
                }
                else if (totalkg == "")
                {
                }
                else if (amount == "")
                {
                }
                else
                {
                    srno = srno + 1;
                    dt.Rows.Add(srno, productname, sack, nug, total, totalkg, amount);
                }
            }
            cnnd.Close();
            rdr2.Close();
        }

        grdReport.DataSource = dt;
        grdReport.DataBind();

    }

    
    protected System.Data.DataTable GetDatafromDatabase()
    {

      
        dbc.con.Open();
        string queryStr = "SELECT  tblsuconsignmentdetails.varProductName as Products ,tblsuconsignmentdetails.varSack  AS Sack, tblsuconsignmentdetails.varNug  AS Nug, (tblsuconsignmentdetails.varSack  * tblsuproducts.intPacking + tblsuconsignmentdetails.varNug ) AS  'Total Nug',(tblsuconsignmentdetails.varSack  * tblsuproducts.intPacking +  tblsuconsignmentdetails.varNug)*tblsuproducts.varWeight AS 'Total Kg',tblsuconsignmentdetails.varPrice as Amount FROM tblsuconsignment JOIN tblsuconsignmentdetails ON tblsuconsignment.intConsigmentNo = tblsuconsignmentdetails.intConsigmentNo JOIN tblsuproducts ON tblsuconsignmentdetails.intProductId = tblsuproducts.intId ";
        MySql.Data.MySqlClient.MySqlDataAdapter sda = new MySql.Data.MySqlClient.MySqlDataAdapter(queryStr, dbc.con);
        sda.Fill(dt);

        dbc.con.Close();
        return dt;
    }
  
    

    protected void btnExport_Click(object sender, EventArgs e)
    {

        if (txtCmpName.Text != "")
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "TransportReport.xls"));
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
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "TransportReport.xls"));
            Response.ContentType = "application/ms-excel";
            System.Data.DataTable dt = GetDatafromDatabase();
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