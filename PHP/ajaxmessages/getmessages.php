<?php

	require_once("common.php");

	do
	{
		$messages = ReadMessages("message.json");

		if (isset($_GET['lastMessageId']) && !empty($_GET['lastMessageId']))
		{
			foreach ($messages as $key => $message) {
				if ($message['id'] < $_GET['lastMessageId'])
				{
					unset($messages[$key]);
				}
			}
		}
	} while (count($messages) === 0);

	header('Content-Type: application/xml');
	header('Cache-Control: no-cache');
?>
<response>
	<result><?= (count($messages) === 0) ? 1 : 0; ?></result>
	<data>
		<?php foreach ($messages as $message) { ?>
			<message>
				<id><?= $message['id']; ?></id>
				<email><?= $message['email']; ?></email>
				<content><?= $message['content']; ?></content>
				<date><?= $message['date']; ?></date>
			</message>
		<?php } ?>
	</data>
	<method>addMessages</method>
</response>