<?php
    require_once("./Menu.php");
    class Page
    {
        private $menu;

        public function __construct(Menu $menu)
        {
            $this->menu = $menu;
        }
        protected function makeHeader(){ // Формирует заголовочную часть страницы
            echo "<div style='border: 1px solid red; text-align: center;width: 100%; height: 100px'>";
            echo "<h1>Заголовок сайта</h1>";
            echo "</div>";
        }
        protected function makeMenu(){  // Формирует меню
            echo $this->menu;
        }
        protected function makeContent(){ // Формирует контент страницы (будет перегружаться) 
            echo "<h1 style='color:red'>404. Страница не найдена</h1>";
        }
        protected function makeFooter(){ // Формирует подвальную часть страницы
            echo "<div style='border: 1px solid green; text-align: center;width: 100%; height: 70px'>";
            echo "<h2>Подвал сайта</h2>";
            echo "</div>";
        }
        public function showPage() // Формирует всю страницу целиком
        {
            $this->makeHeader();
            $this->makeMenu();
            $this->makeContent();
            $this->makeFooter();

        }
    }
?>