<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="career.aspx.cs" Inherits="MoviePlex.career" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        /* Style for job postings */
        .job-posting {
            background-color: #f8f8f8;
            border: 1px solid #ddd;
            padding: 15px;
            margin: 10px;
            border-radius: 5px;
        }

        .job-posting h2 {
            font-size: 24px;
            margin-bottom: 10px;
        }

        /* Style for job application form */
        .job-application-form {
            background-color: #f8f8f8;
            border: 1px solid #ddd;
            padding: 15px;
            margin: 10px;
            border-radius: 5px;
        }

        .job-application-form h2 {
            font-size: 24px;
            margin-bottom: 10px;
        }

        .form-label {
            display: block;
            margin-top: 10px;
        }

        .form-input {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            margin-bottom: 10px;
        }

        .form-textarea {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            margin-bottom: 10px;
        }

        .form-select {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            margin-bottom: 10px;
        }

        .form-button {
            background-color: #007bff;
            color: #fff;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!-- Job Postings Section -->
    <div class="job-posting">
        <h2>Job Title: Software Developer</h2>
        <p>Company: MoviePlex</p>
        <p>Location: Ontario, Canada</p>
        <p>Description: We are looking for a skilled software developer to join our team. If you are passionate about programming and love building great software, we want to hear from you.</p>
    </div>

    <div class="job-posting">
        <h2>Job Title: Graphic Designer</h2>
        <p>Company: MoviePlex</p>
        <p>Location: BC, Canada</p>
        <p>Description: Are you a creative graphic designer with an eye for design and a passion for creating visually appealing content? Join our team and help us make our projects shine.</p>
    </div>

    <div class="job-posting">
        <h2>Job Title: Marketing Manager</h2>
        <p>Company: MoviePlex</p>
        <p>Location: Nova scotia, Canada</p>
        <p>Description: We are seeking a talented marketing manager to lead our marketing efforts. If you have a knack for marketing strategy and campaign management, we want you on our team.</p>
    </div>

    <!-- Job Application Form -->
    <div class="job-application-form">
        <h2>Apply for a Job</h2>
        <label class="form-label" for="txtName">Full Name:</label>
        <asp:TextBox ID="txtName" runat="server" CssClass="form-input"></asp:TextBox>

        <label class="form-label" for="txtEmail">Email:</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-input"></asp:TextBox>

        <label class="form-label" for="fileResume">Resume (PDF):</label>
        <asp:FileUpload ID="fileResume" runat="server" CssClass="form-input" />

        <label class="form-label" for="ddlJobTitle">Select a Job:</label>
        <asp:DropDownList ID="ddlJobTitle" runat="server" CssClass="form-select">
            <asp:ListItem Text="Software Developer" Value="Software Developer" />
            <asp:ListItem Text="Graphic Designer" Value="Graphic Designer" />
            <asp:ListItem Text="Marketing Manager" Value="Marketing Manager" />
        </asp:DropDownList>

        <label class="form-label" for="txtExperience">Years of Experience:</label>
        <asp:TextBox ID="txtExperience" runat="server" CssClass="form-input"></asp:TextBox>

        <label class="form-label" for="txtCoverLetter">Cover Letter:</label>
        <asp:TextBox ID="txtCoverLetter" runat="server" CssClass="form-textarea" TextMode="MultiLine" Rows="4"></asp:TextBox>

        <asp:Button ID="btnApply" runat="server" Text="Submit Application" CssClass="form-button" />
    </div>
</asp:Content>
