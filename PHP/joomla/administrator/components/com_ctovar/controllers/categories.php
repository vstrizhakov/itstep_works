<?php
defined('_JEXEC') or die('Restricted access');

// Class ItemData - инкапсулирует данные одной категории (строки из таблицы #__ctv_categories)
// (применяется в методах Добавить/Редактировать)
class ItemData  // Это класс Модели
{
    public $id;
    public $name;

    // Конструктор - инициализирует значение полей из ассоциативного массива
    // Ассоциативный массив берется при выборке из Базы данных
    function __construct($row = null)
    {
        if($row==null)
        {
            $this->id = 0;
            $this->name = "";
           // echo "Hello";
        }
        else{
            $this->id = $row->id;
            //echo ($row->name."<br/>");
            $this->name =$row->name;
           
        }
    }

    //--------- Получение значения переменных из HTTP-запроса
    public function initFromRequest()
    {
        $app = JFactory::getApplication();

        $this->id = $app->input->get('id', '');
        $this->name = $app->input->getString('name','');
    }
}
// ----------- Class CTovarControllersCategories

class CTovarControllersCategories extends JControllerAdmin
{
    function __construct($config = array())
    {
        parent:: __construct($config);
        $this->registerTask('add', 'add'); // Добавить
        $this->registerTask('edit', 'edit'); // Изменить
        $this->registerTask('remove', 'remove'); // удалить

        $this->registerTask('cancel', 'cancel'); 
        $this->registerTask('apply', 'apply');  

    }
    function add()
    {
       $this->addOrEdit(new ItemData(), "Добавление новой категории", true);
        //$this->display();
    }

    // Универсальный метод для добавления/редактирования
    //     $obj - обьект ItemData
    //     $title - надпись в заголовке страницы
    //     $isAdd - признак добавления/Редактирования

