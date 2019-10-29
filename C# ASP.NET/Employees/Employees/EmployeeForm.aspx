<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeForm.aspx.cs" Inherits="Employees.EmployeeForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Employees</title>
    <link href="~/Content/bootstrap.min.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server" class="my-4">
        <asp:Panel runat="server" ID="panel" class="container">
            <div class="form-group">
                <label for="firstName">Имя</label>
                <asp:TextBox runat="server" name="firstName" type="text" class="form-control" id="firstName" placeholder="Имя"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="lastName">Фамилия</label>
                <asp:TextBox runat="server" name="lastName" type="text" class="form-control" id="lastName" placeholder="Фамилия"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="age">Возраст</label>
                <asp:TextBox runat="server" name="age" type="number" class="form-control" id="age" placeholder="Возраст"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="post">Должность</label>
                <asp:TextBox runat="server" name="post" type="text" class="form-control" id="post" placeholder="Должность"></asp:TextBox>
            </div>
            <div class="form-check form-check-inline">
                <asp:RadioButton GroupName="sex" runat="server" class="form-check-input" type="radio" name="sex" id="male" value="male" checked></asp:RadioButton>
                <label class="form-check-label" for="male">Мужчина</label>
            </div>
            <div class="form-check form-check-inline">
                <asp:RadioButton GroupName="sex" runat="server" class="form-check-input" type="radio" name="sex" id="female" value="female"></asp:RadioButton>
                <label class="form-check-label" for="female">Женщина</label>
            </div>
            <asp:Label ID="error" runat="server" CssClass="row mx-1 text-danger my-2"></asp:Label>
            <asp:Button ID="btn" runat="server" CssClass="btn btn-lg btn-block btn-success my-3" Text="Добавить"></asp:Button>
        </asp:Panel>
    </form>
</body>
</html>
