<?php
	function wrap($text, $tag)
	{
		return "<$tag>$text</$tag>";
	}
	
	
	$table = "";
	for ($i = 0; $i < 9; $i++)
	{
		$row = "";
		for ($j = 0; $j < 9; $j++)
		{
			$row .= wrap(($i + 1) * ($j + 1), 'td');
		}
		$table .= wrap($row, 'tr');
	}
	echo wrap($table, 'table');
?>