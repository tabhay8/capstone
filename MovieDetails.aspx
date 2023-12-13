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
        </div>
        <div class="column">
           
            <asp:Button ID="btnBookShow" runat="server" Text="Book a Show" OnClick="BtnBookShow_Click" CssClass="book-show-button" />
        </div>
    </div>
</asp:Content>
