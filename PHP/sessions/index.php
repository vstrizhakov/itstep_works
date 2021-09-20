<?php 

	function get($var, $array)
	{
		return (isset($array[$var]) && !empty(trim($array[$var]))) ? trim(htmlspecialchars($array[$var])) : "";
	}

	if (isset($_POST["submit"]))
	{
		$lastname = get('lastname', $_POST);
		$firstname = get('firstname', $_POST);

		if ((empty($lastname) || empty($firstname)))
		{
			header("Location: sessionform.php?error=Заполните все поля!");
			exit();
		}

		session_start();
		$_SESSION["lastname"] = $lastname;
		$_SESSION["firstname"] = $firstname;
		$session_started = true;
	}
	if (!$session_started)
	{
		session_start();
	}
	$phone = (!empty(get("phone", $_GET))) ? get("phone", $_GET) : get("phone", $_SESSION); 
	$email = (!empty(get("email", $_GET))) ? get("email", $_GET) : get("email", $_SESSION); 
?>
<html>
	<head>
		<meta charset="utf-8">
	</head>
	<body>
		<form action="index2.php" method="POST">
			<?= get('error', $_GET); ?><br>
			Phone: <input type="text" name="phone" value="<?= $phone; ?>"><br>
			E-Mail: <input type="email" name="email" value="<?= $email; ?>"><br>
			<input type="submit" name="submit" value="Next">
		</form>
		<a href="sessionform.php?lastname=<?= $lastname; ?>&firstname=<?= $firstname; ?>"><button>Prev</button></a>
	</body>
</html>
