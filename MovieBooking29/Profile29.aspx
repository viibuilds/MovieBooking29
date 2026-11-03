
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile29.aspx.cs" Inherits="MovieBooking29.Profile29" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>My Profile</title>
</head>
<body>
    <form id="form1" runat="server">

        <h1>My Profile</h1>

        <p>Full Name</p>
        <asp:TextBox ID="TxtName29" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqName29" runat="server"
            ControlToValidate="TxtName29"
            ErrorMessage="Name is required."
            ForeColor="Red">
        </asp:RequiredFieldValidator>

        <p>Email Address</p>
        <asp:TextBox ID="TxtEmail29" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqEmail29" runat="server"
            ControlToValidate="TxtEmail29"
            ErrorMessage="Email is required."
            ForeColor="Red">
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegEmail29" runat="server"
            ControlToValidate="TxtEmail29"
            ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
            ErrorMessage="Enter a valid email."
            ForeColor="Red">
        </asp:RegularExpressionValidator>

        <p>City</p>
        <asp:TextBox ID="TxtCity29" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqCity29" runat="server"
            ControlToValidate="TxtCity29"
            ErrorMessage="City is required."
            ForeColor="Red">
        </asp:RequiredFieldValidator>

        <p>Phone Number</p>
        <asp:TextBox ID="TxtPhone29" runat="server" MaxLength="15"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqPhone29" runat="server"
            ControlToValidate="TxtPhone29"
            ErrorMessage="Phone is required."
            ForeColor="Red">
        </asp:RequiredFieldValidator>

        <br /><br />

        <asp:Button ID="BtnUpdate29" runat="server"
            Text="Update Profile"
            OnClick="BtnUpdate29_Click" />

        <br /><br />

        <asp:Label ID="LblMessage29" runat="server"></asp:Label>

    </form>
</body>
</html>
