<?php

	require_once("common.php");

	$errors = [];

	$messages = ReadMessages("message.json");
	$id = 0;
	if (count($messages) !== 0)
	{
		$id = end($messages)['id'] + 1;
	}

	$email = str_replace('&', '/n/', $_POST['email']);
	$message = str_replace('&', '/n/', $_POST['message']);
	if (empty($email))
	{
		$errors[] = 'Заполните поле "E-Mail"';
	}
	if (empty($message))
	{
		$errors[] = 'Заполните поле "Сообщение"';
	}
	if (empty($errors))
	{
		$date = date(DATE_RSS);

		$strToAppend = str_replace('|', '/p/', "$id&$email&$message&$date") . '|';

		AppendToFile("message.json", $strToAppend);
	}

	header("Content-Type: application/xml");
	header("Cache-Control: no-cache");

?>
<response>
	<?php if (!empty($errors)) { ?>
		<result>1</result>
		<data>
			<?php foreach ($errors as $error) { ?>
				<error><?= $error; ?></error>
			<?php } ?>
		</data>
		<method>displayErrors</method>
	<?php } else { ?>
		<result>0</result>
		<data></data>
		<method></method>
	<?php } ?>
</response>