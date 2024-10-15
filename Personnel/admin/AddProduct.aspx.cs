using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Personnel_admin_AddProduct : System.Web.UI.Page
{
    public static string empdesig = string.Empty;
    DatabaseConnection dbc = new DatabaseConnection();
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
            notifications();
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
        SqlDataSource2.SelectCommand = "SELECT ID,varProductType FROM tblproducttype";
        cmbProType.DataBind();
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Personnel/admin/Default.aspx");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                int contentLength = fupProPic.PostedFile.ContentLength;//You may need it for validation
                string contentType = fupProPic.PostedFile.ContentType;//You may need it for validation
                string fileName = fupProPic.PostedFile.FileName;
                if (contentLength == 0)
                {
                    int insert_ok = dbc.insert_tblProductDetails(txtProductName.Text, cmbProType.Text, cmbProSubType.Text, txtCode.Text, txtSize.Text, Convert.ToInt32(txtPack.Text), Convert.ToInt32(txtDealerPrice.Text), Convert.ToInt32(txtMRP.Text), txtDesc.Text, "NoProfile.png", ddlUnit.Text, txtWeight.Text, Convert.ToInt32(txtMSMPDealer.Text), Convert.ToInt32(txtMSMPPrice.Text), Convert.ToInt32(txtAllStatePrice.Text), Convert.ToInt32(txtAllStateMRP.Text), txtWarningSack.Text, txtWarningNag.Text, txtIndex.Text);
                    if (insert_ok != 0)
                    {
                        int ok = notification(insert_ok);
                        if (ok == 1)
                        {
                            ScriptManager.RegisterStartupScript(
                               this,
                               this.GetType(),
                               "MessageBox",
                               "alert('Data Inserted');", true);
                            Clear();
                        }
                    }
                }
                else
                {

                    int insert_ok = dbc.insert_tblProductDetails(txtProductName.Text, cmbProType.Text, cmbProSubType.Text, txtCode.Text, txtSize.Text, Convert.ToInt32(txtPack.Text), Convert.ToInt32(txtDealerPrice.Text), Convert.ToInt32(txtMRP.Text), txtDesc.Text, fileName, ddlUnit.Text, txtWeight.Text, Convert.ToInt32(txtMSMPDealer.Text), Convert.ToInt32(txtMSMPPrice.Text), Convert.ToInt32(txtAllStatePrice.Text), Convert.ToInt32(txtAllStateMRP.Text), txtWarningSack.Text, txtWarningNag.Text,txtIndex.Text);

                    if (insert_ok != 0)
                    {
                        int ok = notification(insert_ok);
                        if (ok == 1)
                        {

                            fupProPic.PostedFile.SaveAs(Server.MapPath("~/Personnel/admin/media/product/") + fileName);//Or code to save in the DataBase.
                            ScriptManager.RegisterStartupScript(
                               this,
                               this.GetType(),
                               "MessageBox",
                               "alert('Data Inserted');", true);
                            Clear();
                        }
                    }
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


   


    public int notification(int productId)
    {
        try
        {
            int okn = 0;
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdn = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId FROM tblsucustomer", dbc.con);

            MySql.Data.MySqlClient.MySqlDataReader drn;
            drn = cmdn.ExecuteReader();
            while (drn.Read())
            {
                okn = dbc.insert_tblsunotifications("Session", Convert.ToInt32(Session["adminid"].ToString()), lblCustName.Text, "Admin", Convert.ToInt32(drn["intId"].ToString()), "Customer", "New Product Added of Name: " + txtProductName.Text + "","~/Personnel/customer/ViewFullProduct.aspx" , productId.ToString(), "Unread", "Product");
            }
            dbc.con.Close();
            drn.Close();

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdn1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varSubDesig FROM tblsupersonnel where varSubDesig = 'Marketing Executive' OR  varSubDesig = 'Marketing Head'", dbc.con);

            MySql.Data.MySqlClient.MySqlDataReader drn1;
            drn1 = cmdn1.ExecuteReader();
            while (drn1.Read())
            {
                okn = dbc.insert_tblsunotifications("Session", Convert.ToInt32(Session["adminid"].ToString()), lblCustName.Text, "Admin", Convert.ToInt32(drn1["intId"].ToString()), drn1["varSubDesig"].ToString(), "New Product Added of Name:  " + txtProductName.Text + "","~/Personnel/employee/marketing/ViewFullProduct.aspx", productId.ToString() , "Unread", "Order");
            }
            dbc.con.Close();
            drn1.Close();

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdn2 = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varSubDesig FROM tblsupersonnel where varSubDesig != 'Marketing Executive' AND  varSubDesig != 'Marketing Head'", dbc.con);

            MySql.Data.MySqlClient.MySqlDataReader drn2;
            drn2 = cmdn2.ExecuteReader();
            while (drn2.Read())
            {
                okn = dbc.insert_tblsunotifications("Message", Convert.ToInt32(Session["adminid"].ToString()), lblCustName.Text, "Admin", Convert.ToInt32(drn2["intId"].ToString()), drn2["varSubDesig"].ToString(), "New Product Added of Name:  " + txtProductName.Text + "", "", "", "Unread", "Order");
            }
            dbc.con.Close();
            drn2.Close();
            return okn;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
    public void Clear()
    {
        txtProductName.Text = "";
        cmbProType.SelectedItem.Text = "--Select Type--";
        cmbProSubType.SelectedItem.Text = "--Select SubType--";
        txtDealerPrice.Text = "";
        txtDesc.Text = "";
        txtMRP.Text = "";
        txtPack.Text = "";
        txtSize.Text = "";
        txtCode.Text = "";
        txtAllStateMRP.Text = "";
        txtAllStatePrice.Text = "";
        txtMSMPDealer.Text = "";
        txtMSMPPrice.Text = "";
        txtWarningNag.Text = "";
        txtWarningSack.Text = "";
        txtWeight.Text = "";
    }
    protected void cmbProType_SelectedIndexChanged(object sender, EventArgs e)
    {
        cmbProSubType.Items.Clear();
        cmbProSubType.Items.Add("-- Select SubType --");
        SqlDataSourceSubtype.SelectCommand = "SELECT ID, varProductType, varProductSubType FROM tblproductsubtype where varProductType='" + cmbProType.SelectedValue + "' ";
        cmbProSubType.DataBind();

    }


    
}