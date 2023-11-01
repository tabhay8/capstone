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
                        <div class="form-group">
                            <label for="sizeDropdown">Size:</label>
                            <select class="form-control" id="sizeDropdown">
                                <option>Small</option>
                                <option>Medium</option>
                                <option>Large</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="quantityDropdown">Quantity:</label>
                            <select class="form-control" id="quantityDropdown">
                                <option>1</option>
                                <option>2</option>
                                <option>3</option>
                            </select>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
