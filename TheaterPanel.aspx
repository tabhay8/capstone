<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TheaterPanel.aspx.cs" Inherits="MoviePlex.TheaterPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add Theater</h2>
    <asp:Panel ID="PanelAddTheater" runat="server">
        
        <asp:Label runat="server" Text="Theater Name:" AssociatedControlID="txtTheaterName" />
        <asp:TextBox runat="server" ID="txtTheaterName" CssClass="form-control" /><br />

        <asp:Label runat="server" Text="Location:" AssociatedControlID="txtLocation" />
        <asp:TextBox runat="server" ID="txtLocation" CssClass="form-control" /><br />

        <asp:Label runat="server" Text="Total Seats:" AssociatedControlID="txtTotalSeats" />
        <asp:TextBox runat="server" ID="txtTotalSeats" CssClass="form-control" /><br />

        <asp:Button runat="server" ID="btnAddTheater" Text="Add Theater" OnClick="btnAddTheater_Click" CssClass="btn btn-primary" />

    </asp:Panel>

    <hr />

    <h2>Add Theater Timings</h2>
    <asp:Panel ID="PanelAddTheaterTimings" runat="server">
        
        <asp:Label runat="server" Text="Select Theater:" AssociatedControlID="ddlTheater" />
        <asp:DropDownList runat="server" ID="ddlTheater" CssClass="form-control" DataTextField="Name" DataValueField="TheatreID"></asp:DropDownList><br />

        <asp:Label runat="server" Text="Auditorium:" AssociatedControlID="txtAuditorium" />
        <asp:TextBox runat="server" ID="txtAuditorium" CssClass="form-control" /><br />

        <asp:Label runat="server" Text="Select Movie:" AssociatedControlID="ddlMovie" />
        <asp:DropDownList runat="server" ID="ddlMovie" CssClass="form-control" DataTextField="Title" DataValueField="MovieID"></asp:DropDownList><br />

        <asp:Label runat="server" Text="Timing Slot:" AssociatedControlID="txtTimingSlot" />
        <asp:TextBox runat="server" ID="txtTimingSlot" CssClass="form-control" /><br />

        <asp:Button runat="server" ID="btnAddTiming" Text="Add Timing" OnClick="btnAddTiming_Click" CssClass="btn btn-primary" />
    </asp:Panel>
</asp:Content>
