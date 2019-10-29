<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="Calculator.Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <style>
        .auto-style2
        {
            width: 150px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <table style="margin: 0 auto; width:50%; text-align: center;" class="my-4">
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="firstNum" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:Button ID="multipleBtn" runat="server" Text="*" OnClick="mathBtn_Click" />
                        <asp:Button ID="plusBtn" runat="server" Text="+" OnClick="mathBtn_Click" />
                        <asp:Button ID="divideBtn" runat="server" Text="/" OnClick="mathBtn_Click" />
                        <asp:Button ID="difBtn" runat="server" Text="-" OnClick="mathBtn_Click" />
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="secondBtn" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="Label1" runat="server" Text="=" Width="100%" CssClass="mx-2"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="result" runat="server" Width="100%"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Label ID="error" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
