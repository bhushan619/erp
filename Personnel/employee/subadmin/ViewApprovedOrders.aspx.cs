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

public partial class Personnel_employee_CreateBill : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();
    static string empdesig = string.Empty;
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
            SqlDataSource2.SelectCommand = "SELECT intOrderId,ex2,varBookingId,(SELECT varCompanyName from tblsucustomer WHERE intId= intCustId)  as comname,(SELECT varMobile from sanghaviunbreakables.tblsucustomer WHERE (intId = intCustId) ) as mobile, intCustId,varStatus, dtDate, varProductTotal, varTotalNag, varPriceTotal, intId FROM tblsuorder where tblsuorder.varStatus='Approved' order by CAST( STR_TO_DATE( tblsuorder.dtDate,  '%d-%m-%Y' ) AS DATE ) desc";
            listorder.DataBind();
        }
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["empid"].ToString()), empdesig).ToString();
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

    protected void listorder_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        int updateok = 0;
        string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
        string orderid = commandArgs[0];
        string empcustid = commandArgs[1];

        if (e.CommandName == "View")
        {
            Session.Add("orderid", orderid);
            Session.Add("empcustid", empcustid);
            Response.Redirect("ViewOrderFull.aspx");
        }
        else if (e.CommandName == "Bill")
        {
            Session.Add("orderid", orderid);
            Session.Add("empcustid", empcustid);
            Response.Redirect("CreateBill.aspx");
        }
    }
    protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (listorder.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        if (txtCmpName.Text == "")
        {
            SqlDataSource2.SelectCommand = "SELECT intOrderId,ex2,varBookingId,(SELECT varCompanyName from tblsucustomer WHERE intId= intCustId)  as comname,(SELECT varMobile from sanghaviunbreakables.tblsucustomer WHERE (intId = intCustId) ) as mobile, intCustId,varStatus, dtDate, varProductTotal, varTotalNag, varPriceTotal, intId FROM tblsuorder where tblsuorder.varStatus='Approved' order by CAST( STR_TO_DATE( tblsuorder.dtDate,  '%d-%m-%Y' ) AS DATE ) desc";
            listorder.DataBind();
        }
        else
        {
            getData();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        getData();
    }
    public void getData()
    {
        string[] arry = txtCmpName.Text.Split(new char[] { '_' });
        SqlDataSource2.SelectCommand = "SELECT intOrderId,ex2,varBookingId,(SELECT varCompanyName from tblsucustomer WHERE intId= intCustId)  as comname,(SELECT varMobile from sanghaviunbreakables.tblsucustomer WHERE (intId = intCustId) ) as mobile, intCustId,varStatus, dtDate, varProductTotal, varTotalNag, varPriceTotal, intId FROM tblsuorder where tblsuorder.intCustId =(SELECT intId FROM sanghaviunbreakables.tblsucustomer where varCompanyName='" + arry[0] + "' and varCity='" + arry[1] + "' and varStatus!='-') AND tblsuorder.varStatus='Approved' order by CAST( STR_TO_DATE( tblsuorder.dtDate,  '%d-%m-%Y' ) AS DATE ) desc";

    }
}