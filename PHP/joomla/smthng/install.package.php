<?php
defined ('_JEXEC') or die ('Restricted access');

// При установке, обновлении или удалении компонента могут потребоваться дополнительные операции,
// которые не обеспечиваются основными операциями, описанными в основном файле xml.
// Joomla! предлагает новый подход к решению этой проблемы. Он заключается в использовании файла
// сценапия, содержащего класс с именем вида com_ИмяКомпонентаInstallerScript, в котором 
// используется 5 методов:
//     preflight - выполняется перед установкой или обновлением
//     install - вызывается при установке компонента
//     update - вызывается при обновлении компонента
//     uninstall - вызывается при удалении компонента
//     postflight - выполняется после установки и обновления.

class com_CTovarInstallerScript
{
    function install ($parent)
    {
        $db = JFactory::getDBO(); // Ссылка на обьект для взаимодействия с БД
        
        // ----------- Удаление таблицы "Товары", если остались от предыдущей установки
        $q = "DROP TABLE IF EXISTS #__ctv_tovars";
        $db->setQuery($q);
        $db->execute();     // execute: INSERT, UPDATE, DELETE, CREATE, DROP

        // ----------- Удаление таблицы "Категории", если остались от предыдущей установки 
        $q = "DROP TABLE IF EXISTS #__ctv_categories";
        $db->setQuery($q);
        $db->execute();

        // ----------- Создание таблицы "Категории"
        $q = "CREATE TABLE #__ctv_categories(".
            "id int not null primary key auto_increment, ".
            "name varchar(32) ".
            ") DEFAULT CHARSET=utf8";
        $db->setQuery($q);
        $db->execute();

        
        // ----------- Создание таблицы "Товары"
        $q = "CREATE TABLE #__ctv_tovars(".
            "id int not null primary key auto_increment, ".
            "tovar varchar(64), ".
            "price decimal(10,2),".
            "weigth int,".
            "id_category int".
            ") DEFAULT CHARSET=utf8";
        $db->setQuery($q);
        $db->execute();

        $db->setQuery("INSERT INTO #__ctv_tovars (tovar, price, weigth, id_category) VALUES ('Snickers',14.50,45,1) ");
        $db->execute();
        $db->setQuery("INSERT INTO #__ctv_tovars (tovar, price, weigth, id_category) VALUES ('Bounty',13.0,40,1) ");
        $db->execute();
        $db->setQuery("INSERT INTO #__ctv_tovars (tovar, price, weigth, id_category) VALUES ('Cola',12,0.5,2) ");
        $db->execute();
        $db->setQuery("INSERT INTO #__ctv_tovars (tovar, price, weigth, id_category) VALUES ('Рогалик',8.40,0.2,3) ");
        $db->execute();
        $db->setQuery("INSERT INTO #__ctv_categories (name) VALUES ('Батончики')");
        $db->execute();
        $db->setQuery("INSERT INTO #__ctv_categories (name) VALUES ('Напитки')");
        $db->execute();
        $db->setQuery("INSERT INTO #__ctv_categories (name) VALUES ('Хлебобулочные изделия')");
        $db->execute();

        // ----------- Вывод информации о результатах инсталяции
        JFactory::getApplication()->enqueueMessage(JText::_("COM_CTOVAR_INSTALL_SUCCESSFULL"), 'message');
    }
    function uninstall($parent)
    {
        $db = JFactory::getDBO();

        // ------------- Удаление таблицы "Товары"
        $q = "DROP TABLE #__ctv_tovars";
        $db->setQuery($q);
        $db->execute();

         // ------------- Удаление таблицы "Категории"
         $q = "DROP TABLE #__ctv_categories";
         $db->setQuery($q);
         $db->execute();
            // ----------- Вывод информации о результатах деинсталяции
        JFactory::getApplication()->enqueueMessage(JText::_("COM_CTOVAR_UNINSTALL_SUCCESSFULL"), 'message');
    }
    // Цвета сообщений:
    // message - зелененькие
    // warning - желтенькие (предупреждения)
    // error -   красненькие (ошибки)

    // метод: JText::_(string) - принимает строку (языковую константу) и ищет ее среди языковых файлов.
}

?>