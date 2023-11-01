<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="MoviePlex.AdminLogin" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheet/LoginPage.css">
    <div class="container_form">
        <div class="column">
            <h2>Sign Up</h2>
            <asp:TextBox runat="server" ID="EmployeeNameTextBox" placeholder="Employee Name"></asp:TextBox>
            <asp:TextBox runat="server" ID="EmployeeIDTextBox" placeholder="Employee ID"></asp:TextBox>
            <asp:TextBox runat="server" ID="EmployeeEmailTextBox" placeholder="Employee Email"></asp:TextBox>
            <asp:TextBox runat="server" ID="EmployeePasswordTextBox" TextMode="Password" placeholder="Employee Password"></asp:TextBox>
           
            <p>Employee Designation:</p>
    <asp:RadioButtonList runat="server" ID="EmployeeDesignationRadioList">
        <asp:ListItem Text="Food and Beverages Manager" Value="FoodAndBeveragesManager"></asp:ListItem>
        <asp:ListItem Text="Show Manager" Value="ShowManager"></asp:ListItem>
    </asp:RadioButtonList>

            <asp:Button runat="server" ID="SignUpButton" Text="Sign Up" OnClick="SignUp_Click" />
        </div>
        <div class="column">
            <h2>Sign In</h2>
            <asp:TextBox runat="server" ID="SignInIdentifier" placeholder="Employee ID or Email"></asp:TextBox>
            <asp:TextBox runat="server" ID="SignInPassword" TextMode="Password" placeholder="Password"></asp:TextBox>
            <asp:Button runat="server" ID="SignInButton" Text="Sign In" OnClick="SignIn_Click" />
        </div>
    </div>
</asp:Content>
