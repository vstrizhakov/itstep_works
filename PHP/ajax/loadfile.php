<?php

	$filename = (isset($_POST["filename"])) ? $_POST['filename'] : "";

	if (!empty($filename)) { ?>
	
		<body onload="showFileContent()">
			<script>
				function showFileContent()
				{
					var elem = parent.document.getElementById("content");
					if (elem != null)
					{
						elem.innerHTML = "<pre><?= (file_exists($filename)) ? file_get_contents($filename) : "Error"; ?></pre>";
					}
				}
			</script>
		</body>

<?php } ?>