using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace School.Admin
{
    public partial class Teacher : System.Web.UI.Page
    {
        private string cs = ConfigurationManager.ConnectionStrings["SQLCON"].ConnectionString;
        string targetPath { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                PanelAddTeacher.Visible = false;
                PanelEditTeacher.Visible = false;
                Massage.Visible = false;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "-1")
            {
                PanelAddTeacher.Visible = false;
                PanelEditTeacher.Visible = false;
                Massage.Visible = true;
                Massage.Text = "Please Select a Continent";
            }
            else if(DropDownList1.SelectedValue == "Add Teacher")
            {
                PanelAddTeacher.Visible = true;
                PanelEditTeacher.Visible = false;
                Massage.Visible = false;
            }
            else if (DropDownList1.SelectedValue == "Edit Teacher Info")
            {
                PanelAddTeacher.Visible = false;
                PanelEditTeacher.Visible = true;
                Massage.Visible = false;
            }
        }

        protected void ResizeImage(double scaleFactor, Stream sourcePath, string targetPath)
        {
            using (var image = System.Drawing.Image.FromStream(sourcePath))
            {
                var newWidth = (int) (600);
                var newHeight = (int)(600);
                var resizing = new Bitmap(newWidth, newHeight);
                var resizeGraph = Graphics.FromImage(resizing);
                resizeGraph.CompositingQuality = CompositingQuality.HighQuality;
                resizeGraph.SmoothingMode = SmoothingMode.HighQuality;
                resizeGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var ImageRectangle = new Rectangle(0,0, newWidth, newHeight);
                resizeGraph.DrawImage(image, ImageRectangle);
                resizing.Save(targetPath, image.RawFormat);
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (DropDownListStatus.SelectedValue == "-1")
            {
                MassageStatus.Visible = true;
                MassageStatus.Text = "Status is Required";
            }
            else
            {
                string status = DropDownListStatus.SelectedValue;
                string EducationalQualification = TextBoxEducationalQualification.Text.Replace(Environment.NewLine,
                    "<br />");

                if (Page.IsValid)
                {
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        HttpPostedFile postedfileProPic = FileUploadImage.PostedFile;
                        string filenameProPic = Path.GetFileName(postedfileProPic.FileName);
                        string fileextentionProPic = Path.GetExtension(filenameProPic);

                        if (fileextentionProPic.ToLower() == ".jpg" || fileextentionProPic.ToLower() == ".bmp" ||
                                    fileextentionProPic.ToLower() == ".jpeg" || fileextentionProPic.ToLower() == ".png")
                        {
                            //string str = FileUploadProImage.FileName;
                            //FileUploadProImage.PostedFile.SaveAs(Server.MapPath("~/Content/Product/") + str);
                            //ProductPic = ("~/Content/Product/") + str.ToString();
                            targetPath = Server.MapPath("~/Content/Images/Teacher/" + filenameProPic);
                            Stream strm = FileUploadImage.PostedFile.InputStream;
                            var targetFile = targetPath;

                            ResizeImage(0.5, strm, targetFile);


                        }
                        else
                        {
                            MassageImg.Visible = true;
                            MassageImg.Text = "Only image (jpg, bmp, gif, png) can be uploaded";
                        }

                        SqlCommand cmd = new SqlCommand("INSERT INTO Teacher VALUES(@TeacherName, @Designation, @EducationalQualification, @DateOfBirth, @MobileNo, @ImagePath, @StartDate, @EndDate, @Status)", con);
                        cmd.Parameters.AddWithValue("TeacherName", TextBoxTeacherName.Text);
                        cmd.Parameters.AddWithValue("Designation", TextBoxDesignation.Text);
                        cmd.Parameters.AddWithValue("EducationalQualification", EducationalQualification);
                        cmd.Parameters.AddWithValue("DateOfBirth", TextBoxDateOfBirth.Text);
                        cmd.Parameters.AddWithValue("MobileNo", TextBoxMobileNo.Text);
                        cmd.Parameters.AddWithValue("ImagePath", targetPath);
                        cmd.Parameters.AddWithValue("StartDate", TextBoxStartDate.Text);
                        cmd.Parameters.AddWithValue("EndDate", TextBoxEndDate.Text);
                        cmd.Parameters.AddWithValue("Status", status);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect("~/Admin/Teacher.aspx");
                    }
                }
                else
                {
                    ErrorMassage.Text = "Validation Failed! Data not saved";
                }
            }
        }
    }
}