    function addOrEdit($obj, $title, $isAdd)
    {
        // ---------- Запрет меню джумлы - выйти можно только по "Применить" / "отменить"
        //JFactory::getApplication()->input->set('hidemainmenu', 1);

        // ---------- Заголовок
        JToolBarHelper::title('Компонент работы с товарами CTovar : Категории');

        // ---------- Кнопки
        JToolBarHelper::apply();
        JToolBarHelper::cancel();

        // ---------- Подзаголовок функционала
        echo "<h2>$title</h2>";

        // ---------- Отображение
        ?>
        <form action="index.php" method="POST" name="adminForm" id="adminForm">
            <input type="hidden" name="task" value=""/>
            <input type="hidden" name="option" value="com_ctovar"/>
            <input type="hidden" name="controller" value="categories"/>

            <input type="hidden" name="id" value="<?php echo $obj->id; ?>"/>
            <input type="hidden" name="is_add" value="<?php echo $isAdd; ?>"/>
        <table>
            <tbody>
            <!-- Название категории -->
            <tr>
                <td width="300">Название</td>
                <td><input type="text" class="inputbox" name="name" size="60" value="<?php echo $obj->name; ?>"></td>
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
                        alert ('Название Категории не введено');
                        return;
                    }
                }
                // --------- подтверждение отправки данных 
                Joomla.submitform(task, document.getElementById('adminForm'));
            }
        </script>
        <?php
    } // Закрывается метод addOrEdit
    
    function edit()
    {
       $app = JFactory::getApplication(); //Ссылка на обьект приложения
       $db = JFactory::getDBO(); // Ссылка на обьект JDatabase

       try
       {
           // ------------- Проверка, что элемент выбран для редактирования
            $id = $app->input->get('boxchecked', '');
            if($id=='')
                throw new Exception("Не выбрана категория для редактирования");

            // ------------- Получение даннных из базы данных
       $db->setQuery("SELECT * FROM #__ctv_categories WHERE id='{$id}'");
       $obj = $db->loadObject();
       if($obj == null)
            throw new Exception("Категория не найдена в базе данных");

        $item = new ItemData($obj); // ItemData инициализируем строкой из таблицы

        //-------------- Вызов addOrEdit для создания формы
        $this->addOrEdit($item, "Редактирование категории: ".$item->name, false);
       }
       catch(Exception $e)
       {
           $app->input->set('task','');
           $app->enqueueMessage($e->getMessage(),'error');
           $this->display();
       }
       // $this->display();
    }
    function remove()
    {
        $app = JFactory::getApplication();  // ссылка на обьект приложение
        $db = JFactory::getDBO();   // ссылка на обьект JDatabase

        // ------------------------ проверка, что элемент списка выбран
        $id = $app->input->get('boxchecked', ''); // чтение из GET или POST

        if($id == '')
        {
            $app->input->set('task','');
            $app->enqueueMessage("Не выбрана категория списка для удаления", 'error');
        }
        else{
            // ----------------------- Удаление
			$query = "SELECT * FROM #__ctv_tovars WHERE id_category='{$id}'";
			$db->setQuery($query);
			$obj = $db->loadObject();
			if($obj != null)
			{
				$app->enqueueMessage("Невозможно удалить категорию, так как существуют товары, находящиеся в данной категории. Сначала удалите товары, затем попробуйте снова удалить категорию.", "error");
			}
			else
			{
				$query = "DELETE FROM #__ctv_categories WHERE id=".$id;
				$db->setQuery($query);
				$db->execute();
				$app->enqueueMessage("Категория удалена успешно", "message");
			}
        }
        $this->display();
    }
    function apply()
    {
        //------------------------ Получение ссылки на обьект Приложение
        $app = JFactory::getApplication();
        $db = JFactory::getDBO();

        // --- Определение - будет ли добавление или обновление 
        $isAdd = $app->input->get('is_add', 'true');

        // --- Восстановление значений из HTTP - запроса
        $obj = new ItemData();
        $obj->initFromRequest();

        if($isAdd!=true)
        {
        // --- Обновление 
            $query = "UPDATE #__ctv_categories SET name='{$obj->name}' WHERE id=".$obj->id;
        }
        else{
        // --- Вставка
        $query = "INSERT INTO #__ctv_categories (name) VALUES ('{$obj->name}')";
        }

        // --- Отправка запроса
        $db->setQuery($query);
        $db->Execute();

        // --- Сообщение об успешном завершении операции
        $app->enqueueMessage("Обновление осуществлено успешно", 'message');

        // --- Переход на отображение списка категорий
        $this->display();

    }
    function cancel()
    {
        $this->display();
    }
    function display($cachhable = false, $urlparams = array()) // показывает контроллер (его страницу)
    {
        $db = JFactory::getDBO();

        // ---------- Заголовок, кнопки
        JToolBarHelper::title('Компонент для работы с продуктами CTovar : Категории');

        // --------- Кнопки
        JToolBarHelper::addNew();   //task add
        JToolBarHelper::editList();   //task edit
        JToolBarHelper::deleteList();   //task delete
      
        // ---------- Извлечение данных из БД
        $db->setQuery("SELECT id, name FROM #__ctv_categories ORDER BY name");
        $rows = $db->loadObjectList();
        if($rows == null)
        {
            JFactory::getApplication()->enqueueMessage(
                "Ошибка получения категории из Базы Данных", "error");
                return;
        }
        echo "<h1>".JText::_('COM_CTOVAR_CATEGORIES_LIST')."</h1>";
        ?>
            <form id="adminForm" name="adminForm" action="index.php" method="POST">
                <input type='hidden' name='task'/>
                <input type='hidden' name='option' value="com_ctovar"/>
                <input type='hidden' name='controller' value="categories"/>
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th width="2%">#</th>
                            <th width="98%">Название</th>
                        </tr>
                    </thead>
        <?php
        // -------------------- Вывод списка категорий -----------------
        for($i=0;$i<count($rows);$i++)
        {
            echo '<tr>';
            // --------------- Радиобатон
            echo "<td><input type='radio' name='boxchecked' value='{$rows[$i]->id}'/>";
            echo "</td>\n";
            // --------------- Название
            echo "<td>\n";
            echo "<a href='index.php?option=com_ctovar&controller=categories".
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