<?php

	class Menu
	{
		private $items = array();

		public function addItem($id, $title)
		{
			$this->items[$id] = $title;
		}

		public function __toString()
		{
			$str = "<table align='center' width='60%'><tr>";
			foreach ($this->items as $key => $value)
			{
				$str .= "<td><a href='index.php?c=$key'>$value</a></td>";
			}
			$str .= "</tr></table>";
			return $str;
		}
	}

?>