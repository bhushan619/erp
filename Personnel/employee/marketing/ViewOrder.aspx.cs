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

public partial class Personnel_employee_ViewOrder : System.Web.UI.Page
{
    static string empdesig = string.Empty;
    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();
    static int packing = 0, orderrow = 1, custId = 0, prices = 0;
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
            SqlDataSource2.SelectCommand = "SELECT intOrderId,(SELECT varCompanyName from tblsucustomer WHERE intId = intCustId)  as comname,(SELECT varMobile from sanghaviunbreakables.tblsucustomer WHERE (intId = intCustId) ) as mobile, intCustId,varStatus, dtDate, varProductTotal, varTotalNag, varPriceTotal, intId FROM tblsuorder order by CAST(STR_TO_DATE(dtDate, '%d-%m-%Y') AS DATE)";
            listorder.DataBind();
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
    protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (listorder.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        if (txtCmpName.Text == "")
        {
            SqlDataSource2.SelectCommand = "SELECT intOrderId,(SELECT varCompanyName from tblsucustomer WHERE intId = intCustId)  as comname,(SELECT varMobile from sanghaviunbreakables.tblsucustomer WHERE (intId = intCustId) ) as mobile, intCustId,varStatus, dtDate, varProductTotal, varTotalNag, varPriceTotal, intId FROM tblsuorder    order by CAST(STR_TO_DATE(dtDate, '%d-%m-%Y') AS DATE)";
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
        try
        {
            string[] arry = txtCmpName.Text.Split(new char[] { '_' });
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varRepresentativeName, varMobile,varState FROM sanghaviunbreakables.tblsucustomer where varCompanyName='" + arry[0] + "' and varCity='" + arry[1] + "'", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                custId = Convert.ToInt32(dbc.dr["intId"].ToString());
                dbc.con.Close();
                dbc.dr.Close();
            }
            SqlDataSource2.SelectCommand = "SELECT intOrderId,(SELECT varCompanyName from tblsucustomer WHERE intId= " + custId + ")  as comname, (SELECT varMobile from sanghaviunbreakables.tblsucustomer WHERE (intId = " + custId + ") ) as mobile,intCustId,varStatus, dtDate, varProductTotal, varTotalNag, varPriceTotal, intId FROM tblsuorder where intCustId=" + custId + "";
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
        }
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

        else if (e.CommandName == "ViewBill")
        {
            int billno = dbc.get_OrderStatusBill(Convert.ToInt64(orderid));

            if (billno != 0)
            {
                Session.Add("billno", billno);
                Session.Add("orderid", orderid);
                Response.Redirect("ViewOrderBill.aspx");
            }
            else
            {
                Response.Write("<script>alert('Bill Not Generated. Please Try Again Later');window.location='ViewOrder.aspx';</script>");
            }

        }
    }
}