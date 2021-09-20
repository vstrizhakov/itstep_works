var currentPage = 0;
var loadingPage = 0;

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

function searchBooks(evt, lp = 0)
{
	var request = new XMLHttpRequest();
	var formData = new FormData(document.forms.search);

	request.onreadystatechange = function()
	{
		if (this.readyState != 4) return;

		currentPage = loadingPage;

		var parser = new DOMParser();
		var response = parser.parseFromString(request.responseText, "application/xml");
		var result = response.getElementsByTagName('result').item(0).firstChild.data;
		var data = response.getElementsByTagName('data').item(0);
		var pagesCount = null;
		if (result == 0)
		{
			var handler = response.getElementsByTagName('method').item(0).firstChild.data;
			pagesCount = Number(response.getElementsByTagName('pagesCount').item(0).firstChild.data);

			var errorsSpan = document.getElementById("errors");
			errorsSpan.innerHTML = '';

			eval(handler + '(data, pagesCount)');
		}
		else
		{
			displayErrors(data);
		}

		var pagination = document.getElementById("pagination");
		while (pagination.childNodes.length > 0)
		{
			pagination.removeChild(pagination.childNodes[0]);
		}
		if (pagesCount != null)
		{
			for (var i = 0; i < pagesCount; i++)
			{
				var li = document.createElement('li');
				li.classList.add("page-item");
				if (i == currentPage)
				{
					li.classList.add("disabled");
					li.setAttribute('tabindex', '-1');
				}
				var a = document.createElement('a');
				a.classList.add('page-link');
				a.setAttribute('href', 'javascript:void(0);');
				a.innerHTML = i + 1;
				a.onclick = function(evt)
				{
					var page = Number(evt.target.innerHTML);
					searchBooks(evt, page - 1);
				};
				li.appendChild(a);
				pagination.appendChild(li);
			}
		}
	}
	
	request.open("POST", "getbooks.php?rnd=" + Math.random() + "&page=" + lp, true);
	loadingPage = lp;
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