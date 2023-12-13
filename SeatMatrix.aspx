<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeatMatrix.aspx.cs" Inherits="MoviePlex.SeatMatrix" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Seats</title>
    <link rel="stylesheet" type="text/css" href="stylesheet/stylesheet.css"/>
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
    
<style>
        .selected {
            background-color: lightblue;
        }

        .button-container {
            display: grid;
            grid-template-columns: repeat(5, 1fr);
            gap: 10px;
            width:70%;
            margin-left: 10%;
         
        }

        .toggle-button {
            width: 100%;
            height: 30px;
        }
    </style>
</head>
<body>
     <div class="header">
                <div class="logo">
                    <img src="Images/Logo.png" alt="Your Logo"/>
                </div>
                <div class="nav">
                    <a href="Home.aspx">Home</a>
                    <a href="Movies.aspx">Movies</a>
                    <a href="FoodDrinks.aspx">Food and drinks</a>
                    <a href="Contact.aspx">Contact</a>
                </div>
                
            </div>
    <form id="form1" runat="server">
        <h1> Seats</h1>
         <h2>Select Your Seats</h2>
        <div>
            <asp:Label ID="lblTheater" runat="server" Text=""></asp:Label><br />
             <asp:Label ID="lblTheaterName" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblShowTiming" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblAuditorium" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblDate" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="timing_id" runat="server" Text=""></asp:Label><br />
        </div>

        <div class="button-container">
            <asp:Button ID="toggleButton1" runat="server" Text="seat 1" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton2" runat="server" Text="seat 2" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton3" runat="server" Text="seat 3" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton4" runat="server" Text="seat 4" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton5" runat="server" Text="seat 5" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton6" runat="server" Text="seat 6" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton7" runat="server" Text="seat 7" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton8" runat="server" Text="seat 8" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton9" runat="server" Text="seat 9" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton10" runat="server" Text="seat 10" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton11" runat="server" Text="seat 11" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton12" runat="server" Text="seat 12" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton13" runat="server" Text="seat 13" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton14" runat="server" Text="seat 14" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton15" runat="server" Text="seat 15" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton16" runat="server" Text="seat 16" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton17" runat="server" Text="seat 17" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton18" runat="server" Text="seat 18" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton19" runat="server" Text="seat 19" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton20" runat="server" Text="seat 20" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton21" runat="server" Text="seat 21" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton22" runat="server" Text="seat 22" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton23" runat="server" Text="seat 23" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton24" runat="server" Text="seat 24" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton25" runat="server" Text="seat 25" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton26" runat="server" Text="seat 26" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton27" runat="server" Text="seat 27" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton28" runat="server" Text="seat 28" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton29" runat="server" Text="seat 29" CssClass="toggle-button" OnClick="toggleButtonClick" />
            <asp:Button ID="toggleButton30" runat="server" Text="seat 30" CssClass="toggle-button" OnClick="toggleButtonClick" />
        </div>

        <br />

        <asp:Button ID="goToNextPageBtn" runat="server" Text="Go To Cart" OnClick="goToNextPage" />
    </form>
     <div class="footer">
            <div class="footer-column">
                <a href="Career.aspx">Careers</a>
            </div>
            <div class="footer-column">
                Whats new?
            </div>
            <div class="footer-column">
                 <a href="New.aspx">Upcoming movies </a>
            </div>
        </div>
</body>

</html>
