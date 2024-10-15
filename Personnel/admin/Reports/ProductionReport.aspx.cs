    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.IO;

public partial class Personnel_admin_Reports_ProductionReport : System.Web.UI.Page
{

    DatabaseConnection dbc = new DatabaseConnection();
    DateTime datef, datet;
    MySql.Data.MySqlClient.MySqlCommand cmd, cmd1;

    public static Double totalkg = 0, totalWeight = 0, totalquantity = 0;
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
            totalkg = 0;
            totalWeight = 0;
            totalquantity = 0;
            string temp = string.Empty;

            dbc.oDt = new System.Data.DataTable();
            datef = DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            datet = DateTime.ParseExact(txtToDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            dbc.con.Close();
            dbc.con.Open();
            cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT         tblsustockhistory.dtDate as 'Date',tblsustockhistory.varRemark as 'Remark', tblsustockhistory.varChallenNo as 'ChallenNo',tblsustockhistory.varProName as 'Product',tblsustockhistory.intSack * tblsuproducts.intPacking + tblsustockhistory.intNug AS Quantity,tblsuproducts.varWeight as 'Standard Weight',(tblsustockhistory.intSack * tblsuproducts.intPacking + tblsustockhistory.intNug) * tblsuproducts.varWeight AS 'Total Kg' FROM            tblsustockhistory INNER JOIN         tblsuproducts ON tblsustockhistory.intProductId = tblsuproducts.intId where  CAST(STR_TO_DATE(tblsustockhistory.dtDate,'%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + txtFromDate.Text + "','%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + txtToDate.Text + "','%d-%m-%Y') AS DATE)", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            ad.Fill(dbc.oDt);
            grdReport.DataSource = dbc.oDt;
            grdReport.DataBind();
            dbc.con.Close();
            dbc.oDt.Dispose();
            cmd.Dispose();

            foreach (GridViewRow grow in grdReport.Rows)
            {
                totalquantity = totalquantity + Convert.ToDouble(grow.Cells[4].Text.ToString());
                totalkg = totalkg + Convert.ToDouble(grow.Cells[6].Text.ToString());
                totalWeight = totalWeight + Convert.ToDouble(grow.Cells[5].Text.ToString());


            }

            lblTotalKgUsed.Text = totalkg.ToString();
            lblTotalWeightUsed.Text = totalWeight.ToString();
            lblTotalQuantity.Text = totalquantity.ToString();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Pls Try Again...');window.location='ProductionReport.aspx';</script>");
        }
    
    }

    protected void btnExportProduction_Click(object sender, EventArgs e)
    {
        DataTable dt1 = new DataTable();
        dbc.con.Open();
        string queryStr = "SELECT         tblsustockhistory.dtDate as 'Date',tblsustockhistory.varRemark as 'Remark', tblsustockhistory.varChallenNo as 'ChallenNo',tblsustockhistory.varProName as 'Product',tblsustockhistory.intSack * tblsuproducts.intPacking + tblsustockhistory.intNug AS Quantity,tblsuproducts.varWeight as 'Standard Weight',(tblsustockhistory.intSack * tblsuproducts.intPacking + tblsustockhistory.intNug) * tblsuproducts.varWeight AS 'Total Kg' FROM            tblsustockhistory INNER JOIN         tblsuproducts ON tblsustockhistory.intProductId = tblsuproducts.intId where  CAST(STR_TO_DATE(tblsustockhistory.dtDate,'%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + txtFromDate.Text + "','%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + txtToDate.Text + "','%d-%m-%Y') AS DATE)";
        MySql.Data.MySqlClient.MySqlDataAdapter sda = new MySql.Data.MySqlClient.MySqlDataAdapter(queryStr, dbc.con);
        sda.Fill(dt1);
        grdReport.DataSource = dt1;
        grdReport.DataBind();
        dbc.con.Close();

        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "ProductionReport.xls"));
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
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }
}