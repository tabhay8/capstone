<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BookingPage.aspx.cs" Inherits="MoviePlex.BookingPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheet/Booking.css" />
    <img ID="banner"src="Images/Booking/booking.jpg" alt="booking">
    <div class="booking-details">
        
        <h1>Booking Details</h1>
        
        <!-- Display available theaters -->
        <h2>Theaters:</h2>
        <asp:DropDownList ID="ddlTheaters" runat="server"></asp:DropDownList>
        
        <!-- Display available show timings -->
        <h2>Show Timings:</h2>
        <asp:DropDownList ID="ddlShowTimings" runat="server"></asp:DropDownList>
        
        <!-- Add a button to confirm the booking -->
        <asp:Button ID="btnConfirmBooking" runat="server" Text="Confirm Booking" OnClick="BtnConfirmBooking_Click" CssClass="confirm-booking-button" />
    </div>
</asp:Content>
