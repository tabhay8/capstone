<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BookingPage.aspx.cs" Inherits="MoviePlex.BookingPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheet/Booking.css" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <img ID="banner" src="Images/Booking/booking.jpg" alt="booking" class="img-fluid">

    <div class="container">
        <div class="nav">
            <a href="UserProfile.aspx">User</a>
        </div>

        <div class="booking-details">
            <!-- Display a calendar control on top -->
            <asp:Calendar ID="calendar" runat="server" OnDayRender="calendar_DayRender" CssClass="calendar"></asp:Calendar>

            <h1>Booking Details</h1>

            <!-- Display available theaters -->
            <div class="form-group">
                <label for="ddlTheaters">Theaters:</label>
                <asp:DropDownList ID="ddlTheaters" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="ddlAuditorium">Auditorium:</label>
                <asp:DropDownList ID="ddlAuditorium" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <!-- Display available show timings -->
            <div class="form-group">
                <label for="ddlShowTimings">Show Timings:</label>
                <asp:DropDownList ID="ddlShowTimings" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <!-- Add a button to confirm the booking -->
            <asp:Button ID="btnConfirmBooking" runat="server" Text="Confirm Booking" OnClick="BtnConfirmBooking_Click" CssClass="btn btn-primary" />
        </div>
    </div>
</asp:Content>
