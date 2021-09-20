<?php
	require_once("CommonFunctions.php");
	require_once("SvezhakClass.php");

	define('NOT_AUTHENTICATED', 0);

	session_start();
	$svezhak = SvezhakOrRedirectTo("index", TRUE);

	if (isset($_POST["login"]))
	{
		$username = StringOrNullFromArray("username", $_POST);
		$password = StringOrNullFromArray("password", $_POST);

		$loginResult = $svezhak->Login($username, $password);
		if ($loginResult === TRUE)
		{
			header("Location: /");
		}
		else
		{
			$errors = $loginResult;
		}
	}
	elseif (isset($_POST["register"]))
	{
		$username = StringOrNullFromArray("username", $_POST);
		$password = StringOrNullFromArray("password", $_POST);

		$registerResult = $svezhak->Register($username, $password);
		if ($registerResult === TRUE)
		{
			header("Location: /");
		}
		else
		{
			$errors = $registerResult;
		}
	}
	
	extract($svezhak->GetData());
?>
<?php include('html/header.php'); ?>

	<form method="POST" class="rounded border mt-4 p-3">
		<div class="alert alert-danger" style="display: <?= isset($errors) ? 'block' : 'none'; ?>;">
			<ul class="mb-0">
				<?php foreach ($errors as $error) { ?>
					<li><?= $error; ?></li>
				<?php } ?>
			</ul>
		</div>
	  	<div class="form-group">
			<label for="exampleInputEmail1">Логин</label>
			<input type="text" name="username" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Введите логин">
	  	</div>
	  	<div class="form-group">
			<label for="exampleInputPassword1">Пароль</label>
			<input type="password" name="password" class="form-control" id="exampleInputPassword1" placeholder="Пароль">
	 	</div>
	  	<button type="submit" name="login" class="btn btn-primary">Войти</button>
	  	<button type="submit" name="register" class="btn btn-secondary">Зарегистрироваться</button>
	</form>

<?php include("html/footer.php"); ?>
