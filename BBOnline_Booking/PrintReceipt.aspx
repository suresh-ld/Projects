<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintReceipt.aspx.cs" Inherits="BBOnline_Booking.PrintReceipt" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Receipt</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            text-align: center;
        }

        h2 {
            margin-top: 20px;
        }

        table {
            width: 80%;
            margin: 20px auto;
            border-collapse: collapse;
        }

        th, td {
            border: 1px solid #000;
            padding: 10px;
            text-align: center;
        }

        th {
            background-color: #f2f2f2;
        }

        @media print {
            #btnBack {
                display: none;
            }
        }
        
    </style>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
        <h2>Booking Receipt</h2>
        <asp:GridView ID="GridViewPrint" runat="server" AutoGenerateColumns="False">
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
        <br />
        <asp:Button ID="btnBack" runat="server"  Text="Back" OnClick="btnBack_Click" />
    </form>
</body>
</html>
