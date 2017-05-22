using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School.Admin
{
    public partial class BoardOfDirector : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LinkButtonInsurtOnClick(object sender, EventArgs eventArgs)
        {
            SqlDataSource1.InsertParameters["MemberName"].DefaultValue =
                ((TextBox) GridView1.FooterRow.FindControl("TextBoxName")).Text;

            SqlDataSource1.InsertParameters["Designation"].DefaultValue =
                ((TextBox)GridView1.FooterRow.FindControl("TextBoxDesignation")).Text;

            SqlDataSource1.InsertParameters["EducationalQualification"].DefaultValue =
                ((TextBox)GridView1.FooterRow.FindControl("TextBoxEQ")).Text;

            SqlDataSource1.InsertParameters["Category"].DefaultValue =
                ((TextBox)GridView1.FooterRow.FindControl("TextBoxCategory")).Text;

            SqlDataSource1.InsertParameters["Comment"].DefaultValue =
                ((TextBox)GridView1.FooterRow.FindControl("TextBoxComment")).Text;

            SqlDataSource1.Insert();
        }
    }
}