using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class Personnel_admin_Reports_EditDispatchExpenses : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
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
        Session["empid"] = "";
        Session.Remove("empid");

        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();

        Response.Redirect("~/Default.aspx");
    }

    public void getData()
    {
        dbc.con.Open();
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, intEmpid, varNo, varDate, varInvoiceNo, varLRNo, varTransporter, varParty, varSack, varAuto, varLorry, varGoodsReturn, varHamali, varTotal, varRemark, ex1 FROM tblsudispatchexpensesheet WHERE intId='" + Request.QueryString[0].ToString() + "'", dbc.con);

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
         

        }
        catch (Exception ecc)
        {
            Response.Write("<script>alert('" + ecc.Message + "');window.location='DispatchExpenseSheet.aspx';</script>");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Personnel/admin/Reports/DispatchExpenseSheet.aspx", false);
    }
}