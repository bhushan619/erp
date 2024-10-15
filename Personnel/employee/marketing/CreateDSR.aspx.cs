using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.IO;
public partial class Personnel_employee_marketing_CreateDSR : System.Web.UI.Page
{
    public static string empdesig = string.Empty;
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
            SqlDataSourceDSR.SelectCommand = "SELECT intId, varEmpName, varDate, varLocation, varCallType, varCustName, varRepersentName, varLandline, varMobile, varRemark, varNextDate FROM tblsudsrdetails WHERE (intEmpId = @EmpId) order by CAST(STR_TO_DATE(varDate,'%d-%m-%Y') AS DATE)";
            grdDSR.DataBind();
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
    protected void txtCustomerName_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtContactPerson.Text = "";
            txtMobile.Text = "";
            string[] arry = txtCustomerName.Text.Split(new char[] { '_' });

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varRepresentativeName, varMobile,varState FROM sanghaviunbreakables.tblsucustomer where varCompanyName='" + arry[0] + "' and varCity='" + arry[1] + "'", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                txtContactPerson.Text = dbc.dr["varRepresentativeName"].ToString();
                txtMobile.Text = dbc.dr["varMobile"].ToString(); 
                dbc.con.Close();
                dbc.dr.Close();
            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
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
    public void getImage()
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

    public void clear()
    {
        txtDate.Text = "";
        txtContactPerson.Text = "";
        txtCustomerName.Text = "";
        txtLandLine.Text = "";
        txtLocation.Text = "";
        txtMobile.Text = "";
        txtNextCall.Text = "";
        txtRemark.Text = "";
        txtTime.Text = "";
        
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        try
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                int insert_ok = dbc.insert_tblDSRDetails(Convert.ToInt32(Session["empid"].ToString()), lblCustName.Text, txtDate.Text, txtTime.Text, txtLocation.Text, call(), txtCustomerName.Text, txtContactPerson.Text, txtLandLine.Text, txtMobile.Text, txtRemark.Text, txtNextCall.Text, "NA");
                if (insert_ok == 1)
                {
                    ScriptManager.RegisterStartupScript(
                       this,
                       this.GetType(),
                       "MessageBox",
                       "alert('Data Inserted');", true);
                    clear();
                }

            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('Data Not Updated');", true);

        }
    }
    public string call()
    {
        if (rdbFollowUp.Checked == true)
        {
            return "Follow Up Call";
        }
        else if (rdbNewCall.Checked == true)
        {
            return "New Call";
        }
        else
        {
            return "Visit";
        }
    }

    protected void btnview_Click(object sender, EventArgs e)
    {
        getdsrdata();
    }

    public void getdsrdata()
    {
        string temp = string.Empty, where = string.Empty;
        if (txtFromDate.Text == "")
        {
            Response.Write("<script>alert('Please Select from date');</script>");
        }
        else if (txtToDate.Text == "")
        {
            Response.Write("<script>alert('Please Select to date');</script>");
        }
        else if (txtCmpName.Text != "-- Select Customer --")
        {
            SqlDataSourceDSR.SelectCommand = "SELECT intId, varEmpName, varDate, varLocation, varCallType, varCustName, varRepersentName, varLandline, varMobile, varRemark, varNextDate FROM tblsudsrdetails WHERE (intEmpId =" + Session["empid"].ToString() + ")  AND (varCustName = '" + txtCmpName.Text + "') and CAST(STR_TO_DATE(varDate,'%d-%m-%Y') AS DATE) BETWEEN CAST(STR_TO_DATE('" + txtFromDate.Text + "','%d-%m-%Y') AS DATE) and CAST(STR_TO_DATE('" + txtToDate.Text + "','%d-%m-%Y') AS DATE)";
            grdDSR.DataBind();
        }
        else
        {
            Response.Write("<script>alert('Please Select Customer Name');</script>");
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            getdsrdata();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "DSR.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grdDSR.AllowPaging = false;
            //Change the Header Row back to white color
            // grdReport.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //Applying stlye to gridview header cells


            grdDSR.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Pls Try Again...');window.location='CreateDSR.aspx';</script>");
        }
    }
}