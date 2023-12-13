<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MovieDetails.aspx.cs" Inherits="MoviePlex.MovieDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheet/Moviedetails.css">
    <div class="movie-details">
        <div class="column movie-poster">
            <asp:Image ID="imgPoster" runat="server" CssClass="movie-poster" AlternateText="Movie Poster" />
        </div>
        <div class="column movie-details-content">
            <h1>Movie Details</h1>
            <h2>Movie Title: <asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
            <p>Duration: <asp:Label ID="lblDuration" runat="server"></asp:Label> minutes</p>
            <p>Description: <asp:Label ID="lblDescription" runat="server"></asp:Label></p>
            <p>Genre: <asp:Label ID="lblGenre" runat="server"></asp:Label></p>
            <p>Release Date: <asp:Label ID="lblReleaseDate" runat="server"></asp:Label></p>
            <p>Director: <asp:Label ID="lblDirector" runat="server"></asp:Label></p>
            
            <!-- Display Average Rating -->
            <p><asp:Label ID="lblAverageRating" runat="server"></asp:Label></p>
            
            
            <asp:Repeater ID="allReviewsRepeater" runat="server">
    <HeaderTemplate>
        <h2>All Reviews</h2>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <p>Rating: <asp:Label ID="lblAllReviewRating" runat="server" Text='<%# Eval("Rating") %>'></asp:Label></p>
            <p>Comment: <asp:Label ID="lblAllReviewComment" runat="server" Text='<%# Eval("Comment") %>'></asp:Label></p>
            <p>Posted by: <asp:Label ID="lblAllReviewUserName" runat="server" Text='<%# Eval("UserName") %>'></asp:Label></p>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>

        </div>
        <div class="column">
            <asp:Button ID="btnBookShow" runat="server" Text="Book a Show" OnClick="BtnBookShow_Click" CssClass="book-show-button" />
            <h2>Write a Review</h2>
            <asp:TextBox ID="txtReviewComment" runat="server" placeholder="Write your review" TextMode="MultiLine"></asp:TextBox>
            <asp:DropDownList ID="ddlRating" runat="server">
                <asp:ListItem Text="1" Value="1" />
                <asp:ListItem Text="2" Value="2" />
                <asp:ListItem Text="3" Value="3" />
                <asp:ListItem Text="4" Value="4" />
                <asp:ListItem Text="5" Value="5" />
            </asp:DropDownList>
            <asp:Button ID="btnSubmitReview" runat="server" Text="Submit Review" OnClick="BtnSubmitReview_Click" />
        </div>
    </div>
</asp:Content>
