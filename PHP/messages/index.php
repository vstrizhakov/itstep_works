<?php

	require_once("common.php");

	$errors = "";
	$email = "";
	$message = "";

	if (isset($_POST["sumbit"]))
	{
		$email = str_replace('&', '/n/', $_POST['email']);
		$message = str_replace('&', '/n/', $_POST['message']);
		if (empty($email))
		{
			$errors .= 'Заполните поле "E-Mail"<br>';
		}
		if (empty($message))
		{
			$errors .= 'Заполните поле "Сообщение"<br>';
		}
		if (empty($errors))
		{
			$date = date(DATE_RSS);

			$strToAppend = str_replace('|', '/p/', "$email&$message&$date") . '|';

			AppendToFile("message.json", $strToAppend);
		}
	}

	$messages = [];

	if (file_exists("message.json"))
	{
		$fileContent = ReadFromFile("message.json");

		$msgs = explode('|', $fileContent);

		foreach ($msgs as $key => $value) {
			if (empty($value))
			{
				continue;
			}

			$data = explode('&', str_replace('/p/', '|', $value));
			
			$email_ = str_replace('/n/', '&', $data[0]);
			$message_ = str_replace('/n/', '&', $data[1]);
			$date_ = $data[2];

			$messages[] = [
				'email' => $email_,
				'content' => $message_,
				'date' => $date_
			];
		}
	}
?>
<html>
	<head>
		<title>Message</title>
		<meta charset="utf-8">
		<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
		<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/ulg/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous" defer="defer"></script>
		<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js" integrity="sha384-smHYKdLADwkXOn1EmN1qk/HfnUcbVRZyYmZ4qpPea6sjB/pTJ0euyQp0Mk8ck+5T" crossorigin="anonymous" defer="defer"></script>
		<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
		<script src="main.js"></script>
	</head>
	<body>
		<div class="container">
			<div class="card mt-4 rounded-0">
				<div class="card-header"><h4 class="mb-0">Ваше сообщение</h4></div>
				<div class="card-body">
					<form method="POST">
						<span class="text-danger"><?= $errors; ?></span>
						<div class="form-group">
							<label for="email">E-Mail</label>
							<input name="email" type="email" placeholder="Введите Ваш E-Mail" class="form-control" id="email" value="<?= $email; ?>">
						</div>
						<div class="form-group">
							<label for="message">Текст сообщения</label>
							<textarea name="message" id="message" cols="30" rows="5" placeholder="Введите текст сообщения" class="form-control"><?= $message; ?></textarea>
						</div>
						<button class="btn btn-primary btn-block" type="submit" name="sumbit">Отправить сообщение</button>
					</form>
				</div>
			</div>
			<div class="card mb-4 rounded-0 border-top-0">
				<div class="card-header"><h4 class="mb-0">Все сообщения</h4></div>
				<div class="card-body">
					<ul class="list-group">
						<?php foreach ($messages as $message) { ?>
							<li class="list-group-item">
								<div class="row">
									<div class="col-lg-12">
										<b>E-Mail: </b><?= $message['email']; ?>
									</div>
								</div>
								<div class="row">
									<div class="col-lg-12">
										<b>Сообщение: </b><?= $message['content']; ?>
									</div>
								</div>
								<div class="row">
									<div class="col-lg-12">
										<b>Дата: </b><?= $message['date']; ?>
									</div>
								</div>
							</li>
						<?php } ?>
					</ul>
				</div>
			</div>
		</div>
	</body>
</html>