<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Movies.aspx.cs" Inherits="MoviePlex.Movies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="search form-inline my-2 my-lg-0">
            <asp:TextBox ID="txtSearch" runat="server" placeholder="Search" CssClass="form-control mr-sm-2"></asp:TextBox>
            <asp:DropDownList ID="ddlGenres" runat="server" CssClass="form-control mr-sm-2">
               
            </asp:DropDownList>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" CssClass="btn btn-outline-success my-2 my-sm-0" />
        </div>

        <br />

        <asp:Label ID="lblNoResults" runat="server" Text="No results found." Visible="false" CssClass="no-results-message"></asp:Label>
        <img ID="notFound" runat="server" Visible="false" src="Images/notFound.png" class="no_results img-fluid" />

        <div class="movie-grid row">
            <asp:Repeater ID="MovieRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-lg-3 col-md-4 col-sm-6 mb-4">
                        <div class="card">
                            <a href='<%# "MovieDetails.aspx?movieId=" + Eval("movie_id") %>'>
                                <img src='<%# Eval("poster_url") %>' alt="Movie Poster" class="card-img-top movie-poster" />
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("title") %></h5>
                                    <p class="card-text">Duration: <%# Eval("duration") %> minutes</p>
                                </div>
                            </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
