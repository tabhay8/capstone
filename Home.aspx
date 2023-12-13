<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MoviePlex.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheet/HomeStyleSheet.css">
    <div class="banner-container">
        <div class="banner-slider">
            <div class="banner-slide">
                <img src="Images/banner/Banner1.jpg" alt="Image 1">
            </div>
            <div class="banner-slide">
                <img src="Images/banner/Banner2.jpg" alt="Image 2">
            </div> 
         
        </div>
       
    </div>
    
    <div class="column-container">
        <div class="column">
            <img src="Images/homepage/screen.jpg" alt="Wide Theatre Screen">
            <p>A cinematic experience like no other awaits you with our wide theatre screens. Immerse yourself in stunning visuals that bring your favorite movies to life. Get ready for a visual journey like never before.</p>
        </div>
        <div class="column">
            <img src="Images/homepage/3d.jpg" alt="3D Glasses">
            <p>Explore the magic of 3D with our high-quality 3D glasses. Dive into a world where characters and scenes leap off the screen. Experience depth and realism in your movies with our top-notch 3D glassess</p>
        </div>
        <div class="column">
            <img src="Images/homepage/recliner.jpg" alt="Recliner Seats">
            <p>Take relaxation to the next level with our plush recliner seats. Enjoy unparalleled comfort as you watch your favorite films. Sit back, unwind, and savor every moment in the lap of luxury with our recliner seats</p>
        </div>
    </div>
    

    

<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<script src="JS/BannerSlide.js"></script>


</asp:Content>

