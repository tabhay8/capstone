<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="MoviePlex.AdminLogin" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheet/LoginPage.css">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h2>Sign Up</h2>
                <asp:TextBox runat="server" ID="EmployeeNameTextBox" CssClass="form-control" placeholder="Employee Name"></asp:TextBox>
                <asp:TextBox runat="server" ID="EmployeeIDTextBox" CssClass="form-control" placeholder="Employee ID"></asp:TextBox>
                <asp:TextBox runat="server" ID="EmployeeEmailTextBox" CssClass="form-control" placeholder="Employee Email"></asp:TextBox>
                <asp:TextBox runat="server" ID="EmployeePasswordTextBox" CssClass="form-control" TextMode="Password" placeholder="Employee Password"></asp:TextBox>

                <asp:RadioButtonList runat="server" ID="EmployeeDesignationRadioList" CssClass="form-control">
                    <asp:ListItem Text="Food and Beverages Manager" Value="FoodAndBeveragesManager"></asp:ListItem>
                    <asp:ListItem Text="Show Manager" Value="ShowManager"></asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <asp:Button runat="server" ID="SignUpButton" CssClass="btn btn-primary" Text="Sign Up" OnClick="SignUp_Click" />
            </div>
        </div>
        
        <div class="row mt-4">
            <div class="col-md-12">
                <h2>Sign In</h2>
                <asp:TextBox runat="server" ID="SignInIdentifier" CssClass="form-control" placeholder="Employee ID or Email"></asp:TextBox>
                <asp:TextBox runat="server" ID="SignInPassword" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                <asp:Button runat="server" ID="SignInButton" CssClass="btn btn-success" Text="Sign In" OnClick="SignIn_Click" />
            </div>
        </div>
    </div>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
</asp:Content>
