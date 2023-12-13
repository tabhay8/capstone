<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FoodDrinks.aspx.cs" Inherits="MoviePlex.FoodDrinks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheet/Food.css" />
    <!-- Your content for ContentPlaceHolder1 -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Food and Beverages Menu</h1>
    <div class="card-container">
        <asp:Repeater ID="foodRepeater" runat="server">
            <ItemTemplate>
                <div class="card">
                    <asp:Image ID="itemImage" runat="server" ImageUrl='<%# Eval("ImageURL") %>' CssClass="card-img" />
                    <div class="card-details">
                        <h2><%# Eval("Name") %></h2>
                        <p><%# Eval("Description") %></p>
                        <p><strong>Price: <%# Eval("Price", "{0:C}") %></strong></p>

                        <!-- Review Controls Inside Repeater -->
                        <div class="form-group">
                            <label for="sizeDropdown">Size:</label>
                            <select class="form-control" id="sizeDropdown<%# Container.ItemIndex %>">
                                <option>Small</option>
                                <option>Medium</option>
                                <option>Large</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="quantityTextbox">Quantity:</label>
                            <asp:TextBox ID="quantityTextbox" runat="server" CssClass="form-control" Text="1"></asp:TextBox>
                        </div>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        
                       
                        <asp:Button ID="addToCartButton" runat="server" Text="Add to Cart" OnClick="AddToCart_Click"
                            CommandArgument='<%# Eval("ItemID") %>' />

                       
                        <asp:Button ID="submitReviewButton" runat="server" Text="Submit Review" OnClick="SubmitReview_Click"
                            CommandArgument='<%# Eval("ItemID") %>' />
                        
                     
                        <asp:Button ID="goToCartButton" runat="server" Text="Go to Cart" OnClick="GoToCart_Click" />
                    </div>
                </div>
                <asp:Repeater ID="reviewRepeater" runat="server" DataSource='<%# GetTop5Reviews(Convert.ToInt32(Eval("ItemID"))) %>'>
            <ItemTemplate>
                <div class="review">
                    <p><strong>Rating:</strong> <%# Eval("Rating") %> stars</p>
                    <p><strong>Comment:</strong> <%# Eval("Comment") %></p>
                    <p><strong>Date:</strong> <%# Eval("ReviewDate", "{0:MMMM dd, yyyy}") %></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
