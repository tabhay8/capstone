<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MoviePlex.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1>Contact Us</h1>
        <p>If you have any questions, comments, or feedback, please feel free to contact us using the information below:</p>
        <address>
            <strong>MoviePlex</strong><br />
            123 Main Street<br />
            City, State ZIP<br />
            Email: <a href="mailto:info@movieplex.com">info@movieplex.com</a><br />
            Phone: (123) 456-7890
        </address>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <h2>Our Locations</h2>

        <div class="row">
            <div class="col-md-6">
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3152.748458286553!2d-122.41941538476793!3d37.77492977975935!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x80858096511de713%3A0x51c8c9222a44b5f9!2sSan%20Francisco%2C%20CA!5e0!3m2!1sen!2sus!4v1640111115684!5m2!1sen!2sus" width="100%" height="300" style="border:0;" allowfullscreen="" loading="lazy"></iframe>
            </div>
            <div class="col-md-6">
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3304.3632055323174!2d-118.24368448482548!3d34.052235685112356!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x80c2c75ddc27da13%3A0xe22fdfa24751edf6!2sLos%20Angeles%2C%20CA!5e0!3m2!1sen!2sus!4v1640111152691!5m2!1sen!2sus" width="100%" height="300" style="border:0;" allowfullscreen="" loading="lazy"></iframe>
            </div>
        </div>
    </div>
</asp:Content>
