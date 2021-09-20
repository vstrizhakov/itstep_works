<?php 

	$mysqli = new mysqli("localhost", "root", "", "gallery");
	if ($mysqli->connect_error)
	{
		die("Ошибка при подключении к Базе Данных.");
	}
	if (isset($_POST['submit']) && count($_FILES['photos']['name']) > 0)
	{
		$uploaddir = __DIR__ . '/uploads/';

		for ($i = 0; $i < count($_FILES['photos']['name']); $i++)
		{
			$filename = $_FILES['photos']['name'][$i];
			$tmp_name = $_FILES['photos']['tmp_name'][$i];
			$basename = rand(0, 10000) . basename($filename);
			$path = '/uploads/' . $basename;
			$uploadfile = $uploaddir . $basename;
			move_uploaded_file($tmp_name, $uploadfile);

			$query = "INSERT INTO photos (path) VALUES ('$path')";
			$mysqli->query($query);
		}
		
	}

	$query = "SELECT path FROM photos";
	$result = $mysqli->query($query);
	$imagePaths = ($result !== FALSE) ? $result->fetch_all(MYSQLI_ASSOC) : [];
?>
<html style="height: 100%;">
	<head>
		<title>Gallery</title>
		<meta charset="utf-8">
		<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
		<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/ulg/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous" defer="defer"></script>
		<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js" integrity="sha384-smHYKdLADwkXOn1EmN1qk/HfnUcbVRZyYmZ4qpPea6sjB/pTJ0euyQp0Mk8ck+5T" crossorigin="anonymous" defer="defer"></script>
		<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

		<style>
			.wrapper
			{
				position: fixed;
				left: 0;
				top: 0;
				display: flex;
				justify-content: center;
				align-items: center;
				width: 100%;
				height: 100%;
				background: rgba(0, 0, 0, 0.8);
			}

			#slider
			{
				position: relative;
				max-width: 100%;
				max-height: 720px;
				font-weight: bold;
				font-family: monospace;
				font-size: 35px;
				color: #ccc;
			}

			#slider img
			{
				max-width: 100%; 
				max-height: 720px;
				vertical-align: top;
			}

			#slider div
			{
				display: none;
				text-align: center;
			}

			#slider #current
			{
				display: block;
			}
		</style>
	</head>
	<body style="height: 100%;">
		<nav class="navbar navbar-expand-lg navbar-dark" style="background: #222;">
			<div class="container">
				<form class="form-inline my-2 my-lg-0 mx-auto" enctype="multipart/form-data" method="POST">
					<div class="row">
						<div class="col-lg-9">
							<div class="custom-file">
						    <input name="photos[]" type="file" multiple="multiple" class="custom-file-input" id="inputGroupFile01" aria-describedby="inputGroupFileAddon01" required="required">
						    <label class="custom-file-label" for="inputGroupFile01">Выбрать</label>
						</div>
						</div>
						<div class="col-lg-3">
							<button class="btn btn-outline-success my-2 my-sm-0" type="submit" name="submit">Добавить</button>
						</div>
					</div>
				</form>
			</div>
		</nav>
		<div style="height: 100%;" class="bg-dark w-100 text-white">
			<div class="container">
				<?php

				for ($i = 0; $i < count($imagePaths); $i++)
				{
					if ($i % 6 == 0)
					{ ?>
						<div class="row py-4">
			<?php   } ?>

							<div class="col col-lg-2">
								<img src="/gallery<?= $imagePaths[$i]['path']; ?>" width="100%" class="image" style="cursor: pointer;">
							</div>

			<?php	if ($i % 6 == 5)
					{ ?>
						</div>
			<?php	}
				}

				?>
			</div>
		</div>
		<div class="wrapper" id="slider-wrapper" style="display: none;">
			<div id="slider">
				<div id="current">
					<img src="1.jpg" alt="">
				</div>
			</div>		
		</div>
		<script>
			function showPhoto(evt)
			{
				document.getElementById('slider-wrapper').style.display = 'flex';
				document.getElementById("current").childNodes[1].src = evt.target.src;
			}

			function hidePhoto()
			{
				document.getElementById('slider-wrapper').style.display = 'none';
			}

			var images = document.getElementsByClassName("image");
			for (var i = 0; i < images.length; i++)
			{
				var image = images[i];
				image.onclick = showPhoto;
			}

			var sliderWrapper = document.getElementById("slider-wrapper");
			sliderWrapper.onclick = hidePhoto;
		</script>
	</body>
</html>