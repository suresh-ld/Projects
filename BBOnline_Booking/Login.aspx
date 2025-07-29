<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BBOnline_Booking.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .logform{
            display:flex;
            flex-direction:column;
            margin-bottom:150px;
            gap:25px;
            font-weight:bold;
            font-family:'Arial Unicode MS';
            text-align:center;
            align-items:center;
            border:1px solid black;
            margin-left:600px;
            width:250px;
            margin-top:50px;
            border-radius:20px;
        }
        .hd-top{
            font-weight:bold;
            font-size:25px;
            text-align:center;
        }
        .user{
            text-align:center;
            align-content:center;
            border-radius:50px;
        }
        .pass{
            text-align:center;
            border-radius:50px;
            align-content:center;
        }
        .log{
            border-radius:50px;
            background-color:aqua;
            color:black;
        }
        .new{
            border-radius:50px;
            background-color:aqua;
            color:black;
            margin-bottom:10px;
        }
     
    </style>

    <main>
        <div class="hd-top">
         <img src="page_image.png" style="width:150px;" />
        <br />
        <br />
        <asp:Label ID="hd1" runat="server" Text="BBOnline"></asp:Label>
        </div>
        <div class="logform">
            <asp:Label ID="user_label" runat="server" Text="User ID"></asp:Label>
            <asp:TextBox ID="user" runat="server"  CssClass="user"></asp:TextBox>
            <asp:Label ID="password_label" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="pass" runat="server" TextMode="Password" CssClass="pass"></asp:TextBox>
            <asp:Button ID="log" runat="server" Text="Login"  CssClass="log" OnClick="login_button"/>
            <asp:Button ID="new" runat="server" Text="New User" CssClass="new" OnClick="new_button" />
        </div>
    </main>
</asp:Content>
