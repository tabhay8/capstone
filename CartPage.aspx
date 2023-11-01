<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="MoviePlex.CartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .cart-container {
            text-align: center;
            margin: 50px auto;
        }

        .cart-table {
            width: 50%;
            border: 1px solid #ccc;
            border-collapse: collapse;
            margin: 0 auto;
        }

        .cart-table th, .cart-table td {
            padding: 10px;
            text-align: center;
            border: 0px solid #ccc;
        }
    </style>

    <div class="cart-container">
        <h2>Shopping Cart</h2>
        <table class="cart-table">
            <tr>
                <th>Seat Number</th>
            </tr>
            <asp:Repeater ID="CartRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItem %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <asp:Button ID="btnCheckout" runat="server" Text="Checkout" OnClick="BtnCheckout_Click" CssClass="cart-button" Visible="true" />

</asp:Content>
