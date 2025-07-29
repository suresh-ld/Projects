<%@ Page Title="User Registration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="GOVTSTATEDET._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div style="width: 500px; margin: auto; padding: 30px; border: 1px solid #ccc; border-radius: 10px; text-align: center;">
        <img src="download.png" alt="Description" style="width: 100px; height: auto;" />
        <br />
        <h2>User Registration</h2>

        <div style="margin-bottom: 15px;">
            <asp:Label ID="lblName" runat="server" Text="Name:" Font-Bold="true" /><br />
            <asp:TextBox ID="txtName" runat="server" style="width: 80%; text-align: center;" />
        </div>

        <div style="margin-bottom: 15px;">
            <asp:Label ID="lblDOB" runat="server" Text="Date of Birth:" Font-Bold="true" /><br />
            <asp:TextBox ID="txtDOB" runat="server" TextMode="Date" style="width: 80%; text-align: center;" />
        </div>

        <div style="margin-bottom: 15px;">
            <asp:Label ID="lblGender" runat="server" Text="Gender:" Font-Bold="true" /><br />
            <div style="display: flex; justify-content: center; gap: 20px; margin-top: 5px;">
                <asp:RadioButton ID="rbMale" runat="server" GroupName="Gender" Text="Male" />
                <asp:RadioButton ID="rbFemale" runat="server" GroupName="Gender" Text="Female" />
            </div>
        </div>

        <div style="margin-bottom: 15px;">
            <asp:Label ID="lblMobile" runat="server" Text="Mobile Number:" Font-Bold="true" /><br />
            <asp:TextBox ID="txtMobile" runat="server" MaxLength="10" style="width: 80%; text-align: center;" />
        </div>

        <div style="margin-top: 20px;">
            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-primary" OnClick="btnRegister_Click"
                style="width: 40%; margin-bottom: 10px;" /><br />
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-secondary" OnClick="btnBack_Click"
                style="width: 40%;" />
        </div>

        <br />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Bold="true" />
    </div>
    <br />
    <br />
</asp:Content>
