<%@ Page Title="Enrolment Report" Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="GOVTSTATEDET.EnrolmentReport" MasterPageFile="~/Site.Master" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align: center; padding: 40px;">
        <img src="download.png" alt="Logo" style="width: 100px; height: auto;" />
        <div style="font-size: 24px; font-weight: bold; margin: 30px 0;">Enrolment Report</div>
        <asp:Button ID="btnBack" runat="server" Text="Back to Dashboard"
        CssClass="btn btn-primary" OnClick="btnBack_Click"
        Style="margin-top: 20px;" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"
            CssClass="table table-bordered" Width="95%" />
    </div>
</asp:Content>
