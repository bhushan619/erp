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

public partial class Personnel_employee_subadmin_ViewConsignments : System.Web.UI.Page
{
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlSearchBy.Text == "-- Search By --")
            {
                ScriptManager.RegisterStartupScript(
               this,
               this.GetType(),
               "MessageBox",
               "alert('Please select Search by');", true);
            }
            else if (ddlSearchBy.Text == "Company Name")
            {
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varRepresentativeName, varMobile,varState FROM sanghaviunbreakables.tblsucustomer where varCompanyName='" + txtCmpName.Text + "'", dbc.con);

                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    int custId = Convert.ToInt32(dbc.dr["intId"].ToString());
                    dbc.con.Close();
                    dbc.dr.Close();
                    SqlDataSource2.SelectCommand = "SELECT distinct tblsuconsignment.intConsigmentNo AS `ConsNo`, tblsucustomer.varCompanyName AS Customer, tblsuconsignment.intOrderId AS OrderNo, tblsuconsignment.dtDate AS `Date`, tblsuconsignment.varStatus AS Status FROM tblsucustomer, tblsuorder, tblsuconsignment WHERE tblsucustomer.intId = tblsuorder.intCustId AND tblsuconsignment.intOrderId = tblsuorder.intOrderId AND tblsuconsignment.varStatus ='In Transit' AND tblsucustomer.intId=" + custId + "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(
                    this,
                    this.GetType(),
                    "MessageBox",
                    "alert('No Record found');", true);
                }
            }
            else if (ddlSearchBy.Text == "Consignment Number")
            {
                SqlDataSource2.SelectCommand = "SELECT distinct tblsuconsignment.intConsigmentNo AS `ConsNo`, tblsucustomer.varCompanyName AS Customer,tblsuconsignment.intOrderId AS OrderNo, tblsuconsignment.dtDate AS `Date`, tblsuconsignment.varStatus AS Status, tblsuconsignment.varTransportName as Transport FROM tblsucustomer, tblsuorder, tblsuconsignment WHERE tblsucustomer.intId = tblsuorder.intCustId AND tblsuorder.intOrderId = tblsuconsignment.intOrderId AND (tblsuconsignment.intConsigmentNo ='" + txtConsignmentNumber.Text + "')";
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
        }

    }
    protected void listorder_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            Session.Add("consno", e.CommandArgument);

            Response.Redirect("ViewUpdateConsignment.aspx");
        }
        else if (e.CommandName == "Updates")
        {
            lblConsignmentNo.Text = e.CommandArgument.ToString();
        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (lblConsignmentNo.Text == "")
        {
            Response.Write("<script>alert('Please Select Consignment Number from Table');</script>");
        }
        else
        {
            int updateok = dbc.Update_ConsignmentStatus(Convert.ToInt32(lblConsignmentNo.Text), txtStatus.Text);
            if (updateok == 1)
            {
                int ok = notification();
                if (ok == 1)
                {
                    Response.Write("<script>alert('Updated Successfully');window.location='ViewConsignment.aspx';</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please try again');window.location='ViewConsignment.aspx';</script>");
            }
        }
    }
    public int notification()
    {
        try
        {
            int okn = 0;
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdn = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId FROM tblsupersonnel WHERE varSubDesig='Sub Admin'", dbc.con);

            MySql.Data.MySqlClient.MySqlDataReader drn;
            drn = cmdn.ExecuteReader();
            while (drn.Read())
            {
                okn = dbc.insert_tblsunotifications("Message", Convert.ToInt32(Session["empid"].ToString()), lblCustName.Text, empdesig, Convert.ToInt32(drn["intId"].ToString()), "Sub Admin", "Dispatch updated status of consignment number : " + lblConsignmentNo.Text + " as " + txtStatus.Text + "", "NA", "NA", "Unread", "Emp");
            }
            dbc.con.Close();
            dbc.dr.Close();
            return okn;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
    protected void btnCamcel_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.location='ViewConsignment.aspx';</script>");
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
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtCmpName.Text = "";
        txtConsignmentNumber.Text = "";
        txtCmpName.Visible = false;
        txtConsignmentNumber.Visible = false;
        ddlSearchBy.Text = "-- Search By --";
        SqlDataSource2.SelectCommand = "SELECT distinct tblsuconsignment.intConsigmentNo AS `ConsNo`,tblsuconsignment.intOrderId AS OrderNo, tblsucustomer.varCompanyName AS Customer,  tblsuconsignment.dtDate AS `Date`, tblsuconsignment.varStatus AS Status FROM tblsucustomer, tblsuorder, tblsuconsignment WHERE tblsucustomer.intId = tblsuorder.intCustId AND tblsuconsignment.intOrderId = tblsuorder.intOrderId AND tblsuconsignment.varStatus ='In Transit'";
        SqlDataSource2.DataBind();
    }
    protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSearchBy.Text == "-- Search By --")
        {
            txtCmpName.Visible = false;
            txtConsignmentNumber.Visible = false;
        }
        else if (ddlSearchBy.Text == "Company Name")
        {
            txtCmpName.Visible = true;
            txtConsignmentNumber.Visible = false;
        }
        else if (ddlSearchBy.Text == "Consignment Number")
        {
            txtConsignmentNumber.Visible = true;
            txtCmpName.Visible = false;
        }
    }
}