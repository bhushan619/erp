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

public partial class Personnel_Delete : System.Web.UI.Page
{  DatabaseConnection dbc = new DatabaseConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        alldelet();
    }
    public void alldelet()
    {
        try
        { 

            MySql.Data.MySqlClient.MySqlCommand cmd1zz = new MySql.Data.MySqlClient.MySqlCommand("delete from tblrawmaterialhistory", dbc.con);
            dbc.con.Open();
            cmd1zz.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from tblsubill", dbc.con);
            dbc.con.Open();
            cmd.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblsuconsignment", dbc.con);
            dbc.con.Open();
            cmd1.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblsuconsignmentdetails", dbc.con);
            dbc.con.Open();
            cmd2.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd3 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblsuorder", dbc.con);
            dbc.con.Open();
            cmd3.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd4 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblsuorderdetails", dbc.con);
            dbc.con.Open();
            cmd4.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd5 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE `tblsustockvarkhedi` SET `intSack`=0,`intNug`=0,`varRemark`=NULL WHERE 1 ", dbc.con);
            dbc.con.Open();
            cmd5.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd6 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE `tblsustockjalgaon` SET `intSack`=0,`intNug`=0,`varRemark`=NULL WHERE 1 ", dbc.con);
            dbc.con.Open();
            cmd6.ExecuteNonQuery();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd7 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblsustockhistory", dbc.con);
            dbc.con.Open();
            cmd7.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd8 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblsustockhistoryjalgaon", dbc.con);
            dbc.con.Open();
            cmd8.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd9 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblrawmaterial set varWeightKg='0',varWeightTon='0',varWarningTon='1',varWarningKg='1000',`varRemark`=NULL where 1", dbc.con);
            dbc.con.Open();
            cmd9.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd10 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblrawmaterialhistory", dbc.con);
            dbc.con.Open();
            cmd10.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd11 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblsuconversation", dbc.con);
            dbc.con.Open();
            cmd11.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd12 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblsuenquiry", dbc.con);
            dbc.con.Open();
            cmd12.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd13 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblsudsrdetails", dbc.con);
            dbc.con.Open();
            cmd13.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd14 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblsumaterials", dbc.con);
            dbc.con.Open();
            cmd14.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd15 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblsumaterialhistory", dbc.con);
            dbc.con.Open();
            cmd15.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd16 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblsuodervarkhedidetails", dbc.con);
            dbc.con.Open();
            cmd16.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd17 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblsuvarkhediorder", dbc.con);
            dbc.con.Open();
            cmd17.ExecuteReader();
            dbc.con.Close();

          
        }
        catch (Exception ex)
        {

        }
    }
  
}