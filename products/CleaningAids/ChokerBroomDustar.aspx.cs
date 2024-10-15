using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class products_CleaningAids_Choker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void View(object sender, EventArgs e)
    {
        txtEmail.Text = "";
        txtMobile.Text = "";
        ListViewItem item = (sender as LinkButton).NamingContainer as ListViewItem;
        lblId.Text = (item.FindControl("lblProductName") as Label).Text;
        mpe.Show();
    }
    protected void Save(object sender, EventArgs e)
    {
        using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
        {
            //   Response.Redirect("~/Default.aspx?mob='" + txtMobile.Text + "'&email='" + txtEmail.Text + "'");
        }
    }
}