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


public partial class Personnel_admin_Reports_DispatchExpenseSheet : System.Web.UI.Page
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
            cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varNo as No, varDate as Date, varInvoiceNo AS 'Invoice No' , varLRNo as LRNo, varTransporter as Transport, varParty as Party, varSack as Sack,  varAuto as Auto, varLorry as Lorry, varGoodsReturn as 'Goods Return', varHamali as Hamali, varTotal as Total,varRemark as Remark FROM tblsudispatchexpensesheet where  CAST(STR_TO_DATE(varDate,'%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + txtFromDate.Text + "','%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + txtToDate.Text + "','%d-%m-%Y') AS DATE)", dbc.con);
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
            Response.Write("<script>alert('"+ex.Message+"');window.location='DispatchExpenseSheet.aspx';</script>");
        }
    }
    protected void GetDatafromDatabase1()
    {

        DataTable dt1 = new DataTable();
        dbc.con.Open();
        string queryStr = "SELECT  varNo as No, varDate as Date, varInvoiceNo AS 'Invoice No' , varLRNo as LRNo, varTransporter as Transport, varParty as Party, varSack as Sack, varAuto as Auto, varLorry as Lorry, varGoodsReturn as 'Goods Return', varHamali as Hamali, varTotal as Total,varRemark as Remark FROM tblsudispatchexpensesheet where  CAST(STR_TO_DATE(varDate,'%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + txtFromDate.Text + "','%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + txtToDate.Text + "','%d-%m-%Y') AS DATE)";
        MySql.Data.MySqlClient.MySqlDataAdapter sda = new MySql.Data.MySqlClient.MySqlDataAdapter(queryStr, dbc.con);
        sda.Fill(dt1);
        grdExport.DataSource = dt1;
        grdExport.DataBind();
        dbc.con.Close();

    }
    protected void btnDispatchExpenseSheet_Click(object sender, EventArgs e)
    {
        try
        {
            GetDatafromDatabase1();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "DispatchExpenseSheet.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grdExport.AllowPaging = false;
            //Change the Header Row back to white color
            // grdReport.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //Applying stlye to gridview header cells


            grdExport.RenderControl(htw);
            
            Response.Write(sw.ToString());
            Response.End();grdExport.Visible = false;
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Pls Try Again...');window.location='DispatchExpenseSheet.aspx';</script>");
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    protected void grdRaw_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "edits")
            {
                Response.Redirect("~/Personnel/admin/Reports/EditDispatchExpenses.aspx?cid=" + e.CommandArgument, false);
                //Response.Write("<script>alert('Expense Note Updated Successfully');window.location='DispatchExpenseSheet.aspx';</script>");
            }
            else if (e.CommandName == "del")
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    dbc.con.Close();
                    dbc.con.Open();
                    dbc.cmd = new MySqlCommand("DELETE from tblsudispatchexpensesheet WHERE intId='" + e.CommandArgument + "'", dbc.con);
                    dbc.cmd.ExecuteNonQuery();
                    dbc.con.Close();

                    Response.Write("<script>alert('Expense sheet entry Updated Successfully');window.location='DispatchExpenseSheet.aspx';</script>");
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

    protected void grdRaw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdReport.PageIndex = e.NewPageIndex;
        GetDatafromDatabase1();
    }
}