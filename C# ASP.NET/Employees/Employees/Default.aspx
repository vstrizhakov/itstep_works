<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Employees.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Employees</title>
    <link href="~/Content/bootstrap.min.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form runat="server">
        <asp:Panel ID="content" runat="server" CssClass="container">
            <asp:Button runat="server" CssClass="btn btn-primary btn-lg btn-block my-4" Text="Добавить сотрудника" OnClick="Unnamed1_Click"/>
        </asp:Panel>
    </form>
</body>
</html>
