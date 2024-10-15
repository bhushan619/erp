using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Personnel_customer_ViewOrderBill : System.Web.UI.Page
{
   
    public static Int64 tot = 0, vat = 0, t = 0; 
    DatabaseConnection dbc = new DatabaseConnection();
    public MySql.Data.MySqlClient.MySqlDataReader dr;
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
            getbuyerdata();
            getOrderDetails();
           
            notifications();
        }
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["custid"].ToString()), "Customer").ToString();
    }
  
    public void getbuyerdata()
    {
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(" SELECT tblsucustomer.varVatNo,  tblsuorder.intOrderId FROM tblsucustomer INNER JOIN tblsuorder ON tblsucustomer.intId = tblsuorder.intCustId where tblsuorder.intOrderId = '" + Convert.ToInt64(Session["orderid"]) + "'", dbc.con);
        dbc.con.Open();
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            lblvat.Text = dr["varVatNo"].ToString() + "-V";
            lbltin.Text = dr["varVatNo"].ToString() + "-C";
        }
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand("SELECT tblsubill.varBillTotal as bil FROM  tblsubill where tblsubill.intBillNO = " + Convert.ToInt64(Session["billno"]) + "", dbc.con);
        dbc.con.Open();
        dr = cmda.ExecuteReader();
        if (dr.Read())
        {
            string aaa = dr["bil"].ToString();
            tot = Convert.ToInt64(aaa);
            lblAmt.Text = aaa;
            lbltotalVat.Text = Convert.ToString(tot * 5 / 100);
            lblfinaltotamt.Text = Convert.ToString(tot);

            Int64 t = tot - Convert.ToInt32(lbltotalVat.Text);
            lblAmt.Text = Convert.ToString(t);

            string word = ConvertNumbertoWords(tot);
            lblAmountChargeword.Text = word + " only";

            string vatword = ConvertNumbertoWords(tot * 5 / 100);
            lblvatinword.Text = vatword + " only";
        }
        dbc.con.Close();


    }
    public static string ConvertNumbertoWords(Int64 number)
    {
        if (number == 0)
            return "ZERO";
        if (number < 0)
            return "minus " + ConvertNumbertoWords(Math.Abs(number));
        string words = "";
        if ((number / 1000000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000000) + " MILLION ";
            number %= 1000000;
        }
        if ((number / 1000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
            number %= 100;
        }
        if (number > 0)
        {
            if (words != "")
                words += "AND ";
            var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
            var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[number % 10];
            }
        }
        return words;
    }
    public void getOrderDetails()
    {
        try
        {

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT VarModePayment,varDestination FROM tblsuorder WHERE intOrderId=" + Session["orderid"] + "", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblModeOfPayment.Text = dbc.dr["VarModePayment"].ToString();
                lblDestination.Text = dbc.dr["varDestination"].ToString();
                dbc.con.Close();
                dbc.dr.Close();
            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
        }
    }
    public void getCustomerdata()
    {
        try
        {

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varVatNo,varCompanyName,varRepresentativeName, varMobile, varEmail,varAddress, varCity, varState, varPanCardNo, varVatNo, varTinNo, dtDateOfEstd FROM sanghaviunbreakables.tblsucustomer where intId=" + Session["custid"].ToString() + "", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblCustName.Text = dbc.dr["varCompanyName"].ToString();
                lblvat.Text = dbc.dr["varVatNo"].ToString() + "-V";
                lbltin.Text = dbc.dr["varVatNo"].ToString() + "-C";
                dbc.con.Close();
                dbc.dr.Close();
            }
            dbc.dr.Close();
            MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand("SELECT tblsubill.varBillTotal as bil FROM  tblsubill where tblsubill.intBillNO = " + Convert.ToInt64(Session["billno"]) + "", dbc.con);
            dbc.con.Open();
            dbc.dr = cmda.ExecuteReader();
            if (dbc.dr.Read())
            {
                string aaa = dbc.dr["bil"].ToString();
                tot = Convert.ToInt64(aaa);
                lblAmt.Text = aaa;
                lbltotalVat.Text = Convert.ToString(tot * 5 / 100);
                lblfinaltotamt.Text = Convert.ToString(tot);

                Int64 t = tot - Convert.ToInt32(lbltotalVat.Text);


                string word = dbc.ConvertNumbertoWords(tot);
                lblAmountChargeword.Text = word + " only";

                string vatword = dbc.ConvertNumbertoWords(tot * 5 / 100);
                lblvatinword.Text = vatword + " only";
            }
            dbc.con.Close();
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
    protected void btnprint_Click(object sender, EventArgs e)
    {


        Session.Add("billnoprint", Session["billno"].ToString());
        Session.Add("orderidprint", Session["orderid"].ToString());
        ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>openNewWin('BillPrint.aspx')</script>");
    }
}