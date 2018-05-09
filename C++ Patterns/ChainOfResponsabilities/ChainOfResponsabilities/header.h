#pragma once
#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h>
#include <string>
#include <map>

using namespace std;

class Request
{
	int rest;
	int requested;
	map<int, int> notes;
public:
	Request(int requested = 0)
	{
		this->requested = requested;
		this->rest = requested;
	}

	void Show()
	{
		cout << "Was requested amount of: " << this->requested << endl;
		cout << "Transactions have been done: " << endl;
		map<int, int>::iterator it = notes.begin();
		for (it; it != notes.end(); it++)
		{
			cout << "Nominal " << it->first << " was given in amount of " << it->second << endl;
		}
		if (this->rest > 0)
		{
			cout << "Impossible to give money in amount of " << this->rest << endl;
		}
	}

	int GetRest()
	{
		return this->rest;
	}

	map<int, int> GetNotes()
	{
		return this->notes;
	}

	void SetNotes(map<int, int> notes)
	{
		this->notes = notes;
	}

	void SetRest(int rest)
	{
		this->rest -= rest;
	}
};

class Handler
{
protected:
	Handler* next;
public:
	virtual void SetHandler(Handler* next = NULL)
	{
		this->next = next;
	}

	virtual void HandleRequest(Request* request) = 0;
};

class Handler500 :public Handler
{
protected:
	int value;
	int count;
public:
	Handler500(int count = 0)
	{
		this->count = count;
		this->value = 500;
	}

	virtual void HandleRequest(Request* request)
	{
		map<int, int> notes;
		while (request->GetRest() >= this->value && this->count > 0)
		{
			notes = request->GetNotes();
			if (notes.find(this->value) == notes.end())
			{
				notes.insert(make_pair(this->value, 1));
			}
			else
			{
				notes[this->value]++;
			}
			this->count--;
			request->SetRest(this->value);
			request->SetNotes(notes);
		}
		if (request->GetRest() > 0 && next != NULL)
		{
			next->HandleRequest(request);
		}
	}
};

class Handler200 :public Handler
{
protected:
	int value;
	int count;
public:
	Handler200(int count = 0)
	{
		this->count = count;
		this->value = 200;
	}

	virtual void HandleRequest(Request* request)
	{
		map<int, int> notes;
		while (request->GetRest() >= this->value && this->count > 0)
		{
			notes = request->GetNotes();
			if (notes.find(this->value) == notes.end())
			{
				notes.insert(make_pair(this->value, 1));
			}
			else
			{
				notes[this->value]++;
			}
			this->count--;
			request->SetRest(this->value);
			request->SetNotes(notes);
		}
		if (request->GetRest() > 0 && next != NULL)
		{
			next->HandleRequest(request);
		}
	}
};

class Handler100 :public Handler
{
protected:
	int value;
	int count;
public:
	Handler100(int count = 0)
	{
		this->count = count;
		this->value = 100;
	}

	virtual void HandleRequest(Request* request)
	{
		map<int, int> notes;
		while (request->GetRest() >= this->value && this->count > 0)
		{
			notes = request->GetNotes();
			if (notes.find(this->value) == notes.end())
			{
				notes.insert(make_pair(this->value, 1));
			}
			else
			{
				notes[this->value]++;
			}
			this->count--;
			request->SetRest(this->value);
			request->SetNotes(notes);
		}
		if (request->GetRest() > 0 && next != NULL)
		{
			next->HandleRequest(request);
		}
	}
};

class Handler50 :public Handler
{
protected:
	int value;
	int count;
public:
	Handler50(int count = 0)
	{
		this->count = count;
		this->value = 50;
	}

	virtual void HandleRequest(Request* request)
	{
		map<int, int> notes;
		while (request->GetRest() >= this->value && this->count > 0)
		{
			notes = request->GetNotes();
			if (notes.find(this->value) == notes.end())
			{
				notes.insert(make_pair(this->value, 1));
			}
			else
			{
				notes[this->value]++;
			}
			this->count--;
			request->SetRest(this->value);
			request->SetNotes(notes);
		}
		if (request->GetRest() > 0 && next != NULL)
		{
			next->HandleRequest(request);
		}
	}
};

class Handler20 :public Handler
{
protected:
	int value;
	int count;
public:
	Handler20(int count = 0)
	{
		this->count = count;
		this->value = 20;
	}

	virtual void HandleRequest(Request* request)
	{
		map<int, int> notes;
		while (request->GetRest() >= this->value && this->count > 0)
		{
			notes = request->GetNotes();
			if (notes.find(this->value) == notes.end())
			{
				notes.insert(make_pair(this->value, 1));
			}
			else
			{
				notes[this->value]++;
			}
			this->count--;
			request->SetRest(this->value);
			request->SetNotes(notes);
		}
		if (request->GetRest() > 0 && next != NULL)
		{
			next->HandleRequest(request);
		}
	}
};