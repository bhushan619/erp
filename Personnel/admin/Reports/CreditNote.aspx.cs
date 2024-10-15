using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;

public partial class Personnel_admin_Reports_CreditNote : System.Web.UI.Page
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
            //  SqlDataSource2.SelectCommand = "SELECT distinct CONCAT(nvarProductName,' ',nvarProductSubType ,' ', intSize,' ', varUnit) as ProductName FROM sanghaviunbreakables.tblsuproducts where nvarStatus!='-'";
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
    protected void btnview_Click(object sender, EventArgs e)
    {
        try
        {

            dbc.oDt = new System.Data.DataTable();
            datef = DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            datet = DateTime.ParseExact(txtToDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            dbc.con.Open();
            cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT  tblsucreditnote.intId,tblsucreditnote.varCrediteNoteNo as 'CNote No', tblsucreditnote.varDate as 'Date', tblsucreditnote.varNoteType as 'Note Type', tblsucustomer.varCompanyName as 'Customer', tblsucreditnote.ex1 as 'Added to'  ,tblsucreditnotedetails.varProductName as 'Product', tblsuproducts.varWeight as 'Standard Weight',Round((tblsucreditnotedetails.varSack * tblsuproducts.intPacking + tblsucreditnotedetails.varNag) * tblsuproducts.varWeight, 2) AS 'Total Kg',tblsucreditnotedetails.varSack * tblsuproducts.intPacking + tblsucreditnotedetails.varNag AS Qty, tblsucreditnote.varCreditNoteAmount as 'Credit Note Amt', tblsucreditnote.varDiscount as 'Disc', tblsucreditnote.varTransportName as 'Transport', tblsucreditnote.varTransportAmount as 'Trans Amt', tblsucreditnote.varWages as Wages, tblsucreditnote.varLorry as Lorry FROM tblsucreditnote LEFT OUTER JOIN tblsucreditnotedetails ON tblsucreditnote.intId = tblsucreditnotedetails.intcreditenoteId LEFT OUTER JOIN tblsucustomer ON tblsucreditnote.intCustid = tblsucustomer.intId LEFT OUTER JOIN tblsuproducts ON tblsucreditnotedetails.intProductId = tblsuproducts.intId where  CAST(STR_TO_DATE(tblsucreditnote.varDate,'%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + txtFromDate.Text + "','%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + txtToDate.Text + "','%d-%m-%Y') AS DATE)", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            ad.Fill(dbc.oDt);
            grdReport.DataSource = dbc.oDt;
            grdReport.DataBind();
            dbc.con.Close();
            dbc.oDt.Dispose();
            cmd.Dispose();
            grdExport.Visible = false;
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Pls Try Again...');window.location='CreditNote.aspx';</script>");
        }
    }
    protected void GetDatafromDatabase1()
    {

        DataTable dt1 = new DataTable();
        dbc.con.Open();
        string queryStr = "SELECT tblsucreditnote.intId,tblsucreditnote.varCrediteNoteNo as 'CNote No', tblsucreditnote.varDate as 'Date', tblsucreditnote.varNoteType as 'Note Type', tblsucustomer.varCompanyName as 'Customer', tblsucreditnote.ex1 as 'Added to'  ,tblsucreditnotedetails.varProductName as 'Product', tblsuproducts.varWeight as 'Standard Weight',Round((tblsucreditnotedetails.varSack * tblsuproducts.intPacking + tblsucreditnotedetails.varNag) * tblsuproducts.varWeight, 2) AS 'Total Kg',tblsucreditnotedetails.varSack * tblsuproducts.intPacking + tblsucreditnotedetails.varNag AS Qty, tblsucreditnote.varCreditNoteAmount as 'Credit Note Amt', tblsucreditnote.varDiscount as 'Disc', tblsucreditnote.varTransportName as 'Transport', tblsucreditnote.varTransportAmount as 'Trans Amt', tblsucreditnote.varWages as Wages, tblsucreditnote.varLorry as Lorry FROM tblsucreditnote LEFT OUTER JOIN tblsucreditnotedetails ON tblsucreditnote.intId = tblsucreditnotedetails.intcreditenoteId LEFT OUTER JOIN tblsucustomer ON tblsucreditnote.intCustid = tblsucustomer.intId LEFT OUTER JOIN tblsuproducts ON tblsucreditnotedetails.intProductId = tblsuproducts.intId where  CAST(STR_TO_DATE(tblsucreditnote.varDate,'%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + txtFromDate.Text + "','%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + txtToDate.Text + "','%d-%m-%Y') AS DATE)";
        MySql.Data.MySqlClient.MySqlDataAdapter sda = new MySql.Data.MySqlClient.MySqlDataAdapter(queryStr, dbc.con);
        sda.Fill(dt1);
        grdReport.DataSource = dt1;
        grdReport.DataBind();
        dbc.con.Close();
        
    }
    protected  DataTable GetDatafromDatabase()
    {

        DataTable dt1 = new DataTable();
        dbc.con.Open();
        string queryStr = "SELECT tblsucreditnote.intId,tblsucreditnote.varCrediteNoteNo as 'CNote No', tblsucreditnote.varDate as 'Date', tblsucreditnote.varNoteType as 'Note Type', tblsucustomer.varCompanyName as 'Customer', tblsucreditnote.ex1 as 'Added to'  ,tblsucreditnotedetails.varProductName as 'Product', tblsuproducts.varWeight as 'Standard Weight',Round((tblsucreditnotedetails.varSack * tblsuproducts.intPacking + tblsucreditnotedetails.varNag) * tblsuproducts.varWeight, 2) AS 'Total Kg',tblsucreditnotedetails.varSack * tblsuproducts.intPacking + tblsucreditnotedetails.varNag AS Qty, tblsucreditnote.varCreditNoteAmount as 'Credit Note Amt', tblsucreditnote.varDiscount as 'Disc', tblsucreditnote.varTransportName as 'Transport', tblsucreditnote.varTransportAmount as 'Trans Amt', tblsucreditnote.varWages as Wages, tblsucreditnote.varLorry as Lorry FROM tblsucreditnote LEFT OUTER JOIN tblsucreditnotedetails ON tblsucreditnote.intId = tblsucreditnotedetails.intcreditenoteId LEFT OUTER JOIN tblsucustomer ON tblsucreditnote.intCustid = tblsucustomer.intId LEFT OUTER JOIN tblsuproducts ON tblsucreditnotedetails.intProductId = tblsuproducts.intId where  CAST(STR_TO_DATE(tblsucreditnote.varDate,'%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + txtFromDate.Text + "','%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + txtToDate.Text + "','%d-%m-%Y') AS DATE)";
        MySql.Data.MySqlClient.MySqlDataAdapter sda = new MySql.Data.MySqlClient.MySqlDataAdapter(queryStr, dbc.con);
        sda.Fill(dt1);
      
        dbc.con.Close();
        return dt1;

    }
    protected void btnExportSale_Click(object sender, EventArgs e)
    {
        try
        {
            //DataTable dt11 = new DataTable();
            //dbc.con1.Open();
            //string queryStr = "SELECT  tblsucreditnote.varCrediteNoteNo as 'CNote No', tblsucreditnote.varDate as 'Date', tblsucreditnote.varNoteType as 'Note Type', tblsucustomer.varCompanyName as 'Customer', tblsucreditnote.ex1 as 'Added to'  ,tblsucreditnotedetails.varProductName as 'Product', tblsuproducts.varWeight as 'Standard Weight',Round((tblsucreditnotedetails.varSack * tblsuproducts.intPacking + tblsucreditnotedetails.varNag) * tblsuproducts.varWeight, 2) AS 'Total Kg',tblsucreditnotedetails.varSack * tblsuproducts.intPacking + tblsucreditnotedetails.varNag AS Qty, tblsucreditnote.varCreditNoteAmount as 'Credit Note Amt', tblsucreditnote.varDiscount as 'Disc', tblsucreditnote.varTransportName as 'Transport', tblsucreditnote.varTransportAmount as 'Trans Amt', tblsucreditnote.varWages as Wages, tblsucreditnote.varLorry as Lorry FROM tblsucreditnote LEFT OUTER JOIN tblsucreditnotedetails ON tblsucreditnote.intId = tblsucreditnotedetails.intcreditenoteId LEFT OUTER JOIN tblsucustomer ON tblsucreditnote.intCustid = tblsucustomer.intId LEFT OUTER JOIN tblsuproducts ON tblsucreditnotedetails.intProductId = tblsuproducts.intId where  CAST(STR_TO_DATE(tblsucreditnote.varDate,'%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + txtFromDate.Text + "','%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + txtToDate.Text + "','%d-%m-%Y') AS DATE)";
            //MySql.Data.MySqlClient.MySqlDataAdapter sda = new MySql.Data.MySqlClient.MySqlDataAdapter(queryStr, dbc.con1);
            //sda.Fill(dt11);
            //grdExport.DataSource = dt11;
            //grdExport.DataBind();
            //dbc.con1.Close();

            //Response.ClearContent();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "CreditNote.xls"));
            //Response.ContentType = "application/ms-excel";
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter htw = new HtmlTextWriter(sw);
            //grdExport.AllowPaging = false;
            ////Change the Header Row back to white color
            //// grdReport.HeaderRow.Style.Add("background-color", "#FFFFFF");
            ////Applying stlye to gridview header cells


            //grdExport.RenderControl(htw);

            //Response.Write(sw.ToString());
            //Response.End(); grdExport.Visible = false;


            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "CreditNote.xls"));
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

        

        }
        catch (Exception ex)
        {
           Response.Write("<script>alert('Pls Try Again...');window.location='CreditNote.aspx';</script>");
        }    HttpContext.Current.Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    protected void grdReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "edits")
            {
                Response.Redirect("~/Personnel/admin/Reports/EditCreditNote.aspx?cid=" + e.CommandArgument.ToString().Split(';')[0], false);
            }
            else if (e.CommandName == "del")
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    dbc.con.Close();
                    dbc.con.Open();
                    dbc.cmd = new MySqlCommand("DELETE from tblsucreditnote WHERE varCrediteNoteNo='" + e.CommandArgument.ToString().Split(';')[0] + "'", dbc.con);
                    dbc.cmd.ExecuteNonQuery();
                    dbc.con.Close();


                    dbc.con.Close();
                    dbc.con.Open();
                    dbc.cmd = new MySqlCommand("DELETE from tblsucreditnotedetails WHERE intcreditenoteId='" + e.CommandArgument.ToString().Split(';')[1] + "'", dbc.con);
                    dbc.cmd.ExecuteNonQuery();
                    dbc.con.Close();
                     
                    GetDatafromDatabase1();
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

    protected void grdReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdReport.PageIndex = e.NewPageIndex;
        GetDatafromDatabase1();
    }
}