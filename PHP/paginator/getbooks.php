<?php

	function StringOrNullFromArray($var, $array)
	{
		$variable = &$array[$var];
		return (isset($variable) && !empty($variable)) ?
			$variable : null;
	}

	$mysqli = new mysqli("localhost", "root", "", "library");
	if ($mysqli->connect_error)
	{
		die("Ошибка при подключении к Базе Данных.");
	}

	$where = "";

	$category = StringOrNullFromArray("category", $_POST);
	$theme = StringOrNullFromArray("theme", $_POST);
	$publication = StringOrNullFromArray("publication", $_POST);
	$page = StringOrNullFromArray("page", $_GET);
	$limit = 10;
	$offset = $limit * $page;

	if (is_null($offset))
	{
		$offset = 0;
	}

	$conditions = [];

	if ($category !== "None")
	{
		$conditions[] = "category = '$category'";
	}

	if ($theme !== "None")
	{
		$conditions[] = "themes = '$theme'";
	}

	if ($publication !== "None")
	{
		$conditions[] = "izd = '$publication'";
	}

	$conditionsCount = count($conditions);
	if ($conditionsCount > 0)
	{
		$where = " WHERE ";
		for ($i = 0; $i < $conditionsCount; $i++)
		{
			$where .= $conditions[$i];
			if ($i + 1 !== $conditionsCount)
			{
				$where .= " AND";
			}
			$where .= " ";
		}
	}
	
	$query = "SELECT name, izd, price, themes, category FROM books $where ORDER BY name LIMIT $limit OFFSET $offset";
	$result = $mysqli->query($query);
	$books = ($result !== FALSE) ? $result->fetch_all(MYSQLI_ASSOC) : [];

	$query = "SELECT COUNT(*) FROM books $where";
	$result = $mysqli->query($query);
	$booksCount = ($result !== FALSE) ? $result->fetch_row()[0] : 0;

	header("Content-Type: application/xml");
	header('Cache-Control: no-cache');
?>
<?php if (count($books) > 0) { ?>
	<response>
		<result>0</result>
		<method>displayBooks</method>
		<data>
			<?php foreach ($books as $book) { ?>
				<book>
					<name><?= htmlspecialchars($book['name']); ?></name>
					<category><?= htmlspecialchars($book['category']); ?></category>
					<theme><?= htmlspecialchars($book['themes']); ?></theme>
					<publication><?= htmlspecialchars($book['izd']); ?></publication>
					<price><?= number_format($book['price'], 2, '.', ''); ?></price>
				</book>
			<?php } ?>
		</data>
		<pagesCount><?= ceil($booksCount / $limit); ?></pagesCount>
	</response>
<?php } else { ?>
	<response>
		<result>1</result>
		<method>displayErrors</method>
		<data>
			<error>Книг по заданному запросу не найдено!</error>
		</data>
	</response>
<?php } ?>