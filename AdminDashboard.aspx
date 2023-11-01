<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="MoviePlex.AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Admin Dashboard - Manage Movies</h1>

    <div class="add-movie-form">
    <h2>Add Movie</h2>
    <asp:TextBox runat="server" ID="TitleTextBox" placeholder="Title"></asp:TextBox>
    <asp:TextBox runat="server" ID="GenreTextBox" placeholder="Genre"></asp:TextBox>
    <asp:TextBox runat="server" ID="ReleaseDateTextBox" placeholder="Release Date"></asp:TextBox>
    <asp:TextBox runat="server" ID="DescriptionTextBox" placeholder="Description"></asp:TextBox>
    <asp:TextBox runat="server" ID="DurationTextBox" placeholder="Duration"></asp:TextBox>
    <asp:TextBox runat="server" ID="DirectorTextBox" placeholder="Director"></asp:TextBox>
    <asp:FileUpload runat="server" ID="PosterUpload" />
    <asp:Button runat="server" ID="AddMovieButton" Text="Add Movie" OnClick="AddMovieButton_Click" />
     </div>

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
</asp:Content>