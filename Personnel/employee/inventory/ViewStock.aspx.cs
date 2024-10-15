using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Personnel_employee_ViewStock : System.Web.UI.Page
{
    static string empdesig = string.Empty;
    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();
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
            bindGrid();

        }
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["empid"].ToString()), empdesig).ToString();
    }
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
            Response.Write("<script>alert('Please Try Again');</script>");
        }
        //  SqlDataSourceMedia.SelectCommand = "SELECT [imgImage] FROM tblsucustomer where intId=" + Convert.ToInt32(Session["empid"].ToString()) + "";
    }
   
    protected void lnkLogout_Click(object sender, EventArgs e)
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

    public void bindGrid()
    {
        DataTable dt = new DataTable();
        dbc.con.Open();
        string queryStr = "SELECT CONCAT(tblsuproducts.nvarProductName, ' ', tblsuproducts.intSize, ' ', tblsuproducts.varUnit) AS 'Product Name',  tblsuproducts.intPacking as Packing,  tblsuproducts.varWeight as Weight, tblsustockvarkhedi.intSack as 'VSack', tblsustockvarkhedi.intNug as 'VNug', tblsuproducts.intPacking* tblsustockvarkhedi.intSack + tblsustockvarkhedi.intNug AS 'VTotal',tblsustockjalgaon.intSack as 'JSack', tblsustockjalgaon.intNug as 'JNug', tblsuproducts.intPacking* tblsustockjalgaon.intSack + tblsustockjalgaon.intNug AS 'JTotal',FLOOR((((tblsustockvarkhedi.intSack + tblsustockjalgaon.intSack) * tblsuproducts.intPacking) + (tblsustockvarkhedi.intNug + tblsustockjalgaon.intNug)) / tblsuproducts.intPacking) as 'TSack',FLOOR((((tblsustockvarkhedi.intSack + tblsustockjalgaon.intSack) * tblsuproducts.intPacking) + (tblsustockvarkhedi.intNug + tblsustockjalgaon.intNug))) - FLOOR((((tblsustockvarkhedi.intSack + tblsustockjalgaon.intSack) * tblsuproducts.intPacking) + (tblsustockvarkhedi.intNug + tblsustockjalgaon.intNug)) / tblsuproducts.intPacking) * tblsuproducts.intPacking as 'TNug',FLOOR((((tblsustockvarkhedi.intSack + tblsustockjalgaon.intSack) * tblsuproducts.intPacking) + (tblsustockvarkhedi.intNug + tblsustockjalgaon.intNug))) as 'Total',Round(FLOOR((((tblsustockvarkhedi.intSack + tblsustockjalgaon.intSack) * tblsuproducts.intPacking) + (tblsustockvarkhedi.intNug + tblsustockjalgaon.intNug))) * tblsuproducts.varWeight, 3) as TotalKg FROM tblsuproducts INNER JOIN tblsustockvarkhedi ON tblsuproducts.intId = tblsustockvarkhedi.intProductId INNER JOIN tblsustockjalgaon ON tblsuproducts.intId = tblsustockjalgaon.intProductId";//   WHERE tblsuproducts.nvarProductType='Unbreakables'
        MySql.Data.MySqlClient.MySqlDataAdapter sda = new MySql.Data.MySqlClient.MySqlDataAdapter(queryStr, dbc.con);
        sda.Fill(dt);
        grdStock.DataSource = dt;
        grdStock.DataBind();
        dbc.con.Close();
    }
    protected void btnJalgaonExport_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "StockReport.xls"));
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        grdStock.AllowPaging = false;
        //Change the Header Row back to white color
        // grdReport.HeaderRow.Style.Add("background-color", "#FFFFFF");
        //Applying stlye to gridview header cells


        grdStock.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    protected void grdStockManuf_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header) // If header created
        {
            GridView ProductGrid = (GridView)sender;

            // Creating a Row
            GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            //Adding Year Column
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "Product Name";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.RowSpan = 2; // For merging first, second row cells to one
            HeaderCell.CssClass = "HeaderStyle";
            HeaderRow.Cells.Add(HeaderCell);

            //Adding Period Column
            HeaderCell = new TableCell();
            HeaderCell.Text = "Packing";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.RowSpan = 2;
            HeaderCell.CssClass = "HeaderStyle";
            HeaderRow.Cells.Add(HeaderCell);

            //Adding Audited By Column
            HeaderCell = new TableCell();
            HeaderCell.Text = "Weight";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.RowSpan = 2;
            HeaderCell.CssClass = "HeaderStyle";
            HeaderRow.Cells.Add(HeaderCell);

            //Adding Revenue Column
            HeaderCell = new TableCell();
            HeaderCell.Text = "Varkhedi";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 3; // For merging three columns (Direct, Referral, Total)
            HeaderCell.CssClass = "HeaderStyle";
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Jalgaon";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 3; // For merging three columns (Direct, Referral, Total)
            HeaderCell.CssClass = "HeaderStyle";
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Total";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 4; // For merging three columns (Direct, Referral, Total)
            HeaderCell.CssClass = "HeaderStyle";
            HeaderRow.Cells.Add(HeaderCell);


            //Adding the Row at the 0th position (first row) in the Grid
            ProductGrid.Controls[0].Controls.AddAt(0, HeaderRow);
        }
    }

    protected void grdStockManuf_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Invisibling the first three columns of second row header (normally created on binding)
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Visible = false; // Invisibiling Year Header Cell
            e.Row.Cells[1].Visible = false; // Invisibiling Period Header Cell
            e.Row.Cells[2].Visible = false; // Invisibiling Audited By Header Cell
        }

    }

}