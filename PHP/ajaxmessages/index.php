<?php

	require_once("common.php");

	$messages = ReadMessages("message.json");
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
					<form name="msg">
						<span class="text-danger" id="errors"></span>
						<div class="form-group">
							<label for="email">E-Mail</label>
							<input name="email" type="email" placeholder="Введите Ваш E-Mail" class="form-control" id="email">
						</div>
						<div class="form-group">
							<label for="message">Текст сообщения</label>
							<textarea name="message" id="message" cols="30" rows="5" placeholder="Введите текст сообщения" class="form-control"></textarea>
						</div>
						<button class="btn btn-primary btn-block" type="button" name="sumbit" id="addMessageButton">Отправить сообщение</button>
					</form>
				</div>
			</div>
			<div class="card mb-4 rounded-0 border-top-0">
				<div class="card-header"><h4 class="mb-0">Все сообщения</h4></div>
				<div class="card-body">
					<ul class="list-group" id="messages"></ul>
				</div>
			</div>
		</div>
	</body>
</html>