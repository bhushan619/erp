using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class Personnel_admin_Reports_EditCollection : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    public static string empdesig = string.Empty;
    static int custId = 0;
    static string custstate = string.Empty;
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
            getData();
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

    public void getData()
    {
        dbc.con.Open();
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT  tblsucollection.intId,   tblsucustomer.varCompanyName as Party,  tblsupersonnel.varName As 'Emp Name',     tblsupersonnel.varSubDesig as Designation,   tblsucollection.varDate as Date, tblsucollection.varPaymentMode as'Pay Mode', tblsucollection.varCheckno as 'Check No',      tblsucollection.varCheckDate as 'Check Date', tblsucollection.varAmount as Amount, tblsucollection.varOtherPaymentDetails as 'Other Details' FROM    tblsucollection INNER JOIN         tblsucustomer ON tblsucollection.intCustId = tblsucustomer.intId INNER JOIN     tblsupersonnel ON tblsucollection.intEmpId = tblsupersonnel.intId  WHERE tblsucollection.intId='" + Request.QueryString[0].ToString() + "' order by  CAST(STR_TO_DATE(varDate,'%d-%m-%Y') AS DATE) desc", dbc.con);

        dbc.dr = cmd.ExecuteReader();
        if (dbc.dr.Read())
        {
            txtintId.Text = dbc.dr["intId"].ToString();
            txtDate.Text = dbc.dr["Date"].ToString();
            txtCustomerName.Text = dbc.dr["Party"].ToString();
            txtCustomerName.Enabled = false;
            ddlPayMode.SelectedValue = dbc.dr["Pay Mode"].ToString();
            txtCheckNo.Text = dbc.dr["Check No"].ToString();
            txtCheckDate.Text = dbc.dr["Check Date"].ToString();
            txtAmount.Text = dbc.dr["Amount"].ToString();
            txtOtherDetails.Text = dbc.dr["Other Details"].ToString();

        }
        dbc.con.Close();
        btnEditUpdate.Visible = true;
       
    }
    protected void txtCustomerName_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string[] arry = txtCustomerName.Text.Split(new char[] { '_' });

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varRepresentativeName, varMobile,varState FROM sanghaviunbreakables.tblsucustomer where varCompanyName='" + arry[0] + "' and varCity='" + arry[1] + "'", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblRepresentativeName.Text = dbc.dr["varRepresentativeName"].ToString();
                lblMob.Text = dbc.dr["varMobile"].ToString();
                custstate = dbc.dr["varState"].ToString();
                custId = Convert.ToInt32(dbc.dr["intId"].ToString());
                dbc.con.Close();
                dbc.dr.Close();
            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
        }
    }

    protected void btnEditUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            dbc.con.Close();
            dbc.con.Open();
            dbc.cmd = new MySqlCommand("UPDATE tblsucollection SET  varDate='" + txtDate.Text + "',varPaymentMode='" + ddlPayMode.SelectedValue + "',varCheckno='" + txtCheckNo.Text + "',varCheckDate='" + txtCheckDate.Text + "',varAmount='" + txtAmount.Text + "',varOtherPaymentDetails='" + txtOtherDetails.Text + "'  WHERE intId=" + txtintId.Text + "", dbc.con);
            dbc.cmd.ExecuteNonQuery();
            dbc.con.Close();

            Response.Write("<script>alert('Collection Entry Updated Successfully');window.location='Collection.aspx';</script>");
           

        }
        catch (Exception ecc)
        {
            Response.Write("<script>alert('" + ecc.Message + "');window.location='Collection.aspx';</script>");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Personnel/admin/Reports/Collection.aspx", false);
    }
}