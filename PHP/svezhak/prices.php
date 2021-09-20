<?php
	require_once("SvezhakClass.php");
	require_once("CommonFunctions.php");

	session_start();
	$svezhak = SvezhakOrRedirectTo("auth", FALSE);

	extract($svezhak->GetData());
?>

<?php include('html/header.php'); ?>

<h3 class="mt-4">Цены на <span class="badge badge-warning">НЕИЗВЕСТНО ЧТО!</span></h3>
<table class="table">
	<thead>
		<tr>
			<th>За что</th>
			<th>Сколько</th>
		</tr>
	</thead>
	<tbody>
		<?php foreach ($prices as $price) { ?>
			<tr>
				<td><?= $price["what"]; ?></td>
				<td><?= $price["howmuch"]; ?></td>
			</tr>
		<?php } ?>
	</tbody>
</table>

<?php include("html/footer.php"); ?>