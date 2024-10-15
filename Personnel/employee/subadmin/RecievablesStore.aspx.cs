using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

public partial class Personnel_employee_subadmin_RecievablesStore : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();
    DatabaseConnection dbc1 = new DatabaseConnection();
    public static string empdesig = string.Empty;

    string filename = string.Empty;
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
            notifications();
            getempname();
           // GetdataInGridView();
            getFileName();

        }
        lbldate.Text = System.DateTime.Now.ToShortDateString();
        lblTime.Text = System.DateTime.Now.ToShortTimeString();
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
    public void getFileName()
    {
         dbc.con.Open();
         MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("Select varUploadFilePath from tblsuuploadfiles where intId=(select  max(intId) from tblsuuploadfiles)", dbc.con);
         dbc.dr = cmd.ExecuteReader();
         if (dbc.dr.Read())
         {
             lblFile.Text = dbc.dr["varUploadFilePath"].ToString();
         }
         dbc.dr.Dispose();
         dbc.con.Close();
    }
    
    public void uploadFile()
    {
        if (!fupFile.HasFile)
        {
            ScriptManager.RegisterStartupScript(
             this,
              this.GetType(),
             "MessageBox",
              "alert('Please select a File');", true);

            return;
        }
        else
        {

            string ffileExt = System.IO.Path.GetExtension(fupFile.FileName);
            if ( (ffileExt == ".xls") || (ffileExt == ".pdf") ||  (ffileExt == ".XLS") || (ffileExt == ".PDF"))
            {
                filename =fupFile.FileName.ToString();
                int insert_upload = dbc.insert_tblsuuploadfiles(filename);

                if (insert_upload == 1)
                {
                    fupFile.SaveAs(Server.MapPath("~/Personnel/employee/media/Recievables/") + filename);

                    ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "MessageBox",
                        "alert('File Uploded');", true);
                    Response.Redirect("RecievablesStore.aspx");
                    //clear();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(
                    this,
                    this.GetType(),
                    "MessageBox",
                    "alert('Data Not Inserted');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(
              this,
              this.GetType(),
              "MessageBox",
              "alert('Please select proper file as .xls or .pdf');", true);
                return;
            }

        }

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            uploadFile();
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
        }

    }
}

