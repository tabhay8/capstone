<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FoodCheckoutPage.aspx.cs" Inherits="MoviePlex.FoodCheckoutPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="mt-5">Food Checkout Page</h2>

    <div>
        <h3>Food Order Information</h3>
        <!-- Add your food order details and controls here -->

        <!-- Example: -->
        <div class="form-group">
            <label for="txtFoodItem">Food Item:</label>
            <asp:TextBox ID="txtFoodItem" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtQuantity">Quantity:</label>
            <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtTotalAmount">Total Amount:</label>
            <asp:TextBox ID="txtTotalAmount" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="mt-4">
        <h3>User Information</h3>
        <div class="form-group">
            <label for="txtName">Name:</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="mt-4">
        <h3>Booking Information</h3>
        <div class="form-group">
            <label for="txtBookingID">Booking ID:</label>
            <asp:TextBox ID="txtBookingID" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="btnVerifyBookingID" runat="server" Text="Verify Booking ID" OnClick="BtnVerifyBookingID_Click" CssClass="btn btn-primary" />
        <asp:Label ID="lblBookingVerificationResult" runat="server" Text=""></asp:Label>
    </div>

    <div class="mt-4">
        <h3>CAPTCHA</h3>
        <div class="form-group">
            <label for="txtCaptcha">CAPTCHA:</label>
            <asp:TextBox ID="txtCaptcha" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtUserEnteredCaptcha">Enter CAPTCHA:</label>
            <asp:TextBox ID="txtUserEnteredCaptcha" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="btnRefreshCaptcha" runat="server" Text="Refresh CAPTCHA" OnClick="BtnRefreshCaptcha_Click" CssClass="btn btn-secondary" />
    </div>

    
    <div class="mt-4">
        <asp:Button ID="btnFoodCheckout" runat="server" Text="Food Checkout" OnClick="BtnFoodCheckout_Click" CssClass="btn btn-success" />
    </div>

    <asp:Label ID="lblFoodCheckoutInfo" runat="server" Text=""></asp:Label>

</asp:Content>
