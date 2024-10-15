using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Personnel_admin_EditProduct : System.Web.UI.Page
{
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
            getProductdata();
            notifications();
        }
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["adminid"].ToString()), "Admin").ToString();
    }
    public void getProductdata()
    {
        SqlDataSource2.SelectCommand = "SELECT ID,varProductType FROM tblproducttype";
        cmbProType.DataBind();
        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intSort,intId, nvarProductName, nvarProductType, nvarProductSubType, tblsuproductcode, intSize, intPacking, intDealerPrice, intMRP, nvarDescription, imgImage, nvarStatus, varUnit, varWeight, intMMSMPDealer, intMSMPMRP, intAllStateDealer, intAllStateMRP FROM sanghaviunbreakables.tblsuproducts where intId=" + Session["productbyadmin"].ToString() + "", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                txtCode.Text = dbc.dr["tblsuproductcode"].ToString();
                txtProductName.Text = dbc.dr["nvarProductName"].ToString();
                txtSize.Text = dbc.dr["intSize"].ToString();
                txtPack.Text = dbc.dr["intPacking"].ToString();
                txtDealerPrice.Text = dbc.dr["intDealerPrice"].ToString();
                txtMRP.Text = dbc.dr["intMRP"].ToString();
                txtDesc.Text = dbc.dr["nvarDescription"].ToString();
                txtMSMPPrice.Text = dbc.dr["intMSMPMRP"].ToString();
                txtMSMPDealer.Text = dbc.dr["intMMSMPDealer"].ToString();
                txtAllStateMRP.Text = dbc.dr["intAllStateMRP"].ToString();
                txtAllStatePrice.Text = dbc.dr["intAllStateDealer"].ToString();
                cmbUnit.Text = dbc.dr["varUnit"].ToString();
                txtWeight.Text = dbc.dr["varWeight"].ToString();
                txtIndex.Text = dbc.dr["intSort"].ToString();
                ImgProduct.ImageUrl = "~/Personnel/admin/media/product/" + dbc.dr["imgImage"].ToString();
                cmbProType.SelectedValue = dbc.dr["nvarProductType"].ToString();
                changeProType(dbc.dr["nvarProductType"].ToString());
                cmbProSubType.SelectedValue = dbc.dr["nvarProductSubType"].ToString(); 
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
                    string myStr = ImgProduct.ImageUrl;
                    string[] ssize = myStr.Split('/');
                    fileName = ssize[5].ToString();
                    int insert_ok = dbc.update_ProdDetail(Session["productbyadmin"].ToString(), txtProductName.Text, cmbProType.SelectedValue, cmbProSubType.Text, txtCode.Text, txtSize.Text, cmbUnit.Text, Convert.ToInt32(txtPack.Text), txtDesc.Text, txtWeight.Text, Convert.ToInt32(txtDealerPrice.Text), Convert.ToInt32(txtMRP.Text), Convert.ToInt32(txtMSMPDealer.Text), Convert.ToInt32(txtMSMPPrice.Text), Convert.ToInt32(txtAllStatePrice.Text), Convert.ToInt32(txtAllStateMRP.Text), fileName, "active", txtWarningSack.Text, txtWarningNag.Text, txtIndex.Text);

                    if (insert_ok == 1)
                    {
                        Response.Write("<script>alert('Data Updated');window.location='UpdateProduct.aspx';</script>");
                        getProductdata();
                    }
                }
                else
                {

                    int insert_ok = dbc.update_ProdDetail(Session["productbyadmin"].ToString(), txtProductName.Text, cmbProType.SelectedValue, cmbProSubType.Text, txtCode.Text, txtSize.Text, cmbUnit.Text, Convert.ToInt32(txtPack.Text), txtDesc.Text, txtWeight.Text, Convert.ToInt32(txtDealerPrice.Text), Convert.ToInt32(txtMRP.Text), Convert.ToInt32(txtMSMPDealer.Text), Convert.ToInt32(txtMSMPPrice.Text), Convert.ToInt32(txtAllStatePrice.Text), Convert.ToInt32(txtAllStateMRP.Text), fileName, "active", txtWarningSack.Text, txtWarningNag.Text, txtIndex.Text);
                    if (insert_ok == 1)
                    {

                        fupProPic.PostedFile.SaveAs(Server.MapPath("~/Personnel/admin/media/product/") + fileName);//Or code to save in the DataBase.
                        Response.Write("<script>alert('Data Updated');window.location='UpdateProduct.aspx';</script>");

                        getProductdata();
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
     
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Personnel/admin/UpdateProduct.aspx");
    }

    public void Clear()
    {
        txtProductName.Text = "";
        cmbProType.SelectedValue = "--Select Type--";
        cmbProSubType.SelectedValue= "--Select SubType--";
        txtDealerPrice.Text = "";
        txtDesc.Text = "";
        txtMRP.Text = "";
        txtPack.Text = "";
        txtSize.Text = "";
    }

    protected void cmbProType_SelectedIndexChanged(object sender, EventArgs e)
    {
        changeProType(cmbProType.SelectedValue);
    }
    public void changeProType(string cmbProType)
    {
        SqlDataSourceSubtype.SelectCommand = "SELECT ID, varProductType, varProductSubType FROM tblproductsubtype where varProductType='" + cmbProType + "' ";
        cmbProSubType.DataBind();
    }


}