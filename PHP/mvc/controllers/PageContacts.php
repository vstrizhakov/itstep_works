<?php
    require_once("controllers/Page.php");

    class PageContacts extends Page
    {
        public function makeContent()
        {
            echo "<h1 style='color:green'>Страница Контактов</h1>";
        }
    }
?>