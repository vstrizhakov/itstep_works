<?php

	function StringOrNullFromArray($var, $array)
	{
		$variable = &$array[$var];
		return (isset($variable) && !empty($variable)) ?
			$variable : null;
	}

	function ReadFromFile($filename)
	{
		return json_decode(file_get_contents("$filename.json"), TRUE);
	}

	function WriteToFile($filename, $data)
	{
		$file = fopen("$filename.json", "w");
		fwrite($file, json_encode($data));
		fclose($file);
	}

?>