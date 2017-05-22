using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using School.Admin;

namespace School.Admin
{
    public partial class EditAdmin : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["SQLCON"].ConnectionString;
        string Role { get; set; }
        string AdminId { get; set; }

        Cryptography cryptography = new Cryptography();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null)
            {
                Response.Redirect("~/Admin/Login.aspx");
            }
            else
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM AdminData WHERE AdminID = @AdminID", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    AdminId = cryptography.Decrypt(Request.Cookies["AdminID"].Value);
                    cmd.Parameters.AddWithValue("AdminID", AdminId);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (!IsPostBack)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            FirstName.Text = dt.Rows[0]["FirstName"].ToString();
                            LastName.Text = dt.Rows[0]["LastName"].ToString();
                            UserName.Text = dt.Rows[0]["UserName"].ToString();
                            TextBoxPassword.Text = cryptography.Decrypt(dt.Rows[0]["Password"].ToString());
                            Email.Text = dt.Rows[0]["Email"].ToString();
                            TextBoxPhone.Text = dt.Rows[0]["MobileNo"].ToString();
                        }
                    }
                    Role = dt.Rows[0]["Role"].ToString();
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE [dbo].[AdminData] SET FirstName = @FirstName, LastName = @LastName, UserName = @UserName, Password = @Password, Role = @Role, MobileNo = @MobileNo, Email = @Email WHERE (AdminID = @AdminID)", con);
                    cmd.Parameters.AddWithValue("FirstName", FirstName.Text);
                    cmd.Parameters.AddWithValue("LastName", LastName.Text);
                    cmd.Parameters.AddWithValue("UserName", UserName.Text);
                    cmd.Parameters.AddWithValue("Password", cryptography.Encrypt(TextBoxPassword.Text));
                    cmd.Parameters.AddWithValue("Role", Role);
                    cmd.Parameters.AddWithValue("MobileNo", TextBoxPhone.Text);
                    cmd.Parameters.AddWithValue("Email", Email.Text);
                    cmd.Parameters.AddWithValue("AdminID", AdminId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Massage.Text = "Account Edit Successfull";
                    //Thread.Sleep(5000);
                    //Response.Redirect("~/Admin/EditAdmin.aspx");
                }
            }
            else
            {
                ErrorMassage.Text = "Validation Failed! Data not saved";
            }
        }
    }
}