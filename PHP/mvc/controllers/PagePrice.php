<?php
	
    require_once("controllers/Page.php");

	class PagePrice extends Page {
		public function makeContent()
		{
			echo "<h1 style='color: green;'>Страница цены</h1>";
		}
	}

?>