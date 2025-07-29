<%@ Page Title="Booking" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="BBOnline_Booking.Booking" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .bookform {
            display: flex;
            flex-direction: column;
            margin-bottom: 150px;
            gap: 25px;
            font-weight: bold;
            font-family: 'Arial Unicode MS';
            text-align: center;
            align-items: center;
            border: 1px solid black;
            margin-left: 500px;
            width: 500px;
            margin-top: 50px;
            border-radius: 20px;
        }
        .hd-top {
            font-weight: bold;
            font-size: 25px;
            text-align: center;
        }
        .booklabel {
            margin-top: 10px;
            margin-right: 300px;
        }
        .booktxt {
            margin-top: -50px;
            margin-left: 100px;
            width: 200px;
            border-radius: 50px;
            text-align: center;
        }
        .booktxt1 {
            margin-top: -60px;
            margin-left: 100px;
            width: 200px;
            height: 100px;
            border-radius: 10px;
            text-align: center;
        }
        .bookradio1 {
            margin-top: -50px;
            margin-left: -30px;
        }
        .bookradio2 {
            margin-top: -49px;
            margin-left: 100px;
        }
        .but_part1, .but_part2, .but_part3 {
            width: 150px;
            background-color: aqua;
            color: black;
            border-radius: 50px;
            text-align: center;
        }
        .but_part1 {
            margin-left: -150px;
            margin-top: 20px;
            margin-bottom: 10px;
        }
        .but_part2 {
            margin-left: 200px;
            margin-top: -64px;
        }
        .but_part3 {
            margin-left: 100px;
        }
    </style>

    <main>
        <div class="hd-top">
            <img src="page_image.png" style="width:150px;" />
            <br /><br />
            <asp:Label ID="hd1" runat="server" Text="BBOnline"></asp:Label>
        </div>

        <div class="bookform">
            <asp:Label ID="name_label" runat="server" />
            <asp:Label ID="reg_label" runat="server" />

            <asp:Label ID="sel_label" CssClass="booklabel" runat="server" Text="Select Activity:" />
            <asp:DropDownList ID="sel_drop" runat="server" CssClass="booktxt" AutoPostBack="true" OnSelectedIndexChanged="sel_drop_SelectedIndexChanged" />

            <asp:Label ID="date_label" CssClass="booklabel" runat="server" Text="Booking Date:" />
            <asp:TextBox ID="date_txt" CssClass="booktxt" TextMode="Date" runat="server" />

            <asp:Button ID="check_but" CssClass="but_part3" runat="server" Text="Check Availability" OnClick="check_avail" />

            <asp:Label ID="dist_label" CssClass="booklabel" runat="server" Text="District:" Enabled="false" />
            <asp:DropDownList ID="dist_drop" runat="server" CssClass="booktxt" Enabled="false" />

            <asp:Label ID="per_label" CssClass="booklabel" runat="server" Text="Name Of Person:" Enabled="false" />
            <asp:TextBox ID="per_text" CssClass="booktxt" runat="server" Enabled="false" />

            <asp:Label ID="id_label" CssClass="booklabel" runat="server" Text="ID Proof:" Enabled="false" />
            <asp:DropDownList ID="id_drop" runat="server" CssClass="booktxt" Enabled="false" />

            <asp:Label ID="idnum_label" CssClass="booklabel" runat="server" Text="ID Number:" Enabled="false" />
            <asp:TextBox ID="idnum_text" CssClass="booktxt" runat="server" Enabled="false" />

            <asp:Label ID="gend_label" CssClass="booklabel" runat="server" Text="Gender:" Enabled="false" />
            <asp:RadioButton ID="RadioButton1" CssClass="bookradio1" Text="Male" runat="server" Enabled="false" GroupName="Gender" />
            <asp:RadioButton ID="RadioButton2" CssClass="bookradio2" Text="Female" runat="server" Enabled="false" GroupName="Gender" />

            <asp:Label ID="age_label" CssClass="booklabel" runat="server" Text="Age:" Enabled="false" />
            <asp:TextBox ID="age_text" CssClass="booktxt" runat="server" Enabled="false" />

            <asp:Label ID="add_label" CssClass="booklabel" runat="server" Text="Address:" Enabled="false" />
            <asp:TextBox ID="add_text" CssClass="booktxt1" runat="server" Enabled="false" />

            <asp:Label ID="amount_label" CssClass="booklabel" runat="server" Text="Amount:" Enabled="false" />
            <asp:TextBox ID="amount_text" CssClass="booktxt" runat="server" Enabled="false" />

            <asp:Button ID="save_but" CssClass="but_part1" runat="server" Text="Save" Enabled="false" OnClick="save_book" />
            <asp:Button ID="back_but" CssClass="but_part2" runat="server" Text="Back"  OnClick="back_but_Click" />

            <br /><br />
            <asp:Label ID="lblMsg" runat="server" ForeColor="Green" Font-Bold="true" />
        </div>
    </main>
</asp:Content>
