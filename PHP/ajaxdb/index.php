<?php

	$mysqli = new mysqli("localhost", "root", "", "library");
	if ($mysqli->connect_error)
	{
		die("Ошибка при подключении к Базе Данных.");
	}

	$query = "SELECT category FROM books GROUP BY category ORDER BY category";
	$result = $mysqli->query($query);
	$categories = ($result !== FALSE) ? $result->fetch_all() : [];

	$query = "SELECT themes FROM books GROUP BY themes ORDER BY themes";
	$result = $mysqli->query($query);
	$themes = ($result !== FALSE) ? $result->fetch_all() : [];

	$query = "SELECT izd FROM books GROUP BY izd ORDER BY izd";
	$result = $mysqli->query($query);
	$publications = ($result !== FALSE) ? $result->fetch_all() : [];

?>
<html>
	<head>
		<title>Library</title>
		<meta charset="utf-8">
		<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
		<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/ulg/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous" defer="defer"></script>
		<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js" integrity="sha384-smHYKdLADwkXOn1EmN1qk/HfnUcbVRZyYmZ4qpPea6sjB/pTJ0euyQp0Mk8ck+5T" crossorigin="anonymous" defer="defer"></script>
		<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
		<script src="main.js"></script>
	</head>
	<body>
		<div class="container my-4">
			<div class="page-header">
				<h1>Поиск по библиотеке</h1>
			</div>
			<form class="row my-4" name="search">
				<div class="col col-lg-4">
					<h4>Категория:</h4>
					<select name="category" id="categories" class="custom-select custom-select-lg mb-3">
						<option value="None" selected>Не выбрано...</option>
						<?php foreach ($categories as $category) { 
								if (!empty($category[0])) { ?>
							<option value="<?= $category[0]; ?>" <? if ($category[0] === $cs) echo "selected"; ?>><?= $category[0]; ?></option>
						<?php 	}
							  } ?>
					</select>
				</div>
				<div class="col col-lg-4">
					<h4>Тематика:</h4>
					<select name="theme" id="themes" class="custom-select custom-select-lg mb-3">
						<option value="None" selected>Не выбрано...</option>
						<?php foreach ($themes as $theme) { 
								if (!empty($theme[0])) { ?>
							<option value="<?= $theme[0]; ?>" <? if ($theme[0] === $ts) echo "selected"; ?>><?= $theme[0]; ?></option>
						<?php 	}
							  } ?>
					</select>
				</div>
				<div class="col col-lg-4">
					<h4>Издательство:</h4>
					<select name="publication" id="publications" class="custom-select custom-select-lg mb-3">
						<option value="None" selected>Не выбрано...</option>
						<?php foreach ($publications as $publication) { 
								if (!empty($publication[0])) { ?>
							<option value="<?= $publication[0]; ?>" <? if ($publication[0] === $ps) echo "selected"; ?>><?= $publication[0]; ?></option>
						<?php 	}
							  } ?>
					</select>
				</div>
			</form>
			<table class="table d-none" id="table">
				<thead>
					<tr>
						<th>Название</th>
						<th>Категория</th>
						<th>Тематика</th>
						<th>Издательство</th>
						<th>Цена</th>
					</tr>
				</thead>
				<tbody id="tbody"></tbody>
			</table>
			<h3 class="text-center d-none" id="errors">Книг по заданному запросу не найдено!</h3>
		</div>
	</body>
</html>