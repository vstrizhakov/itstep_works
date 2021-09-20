<?php
	require_once('common.php');
	
	session_start();

	$IDsToQuestions = [];

	if (!file_exists("vote1.json"))
	{
		WriteToFile("vote1", []);
	}
	$QuestionsAndAnswer = ReadFromFile('vote1');
	foreach ($QuestionsAndAnswer as $Question => $Answers)
	{
		$IDsToQuestions[$Answers["id"]] = $Question;
	}

	$resultsFileName = "vote1_results";
	if (!file_exists("$resultsFileName.json"))
	{
		WriteToFile($resultsFileName, []);
	}

	$Results = ReadFromFile($resultsFileName);

	if (isset($_POST["submit"]))
	{
		$UserAnswers = [];

		foreach ($_POST as $key => $value) {
			if (array_key_exists($key, $IDsToQuestions))
			{
				$UserAnswers[$key] = $value;
			}
		}

		if (count($UserAnswers) !== count($IDsToQuestions))
		{
			header("Location: index.php?error=Отправлены недопустимые данные. Попробуйте перезагрузить страницу и отправить данные еще раз.");
		}

		foreach ($UserAnswers as $key => $value) {
			if (array_key_exists($key, $Results))
			{
				if (array_key_exists($value, $Results[$key]))
				{
					$Results[$key][$value]++;
				}
				else
				{
					$Results[$key][$value] = 1;
				}
			}
			else
			{
				$Results[$key] = [
					$value => 1,
				];
			}
		}

		WriteToFile($resultsFileName, $Results);
		// echo '<pre>';
		// var_dump($Results);
		// echo '</pre>';
	}
	$lol = [];
	$SummaryVotesForEachQuestion = [];
	foreach ($Results as $ID => $Answers) {
		$SummaryVotes = 0;
		foreach ($Answers as $Answer => $Votes) {
			$lol[$Answer] = $Votes;
			$SummaryVotes += $Votes;
		}
		$SummaryVotesForEachQuestion[$ID] = $SummaryVotes;
	}
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
			<?php foreach ($Results as $ID => $Answers) { ?>
				<div class="card my-4">
					<div class="card-header" style="cursor: pointer;">
						<b><?= $IDsToQuestions[$ID]; ?></b>
					</div>
					<div class="card-body">
						<img src='<?= "createDiagram.php?values=" . json_encode($Answers); ?>' width="100%">
					</div>
				</div>
			<?php } ?>
			<?php if (!empty($lol)) { ?>
				<div class="card my-4">
					<div class="card-header" style="cursor: pointer;">
						<b>Статистика по всем ответам</b>
					</div>
					<div class="card-body">
						<img src='<?= "createDiagram.php?values=" . json_encode($lol); ?>' width="100%">
					</div>
				</div>
			<?php } else { ?>
				<div class="my-4"><b>Нет результатов опроса</b></div>
			<?php } ?>
			<a href="index.php"><button class="btn btn-block btn-primary mb-4">Назад</button></a>
		</div>
	</body>
</html>