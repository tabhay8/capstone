<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FoodAdmin.aspx.cs" Inherits="MoviePlex.FoodAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Admin Dashboard - Manage Food Items</h1> 
    

    <div class="add-food-item-form">
        <h2>Add Food Item</h2>
        <asp:TextBox runat="server" ID="FoodNameTextBox" placeholder="Name"></asp:TextBox>
        <asp:TextBox runat="server" ID="DescriptionTextBox" placeholder="Description"></asp:TextBox>
        <asp:TextBox runat="server" ID="CategoryTextBox" placeholder="Category"></asp:TextBox>
        <asp:TextBox runat="server" ID="PriceTextBox" placeholder="Price"></asp:TextBox>
        <asp:CheckBox runat="server" ID="AvailabilityCheckBox" Text="Available" />
        <asp:TextBox runat="server" ID="StockQuantityTextBox" placeholder="Stock Quantity"></asp:TextBox>
        <asp:FileUpload runat="server" ID="ImageUpload" />
        <asp:Button runat="server" ID="AddFoodItemButton" Text="Add Food Item" OnClick="AddFoodItemButton_Click" />
    </div>

    <h2>Food Item List</h2>

    <asp:GridView runat="server" ID="GridViewFoodAndBeverages" AutoGenerateColumns="False" DataKeyNames="ItemID" OnRowDeleting="GridViewFoodAndBeverages_RowDeleting" OnRowEditing="GridViewFoodAndBeverages_RowEditing" OnRowUpdating="GridViewFoodAndBeverages_RowUpdating" OnRowCancelingEdit="GridViewFoodAndBeverages_RowCancelingEdit">

    <Columns>
       <asp:BoundField DataField="ItemID" HeaderText="Item ID" ReadOnly="True" SortExpression="ItemID" />
    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" ReadOnly="True" />
    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" ReadOnly="True" />
    <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" ReadOnly="True" />
    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" ReadOnly="True" />
    <asp:BoundField DataField="Availability" HeaderText="Availability" SortExpression="Availability" ReadOnly="True" />
    <asp:BoundField DataField="StockQuantity" HeaderText="Stock Quantity" SortExpression="StockQuantity" ReadOnly="True" />
    <asp:ImageField DataImageUrlField="ImageURL" HeaderText="Image" SortExpression="ImageURL" ControlStyle-Height="50" ControlStyle-Width="50" ReadOnly="True" />
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:LinkButton ID="EditButton" runat="server" CommandName="Edit" CommandArgument='<%# Eval("ItemID") %>' Text="Edit" />
                <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Delete" CommandArgument='<%# Eval("ItemID") %>' Text="Delete" />
            </ItemTemplate>
            <EditItemTemplate>
                <asp:Label runat="server" Text='<%# Eval("ItemID") %>' Visible="false"></asp:Label>
                <asp:TextBox runat="server" ID="txtName" Text='<%# Bind("Name") %>' />
                <asp:TextBox runat="server" ID="txtDescription" Text='<%# Bind("Description") %>' />
                <asp:TextBox runat="server" ID="txtCategory" Text='<%# Bind("Category") %>' />
                <asp:TextBox runat="server" ID="txtPrice" Text='<%# Bind("Price") %>' />
                <asp:CheckBox runat="server" ID="chkAvailability" Checked='<%# Bind("Availability") %>' />
                <asp:TextBox runat="server" ID="txtStockQuantity" Text='<%# Bind("StockQuantity") %>' />
                <asp:TextBox runat="server" ID="txtImageURL" Text='<%# Bind("ImageURL") %>' />

                <asp:LinkButton ID="UpdateButton" runat="server" CommandName="Update" CommandArgument='<%# Eval("ItemID") %>' Text="Update" />
                <asp:LinkButton ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
    <asp:LinkButton runat="server" ID="LogoutButton" OnClick="LogoutButton_Click" Text="Logout" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
