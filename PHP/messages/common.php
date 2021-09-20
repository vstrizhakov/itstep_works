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

?>