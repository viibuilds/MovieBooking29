
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default29.aspx.cs" Inherits="MovieBooking29.Default29" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>Movie Booking System</title>
</head>
<body>
    <form id="form1" runat="server">

        <h1>Movie Booking System</h1>

        <hr />

        <h2>My Account</h2>

        <asp:HyperLink ID="LinkMyBookings29" runat="server" NavigateUrl="~/MyBookings29.aspx">My Bookings</asp:HyperLink>

        &nbsp;&nbsp;|&nbsp;&nbsp;

        <asp:HyperLink ID="LinkUpdateBooking29" runat="server" NavigateUrl="~/UpdateBooking29.aspx">Update Booking</asp:HyperLink>

        &nbsp;&nbsp;|&nbsp;&nbsp;

        <asp:HyperLink ID="LinkCancelBooking29" runat="server" NavigateUrl="~/CancelBooking29.aspx">Cancel Booking</asp:HyperLink>

        <hr />

        <h2>Add Movie Category</h2>

        <asp:TextBox ID="TxtCategory29" runat="server" placeholder="Enter Category Name"></asp:TextBox>
        <asp:Button ID="BtnAddCategory29" runat="server" Text="Add Category" OnClick="BtnAddCategory29_Click" />

        <br /><br />

        <asp:Label ID="LblCategoryMessage29" runat="server"></asp:Label>

        <hr />

        <h2>Add New Movie</h2>

        Movie Name:
        <asp:TextBox ID="TxtMovieName29" runat="server"></asp:TextBox>

        <br /><br />

        Release Date:
        <asp:TextBox ID="TxtReleaseDate29" runat="server"></asp:TextBox>

        <br /><br />

        Category:
        <asp:DropDownList ID="DropDownMovieCategory29" runat="server"></asp:DropDownList>

        <br /><br />

        Ticket Rate:
        <asp:TextBox ID="TxtRate29" runat="server"></asp:TextBox>

        <br /><br />

        <asp:Button ID="BtnAddMovie29" runat="server" Text="Add Movie" OnClick="BtnAddMovie29_Click" />

        <br /><br />

        <asp:Label ID="LblMovieMessage29" runat="server"></asp:Label>

        <hr />

        <h2>Book Movie Tickets</h2>

        Movie Category:

        <asp:DropDownList ID="DropDownBookingCategory29" runat="server"
            AutoPostBack="true"
            OnSelectedIndexChanged="DropDownBookingCategory29_SelectedIndexChanged">
        </asp:DropDownList>

        <br /><br />

        Select Movie:

        <asp:DropDownList ID="DropDownBookingMovie29" runat="server"
            AutoPostBack="true"
            OnSelectedIndexChanged="DropDownBookingMovie29_SelectedIndexChanged">
        </asp:DropDownList>

        <br /><br />

        Number of Tickets:

        <asp:TextBox ID="TxtTickets29" runat="server"
            Text="1" AutoPostBack="true"
            OnTextChanged="TxtTickets29_TextChanged">
        </asp:TextBox>

        <br /><br />

        Total Amount:

        <asp:Label ID="LblAmount29" runat="server" Text="0"></asp:Label>

        <br /><br />

        <asp:Button ID="BtnBook29" runat="server"
            Text="Book Tickets"
            OnClick="BtnBook29_Click" />

        <br /><br />

        <asp:Label ID="LblBookingMessage29" runat="server"></asp:Label>

        <hr />

        <h2>Available Movies</h2>

        Select Movie Category:

        <asp:DropDownList ID="DropDownCategory29" runat="server"
            AutoPostBack="true"
            OnSelectedIndexChanged="DropDownCategory29_SelectedIndexChanged">
        </asp:DropDownList>

        <br /><br />

        <asp:GridView ID="GridViewMovie29" runat="server"
            AutoGenerateColumns="true"
            DataKeyNames="Movie_ID29"
            OnRowDeleting="GridViewMovie29_RowDeleting">

            <Columns>
                <asp:CommandField ShowDeleteButton="true" />
            </Columns>

        </asp:GridView>

        <asp:Label ID="LblDeleteMessage29" runat="server"></asp:Label>

    </form>
</body>
</html>
