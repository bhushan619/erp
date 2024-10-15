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
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for DatabaseConnection
/// </summary>
public class DatabaseConnection
{
    public MySql.Data.MySqlClient.MySqlConnection con, con1, con2, con3, con4;
    public MySql.Data.MySqlClient.MySqlCommand cmd, cmd1;
    public MySql.Data.MySqlClient.MySqlDataReader dr, dr1;

    public MySql.Data.MySqlClient.MySqlDataAdapter dataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter();
    public DataTable oDt, oDt1;
    public DataRow oDr;

    string tdt = string.Empty;

    public string begindate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1).ToShortDateString();
    public string enddate = DateTime.UtcNow.ToShortDateString();

    public DatabaseConnection()
    {
        //
        con = new MySql.Data.MySqlClient.MySqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["sanghaviConnectionString"].ConnectionString;
        con1 = new MySql.Data.MySqlClient.MySqlConnection();
        con1.ConnectionString = ConfigurationManager.ConnectionStrings["sanghaviConnectionString"].ConnectionString;
        con2 = new MySql.Data.MySqlClient.MySqlConnection();
        con2.ConnectionString = ConfigurationManager.ConnectionStrings["sanghaviConnectionString"].ConnectionString;
        con3 = new MySql.Data.MySqlClient.MySqlConnection();
        con3.ConnectionString = ConfigurationManager.ConnectionStrings["sanghaviConnectionString"].ConnectionString;
        con4 = new MySql.Data.MySqlClient.MySqlConnection();
        con4.ConnectionString = ConfigurationManager.ConnectionStrings["sanghaviConnectionString"].ConnectionString;
        //
    }
    public string CreateRandomPassword(int PasswordLength)
    {
        string _allowedChars = "123456789";
        Random randNum = new Random();
        char[] chars = new char[PasswordLength];
        int allowedCharCount = _allowedChars.Length;
        for (int i = 0; i < PasswordLength; i++)
        {
            chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
        }
        return new string(chars);
    }

    public int insert_tblsunotifications(string type, int fromid, string fromName, string fromDesig, int toId, string toDesig, string text, string link, string sesson, string status, string remark)
    {
        try
        {
            int id = max_tblsunotifications();
            id = id + 1;
            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsunotifications VALUES(" + id + ",'" + type + "'," + fromid + ",'" + fromName + "','" + fromDesig + "'," + toId + ",'" + toDesig + "','" + text + "','" + link + "','" + sesson + "','" + status + "','" + remark + "','')", con1);
            cmd1.ExecuteNonQuery();
            con1.Close();
            cmd1.Dispose();
            return 1;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
    public int max_tblsunotifications()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsunotifications", con2);
            con2.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
            con2.Close();
            return chk;
        }
        catch (Exception ex)
        {
            con2.Close();
            return chk;
        }
    }

    public int count_tblsunotifications(int toid, string desig)
    {
        int not = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select count(intId) as newid from sanghaviunbreakables.tblsunotifications where varStatus='Unread' and intNotToId=" + toid + " and varNotToDesig='" + desig + "'", con2);
            con2.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                not = Convert.ToInt32(dr["newid"].ToString());
            }
            con2.Close();
            return not;
        }
        catch (Exception ex)
        {
            con2.Close();
            return not;
        }
    }
    public string getpass(string email, string cos)
    {
        string schId = string.Empty;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
            con.Open();
            if (cos == "c")
            {
                cmd = new MySql.Data.MySqlClient.MySqlCommand("select varPassword FROM sanghaviunbreakables.tblsucustomer WHERE varEmail= '" + email + "'", con);
            }
            else if (cos == "e")
            {
                cmd = new MySql.Data.MySqlClient.MySqlCommand("select varPassword FROM sanghaviunbreakables.tblsupersonnel WHERE varEmail= '" + email + "'", con);
            }
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                schId = dr["varPassword"].ToString();
            }
            else
            {

            }
            con.Close();
            return schId;
        }
        catch (Exception s)
        {
            con.Close();
            return schId;
        }
    }
    public int check_already_Employee(string email)
    {
        try
        {
            int schId = 0;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select varEmail FROM sanghaviunbreakables.tblsupersonnel WHERE varEmail= '" + email + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                schId = 1;
            }
            else
            {
                schId = 0;
            }
            con.Close();
            return schId;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int check_already_Customer(string email)
    {
        try
        {
            int schId = 0;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varEmail FROM sanghaviunbreakables.tblsucustomer WHERE varEmail ='" + email + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                schId = 1;
            }
            else
            {
                schId = 0;
            }
            con.Close();
            return schId;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int insert_tblProductDetails(string pname, string ptype, string pstype, string code, string size, int packing, int dealerp, int mrp, string descrip, string image, string unit, string weight, int msmpdealerp, int msmpmrp, int alldealerp, int allmrp, string warningsack, string warningnag,string index)
    {
        try
        {
            int id = max_tblProductDetails();
            id = id + 1;
            con.Open();
            cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsuproducts VALUES(" + id + ",N'" + pname + "',N'" + ptype + "',N'" + pstype + "',N'" + code + "','" + size + "'," + packing + "," + dealerp + "," + mrp + ",N'" + descrip + "',N'" + image + "',N'active','" + unit + "','" + weight + "'," + msmpdealerp + "," + msmpmrp + "," + alldealerp + "," + allmrp + ",'" + warningsack + "','" + warningnag + "'," + index + ")", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsustockjalgaon VALUES(" + id + "," + id + ",0,0,'')", con);
            cmd1.ExecuteNonQuery();
            con.Close();
            cmd1.Dispose();

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsustockvarkhedi VALUES(" + id + "," + id + ",0,0,'')", con);
            cmd2.ExecuteNonQuery();
            con.Close();
            cmd2.Dispose();
            return id;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }

    }
    public int insert_tblEmployeeDetails(string name, string mob, string mverify, string email, string everify, string pass, string address, string city, string state, string desig, string subdes, string status, string idproof, string idproofno, string pan, string image, string dob, string page)
    {
        try
        {
            int id = max_tblEmployeeDetails();
            id = id + 1;
            con.Open();
            string design = "employee";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
            if (page == "login")
            {
                cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsupersonnel VALUES(" + id + ",N'" + name + "',N'" + mob + "',N'',N'" + email + "',N'" + everify + "',N'" + pass + "',N'',N'',N'',N'" + design + "',N'Pending',N'',N'',N'',N'',N'NoProfile.png',N'')", con);
            }
            else if (page == "adminemp")
            {
                cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsupersonnel VALUES(" + id + ",N'" + name + "',N'" + mob + "',N'" + mverify + "',N'" + email + "',N'" + everify + "',N'" + pass + "',N'" + address + "',N'" + city + "',N'" + state + "',N'" + design + "',N'" + subdes + "',N'" + status + "',N'" + idproof + "',N'" + idproofno + "',N'" + pan + "',N'" + image + "',N'" + dob + "')", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }

    }
    public int insert_CustomerDetail(string cname, string rname, string mob, string mverify, string landline, string email, string everify, string pass, string address, string city, string state, string status, string pan, string vat, string tin, string custtype, string image, string doet)
    {
        try
        {
            int id = max_tblCustomerDetails();
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsucustomer VALUES(" + id + ",N'" + cname + "',N'" + rname + "',N'" + mob + "',N'" + mverify + "',N'" + landline + "',N'" + email + "',N'" + everify + "',N'" + pass + "',N'" + address + "',N'" + city + "',N'" + state + "',N'Whitelist',N'" + pan + "',N'" + vat + "',N'" + tin + "',N'',N'" + image + "',N'" + doet + "','NA','NA')", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }

    }
    public int max_tblEmployeeDetails()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsupersonnel", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblProductDetails()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsuproducts", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblOrderId()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsuorder", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        chk++;
        return chk;
    }
    public int max_tblOrderVarkhediId()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsuvarkhediorder", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        chk++;
        return chk;
    }
    public int insert_tblCustomerDetails(string name, string email, string mob, string pass, string verify)
    {
        try
        {
            int id = max_tblCustomerDetails();
            id = id + 1;

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsucustomer VALUES(" + id + ",N'',N'" + name + "',N'" + mob + "',N'',N'',N'" + email + "',N'" + verify + "',N'" + pass + "',N'',N'',N'','Pending',N'',N'',N'',N'',N'NoProfile.png',N'','','')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();


            //con.Open();
            //cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblCollegeOtherDetails ([intCollegeId]) VALUES(" + id + ")", con);
            //cmd.ExecuteNonQuery();
            //con.Close();
            //cmd.Dispose();

            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }

    public int max_tblCustomerDetails()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsucustomer", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int Update_ProfilePiccust(int custid, string fname)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsucustomer SET imgImage='" + fname + "' WHERE intId=" + custid + "", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }

    }

    public int Update_CustomerStatus(int custid, string status)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsucustomer SET varStatus='" + status + "' WHERE intId=" + custid + "", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }

    }
    public int Update_ConsignmentStatus(int consno, string status)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsuconsignment SET varStatus='" + status + "' WHERE intConsigmentNo=" + consno + "", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }

    }
    public int Update_ProfilePicadmin(int adminid, string fname)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsupersonnel SET imgImage='" + fname + "' WHERE intId=" + adminid + "", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }

    }
    public int Update_ProfilePicemp(int empid, string fname)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsupersonnel SET imgImage='" + fname + "' WHERE intId=" + empid + "", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }

    }
    public int Update_OrderStatusCancelByCustomer(int orderId, string reason)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsuorder SET tblsuorder.varStatus='Cancelled',varCompletion='" + reason + "' WHERE tblsuorder.intOrderId=" + orderId + "", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }

    }
    public String select_empProfilePic(int id)
    {
        String name = String.Empty;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select imgImage from sanghaviunbreakables.tblsupersonnel where intId =" + id + " ", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                name = dr["imgImage"].ToString();
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return name;
    }
    public string get_OrderStatus(Int64 orderid)
    {
        string status = string.Empty;
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select varStatus from sanghaviunbreakables.tblsuorder where intOrderId=" + orderid + "", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                status = dr["varStatus"].ToString();
            }
        }
        catch (Exception ex)
        {
        }
        con.Close();
        return status;
    }
    public int get_OrderStatusBill(Int64 orderid)
    {
        int status = 0;
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select intBillNO from sanghaviunbreakables.tblsubill where intOrderId=" + orderid + "", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                status = Convert.ToInt32(dr["intBillNO"].ToString());
            }
        }
        catch (Exception ex)
        {
        }
        con.Close();
        return status;
    }
    public String select_CustState(int id)
    {
        String state = String.Empty;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varState FROM sanghaviunbreakables.tblsucustomer where intId =" + id + " ", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                state = dr["varState"].ToString();
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return state;
    }
    public String select_custProfilePic(int id)
    {
        String name = String.Empty;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select imgImage from sanghaviunbreakables.tblsucustomer where intId =" + id + " ", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                name = dr["imgImage"].ToString();
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return name;
    }

    public int update_tblsucustomer(string id, string cname, string rname, string mob, string landline, string address, string city, string state, string pan, string vat, string tin, string doet)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsucustomer SET varCompanyName = '" + cname + "',varRepresentativeName = '" + rname + "',varMobile = '" + mob + "', varLandline='" + landline + "', varAddress= '" + address + "',varCity = '" + city + "',varState = '" + state + "',varPanCardNo = '" + pan + "',varVatNo = '" + vat + "',varTinNo = '" + tin + "',dtDateOfEstd = '" + doet + "' WHERE intId = " + id + "", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int max_tblDSR()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsudsr", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }

    public int getEmpId(string name)
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select intId as newid from sanghaviunbreakables.tblsupersonnel  where varName='" + name + "'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int getCustId(string name)
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select intId as newid from sanghaviunbreakables.tblsucustomer where varCompanyName='" + name + "'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public string ConvertNumbertoWords(Int64 number)
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

    public int insert_tblExpense(string spname, string ttra, string atar, string loc, string date, string time, string reptime, string repper)
    {
        try
        {
            int id = max_tblDSR();
            id = id + 1;
            int eid = getEmpId(spname);
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsudsr VALUES(" + id + "," + eid + ",'" + date + "','" + time + "','" + loc + "','" + ttra + "','" + atar + "','" + reptime + "','" + repper + "','','','','')", con);
            cmda.ExecuteNonQuery();
            con.Close();
            cmda.Dispose();


            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int max_tblstockhistory()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsustockhistory", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_rowMaterial()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblrawmaterial", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }

    public int insert_rowMaterial(string rname, string rweightkg, string runitkg, string rweightton, string runitton, string warton, string warkg, string remark, string cal)
    {
        try
        {
            int rid = max_rowMaterial();
            rid = rid + 1;
            con.Open();                                                                                         //  intId, intProductId, pname intSack, intNug, varUnit, dtDate, tmTime, varUpdater, varReason, varTransport, varRemark
            MySql.Data.MySqlClient.MySqlCommand cmdx = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblrawmaterial VALUES(" + rid + ",'" + rname + "','" + rweightkg + "','" + runitkg + "','" + rweightton + "','" + runitton + "','" + warton + "','" + warkg + "','" + remark + "','" + cal + "')", con);
            cmdx.ExecuteNonQuery();
            con.Close();
            cmdx.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    //public int insert_update_stockVerkhedi(int prid, string pname, string rawmaterial, int sacknew, int nugnew, int sack, int nug, string unitz, string date, string time, string updater, string reason, string trans, string remark)
    //{
    //    try
    //    {

    //        int pid = max_tblstockhistory();
    //        pid = pid + 1;
    //        con.Open();                                                                                         //  intId, intProductId, pname intSack, intNug, varUnit, dtDate, tmTime, varUpdater, varReason, varTransport, varRemark
    //        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsustockhistory VALUES(" + pid + "," + prid + ",'" + pname + "','" + rawmaterial + "'," + sacknew + "," + nugnew + ",'" + unitz + "','" + date + "','" + time + "','" + updater + "','" + reason + "','" + trans + "','" + remark + "','Add')", con);
    //        cmd.ExecuteNonQuery();
    //        con.Close();
    //        cmd.Dispose();

    //        string myStr = rawmaterial;
    //        string[] ssize = myStr.Split(new char[0]);
    //        int maxrawid = max_tblrawmaterialhistoryId();
    //        maxrawid++;
    //        int rawid = get_RawId(ssize[0].ToString());
    //        con.Open();                                                                                         //  intId, intProductId, pname intSack, intNug, varUnit, dtDate, tmTime, varUpdater, varReason, varTransport, varRemark
    //        MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblrawmaterialhistory VALUES (" + maxrawid + ",'" + ssize[0].ToString() + "','" + ssize[1].ToString() + "','Kg','" + ssize[3].ToString() + "','Ton','" + date + "','" + time + "','" + updater + "','" + reason + "','StockRemoved','Remove')", con);
    //        cmd1.ExecuteNonQuery();
    //        con.Close();
    //        cmd.Dispose();


    //        Double newtsockkg = get_RawIdStockKg(rawid) - Convert.ToDouble(ssize[2].ToString());
    //        Double newtsockton = get_RawIdStockTon(rawid) - Convert.ToDouble(ssize[4].ToString());

    //        con.Open();
    //        MySql.Data.MySqlClient.MySqlCommand cmdn = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblrawmaterial SET varWeightKg ='" + newtsockkg + "', varWeightTon ='" + newtsockton + "' WHERE intId = " + rawid + "", con);
    //        cmdn.ExecuteNonQuery();
    //        con.Close();


    //        con.Open();                                                                                         //  intId, intProductId, pname intSack, intNug, varUnit, dtDate, tmTime, varUpdater, varReason, varTransport, varRemark
    //        MySql.Data.MySqlClient.MySqlCommand cmdaa = new MySql.Data.MySqlClient.MySqlCommand("select intSack,intNug from sanghaviunbreakables.tblsustockvarkhedi where intProductId=" + prid + " ", con);
    //        dr = cmdaa.ExecuteReader();
    //        string oldsack = string.Empty, oldnug = string.Empty;
    //        if (dr.Read())
    //        {
    //            oldsack = dr["intSack"].ToString();
    //            oldnug = dr["intNug"].ToString();
    //        }
    //        con.Close();
    //        cmdaa.Dispose();
    //        oldsack = Convert.ToString(Convert.ToInt32(oldsack) + sacknew);
    //        oldnug = Convert.ToString(Convert.ToInt32(oldnug) + nugnew);
    //        con.Open();                                                                                         //  intId, intProductId, pname intSack, intNug, varUnit, dtDate, tmTime, varUpdater, varReason, varTransport, varRemark
    //        MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsustockvarkhedi set intSack=" + oldsack + ",intNug=" + oldnug + ",varRemark='" + remark + "' where intProductId=" + prid + " ", con);
    //        cmda.ExecuteNonQuery();
    //        con.Close();
    //        cmda.Dispose();
    //        return 1;
    //    }
    //    catch (Exception s)
    //    {
    //        con.Close();
    //        return 0;
    //    }
    //}
    public int insert_update_stockVerkhedisendjal(int prid, string pname, Int64 sacku, Int64 nugu, Int64 sacki, Int64 nugi, string unitz, string date, string time, string updater, string reason, string trans, string remark, string challonno)
    {
        try
        {
            int pid = max_tblstockhistory();
            pid = pid + 1;
            con.Open();                                                                                         //  intId, intProductId, pname intSack, intNug, varUnit, dtDate, tmTime, varUpdater, varReason, varTransport, varRemark
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsustockhistory VALUES(" + pid + "," + prid + ",'" + pname + "','NA'," + sacki + "," + nugi + ",'" + unitz + "','" + date + "','" + time + "','" + updater + "','" + reason + "','" + trans + "','" + remark + "','Remove','" + challonno + "','')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            con.Open();                                                                                         //  intId, intProductId, pname intSack, intNug, varUnit, dtDate, tmTime, varUpdater, varReason, varTransport, varRemark
            MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsustockvarkhedi set intSack=" + sacku + ",intNug=" + nugu + ",varRemark='" + remark + "' where intProductId=" + prid + " ", con);
            cmda.ExecuteNonQuery();
            con.Close();
            cmda.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int max_tblstockhistoryjalgaon()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsustockhistoryjalgaon", con3);
            con3.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con3.Close();
        return chk;
    }
    public int insert_update_stockJalgaon(int idhistory, int prid, string pname, int sacknew, int nugnew, int sack, int nug, string unitz, string date, string time, string updater, string reason, string trans, string remark)
    {
        try
        {
            int pid = max_tblstockhistoryjalgaon();
            pid = pid + 1;
            con.Open();                                                                                         //  intId, intProductId, pname intSack, intNug, varUnit, dtDate, tmTime, varUpdater, varReason, varTransport, varRemark
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsustockhistoryjalgaon VALUES(" + pid + "," + prid + ",'" + pname + "'," + sacknew + "," + nugnew + ",'" + unitz + "','" + date + "','" + time + "','" + updater + "','" + reason + "','" + trans + "','" + remark + "','Add')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            con.Open();                                                                                         //  intId, intProductId, pname intSack, intNug, varUnit, dtDate, tmTime, varUpdater, varReason, varTransport, varRemark
            MySql.Data.MySqlClient.MySqlCommand cmdaa = new MySql.Data.MySqlClient.MySqlCommand("select intSack,intNug from sanghaviunbreakables.tblsustockjalgaon  where intProductId=" + prid + " ", con);
            dr = cmdaa.ExecuteReader();
            string oldsack = string.Empty, oldnug = string.Empty;
            if (dr.Read())
            {
                oldsack = dr["intSack"].ToString();
                oldnug = dr["intNug"].ToString();
            }
            con.Close();
            cmdaa.Dispose();
            oldsack = Convert.ToString(Convert.ToInt32(oldsack) + sacknew);
            oldnug = Convert.ToString(Convert.ToInt32(oldnug) + nugnew);
            con.Open();                                                                                         //  intId, intProductId, pname intSack, intNug, varUnit, dtDate, tmTime, varUpdater, varReason, varTransport, varRemark
            MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsustockjalgaon set intSack=" + oldsack + ",intNug=" + oldnug + ",varRemark='" + remark + "' where intProductId=" + prid + " ", con);
            cmda.ExecuteNonQuery();
            con.Close();
            cmda.Dispose();

            con.Open();                                                                                         //  intId, intProductId, pname intSack, intNug, varUnit, dtDate, tmTime, varUpdater, varReason, varTransport, varRemark
            MySql.Data.MySqlClient.MySqlCommand cmdb = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsustockhistory set varRemark='RecievedAtJalgaon' where intId=" + idhistory + "", con);
            cmdb.ExecuteNonQuery();
            con.Close();
            cmdb.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }

    public int insert_tblDSR(string spname, string ttra, string atar, string loc, string date, string time, string reptime, string repper)
    {
        try
        {
            int id = max_tblDSR();
            id = id + 1;
            int eid = getEmpId(spname);
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsudsr VALUES(" + id + "," + eid + ",'" + date + "','" + time + "','" + loc + "','" + ttra + "','" + atar + "','" + reptime + "','" + repper + "','','','','')", con);
            cmda.ExecuteNonQuery();
            con.Close();
            cmda.Dispose();


            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int insert_tblsuenquiry(int msgbyid, string msgbyname, string fromdesig, int msgtoid, string msgtoname, string todesig, string enqsub, string enqmsg, string date, string time)
    {
        try
        {
            int id = max_tblsuenquiry();
            id = id + 1;
            int cid = max_tblsuconversation();
            cid = cid + 1;

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsuconversation VALUES(" + cid + ",'" + id + "','" + enqmsg + "','')", con);
            cmda.ExecuteNonQuery();
            con.Close();
            cmda.Dispose();

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdb = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsuenquiry VALUES(" + id + "," + msgbyid + ",'" + msgbyname + "','" + fromdesig + "'," + msgtoid + ",'" + msgtoname + "','" + todesig + "','" + enqsub + "','" + date + "','" + time + "','Unread')", con);
            cmdb.ExecuteNonQuery();
            con.Close();
            cmdb.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int max_tblsuenquiry()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsuenquiry", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }

    public int max_tblsuconversation()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsuconversation", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int update_tblsupersonnel(string id, string cname, string mob, string address, string city, string state, string idProof, string idProofno, string pan, string dob)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsupersonnel SET varName = '" + cname + "',varMobile = '" + mob + "', varAddress= '" + address + "',varCity = '" + city + "',varState = '" + state + "',varIDProof = '" + idProof + "',varIDProofNo = '" + idProofno + "',varPanCardNo = '" + pan + "',dtDateOfBirth='" + dob + "' WHERE intId = " + id + "", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int update_tblsupersonnelEmp(string id, string name, string mob, string address, string city, string state, string subdes, string idproof, string idproofno, string pan, string image, string dob)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsupersonnel SET varName = '" + name + "',varMobile = '" + mob + "', varAddress= '" + address + "',varCity = '" + city + "',varState = '" + state + "',varSubDesig='" + subdes + "',varIDProof = '" + idproof + "',varIDProofNo = '" + idproofno + "',varPanCardNo = '" + pan + "',imgImage='" + image + "',dtDateOfBirth='" + dob + "' WHERE intId = " + id + "", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }

    public int Update_tblsuEnquiryReplySendAdmin(string mid, string replymsg)
    {
        try
        {
            int id = max_tblsuconversation();
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("insert into sanghaviunbreakables.tblsuconversation values( " + id + "," + mid + ",'','" + replymsg + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }

    public int update_tblsucustomeradmin(string id, string cname, string rname, string mob, string landlne, string address, string city, string state, string status, string pan, string vat, string tin, string img, string doet)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsucustomer SET varCompanyName = '" + cname + "',varRepresentativeName = '" + rname + "',varMobile = '" + mob + "',varLandline = '" + landlne + "', varAddress= '" + address + "',varCity = '" + city + "',varState = '" + state + "',varStatus='Whitelist',varPanCardNo = '" + pan + "',varVatNo = '" + vat + "',varTinNo = '" + tin + "',imgImage='" + img + "',dtDateOfEstd = '" + doet + "' WHERE intId = " + id + "", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int max_tblsucustomeradminother()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsucustomerotherdetails", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int update_tblsucustomeradminother(string custid, string rname, string desres, string contact, string dob, string remark)
    {
        try
        {
            int id = max_tblsucustomeradminother();
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdb = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsucustomerotherdetails VALUES(" + id + ",'" + custid + "','" + rname + "','" + desres + "','" + contact + "','" + dob + "','" + remark + "','')", con);
            cmdb.ExecuteNonQuery();
            con.Close();
            cmdb.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int update_tblsucustomeremp(string id, string rname, string mob, string landline, string address)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsucustomer SET varRepresentativeName = '" + rname + "',varMobile = '" + mob + "', varAddress= '" + address + "', varLandline='" + landline + "' WHERE intId = " + id + "", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int update_ProdDetail(string id, string pname, string ptype, string pstype, string code, string size, string unit, int packing, string descrip, string weight, int dealerp, int mrp, int msmpdealerp, int msmpmrp, int alldealerp, int allmrp, string image, string status, string warningsack, string warningnug,string index)
    {
        try
        {
            status = "true";
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsuproducts SET nvarProductName ='" + pname + "', nvarProductType ='" + ptype + "', nvarProductSubType ='" + pstype + "', tblsuproductcode ='" + code + "', intSize ='" + size + "', intPacking ='" + packing + "',intSort=" + index + ", intDealerPrice ='" + dealerp + "', intMRP ='" + mrp + "', nvarDescription ='" + descrip + "', imgImage ='" + image + "', nvarStatus ='active', varUnit ='" + unit + "', varWeight ='" + weight + "', intMMSMPDealer =" + msmpdealerp + ", intMSMPMRP =" + msmpmrp + ", intAllStateDealer =" + alldealerp + ", intAllStateMRP =" + allmrp + " WHERE intId = " + id + "", con);
            cmd.ExecuteNonQuery();
            con.Close();

            //con.Open();
            //MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsustockjalgaon SET varWarningSack ='" + warningsack + "', varWarningNug ='" + warningnug + "' WHERE intProductId = " + id + "", con);
            //cmd1.ExecuteNonQuery();
            //con.Close();

            //con.Open();
            //MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsustockvarkhedi SET varWarningSack ='" + warningsack + "', varWarningNug ='" + warningnug + "' WHERE intProductId = " + id + "", con);
            //cmd2.ExecuteNonQuery();
            //con.Close();

            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int get_ProductId(string name, string size)
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select intId as newid from sanghaviunbreakables.tblsuproducts where nvarProductName='" + name + "'  and intSize='" + size + "'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public string get_CustState(int orderid)
    {
        string chk = string.Empty;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT tblsucustomer.varState as State FROM tblsucustomer, tblsuorder WHERE tblsucustomer.intId = tblsuorder.intCustId AND (tblsuorder.intOrderId = " + orderid + ")", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = dr["State"].ToString();
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblOrderDetails()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsuorderdetails", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }


    public int insert_orderdetails(string OrderId, string ProductName, string Quantity, string Nag, string Price, string Remark)
    {
        try
        {
            int id = max_tblOrderDetails();
            id = id + 1;
            string myStr = ProductName;
            string[] ssize = myStr.Split(new char[0]);
            int Pname = get_ProductId(ssize[0].ToString(), ssize[2].ToString());
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsuorderdetails VALUES (" + id + "," + OrderId + "," + Pname + ",'" + ProductName + "','" + Quantity + "','" + Nag + "','" + Price + "','" + Remark + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int insert_orderdetailsediting(string OrderId, string ProductName, string Quantity, string Nag, string Price, string Remark)
    {
        string newsack = string.Empty;
        string newnug = string.Empty;
        string newprice = string.Empty;
        try
        {
            int id = max_tblOrderDetails();
            id = id + 1;
            string myStr = ProductName;
            string[] ssize = myStr.Split(new char[0]);
            int Pname = get_ProductId(ssize[0].ToString(), ssize[2].ToString());
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsuorderdetails VALUES (" + id + "," + OrderId + "," + Pname + ",'" + ProductName + "','" + Quantity + "','" + Nag + "','" + Price + "','" + Remark + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT SUM(varQuantity) as sack,SUM(varNag) as nug ,SUM(varPrice) as cost FROM sanghaviunbreakables.tblsuorderdetails WHERE tblsuorderdetails.intOrderId=" + Convert.ToInt32(OrderId) + "", con);
            dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                newsack = dr[0].ToString();
                newnug = dr[1].ToString();
                newprice = dr[2].ToString();
            }
            con.Close();

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsuorder SET varProductTotal='" + newsack + "',varTotalNag='" + newnug + "',varPriceTotal='" + newprice + "' WHERE intOrderId=" + Convert.ToInt32(OrderId) + "", con);
            cmd2.ExecuteNonQuery();
            con.Close();

            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int max_tblOrder()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsuorder", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }


    public int insert_order(string OrderId, int CustId, string EmpId, string ProductTotal, string ProductNag, string ProductPrice, string modepay, string destination, string orderids)
    {
        try
        {
            int id = max_tblOrder();
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsuorder VALUES (" + OrderId + "," + id + "," + CustId + "," + Convert.ToInt32(EmpId) + ",'UnApproved','NA','" + DateTime.UtcNow.ToShortDateString() + "','" + DateTime.UtcNow.ToShortTimeString() + "','" + ProductTotal + "','" + ProductNag + "','" + ProductPrice + "','" + modepay + "','" + destination + "','Incomplete','','','" + orderids + "','NA')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int insert_order_admin(string OrderId, int CustId, int EmpId, string ProductTotal, string ProductNag, string ProductPrice, string modepay, string destination, string transprt, string empname, string orderdate, string bookingId, string lrno, string disc)
    {
        try
        {
            int id = max_tblOrder();
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsuorder VALUES (" + OrderId + "," + id + "," + CustId + "," + EmpId + ",'Approved','" + empname + "','" + orderdate + "','" + DateTime.UtcNow.ToShortTimeString() + "','" + ProductTotal + "','" + ProductNag + "','" + ProductPrice + "','" + modepay + "','" + destination + "','Incomplete','" + bookingId + "','" + lrno + "','" + disc + "','" + transprt + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }

    public int Update_OrderStatus(Int64 orderid, string status, string approvedby, string bookingid, string totolprice, string dte, string lrno, string disc, string transport)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsuorder SET varStatus='" + status + "',varApprvedBy='" + approvedby + "',varBookingId='" + bookingid + "',varPriceTotal='" + totolprice + "',dtDate='" + dte + "',ex1='" + lrno + "',ex2='" + disc + "',varTransport='" + transport + "' WHERE intOrderId=" + orderid + "", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }

    }
    public int updateOrderDetailsFull(string sack, string nug, string price, string odetid, string orderid, string prname)
    {
        int ok = 0;
        string newsack = string.Empty;
        string newnug = string.Empty;
        string newprice = string.Empty;
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsuorderdetails SET tblsuorderdetails.varQuantity='" + sack + "',tblsuorderdetails.varNag='" + nug + "',tblsuorderdetails.varPrice='" + price + "',tblsuorderdetails.varProductName='" + prname + "' WHERE intId=" + Convert.ToInt32(odetid) + "", con);
            cmd.ExecuteNonQuery();
            con.Close();

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT SUM(varQuantity) as sack,SUM(varNag) as nug ,SUM(varPrice) as cost FROM sanghaviunbreakables.tblsuorderdetails WHERE tblsuorderdetails.intOrderId=" + Convert.ToInt32(orderid) + "", con);
            dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                newsack = dr[0].ToString();
                newnug = dr[1].ToString();
                newprice = dr[2].ToString();
            }
            con.Close();

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsuorder SET varProductTotal='" + newsack + "',varTotalNag='" + newnug + "',varPriceTotal='" + newprice + "' WHERE intOrderId=" + Convert.ToInt32(orderid) + "", con);
            cmd2.ExecuteNonQuery();
            con.Close();

            ok = 1;

        }
        catch (Exception ex)
        {
            ok = 0;
        }
        con.Close();
        return ok;
    }

    public int updateOrderDetailsFullDelete(string odetid, string orderid)
    {
        int ok = 0;
        string newsack = string.Empty;
        string newnug = string.Empty;
        string newprice = string.Empty;
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from sanghaviunbreakables.tblsuorderdetails  WHERE tblsuorderdetails.intId=" + Convert.ToInt32(odetid) + "", con);
            cmd.ExecuteNonQuery();
            con.Close();

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT SUM(varQuantity) as sack,SUM(varNag) as nug ,SUM(varPrice) as cost FROM sanghaviunbreakables.tblsuorderdetails WHERE tblsuorderdetails.intOrderId=" + Convert.ToInt32(orderid) + "", con);
            dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                newsack = dr[0].ToString();
                newnug = dr[1].ToString();
                newprice = dr[2].ToString();
            }
            con.Close();

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsuorder SET varProductTotal='" + newsack + "',varTotalNag='" + newnug + "',varPriceTotal='" + newprice + "' WHERE intOrderId=" + Convert.ToInt32(orderid) + "", con);
            cmd2.ExecuteNonQuery();
            con.Close();

            ok = 1;

        }
        catch (Exception ex)
        {
            ok = 0;
        }
        con.Close();
        return ok;
    }
    public int max_suconsignment()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intConsigmentNo) as newid from sanghaviunbreakables.tblsuconsignment", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_BillSr()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsubill", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_BillNo()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intBillNO) as newid from sanghaviunbreakables.tblsubill", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }

    public int insert_Bill(int Billno, Int64 OrderId, int CosignmentId, string ModePay, string dispatch, string destination, string TermsOfDelivery, string Remark, string tsack, string tnug, string tprice)
    {
        try
        {
            int id = max_BillSr();
            id = id + 1;

            con.Open();                                                                                                                                                     // string Id, int Billno, int OrderId, int CosignmentId, string date, string time, string ModePay, string dispatch, string destination, string TermsOfDelivery, string Remark, string tsack, string tnug, string tprice)
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsubill VALUES (" + id + "," + Billno + "," + OrderId + "," + CosignmentId + ",'" + DateTime.UtcNow.ToShortDateString() + "','" + DateTime.UtcNow.ToShortTimeString() + "','" + dispatch + "','" + TermsOfDelivery + "','" + Remark + "','" + tsack + "','" + tnug + "','" + tprice + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int max_cosignmentIntId()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsuconsignment", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_cosignmentDetailsConId()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intConsigmentNo) as newid from sanghaviunbreakables.tblsuconsignmentdetails", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_cosignmentDetailsId()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsuconsignmentdetails", con1);
            con1.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con1.Close();
        return chk;
    }
    public int max_VarkhediOrderDetailsId()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsuodervarkhedidetails", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    //public int insert_ConsignmentDetails(int CosignmentId, int billno, Int64 orderid)
    //{
    //    try
    //    {
    //        int id = max_cosignmentDetailsId();
    //        id = id + 1;

    //        con.Open();
    //        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsuconsignment VALUES (" + id + "," + CosignmentId + "," + billno + "," + orderid + ",'" + DateTime.UtcNow.ToShortDateString() + "','" + DateTime.UtcNow.ToShortTimeString() + "','','')", con);
    //        cmd.ExecuteNonQuery();
    //        con.Close();
    //        cmd.Dispose();

    //        return 1;
    //    }
    //    catch (Exception s)
    //    {
    //        con.Close();
    //        return 0;
    //    }
    //}
    public int insert_Consignment(Int64 orderid, string transport)
    {
        try
        {
            int id = max_cosignmentIntId();
            id = id + 1;

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsuconsignment VALUES (" + id + "," + orderid + ",0," + orderid + ",'" + transport + "','" + DateTime.UtcNow.ToShortDateString() + "','" + DateTime.UtcNow.ToShortTimeString() + "','Consignment Created','In Transit')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int get_ProductSack(string name, string size)
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select intSack as newid from sanghaviunbreakables.tblsustockjalgaon where intProductId=(select 	intId from sanghaviunbreakables.tblsuproducts where nvarProductName='" + name + "' and intSize='" + size + "')", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int get_ProductNug(string name, string size)
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select intNug as newid from sanghaviunbreakables.tblsustockjalgaon where intProductId=(select 	intId from sanghaviunbreakables.tblsuproducts where nvarProductName='" + name + "' and intSize='" + size + "')", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public Int64 get_ProductStock(string productid)
    {
        Int64 chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT tblsustockvarkhedi.intSack * tblsuproducts.intPacking + tblsustockvarkhedi.intNug AS total FROM tblsustockvarkhedi, tblsuproducts WHERE tblsustockvarkhedi.intProductId = tblsuproducts.intId AND (tblsustockvarkhedi.intProductId = " + productid + ")", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt64(dr["total"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public Int64 get_ProductStockJalgaon(string productid)
    {
        Int64 chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT tblsustockjalgaon.intSack * tblsuproducts.intPacking + tblsustockjalgaon.intNug AS total FROM tblsustockjalgaon, tblsuproducts WHERE tblsustockjalgaon.intProductId = tblsuproducts.intId AND (tblsustockjalgaon.intProductId = " + productid + ")", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt64(dr["total"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int update_rawMaterial(string name, string weight, string weights, string date, string time, string updater, string reason, string remark, string billno, string vendorname, double rate, double disc, double amt)
    {
        try
        {
            int id = max_tblrawmaterialhistoryId();
            id = id + 1;
            int rawId = get_RawId(name);
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblrawmaterialhistory VALUES (" + id + ",'" + name + "','" + weight + "','Kg','" + weights + "','Ton','" + date + "','" + time + "','" + updater + "','" + reason + "','StockAdded','Add','" + billno + "','" + vendorname + "'," + rate + "," + disc + "," + amt + ")", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            Double newtsockkg = get_RawIdStockKg(rawId) + Convert.ToDouble(weight);
            Double newtsockton = get_RawIdStockTon(rawId) + Convert.ToDouble(weights);

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblrawmaterial SET varWeightKg ='" + newtsockkg + "', varWeightTon ='" + newtsockton + "' WHERE intId = " + rawId + "", con);
            cmd1.ExecuteNonQuery();
            con.Close();

            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int max_tblrawmaterialhistoryId()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblrawmaterialhistory", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int get_RawId(string name)
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select intId as newid from sanghaviunbreakables.tblrawmaterial where varName='" + name + "'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public Double get_RawIdStockKg(int id)
    {
        Double chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select varWeightKg as newid from sanghaviunbreakables.tblrawmaterial where intId=" + id + "", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToDouble(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public Double get_RawIdStockTon(int id)
    {
        Double chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select varWeightTon as newid from sanghaviunbreakables.tblrawmaterial where intId=" + id + "", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToDouble(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }

    public int insert_tblDSRDetails(int empid, string empName, string date, string time, string location, string calltype, string custname, string repname, string landline, string mobile, string remark, string nextdate, string status)
    {
        try
        {
            int id = max_DSR();
            id = id + 1;
            con.Open();

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();

            cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsudsrdetails VALUES(" + id + "," + empid + ",'" + empName + "','" + date + "','" + time + "','" + location + "','" + calltype + "','" + custname + "','" + repname + "','" + landline + "','" + mobile + "','" + remark + "','" + nextdate + "','" + status + "')", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int max_DSR()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsudsrdetails", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_material()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsumaterials", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int insert_sumaterials(string name, string units)
    {
        try
        {
            int id = max_material();
            id = id + 1;
            con.Open();

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();

            cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsumaterials VALUES(" + id + ",'" + name + "','0','" + units + "','NA')", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int max_materialhistory()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsumaterialhistory", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int get_material(string name)
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select varQty as newid from sanghaviunbreakables.tblsumaterials where varMaterialName='" + name + "'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int update_sumaterials(string dt, string tm, string name, string qty, string reason)
    {
        try
        {

            int id = max_materialhistory();

            int oldstock = get_material(name);
            int stock = oldstock - Convert.ToInt32(qty);
            id = id + 1;
            con.Open();

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();

            cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsumaterialhistory VALUES(" + id + ",'" + dt + "','" + tm + "','" + name + "','" + qty + "','" + stock.ToString() + "','" + reason + "','Used')", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsumaterials SET varQty ='" + stock + "' WHERE varMaterialName = '" + name + "'", con);
            cmd1.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int update_sumaterialsAdd(string dt, string tm, string name, string qty, string reason)
    {
        try
        {

            int id = max_materialhistory();

            int oldstock = get_material(name);
            int stock = oldstock + Convert.ToInt32(qty);
            id = id + 1;
            con.Open();

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();

            cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsumaterialhistory VALUES(" + id + ",'" + dt + "','" + tm + "','" + name + "','" + qty + "','" + stock.ToString() + "','" + reason + "','Used')", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsumaterials SET varQty ='" + stock + "' WHERE varMaterialName = '" + name + "'", con);
            cmd1.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    /////////////for District allocate
    public int max_tblsuallocatedistrict()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsuallocatedistrict", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }

    public int insert_tblsuallocatedistrict(int empId, string ename, string empallocator, string country, string state, string district, string edesig)
    {

        int id = max_tblsuallocatedistrict();
        id = id + 1;

        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
        con.Open();
        cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsuallocatedistrict VALUES(" + id + ", " + empId + " , '" + ename + "' ,'" + empallocator + "', '" + country + "', '" + state + "', '" + district + "','" + edesig + "','','')", con);

        cmd.ExecuteNonQuery();
        con.Close();
        cmd.Dispose();
        return 1;
    }
    ///////////////////For file Upload(By Subadmin)
    public int max_tblsuuploadfiles()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsuuploadfiles", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int insert_tblsuuploadfiles(string fname)
    {

        int id = max_tblsuuploadfiles();
        id = id + 1;

        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
        con.Open();
        cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsuuploadfiles VALUES(" + id + ",'" + fname + "','" + DateTime.Now.ToShortDateString() + "','')", con);

        cmd.ExecuteNonQuery();
        con.Close();
        cmd.Dispose();
        return 1;
    }
    ////////////////////for customer tax transaction details
    public int max_tblsucustomertaxdetails()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsucustomertaxdetails", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int insert_tblsucustomertaxdetails(int Cid, string cname, string ctaxable, string ctaxtype, string ctaxgroup, string ccstNumber, string ctaxdiscount, string ccrbills, string ccrlimit, string ccrdays)
    {

        int id = max_tblsucustomertaxdetails();
        id = id + 1;

        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
        con.Open();
        cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsucustomertaxdetails VALUES(" + id + "," + Cid + ",'" + cname + "','" + ctaxable + "', '" + ctaxtype + "', '" + ctaxgroup + "', '" + ccstNumber + "','" + ctaxdiscount + "','" + ccrbills + "','" + ccrlimit + "','" + ccrdays + "','','')", con);

        cmd.ExecuteNonQuery();
        con.Close();
        cmd.Dispose();
        return 1;
    }
    public int check_already_CustomerTaxDetails(int Companyid)
    {
        try
        {
            int schId = 0;
            con.Close();
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intCompanyId FROM sanghaviunbreakables.tblsucustomertaxdetails WHERE intCompanyId ='" + Companyid + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                schId = 1;
            }
            else
            {
                schId = 0;
            }
            con.Close();
            return schId;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }

    }
    public int update_tblsucustomertaxdetails(int Cid, string ctaxable, string ctaxtype, string ctaxgroup, string ccstNumber, string ctaxdiscount, string ccrbills, string ccrlimit, string ccrdays)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE sanghaviunbreakables.tblsucustomertaxdetails SET varTaxable ='" + ctaxable + "',varTaxType='" + ctaxtype + "',varCSTnumber='" + ccstNumber + "',varTaxGroup='" + ctaxgroup + "',varTaxDiscount='" + ctaxdiscount + "',varCrBills='" + ccrbills + "', varCrLimit='" + ccrlimit + "',varCrdays='" + ccrdays + "' WHERE intCompanyId = '" + Cid + "'", con);
            cmd1.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int max_tblcreditnote()
    {
        int chk = 0;
        try
        {
            con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsucreditnote", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int check_tblcreditnote(string cnoteno)
    {
        int chk = 0;
        try
        {
            con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select intId as newid from sanghaviunbreakables.tblsucreditnote where varCrediteNoteNo='" + cnoteno + "'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = 1;
            }
            else
            {
                chk = 0;
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblcreditnotedetails()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsucreditnotedetails", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }

    public int insert_CreditNote_subadmin(string billno, string creditenoteno, string notetype, int custid, int empid, double creditenoteamt, string discount, string transName, double transeAmt, double wages, double lorry, string place, string dates)
    {
        try
        {
            int id = max_tblcreditnote();
            id = id + 1;
            con.Close();
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsucreditnote VALUES (" + id + ",'" + billno + "','" + creditenoteno + "','" + dates + "','" + DateTime.UtcNow.ToShortTimeString() + "','" + notetype + "'," + custid + "," + empid + "," + creditenoteamt + ",'" + discount + "','" + transName + "'," + transeAmt + "," + wages + "," + lorry + ",'" + place + "','','')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            return id;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }

    public int insert_creditnotedetails(string creditnoteno, string ProductName, string Quantity, string Nag, string Price)
    {
        try
        {
            int id = max_tblcreditnotedetails();
            id = id + 1;
            string myStr = ProductName;
            string[] ssize = myStr.Split(new char[0]);
            int Pname = get_ProductId(ssize[0].ToString(), ssize[2].ToString());
            con.Close();
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsucreditnotedetails VALUES (" + id + ",'" + creditnoteno + "'," + Pname + ",'" + ProductName + "','" + Quantity + "','" + Nag + "','" + Price + "','')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int max_tblsucollection()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsucollection", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int insert_Collection_Marketing(int custid, int empid, string paymode, string Checkno, string CheckDate, string varAmount, string OtherPaymentDetails)
    {
        try
        {
            int id = max_tblsucollection();
            id = id + 1;
            con.Close();
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO sanghaviunbreakables.tblsucollection VALUES (" + id + "," + id + "," + custid + "," + empid + ",'" + DateTime.UtcNow.ToShortDateString() + "','" + paymode + "','" + Checkno + "','" + CheckDate + "','" + varAmount + "','" + OtherPaymentDetails + "','','')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int max_tblsuexpenses()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsuexpenses", con2);
            con2.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
            con2.Close();
            return chk;
        }
        catch (Exception ex)
        {
            con2.Close();
            return chk;
        }
    }
    public int insert_tblsuexpenses(int EmpId, string StartDate, string Advance, string Location, string Balance, string TotalExpense, string EndDate, string imgSignature, string Remark)
    {
        try
        {
            int id = max_tblsuexpenses();
            id = id + 1;
            con.Close();
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblsuexpenses VALUES (" + id + "," + EmpId + ",'" + StartDate + "','" + Advance + "','" + Location + "','" + Balance + "','" + TotalExpense + "','" + EndDate + "','" + imgSignature + "','" + Remark + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            return id;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }

    public int max_tblsuexpensesdetails()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsuexpensesdetails", con2);
            con2.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
            con2.Close();
            return chk;
        }
        catch (Exception ex)
        {
            con2.Close();
            return chk;
        }
    }
    public int insert_tblsuexpensesdetails(Int64 ExpensesId, string Date, string Place, string ExpenseDetail, string ModeOfTransport, string Local, string Lodging, string DA, string Other, string Total)
    {
        try
        {
            int id = max_tblsuexpensesdetails();
            id = id + 1;
            con.Close();
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblsuexpensesdetails VALUES (" + id + "," + ExpensesId + ",'" + Date + "','" + DateTime.UtcNow.ToShortTimeString() + "','" + Place + "','" + ExpenseDetail + "','" + ModeOfTransport + "','" + Local + "','" + Lodging + "','" + DA + "','" + Other + "','" + Total + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    //15-03-2016 jyoti

    public int max_tblsudispatchexpensesheet()
    {
        int chk = 0;
        try
        {
            con2.Close();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from sanghaviunbreakables.tblsudispatchexpensesheet", con2);
            con2.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
            con2.Close();
            return chk;
        }
        catch (Exception ex)
        {
            con2.Close();
            return chk;
        }
    }

    public int insert_DispatchExpenseSheet(Int32 empid, string no, string date, string invoice, string lr, string trans, string party, string sack, string auto, string lorry, string goodsreturn, string hamali, string Total, string remark)
    {
        try
        {
            int id = max_tblsudispatchexpensesheet();
            id = id + 1;
            con.Close();
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblsudispatchexpensesheet VALUES (" + id + "," + empid + ",'" + no + "','" + date + "','" + invoice + "','" + lr + "','" + trans + "','" + party + "','" + sack + "','" + auto + "','" + lorry + "','" + goodsreturn + "','" + hamali + "','" + Total + "','" + remark + "','')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public void deleteAll_Notification(string memId)
    {
        try
        {

            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("delete from sanghaviunbreakables.tblsunotifications where intNotToId='" + memId + "'", con1);
            cmd1.ExecuteNonQuery();
            con1.Close();
            cmd1.Dispose();

        }
        catch (Exception ex)
        {

        }
    }
    public void readAll_Notification(string memId)
    {
        try
        {

            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("update sanghaviunbreakables.tblsunotifications set varStatus='Read' where intNotToId='" + memId + "'", con1);
            cmd1.ExecuteNonQuery();
            con1.Close();
            cmd1.Dispose();

        }
        catch (Exception ex)
        {

        }
    }
    public int insert_tblproducttype(string pname)
    {
        try
        {
            
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("insert into sanghaviunbreakables.tblproducttype(varProductType) values(  '" + pname + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception ex)
        {
            con.Close();
            return 0;
        }
    }
  

    public int insert_tblproductsubtype(string ptype, string psubtype)
    {
        try
        {
            
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd=new MySql.Data.MySqlClient.MySqlCommand("insert into sanghaviunbreakables.tblproductsubtype(varProductType,varProductSubType) values('" + ptype + "','"+ psubtype + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception ex)
        {
            con.Close();
           return 0;
        }
    }
  
}
   
