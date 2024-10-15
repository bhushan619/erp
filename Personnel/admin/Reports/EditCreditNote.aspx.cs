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
using System.Globalization;


public partial class Personnel_admin_Reports_EditCreditNote : System.Web.UI.Page
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
    public void getData()
    {
        dbc.con.Open();
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT tblsucreditnote.varCrediteNoteNo as 'CNote No', tblsucreditnote.varDate as 'Date', tblsucreditnote.varNoteType as 'Note Type', tblsucustomer.varCompanyName as 'Customer', tblsucreditnote.ex1 as 'Added to'  ,tblsucreditnotedetails.varProductName as 'Product', tblsuproducts.varWeight as 'Standard Weight',Round((tblsucreditnotedetails.varSack * tblsuproducts.intPacking + tblsucreditnotedetails.varNag) * tblsuproducts.varWeight, 2) AS 'Total Kg',tblsucreditnotedetails.varSack * tblsuproducts.intPacking + tblsucreditnotedetails.varNag AS Qty, tblsucreditnote.varCreditNoteAmount as 'Credit Note Amt', tblsucreditnote.varDiscount as 'Disc', tblsucreditnote.varTransportName as 'Transport', tblsucreditnote.varTransportAmount as 'Trans Amt', tblsucreditnote.varWages as Wages, tblsucreditnote.varLorry as Lorry FROM tblsucreditnote LEFT OUTER JOIN tblsucreditnotedetails ON tblsucreditnote.intId = tblsucreditnotedetails.intcreditenoteId LEFT OUTER JOIN tblsucustomer ON tblsucreditnote.intCustid = tblsucustomer.intId LEFT OUTER JOIN tblsuproducts ON tblsucreditnotedetails.intProductId = tblsuproducts.intId where tblsucreditnote.varCrediteNoteNo='" + Request.QueryString[0].ToString() + "'", dbc.con);

        dbc.dr = cmd.ExecuteReader();
        if (dbc.dr.Read())
        {
            txtCrediteNoteNo.Text = Request.QueryString[0].ToString();
            txtCrediteNoteNo.Enabled = false;
            txtDate.Text = dbc.dr["Date"].ToString();
            txtCustomerName.Text = dbc.dr["Customer"].ToString();
            txtCustomerName.Enabled = false;
            txtNodeType.Text = dbc.dr["Note Type"].ToString();
            txtCreditNoteAmount.Text = dbc.dr["Credit Note Amt"].ToString();
            txtDiscount.Text = dbc.dr["Disc"].ToString();
            txtTransportName.Text = dbc.dr["Transport"].ToString();
            txtTransportAmount.Text = dbc.dr["Trans Amt"].ToString();
            txtWages.Text = dbc.dr["Wages"].ToString();
            txtLorry.Text = dbc.dr["Lorry"].ToString();
            ddlPlace.Enabled = false;
        }
        dbc.con.Close();
        
      
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
    
    protected void btnEditUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            dbc.con.Close();
            dbc.con.Open();
            dbc.cmd = new MySqlCommand("UPDATE tblsucreditnote SET  varDate='" + txtDate.Text + "', varNoteType='" + txtNodeType.Text + "', varCreditNoteAmount='" + txtCreditNoteAmount.Text + "',varDiscount='" + txtDiscount.Text + "',varTransportName='" + txtTransportName.Text + "',varTransportAmount='" + txtTransportAmount.Text + "',varWages='" + txtWages.Text + "',varLorry='" + txtLorry.Text + "' WHERE varCrediteNoteNo='" + txtCrediteNoteNo.Text + "'", dbc.con);
            dbc.cmd.ExecuteNonQuery();
            dbc.con.Close();

            Response.Write("<script>alert('Credit Note Updated Successfully');window.location='CreditNote.aspx';</script>");
           

        }
        catch (Exception ecc)
        {
            Response.Write("<script>alert('" + ecc.Message + "');window.location='CreditNote.aspx';</script>");
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Personnel/admin/Reports/CreditNote.aspx", false);
    }
}