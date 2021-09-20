<?php 

	require_once('common.php');

	// $QuestionsAndAnswers = [
	// 	"Светлая или темная тема?" =>
	// 	[
	// 		"id" => "Theme",
	// 		"Темная" => 'checked="checked"',
	// 		"Светлая" => ''
	// 	],
	// 	"Фигурная скобка с новой или с той же линии?" =>
	// 	[
	// 		"id" => "NewOrTheSameLine",
	// 		"С новой линии" => '',
	// 		"С той же линии" => 'checked="checked"'
	// 	],
	// 	"Программист или Компуктерщик?" =>
	// 	[
	// 		"id" => "ProgrammerOrComputerer",
	// 		"Компуктерщик" => 'checked="checked"',
	// 		"Программист" => ''
	// 	],
	// 	"Билл Гейтс или Коала?" =>
	// 	[
	// 		"id" => "BillOrKoala",
	// 		"Билл Гейтс" => 'checked="checked"',
	// 		"Коала" => ''
	// 	],
	// 	"JPEG или JPG?" =>
	// 	[
	// 		"id" => "JPEGorJPG",
	// 		"JPG" => '',
	// 		"JPEG" => 'checked="checked"'
	// 	],
	// 	"Компьютер или ноутбук?" =>
	// 	[
	// 		"id" => "ComputerOrNotebook",
	// 		"Компьютер" => '',
	// 		"Ноутбук" => 'checked="checked"'
	// 	],
	// 	"илОн или Илон?" =>
	// 	[
	// 		"id" => "ilOnOrIlon",
	// 		"илОн" => 'checked="checked"',
	// 		"Илон" => ''
	// 	],
	// 	"Левая или правая палочка Twix?" =>
	// 	[
	// 		"id" => "LeftOrRightTwix",
	// 		"Левая" => '',
	// 		"Правая" => 'checked="checked"'
	// 	],
	// 	"Floppy Disk или USB Flash Drive?" =>
	// 	[
	// 		"id" => "FloppyOrUsb",
	// 		"Floppy Disk" => '',
	// 		"USB Flash Drive" => 'checked="checked"'
	// 	],
	// 	"Вам понравился опрос?" =>
	// 	[
	// 		"id" => "isVoteLiked",
	// 		"Да" => 'checked="checked"'
	// 	]
	// ];
	// WriteToFile("vote1", $QuestionsAndAnswers);

	$QuestionsAndAnswers = ReadFromFile("vote1");
	$FirstQuestion = key($QuestionsAndAnswers);
?>
<html>
	<head>
		<title>Daily Votes</title>
		<meta charset="utf-8">
		<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
		<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/ulg/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous" defer="defer"></script>
		<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js" integrity="sha384-smHYKdLADwkXOn1EmN1qk/HfnUcbVRZyYmZ4qpPea6sjB/pTJ0euyQp0Mk8ck+5T" crossorigin="anonymous" defer="defer"></script>
		<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
		<script src="main.js"></script>
	</head>
	<body>
		<div class="container">
			<div class="row mt-4">
				<h1 class="mb-0">Daily Votes</h1>
			</div>
			<form action="results.php" method="POST">
				<?php foreach ($QuestionsAndAnswers as $Question => $Answers) { ?>
					<div class="card my-4">
						<div class="card-header toggler toggler-header" style="cursor: pointer;">
							<b><?= $Question; ?></b>
						</div>
						<div class="card-body p-0 <?= ($Question == $FirstQuestion) ? '' : 'collapse'; ?>">
							<?php foreach ($Answers as $Answer => $Ischecked) { if ($Answer === "id") continue; ?>
								<div class="custom-control custom-radio mt-4 ml-4">
									<input name="<?= $Answers["id"]; ?>" <?= $Ischecked; ?> type="radio" id="<?= $Answer; ?>" value="<?= $Answer; ?>" class="custom-control-input">
									<label class="custom-control-label" for="<?= $Answer; ?>"><?= $Answer; ?></label>
								</div>
							<?php } ?>
							<button class="btn btn-primary my-4 ml-4 toggler" type="button">Проголосовать</button>
						</div>
					</div>
				<?php } ?>
				<button class="btn btn-success btn-block mb-4" type="submit" name="submit">Отправить данные</button>
			</form>
		</div>
	</body>
</html>