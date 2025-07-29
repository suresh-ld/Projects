<%@ Page Title="Beneficiary Enrolment" Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Site.Master" CodeBehind="BeneficiaryEnrolment.aspx.cs"
    Inherits="GOVTSTATEDET.BeneficiaryEnrolment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="text-align: center;"><br />
        <img src="download.png" alt="Logo" style="width: 100px; height: auto;" />
        Beneficiary Enrolment Form
    </h2>
    <hr />
    <div style="max-width: 600px; margin: auto;">
        <table class="table table-borderless">
            <tr>
                <td><strong>User Name:</strong></td>
                <td><asp:Label ID="lblUserName" runat="server" CssClass="form-control-plaintext text-dark fw-bold"></asp:Label></td>
            </tr>
            <tr>
                <td><strong>Registration ID:</strong></td>
                <td><asp:Label ID="lblRegID" runat="server" CssClass="form-control-plaintext text-dark fw-bold"></asp:Label></td>
            </tr>
            <tr>
                <td><strong>District:</strong></td>
                <td><asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control"></asp:DropDownList></td>
            </tr>
            <tr>
                <td><strong>Taluk:</strong></td>
                <td><asp:DropDownList ID="ddlTaluk" runat="server" CssClass="form-control"></asp:DropDownList></td>
            </tr>
            <tr>
                <td><strong>Girl Child Name:</strong></td>
                <td><asp:TextBox ID="txtChildName" runat="server" CssClass="form-control" MaxLength="35"></asp:TextBox></td>
            </tr>
            <tr>
                <td><strong>BPL Card Number:</strong></td>
                <td><asp:TextBox ID="txtBPLCard" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox></td>
            </tr>
            <tr>
                <td><strong>Date of Birth:</strong></td>
                <td><asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox></td>
            </tr>
            <tr>
                <td><strong>Father Name:</strong></td>
                <td><asp:TextBox ID="txtFatherName" runat="server" CssClass="form-control" MaxLength="35"></asp:TextBox></td>
            </tr>
            <tr>
                <td><strong>Family Income:</strong></td>
                <td><asp:TextBox ID="txtIncome" runat="server" CssClass="form-control" MaxLength="5"></asp:TextBox></td>
            </tr>
            <tr>
                <td><strong>Mother Name:</strong></td>
                <td><asp:TextBox ID="txtMotherName" runat="server" CssClass="form-control" MaxLength="35"></asp:TextBox></td>
            </tr>
            <tr>
                <td><strong>Category:</strong></td>
                <td><asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control"></asp:DropDownList></td>
            </tr>
            <tr>
                <td><strong>Address:</strong></td>
                <td><asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" MaxLength="60"></asp:TextBox></td>
            </tr>
        </table>

        <asp:Label ID="lblMsg" runat="server" Font-Bold="true" /><br />

        <div style="text-align: center; margin-top: 20px;">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit"
                CssClass="btn btn-success" OnClick="btnSubmit_Click_save" />
            &nbsp;&nbsp;
            <asp:Button ID="btnBack" runat="server" Text="Back"
                CssClass="btn btn-secondary" OnClick="btnBack_Click" />
            <br />
            <br />
        </div>
    </div>
</asp:Content>
