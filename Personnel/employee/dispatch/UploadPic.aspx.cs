using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Personnel_customer_UploadPic : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../../SignUpLogin.aspx';</script>");
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
    }
    protected void btnUploadPro_Click(object sender, EventArgs e)
    {
        string filename = string.Empty;
        try
        {
            if (!fupProPic.HasFile)
            {
                ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('Please select a picture');", true);

                return;
            }
            else
            {
                string ffileExt = System.IO.Path.GetExtension(fupProPic.FileName);
                if ((ffileExt == ".JPG") || (ffileExt == ".jpg") || (ffileExt == ".JPEG") || (ffileExt == ".jpeg") || (ffileExt == ".PNG") || (ffileExt == ".png"))
                {
                    filename = Session["empid"].ToString() + fupProPic.FileName.ToString();
                    int update_insp = dbc.Update_ProfilePicemp(Convert.ToInt32(Session["empid"].ToString()), filename);

                    if (update_insp == 1)
                    {
                        fupProPic.SaveAs(Server.MapPath("~/Personnel/employee/media/") + filename);
                        string js = string.Empty;
                        js += "window.opener.location.href='EditProfile.aspx';";
                        js += "window.close();";
                        ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", js, true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "MessageBox",
                        "alert('Data Not Inserted');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(
                  this,
                  this.GetType(),
                  "MessageBox",
                  "alert('Please select proper image as .jpg or .png');", true);
                    return;
                }

            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                this,
                this.GetType(),
                "MessageBox",
                "alert('Some error please try again');", true);
            return;
        }
    }
}