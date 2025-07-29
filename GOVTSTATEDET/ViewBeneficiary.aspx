<%@ Page Title="View Beneficiary" Language="C#" AutoEventWireup="true" CodeBehind="ViewBeneficiary.aspx.cs" Inherits="GOVTSTATEDET.ViewBeneficiary" MasterPageFile="~/Site.Master" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .form-control {
            width: 300px;
            padding: 8px;
            margin: 10px auto; 
            display: block;
        }
        .btn {
            padding: 8px 16px;
            margin: 10px auto;
            display: block;
        }
        .form-group {
            text-align: center;
            margin-bottom: 20px;
        }
        .grid {
            margin: 20px auto;
            width: 90%;
            border-collapse: collapse;
            margin-bottom:250px;
        }
        .grid th, .grid td {
            padding: 8px;
            border: 1px solid #ccc;
        }
        .message {
            color: red;
            font-weight: bold;
            text-align: center;
        }
        .btn-success {
            background-color: #28a745;
            color: white;
            padding: 8px 16px;
            border: none;
            cursor: pointer;
            margin: 10px auto;
            display: block;
        }
    </style>

    <div style="text-align:center;">
        <br />
        <img src="download.png" alt="Logo" style="width: 100px; height: auto;" />
        <h2>View Beneficiary Enrolments</h2>

        <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label><br />

        <div class="form-group">
            <asp:Label ID="lblUserId" runat="server" Text="User Registration ID:"></asp:Label><br />
            <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control"></asp:TextBox><br />
            <asp:Button ID="btnFetch" runat="server" Text="Submit" OnClick="btnFetch_Click" CssClass="btn-success" />
            <asp:Button ID="btnBack" runat="server" Text="Back to DashBoard" CssClass="btn btn-danger" OnClick="btnBack_Click" />
        </div>

        <asp:GridView ID="GridViewEnrolments" runat="server" AutoGenerateColumns="False" CssClass="grid">
            <Columns>
                <asp:BoundField DataField="child_id" HeaderText="Child ID" />
                <asp:BoundField DataField="child_name" HeaderText="Child Name" />
                <asp:BoundField DataField="ParentsDetails" HeaderText="Parents Name and Address" />
                <asp:BoundField DataField="status" HeaderText="Enrolment Status" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
