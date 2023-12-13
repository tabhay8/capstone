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
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-input"></asp:TextBox>
            </div>
            <div>
                <label for="txtPhoneNumber">Phone Number:</label>
                <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-input"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="update-button" />
            </div>
            <div>
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="logout-button" />
            </div>
        </div>
    </div>
</asp:Content>
