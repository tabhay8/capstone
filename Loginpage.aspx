<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Loginpage.aspx.cs" Inherits="MoviePlex.Loginpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheet/LoginPage.css">
    <div class="container_form">
        <div class="column">
            <h2>Sign Up</h2>
            <asp:TextBox runat="server" ID="UsernameTextBox" placeholder="Username"></asp:TextBox>
            <asp:TextBox runat="server" ID="FullNameTextBox" placeholder="Full Name"></asp:TextBox>
            <asp:TextBox runat="server" ID="AgeTextBox" placeholder="Age"></asp:TextBox>
            <asp:TextBox runat="server" ID="EmailTextBox" placeholder="Email Address"></asp:TextBox>
            <asp:TextBox runat="server" ID="PhoneNumberTextBox" placeholder="Phone Number"></asp:TextBox>
            <asp:TextBox runat="server" ID="PasswordTextBox" TextMode="Password" placeholder="Password"></asp:TextBox>

            <asp:Button runat="server" ID="SignUpButton" Text="Sign Up" OnClick="SignUp_Click" />
        </div>
        <div class="column">
            <h2>Sign In</h2>
            <asp:TextBox runat="server" ID="SignInIdentifier" placeholder="Username or Email"></asp:TextBox>
            <asp:TextBox runat="server" ID="SignInPassword" TextMode="Password" placeholder="Password"></asp:TextBox>
            <asp:Button runat="server" ID="SignInButton" Text="Sign In" OnClick="SignIn_Click" />
        </div>
    </div>
    
</asp:Content>

