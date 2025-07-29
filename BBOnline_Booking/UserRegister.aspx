<%@ Page Title="User Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="BBOnline_Booking.UserRegister" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .userform {
            display: flex;
            flex-direction: column;
            margin-bottom: 150px;
            gap: 5px;
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
       .hd-top{
            font-weight:bold;
            font-size:25px;
            text-align:center;
        }
       .labelpart{
           margin-top:10px;
           margin-right:300px;
       }

       .textpart{
           margin-left:100px;
           margin-top:-30px;
           margin-bottom:10px;
           border-radius:100px;
           width:200px;
           text-align:center;
       }
       .radiopart1{
            margin-left:-30px;
            margin-top:-30px;
            margin-bottom:10px;
        }
       .radiopart2{
             margin-left:150px;
             margin-top:-39px;
             margin-bottom:10px;
        }

       .butpart1,.butpart2{
           border-radius:50px;
           width:100px;
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
        <div class="userform">
            <asp:Label ID="name" CssClass="labelpart" runat="server" Text="Name:"></asp:Label>
            <asp:TextBox ID="nametxt" CssClass="textpart" runat="server"></asp:TextBox>
            <asp:Label ID="dob" CssClass="labelpart" runat="server" Text="DOB:"></asp:Label>
            <asp:TextBox ID="dobtxt" CssClass="textpart" TextMode="Date" runat="server"></asp:TextBox>
            <asp:Label ID="gender" CssClass="labelpart" runat="server" Text="Gender:"></asp:Label>
            <asp:RadioButton ID="male" CssClass="radiopart1" runat="server" GroupName="gender" Text="Male" />
            <asp:RadioButton ID="female" CssClass="radiopart2" runat="server" GroupName="gender" Text="Female"/>
            <asp:Label ID="phoneno" CssClass="labelpart" runat="server" Text="Phone Number:"></asp:Label>
            <asp:TextBox ID="phnotxt" CssClass="textpart" TextMode="Phone" runat="server"></asp:TextBox>
            <asp:Label ID="address" CssClass="labelpart" runat="server" Text="Address:"></asp:Label>
            <asp:TextBox ID="addtxt" CssClass="textpart"  runat="server"></asp:TextBox>
            <asp:Label ID="email" CssClass="labelpart" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="emailtxt" CssClass="textpart" TextMode="Email" runat="server"></asp:TextBox>
            <asp:Label ID="userid" CssClass="labelpart" runat="server" Text="User ID:"></asp:Label>
            <asp:TextBox ID="useridtxt" CssClass="textpart" runat="server"></asp:TextBox>
            <asp:Label ID="password" CssClass="labelpart" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="passwordtxt" CssClass="textpart" TextMode="Password" runat="server"></asp:TextBox>
            <asp:Label ID="comfirmpassword" CssClass="labelpart" runat="server" Text="Confirm Password:"></asp:Label>
            <asp:TextBox ID="confirmpasswordtext" CssClass="textpart" TextMode="Password" runat="server"></asp:TextBox>
            <asp:Button ID="register" runat="server" CssClass="butpart1" Text="Submit" OnClick="new_register" />
            <asp:Button ID="back" runat="server" CssClass="butpart2" Text="Back" OnClick="back_Click"/>

            <br />
             <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Bold="true" />
        </div>
    </main>
</asp:Content>