using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.IO;

public partial class Personnel_admin_Reports_StockRecievedJalgaon : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    DateTime datef, datet;
    public static Double totalkg = 0, totalton = 0, totalsack = 0, totalnug = 0;
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
            SqlDataSource2.SelectCommand = "SELECT distinct CONCAT(nvarProductName,' ',nvarProductSubType ,' ', intSize,' ', varUnit) as ProductName FROM sanghaviunbreakables.tblsuproducts where nvarStatus!='-'";
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
        totalkg = 0;
        totalton = 0;
        totalsack = 0;
        totalnug = 0;
        string temp = string.Empty, where = string.Empty;
        if (ddlProName.Text != "-- Select Product --")
        {
            dbc.oDt = new System.Data.DataTable();
            datef = DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            datet = DateTime.ParseExact(txtToDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            dbc.con.Open();
            cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT  varProName as ProductName,intSack as Sack,intNug as Nug, varReason as Reason,dtDate as Date FROM tblsustockhistoryjalgaon where varProName='" + ddlProName.Text + "' and varCalc='Add' and CAST(STR_TO_DATE(dtDate,'%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + txtFromDate.Text + "','%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + txtToDate.Text + "','%d-%m-%Y') AS DATE)", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            ad.Fill(dbc.oDt);
            grdReport.DataSource = dbc.oDt;
            grdReport.DataBind();
            dbc.con.Close();
            dbc.oDt.Dispose();
            cmd.Dispose();



            DataTable dt = new DataTable();
            dbc.con.Open();
            cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT  varProName as ProductName,intSack as Sack,intNug as Nug,varReason as Reason, dtDate as Date FROM tblsustockhistoryjalgaon where varProName='" + ddlProName.Text + "' and varCalc='Remove' and CAST(STR_TO_DATE(dtDate,'%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + txtFromDate.Text + "','%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + txtToDate.Text + "','%d-%m-%Y') AS DATE)", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);
            ad1.Fill(dt);
            grdDispatch.DataSource = dt;
            grdDispatch.DataBind();
            dbc.con.Close();

            int prodId = 0;
            int packing = 0;
            string myStr = ddlProName.Text;
            string[] ssize = myStr.Split(new char[0]);
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmds = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varUnit,intPacking FROM sanghaviunbreakables.tblsuproducts where nvarProductName='" + ssize[0].ToString() + "' and nvarProductSubType='" + ssize[1].ToString() + "' and intSize='" + ssize[2].ToString() + "'", dbc.con);

            dbc.dr = cmds.ExecuteReader();
            if (dbc.dr.Read())
            {
                prodId = Convert.ToInt32(dbc.dr["intId"].ToString());
                packing = Convert.ToInt32(dbc.dr["intPacking"].ToString());
            }

            dbc.con.Close();
            dbc.dr.Close();

            foreach (GridViewRow grow in grdReport.Rows)
            {
                totalkg = totalkg + Convert.ToDouble(grow.Cells[1].Text.ToString());
                totalton = totalton + Convert.ToDouble(grow.Cells[2].Text.ToString());
            }

            double finalrec = (totalkg * packing) + totalton;

            string newsacku = (Convert.ToInt64(finalrec) / packing).ToString();
            Int64 tempvaru = Convert.ToInt64(newsacku) * packing;
            string newnugsu = (Convert.ToInt64(finalrec) - tempvaru).ToString();

            lblTotalKgUsed.Text = newsacku;
            lblTotalTonUsed.Text = newnugsu;
            lblTotalReceived.Text = finalrec.ToString();

            foreach (GridViewRow grow in grdDispatch.Rows)
            {
                totalsack = totalsack + Convert.ToDouble(grow.Cells[1].Text.ToString());
                totalnug = totalnug + Convert.ToDouble(grow.Cells[2].Text.ToString());
            }

            double finalsale = (totalsack * packing) + totalnug;

            string newsack = (Convert.ToInt64(finalsale) / packing).ToString();
            Int64 tempvar = Convert.ToInt64(newsack) * packing;
            string newnugs = (Convert.ToInt64(finalsale) - tempvar).ToString();

            lblSack.Text = newsack;
            lblNug.Text = newnugs;
            lblTotalSale.Text = finalsale.ToString();

            dbc.con.Open();
            cmds = new MySql.Data.MySqlClient.MySqlCommand("SELECT SUM(tblsucreditnotedetails.varSack) AS Sack, SUM(tblsucreditnotedetails.varNag) AS Nug FROM tblsucreditnote INNER JOIN tblsucreditnotedetails ON tblsucreditnote.intId = tblsucreditnotedetails.intcreditenoteId WHERE (tblsucreditnote.ex1 = 'Jalgaon') AND (tblsucreditnotedetails.varProductName = '" + ddlProName.Text + "')", dbc.con);

            dbc.dr = cmds.ExecuteReader();
            if (dbc.dr.Read())
            {
                totalsack = Convert.ToInt64(dbc.dr["Sack"].ToString() == "" ? "0" : dbc.dr["Sack"].ToString());
                totalnug = Convert.ToInt64(dbc.dr["Nug"].ToString() == "" ? "0" : dbc.dr["Nug"].ToString());
            }
            dbc.con.Close();
            dbc.dr.Close();
            finalsale = (totalsack * packing) + totalnug;

            newsack = (Convert.ToInt64(finalsale) / packing).ToString();
            tempvar = Convert.ToInt64(newsack) * packing;
            newnugs = (Convert.ToInt64(finalsale) - tempvar).ToString();

            lblCreditNoteSack.Text = newsack;
            lblCreditNoteNug.Text = newnugs;
            lblCreditNoteTotal.Text = finalsale.ToString();



            SqlDataSource1.SelectCommand = "SELECT sanghaviunbreakables.tblsuproducts.intId, CONCAT(tblsuproducts.nvarProductName,' ', tblsuproducts.intSize,' ', tblsuproducts.varUnit) as ProductName, sanghaviunbreakables.tblsustockjalgaon.intSack, sanghaviunbreakables.tblsustockjalgaon.intNug, tblsuproducts.intPacking* tblsustockjalgaon.intSack + tblsustockjalgaon.intNug AS total FROM sanghaviunbreakables.tblsuproducts INNER JOIN sanghaviunbreakables.tblsustockjalgaon ON sanghaviunbreakables.tblsuproducts.intId = sanghaviunbreakables.tblsustockjalgaon.intProductId where sanghaviunbreakables.tblsuproducts.intId=" + prodId + "";
        }
        else
        {
            Response.Write("<script>alert('Please Select Product Name');</script>");
        }
    }
    protected DataTable GetDatafromDatabase()
    {

        DataTable dt = new DataTable();
        dbc.con.Open();
        string queryStr = "SELECT  varProName as ProductName,intSack as Sack,intNug as Nug, varReason as Reason,dtDate as Date FROM tblsustockhistoryjalgaon ";
        MySql.Data.MySqlClient.MySqlDataAdapter sda = new MySql.Data.MySqlClient.MySqlDataAdapter(queryStr, dbc.con);
        sda.Fill(dt);

        dbc.con.Close();
        return dt;
    }
    protected DataTable GetDatafromDatabase1()
    {

        DataTable dt = new DataTable();
        dbc.con.Open();
        string queryStr = "SELECT  varProName as ProductName,intSack as Sack,intNug as Nug,varReason as Reason, dtDate as Date FROM tblsustockhistoryjalgaon ";
        MySql.Data.MySqlClient.MySqlDataAdapter sda = new MySql.Data.MySqlClient.MySqlDataAdapter(queryStr, dbc.con);
        sda.Fill(dt);

        dbc.con.Close();
        return dt;
    }
    protected void btnRecievedExport_Click(object sender, EventArgs e)
    {
        if (ddlProName.Text != "-- Select Product --")
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "JalgaonProductRecieve.xls"));
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
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "JalgaonProductRecieve.xls"));
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
    protected void btnDispatchExport_Click(object sender, EventArgs e)
    {
        if (ddlProName.Text != "-- Select Product --")
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "JalgaonProductDispatch.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grdDispatch.AllowPaging = false;
            grdDispatch.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        else
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "JalgaonProductDispatch.xls"));
            Response.ContentType = "application/ms-excel";
            DataTable dt = GetDatafromDatabase1();
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
}