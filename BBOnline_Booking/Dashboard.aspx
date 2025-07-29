<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="BBOnline_Booking.Dashboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <style>
            .dashform {
                display: flex;
                flex-direction: row;
                margin-bottom: 350px;
                gap: 25px;
                font-weight: bold;
                font-family: 'Arial Unicode MS';
                text-align: center;
                align-items: center;
                margin-left: 300px;
                margin-top: 50px;
            }
            .hd-top{
                font-weight:bold;
                font-size:25px;
                text-align:center;
            }
            .dbbutpart{
                width:200px;
                text-align:center;
                background-color:aqua;
                color:black;
                border-radius:50px;
            }
            .book{
                margin-left:600px;
                margin-top:-300px;
                margin-bottom:130px;
                
            }
     
    </style>
    <main>
        <div class="hd-top">
         <img src="page_image.png" style="width:150px;" />
        <br />
        <br />
        <asp:Label ID="hd1" runat="server" Text="BBOnline"></asp:Label>
        <br />
        <br />
         <asp:Label ID="Labelusr" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="dashform">
            <asp:Button ID="newbook" CssClass="dbbutpart" runat="server" Text="New Booking" OnClick="new_book" />
            <asp:Button ID="viewbook" CssClass="dbbutpart" runat="server" Text="View Booking" OnClick="view_book" />
            <asp:Button ID="report" CssClass="dbbutpart" runat="server" Text="Report" OnClick="report_sec" />
            <asp:Button ID="homepage" CssClass="dbbutpart" runat="server" Text="Homepage(Logout)" OnClick="logout" />
        </div>
        <div class="book">
        <img src="Book.jpeg" style="width:250px;" />
        </div>
    </main>
</asp:Content>
