using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Personnel_customer_notifications : System.Web.UI.Page
{
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
            SqlDataSourceNotifications.SelectCommand = "SELECT varNotType,varNotText, varLink, varSession, varStatus, intId,varRemark,intNotFromId FROM tblsunotifications where (intNotToId = " + Convert.ToInt32(Session["custid"].ToString()) + ") order by varStatus desc";
        }
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["custid"].ToString()), "Customer").ToString();
    }
    protected void lnkDeleteAll_Click(object sender, EventArgs e)
    {
        dbc.deleteAll_Notification(Session["custid"].ToString());
        Response.Redirect("~/Personnel/customer/Notification.aspx");
    }
    protected void btnReadAll_Click(object sender, EventArgs e)
    {
        dbc.readAll_Notification(Session["custid"].ToString());
        Response.Redirect("~/Personnel/customer/Notification.aspx");
    }
    protected void lstNotification_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });

            string id = commandArgs[0];
            string link = commandArgs[1];
            string empcustid = commandArgs[2];
            string sesson = commandArgs[3];
            string remark = commandArgs[4];
            string type = commandArgs[5];
            string textmatter = commandArgs[6];


            if (e.CommandName == "Views")
            {
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("update sanghaviunbreakables.tblsunotifications set varStatus='Read' WHERE intId=" + id + "", dbc.con);
                cmd.ExecuteReader();
                dbc.con.Close();
                if (type == "Message")
                {
                    Response.Write("<script>alert('" + textmatter + "');window.location='Notification.aspx';</script>");
                    //Response.Write("<script>alert('" + textmatter + "');</script>");
                }
                else if (type == "Page")
                {
                    Response.Redirect(link);
                }
                else if (type == "Session")
                {
                    if (remark == "Order")
                    {
                        Session.Add("consno", sesson);
                        Session.Add("empcustid", empcustid);
                        Response.Redirect(link);
                    }
                    else if (remark == "emp")
                    {
                        Session.Add("empid", sesson);
                        Response.Redirect(link);
                    }
                    else if (remark == "cust")
                    {
                        Session.Add("custid", sesson);
                        Response.Redirect(link);
                    }
                    else if (remark == "Product")
                    {
                        Session.Add("productbyMark", sesson); 
                        Response.Redirect(link);
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void lstNotification_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        Panel notifpanal;
        string notification = string.Empty;
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            notifpanal = (Panel)e.Item.FindControl("notificationpanel");
            System.Data.DataRowView rowView = e.Item.DataItem as System.Data.DataRowView;
            notification = rowView["varStatus"].ToString();
            if (notification == "Unread")
            {
                notifpanal.CssClass = "alert alert-danger";
            }
            else if (notification == "Read")
            {
                notifpanal.CssClass = "alert alert-success";
            }

        }
    }

    DatabaseConnection dbc = new DatabaseConnection();
    public void getCustomerdata()
    {
        try
        {

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varCompanyName,varRepresentativeName, varMobile, varEmail,varAddress, varCity, varState, varPanCardNo, varVatNo, varTinNo, dtDateOfEstd FROM sanghaviunbreakables.tblsucustomer where intId=" + Session["custid"].ToString() + "", dbc.con);

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
    protected void lstNotification_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (lstNotification.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        SqlDataSourceNotifications.SelectCommand = "SELECT varNotType,varNotText, varLink, varSession, varStatus, intId,varRemark,intNotFromId FROM tblsunotifications where (intNotToId = " + Convert.ToInt32(Session["custid"].ToString()) + ") order by varStatus desc";
        SqlDataSourceNotifications.DataBind();
    }
}