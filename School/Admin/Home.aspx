<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="School.Admin.Home" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            var windowHeight = $(window).height();/* get the browser visible height on screen */
            //var headerHeight = $('#myheader').height();/* get the header visible height on screen */
            var bodyHeight = $('#mybody').height();/* get the body visible height on screen */
            //var footerHeight = $('#myfooter').height();/* get the footer visible height on screen */
            var newBodyHeight = windowHeight - 150;
            if (newBodyHeight > 0 && newBodyHeight > bodyHeight) {
                $('#mybody').height(newBodyHeight);
            }
        });
</script>
    <div class="container" id="mybody">
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
            <div class="col-md-2 text-center">
                <asp:ImageButton ID="BoardOfDirector" runat="server" ImageUrl="../Content/Images/green-button.png" Height="100px" OnClick="BoardOfDirector_Click" />
                <h5 class="text-info">Board Of Director</h5>
            </div>
            <div class="col-md-2 text-center">
                <asp:ImageButton ID="Teachers" runat="server" ImageUrl="../Content/Images/green-button.png" Height="100px" OnClick="Teachers_Click" />
                <h5 class="text-info">Teacher</h5>
            </div>
            <div class="col-md-2 text-center">
                <asp:ImageButton ID="Employees" runat="server" ImageUrl="../Content/Images/green-button.png" Height="100px" />
                <h5 class="text-info">Employee</h5>
            </div>
            <div class="col-md-2 text-center">
                <asp:ImageButton ID="HeadTeacher" runat="server" ImageUrl="../Content/Images/green-button.png" Height="100px" />
                <h5 class="text-info">Head Teacher</h5>
            </div>
            <div class="col-md-2 text-center">
                <asp:ImageButton ID="Student" runat="server" ImageUrl="../Content/Images/green-button.png" Height="100px" />
                <h5 class="text-info">Student</h5>
            </div>
            <div class="col-md-2 text-center">
                <asp:ImageButton ID="Result" runat="server" ImageUrl="../Content/Images/green-button.png" Height="100px" />
                <h5 class="text-info">Result</h5>
            </div>
        </div>
    </div>
</asp:Content>
