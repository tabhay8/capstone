<%@ Page Title="User Profile" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="MoviePlex.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="background" style="background-image: url('Images/Background/userBack.jpg');">
    <link rel="stylesheet" type="text/css" href="StyleSheet/UserProfile.css">
    
        
    <div class="user-profile">
        <h1>User Profile</h1>
        <div>
            <label for="txtUserID">User ID:</label>
            <asp:Label ID="lblUserID" runat="server"></asp:Label>
        </div>
        <div>
            <label for="txtUsername">Username:</label>
            <asp:Label ID="lblUsername" runat="server"></asp:Label>
        </div>
        <div>
            <label for="txtFullName">Full Name:</label>
            <asp:Label ID="lblFullName" runat="server"></asp:Label>
        </div>
        <div>
            <label for="txtAge">Age:</label>
            <asp:Label ID="lblAge" runat="server"></asp:Label>
        </div>
        <div>
            <label for="txtEmail">Email:</label>
            <asp:Label ID="lblEmail" runat="server"></asp:Label>
        </div>
        <div>
            <label for="txtPhoneNumber">Phone Number:</label>
            <asp:Label ID="lblPhoneNumber" runat="server"></asp:Label>
        </div>
    </div>
   </div>
</asp:Content>
