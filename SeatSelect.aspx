<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SeatSelect.aspx.cs" Inherits="MoviePlex.SeatSelect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
    .seat-matrix-container {
        text-align: center;
        margin: 50px auto;
    }

    .seat-matrix-table {
        width: 80%;
        border: 1px solid #ccc;
        border-collapse: collapse;
        margin: 0 auto;
    }

    .seat-matrix-table th, .seat-matrix-table td {
        padding: 10px;
        text-align: center;
        border: 0px solid #ccc;
    }

    .seat-button {
        width: 30px;
        height: 30px;
        font-size: 16px;
    }

    .cart-button {
        margin-top: 20px;
    }
</style>

    <div class="seat-matrix-container">
        <h2>Select Your Seats</h2>
        <table class="seat-matrix-table">
            <asp:Repeater ID="SeatMatrixRepeater" runat="server">
                <HeaderTemplate>
                    <tr>
                        <th>Row</th>
                        <th>Seats</th>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("RowNumber") %></td>
                        <td>
                            <asp:Repeater ID="SeatRepeater" runat="server" DataSource='<%# Eval("Seats") %>'>
                                <ItemTemplate>
                                    <asp:Button ID="SeatButton" runat="server" Text='<%# Container.DataItem %>' OnClick="SeatButton_Click" CssClass="seat-button" />
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>

        <asp:Button ID="btnGoToCart" runat="server" Text="Go to Cart" OnClick="BtnGoToCart_Click" CssClass="cart-button" Visible="false" />
    </div>
</asp:Content>
