<%@ Page Title="Booking Availability" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="bookingavailability.aspx.cs" Inherits="BBOnline_Booking.bookingavailability" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        
        .availform{
            display:flex;
            flex-direction:row;
            margin-bottom:150px;
            gap:25px;
            font-weight:bold;
            font-family:'Arial Unicode MS';
            text-align:center;
            align-items:center;
            margin-left:250px;
            width:1000px;
            margin-top:50px;
            margin-bottom:330px;
        }
        
        .hd-top {
            font-weight: bold;
            font-size: 25px;
            text-align: center;
        }
        .availbooktxt{
            width:200px;
            border-radius:50px;
            text-align:center;
        }
        .availbutpart{
            background-color:aqua;
            color:black;
            border-radius:50px;
            width:100px;
        }



    </style>

    <main>
        <div class="hd-top">
         <img src="page_image.png" style="width:150px;" />
        <br />
        <br />
        <asp:Label ID="hd1" runat="server" Text="BBOnline"></asp:Label>
        </div>
        <div class="availform">
            <asp:Label ID="availbooklabel" CssClass="avail_label" runat="server" Text="Booking Date:"></asp:Label>
            <asp:TextBox ID="availtext" CssClass="availbooktxt" TextMode="Date"  runat="server"  ></asp:TextBox>
            <asp:Label ID="availsellabel" CssClass="avail_label" runat="server" Text="Select Activity:"></asp:Label>
            <asp:DropDownList ID="activity_drop" runat="server" CssClass="availbooktxt" ></asp:DropDownList>   
            <asp:Button ID="availsubmit" CssClass="availbutpart" runat="server" Text="Submit" />
            <asp:Button ID="availback" CssClass="availbutpart" runat="server" Text="Back" />    
            <br />
            <br />
        </div>
    </main>
</asp:Content>



