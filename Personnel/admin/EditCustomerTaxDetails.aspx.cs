using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Personnel_admin_EditCustomerTaxDetails : System.Web.UI.Page
{
    static int custid = 0;
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
            getCustomerdata();
            bindDataToGridView();
            notifications();
        }
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["adminid"].ToString()), "Admin").ToString();
    }
    public void getCustomerdata()
    {
        try
        {
            dbc.con.Close();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varTaxable, varTaxType, varCSTnumber, varTaxGroup, varTaxDiscount, varCrBills, varCrLimit, varCrdays FROM sanghaviunbreakables.tblsucustomertaxdetails WHERE intCompanyId=" + Session["custbyadmin"].ToString() + " ", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                //lblCustName.Text = dbc.dr["varCompanyName"].ToString();
                txtTaxable.Text = dbc.dr["varTaxable"].ToString();
                txtType.Text = dbc.dr["varTaxType"].ToString();
                txtCST.Text = dbc.dr["varCSTnumber"].ToString();
                txtTaxgroup.Text = dbc.dr["varTaxGroup"].ToString();
                txtTaxDiscount.Text = dbc.dr["varTaxDiscount"].ToString();
                txtCrBills.Text = dbc.dr["varCrBills"].ToString();
                txtCrLimit.Text = dbc.dr["varCrLimit"].ToString();
                txtCrDays.Text = dbc.dr["varCrdays"].ToString();
                dbc.con.Close();
                dbc.dr.Close();
            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
        }
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
    DatabaseConnection dbc = new DatabaseConnection();

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
    public void clear()
    {

        txtTaxable.Text = "";
        txtType.Text = "";
        txtTaxgroup.Text = "";
        txtCST.Text = "";
        txtTaxDiscount.Text = "";
        txtCrBills.Text = "";
        txtCrLimit.Text = "";
        txtCrDays.Text = "";

    }
    public void bindDataToGridView()
    {
        DataSet ds = new DataSet();
        dbc.con.Close();
        dbc.con.Open();
        MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT intId, varTaxable, varTaxType, varCSTnumber, varTaxGroup,varTaxDiscount FROM tblsucustomertaxdetails WHERE intCompanyId=" + Session["custbyadmin"].ToString() + " ", dbc.con);
        adp.Fill(ds);
        dbc.con.Close();
        grdCustomerTaxDetails.DataSource = ds;
        grdCustomerTaxDetails.DataBind();
        

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int update_ok = dbc.update_tblsucustomertaxdetails(Convert.ToInt32 (Session["custbyadmin"].ToString()),txtTaxable.Text, txtType.Text, txtTaxgroup.Text, txtCST.Text, txtTaxDiscount.Text, txtCrBills.Text, txtCrLimit.Text, txtCrDays.Text);
           if(update_ok==1)
           {

            ScriptManager.RegisterStartupScript(
                     this,
                     this.GetType(),
                     "MessageBox",
                     "alert('Data Updated');", true);
            Response.Redirect("EditCustomerTaxDetails.aspx");
          //  clear();
           }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                    this,
                    this.GetType(),
                    "MessageBox",
                    "alert('Data Not Updated! Try Again');", true);
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {

                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT  intCompanyId FROM tblsucustomertaxdetails WHERE intCompanyId=" + Session["custbyadmin"].ToString() + " ", dbc.con);

                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    custid = Convert.ToInt32(dbc.dr["intCompanyId"].ToString());
                }
                if (dbc.check_already_CustomerTaxDetails(custid) != 1)
                {
                    int insert_ok = dbc.insert_tblsucustomertaxdetails(Convert.ToInt32(Session["custbyadmin"].ToString()), lblCustName.Text, txtTaxable.Text, txtType.Text, txtTaxgroup.Text, txtCST.Text, txtTaxDiscount.Text, txtCrBills.Text, txtCrLimit.Text, txtCrDays.Text);
                    ScriptManager.RegisterStartupScript(
                             this,
                             this.GetType(),
                             "MessageBox",
                             "alert('Data Inserted');", true);
                    clear();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(
                       this,
                       this.GetType(),
                       "MessageBox",
                       "alert('Customer Details Already added! For Update Click On Update button');", true);
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
                    "alert('Some Problem occur! Try Again');", true);
            clear();
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditTransactionDetails.aspx");
    }
    protected void grdCustomerTaxDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "removes")
            {
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("DELETE from tblsucustomertaxdetails WHERE intId = " + Convert.ToInt32(e.CommandArgument) + "", dbc.con);
                cmd.ExecuteNonQuery();
                dbc.con.Close();
                Response.Write("<script>alert('Data Deleted');window.location='EditTransactionDetails.aspx';</script>");
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}