<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GOVTSTATEDET._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .center-container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 80vh; 
        }

        .login-box {
            width: 300px;
            text-align: center;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }

        .login-box h2 {
            text-align: center;
            margin-bottom: 20px;
        }
    </style>
    
    <div class="center-container">
        <div class="login-box">
            <img src="download.png" alt="Description" style="width: 100px; height: auto;" />
            <br />
            <br />
            <h2>Login</h2>

            <asp:Label ID="Label1" runat="server" Text="Registration ID"></asp:Label><br />
            <asp:TextBox ID="txtRegId" runat="server" CssClass="form-control"></asp:TextBox><br /><br />

            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label><br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox><br /><br />

            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            &nbsp;
            <asp:Button ID="btnNewReg" runat="server" Text="New Registration" OnClick="btnNewReg_Click" />
        </div>
    </div>
</asp:Content>
