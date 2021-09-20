<?php

	require_once("Page.php");

	class PageMain extends Page
	{
		public function makeContent()
		{
			echo "<h1 style='color: green;'>Главная страница</h1>";
		}
	}

?>