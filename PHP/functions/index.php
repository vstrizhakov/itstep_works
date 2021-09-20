<?php 
	
	function getValues($array, $method)
	{
		foreach ($array as $key => $value)
		{
			$GLOBALS[$key] = (isset($method[$key])) ? $method[$key] : $value;
		}
	}

	getValues(["firstname" => "", "lastname" => "", "age" => 0, "myarray" => []], $_POST);
	echo "<h1>Hello $lastname $firstname</h1>";

?>

<form method="POST">
	<input type="text" name="firstname">
	<input type="text" name="lastname">
	<input type="submit">
</form>