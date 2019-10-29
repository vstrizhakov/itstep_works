<%@ Page Title="Library" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Library._Default" %>

<form id="form1" runat="server">
	<div class="container">
		<h1>Библиотека</h1>
		<asp:gridview id="GridView1" runat="server" AutoGenerateColumns="False">
			<Columns>
				<asp:BoundField HeaderText="#" />
				<asp:BoundField HeaderText="Название" />
				<asp:BoundField HeaderText="Категория" />
				<asp:BoundField HeaderText="Тема" />
				<asp:BoundField HeaderText="Автор" />
				<asp:BoundField HeaderText="Издание" />
				<asp:BoundField HeaderText="Количество страниц" />
				<asp:BoundField HeaderText="Цена" />
			</Columns>
		</asp:gridview>
	</div>
</form>
