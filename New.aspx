<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="MoviePlex.New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Upcoming Movies</h2>

   
    <div id="movieCarousel" class="carousel slide" data-ride="carousel">
        <div class="carousel-inner">
            <asp:Repeater ID="MoviesRepeater" runat="server">
                <ItemTemplate>
                    <div class='<%# Container.ItemIndex == 0 ? "carousel-item active" : "carousel-item" %>'>
                        <div class="d-flex justify-content-center align-items-center">
                            <asp:Image ID="MoviePoster" runat="server" ImageUrl='<%# Eval("poster_url") %>' Width="200" />
                        </div>
                        <div class="text-center">
                            <h3><%# Eval("title") %></h3>
                            <p><strong>Genre:</strong> <%# Eval("genre") %></p>
                            <p><strong>Release Date:</strong> <%# Eval("release_date", "{0:yyyy-MM-dd}") %></p>
                            <p><strong>Description:</strong> <%# Eval("description") %></p>
                            <p><strong>Duration:</strong> <%# Eval("duration") %></p>
                            <p><strong>Director:</strong> <%# Eval("director") %></p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        
        <a class="carousel-control-prev" href="#movieCarousel" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#movieCarousel" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>

    

</asp:Content>
