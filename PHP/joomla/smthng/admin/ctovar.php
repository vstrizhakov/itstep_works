<?php
   defined("_JEXEC") or die ("Restricted access"); // Проверка, запускается ли сценарий джумлой

   //-------- Отображение пунктов меню Компонента

   $arr = array(
       'categories' => array ('Категории', 'index.php?option=com_ctovar&controller=categories'),
       'tovar' => array('Товары', 'index.php?option=com_ctovar&controller=tovar')
   );

   $vName = JFactory::getApplication()->input->get('controller', 'categories');
   foreach($arr as $aKey=>$aValue)
   {
       JSubMenuHelper::addEntry(JText::_($aValue[0]),($aValue[1]), $vName == $aKKey);
   }
  // echo "<h1 style='color: blue'>Component CTovar: Site</h1>";

   // ------------- Загрузка необходимого контроллера

   // ------------- Load classes 
   JLoader::registerPrefix('CTovar', JPATH_COMPONENT_ADMINISTRATOR);

   // ------------- Application
   $app = JFactory::getApplication();

   // ------------- Require specific controller if requested
   $controller = $app->input->get('controller', 'categories'); // Читаем controller, если нет, то = categories
   $app->input->set('controller', $controller); // Принудительно записываем controller в полученные данные

   // ------------- Create the controller
   $classname = 'CTovarControllers'.ucwords($controller); // Формирование имени класс
  // echo $classname;
   $controller = new $classname();

   // ------------- Perform the Request task
   $controller->execute($app->input->get('task'));


  
?>