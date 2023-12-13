<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="MoviePlex.AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1>Admin Dashboard - Manage Movies</h1>

        <div class="row">
            <div class="col-md-12">
                <div class="add-movie-form">
                    <h2>Add Movie</h2>
                    <asp:TextBox runat="server" ID="TitleTextBox" CssClass="form-control" placeholder="Title"></asp:TextBox>
                    <asp:TextBox runat="server" ID="GenreTextBox" CssClass="form-control" placeholder="Genre"></asp:TextBox>
                    <asp:TextBox runat="server" ID="ReleaseDateTextBox" CssClass="form-control" placeholder="Release Date"></asp:TextBox>
                    <asp:TextBox runat="server" ID="DescriptionTextBox" CssClass="form-control" placeholder="Description"></asp:TextBox>
                    <asp:TextBox runat="server" ID="DurationTextBox" CssClass="form-control" placeholder="Duration"></asp:TextBox>
                    <asp:TextBox runat="server" ID="DirectorTextBox" CssClass="form-control" placeholder="Director"></asp:TextBox>
                    <asp:FileUpload runat="server" ID="PosterUpload" CssClass="form-control" />
                    <asp:Button runat="server" ID="AddMovieButton" CssClass="btn btn-primary" Text="Add Movie" OnClick="AddMovieButton_Click" />
                </div>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-12">
                <h2>Movie List</h2>
                <asp:GridView runat="server" ID="MoviesGridView" AutoGenerateColumns="false" DataKeyNames="movie_id" OnRowDeleting="MoviesGridView_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="movie_id" HeaderText="Movie ID" />
                        <asp:BoundField DataField="title" HeaderText="Title" />
                        <asp:BoundField DataField="genre" HeaderText="Genre" />
                        <asp:BoundField DataField="release_date" HeaderText="Release Date" />
                        <asp:BoundField DataField="description" HeaderText="Description" />
                        <asp:BoundField DataField="duration" HeaderText="Duration" />
                        <asp:BoundField DataField="director" HeaderText="Director" />
                        <asp:TemplateField HeaderText="Poster">
                            <ItemTemplate>
                                <asp:Image ID="PosterImage" runat="server" ImageUrl='<%# Eval("poster_url") %>' Width="100" Height="150" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:LinkButton ID="EditButton" runat="server" CommandName="Edit" CommandArgument='<%# Eval("movie_id") %>' Text="" />
                                <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Delete" CommandArgument='<%# Eval("movie_id") %>' Text="Delete" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-12">
                <h2>Movie View</h2>
                <p>Log out or manage theater timings</p>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-12">
                <asp:LinkButton runat="server" ID="LogoutButton" OnClick="LogoutButton_Click" CssClass="btn btn-danger" Text="Logout" />
                <asp:LinkButton runat="server" ID="TheaterTimings" OnClick="TheaterTimings_Click" CssClass="btn btn-secondary" Text="Manage Theater Timings" />
            </div>
        </div>
    </div>
</asp:Content>
