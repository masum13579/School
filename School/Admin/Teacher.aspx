<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="School.Admin.Teacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12 text-center">
                <h3>পরিচালনা কমিটির তথ্য (বর্তমান পরিচালনা কমিটি)</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <table>
                    <tr>
                        <td style="height: 100px"></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <h3>Teacher Panel</h3>
                <asp:DropDownList ID="DropDownList1" Width="100%" AutoPostBack="True" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem Value="-1">Select Option</asp:ListItem>
                    <asp:ListItem>Add Teacher</asp:ListItem>
                    <asp:ListItem>Edit Teacher Info</asp:ListItem>
                </asp:DropDownList>
                <p class="text-left">
                    <asp:Label ID="Massage" CssClass="text-danger" runat="server" Font-Size="Small"></asp:Label>
                </p>
                <asp:Panel ID="PanelAddTeacher" runat="server">
                    <h3>Add Teacher</h3>
                    <div class="form-group">
                        <label>Teacher Name</label>
                        <asp:TextBox ID="TextBoxTeacherName" CssClass="form-control" placeholder="Teacher Name" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBoxTeacherName" 
                            runat="server" ForeColor="red" ErrorMessage="Teacher Name is Required"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Teacher Designation</label>
                        <asp:TextBox ID="TextBoxDesignation" CssClass="form-control" placeholder="Teacher Designation" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBoxDesignation" 
                            runat="server" ForeColor="red" ErrorMessage="Teacher Designation is Required"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Educational Qualification</label>
                        <asp:TextBox ID="TextBoxEducationalQualification" CssClass="form-control" placeholder="Educational Qualification" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TextBoxEducationalQualification" 
                            runat="server" ForeColor="red" ErrorMessage="Educational Qualification is Required"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Date Of Birth</label>
                        <asp:TextBox ID="TextBoxDateOfBirth" CssClass="form-control" placeholder="Date Of Birth" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="TextBoxDateOfBirth" 
                            runat="server" ForeColor="red" ErrorMessage="Date Of Birth is Required"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Mobile No</label>
                        <asp:TextBox ID="TextBoxMobileNo" CssClass="form-control" placeholder="Mobile No" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="TextBoxMobileNo" 
                            runat="server" ForeColor="red" ErrorMessage="Mobile No is Required"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Picture</label>
                        <asp:FileUpload ID="FileUploadImage" runat="server" />
                        <asp:Label ID="LableProInf" runat="server" Text="Only image (jpg, bmp, gif, png) can be uploaded, image size maximum 4 mb" Font-Size="X-Small" CssClass="text-success"></asp:Label><br/>
                        <asp:Label ID="MassageImg" runat="server" Font-Size="Small" Visible="False" CssClass="text-danger"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" ControlToValidate="FileUploadImage" 
                            runat="server" ForeColor="red" ErrorMessage="Image is Required"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Start Date</label>
                        <asp:TextBox ID="TextBoxStartDate" CssClass="form-control" placeholder="Start Date" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="TextBoxStartDate" 
                            runat="server" ForeColor="red" ErrorMessage="Start Date is Required"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>End Date</label>
                        <asp:TextBox ID="TextBoxEndDate" CssClass="form-control" placeholder="End Date" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Status</label>
                        <asp:DropDownList ID="DropDownListStatus" CssClass="form-control" runat="server">
                            <asp:ListItem Value="-1">Select Option</asp:ListItem>
                            <asp:ListItem Value="retired">অবসরপ্রাপ্ত</asp:ListItem>
                            <asp:ListItem Value="Running">চলমান</asp:ListItem>
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="MassageStatus" runat="server" Font-Size="Small" Visible="False" CssClass="text-danger"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="DropDownListStatus"
                             runat="server" ForeColor="red" ErrorMessage="Status is Required"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="ErrorMassage" runat="server" Font-Size="Small" CssClass="text-danger"></asp:Label><br/>
                        <asp:Button ID="Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Submit_Click" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="PanelEditTeacher" runat="server"></asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
