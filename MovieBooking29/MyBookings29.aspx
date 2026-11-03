<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyBookings29.aspx.cs" Inherits="MovieBooking29.MyBookings29" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>My Bookings</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>My Bookings</h2>

            <asp:Label ID="LblMessage29" runat="server" ForeColor="Red"></asp:Label>

            <asp:GridView ID="GridViewBookings29" runat="server"
                AutoGenerateColumns="False"
                EmptyDataText="No bookings found."
                CellPadding="8"
                GridLines="Both">
                <Columns>
                    <asp:BoundField DataField="booking_ID29" HeaderText="Booking ID" />
                    <asp:BoundField DataField="Movie_name29" HeaderText="Movie Name" />
                    <asp:BoundField DataField="Cat_Type29" HeaderText="Category" />
                    <asp:BoundField DataField="no_of_Tickets29" HeaderText="Tickets" />
                    <asp:BoundField DataField="amount29" HeaderText="Total Amount" DataFormatString="{0:N2}" />
                </Columns>
            </asp:GridView>

            <br />
            <asp:HyperLink ID="LinkHome29" runat="server" NavigateUrl="~/Default29.aspx">Back to Home</asp:HyperLink>
        </div>
    </form>
</body>
</html>