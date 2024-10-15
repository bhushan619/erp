using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;


public partial class Personnel_admin_AddType : System.Web.UI.Page
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
        else if (!IsPostBack)
        {
            getAdmindata();
            getImage();
            notifications();
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Personnel/admin/Default.aspx");

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        { 
            int insert_ok = dbc.insert_tblproducttype(txtprodName.Text); 
            if (insert_ok != 0)
            { 
                ScriptManager.RegisterStartupScript(
                              this,
                              this.GetType(),
                              "MessageBox",
                              "alert('Product Type Added.');", true); 
            } 
            BindListView(); 
        } 
        catch (Exception)
        {

            throw;
        }
    }

    private int notifications(int insert_ok)
    {
        throw new NotImplementedException();
    }
    public void BindListView()
    {
        SqlDataSource1.SelectCommand = "SELECT ID,varProductType FROM sanghaviunbreakables.tblproducttype";
        listprodtype.DataBind();
    }



    protected void listprodtype_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
        string id = commandArgs[0];
        string stat = commandArgs[1];
        if (e.CommandName == "Edits")
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select ID,varProductType from sanghaviunbreakables.tblproducttype where ID=" + id + "", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                txtid.Text = dbc.dr["ID"].ToString();
                txtprodName.Text = dbc.dr["varProductType"].ToString();

                dbc.con.Close();
                dbc.dr.Close();
            }
        }
        else if (e.CommandName == "Deletes")
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from sanghaviunbreakables.tblproducttype WHERE ID=" + id + "", dbc.con);
            cmd.ExecuteNonQuery();
            dbc.con.Close();
        }
        SqlDataSource1.SelectCommand = "SELECT ID,varProductType FROM sanghaviunbreakables.tblproducttype";
        listprodtype.DataBind();
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("update sanghaviunbreakables.tblproducttype set varProductType='" + txtprodName.Text + "' where ID=" + txtid.Text + "", dbc.con);
            cmd.ExecuteNonQuery();
            dbc.con.Close();
            SqlDataSource1.SelectCommand = "SELECT ID,varProductType FROM sanghaviunbreakables.tblproducttype";
            listprodtype.DataBind();
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    

}