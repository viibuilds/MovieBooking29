
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
