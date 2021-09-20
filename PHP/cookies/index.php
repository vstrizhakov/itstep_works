<?php 
	if (isset($_COOKIE["words"]))
	{
		$words = $_COOKIE["words"];
	}
	else
	{
		$words = [];
	}
	if (isset($_POST["clear"]))
	{
		for ($i = 0; $i <= count($words); $i++)
		{
			setcookie("words[$i]", "", time() + 3600);			
		}
		$words = [];
	}
	else if (isset($_POST["submit"]))
	{
		if (isset($_POST["newWord"]) && !empty(trim($_POST["newWord"])))
		{
			$words[] = $_POST["newWord"];
			setcookie("words[" . count($words) . "]", $_POST["newWord"], time() + 3600);
		}
		else
		{
			$error = "Введите слово!";
		}
	}

?>
<html>
	<head>
		<title>Cookies</title>
		<meta charset="utf-8">
		<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
		<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/ulg/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous" defer="defer"></script>
		<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js" integrity="sha384-smHYKdLADwkXOn1EmN1qk/HfnUcbVRZyYmZ4qpPea6sjB/pTJ0euyQp0Mk8ck+5T" crossorigin="anonymous" defer="defer"></script>
		<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
	</head>
	<body>
		<div class="container">
			<form action="" class="mt-4 rounded border border-1 p-4" method="POST">
				<div class="form-group">
					<label for="previousWords">Раннее введенные слова:</label>
					<select id="previousWords" class="custom-select"><?php if (!count($words)) echo "Введенных ранее слов нет!"; ?>
						<?php foreach ($words as $key => $word) { ?>
							<option value="<?= $word; ?>" <?php if (!$key) echo "selected"; ?>><?= $word; ?></option>
						<?php } ?>
					</select>
				</div>
				<div class="form-group">
					<label for="newWord">Новое слово:</label>
					<input type="text" name="newWord" id="newWord" class="form-control" placeholder="Введите новое слово...">
				</div>
				<p class="text-center" style="color: red;"><?php if (!empty($error)) echo $error; ?></p>
				<button class="btn btn-success btn-block" type="submit" name="submit">Добавить слово</button>					
				<button class="btn btn-danger btn-block" type="submit" name="clear">Очистить список</button>					
			</form>
		</div>
	</body>
</html>