<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CancelBooking29.aspx.cs" Inherits="MovieBooking29.CancelBooking29" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>Cancel Booking</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Cancel Booking</h2>

            <asp:Label ID="LblMessage29" runat="server"></asp:Label>

            <br /><br />

            <asp:Label ID="LblBooking29" runat="server" Text="Select Booking:"></asp:Label>
            <br />

            <asp:DropDownList ID="DropDownBooking29" runat="server"></asp:DropDownList>

            <br /><br />

            <asp:Button ID="BtnCancel29" runat="server"
                Text="Cancel Booking"
                OnClick="BtnCancel29_Click"
                OnClientClick="return confirm('Are you sure you want to cancel this booking?');" />

            <br /><br />

            <asp:HyperLink ID="LinkBookings29" runat="server" NavigateUrl="~/MyBookings29.aspx">My Bookings</asp:HyperLink>

            <br /><br />

            <asp:HyperLink ID="LinkHome29" runat="server" NavigateUrl="~/Default29.aspx">Back to Home</asp:HyperLink>
        </div>
    </form>
</body>
</html>