<?php

	function get($var, $array)
	{
		return (isset($array[$var]) && !empty(trim($array[$var]))) ? trim(htmlspecialchars($array[$var])) : "";
	}

	if (isset($_POST["submit"]))
	{
		$phone = get('phone', $_POST);
		$email = get('email', $_POST);

		if ((empty($phone) || empty($email)) && count($_GET) == 0)
		{
			header("Location: index.php?error=Заполните все поля!&phone=$phone&email=$email");
			exit();
		}

		session_start();
		$_SESSION['phone'] = $phone;
		$_SESSION['email'] = $email;
		$session_started = true;
	}
	if (!$session_started)
	{
		session_start();
	}
	$telegram = (!empty(get("telegram", $_GET))) ? get("telegram", $_GET) : get("telegram", $_SESSION); 
	$skype = (!empty(get("skype", $_GET))) ? get("skype", $_GET) : get("skype", $_SESSION); 
?>
<html>
	<head>
		<meta charset="utf-8">
	</head>
	<body>
		<form action="index3.php" method="POST">
			<?= get('error', $_GET); ?><br>
			Telegram: <input type="text" name="telegram" value="<?= $telegram; ?>"><br>
			Skype: <input type="text" name="skype" value="<?= $skype; ?>"><br>
			<input type="submit" name="submit" value="Next">
		</form>
		<a href="index.php?phone=<?= $phone; ?>&email=<?= $email; ?>"><button>Prev</button></a>
	</body>
</html>