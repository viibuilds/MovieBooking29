<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateBooking29.aspx.cs" Inherits="MovieBooking29.UpdateBooking29" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>Update Booking</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Update Booking</h2>

            <asp:Label ID="LblMessage29" runat="server"></asp:Label>

            <br /><br />

            <asp:Label ID="LblBooking29" runat="server" Text="Select Booking:"></asp:Label>
            <br />

            <asp:DropDownList ID="DropDownBooking29" runat="server"
                AutoPostBack="True"
                OnSelectedIndexChanged="DropDownBooking29_SelectedIndexChanged">
            </asp:DropDownList>

            <br /><br />

            <asp:Label ID="LblMovie29" runat="server" Text="Movie:"></asp:Label>
            <br />

            <asp:TextBox ID="TxtMovie29" runat="server" ReadOnly="True"></asp:TextBox>

            <br /><br />

            <asp:Label ID="LblTickets29" runat="server" Text="Number of Tickets:"></asp:Label>
            <br />

            <asp:TextBox ID="TxtTickets29" runat="server" TextMode="Number"></asp:TextBox>

            <br /><br />

            <asp:Button ID="BtnUpdate29" runat="server"
                Text="Update Booking"
                OnClick="BtnUpdate29_Click" />

            <br /><br />

            <asp:HyperLink ID="LinkBookings29" runat="server" NavigateUrl="~/MyBookings29.aspx">My Bookings</asp:HyperLink>

            <br /><br />

            <asp:HyperLink ID="LinkHome29" runat="server" NavigateUrl="~/Default29.aspx">Back to Home</asp:HyperLink>
        </div>
    </form>
</body>
</html>