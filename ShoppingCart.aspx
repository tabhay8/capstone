<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="MoviePlex.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <h1>Shopping Cart</h1>

    <asp:Repeater ID="cartRepeater" runat="server">
        <ItemTemplate>
            <div class="cart-item">
                <h3><%# Eval("ItemName") %></h3>
                <p>Quantity: <%# Eval("Quantity") %></p>
                <p>Price: <%# Eval("Price", "{0:C}") %></p>
            </div>
            <asp:Button runat="server" CommandArgument='<%# Eval("ItemID") %>' 
                        OnCommand="DeleteCartItem_Command" Text="Delete" />
        </ItemTemplate>
    </asp:Repeater>



       

        <div >
            <!-- Button to move to checkout page -->
            <asp:Button ID="btnMoveToCheckout" runat="server" Text="Proceed to Checkout" OnClick="BtnMoveToCheckout_Click" CssClass="btn btn-success" />
        </div>
    

</asp:Content>
