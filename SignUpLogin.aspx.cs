using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

public partial class SignUpLogin : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        con = new MySql.Data.MySqlClient.MySqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["sanghaviConnectionString"].ConnectionString;

        Session.Abandon();
        Session.Clear();
        if (!IsPostBack)
        {
        }
        location();
    }
    public void location()
    {
        //lblLocation.Text = "At " + "<script type='text/javascript'>locate();</script>";
        // sendmail();
    }
    private string PopulateBody(string Name, string EmailId, string VerifyLink)
    {
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(Server.MapPath("~/Personnel/admin/emails/register.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{Name}", Name);
        body = body.Replace("{EmailId}", EmailId);
        body = body.Replace("{VerifyLink}", VerifyLink);
        return body;
    }
    protected void sendmail(string verify, string cos)
    {
        try
        {
            string mess = string.Empty;
            string email = string.Empty;
            if (cos == "c")
            {
                mess = "http://sanghavi.anuvaasoft.com/Personnel/Admin/verify.aspx?cvid=";
                email = txtMail.Text;
            }
            else
            {
                mess = "http://sanghavi.anuvaasoft.com/Personnel/Admin/verify.aspx?evid=";
                email = txtMail.Text;
            }
            using (MailMessage mm = new MailMessage(new MailAddress("Edmitra <info.edmitra@gmail.com>"), new MailAddress(email)))
            {
                mm.Subject = "Sanghavi : Verification Email";

                mm.Body = PopulateBody(txtName.Text, email, mess + verify);

                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                NetworkCredential NetworkCred = new NetworkCredential("info.edmitra@gmail.com", "info@2014");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);

            }
        }
        catch (Exception rx)
        {
            ScriptManager.RegisterStartupScript(
                         this,
                         this.GetType(),
                         "MessageBox",
                          "alert('not sent');", true);

        }
    }
    public void clear()
    {
        txtMail.Text = "";
        txtName.Text = "";
        txtMobile.Text = "";
        txtPasswd.Text = "";
        txtConfirmPass.Text = "";

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (rdbEmployee.Checked)
            {
                if (dbc.check_already_Customer(txtMail.Text) == 1)
                {
                    // pass.Visible = true;
                    lblError.Text = "This Email is already registered. Did You forget password? If yes please retrieve your password.";
                }
                else if (dbc.check_already_Employee(txtMail.Text) == 1)
                {
                    // pass.Visible = true;
                    lblError.Text = "This Email is already registered. Did You forget password? If yes please retrieve your password.";
                }
                else
                {
                    string verify = dbc.CreateRandomPassword(8);
                    int insert_ok = dbc.insert_tblEmployeeDetails(txtName.Text, txtMobile.Text, "pending", txtMail.Text, verify, txtPasswd.Text, "", "", "", "", "", "", "", "", "", "", "", "login");

                    if (insert_ok == 1)
                    {
                        sendmail(verify, "e");
                        ScriptManager.RegisterStartupScript(
                           this,
                           this.GetType(),
                           "MessageBox",
                           "alert('Registration completed please check email for verification');", true);
                        clear();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(
                      this,
                      this.GetType(),
                      "MessageBox",
                      "alert('Some problem Please try again');", true);
                    }
                }
            }
            else
            {
                if (dbc.check_already_Customer(txtMail.Text) == 1)
                {
                    // pass.Visible = true;
                    lblError.Text = "This Email is already registered. Did You forget password? If yes please retrieve your password.";
                }
                else if (dbc.check_already_Employee(txtMail.Text) == 1)
                {
                    // pass.Visible = true;
                    lblError.Text = "This Email is already registered. Did You forget password? If yes please retrieve your password.";
                }
                else
                {
                    string verify = dbc.CreateRandomPassword(8);
                    int insert_ok = dbc.insert_tblCustomerDetails(txtName.Text, txtMail.Text, txtMobile.Text, txtPasswd.Text, verify);

                    if (insert_ok == 1)
                    {
                        sendmail(verify, "c");
                        ScriptManager.RegisterStartupScript(
                           this,
                           this.GetType(),
                           "MessageBox",
                           "alert('Registration completed please check email for verification');", true);
                        clear();
                    }
                }
            }
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


}