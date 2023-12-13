<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Movies.aspx.cs" Inherits="MoviePlex.Movies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheet/Movie.css">
<div class="search">
        <asp:TextBox ID="txtSearch" runat="server" placeholder="Search"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" />
    </div>
    <br />
    <asp:Label ID="lblNoResults" runat="server" Text="No results found." Visible="false" CssClass="no-results-message"></asp:Label>
   <image ID="notFound" runat="server" Visible="false" src="Images/notFound.png" Class="no_results"/>

    <div class="movie-grid">
        <asp:Repeater ID="MovieRepeater" runat="server">
    <ItemTemplate>
        <div class="movie-card">
            <a href='<%# "MovieDetails.aspx?movieId=" + Eval("movie_id") %>'>
                <img src='<%# Eval("poster_url") %>' alt="Movie Poster" class="movie-poster" />
                <h3><%# Eval("title") %></h3>
            </a>
            <p>Duration: <%# Eval("duration") %> minutes</p>
        </div>
    </ItemTemplate>
</asp:Repeater>
    </div>
</asp:Content>