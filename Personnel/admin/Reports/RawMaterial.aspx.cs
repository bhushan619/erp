using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.IO;

public partial class Personnel_admin_Reports_RawMaterial : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    DateTime datef, datet;
    public static Double totalkg = 0, totalton = 0, totalsack = 0, totalnug = 0, totalAmt=0;
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
        totalAmt = 0;
        string temp = string.Empty, where = string.Empty;
        if (ddlNameRaw.Text != "-- Select Product --")
        {
            dbc.oDt = new System.Data.DataTable();
            datef = DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            datet = DateTime.ParseExact(txtToDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            dbc.con.Open();
            cmd = new MySql.Data.MySqlClient.MySqlCommand("Select varBookingId as 'Bill No', varVendorName as 'Vendor Name',  varName AS Name, varWeightKg AS Kg, varWeightTon AS Ton, dtDate AS `Date`, varRate as 'Rate/Kg', varDiscount as Discount,varAmount AS Amount, varReason AS Reason FROM tblrawmaterialhistory where varName='" + ddlNameRaw.Text + "' and varCalc='Add' and CAST(STR_TO_DATE(dtDate,'%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + txtFromDate.Text + "','%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + txtToDate.Text + "','%d-%m-%Y') AS DATE)", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            ad.Fill(dbc.oDt);
            grdReport.DataSource = dbc.oDt;
            grdReport.DataBind();
            dbc.con.Close();
            dbc.oDt.Dispose();
            cmd.Dispose();

            foreach (GridViewRow grow in grdReport.Rows)
            {
                totalkg = totalkg + Convert.ToDouble(grow.Cells[3].Text.ToString());
                totalton = totalton + Convert.ToDouble(grow.Cells[4].Text.ToString());
                totalAmt= totalAmt + Convert.ToDouble(grow.Cells[8].Text.ToString());
            }
            lblTotalKgUsed.Text = totalkg.ToString();
            lblTotalTonUsed.Text = totalton.ToString();
            lbltotAmt.Text = totalAmt.ToString();

            DataTable dt = new DataTable();
            dbc.con.Open();
            cmd1 = new MySql.Data.MySqlClient.MySqlCommand("Select   varName AS Name, varWeightKg AS Kg, varWeightTon AS Ton, dtDate AS `Date` FROM tblrawmaterialhistory where varName='" + ddlNameRaw.Text + "' and varCalc='Remove' and CAST(STR_TO_DATE(dtDate,'%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + txtFromDate.Text + "','%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + txtToDate.Text + "','%d-%m-%Y') AS DATE)", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);
            ad1.Fill(dt);
            grdDispatch.DataSource = dt;
            grdDispatch.DataBind();
            dbc.con.Close();

            foreach (GridViewRow grow in grdDispatch.Rows)
            {
                totalsack = totalsack + Convert.ToDouble(grow.Cells[1].Text.ToString());
                totalnug = totalnug + Convert.ToDouble(grow.Cells[2].Text.ToString());
            }
            lblSack.Text = totalsack.ToString();
            lblNug.Text = totalnug.ToString();
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
        string queryStr = "Select varBookingId as 'Bill No', varVendorName as 'Vendor Name',  varName AS Name, varWeightKg AS Kg, varWeightTon AS Ton, dtDate AS `Date`, varRate as 'Rate/Kg', varDiscount as Discount,varAmount AS Amount ,varReason AS Reason  FROM tblrawmaterialhistory ";
        MySql.Data.MySqlClient.MySqlDataAdapter sda = new MySql.Data.MySqlClient.MySqlDataAdapter(queryStr, dbc.con);
        sda.Fill(dt);

        dbc.con.Close();
        return dt;
    }
    protected DataTable GetDatafromDatabase1()
    {
        DataTable dt = new DataTable();
        dbc.con.Open();
        string queryStr = "Select   varName AS Name, varWeightKg AS Kg, varWeightTon AS Ton, dtDate AS `Date`  FROM tblrawmaterialhistory ";
        MySql.Data.MySqlClient.MySqlDataAdapter sda = new MySql.Data.MySqlClient.MySqlDataAdapter(queryStr, dbc.con);
        sda.Fill(dt);

        dbc.con.Close();
        return dt;
    }
    protected void btnInwardExport_Click(object sender, EventArgs e)
    {
        if (ddlNameRaw.Text != "-- Select Product --")
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "RawMaterial(Inward).xls"));
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
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "RawMaterial(Inward).xls"));
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
    protected void btnUseExport_Click(object sender, EventArgs e)
    {
        if (ddlNameRaw.Text != "-- Select Product --")
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "UsedRawMaterial.xls"));
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
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "UsedRawMaterial.xls"));
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