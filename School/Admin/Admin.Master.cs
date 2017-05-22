using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using School.Admin;

namespace School.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        Cryptography cryptography = new Cryptography();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string role = Session["Role"].ToString();
                LabelName.Text = "Welcome  " + cryptography.Decrypt(Request.Cookies["AdminName"].Value);
            }
        }
    }
}
