<?php

	function StringOrNullFromArray($var, $array)
	{
		$variable = &$array[$var];
		return (isset($variable) && !empty($variable)) ?
			htmlspecialchars(trim($variable)) : null;
	}

	function SvezhakOrRedirectTo($redirectTo, $ifAuthenticated)
	{
		$svezhak = Svezhak::GetInstance();

		try
		{
			$isAuthenticated = $svezhak->CheckAuth();
		}
		catch (Exception $e)
		{
			echo $e->getMessage();
			exit();
		}

		if ($isAuthenticated === $ifAuthenticated)
		{
			header("Location: $redirectTo.php");
			exit();
		}
		else
		{
			return $svezhak;
		}
	}

	function hashVariable($var)
	{
		return md5(md5($var . "456") . "123");
	}
?>