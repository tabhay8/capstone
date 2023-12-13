<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CheckoutPage.aspx.cs" Inherits="MoviePlex.CheckoutPage" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" CssClass="container">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <h2 class="mt-5">Checkout Page</h2>

    <div>
    <h3>Cart Information</h3>
    <asp:Label ID="lblSelectedButtons" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="lblTheaterId" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="lblShowTiming" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="lblAuditorium" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="lblSelectedDate" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="lblTheaterName" runat="server" Text=""></asp:Label><br />
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
    <div>

        <asp:Button ID="btnPayPal" runat="server" Text="Pay with PayPal" OnClick="BtnPayPal_Click" CssClass="btn btn-success" />
<asp:Button ID="btnOnlineBanking" runat="server" Text="Pay with Online Banking" OnClick="BtnOnlineBanking_Click" CssClass="btn btn-info" />

    </div>
  
    <div class="mt-4">
        <h3>Card Details</h3>
        <div class="form-group">
            <label for="txtCardNumber">Card Number:</label>
            <asp:TextBox ID="txtCardNumber" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtExpiryDate">Expiry Date (MM/YY):</label>
            <asp:TextBox ID="txtExpiryDate" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtCVV">CVV:</label>
            <asp:TextBox ID="txtCVV" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>
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
    <!-- Checkout Button -->
    <div class="mt-4">
        <asp:Button ID="btnCheckout" runat="server" Text="Checkout" OnClick="BtnCheckout_Click" CssClass="btn btn-primary" />
    </div>
    <asp:Label ID="lblCheckoutInfo" runat="server" Text=""></asp:Label>
</asp:Content>
