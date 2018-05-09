<?php 
	require_once('../admin/config.php');

if (file_exists('../vqmod/vqmod.php')) {
	require_once('../vqmod/vqmod.php');
	VQMod::bootup();

	require_once(VQMod::modCheck(DIR_SYSTEM . 'startup.php'));
	require_once(VQMod::modCheck(DIR_SYSTEM . 'library/currency.php'));
	require_once(VQMod::modCheck(DIR_SYSTEM . 'library/user.php'));
	require_once(VQMod::modCheck(DIR_SYSTEM . 'library/weight.php'));
	require_once(VQMod::modCheck(DIR_SYSTEM . 'library/length.php'));
}
else {
	require_once(DIR_SYSTEM . 'startup.php');
	require_once(DIR_SYSTEM . 'library/currency.php');
	require_once(DIR_SYSTEM . 'library/user.php');
	require_once(DIR_SYSTEM . 'library/weight.php');
	require_once(DIR_SYSTEM . 'library/length.php');
}
	$db = new DB(DB_DRIVER, DB_HOSTNAME, DB_USERNAME, DB_PASSWORD, DB_DATABASE);
	$xml = simplexml_load_file('offers.xml');
	$count = 0;
	foreach ($xml->ПакетПредложений->Предложения[0]->Предложение as $x)
	{
		$query = $db->query("SELECT product_id FROM " . DB_PREFIX . "product_description WHERE name = '" . $x->Наименование . "'");
		$query = $db->query("UPDATE " . DB_PREFIX . "product SET price_opt = " . $x->Цены->Цена->ЦенаЗаЕдиницу . " WHERE product_id = " . $query->rows[0]['product_id']);
		//print_r($query->rows);
	}

?>