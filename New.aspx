<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="MoviePlex.New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Upcoming Movies</h2>
    <asp:GridView ID="GridViewMovies" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="title" HeaderText="Title" />
            <asp:BoundField DataField="genre" HeaderText="Genre" />
            <asp:BoundField DataField="release_date" HeaderText="Release Date" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="description" HeaderText="Description" />
            <asp:BoundField DataField="duration" HeaderText="Duration" />
            <asp:BoundField DataField="director" HeaderText="Director" />
            <asp:TemplateField HeaderText="Poster">
                <ItemTemplate>
                    <asp:Image ID="MoviePoster" runat="server" ImageUrl='<%# Eval("poster_url") %>' Width="100" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
