<?php
defined('_JEXEC') or die('Restricted access');
class ItemData  // Это класс Модели
{
    public $id;
    public $tovar;
    public $price;
    public $weigth;
    public $id_category;

    // Конструктор - инициализирует значение полей из ассоциативного массива
    // Ассоциативный массив берется при выборке из Базы данных
    function __construct($row = null)
    {
        if($row==null)
        {
            $this->id = 0;
            $this->tovar = "";
            $this->id_category = 0;
            $this->price = "";
            $this->weigth = "";
        }
        else{
            $this->id = $row->id;
            $this->tovar =$row->tovar;
            $this->id_category=$row->id_category;
            $this->price = $row->price;
            $this->weigth = $row->weigth;
            }
    }

    //--------- Получение значения переменных из HTTP-запроса
    public function initFromRequest()
    {
        $app = JFactory::getApplication();

        $this->id = $app->input->get('id', '');
        $this->tovar = $app->input->getString('name','');
        $this->category = $app->input->getString('select', '');
        $this->price = $app->input->getString('price', '');
        $this->weigth = $app->input->getString('weigth', '');

    }
}
// ----------- Class CTovarControllersTovar

class CTovarControllersTovar extends JControllerAdmin
{
    function apply()
    {
        // --- Получение ссылки на обьект Приложение
        $app = JFactory::getApplication();
        $db = JFactory::getDBO();

        // --- Определение - будет ли добавление или обновление 
        $isAdd = $app->input->get('is_add', 'true');

        // --- Восстановление значений из HTTP - запроса
        $obj = new ItemData();
        $obj->initFromRequest();
        $db->setQuery("SELECT id FROM #__ctv_categories WHERE name='{$obj->category}'");
        $categ=$db->loadObjectList();

        if($isAdd!=true)
        {
        // --- Обновление 
            $query = "UPDATE #__ctv_tovars SET tovar='{$obj->tovar}',price={$obj->price}, weigth={$obj->weigth}, id_category={$categ[0]->id} WHERE id=".$obj->id;
        }
        else{

        // --- Вставка
         $query = "INSERT INTO #__ctv_tovars (tovar, price, weigth, id_category) VALUES ('{$obj->tovar}', {$obj->price}, {$obj->weigth}, {$categ[0]->id} )";
        }

        // --- Отправка запроса
       $db->setQuery($query);
       $db->Execute();

        // --- Сообщение об успешном завершении операции
        $app->enqueueMessage("Обновление осуществлено успешно", 'message');

        // --- Переход на отображение списка категорий
        $this->display();

    }
    function edit()
    {
       $app = JFactory::getApplication(); //Ссылка на обьект приложения
       $db = JFactory::getDBO(); // Ссылка на обьект JDatabase

       try
       {
           // ------------- Проверка, что элемент выбран для редактирования
            $id = $app->input->get('boxchecked', '');
            if($id=='')
                throw new Exception("Не выбран элемент списка для редактирования");

            // ------------- Получение даннных из базы данных
       $db->setQuery("SELECT * FROM #__ctv_tovars WHERE id='{$id}'");
       $obj = $db->loadObject();
       if($obj == null)
            throw new Exception("Элемент списка не найден в базе данных");

        $item = new ItemData($obj); // ItemData инициализируем строкой из таблицы

        //-------------- Вызов addOrEdit для создания формы
        $this->addOrEdit($item, "Редактирование товара: ".$item->tovar, false);
       }
       catch(Exception $e)
       {
           $app->input->set('task','');
           $app->enqueueMessage($e->getMessage(),'error');
           $this->display();
       }
       // $this->display();
    }
     // Универсальный метод для добавления/редактирования
    //     $obj - обьект ItemData
    //     $title - надпись в заголовке страницы
    //     $isAdd - признак добавления/Редактирования

