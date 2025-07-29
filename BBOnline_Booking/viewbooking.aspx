<%@ Page Title="View Booking" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="viewbooking.aspx.cs" Inherits="BBOnline_Booking.viewbooking" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .viewbookform {
            display: flex;
            flex-direction: row;
            gap: 25px;
            font-weight: bold;
            font-family: 'Arial Unicode MS';
            text-align: center;
            align-items: center;
            margin: 50px auto 30px auto;
            width: 1000px;
        }

        .hd-top {
            font-weight: bold;
            font-size: 25px;
            text-align: center;
        }

        .viewbooktxt1 {
            border-radius: 20px;
            width: 200px;
            text-align: center;
        }

        .viewbut_part {
            background-color: aqua;
            color: black;
            border-radius: 25px;
            width: 200px;
            height: 35px;
        }

        .gridview-style {
            margin: 0 auto;
            width: 80%;
            border-collapse: collapse;
            margin-top: 20px;
            margin-bottom: 350px;
        }

        .gridview-style th,
        .gridview-style td {
            padding: 10px;
            border: 1px solid black;
            text-align: center;
        }

        .status-label {
            text-align: center;
            font-size: 16px;
            color: red;
            margin-top: 15px;
            align-items: center;
            margin-left: 550px;
        }
    </style>

    <main>
        <div class="hd-top">
            <img src="page_image.png" style="width: 150px;" />
            <br />
            <asp:Label ID="hd1" runat="server" Text="BBOnline"></asp:Label>
        </div>

        <div class="viewbookform">
            <asp:Label ID="viewbookidlabel" runat="server" Text="Booking ID:"></asp:Label>
            <asp:TextBox ID="viewbookidtext" CssClass="viewbooktxt1" runat="server"></asp:TextBox>
            <asp:Button ID="viewbookbut" CssClass="viewbut_part" runat="server" Text="View Receipt" OnClick="viewbookbut_Click" />
            <asp:Button ID="viewbackbut" CssClass="viewbut_part" runat="server" Text="Back" OnClick="viewbackbut_Click" />
            <asp:Button ID="print_but" CssClass="viewbut_part" runat="server" Text="Print" OnClick="printbut_Click" />
        </div>

        <asp:Label ID="lblStatus" runat="server" CssClass="status-label"></asp:Label>

        <asp:GridView ID="GridViewReceipt" runat="server" AutoGenerateColumns="False" Visible="false" CssClass="gridview-style">
            <Columns>
                <asp:BoundField HeaderText="Booking ID" DataField="booking_id" />
                <asp:BoundField HeaderText="Booked Activity" DataField="activity_name" />
                <asp:BoundField HeaderText="Booking Date" DataField="booking_date" />
                <asp:BoundField HeaderText="Name" DataField="booking_name" />
                <asp:BoundField HeaderText="ID Proof" DataField="proof_description" />
                <asp:BoundField HeaderText="ID Proof Number" DataField="proof_number" />
                <asp:BoundField HeaderText="Activity Amount" DataField="activity_amount" />
            </Columns>
        </asp:GridView>
    </main>
</asp:Content>
