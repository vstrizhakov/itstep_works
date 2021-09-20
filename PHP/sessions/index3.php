<?php

	function get($var, $array)
	{
		return (isset($array[$var]) && !empty(trim($array[$var]))) ? trim(htmlspecialchars($array[$var])) : "";
	}

	if (isset($_POST["submit"]))
	{
		$telegram = get('telegram', $_POST);
		$skype = get('skype', $_POST);

		if (empty($telegram) || empty($skype))
		{
			header("Location: index2.php?error=Заполните все поля!&telegram=$telegram&skype=$skype");
			exit();
		}

		session_start();
		$_SESSION['telegram'] = $telegram;
		$_SESSION['skype'] = $skype;
		$session_started = true;
	}
	if (!$session_started)
	{
		session_start();
	}
?>
<html>
	<head>
		<meta charset="utf-8">
	</head>
	<body>
		Фамилия: <?= get('lastname', $_SESSION); ?><br>
		Имя: <?= get('firstname', $_SESSION); ?><br>
		Телефон: <?= get('phone', $_SESSION); ?><br>
		E-Mail: <?= get('email', $_SESSION); ?><br>
		Telegram: <?= get('telegram', $_SESSION); ?><br>
		Skype: <?= get('skype', $_SESSION); ?><br>
		Session ID<?= session_id(); ?><br>
		<a href="index2.php?telegram=<?= $telegram; ?>&skype=<?= $skype; ?>"><button>Prev</button></a>
	</body>
</html>