var lastId = 0;

function addMessages(messagesRoot)
{
	var messages = messagesRoot.getElementsByTagName('message');
	for (var i = 0; i < messages.length; i++)
	{
		var message = messages.item(i);

		var id = message.getElementsByTagName('id').item(0).firstChild.data;
		var email = message.getElementsByTagName('email').item(0).firstChild.data;
		var content = message.getElementsByTagName('content').item(0).firstChild.data;
		var date = message.getElementsByTagName('date').item(0).firstChild.data;

		var colEmail= document.createElement('div');
		colEmail.className = 'col-lg-12';
		colEmail.innerHTML = '<b>E-mail: </b>' + email
		var rowEmail = document.createElement('div');
		rowEmail.className = 'row';
		rowEmail.appendChild(colEmail);

		var colContent= document.createElement('div');
		colContent.className = 'col-lg-12';
		colContent.innerHTML = '<b>Content: </b>' + content;
		var rowContent = document.createElement('div');
		rowContent.className = 'row';
		rowContent.appendChild(colContent);

		var colDate= document.createElement('div');
		colDate.className = 'col-lg-12';
		colDate.innerHTML = '<b>Date: </b>' + date;
		var rowDate = document.createElement('div');
		rowDate.className = 'row';
		rowDate.appendChild(colDate);

		var li = document.createElement('li');
		li.className = 'list-group-item';
		li.appendChild(colEmail);
		li.appendChild(colContent);
		li.appendChild(colDate);

		var messagesList = document.getElementById("messages");
		messagesList.prepend(li);

		lastId = Number(id) + 1;
	}
}

function getMessages()
{
	var request = new XMLHttpRequest();

	request.onreadystatechange = function()
	{
		if (this.readyState != 4) return;

		var response = request.responseXML;
		var result = response.getElementsByTagName('result').item(0).firstChild.data;

		if (result == 0)
		{
			var handler = response.getElementsByTagName('method').item(0).firstChild.data;
			var data = response.getElementsByTagName('data').item(0);

			var errorsSpan = document.getElementById("errors");
			errorsSpan.innerHTML = '';

			eval(handler + '(data)');
		}
		getMessages();
	}

	request.open("GET", "getmessages.php?lastMessageId=" + lastId, true);
	request.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
	request.send();
}

function displayErrors(errors)
{
	var errors = errors.getElementsByTagName('error');
	var errorsSpan = document.getElementById("errors");
	var result = "";
	for (var i = 0; i < errors.length; i++)
	{
		var error = errors.item(i);
		result += error.firstChild.data + "<br>";
	}
	errorsSpan.innerHTML = result;
}

function addMessage()
{
	var request = new XMLHttpRequest();

	var formData = new FormData(document.forms.msg);

	request.onreadystatechange = function()
	{
		if (this.readyState != 4) return;

		var response = request.responseXML;

		var result = response.getElementsByTagName('result').item(0).firstChild.data;

		if (result == 1)
		{
			var handler = response.getElementsByTagName('method').item(0).firstChild.data;
			var data = response.getElementsByTagName('data').item(0);
			eval(handler + '(data)');
		}
	}

	request.open("POST", "addmessage.php", true);
	request.send(formData);
}

window.onload = function()
{
	getMessages();

	var addMessageButton = document.getElementById('addMessageButton');
	addMessageButton.onclick = addMessage;
}