<!DOCTYPE html>
<html>
<head>
	<title><?= $title; ?></title>
	<meta charset="utf-8">
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
	<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/ulg/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous" defer="defer"></script>
	<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js" integrity="sha384-smHYKdLADwkXOn1EmN1qk/HfnUcbVRZyYmZ4qpPea6sjB/pTJ0euyQp0Mk8ck+5T" crossorigin="anonymous" defer="defer"></script>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
</head>
<body>
	<div class="navbar navbar-dark navbar-expand-md bg-dark">
		<div class="container">
			<a class="navbar-brand" href="/"><?= $name; ?></a>
			<button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbar">
				<span class="navbar-toggler-icon"></span>
			</button>
			<div class="collapse navbar-collapse" id="navbar">
				<ul class="navbar-nav ml-auto fright">
					<?php foreach ($menu as $key => $item) { ?>
						<li class="nav-item active">
							<a href="<?= $item; ?>" class="nav-link"><?= $key; ?><span class="sr-only">(current)</span></a>
						</li>
					<?php } ?>
					<?php if (!defined('NOT_AUTHENTICATED')) { ?>
						<li class="nav-item active">
							<a href="logout.php" class="nav-link">Выход<span class="sr-only">(current)</span></a>
						</li>
					<?php } ?>
				</ul>
			</div>
		</div>
	</div>
	<div class="container">
		<?php if (isset($_SESSION["is_authenticated"]) && isset($_SESSION["username"]) && !empty($_SESSION["username"])) { ?>
			<div class="alert alert-success mt-4" role="alert">
				<h4 class="alert-heading mb-0">Здравствуйте, <?= $_SESSION['username'];?>!</h4>
			</div>
		<?php } ?>