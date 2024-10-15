using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class Personnel_employee_subadmin_DispatchExpenseSheet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../../SignUpLogin.aspx';</script>");
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        if (!IsPostBack)
        {

            getImage();
            getempname();
            notifications();
            get_DispatchExpenseSheet_data();
        }
    }
    static string empdesig = string.Empty;
    DatabaseConnection dbc = new DatabaseConnection();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
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
            Response.Redirect("~/SignUpLogin.aspx");
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
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static List<string> GetCompletionListNode(string prefixText, int count, string contextKey)
    {

        List<string> CompanyName = new List<string>();


        CompanyName.Add("Auto");
        CompanyName.Add("Lorry");
       
        CompanyName.Add("Goods Return");



        return CompanyName;
    }
    public void get_DispatchExpenseSheet_data()
    {

        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varNo as No, varDate as Date, varInvoiceNo AS 'Invoice No' , varLRNo as LRNo, varTransporter as Transport, varParty as Party, varSack as Sack, varHamali as Hamali, varTotal as Total FROM tblsudispatchexpensesheet   order by CAST(STR_TO_DATE(varDate,'%d-%m-%Y') AS DATE) desc", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad2 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd2);

            ad2.Fill(dt3);

            grdRaw.DataSource = dt3;
            grdRaw.DataBind();
            dbc.con.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void lnkSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                int insert_order_ok = dbc.insert_DispatchExpenseSheet(Convert.ToInt32(Session["empid"].ToString()), txtNo.Text, txtDate.Text, txtInvoiceNo.Text, txtLRNo.Text, txtTransport.Text, txtParty.Text, txtSack.Text, txtAuto.Text, txtLorry.Text, txtGoodsReturn.Text, txtHamali.Text, txtTotal.Text, txtRemark.Text);
                if (insert_order_ok == 1)
                {
                    Response.Write("<script>alert('Dispatch Expense Sheet Added Successfully....');window.location='DispatchExpenseSheet.aspx';</script>");
                    clear();
                }
                else
                {
                    Response.Write("<script>alert('Please Try Again');</script>");
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
        }
    }
    public void clear()
    {
        txtDate.Text = "";
        txtHamali.Text = "";
        txtInvoiceNo.Text = "";
        txtLRNo.Text = "";
        txtDate.Text = "";
        txtNo.Text = "";
        txtParty.Text = "";
        txtSack.Text = "";
        txtTotal.Text = "";
        txtTransport.Text = "";
        txtRemark.Text = "";
        txtAuto.Text = "";
        txtLorry.Text = "";
        txtGoodsReturn.Text = "";
    }

    protected void grdRaw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdRaw.PageIndex = e.NewPageIndex;
        get_DispatchExpenseSheet_data();

    }
    protected void grdReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "edits")
            {
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, intEmpid, varNo, varDate, varInvoiceNo, varLRNo, varTransporter, varParty, varSack, varAuto, varLorry, varGoodsReturn, varHamali, varTotal, varRemark, ex1 FROM tblsudispatchexpensesheet WHERE intId='" + e.CommandArgument + "'", dbc.con);

                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    txtintId.Text = dbc.dr["intId"].ToString();
                    txtNo.Text = dbc.dr["varNo"].ToString();
                    txtNo.Enabled = false;
                    txtDate.Text = dbc.dr["varDate"].ToString();
                    txtInvoiceNo.Text = dbc.dr["varInvoiceNo"].ToString();
                    txtLRNo.Text = dbc.dr["varLRNo"].ToString();
                    txtTransport.Text = dbc.dr["varTransporter"].ToString();
                    txtParty.Text = dbc.dr["varParty"].ToString();
                    txtParty.Enabled = false;
                    txtSack.Text = dbc.dr["varSack"].ToString();
                    txtAuto.Text = dbc.dr["varAuto"].ToString();
                    txtLorry.Text = dbc.dr["varLorry"].ToString();
                    txtGoodsReturn.Text = dbc.dr["varGoodsReturn"].ToString();
                    txtHamali.Text = dbc.dr["varHamali"].ToString();
                    txtTotal.Text = dbc.dr["varTotal"].ToString();
                    txtRemark.Text = dbc.dr["varRemark"].ToString();                    
                }
                dbc.con.Close();
                btnEditUpdate.Visible = true;
                lnkSubmit.Visible = false;
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
    protected void btnEditUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            dbc.con.Close();
            dbc.con.Open();
            dbc.cmd = new MySqlCommand("UPDATE tblsudispatchexpensesheet SET  varDate='" + txtDate.Text + "',varInvoiceNo='" + txtInvoiceNo.Text + "',varLRNo='" + txtLRNo.Text + "',varTransporter='" + txtTransport.Text + "',varSack='" + txtSack.Text + "',varAuto='" + txtAuto.Text + "',varLorry='" + txtLorry.Text + "',varGoodsReturn='" + txtGoodsReturn.Text + "',varHamali='" + txtHamali.Text + "',varTotal='" + txtTotal.Text + "',varRemark='" + txtRemark.Text + "'  WHERE intId='" + txtintId.Text + "'", dbc.con);
            dbc.cmd.ExecuteNonQuery();
            dbc.con.Close();

            Response.Write("<script>alert('Expense Note Updated Successfully');window.location='DispatchExpenseSheet.aspx';</script>");
            clear();

        }
        catch (Exception ecc)
        {
            Response.Write("<script>alert('" + ecc.Message + "');window.location='DispatchExpenseSheet.aspx';</script>");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Personnel/employee/subadmin/DispatchExpenseSheet.aspx", false);
    }
}