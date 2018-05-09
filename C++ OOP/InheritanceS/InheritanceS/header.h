#pragma once
#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>
#include <io.h>
#include <fcntl.h>

using namespace std;

class A
{
public:
	int a;

	A()
	{
		this->a = 0;
		wcout << L"A default" << endl;
	}

	A(int a)
	{
		this->a = a;
		wcout << L"A parameter" << endl;
	}

	~A()
	{
		wcout << L"A destruct" << endl;
	}

	virtual void fa()
	{
		wcout << L"A:fa()" << endl;
	}
};

class B :public A
{
public:
	int b;

	B()
	{
		this->b = 0;
		wcout << L"B default" << endl;
	}

	B(int a, int b) :A(a)
	{
		this->b = b;
		wcout << L"B parameter" << endl;
	}

	~B()
	{
		wcout << L"B destruct" << endl;
	}

	void fb()
	{
		wcout << L"B:fb()" << endl;
	}

	void fa()
	{
		wcout << L"B:fa()" << endl;
	}
};

class C :public B
{
public:
	int c;

	C()
	{
		this->c = 0;
		wcout << L"C default" << endl;
	}

	C(int a, int b, int c) :B(a, b)
	{
		this->c = c;
		wcout << L"C parameter" << endl;
	}

	~C()
	{
		wcout << L"C destruct" << endl;
	}

	void fc()
	{
		wcout << L"C:fc()" << endl;
	}

	void fa()
	{
		wcout << L"C:fa()" << endl;
	}
};