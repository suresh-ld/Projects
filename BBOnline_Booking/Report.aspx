<%@ Page Title="Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="BBOnline_Booking.Report" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .reportform {
            display: flex;
            flex-direction: row;
            gap: 25px;
            font-weight: bold;
            font-family: 'Arial Unicode MS';
            text-align: center;
            align-items: center;
            margin-left: 600px;
            margin-top: 50px;
            margin-bottom:30px;
        }

        .hd-top {
            font-weight: bold;
            font-size: 25px;
            text-align: center;
        }

        .reporttxt {
            width: 200px;
            border-radius: 50px;
        }

        .grid-style {
            margin-left: 200px;
            margin-top: 40px;
            width: 80%;
            margin-bottom:350px;
        }
        .but_part_report {
            width: 150px;
            background-color: aqua;
            color: black;
            border-radius: 50px;
            text-align: center;
        }
                .but_part_report {
            width: 150px;
            background-color: aqua;
            color: black;
            border-radius: 50px;
            text-align: center;
            margin-left: 10px;
        }

    </style>

    <main>
        <div class="hd-top">
            <img src="page_image.png" style="width:150px;" />
            <br /><br />
            <asp:Label ID="hd1" runat="server" Text="BBOnline"></asp:Label>
        </div>

        <div class="reportform">
            <asp:Label ID="reportlabel" runat="server" Text="District:"></asp:Label>
            <asp:DropDownList ID="district_drop" runat="server" CssClass="reporttxt" />
            <asp:Button ID="btnViewReport" runat="server" CssClass="but_part_report" Text="View Report" OnClick="btnViewReport_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back to Dashboard" CssClass="but_part_report" OnClick="btnBack_Click" />
        </div>

        <asp:GridView ID="GridViewReport" runat="server" CssClass="grid-style" AutoGenerateColumns="false" BorderWidth="1px" GridLines="Both">
            <Columns>
                <asp:BoundField DataField="district_name" HeaderText="District Name" />
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="activity_name" HeaderText="Activity" />
                <asp:BoundField DataField="booking_date" HeaderText="Booked Date" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="activity_amount" HeaderText="Activity Amount" />
            </Columns>
        </asp:GridView>
    </main>
</asp:Content>
