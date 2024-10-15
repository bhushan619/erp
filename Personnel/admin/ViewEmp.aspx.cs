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

public partial class Personnel_admin_ViewEmp : System.Web.UI.Page
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
        else  if (!IsPostBack)
        {
            getAdmindata();
            getImage();
            //getEmp();
            SqlDataSource2.SelectCommand = "SELECT varName, varMobile, varEmail, varAddress, varCity,varSubDesig,intId FROM sanghaviunbreakables.tblsupersonnel where varDesignation='employee' and varStatus!='-' ORDER BY intId";
            listemp.DataBind();
            notifications();
        }
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["adminid"].ToString()), "Admin").ToString();
    }

    DatabaseConnection dbc = new DatabaseConnection();
    public void BindListView()
    {
        SqlDataSource2.SelectCommand = "SELECT varName, varMobile, varEmail, varAddress, varCity,varSubDesig,intId FROM sanghaviunbreakables.tblsupersonnel where varDesignation='employee' and varStatus!='-' ORDER BY intId";
        listemp.DataBind();
    }
    protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (listemp.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        this.BindListView();
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
   
    //private void getEmp()
    //{//" + Session["adminid"].ToString() + "
    //    try
    //    {
    //        dbc.con.Open();
    //        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varName, varMobile, varEmail, varAddress, varCity,varSubDesig,intId FROM sanghaviunbreakables.tblsupersonnel where varDesignation='employee' ORDER BY intId", dbc.con);
    //        MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
    //        ad.Fill(dt);
    //        listemp.DataSource = dt;
    //        listemp.DataBind();
    //        dbc.con.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message);
    //    }
    //}

    protected void lnkLogout_Click(object sender, EventArgs e)
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

   
    protected void listproduct_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
       

        string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
        string id = commandArgs[0];
      
        if (e.CommandName == "Edits")
        {
            Session.Add("empbyadmin", id);
            Response.Redirect("EditEmp.aspx");
        }
      
        else if (e.CommandName == "Deletes")
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from sanghaviunbreakables.tblsupersonnel WHERE intId=" + id + "", dbc.con);
            cmd.ExecuteReader();
            dbc.con.Close();
            cmd.Dispose();

            dbc.con.Open();
            cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblsuorder SET intEmpId = 4 WHERE tblsuorder.intEmpId  = " + id + "", dbc.con);
            cmd.ExecuteReader();
            dbc.con.Close();
        }
        SqlDataSource2.SelectCommand = "SELECT varName, varMobile, varEmail, varAddress, varCity,varSubDesig,intId FROM sanghaviunbreakables.tblsupersonnel where varDesignation='employee' and varStatus!='-' ORDER BY intId";
        listemp.DataBind(); 
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static List<string> GetCompletionList(string prefixText, int count, string contextKey)
    {
        String connStr = System.Configuration.ConfigurationManager.ConnectionStrings["sanghaviConnectionString"].ConnectionString;

        MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(connStr);
        con.Open();
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT Distinct varName FROM sanghaviunbreakables.tblsupersonnel where varDesignation='employee' and varName like '%" + prefixText + "%'", con);
        //     cmd.Parameters.AddWithValue("@Name", prefixText);
        MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        int j = 0;
        List<string> CompanyName = new List<string>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            CompanyName.Add(dt.Rows[i][0].ToString());
            //  CompanyName[j++] =dt.Rows[i][0].ToString();
        }
        con.Close();
        return CompanyName;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            //dbc.con.Open();
            //MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varName, varMobile, varEmail, varAddress, varCity,varSubDesig, intId FROM sanghaviunbreakables.tblsupersonnel where varDesignation='employee' and varName like '%" + txtCmpName.Text + "%'", dbc.con);
            //MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            //ad.Fill(dt);
            //listemp.DataSource = dt;
            //listemp.DataBind();
            //dbc.con.Close();

            SqlDataSource2.SelectCommand = "SELECT varName, varMobile, varEmail, varAddress, varCity,varSubDesig, intId FROM sanghaviunbreakables.tblsupersonnel where varDesignation='employee' and varStatus!='-' and varName like '%" + txtCmpName.Text + "%'";
             listemp.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}