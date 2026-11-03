
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login29.aspx.cs" Inherits="MovieBooking29.Login29" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>User Login</title>
</head>
<body>
    <form id="form1" runat="server">

        <h1>User Login</h1>

        <p>Email Address</p>
        <asp:TextBox ID="TxtEmail29" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator ID="ReqEmail29" runat="server"
            ControlToValidate="TxtEmail29"
            ErrorMessage="Email is required."
            ForeColor="Red">
        </asp:RequiredFieldValidator>

        <p>Password</p>
        <asp:TextBox ID="TxtPassword29" runat="server"
            TextMode="Password">
        </asp:TextBox>

        <asp:RequiredFieldValidator ID="ReqPassword29" runat="server"
            ControlToValidate="TxtPassword29"
            ErrorMessage="Password is required."
            ForeColor="Red">
        </asp:RequiredFieldValidator>

        <br /><br />

        <asp:Button ID="BtnLogin29" runat="server"
            Text="Login"
            OnClick="BtnLogin29_Click" />

        <br /><br />

        <asp:Label ID="LblMessage29" runat="server"></asp:Label>

    </form>
</body>
</html>
