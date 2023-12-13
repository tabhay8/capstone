<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="MoviePlex.CartPage" EnableViewState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .cart-container {
            text-align: center;
            margin: 50px auto;
        }

        .cart-table {
            width: 100%;
            border: 1px solid #ccc;
            border-collapse: collapse;
            margin: 0 auto;
        }

        .cart-table th, .cart-table td {
            padding: 10px;
            text-align: center;
            border: 0px solid #ccc;
        }

        .cart-button {
            background-color: #007bff;
            color: #fff;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
    </style>

    <div class="container cart-container">
        <h2>Shopping Cart</h2>
        <div>
            <asp:Label ID="selectedButtonsLabel" runat="server" Text=""></asp:Label>
        </div>

        <asp:Label ID="lblTheaterId" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblShowTiming" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblAuditorium" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblSelectedDate" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblTheaterName" runat="server" Text=""></asp:Label><br />

        <asp:Label ID="lblTotalPrice" runat="server" Text=""></asp:Label><br />

        <asp:Button ID="btnCheckout" runat="server" Text="Checkout" OnClick="BtnCheckout_Click" CssClass="btn btn-primary cart-button" Visible="true" />
    </div>
</asp:Content>
