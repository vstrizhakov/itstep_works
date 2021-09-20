<?php

	function get($var, $array)
	{
		return (isset($array[$var]) && !empty(trim($array[$var]))) ? trim(htmlspecialchars($array[$var])) : "";
	}
	session_start();
	$firstname = (!empty(get("firstname", $_GET))) ? get("firstname", $_GET) : get("firstname", $_SESSION); 
	$lastname = (!empty(get("lastname", $_GET))) ? get("lastname", $_GET) : get("lastname", $_SESSION); 
?>
<html>
	<head>
		<meta charset="utf-8">
	</head>
	<body>
		<form action="index.php" method="POST">
			<?= get("error", $_GET); ?><br>
			Имя: <input type="text" name="firstname" value="<?= $firstname; ?>"><br>
			Фамилия: <input type="text" name="lastname" value="<?= $lastname; ?>"><br>
			<input type="submit" name="submit" value="Дальше">
		</form>
	</body>
</html>