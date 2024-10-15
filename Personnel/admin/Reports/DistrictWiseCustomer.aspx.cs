using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.Collections;

public partial class Personnel_admin_Reports_DistrictWiseCustomer : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    DateTime datef, datet;
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
            //SqlDataSource2.SelectCommand = "SELECT distinct CONCAT(nvarProductName,' ',nvarProductSubType ,' ', intSize,' ', varUnit) as ProductName FROM sanghaviunbreakables.tblsuproducts where nvarStatus!='-'";
            notifications();
           getdataInGroupView();
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

        MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(connStr);//"SELECT distinct concat(varCity,'_',varCompanyName) as  varCity FROM sanghaviunbreakables.tblsucustomer where varCity like '%" + prefixText + "%' AND intId between 1 and 500", con);
        con.Open();
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varCity,'_',varState) AS varCity  FROM sanghaviunbreakables.tblsucustomer where varCity like '%" + prefixText + "%' AND intId between 1 and 500", con);
        //     cmd.Parameters.AddWithValue("@Name", prefixText);
        MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);


        MySql.Data.MySqlClient.MySqlConnection con1 = new MySql.Data.MySqlClient.MySqlConnection(connStr);
        con1.Open();
        MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varCity,'_',varState) AS varCity FROM sanghaviunbreakables.tblsucustomer where varCity like '%" + prefixText + "%' AND intId between 501 and 1000", con1);
        //     cmd.Parameters.AddWithValue("@Name", prefixText);
        MySql.Data.MySqlClient.MySqlDataAdapter da1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        da1.Fill(dt1);

        List<string> CompanyName = new List<string>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            CompanyName.Add(dt.Rows[i][0].ToString());
            //  CompanyName[j++] =dt.Rows[i][0].ToString();
        }
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            CompanyName.Add(dt1.Rows[i][0].ToString());
            //  CompanyName[j++] =dt.Rows[i][0].ToString();
        }
        con.Close();
        con1.Close();
        return CompanyName;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
              string myStr = txtName.Text;
             string[] ssize = myStr.Split('_');
              dbc.con.Open();
              // MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varEmpName,varDistrict FROM sanghaviunbreakables.tblsuallocatedistrict WHERE varEmpName='" + ssize[0].ToString() + "' ", dbc.con);AND varState='"+ssize[1].ToString()+"'
             //dbc.dr= cmd.ExecuteReader();
              MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT DISTINCT intId,varCompanyName,varCity FROM sanghaviunbreakables.tblsucustomer WHERE varCity='" + ssize[0].ToString() + "' AND  varState='" + ssize[1].ToString() + "' ", dbc.con);
             DataSet ds = new DataSet();
             adp.Fill(ds);
             GroupingView1.DataSource = ds;
             GroupingView1.DataBind();
            
             dbc.con.Close();
        }
        catch (Exception ex)
        {
            dbc.con.Close();
        }
    }

    public void getdataInGroupView()
    {

        try
        {
            dbc.con.Open();//WHERE varCompanyName!='-- Select Company --'
            DataSet ds = new DataSet();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT  intId, varCity,varCompanyName FROM sanghaviunbreakables.tblsucustomer  WHERE varCompanyName!='-- Select Company --'", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            adp.Fill(ds);
            GroupingView1.DataSource = ds;
            GroupingView1.DataBind();
            dbc.con.Close();



        }
        catch (Exception ex)
        {
            dbc.con.Close();
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Personnel/admin/Reports/DistrictWiseCustomer.aspx");
    }
    protected DataTable GetDatafromDatabase()
    {
        DataTable dt = new DataTable();
        string myStr = txtName.Text;
        string[] ssize = myStr.Split('_');

        dbc.con.Open();
        string queryStr = "SELECT DISTINCT intId AS 'Company ID',varCompanyName AS CompanyName,varCity AS District FROM sanghaviunbreakables.tblsucustomer WHERE varCity='" + ssize[0].ToString() + "' AND  varState='" + ssize[1].ToString() + "'  ";
        MySql.Data.MySqlClient.MySqlDataAdapter sda = new MySql.Data.MySqlClient.MySqlDataAdapter(queryStr, dbc.con);
        sda.Fill(dt);

        dbc.con.Close();
        return dt;
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (txtName.Text != "")
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "DistrictWiseCustomer.xls"));
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
        else
        {
            DataTable dt = new DataTable();
            dbc.con.Open();
            string queryStr = "SELECT DISTINCT intId AS 'Sr. No', varCompanyName AS 'Customer',varCity AS 'District',varState AS 'State' FROM sanghaviunbreakables.tblsucustomer WHERE varCompanyName!='-- Select Company --'  ";
            MySql.Data.MySqlClient.MySqlDataAdapter sda = new MySql.Data.MySqlClient.MySqlDataAdapter(queryStr, dbc.con);
            sda.Fill(dt);
            ExportTableData(dt);
            dbc.con.Close();
        }
    }

    // this does all the work to export to excel
    public void ExportTableData(DataTable dtdata)
    {
        string attach = "attachment;filename=DistrictWiseCustomer.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attach);
        Response.ContentType = "application/ms-excel";
        if (dtdata != null)
        {
            foreach (DataColumn dc in dtdata.Columns)
            {
                Response.Write(dc.ColumnName + "\t");
                //sep = ";";
            }
            Response.Write(System.Environment.NewLine);
            foreach (DataRow dr in dtdata.Rows)
            {
                for (int i = 0; i < dtdata.Columns.Count; i++)
                {
                    Response.Write(dr[i].ToString() + "\t");
                }
                Response.Write("\n");
            }
            Response.End();
        }
    }


   public  void ShowingGroupingDataInGridView(GridViewRowCollection gridViewRows, int startIndex, int totalColumns)
    {
        if (totalColumns == 0) return;
        int i, count = 1;
        ArrayList lst = new ArrayList();
        lst.Add(gridViewRows[0]);
        var ctrl = gridViewRows[0].Cells[startIndex];
        for (i = 1; i < gridViewRows.Count; i++)
        {
            TableCell nextTbCell = gridViewRows[i].Cells[startIndex];
            if (ctrl.Text == nextTbCell.Text)
            {
                count++;
                nextTbCell.Visible = false;
                lst.Add(gridViewRows[i]);
            }
            else
            {
                if (count > 1)
                {
                    ctrl.RowSpan = count;
                    ShowingGroupingDataInGridView(new GridViewRowCollection(lst), startIndex + 1, totalColumns - 1);
                }
                count = 1;
                lst.Clear();
                ctrl = gridViewRows[i].Cells[startIndex];
                lst.Add(gridViewRows[i]);
            }
        }
        if (count > 1)
        {
            ctrl.RowSpan = count;
            ShowingGroupingDataInGridView(new GridViewRowCollection(lst), startIndex + 1, totalColumns - 1);
        }
        count = 1;
        lst.Clear();
    }   

    //protected void GridView1_DataBound(object sender, EventArgs e)
    //     {
    //        // ShowingGroupingDataInGridView(GridView1.Rows, 0, 5);
    //         for (int i = GridView1.Rows.Count - 1; i > 0; i--)
    //         {
    //             GridViewRow row = GridView1.Rows[i];
    //             GridViewRow previousRow = GridView1.Rows[i - 1];
    //             for (int j = 0; j < row.Cells.Count; j++)
    //             {
    //                 if (row.Cells[j].Text == previousRow.Cells[j].Text)
    //                 {
    //                     if (previousRow.Cells[j].RowSpan == 0)
    //                     {
    //                         if (row.Cells[j].RowSpan == 0)
    //                         {
    //                             previousRow.Cells[j].RowSpan += 2;
    //                         }
    //                         else
    //                         {
    //                             previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
    //                         }
    //                         row.Cells[j].Visible = false;
    //                     }
    //                 }
    //             }
    //         }
    
    //}
   protected void GVRowDB(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
   {
       if (e.Row.RowType == DataControlRowType.DataRow)
       {
           Label titleLabel = (Label)e.Row.FindControl("lblTitle");
           string strval = ((Label)(titleLabel)).Text;
           string title = (string)ViewState["title"];
           if (title == strval)
           {
               titleLabel.Visible = false;
               titleLabel.Text = string.Empty;
           }
           else
           {
               title = strval;
               ViewState["title"] = title;
               titleLabel.Visible = true;
               titleLabel.Text = "<br><b>" + title + "</b><br>";
           }
       }
   }
    
}