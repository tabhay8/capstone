<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ConfirmationPage.aspx.cs" Inherits="MoviePlex.ConfirmationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Display the Cart Items -->
    <h2>Your Cart</h2>
    <asp:Repeater ID="cartRepeater" runat="server">
        <ItemTemplate>
            <div class="cart-item">
                <asp:Image ID="imgCartItem" runat="server" CssClass="cart-item-image" />
                <h3><%# Eval("MovieTitle") %></h3>
                <p>Duration: <%# Eval("Duration") %> minutes</p>
                <p>Genre: <%# Eval("Genre") %></p>
                <p>Price: $<%# Eval("Price") %></p>
                <asp:Button ID="btnRemove" runat="server" Text="Remove" CommandName="Remove" CommandArgument='<%# Eval("MovieID") %>' />
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <!-- Display Total Price and Checkout Button -->
    <div class="cart-summary">
        <h3>Total Price: $<asp:Label ID="lblTotalPrice" runat="server"></asp:Label></h3>
        <asp:Button ID="btnCheckout" runat="server" Text="Proceed to Checkout" OnClick="BtnCheckout_Click" />
    </div>
</asp:Content>
