
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register29.aspx.cs" Inherits="MovieBooking29.Register29" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>User Registration</title>
</head>
<body>
    <form id="form1" runat="server">

        <h1>User Registration</h1>

        <p>Full Name</p>
        <asp:TextBox ID="TxtName29" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqName29" runat="server"
            ControlToValidate="TxtName29" ErrorMessage="Name is required." ForeColor="Red"></asp:RequiredFieldValidator>

        <p>Email Address</p>
        <asp:TextBox ID="TxtEmail29" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqEmail29" runat="server"
            ControlToValidate="TxtEmail29" ErrorMessage="Email is required." ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegEmail29" runat="server"
            ControlToValidate="TxtEmail29"
            ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
            ErrorMessage="Enter a valid email." ForeColor="Red"></asp:RegularExpressionValidator>

        <p>Password</p>
        <asp:TextBox ID="TxtPassword29" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqPassword29" runat="server"
            ControlToValidate="TxtPassword29" ErrorMessage="Password is required." ForeColor="Red"></asp:RequiredFieldValidator>

        <p>City</p>
        <asp:TextBox ID="TxtCity29" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqCity29" runat="server"
            ControlToValidate="TxtCity29" ErrorMessage="City is required." ForeColor="Red"></asp:RequiredFieldValidator>

        <p>Phone Number</p>
        <asp:TextBox ID="TxtPhone29" runat="server" MaxLength="15"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqPhone29" runat="server"
            ControlToValidate="TxtPhone29" ErrorMessage="Phone number is required." ForeColor="Red"></asp:RequiredFieldValidator>

        <br /><br />

        <asp:Button ID="BtnRegister29" runat="server"
            Text="Register" OnClick="BtnRegister29_Click" />

        <br /><br />

        <asp:Label ID="LblMessage29" runat="server"></asp:Label>

    </form>
</body>
</html>
