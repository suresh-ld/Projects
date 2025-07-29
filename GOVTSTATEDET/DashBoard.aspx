<%@ Page Title="DashBoard" Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="GOVTSTATEDET.Dashboard" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .dashboard-container {
            text-align: center;
            padding: 50px;
        }

        .dashboard-container h2 {
            margin-bottom: 30px;
        }

        .dashboard-container .btn {
            margin: 10px;
            padding: 10px 30px;
            font-size: 16px;
            cursor: pointer;
        }
    </style>

    <div class="dashboard-container">
        <img src="download.png" alt="Description" style="width: 100px; height: auto;" />
        <h2>Welcome<br /><br /> <asp:Label ID="lblUser" runat="server" Text=""></asp:Label></h2>

        <asp:Button ID="btnEnroll" runat="server" Text="Beneficiary Enrolment" CssClass="btn btn-primary" OnClick="btnEnroll_Click" /><br />

        <asp:Button ID="btnView" runat="server" Text="View Beneficiary" CssClass="btn btn-info" OnClick="btnView_Click" /><br />

        <asp:Button ID="btnReport" runat="server" Text="Report" CssClass="btn btn-warning" OnClick="btnReport_Click" /><br />

        <asp:Button ID="btnHome" runat="server" Text="Home Page" CssClass="btn btn-secondary" OnClick="btnHome_Click" />
    </div>
</asp:Content>
