<?php

	require_once("./menu.php");

	$c = (isset($_GET['c'])) ? $_GET['c'] : "Main";

	$menu = new Menu();
	$menu->addItem("Main", "Главная");
	$menu->addItem("Price", "Цены");
	$menu->addItem("Contacts", "Контакты");
	$menu->addItem("News", "Новости");

	$controller = "Page$c";

	require_once("controllers/$controller.php");

	$page = new $controller($menu);
	$page->showPage();
?>