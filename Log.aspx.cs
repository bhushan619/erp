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

public partial class Log : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["uname"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='SignUpLogin.aspx';</script>");
        }
        else if (Request["pass"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='signupSignUpLogin.aspx';</script>");
        }
        else
        {
            loginmethod();
        }
    }

    public void loginmethod()
    {
        try
        {
            string uname = Request["uname"].ToString();
            string pass = Request["pass"].ToString();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select intId,varEmail,varPassword,varDesignation,varSubDesig from sanghaviunbreakables.tblsupersonnel where varEmail='" + uname + "' and varStatus='true'", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                if (dbc.dr["varPassword"].ToString() == pass)
                {
                    if (dbc.dr["varDesignation"].ToString() == "admin")
                    {
                        Session.Add("adminid", dbc.dr["intId"].ToString());
                        Response.Redirect("~/Personnel/admin/Report.aspx",false);

                    }
                    else if (dbc.dr["varDesignation"].ToString() == "employee")
                    {
                        Session.Add("empid", dbc.dr["intId"].ToString());
                        if (dbc.dr["varSubDesig"].ToString() == "Marketing Head")
                        {
                            Response.Redirect("~/Personnel/employee/marketing/Default.aspx");
                        }
                        else if (dbc.dr["varSubDesig"].ToString() == "Marketing Executive")
                        {
                            Response.Redirect("~/Personnel/employee/marketing/Default.aspx");
                        }
                        else if (dbc.dr["varSubDesig"].ToString() == "Dispatch")
                        {
                            Response.Redirect("~/Personnel/employee/dispatch/Default.aspx"); 
                        }
                        else if (dbc.dr["varSubDesig"].ToString() == "Inventory")
                        {
                            Response.Redirect("~/Personnel/employee/inventory/Default.aspx");
                        }
                        else if (dbc.dr["varSubDesig"].ToString() == "Sub Admin")
                        {
                            Response.Redirect("~/Personnel/employee/subadmin/Default.aspx");
                        }
                        else if (dbc.dr["varSubDesig"].ToString() == "Production")
                        {
                            Response.Redirect("~/Personnel/employee/production/Default.aspx");
                        } 
                    }
                    else
                    {
                        Response.Write("<script>alert('Please Try Again');window.location='SignUpLogin.aspx';</script>");
                    }
                    dbc.dr.Close();
                }
                else
                {
                    Response.Write("<script>alert('Incorrect Password Please Try Again');window.location='SignUpLogin.aspx';</script>");

                }
            }
            else
            {
                dbc.con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmdc = new MySql.Data.MySqlClient.MySqlCommand("select intId,varEmail,varPassword from sanghaviunbreakables.tblsucustomer where varEmail='" + uname + "' and varStatus='Whitelist'", dbc.con);
                dbc.con.Open();
                dbc.dr = cmdc.ExecuteReader();
                if (dbc.dr.Read())
                {
                    if (dbc.dr["varPassword"].ToString() == pass)
                    {
                        int data = Convert.ToInt32(dbc.dr["intId"].ToString());
                        Session.Add("custid", data);
                        Response.Redirect("~/Personnel/customer/Default.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Please Try Again');window.location='SignUpLogin.aspx';</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please Try Again');window.location='SignUpLogin.aspx';</script>");
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }
}