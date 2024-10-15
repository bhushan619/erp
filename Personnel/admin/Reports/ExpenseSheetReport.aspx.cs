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

public partial class Personnel_admin_Reports_ExpenseSheetReport : System.Web.UI.Page
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
            SqlDataSourceEmp.SelectCommand = "SELECT intId, varName, varMobile, varMobileVerify, varEmail, varEmailVerify, varPassword, varAddress, varCity, varState, varDesignation, varSubDesig, varStatus, varIDProof, varIDProofNo, varPanCardNo, imgImage, dtDateOfBirth FROM tblsupersonnel WHERE varDesignation='Employee'";
            ddlEmployee.DataValueField = "intId";
            ddlEmployee.DataTextField = "varName";
            grdReport.DataBind();
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

            dbc.con.Open();
            DataTable view = new DataTable();
            MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT intId,  dtStartDate as 'Start Date', dtEndDate as 'End Date', nvarLocation as 'Location' FROM tblsuexpenses WHERE intEmpId=" + ddlEmployee.SelectedValue + " and  CAST(STR_TO_DATE(tblsuexpenses.dtStartDate,'%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + txtFromDate.Text + "','%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + txtToDate.Text + "','%d-%m-%Y') AS DATE)", dbc.con);
            adp.Fill(view);
            grdReport.DataSource = view;
            grdReport.DataBind();
            grdReport.Columns[0].Visible = false;
            dbc.con.Close();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Pls Try Again...');window.location='ExpenseSheetReport.aspx';</script>");
        }
    }
    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "edits")
            {
                Response.Redirect("~/Personnel/admin/Reports/ExpenseSheet.aspx?cid=" + e.CommandArgument, false);
            }
            else if (e.CommandName == "view")
            {
                int expenseId = Convert.ToInt32(e.CommandArgument.ToString());

                dbc.con.Open();
                DataTable view = new DataTable();
                MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySqlDataAdapter("SELECT   dtDate as Date,  nvarPlace as Place , nvarExpenseDetail as Details,  nvarModeOfTransport as Transport, nvarLocal as Local, nvarLodging as Lodging, nvarDA as DA, nvarOther as Other, nvarTotal as Total FROM tblsuexpensesdetails WHERE intExpensesId=" + expenseId + "", dbc.con);
                adp.Fill(view);
                grdSheetDetails.DataSource = view;
                grdSheetDetails.DataBind();
                dbc.con.Close();

                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySqlCommand("SELECT intId, (SELECT varName FROM tblsupersonnel WHERE intId=intEmpId) as EmpID, dtStartDate, nvarAdvance, nvarLocation, nvarBalance, nvarTotalExpense, dtEndDate, imgSignature, nvarRemark FROM tblsuexpenses WHERE intId=" + expenseId + "", dbc.con);
                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    txtFDate.Text = dbc.dr["dtStartDate"].ToString();
                    txtTDate.Text = dbc.dr["dtEndDate"].ToString();
                    txtLocation.Text = dbc.dr["nvarLocation"].ToString();

                }
                dbc.con.Close();

            }
            else if (e.CommandName == "deletes")
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    int expenseId = Convert.ToInt32(e.CommandArgument.ToString());

                    dbc.con.Open();
                    MySql.Data.MySqlClient.MySqlCommand adp = new MySqlCommand("delete FROM tblsuexpensesdetails WHERE intExpensesId=" + expenseId + "", dbc.con);
                    adp.ExecuteNonQuery();
                    dbc.con.Close();

                    dbc.con.Open();
                    adp = new MySqlCommand("delete FROM tblsuexpenses WHERE intId=" + expenseId + "", dbc.con);
                    adp.ExecuteNonQuery();
                    dbc.con.Close();

                    Response.Write("<script>alert('Sheet deleted successfully ..!!');window.location='ExpenseSheetReport.aspx';</script>");
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Some error please try again ..!!');window.location='ExpenseSheetReport.aspx';</script>");
        }
    }

    protected void GetDatafromDatabase()
    {

        DataTable dt1 = new DataTable();
        dbc.con.Open();
        string queryStr = "SELECT tblsupersonnel.varName AS `Emp Name`, tblsuexpenses.dtStartDate AS `Start Date`, tblsuexpenses.dtEndDate AS `End Date`, tblsuexpenses.nvarLocation AS Location, tblsuexpensesdetails.dtDate AS `Date`, tblsuexpensesdetails.nvarPlace AS Place, tblsuexpensesdetails.nvarExpenseDetail AS Details, tblsuexpensesdetails.nvarModeOfTransport AS Transport, tblsuexpensesdetails.nvarLocal AS `Local Exp`,tblsuexpensesdetails.nvarLodging AS Lodging, tblsuexpensesdetails.nvarDA AS DA, tblsuexpensesdetails.nvarOther AS Other, tblsuexpensesdetails.nvarTotal AS `Single Total`, tblsuexpenses.nvarTotalExpense AS `Total Exp` FROM tblsuexpenses INNER JOIN tblsuexpensesdetails ON tblsuexpenses.intId = tblsuexpensesdetails.intExpensesId INNER JOIN tblsupersonnel ON tblsuexpenses.intEmpId = tblsupersonnel.intId WHERE (tblsuexpenses.intEmpId = " + ddlEmployee.SelectedValue + ") and CAST(STR_TO_DATE(tblsuexpenses.dtStartDate, '%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + txtFromDate.Text + "', '%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + txtToDate.Text + "', '%d-%m-%Y') AS DATE)";
        MySql.Data.MySqlClient.MySqlDataAdapter sda = new MySql.Data.MySqlClient.MySqlDataAdapter(queryStr, dbc.con);
        sda.Fill(dt1);
        GridViewExport.DataSource = dt1;
        GridViewExport.DataBind();
        dbc.con.Close();
         
    }
    
    protected void btnExportSale_Click(object sender, EventArgs e)
    {
        try
        {
            GetDatafromDatabase();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "ExpenseSheetReport.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridViewExport.AllowPaging = false;
            //Change the Header Row back to white color
            // grdReport.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //Applying stlye to gridview header cells


            GridViewExport.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Pls Try Again...');window.location='ExpenseSheetReport.aspx';</script>");
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }
    private decimal TotalPrice = (decimal)0.0;
    protected void grdSheetDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check row type
        if (e.Row.RowType == DataControlRowType.DataRow)
            // if row type is DataRow, add ProductSales value to TotalSales
            TotalPrice += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total"));
        else if (e.Row.RowType == DataControlRowType.Footer)
        // If row type is footer, show calculated total value
        // Since this example uses sales in dollars, I formatted output as currency
        {
            e.Row.Cells[8].Text = TotalPrice.ToString();
        }
    }
    protected void lbkBack_Click(object sender, EventArgs e)
    { 
        Response.Redirect("~/Personnel/admin/Report.aspx", false);
    }
}