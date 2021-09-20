<?php

	function ReadFromFile($filename)
	{
		return file_get_contents("$filename");
	}

	function AppendToFile($filename, $data)
	{
		$file = fopen("$filename", "a+");
		fwrite($file, $data);
		fclose($file);
	}

	function ReadMessages($filename)
	{
		$messages = [];

		if (file_exists($filename))
		{
			$fileContent = ReadFromFile($filename);

			$msgs = explode('|', $fileContent);

			foreach ($msgs as $key => $value) {
				if (empty($value))
				{
					continue;
				}

				$data = explode('&', str_replace('/p/', '|', $value));
				
				$id_ = str_replace('/n/', '&', $data[0]);
				$email_ = str_replace('/n/', '&', $data[1]);
				$message_ = str_replace('/n/', '&', $data[2]);
				$date_ = $data[3];

				$messages[] = [
					'id' => $id_,
					'email' => $email_,
					'content' => $message_,
					'date' => $date_
				];
			}
		}

		return $messages;
	}
?>