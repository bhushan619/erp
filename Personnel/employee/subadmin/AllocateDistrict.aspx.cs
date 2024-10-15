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

public partial class Personnel_employee_subadmin_AllocateDistrict : System.Web.UI.Page
{

    DatabaseConnection dbc = new DatabaseConnection();
    static string custstate = string.Empty;
    static string pname = string.Empty, ordernumber = string.Empty, unita = string.Empty, empdesig = string.Empty;
  //  static int packing = 0, orderrow = 0, custId = 0, prices = 0, pId = 0;
    static int empid = 0;
    static string eDesig = string.Empty;
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
         if (Session["empid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../../SignUpLogin.aspx';</script>");
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }

         else if (!IsPostBack)
         {
             notifications();
             getempname();
             getImage();
             getData();
         }


    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblsunotifications(Convert.ToInt32(Session["empid"].ToString()), empdesig).ToString();
    }
    public void getempname()
    {
        try
        {

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varName,varSubDesig FROM sanghaviunbreakables.tblsupersonnel where intId=" + Session["empid"].ToString() + "", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblCustName.Text = dbc.dr["varName"].ToString();
                empdesig = dbc.dr["varSubDesig"].ToString();
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
        try
        {
            string ImageUr = dbc.select_empProfilePic(Convert.ToInt32(Session["empid"].ToString()));
            if (ImageUr == "")
            {
                imgProPic.ImageUrl = "~/Personnel/employee/media/NoProfile.png";
            }
            else
            {

                imgProPic.ImageUrl = "~/Personnel/employee/media/" + ImageUr;
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/SignUpLogin.aspx");
        }
        //  SqlDataSourceMedia.SelectCommand = "SELECT [imgImage] FROM tblsucustomer where intId=" + Convert.ToInt32(Session["empid"].ToString()) + "";
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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varSubDesig FROM tblsupersonnel WHERE varName='" + ddlDistricthead.Text + "'", dbc.con);
                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    empid = Convert.ToInt32(dbc.dr["intId"].ToString());
                    eDesig = dbc.dr["varSubDesig"].ToString();
                    dbc.con.Close();
                    dbc.dr.Close();
                }

                //dbc.con.Open();
                int insert_Ok = dbc.insert_tblsuallocatedistrict(empid, ddlDistricthead.Text, ddlStateHead.Text, ddlCountry.Text, ddlstate.Text, ddlDistrict.Text, eDesig);
                if (insert_Ok == 1)
                {
                    ScriptManager.RegisterStartupScript(
                             this,
                             this.GetType(),
                             "MessageBox",
                             "alert('District Allocated');", true);
                    //clear();
                    Response.Redirect("AllocateDistrict.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(
                              this,
                              this.GetType(),
                              "MessageBox",
                              "alert('District not Allocated');", true);
                    // clear();
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
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
    public void getData()
    { try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT intId, varEmpName,varDistrict FROM sanghaviunbreakables.tblsuallocatedistrict ", dbc.con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            GroupingView1.DataSource = ds;
            GroupingView1.DataBind();
            dbc.con.Close();
        }
        catch (Exception ex)
        {
            dbc.con.Close();
        }

        
    }
    public void clear()
    {
        ddlStateHead.SelectedItem.Text = "--Select State Head--";
        ddlstate.SelectedItem.Text = "--Select State--";
        ddlDistrict.SelectedItem.Text = "--Select District--";
        ddlCountry.SelectedItem.Text = "--Select Country--";
        ddlDistricthead.SelectedItem.Text = "--Select District Head--";
        ddlRegionalhead.SelectedItem.Text = "--Select Regional Head--";
    }
    protected void ddlRegionalhead_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            getHeaddata();
        }
        catch(Exception ex)
        {
            dbc.con.Close();
        }
    }
    public void getHeaddata()
    {
        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varName FROM sanghaviunbreakables.tblsupersonnel WHERE varSubDesig='Sub Admin' ", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                //ddlRegionalhead.Text = dbc.dr["varName"].ToString();
               // ddlStateHead.Items.Clear();
                ddlStateHead.Items.Add(dbc.dr["varName"].ToString());
                dbc.con.Close();
                dbc.dr.Close();
            }
        }
        catch (Exception ex)
        {
            dbc.con.Close();
        }
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (ddlCountry.Text == "India")
            {
                
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varName FROM sanghaviunbreakables.tblsupersonnel WHERE varSubDesig='Admin' ", dbc.con);
                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                 //   ddlRegionalhead.Items.Clear();
                    ddlRegionalhead.Items.Add( dbc.dr["varName"].ToString());

                    dbc.con.Close();
                    dbc.dr.Close();
                }
               
                ddlstate.Items.Clear();
                ddlstate.Items.Add("--Select State--");
                ddlstate.Items.Add("Andhra Pradesh");
                ddlstate.Items.Add("Arunachal Pradesh");
                ddlstate.Items.Add("Assam");
                ddlstate.Items.Add("Bihar");
                ddlstate.Items.Add("Chattisgardh");
                ddlstate.Items.Add("Goa");
                ddlstate.Items.Add("Gujarat");
                ddlstate.Items.Add("Haryana");
                ddlstate.Items.Add("Himachal Pradesh");
                ddlstate.Items.Add("Jammu and Kashmir");
                ddlstate.Items.Add("Jharkhand");
                ddlstate.Items.Add("Karnataka");
                ddlstate.Items.Add("Kerala");
                ddlstate.Items.Add("Madhya Pradesh");
                ddlstate.Items.Add("Maharashtra");
                ddlstate.Items.Add("Meghalaya");
                ddlstate.Items.Add("Mizoram");
                ddlstate.Items.Add("Nagaland");
                ddlstate.Items.Add("Orissa");
                ddlstate.Items.Add("Punjab");
                ddlstate.Items.Add("Rajastan");
                ddlstate.Items.Add("Sikkim");
                ddlstate.Items.Add("Tamil Nadu");
                ddlstate.Items.Add("Tripura");
                ddlstate.Items.Add("Uttar Pradesh");
                ddlstate.Items.Add("Uttarakhand");
                ddlstate.Items.Add("West Bengal");

            }
        }
        catch(Exception ex)
        {
          dbc.con.Close();
        }

    }
    protected void ddlStateHead_SelectedIndexChanged(object sender, EventArgs e)
    {
         try
        {
             dbc.con.Open();
             MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT  varName FROM sanghaviunbreakables.tblsupersonnel WHERE varSubDesig='Marketing Executive' OR   varSubDesig='Marketing Head' ", dbc.con);
                dbc.dr = cmd.ExecuteReader();
                while(dbc.dr.Read())
                {
                     
                    ddlDistricthead.Items.Add( dbc.dr["varName"].ToString());
                    
                   // dbc.dr.Close();
                }

                dbc.con.Close();
                dbc.dr.Close();
        }
        catch(Exception ex)
        {
            dbc.con.Close();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("AllocateDistrict.aspx");
    }

    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstate.Text == "Andhra Pradesh")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Adilabad");
            ddlDistrict.Items.Add("Anantapur");
            ddlDistrict.Items.Add("Chittor");
            ddlDistrict.Items.Add("East Godavari");
            ddlDistrict.Items.Add("Guntur");
            ddlDistrict.Items.Add("Hyderabad");
            ddlDistrict.Items.Add("Karimnagar");
            ddlDistrict.Items.Add("Khammam");
            ddlDistrict.Items.Add("Krishna");
            ddlDistrict.Items.Add("Kurnool");
            ddlDistrict.Items.Add("Mahbubnagar");
            ddlDistrict.Items.Add("Medak");
            ddlDistrict.Items.Add("Nalgonda");
            ddlDistrict.Items.Add("Nellore");
            ddlDistrict.Items.Add("Nizamabad");
            ddlDistrict.Items.Add("Prakasam");
            ddlDistrict.Items.Add("Rangareddy");
            ddlDistrict.Items.Add("Srikakulam");

            ddlDistrict.Items.Add("Vishakapattanam");
            ddlDistrict.Items.Add("Vizianagaram");
            ddlDistrict.Items.Add("Warangal");
            ddlDistrict.Items.Add("West Godavari");
            ddlDistrict.Items.Add("YSR Kadapa");

        }
        else if (ddlstate.Text == "Arunachal Pradesh")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Anjaw");
            ddlDistrict.Items.Add("Changlang");
            ddlDistrict.Items.Add("East Kameng");
            ddlDistrict.Items.Add("East Godavari");
            ddlDistrict.Items.Add("Pasighat");
            ddlDistrict.Items.Add("Lohit");
            ddlDistrict.Items.Add("Lower Subansiri");
            ddlDistrict.Items.Add("Papum Pare");
            ddlDistrict.Items.Add("Tawang Town");
            ddlDistrict.Items.Add("Tirap");
            ddlDistrict.Items.Add("Lower Dibang Valley");
            ddlDistrict.Items.Add("Upper Siang");
            ddlDistrict.Items.Add("Upper Subansiri");
            ddlDistrict.Items.Add("West Kameng");
            ddlDistrict.Items.Add("West Siang");
            ddlDistrict.Items.Add("Upper Dibang Valley");
            ddlDistrict.Items.Add("Kurung Kumey");


        }
        else if (ddlstate.Text == "Assam")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Baksa");
            ddlDistrict.Items.Add("Barpeta");
            ddlDistrict.Items.Add("Bongaigaon");
            ddlDistrict.Items.Add("Cachar");
            ddlDistrict.Items.Add("Chirang");
            ddlDistrict.Items.Add("Darrang");
            ddlDistrict.Items.Add("Dhemaji");
            ddlDistrict.Items.Add("Dhubri");
            ddlDistrict.Items.Add("Dibrugarh");
            ddlDistrict.Items.Add("Goalpara");
            ddlDistrict.Items.Add("Golaghat");
            ddlDistrict.Items.Add("Hailakandi");
            ddlDistrict.Items.Add("Jorhat");
            //    ddlDistrict.Items.Add("Kamrup");
            ddlDistrict.Items.Add("Karbi Anglong");
            ddlDistrict.Items.Add("Karimganj");
            ddlDistrict.Items.Add("Kokrajhar");
            ddlDistrict.Items.Add("Lakhimpur ");

            ddlDistrict.Items.Add("Marigaon");
            ddlDistrict.Items.Add("Nagaon");
            ddlDistrict.Items.Add("Nalbari");
            ddlDistrict.Items.Add("Dima Hasao");
            ddlDistrict.Items.Add("Sivasagar");
            ddlDistrict.Items.Add("Sonitpur");
            ddlDistrict.Items.Add("Tinsukia");
            ddlDistrict.Items.Add("Kamrup Metro");
            ddlDistrict.Items.Add("Udalguri");
        }

        else if (ddlstate.Text == "Bihar")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Araria");
            ddlDistrict.Items.Add("Arwal");
            ddlDistrict.Items.Add("Aurangabad");
            ddlDistrict.Items.Add("Banka");
            ddlDistrict.Items.Add("Begusarai");
            ddlDistrict.Items.Add("Bhagalpur");
            ddlDistrict.Items.Add("Bhojpur");
            ddlDistrict.Items.Add("Buxar");
            ddlDistrict.Items.Add("East Champaran");
            ddlDistrict.Items.Add("Gaya");
            ddlDistrict.Items.Add(" Gopalganj");
            ddlDistrict.Items.Add("Jamui");
            ddlDistrict.Items.Add("Jehanabad");
            //    ddlDistrict.Items.Add("Kamrup");
            ddlDistrict.Items.Add("Kaimur");
            ddlDistrict.Items.Add("Katihar");
            ddlDistrict.Items.Add("Khagaria");
            ddlDistrict.Items.Add("Kishanganj ");

            ddlDistrict.Items.Add("Lakhisarai");
            ddlDistrict.Items.Add("Madhepura");


            ddlDistrict.Items.Add("Madhubani");
            ddlDistrict.Items.Add("Munger");
            ddlDistrict.Items.Add("Muzaffarpur");
            ddlDistrict.Items.Add("Nalanda");
            ddlDistrict.Items.Add("Nawada");
            ddlDistrict.Items.Add("Patna");
            ddlDistrict.Items.Add("Purnia");

            ddlDistrict.Items.Add("Rohtas");
            ddlDistrict.Items.Add("Saharsa");
            ddlDistrict.Items.Add("Samastipur");
            ddlDistrict.Items.Add("Saran");
            ddlDistrict.Items.Add("Sheikhpura");
            ddlDistrict.Items.Add("Sheohar");
            ddlDistrict.Items.Add("Sitamarhi");

            ddlDistrict.Items.Add("Siwan");
            ddlDistrict.Items.Add("Supaul");
            ddlDistrict.Items.Add("Vaishali");
            ddlDistrict.Items.Add("West Champaran");

        }
        else if (ddlstate.Text == "Chattisgardh")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Balod");
            ddlDistrict.Items.Add("Baloda Bazar");
            ddlDistrict.Items.Add("Balrampur");
            ddlDistrict.Items.Add("Bastar");
            ddlDistrict.Items.Add("Bemetara");
            ddlDistrict.Items.Add("Bijapur");
            ddlDistrict.Items.Add("Bilaspur");
            ddlDistrict.Items.Add("Dantewada");
            ddlDistrict.Items.Add("Dhamtari");
            ddlDistrict.Items.Add("Durg");
            ddlDistrict.Items.Add("Gariaband");
            ddlDistrict.Items.Add("Janjgir-Champa");
            ddlDistrict.Items.Add("Jashpur");
            //    ddlDistrict.Items.Add("Kamrup");
            ddlDistrict.Items.Add("Kanker");
            ddlDistrict.Items.Add("Kawardha");
            ddlDistrict.Items.Add("Kondagaon");
            ddlDistrict.Items.Add("Korba ");

            ddlDistrict.Items.Add("Koriya");
            ddlDistrict.Items.Add("Mahasamund");
            ddlDistrict.Items.Add("Mungeli");
            ddlDistrict.Items.Add("Narayanpur");
            ddlDistrict.Items.Add("Raigarh");
            ddlDistrict.Items.Add("Raipur");
            ddlDistrict.Items.Add("Sukma");
            ddlDistrict.Items.Add("Surajpur");
            ddlDistrict.Items.Add("Surguja");
        }
        else if (ddlstate.Text == "Goa")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("North Goa");
            ddlDistrict.Items.Add("South Goa");
        }
        else if (ddlstate.Text == "Gujarat")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Ahmedabad");
            ddlDistrict.Items.Add("Amreli District");
            ddlDistrict.Items.Add("Anand");
            ddlDistrict.Items.Add("Banaskantha");
            ddlDistrict.Items.Add("Bharuch");
            ddlDistrict.Items.Add("Bhavnagar");
            ddlDistrict.Items.Add("Dahod");
            ddlDistrict.Items.Add("Gandhinagar");
            ddlDistrict.Items.Add("Jamnagar");
            ddlDistrict.Items.Add("Junagadh");
            ddlDistrict.Items.Add("Kheda");
            ddlDistrict.Items.Add("Mehsana");
            ddlDistrict.Items.Add("Narmada");
            //    ddlDistrict.Items.Add("Kamrup");
            ddlDistrict.Items.Add("Navsari");
            ddlDistrict.Items.Add("Panchmahal");
            ddlDistrict.Items.Add("Patan");
            ddlDistrict.Items.Add("Porbandar ");
            ddlDistrict.Items.Add("Rajkot");
            ddlDistrict.Items.Add("Sabarkantha");
            ddlDistrict.Items.Add("Surat");
            ddlDistrict.Items.Add("Surendranagar");
            ddlDistrict.Items.Add("Tapi");
            ddlDistrict.Items.Add("The Dangs");
            ddlDistrict.Items.Add("Vadodara");
            ddlDistrict.Items.Add("Valsad");
        }

        else if (ddlstate.Text == "Haryana")
        {

            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Ambala");
            ddlDistrict.Items.Add("Bhiwani");
            ddlDistrict.Items.Add("Faridabad");
            ddlDistrict.Items.Add("Fatehabad");
            ddlDistrict.Items.Add("Hisar");
            ddlDistrict.Items.Add("Jhajjar");
            ddlDistrict.Items.Add("Jind");
            ddlDistrict.Items.Add("Kaithal");
            ddlDistrict.Items.Add("Karnal");
            ddlDistrict.Items.Add("Kurukshetra");
            ddlDistrict.Items.Add("Mahendragarh");
            ddlDistrict.Items.Add("Mewat");
            ddlDistrict.Items.Add("Palwal");
            //    ddlDistrict.Items.Add("Kamrup");
            ddlDistrict.Items.Add("Panchkula");
            ddlDistrict.Items.Add("Panipat");
            ddlDistrict.Items.Add("Rohtak");
            ddlDistrict.Items.Add("Sirsa");
            ddlDistrict.Items.Add("Sonipat");
            ddlDistrict.Items.Add(" Yamuna Nagar");
        }

        else if (ddlstate.Text == "Himachal Pradesh")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Bilaspur");
            ddlDistrict.Items.Add("Chamba");
            ddlDistrict.Items.Add("Kangra");
            ddlDistrict.Items.Add("Kinnaur");
            ddlDistrict.Items.Add("Kullu");
            ddlDistrict.Items.Add("Lahaul and Spiti");
            ddlDistrict.Items.Add("Mandi");
            ddlDistrict.Items.Add("Shimla");
            ddlDistrict.Items.Add("Sirmaur");
            ddlDistrict.Items.Add("Solan");
            ddlDistrict.Items.Add("Una");
        }
        else if (ddlstate.Text == "Jammu and Kashmir")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Anantnag");
            ddlDistrict.Items.Add("Bandipora");
            ddlDistrict.Items.Add("Baramulla");
            ddlDistrict.Items.Add("Budgam");
            ddlDistrict.Items.Add("Doda");
            ddlDistrict.Items.Add("Ganderbal");
            ddlDistrict.Items.Add("Jammu");
            ddlDistrict.Items.Add("Kargil");
            ddlDistrict.Items.Add("Kathua");
            ddlDistrict.Items.Add("Kishtwar");
            ddlDistrict.Items.Add("Kulgam");

            ddlDistrict.Items.Add("Kupwara");
            ddlDistrict.Items.Add("Leh");
            ddlDistrict.Items.Add("Poonch");
            ddlDistrict.Items.Add("Pulwama");
            ddlDistrict.Items.Add("Rajouri");
            ddlDistrict.Items.Add("Ramban");
            ddlDistrict.Items.Add("Reasi");
            ddlDistrict.Items.Add("Samba");
            ddlDistrict.Items.Add("Shopian");
            ddlDistrict.Items.Add("Srinagar");
            ddlDistrict.Items.Add("Udhampur");
        }

        else if (ddlstate.Text == "Jharkhand")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Bokaro");
            ddlDistrict.Items.Add("Chaibasa(West Singhbhum)");
            ddlDistrict.Items.Add("Chatra");
            ddlDistrict.Items.Add("Dhanbad");
            ddlDistrict.Items.Add("Dumka");
            ddlDistrict.Items.Add("Garhwa");
            ddlDistrict.Items.Add("Giridih");
            ddlDistrict.Items.Add("Godda");
            ddlDistrict.Items.Add("Gumla");
            ddlDistrict.Items.Add("Hazaribagh ");
            ddlDistrict.Items.Add("Jamshedpur(East Singhbhum)");
            ddlDistrict.Items.Add("Jamtara");
            ddlDistrict.Items.Add("Kharsawan");
            ddlDistrict.Items.Add("Koderma");
            ddlDistrict.Items.Add("Latehar");
            ddlDistrict.Items.Add("Lohardaga");
            ddlDistrict.Items.Add("Pakur");
            ddlDistrict.Items.Add("Palamu");
            ddlDistrict.Items.Add("Ranchi");
            ddlDistrict.Items.Add("Sahebganj");
            ddlDistrict.Items.Add("Saraikela");
            ddlDistrict.Items.Add("Simdega");
        }
        else if (ddlstate.Text == "Karnataka")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Bagalkot");
            ddlDistrict.Items.Add("Bangalore Urban");
            ddlDistrict.Items.Add("Bangalore Rural");
            ddlDistrict.Items.Add("Bellary");
            ddlDistrict.Items.Add("Bidar");
            ddlDistrict.Items.Add("Bijapur");
            ddlDistrict.Items.Add("Chamarajanagar");
            ddlDistrict.Items.Add("Chikballapur");
            ddlDistrict.Items.Add("Chikmagalur");
            ddlDistrict.Items.Add("Chitradurga");
            ddlDistrict.Items.Add("Dakshina Kannada");
            ddlDistrict.Items.Add("Davanagere");
            ddlDistrict.Items.Add("Dharwad");
            ddlDistrict.Items.Add("Gadag");
            ddlDistrict.Items.Add("Gulbarga");
            ddlDistrict.Items.Add("Hassan");
            ddlDistrict.Items.Add("Haveri");
            ddlDistrict.Items.Add("Kodagu");
            ddlDistrict.Items.Add("Kolar");
            ddlDistrict.Items.Add("Koppal");
            ddlDistrict.Items.Add("Mandya");
            ddlDistrict.Items.Add("Mysore");
            ddlDistrict.Items.Add("Raichur");
            ddlDistrict.Items.Add("Ramanagara");
            ddlDistrict.Items.Add("Shimoga");
            ddlDistrict.Items.Add("Tumkur");
            ddlDistrict.Items.Add("Udupi");
            ddlDistrict.Items.Add("Uttara Kannada");
            ddlDistrict.Items.Add("Yadgir");
        }
        else if (ddlstate.Text == "Kerala")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Alappuzha");
            ddlDistrict.Items.Add("Eranakulam");
            ddlDistrict.Items.Add("Idukki");
            ddlDistrict.Items.Add("Kannur");
            ddlDistrict.Items.Add("Kasargod");
            ddlDistrict.Items.Add("Kollam");
            ddlDistrict.Items.Add("Kottayam");
            ddlDistrict.Items.Add("Kozhikode");
            ddlDistrict.Items.Add("Mallapuram");
            ddlDistrict.Items.Add("Palakkad");
            ddlDistrict.Items.Add("Pathanamthitta");
            ddlDistrict.Items.Add("Thiruvananthapuram");
            ddlDistrict.Items.Add("Thrissur");
            ddlDistrict.Items.Add("Wayanad");

        }
        else if (ddlstate.Text == "Madhya Pradesh")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Alirajpur");
            ddlDistrict.Items.Add("Anuppur");
            ddlDistrict.Items.Add("Ashoknagar");
            ddlDistrict.Items.Add("Balaghat");
            ddlDistrict.Items.Add("Barwani");
            ddlDistrict.Items.Add("Betul");
            ddlDistrict.Items.Add("Bhind");
            ddlDistrict.Items.Add("Bhopal ");
            ddlDistrict.Items.Add("Burhanpur");
            ddlDistrict.Items.Add("Chhatarpur");
            ddlDistrict.Items.Add("Chhindwara");
            ddlDistrict.Items.Add("Damoh");
            ddlDistrict.Items.Add("Datia");
            //    ddlDistrict.Items.Add("Kamrup");
            ddlDistrict.Items.Add("Dewas");
            ddlDistrict.Items.Add("Dhar");
            ddlDistrict.Items.Add("Dindori");
            ddlDistrict.Items.Add("Guna");

            ddlDistrict.Items.Add("Gwalior");
            ddlDistrict.Items.Add("Harda");
            ddlDistrict.Items.Add("Hoshangabad");
            ddlDistrict.Items.Add("Indore");

            ddlDistrict.Items.Add("Jabalpur");
            ddlDistrict.Items.Add("Jhabua");
            ddlDistrict.Items.Add("Katni");
            ddlDistrict.Items.Add("Khandwa");
            ddlDistrict.Items.Add("Khargone");
            ddlDistrict.Items.Add("Mandla");
            ddlDistrict.Items.Add("Mandsaur");
            ddlDistrict.Items.Add("Morena");
            ddlDistrict.Items.Add("Narsinghpur");
            ddlDistrict.Items.Add("Neemuch");
            ddlDistrict.Items.Add("Panna");
            ddlDistrict.Items.Add("Raisen");
            ddlDistrict.Items.Add("Rajgarh");
            ddlDistrict.Items.Add("Ratlam");
            ddlDistrict.Items.Add("Rewa");
            ddlDistrict.Items.Add("Sagar");
            ddlDistrict.Items.Add("Satna");
            ddlDistrict.Items.Add("Sehore");
            ddlDistrict.Items.Add("Seoni");
            ddlDistrict.Items.Add("Singrauli");

            ddlDistrict.Items.Add("Shahdol");
            ddlDistrict.Items.Add("Shajapur");
            ddlDistrict.Items.Add("Sheopur");
            ddlDistrict.Items.Add("Shivpuri");

            ddlDistrict.Items.Add("Sidhi");
            ddlDistrict.Items.Add("Tikamgarh");
            ddlDistrict.Items.Add("Ujjain");
            ddlDistrict.Items.Add("Umaria");
            ddlDistrict.Items.Add("Vidisha");
        }
        else if (ddlstate.Text == "Maharashtra")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Ahmednagar");
            ddlDistrict.Items.Add("Akola");
            ddlDistrict.Items.Add("Amravati");
            ddlDistrict.Items.Add("Aurangabad");
            ddlDistrict.Items.Add("Beed");
            ddlDistrict.Items.Add("Bhandara");
            ddlDistrict.Items.Add("Buldhana");
            ddlDistrict.Items.Add("Chandrapur");
            ddlDistrict.Items.Add("Dhule");
            ddlDistrict.Items.Add("Gadchiroli");
            ddlDistrict.Items.Add("Gondia");
            ddlDistrict.Items.Add("Hingoli");
            ddlDistrict.Items.Add("Jalgaon");
            ddlDistrict.Items.Add("Jalna");
            ddlDistrict.Items.Add("Kolhapur");
            ddlDistrict.Items.Add("Latur");
            ddlDistrict.Items.Add("Mumbai Surburban");
            ddlDistrict.Items.Add("Nagpur");

            ddlDistrict.Items.Add("Nanded");
            ddlDistrict.Items.Add("Nashik");
            ddlDistrict.Items.Add("Nundarbar");
            ddlDistrict.Items.Add("Osmanabad");
            ddlDistrict.Items.Add("Parbhani");
            ddlDistrict.Items.Add("Pune");
            ddlDistrict.Items.Add("Raigarh");
            ddlDistrict.Items.Add("Ratnagiri");
            ddlDistrict.Items.Add("Sangli");
            ddlDistrict.Items.Add("Satara");
            ddlDistrict.Items.Add("Sindhudurg");
            ddlDistrict.Items.Add("Solapur");
            ddlDistrict.Items.Add("Thane");
            ddlDistrict.Items.Add("Wardha");
            ddlDistrict.Items.Add("Washim");
            ddlDistrict.Items.Add("Yavatmal");
        }
        else if (ddlstate.Text == "Manipur")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Bishnupur");
            ddlDistrict.Items.Add("Chandel");
            ddlDistrict.Items.Add("Churachandpur");
            ddlDistrict.Items.Add("Imphal East");
            ddlDistrict.Items.Add("Imphal West");
            ddlDistrict.Items.Add("Senapati");
            ddlDistrict.Items.Add("Tamenglong");
            ddlDistrict.Items.Add("Thoubal");
            ddlDistrict.Items.Add("Ukhrul");



        }
        else if (ddlstate.Text == "Meghalaya")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("East Garo Hills/North Garo Hills");
            ddlDistrict.Items.Add("East Khasi Hills");
            ddlDistrict.Items.Add("Jaintia Hills/East Jaintia Hills");
            ddlDistrict.Items.Add("Ri-Bhoi");
            ddlDistrict.Items.Add("South Garo Hills");
            ddlDistrict.Items.Add("West Garo Hills/South West Garo Hills");
            ddlDistrict.Items.Add("West Khasi Hills/South West Khasi Hills");




        }
        else if (ddlstate.Text == "Mizoram")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Aizawl");
            ddlDistrict.Items.Add("Champhai");

            ddlDistrict.Items.Add("Kolasib");
            ddlDistrict.Items.Add("Lawngtlai");
            ddlDistrict.Items.Add("Lunglei");
            ddlDistrict.Items.Add("Mamit");
            ddlDistrict.Items.Add("Saiha");

            ddlDistrict.Items.Add("Serchhip");

        }

        else if (ddlstate.Text == "Nagaland")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Dimapur");
            ddlDistrict.Items.Add("Kiphire");

            ddlDistrict.Items.Add("Kohima");
            ddlDistrict.Items.Add("Longleng");
            ddlDistrict.Items.Add("Mokokchung");
            ddlDistrict.Items.Add("Mon");
            ddlDistrict.Items.Add("Peren");

            ddlDistrict.Items.Add("Phek");
            ddlDistrict.Items.Add("Tuensang");
            ddlDistrict.Items.Add("Wokha");

            ddlDistrict.Items.Add("Zunheboto");

        }
        else if (ddlstate.Text == "Orissa")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Angul");
            ddlDistrict.Items.Add("Balangir");

            ddlDistrict.Items.Add("Balasore");
            ddlDistrict.Items.Add("Bargarh");
            ddlDistrict.Items.Add("Bhadrak");
            ddlDistrict.Items.Add("Boudh (Bauda)");
            ddlDistrict.Items.Add("Cuttack");

            ddlDistrict.Items.Add("Debagarh (Deogarh)");
            ddlDistrict.Items.Add("Dhenkanal");
            ddlDistrict.Items.Add("Gajapati");

            ddlDistrict.Items.Add("Ganjam");

            ddlDistrict.Items.Add("Jagatsinghpur");

            ddlDistrict.Items.Add("Jajapur (Jajpur)");
            ddlDistrict.Items.Add("Jharsuguda");
            ddlDistrict.Items.Add("Kalahandi");

            ddlDistrict.Items.Add("Kandhamal");

            ddlDistrict.Items.Add("Kendrapara");

            ddlDistrict.Items.Add("Kendujhar (Keonjhar)");
            ddlDistrict.Items.Add("Khordha");
            ddlDistrict.Items.Add("Koraput");

            ddlDistrict.Items.Add("Malkangiri");

            ddlDistrict.Items.Add("Mayurbhanj");
            ddlDistrict.Items.Add("Nabarangpur");
            ddlDistrict.Items.Add("Nayagarh");

            ddlDistrict.Items.Add("Nuapada");
            ddlDistrict.Items.Add("Puri");
            ddlDistrict.Items.Add("Rayagada");
            ddlDistrict.Items.Add("Sambalpur");

            ddlDistrict.Items.Add("Subarnapur");
            ddlDistrict.Items.Add("Sundergarh");

        }


        else if (ddlstate.Text == "Punjab")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Amritsar");
            ddlDistrict.Items.Add("Barnala");

            ddlDistrict.Items.Add("Bathinda");
            ddlDistrict.Items.Add("Faridkot");
            ddlDistrict.Items.Add("Fatehgarh Sahib");
            ddlDistrict.Items.Add("Ferozepur");
            ddlDistrict.Items.Add("Fazilka");

            ddlDistrict.Items.Add("Gurdaspur");
            ddlDistrict.Items.Add("Hoshiarpur");
            ddlDistrict.Items.Add("Jalandhar");

            ddlDistrict.Items.Add("Kapurthala");

            ddlDistrict.Items.Add("Ludhiana");

            ddlDistrict.Items.Add("Mansa");
            ddlDistrict.Items.Add("Moga");
            ddlDistrict.Items.Add("Muktsar");

            ddlDistrict.Items.Add("Pathankot");

            ddlDistrict.Items.Add("Rupnagar");

            ddlDistrict.Items.Add("Mohali");
            ddlDistrict.Items.Add("Shahid Bhagat Singh Nagar (Nawanshahr)");
            ddlDistrict.Items.Add("Tarn Taran");

        }
        else if (ddlstate.Text == "Rajastan")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Ajmer");
            ddlDistrict.Items.Add("Alwar");

            ddlDistrict.Items.Add("Banswara");
            ddlDistrict.Items.Add("Baran");
            ddlDistrict.Items.Add("Barmer");
            ddlDistrict.Items.Add("Bharatpur");
            ddlDistrict.Items.Add("Bhilwara");

            ddlDistrict.Items.Add("Bikaner");
            ddlDistrict.Items.Add("Bundi");
            ddlDistrict.Items.Add("Chittorgarh");

            ddlDistrict.Items.Add("Churu");

            ddlDistrict.Items.Add("Dausa");

            ddlDistrict.Items.Add("Dholpur");
            ddlDistrict.Items.Add("Dungarpur");

            ddlDistrict.Items.Add("Hanumangarh");

            ddlDistrict.Items.Add("Jaipur");

            ddlDistrict.Items.Add("Jaisalmer");

            ddlDistrict.Items.Add("Jalor");
            ddlDistrict.Items.Add("Jhalawar");
            ddlDistrict.Items.Add("Jhunjhunu");

            ddlDistrict.Items.Add("Jodhpur");
            ddlDistrict.Items.Add("Karauli");
            ddlDistrict.Items.Add("Kota");

            ddlDistrict.Items.Add("Nagaur");
            ddlDistrict.Items.Add("Pali");
            ddlDistrict.Items.Add("Pratapgarh");

            ddlDistrict.Items.Add("Rajsamand");
            ddlDistrict.Items.Add("Sawai Madhopur");
            ddlDistrict.Items.Add("Sikar  Sirohi");
            ddlDistrict.Items.Add("Sri Ganganagar");
            ddlDistrict.Items.Add("Tonk");
            ddlDistrict.Items.Add("Udaipur");
            ddlDistrict.Items.Add("Rajasthan");
        }
        else if (ddlstate.Text == "Sikkim")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("East Sikkim");
            ddlDistrict.Items.Add("North Sikkim");

            ddlDistrict.Items.Add("South Sikkim");
            ddlDistrict.Items.Add("West Sikkim");
        }

        else if (ddlstate.Text == "Tamil Nadu")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Ariyalur");
            ddlDistrict.Items.Add("Chennai");

            ddlDistrict.Items.Add("Coimbatore");
            ddlDistrict.Items.Add("Cuddalore");
            ddlDistrict.Items.Add("Dharmapuri");
            ddlDistrict.Items.Add("Dindigul");

            ddlDistrict.Items.Add("Erode");
            ddlDistrict.Items.Add("Kanchipuram");
            ddlDistrict.Items.Add("Kanniyakumari");
            ddlDistrict.Items.Add("Karur");

            ddlDistrict.Items.Add("Krishnagiri");
            ddlDistrict.Items.Add("Madurai");
            ddlDistrict.Items.Add("Nagapattinam");
            ddlDistrict.Items.Add("Namakkal");

            ddlDistrict.Items.Add("Nilgiris");
            ddlDistrict.Items.Add("Perambalur");


            ddlDistrict.Items.Add("Pudukkottai");
            ddlDistrict.Items.Add("Ramanathapuram");
            ddlDistrict.Items.Add("Salem");
            ddlDistrict.Items.Add("Sivaganga");

            ddlDistrict.Items.Add("Thanjavur");
            ddlDistrict.Items.Add("Theni");
            ddlDistrict.Items.Add("Thoothukudi");
            ddlDistrict.Items.Add("Thiruvarur");

            ddlDistrict.Items.Add("Tirunelveli");
            ddlDistrict.Items.Add("Tiruchirappalli");

            ddlDistrict.Items.Add("Thiruvallur");
            ddlDistrict.Items.Add("Tiruppur");
            ddlDistrict.Items.Add("Tiruvannamalai");
            ddlDistrict.Items.Add(" Vellore");

            ddlDistrict.Items.Add("Villupuram");
            ddlDistrict.Items.Add("Virudhunagar");


        }

        else if (ddlstate.Text == "Tripura")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Dhalai");
            ddlDistrict.Items.Add("Gomati");
            ddlDistrict.Items.Add("Khowai");
            ddlDistrict.Items.Add("North Tripura");

            ddlDistrict.Items.Add("Sipahijala");

            ddlDistrict.Items.Add("South Tripura");

            ddlDistrict.Items.Add("Unakoti");


            ddlDistrict.Items.Add("West Tripura");
        }


        else if (ddlstate.Text == "Uttar Pradesh")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Agra");
            ddlDistrict.Items.Add("Aligarh");
            ddlDistrict.Items.Add("Allahabad");
            ddlDistrict.Items.Add("Auraiya");
            ddlDistrict.Items.Add("Azamgarh");
            ddlDistrict.Items.Add("Baghpat");
            ddlDistrict.Items.Add("Bahraich");
            ddlDistrict.Items.Add("Ballia");

            ddlDistrict.Items.Add("Balrampur");
            ddlDistrict.Items.Add("Banda");
            ddlDistrict.Items.Add("Barabanki");
            ddlDistrict.Items.Add("Bareilly");
            ddlDistrict.Items.Add("Basti");
            ddlDistrict.Items.Add("Bijnor");
            ddlDistrict.Items.Add("Budaun");
            ddlDistrict.Items.Add("Bulandshahar");
            ddlDistrict.Items.Add("Chandauli");
            ddlDistrict.Items.Add("Chitrakoot");
            ddlDistrict.Items.Add("Deoria");
            ddlDistrict.Items.Add("Etah ");
            ddlDistrict.Items.Add("Etawah");
            ddlDistrict.Items.Add("Faizabad");
            ddlDistrict.Items.Add("Farukkhabad");
            ddlDistrict.Items.Add("Fatehpur");

            ddlDistrict.Items.Add("Firozabad");
            ddlDistrict.Items.Add("Gautam Buddha Nagar");
            ddlDistrict.Items.Add("Ghaziabad");
            ddlDistrict.Items.Add("Ghazipur");
            ddlDistrict.Items.Add("Gonda");
            ddlDistrict.Items.Add("Gorakhpur");
            ddlDistrict.Items.Add("Hamirpur");
            ddlDistrict.Items.Add("Hardoi");
            ddlDistrict.Items.Add("Hathras");
            ddlDistrict.Items.Add("Jalaun");

            ddlDistrict.Items.Add("Jaunpur");
            ddlDistrict.Items.Add("Jhansi");
            ddlDistrict.Items.Add("Jyotiba Phoole Nagar");
            ddlDistrict.Items.Add("Kannauj");
            ddlDistrict.Items.Add("Kanpur Dehat");
            ddlDistrict.Items.Add("Kanpur Nagar");
            ddlDistrict.Items.Add("Kaushambi");
            ddlDistrict.Items.Add("Kushi Nagar (Padrauna)");
            ddlDistrict.Items.Add("Hathras");
            ddlDistrict.Items.Add(" Lakhimpur Kheri");
            ddlDistrict.Items.Add("Lalitpur");
            ddlDistrict.Items.Add("Lucknow");
            ddlDistrict.Items.Add("Maharajganj");
            ddlDistrict.Items.Add("Mahoba");
            ddlDistrict.Items.Add("Mainpuri");
            ddlDistrict.Items.Add("Mathura");
            ddlDistrict.Items.Add("MAU");
            ddlDistrict.Items.Add("Meerut");
            ddlDistrict.Items.Add("Mirzapur");
            ddlDistrict.Items.Add("Moradabad");

            ddlDistrict.Items.Add("Muzaffar Nagar");
            ddlDistrict.Items.Add("Pilibhit");
            ddlDistrict.Items.Add("Pratapgarh");

            ddlDistrict.Items.Add("Raebareli");
            ddlDistrict.Items.Add("Rampur");
            ddlDistrict.Items.Add("Saharanpur");
            ddlDistrict.Items.Add("Sant Kabir Nagar");
            ddlDistrict.Items.Add("Sant Ravidas Nagar");
            ddlDistrict.Items.Add("Shahjahanpur");

            ddlDistrict.Items.Add("Shravasti");
            ddlDistrict.Items.Add("Siddharth Nagar");
            ddlDistrict.Items.Add("Sitapur");
            ddlDistrict.Items.Add("Sonbhadra");

            ddlDistrict.Items.Add("Sultanpur");
            ddlDistrict.Items.Add("Unnao");
            ddlDistrict.Items.Add("Varanasi");
        }
        else if (ddlstate.Text == "Uttarakhand")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Almora");
            ddlDistrict.Items.Add("Bageshwar");
            ddlDistrict.Items.Add("Chamoli");
            ddlDistrict.Items.Add("Champawat");

            ddlDistrict.Items.Add("Dehradun");
            ddlDistrict.Items.Add("Haridwar");
            ddlDistrict.Items.Add("Nainital");
            ddlDistrict.Items.Add("Pauri Garhwal");

            ddlDistrict.Items.Add("Pithoragarh");
            ddlDistrict.Items.Add("Rudra Prayag");
            ddlDistrict.Items.Add("Udham Singh Nagar");
            ddlDistrict.Items.Add("Uttarkashi");
        }
        else if (ddlstate.Text == "West Bengal")
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add("--Select District--");
            ddlDistrict.Items.Add("Bankura");
            ddlDistrict.Items.Add("Bardhaman");
            ddlDistrict.Items.Add("Birbhum");
            ddlDistrict.Items.Add("Cooch Behar");

            ddlDistrict.Items.Add("Darjeeling");
            ddlDistrict.Items.Add("East Midnapore");


            ddlDistrict.Items.Add("Hooghly");
            ddlDistrict.Items.Add("Howrah");

            ddlDistrict.Items.Add("Maldah");
            ddlDistrict.Items.Add("Murshidabad");
            ddlDistrict.Items.Add("Nadia");
            ddlDistrict.Items.Add("North 24 Parganas");

            ddlDistrict.Items.Add("North Dinajpur");
            ddlDistrict.Items.Add("Purulia");
            ddlDistrict.Items.Add("South 24 Parganas");
            ddlDistrict.Items.Add("South Dinajpur");

            ddlDistrict.Items.Add("West Midnapore");

        }
    }

    
}

