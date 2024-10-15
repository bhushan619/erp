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

public partial class Personnel_admin_Reports_Collection : System.Web.UI.Page
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
            cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT  tblsucollection.intId,   tblsucustomer.varCompanyName as Party,  tblsupersonnel.varName As 'Emp Name',     tblsupersonnel.varSubDesig as Designation,   tblsucollection.varDate as Date, tblsucollection.varPaymentMode as'Pay Mode', tblsucollection.varCheckno as 'Check No',      tblsucollection.varCheckDate as 'Check Date', tblsucollection.varAmount as Amount, tblsucollection.varOtherPaymentDetails as 'Other Details' FROM tblsucollection INNER JOIN tblsucustomer ON tblsucollection.intCustId = tblsucustomer.intId INNER JOIN tblsupersonnel ON tblsucollection.intEmpId = tblsupersonnel.intId where  CAST(STR_TO_DATE(tblsucollection.varDate,'%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + txtFromDate.Text + "','%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + txtToDate.Text + "','%d-%m-%Y') AS DATE)", dbc.con);
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
            Response.Write("<script>alert('Pls Try Again...');window.location='Collection.aspx';</script>");
        }
    }
    protected void GetDatafromDatabase1()
    {

        DataTable dt1 = new DataTable();
        dbc.con.Open();
        string queryStr = "SELECT  tblsucollection.intId,   tblsucustomer.varCompanyName as Party,  tblsupersonnel.varName As 'Emp Name',     tblsupersonnel.varSubDesig as Designation,   tblsucollection.varDate as Date, tblsucollection.varPaymentMode as'Pay Mode', tblsucollection.varCheckno as 'Check No',      tblsucollection.varCheckDate as 'Check Date', tblsucollection.varAmount as Amount, tblsucollection.varOtherPaymentDetails as 'Other Details' FROM tblsucollection INNER JOIN tblsucustomer ON tblsucollection.intCustId = tblsucustomer.intId INNER JOIN tblsupersonnel ON tblsucollection.intEmpId = tblsupersonnel.intId where  CAST(STR_TO_DATE(tblsucollection.varDate,'%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + txtFromDate.Text + "','%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + txtToDate.Text + "','%d-%m-%Y') AS DATE)";
        MySql.Data.MySqlClient.MySqlDataAdapter sda = new MySql.Data.MySqlClient.MySqlDataAdapter(queryStr, dbc.con);
        sda.Fill(dt1);
        grdReport.DataSource = dt1;
        grdReport.DataBind();
        dbc.con.Close();
        
    }
    protected DataTable GetDatafromDatabase()
    {

        DataTable dt14 = new DataTable();
        dbc.con.Open();
        string queryStr = "SELECT  tblsucollection.intId,   tblsucustomer.varCompanyName as Party,  tblsupersonnel.varName As 'Emp Name',     tblsupersonnel.varSubDesig as Designation,   tblsucollection.varDate as Date, tblsucollection.varPaymentMode as'Pay Mode', tblsucollection.varCheckno as 'Check No',      tblsucollection.varCheckDate as 'Check Date', tblsucollection.varAmount as Amount, tblsucollection.varOtherPaymentDetails as 'Other Details' FROM tblsucollection INNER JOIN tblsucustomer ON tblsucollection.intCustId = tblsucustomer.intId INNER JOIN tblsupersonnel ON tblsucollection.intEmpId = tblsupersonnel.intId where  CAST(STR_TO_DATE(tblsucollection.varDate,'%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + txtFromDate.Text + "','%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + txtToDate.Text + "','%d-%m-%Y') AS DATE)";
        MySql.Data.MySqlClient.MySqlDataAdapter sda = new MySql.Data.MySqlClient.MySqlDataAdapter(queryStr, dbc.con);
        sda.Fill(dt14);
               dbc.con.Close();
        return dt14;

    }
    protected void btnExportSale_Click(object sender, EventArgs e)
    {
        try
        {
            //GetDatafromDatabase1();
            //Response.ClearContent();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Collection.xls"));
            //Response.ContentType = "application/ms-excel";           
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter htw = new HtmlTextWriter(sw);
            //grdReport.AllowPaging = false;
            ////Change the Header Row back to white color
            //// grdReport.HeaderRow.Style.Add("background-color", "#FFFFFF");
            ////Applying stlye to gridview header cells


            //grdReport.RenderControl(htw);
            //Response.Write(sw.ToString());

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Collection.xls"));
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
            Response.Write("<script>alert('Pls Try Again...');window.location='Collection.aspx';</script>");
        }
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    protected void grdReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdReport.PageIndex = e.NewPageIndex;
        GetDatafromDatabase1();
    }

    protected void grdReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "edits")
            {
                Response.Redirect("~/Personnel/admin/Reports/EditCollection.aspx?cid=" + e.CommandArgument, false);
            }
            else if (e.CommandName == "del")
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    dbc.con.Close();
                    dbc.con.Open();
                    dbc.cmd = new MySqlCommand("DELETE from tblsucollection WHERE intId='" + e.CommandArgument + "'", dbc.con);
                    dbc.cmd.ExecuteNonQuery();
                    dbc.con.Close();

                    Response.Write("<script>alert('Collection entry Updated Successfully');window.location='Collection.aspx';</script>");
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
}