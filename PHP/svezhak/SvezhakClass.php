<?php

	class Svezhak
	{
		#=====================================================================================#
		# Private Fields #

		private $name;
		private $title;
		private $menu;
		private $news;
		private $contacts;

		private $users;

		# ~Private Fields #
		#=====================================================================================#
		# Static Public Fields #

		static public $instance = null;

		# ~Static Public Fields #
		#=====================================================================================#
		# Static Public Methods #

		static public function GetInstance()
		{
			if (is_null(self::$instance))
			{
				self::$instance = new Svezhak();
			}
			return self::$instance;
		}

		# ~Static Public Methods #
		#=====================================================================================#
		# Public Methods #

		public function GetData()
		{
			$fieldsToExtract = [];
			$fieldsToExtract['name'] = $this->name;
			$fieldsToExtract['title'] = $this->title;
			$fieldsToExtract['menu'] = $this->menu;
			if (isset($_SESSION["is_authenticated"]) && isset($_SESSION["username"]) && !empty($_SESSION["username"]))
			{
				$fieldsToExtract['news'] = $this->news;
				$fieldsToExtract['contacts'] = $this->contacts;
				$fieldsToExtract['prices'] = $this->prices;
			}
			return $fieldsToExtract;		
		}

		public function CheckAuth()
		{
			if (isset($_SESSION))
			{
				if (StringOrNullFromArray("is_authenticated", $_SESSION))
				{
					$username = StringOrNullFromArray("username", $_SESSION);
					$password = StringOrNullFromArray("password", $_SESSION);

					if (!is_null($username) && !is_null($password))
					{
						return (array_key_exists($username, $this->users) && $this->users[$username] == $password);
					}
					else
					{
						return FALSE;
					}
				}
				else
				{
					return FALSE;
				}
			}
			else
			{
				throw new Exception("You need call session_start() to check user authentication", 1);
			}
		}

		public function Login($username, $password)
		{
			if (!is_null($username) && !is_null($password))
			{
				if (array_key_exists($username, $this->users) && $this->users[$username] == hashVariable($password))
				{
					if (isset($_SESSION))
					{
						$_SESSION['is_authenticated'] = TRUE;
						$_SESSION['username'] = $username;
						$_SESSION['password'] = hashVariable($password);
						return TRUE;
					}
					else
					{
						throw new Exception("You need call session_start() to check user authentication", 1);
					}
				}
				else
				{
					return [ "Неверный логинь и/или пароль" ];
				}
			}
			else
			{
				$errors = [];
				if (is_null($username))
				{
					$errors[] = "Поле Логин должно быть заполнено";
				}
				if (is_null($password))
				{
					$errors[] = "Поле Пароль должно быть заполнено";
				}
				return $errors;
			}
		}

		public function Register($username, $password)
		{
			if (!is_null($username) && !is_null($password))
			{
				if (!array_key_exists($username, $this->users))
				{
					if (isset($_SESSION))
					{
						$_SESSION['is_authenticated'] = TRUE;
						$_SESSION['username'] = $username;
						$_SESSION['password'] = hashVariable($password);

						# Saving to DB #

						$this->users[$username] = hashVariable($password);
						$this->UploadToFile("users", $this->users);

						# ~Saving to DB #

						return TRUE;
					}
					else
					{
						throw new Exception("You need call session_start() to check user authentication", 1);
					}
				}
				else
				{
					return [ "Пользователь с таким Логином уже существует" ];
				}
			}
			else
			{
				$errors = [];
				if (is_null($username))
				{
					$errors[] = "Поле Логин должно быть заполнено";
				}
				if (is_null($password))
				{
					$errors[] = "Поле Пароль должно быть заполнено";
				}
				return $errors;
			}
		}

		# ~Public Methods #
		#=====================================================================================#
		# Private Methods #

		private function __construct()
		{
			$this->name = 'Свежак';
			$this->title = "Новостной закрытый портал \"$this->name\"";

			$this->menu = $this->DownloadFromFile("menu");
			$this->news = $this->DownloadFromFile("news");
			$this->users = $this->DownloadFromFile("users");
			$this->contacts = $this->DownloadFromFile("contacts");
			$this->prices = $this->DownloadFromFile("prices");
		}

		private function DownloadFromFile($fileName)
		{
			$data = file_get_contents("data/$fileName.json");
			return json_decode($data, TRUE);
		}

		private function UploadToFile($fileName, $data)
		{
			$file = fopen("data/$fileName.json", "w");
			fwrite($file, json_encode($data));
			fclose($file);
		}

		# ~Private Methods #
		#=====================================================================================#
	}

?>