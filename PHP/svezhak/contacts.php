<?php
	require_once("SvezhakClass.php");
	require_once("CommonFunctions.php");

	session_start();
	$svezhak = SvezhakOrRedirectTo("auth", FALSE);

	extract($svezhak->GetData());
?>

<?php include('html/header.php'); ?>

<h3 class="mt-4">Контакты <span class="badge badge-warning">НЕИЗВЕСТНО КОГО!</span></h3>
<table class="table">
	<thead>
		<tr>
			<th>За что</th>
			<th>Сколько</th>
		</tr>
	</thead>
	<tbody>
		<?php foreach ($contacts as $contact) { ?>
			<tr>
				<td><?= $contact["who"]; ?></td>
				<td><?= $contact["number"]; ?></td>
			</tr>
		<?php } ?>
	</tbody>
</table>

<?php include("html/footer.php"); ?>