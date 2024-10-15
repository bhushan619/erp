using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Collections.Generic;
using System.IO;

public partial class Personnel_admin_ViewCustomer : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../SignUpLogin.aspx';</script>");
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        else if (!IsPostBack)
        {
            getAdmindata();
            getImage();
            //   getCustomerList();
            BindListView();
            notifications();
        }
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["adminid"].ToString()), "Admin").ToString();
    }
    public void BindListView()
    {
        SqlDataSource2.SelectCommand = "SELECT varCompanyName, varRepresentativeName, varMobile, varEmail, varCity,varStatus,intId FROM sanghaviunbreakables.tblsucustomer where varStatus!='-' ORDER BY intId";
        if (Session["pageno"] != null) /// set datapager to page 2
        {
            int pages = Convert.ToInt32(Session["pageno"]);
            DataPager1.SetPageProperties(pages * DataPager1.PageSize, DataPager1.MaximumRows, false);
        }
    }
    protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        int pages = e.StartRowIndex / e.MaximumRows;
        Session.Add("pageno", pages);
        this.BindListView();
    }
    DatabaseConnection dbc = new DatabaseConnection();

    public void getAdmindata()
    {
        try
        {

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varName FROM sanghaviunbreakables.tblsupersonnel where intId=" + Session["adminid"].ToString() + " and varStatus!='-'", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblCustName.Text = dbc.dr["varName"].ToString();
            }
            dbc.con.Close();
            dbc.dr.Close();
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



    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Session["adminid"] = "";
        Session.Remove("adminid");
        Session["pageno"] = "";
        Session.Remove("pageno");
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();

        Response.Redirect("~/Default.aspx");
    }


    protected void listproduct_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
        string id = commandArgs[0];
        string stat = commandArgs[1];

        if (e.CommandName == "Edits")
        {
            Session.Add("custbyadmin", id);
            //Session["pageno"] = e.MaximumRows;

            Response.Redirect("EditCustomer.aspx");
        }
        else if (e.CommandName == "Updates")
        {
            if (stat == "Whitelist")
            {
                dbc.Update_CustomerStatus(Convert.ToInt32(id), "Blacklist");

            }
            else
            {
                dbc.Update_CustomerStatus(Convert.ToInt32(id), "Whitelist");
            }
        }
        else if (e.CommandName == "Deletes")
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from sanghaviunbreakables.tblsucustomer WHERE intId=" + id + "", dbc.con);
            cmd.ExecuteReader();
            dbc.con.Close();
        }
        SqlDataSource2.SelectCommand = "SELECT varCompanyName, varRepresentativeName, varMobile, varEmail, varCity,varStatus,intId FROM sanghaviunbreakables.tblsucustomer  where varStatus!='-' ORDER BY intId";
        listcust.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtCmpName.Text == "")
            {
                Response.Write("<script>alert('Please select company Name');window.location='ViewCustomer.aspx';</script>");
            }
            else
            {
                string[] arry = txtCmpName.Text.Split(new char[] { '_' });

                SqlDataSource2.SelectCommand = "SELECT varCompanyName, varRepresentativeName, varMobile, varEmail, varCity,varStatus,intId FROM sanghaviunbreakables.tblsucustomer where varCompanyName='" + arry[0] + "' and varCity='" + arry[1] + "' and varStatus!='-'";

                listcust.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static List<string> GetCompletionList(string prefixText, int count, string contextKey)
    {
        String connStr = System.Configuration.ConfigurationManager.ConnectionStrings["sanghaviConnectionString"].ConnectionString;

        MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(connStr);
        con.Open();
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varCompanyName,'_',varCity) as  varCompanyName FROM sanghaviunbreakables.tblsucustomer where varCompanyName like '%" + prefixText + "%' AND intId between 1 and 500", con);
        //     cmd.Parameters.AddWithValue("@Name", prefixText);
        MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        

        MySql.Data.MySqlClient.MySqlConnection con1 = new MySql.Data.MySqlClient.MySqlConnection(connStr);
        con1.Open();
        MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varCompanyName,'_',varCity) as  varCompanyName FROM sanghaviunbreakables.tblsucustomer where varCompanyName like '%" + prefixText + "%' AND intId between 501 and 1000", con1);
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

    protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSort.Text == "- Sort By-")
        {
            Response.Write("<script>alert('Please Select a list');window.location='ViewCustomer.aspx';</script>");
        }
        else if (ddlSort.Text == "Blacklist")
        {
            SqlDataSource2.SelectCommand = "SELECT varCompanyName, varRepresentativeName, varMobile, varEmail, varCity,varStatus,intId FROM sanghaviunbreakables.tblsucustomer where varStatus!='-' ORDER BY varStatus ASC";

            listcust.DataBind();
        }
        else if (ddlSort.Text == "Whitelist")
        {
            SqlDataSource2.SelectCommand = "SELECT varCompanyName, varRepresentativeName, varMobile, varEmail, varCity,varStatus,intId FROM sanghaviunbreakables.tblsucustomer where varStatus!='-' ORDER BY varStatus DESC";

            listcust.DataBind();
        }
    }
}