    function addOrEdit($obj, $title, $isAdd)
    {
       
        // ---------- Запрет меню джумлы - выйти можно только по "Применить" / "отменить"
        JFactory::getApplication()->input->set('hidemainmenu', 1);

        // ---------- Заголовок
        JToolBarHelper::title('Компонент работы с товарами CTovar : Товары');

        // ---------- Кнопки
        JToolBarHelper::apply();
        JToolBarHelper::cancel();

        // ---------- Подзаголовок функционала
        echo "<h2>$title</h2>";

        // ---------- Отображение
        $db = JFactory::getDBO();
        $db->setQuery("SELECT id, name FROM #__ctv_categories  ORDER BY name");
        $categ=$db->loadObjectList();
        
        ?>
        <form action="index.php" method="POST" name="adminForm" id="adminForm">
            <input type="hidden" name="task" value=""/>
            <input type="hidden" name="option" value="com_ctovar"/>
            <input type="hidden" name="controller" value="tovar"/>

            <input type="hidden" name="id" value="<?php echo $obj->id; ?>"/>
            <input type="hidden" name="is_add" value="<?php echo $isAdd; ?>"/>
        <table>
            <tbody>
            <!-- Название товаров -->
            <tr>
                <td width="300">Название</td>
                <td><input type="text" class="inputbox" name="name" size="60" value="<?php echo $obj->tovar; ?>"></td>
            </tr> 
            <tr>
                <td width="300">Цена</td>
                <td><input type="text" class="inputbox" name="price" size="60" value="<?php echo $obj->price; ?>"></td>
            </tr>
            <tr>
                <td width="300">Вес</td>
                <td><input type="text" class="inputbox" name="weigth" size="60" value="<?php echo $obj->weigth; ?>"></td>
            </tr>
            <tr>
                <td width="300">Категория</td>
                <td>
                    <select name="select" id="">
                    <option disabled selected>Выберите категорию</option>
                    <?php 
                    for ($i=0;$i<count($categ);$i++)
                    {
                         echo "<option value ='{$categ[$i]->name}'";
                            if($obj->id_category == $categ[$i]->id)
                               echo " selected";
                         echo ">{$categ[$i]->name}</option>";
                    }
                    
                    ?>
                    </select>
                </td>
            </tr>
           
        </tbody>
        </table>
        </form>
        <script type="text/javascript">
            // ----------- Валидация данных формы
            Joomla.submitbutton = function(task)
            {
                var form = document.adminForm;
                if(task == 'cancel')
                {
                    //------ Пользователь нажал 'отменить' - проверка не нужна
                    Joomla.submitform(task, document.getElementById('adminForm'));
                    return;
                }
                if(task=='apply')
                {
                    if(form.name.value =='')
                    {
                        // ------ данные не введены - отмена отправки данных
                        alert ('Название Товара не введено');
                        return;
                    }
                    else if(form.select.value == "Выберите категорию"){
                        // ------ данные не введены - отмена отправки данных
                         alert ('Название Категории не выбрано');
                        return;
                    }
                     if(form.price.value == ""){
                        // ------ данные не введены - отмена отправки данных
                         alert ('Цена товара не указана');
                        return;
                    }
                    else
                    {
                        var val = parseFloat(form.price.value);
                        if (isNaN(val) || val != form.price.value || val <= 0)
                        {
                            alert('Введена не корректная цена товара');
                            return;
                        }
                            

                    }
                    if(form.weigth.value == ""){
                        // ------ данные не введены - отмена отправки данных
                         alert ('Вес товара не указан');
                        return;
                    }  
                    else
                    {
                        var val = parseInt(form.weigth.value);
                        if (isNaN(val) || val != form.weigth.value || val <= 0)
                        {
                            alert('Введен не корректный вес товара');
                            return;
                        }
                            
                    } 

                    
                        
                    
                        
                    
                }
                // --------- подтверждение отправки данных 
                Joomla.submitform(task, document.getElementById('adminForm'));
                
            }
        </script>
        <?php
    } // Закрывается метод addOrEdit
    function add()
    {
       $this->addOrEdit(new ItemData(), "Добавление нового товара", true);
        //$this->display();
    }
    function cancel()
    {
        $this->display();
    }
    function __construct($config = array())
    {
        parent:: __construct($config);
        $this->registerTask('add', 'add'); // Добавить
        $this->registerTask('edit', 'edit'); // Изменить
        $this->registerTask('remove', 'remove'); // удалить

        $this->registerTask('cancel', 'cancel'); 
        $this->registerTask('apply', 'apply');  

    }
    function remove()
    {
        $app = JFactory::getApplication();  // ссылка на обьект приложение
        $db = JFactory::getDBO();   // ссылка на обьект JDatabase

        // --- проверка, что элемент списка выбран
        $id = $app->input->get('boxchecked', ''); // чтение из GET или POST

        if($id == '')
        {
            $app->input->set('task','');
            $app->enqueueMessage("Не выбран элемент списка для удаления", 'error');
        }
        else{
            // --- Удаление
            $query = "DELETE FROM #__ctv_tovars WHERE id=".$id;
            $db->setQuery($query);
            $db->execute();
            $app->enqueueMessage("Элемент удален успешно", "message");
        }
        $this->display();
    }
    function display($cachhable = false, $urlparams = array()) // показывает контроллер (его страницу)
    {
       // echo "<h1 style='color: blue'>Товары</h1>";
      
           $db = JFactory::getDBO();
    
           // ---------- Заголовок, кнопки
           JToolBarHelper::title('Компонент Работы С Таворами CTovar : Товары');
    
           // --------- Кнопки
           JToolBarHelper::addNew();   //task add
           JToolBarHelper::editList();   //task edit
           JToolBarHelper::deleteList();   //task delete
         
           // ---------- Извлечение данных из БД
           $db->setQuery("SELECT b.id, b.tovar, b.price, b.weigth, a.name FROM #__ctv_categories a, #__ctv_tovars b WHERE a.id=b.id_category ORDER BY b.tovar");
           $rows=$db->loadObjectList();
           if($rows == null)
           {
               JFactory::getApplication()->enqueueMessage(
                   "Ошибка получения товаров из Базы Данных", "error");
                   return;
           }
           echo "<h1>".JText::_(COM_CTOVAR_TOVARS_LIST)."</h1>";
           ?>
               <form id="adminForm" name="adminForm" action="index.php" method="POST">
                   <input type='hidden' name='task'/>
                   <input type='hidden' name='option' value="com_ctovar"/>
                   <input type='hidden' name='controller' value="tovar"/>
                   <table class="table table-striped">
                       <thead>
                           <tr>
                               <th width="2%">#</th>
                               <th width="10%">Название</th>
                               <th width="5%">Цена</th>
                               <th width="5%">Вес</th>
                               <th width="10%">Категория</th>
                           </tr>
                       </thead>
           <?php
           // -------------------- Вывод списка товаров -----------------
        //    print_r(array_keys ($rows));
        //    print_r(array_values ($rows));

           for($i=0;$i<count($rows);$i++)
           {
            
               echo '<tr>';
               // --------------- Радиобатон
               echo "<td><input type='radio' name='boxchecked' value='{$rows[$i]->id}'/>";
               echo "</td>\n";

               // --------------- Название
               echo "<td>\n";
               echo "<a href='index.php?option=com_ctovar&controller=tovar".
                    "&task=edit&boxchecked={$rows[$i]->id}' title='Редактировать'>\n";
                    echo $rows[$i]->tovar."</a></td>\n";

                // ----- Цена
                echo "<td>\n";
                    echo "<a href='index.php?option=com_ctovar&controller=tovar".
                    "&task=edit&boxchecked={$rows[$i]->id}' title='Редактировать'>\n";
                    echo $rows[$i]->price."</a></td>\n";
                  
                // ----- Вес
                echo "<td>\n";
                    echo "<a href='index.php?option=com_ctovar&controller=tovar".
                    "&task=edit&boxchecked={$rows[$i]->id}' title='Редактировать'>\n";
                    echo $rows[$i]->weigth."</a></td>\n";
                   
               // ----- Категория
                    echo "<td>\n";
                    echo "<a href='index.php?option=com_ctovar&controller=tovar".
                    "&task=edit&boxchecked={$rows[$i]->id}' title='Редактировать'>\n";
                    echo $rows[$i]->name."</a></td>\n";
                    echo "</tr>";
           }
           ?>
           </table>
       </form>
       <?php
    
       }
    

}
?>