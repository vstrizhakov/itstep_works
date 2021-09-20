<?php
	header("Content-Type: image/png");
	if (isset($_GET['values']) && !empty($_GET['values']))
	{
		$values = json_decode($_GET['values'], TRUE);

		$image = imagecreatetruecolor(1920, 1280);
		imagefilledrectangle($image, 0, 0, 1920, 1280, imagecolorallocate($image, 255, 255, 255));
		$white = imagecolorallocate($image, 255, 255, 255);
		$black = imagecolorallocate($image, 0, 0, 0);
		$colors = [];
		$colors[] = imagecolorallocate($image, 55, 255, 175);
		$colors[] = imagecolorallocate($image, 255, 185, 121);
		$colors[] = imagecolorallocate($image, 0, 78, 132);
		$colors[] = imagecolorallocate($image, 0, 34, 25);
		$colors[] = imagecolorallocate($image, 95, 255, 179);
		$colors[] = imagecolorallocate($image, 89, 199, 255);
		$colors[] = imagecolorallocate($image, 255, 255, 0);
		$colors[] = imagecolorallocate($image, 200, 100, 165);
		$colors[] = imagecolorallocate($image, 25, 34, 255);
		$colors[] = imagecolorallocate($image, 179, 255, 0);
		$colors[] = imagecolorallocate($image, 233, 134, 75);
		$colors[] = imagecolorallocate($image, 145, 255, 211);
		$colors[] = imagecolorallocate($image, 199, 75, 75);
		$colors[] = imagecolorallocate($image, 124, 85, 196);
		$colors[] = imagecolorallocate($image, 12, 78, 174);
		$colors[] = imagecolorallocate($image, 196, 34, 251);

		$colors[] = imagecolorallocate($image, 95, 255, 179);
		$colors[] = imagecolorallocate($image, 89, 199, 255);
		$colors[] = imagecolorallocate($image, 255, 255, 0);
		$colors[] = imagecolorallocate($image, 200, 100, 165);
		$colors[] = imagecolorallocate($image, 25, 34, 255);
		$colors[] = imagecolorallocate($image, 179, 255, 0);
		$colors[] = imagecolorallocate($image, 233, 134, 75);
		$colors[] = imagecolorallocate($image, 145, 255, 211);

		$SummaryVotes = array_sum($values);
		
		$i = -90;
		foreach ($values as $key => $value) {
			$color = array_shift($colors);
			$fontSize = 32;
			$centerX = 610;
			$centerY = 640;

			$nextI = ($i + round($value / $SummaryVotes * 360));
			imagefilledarc($image, $centerX, $centerY, 1220, 1140, $i, $nextI, $color, IMG_ARC_PIE);

			static $Y = 64;
			
			$tmp = round($value / $SummaryVotes, 2) * 100;
			imagettftext($image, $fontSize, 0, 1320, $Y, $black, dirname(__FILE__) . '/arial.ttf', "$key - $tmp%");
			imagefilledrectangle($image, 1270, $Y - $fontSize, 1306, $Y, $color);
			$Y += $fontSize * 2;

			$i = $nextI;
		}
		imagepng($image);
	}

?>