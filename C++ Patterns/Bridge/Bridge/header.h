#pragma once
#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <string>
#include "header.h"

using namespace std;

class BaseSender
{
public:
	virtual void SendMsg(string title, string body) = 0;
};

class EmailSender :public BaseSender
{
	virtual void SendMsg(string title, string body)
	{
		cout << "Email: " << title << "\nText: " << body << endl;
	}
};

class MsmqSender :public BaseSender
{
	virtual void SendMsg(string title, string body)
	{
		cout << "MCMQ: " << title << "\nText: " << body << endl;
	}
};

class WebSender :public BaseSender
{
	virtual void SendMsg(string title, string body)
	{
		cout << "Web: " << title << "\nText: " << body << endl;
	}
};

class Message
{
protected:
	BaseSender* sender;
	string title;
	string body;
public:
	Message(BaseSender* sender, string title, string body)
	{
		this->sender = sender;
		this->title = title;
		this->body = body;
	}

	virtual void Send()
	{
		this->sender->SendMsg(this->title, this->body);
	}

	void SetSender(BaseSender* sender)
	{
		this->sender = sender;
	}
};

class SuperMessage :public Message
{
protected:
	int status;
public:
	SuperMessage(BaseSender* sender, string title, string body, int status) :Message(sender, title, body)
	{
		this->status = status;
	}

	virtual void Send()
	{
		cout << "Importance: " << status << endl;
		this->sender->SendMsg(this->title, body);
	}
};