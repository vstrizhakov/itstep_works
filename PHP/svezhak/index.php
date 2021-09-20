<?php
	require_once("SvezhakClass.php");
	require_once("CommonFunctions.php");

	session_start();
	$svezhak = SvezhakOrRedirectTo("auth", FALSE);

	extract($svezhak->GetData());
?>

<?php include('html/header.php'); ?>

<h3 class="mt-4">Главные новости на <span class="badge badge-warning">СЕГОДНЯ!</span></h3>
<ul class="list-unstyled">
	<?php foreach ($news as $new) { ?>
		<li class="media rounded mt-4 border p-2">
			<img src="<?= $new["image"]; ?>" width="164px" alt="" class="mr-3 align-self-center">
			<div class="media-body">
				<h5 class="mt-0 mb-1"><?= $new["title"]; ?></h5>
				<p><?= $new["description"]; ?></p>
				<h6 class="text-secondary float-right"><?= $new["date"]; ?></h6>
			</div>
		</li>
	<?php } ?>
</ul>

<?php include("html/footer.php"); ?>