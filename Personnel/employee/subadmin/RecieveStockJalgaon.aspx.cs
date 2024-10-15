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


public partial class Personnel_employee_RecieveStockJalgaon : System.Web.UI.Page
{

    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();
    static string custstate = string.Empty, reason = string.Empty,empdesig= string.Empty;
    static string unita = string.Empty, ordernumber = string.Empty, dat = string.Empty, tim = string.Empty;
    static int sack = 0, nug = 0, ppid = 0;
    static int pId = 0, orderrow = 1, custId = 0, prices = 0, packing = 0, packingj = 0;
    DataTable dt;
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
            ldate.Text = System.DateTime.Now.ToShortDateString();
            ltime.Text = System.DateTime.Now.ToShortTimeString();
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

    protected void grdOrderDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "addstock")
            {
                int insert_ok = 0;
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string id = commandArgs[0];
                string sacks = commandArgs[1];
                string nags = commandArgs[2];
                string productid = commandArgs[3];
                string productname = commandArgs[4];
                string units = commandArgs[5];
                string transport = commandArgs[6];
                string dates = commandArgs[7]; 
                notification(dates);
                insert_ok = dbc.insert_update_stockJalgaon(Convert.ToInt32(id), Convert.ToInt32(productid), productname, Convert.ToInt32(sacks), Convert.ToInt32(nags), Convert.ToInt32(sacks), Convert.ToInt32(nags), units, dates, ltime.Text, lblCustName.Text, "New Stock", transport, "StockAdded");
                if (insert_ok == 1)
                {
                    Response.Write("<script>alert('Added Successfully');window.location='RecieveStockJalgaon.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Please Try Again');</script>");
                }
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void notification(string dates)
    {
        try
        {
            int okn = 0; 

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdc = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId FROM tblsustockhistoryjalgaon WHERE dtDate='" + dates + "' AND varRemark='StockAdded'", dbc.con);

            MySql.Data.MySqlClient.MySqlDataReader drc;
            drc = cmdc.ExecuteReader();
            if (!drc.Read())
            {
                dbc.con.Close();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId FROM tblsupersonnel WHERE varSubDesig='Admin'", dbc.con);

                MySql.Data.MySqlClient.MySqlDataReader dre;
                dre = cmde.ExecuteReader();
                while (dre.Read())
                {
                    okn = dbc.insert_tblsunotifications("Message", Convert.ToInt32(Session["empid"].ToString()), lblCustName.Text, empdesig, Convert.ToInt32(dre["intId"].ToString()), "Admin", "Goods Recieved at Jalgaon from Varkhedi of date " + dates + "", "NA", "NA", "Unread", "Order");
                }
                dbc.con.Close();
                dbc.dr.Close();
            }
            dbc.con.Close();
            drc.Close();
        }
        catch (Exception ex)
        {
            
        }
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
    protected void grdStockManuf_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdStockManuf.PageIndex = e.NewPageIndex;
    }
}