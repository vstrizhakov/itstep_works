<?php

	require_once("controllers/Page.php");

    class PageNews extends Page
    {
        public function makeContent()
        {
            echo "<h1 style='color:green'>Страница Новостей</h1>";
        }
    }

?>