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

public partial class Personnel_customer_ViewOrder : System.Web.UI.Page
{
   
    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();
    static int packing = 0, orderrow = 1, custId = 0, prices = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["custid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../SignUpLogin.aspx';</script>");
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        else if (!IsPostBack)
        {
            getCustomerdata();
            getImage();
           
            notifications();

        }
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["custid"].ToString()), "Customer").ToString();
    }
  
    DataTable dt = new DataTable();
    public void getCustomerdata()
    {
        try
        {

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varCompanyName FROM sanghaviunbreakables.tblsucustomer where intId=" + Session["custid"].ToString() + "", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblCustName.Text = dbc.dr["varCompanyName"].ToString();

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
        string ImageUr = dbc.select_custProfilePic(Convert.ToInt32(Session["custid"].ToString()));
        if (ImageUr == "")
        {
            imgProPic.ImageUrl = "~/Personnel/customer/media/NoProfile.png";
        }
        else
        {

            imgProPic.ImageUrl = "~/Personnel/customer/media/" + ImageUr;
        }
        //  SqlDataSourceMedia.SelectCommand = "SELECT [imgImage] FROM tblsucustomer where intId=" + Convert.ToInt32(Session["custid"].ToString()) + "";
    }
     
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Session["custid"] = "";
        Session.Remove("custid");

        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();

        Response.Redirect("~/Default.aspx");
    }
    protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (listorder.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        SqlDataSource2.DataBind();
    }


    protected void listorder_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {

            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            string orderid = commandArgs[0];
            string empcustid = commandArgs[1];

            if (e.CommandName == "View")
            {
                Session.Add("orderid", orderid);
                Response.Redirect("ViewOrderFull.aspx");
            }

            else if (e.CommandName == "CancelOrder")
            {
                string status = dbc.get_OrderStatus(Convert.ToInt64(orderid));
                if ( status== "Approved")
                {
                    Response.Write("<script>alert('Order Approved. Cannot Cancel');window.location='ViewOrder.aspx';</script>");
                }
                else if (status == "Cancelled") 
                {
                    Response.Write("<script>alert('Already Cancelled.');window.location='ViewOrder.aspx';</script>");
                }
                else
                {
                    Session.Add("orderid", orderid);
                    Response.Redirect("CancelOrder.aspx");
                }
            }
            else if (e.CommandName == "ViewBill")
            {
                int billno = dbc.get_OrderStatusBill(Convert.ToInt64(orderid));

                if (billno !=0)
                {
                    Session.Add("billno", billno);
                    Session.Add("orderid", orderid);
                    Response.Redirect("ViewOrderBill.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Bill Not Generated. Please Try Again Later');window.location='ViewOrder.aspx';</script>");
                }

            }
        }
        catch (Exception ex)
        {

        }
    }

}