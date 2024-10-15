﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Personnel_Admin_Verify : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["cvid"] != null)
        {
            cust();

        }
        else if (Request.QueryString["evid"] != null)
        {
            emp();
        }
        else
        {
        }
    }

    public void emp()
    {
        try
        {

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select intId as newid from sanghaviunbreakables.tblsupersonnel where varEmailVerify='" + Request.QueryString["evid"].ToString() + "'", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                int upd = Convert.ToInt32(dbc.dr["newid"].ToString());
                dbc.con.Close();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsupersonnel SET varEmailVerify='true', varStatus='true' where intId='" + upd + "'", dbc.con);
                cmd1.ExecuteNonQuery();
                dbc.con.Close();
                ClientScript.RegisterStartupScript(this.GetType(),
                        "popup",
                        "alert('Verified now login as Employee');window.location='../../SignUpLogin.aspx';",
                        true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(),
                         "popup",
                         "alert('Please try again');window.location='../../SignUpLogin.aspx';",
                         true);
            }

        }
        catch (Exception s)
        {
            ClientScript.RegisterStartupScript(this.GetType(),
                         "popup",
                         "alert('Please contact support');window.location='../../contact-us.html';",
                         true);
        }
    }
    public void cust()
    {
        try
        {

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select intId as newid from sanghaviunbreakables.tblsucustomer where varEmailVerify='" + Request.QueryString["cvid"].ToString() + "'", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                int upd = Convert.ToInt32(dbc.dr["newid"].ToString());
                dbc.con.Close();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsucustomer SET varEmailVerify='true',varStatus='Whitelist' where intId='" + upd + "'", dbc.con);
                cmd1.ExecuteNonQuery();
                dbc.con.Close();
                ClientScript.RegisterStartupScript(this.GetType(),
                         "popup",
                         "alert('Verified now login as Customer.');window.location='../../SignUpLogin.aspx';",
                         true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(),
                         "popup",
                         "alert('Please Try again');window.location='../../SignUpLogin.aspx';",
                         true);
            }

        }
        catch (Exception s)
        {
            dbc.con.Close();
            ClientScript.RegisterStartupScript(this.GetType(),
                        "popup",
                        "alert('Please contact support');window.location='../../contact-us.html';",
                        true);
        }
    }


}