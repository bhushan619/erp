using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

public partial class Personnel_employee_BillPrint : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();
    public static Int64 tot = 0, vat = 0, t = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["custid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../../SignUpLogin.aspx';</script>");
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }

        else if (!IsPostBack)
        {
         
            BillTotal();
            getbuyerdata();
         
        }
    }
    public void getbuyerdata()
    {
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(" SELECT tblsucustomer.varVatNo,  tblsuorder.intorderid FROM tblsucustomer INNER JOIN tblsuorder ON tblsucustomer.intId = tblsuorder.intCustId where tblsuorder.intorderid = '" + Convert.ToInt64(Session["orderidprint"]) + "'", dbc.con);
        dbc.con.Open();
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            lblvat.Text = dr["varVatNo"].ToString() + "-V";
            lbltin.Text = dr["varVatNo"].ToString() + "-C";
        }
        dbc.con.Close();
    }
 



    public void BillTotal()
    {
        try
        {
            foreach (GridViewRow dr in gridconsignment.Rows)
            {
                // vat = vat + 5;
                tot = tot + Convert.ToInt64(dr.Cells[8].Text.ToString());

            }
            lbltotalVat.Text = Convert.ToString(tot * 5 / 100);
            lblfinaltotamt.Text = Convert.ToString(tot);

            Int64 t = tot - Convert.ToInt32(lbltotalVat.Text);
            lblAmt.Text = Convert.ToString(t);

            string word = ConvertNumbertoWords(tot);
            lblAmountChargeword.Text = word + " only";

            string vatword = ConvertNumbertoWords(tot * 5 / 100);
            lblvatinword.Text = vatword + " only";

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('" + ex.Message + "');", true);
        }
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

  
   

}