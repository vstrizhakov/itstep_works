function displayBooks(booksRoot)
{
	var books = booksRoot.getElementsByTagName('book');
	var table = document.getElementById("table");
	var errorsSpan = document.getElementById("errors");

	var rowsCount = table.rows.length;
	for (var i = 0; i < rowsCount - 1; i++)
	{
		table.deleteRow(1);
	}
	for (var i = 0; i < books.length; i++)
	{
		var book = books.item(i);

		var name = (book.getElementsByTagName('name').item(0).firstChild != null) ? book.getElementsByTagName('name').item(0).firstChild.data : "";
		var category = (book.getElementsByTagName('category').item(0).firstChild != null) ? book.getElementsByTagName('category').item(0).firstChild.data : "";
		var theme = (book.getElementsByTagName('theme').item(0).firstChild != null) ? book.getElementsByTagName('theme').item(0).firstChild.data : "";
		var publication = (book.getElementsByTagName('publication').item(0).firstChild != null) ? book.getElementsByTagName('publication').item(0).firstChild.data : "";
		var price = (book.getElementsByTagName('price').item(0).firstChild != null) ? book.getElementsByTagName('price').item(0).firstChild.data : "";

		var tr = table.insertRow();

		var td = document.createElement('td');
		td.innerHTML = name;
		tr.appendChild(td);

		td = document.createElement('td');
		td.innerHTML = category;
		tr.appendChild(td);

		td = document.createElement('td');
		td.innerHTML = theme;
		tr.appendChild(td);

		td = document.createElement('td');
		td.innerHTML = publication;
		tr.appendChild(td);

		td = document.createElement('td');
		td.innerHTML = price;
		tr.appendChild(td);
	}
	table.classList.remove("d-none");
	errorsSpan.classList.add("d-none");
}

function searchBooks()
{
	var request = new XMLHttpRequest();
	var formData = new FormData(document.forms.search);

	request.onreadystatechange = function()
	{
		if (this.readyState != 4) return;

		var parser = new DOMParser();
		var response = parser.parseFromString(request.responseText, "application/xml");
		var result = response.getElementsByTagName('result').item(0).firstChild.data;
		var data = response.getElementsByTagName('data').item(0);
		if (result == 0)
		{
			var handler = response.getElementsByTagName('method').item(0).firstChild.data;

			var errorsSpan = document.getElementById("errors");
			errorsSpan.innerHTML = '';

			eval(handler + '(data)');
		}
		else
		{
			displayErrors(data);
		}
	}
	request.open("POST", "getbooks.php?rnd=" + Math.random(), true);
	request.send(formData);
}

function displayErrors(errors)
{
	var errors = errors.getElementsByTagName('error');
	var errorsSpan = document.getElementById("errors");
	var table = document.getElementById("table");

	var result = "";
	for (var i = 0; i < errors.length; i++)
	{
		var error = errors.item(i);
		result += error.firstChild.data + "<br>";
	}
	errorsSpan.innerHTML = result;

	table.classList.add("d-none");
	errorsSpan.classList.remove("d-none");
}

window.onload = function()
{
	var categories = document.getElementById('categories');
	var themes = document.getElementById('themes');
	var publications = document.getElementById('publications');
	categories.onchange = searchBooks;
	themes.onchange = searchBooks;
	publications.onchange = searchBooks;
}