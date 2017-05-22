using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using School.Admin;

namespace School.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["SQLCON"].ConnectionString;
        Cryptography cryptography = new Cryptography();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] != null)
            {
                Response.Redirect("~/Admin/Home.aspx");
            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM AdminData", con);
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            if (sdr[3].ToString().Equals(UserName.Text.Trim()) &&
                                cryptography.Decrypt(sdr[4].ToString()).Equals(Password.Text.Trim()))
                            {
                                Response.Cookies["AdminName"].Value = cryptography.Encrypt(sdr[3].ToString());
                                Response.Cookies["AdminID"].Value = cryptography.Encrypt(sdr[0].ToString());

                                Session["Role"] = sdr[5].ToString();
                                Response.Redirect("~/Admin/Home.aspx");
                            }
                            else
                            {
                                ErrorMassage.Text = "username and password are invalid";
                            }
                        }
                    }
                }
            }
            else
            {
                ErrorMassage.Text = "Validation Error";
            }
        }
    }
}