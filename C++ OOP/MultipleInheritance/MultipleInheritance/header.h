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
};

class B :public A
{
public:
	int b;

	B()
	{
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
};

class C :public A
{
public:
	int c;

	C()
	{
		wcout << L"C default" << endl;
	}

	C(int a, int c) :A(a)
	{
		this->c = c;
		wcout << L"C parameter" << endl;
	}

	~C()
	{
		wcout << L"C destruct" << endl;
	}
};

class D : public B, public C
{
public:
	int d;

	D()
	{
		wcout << L"D default" << endl;
	}

	/*D(int a, int b, int c, int d) :B(a, b), C(a, b, c)
	{
		this->d = d;
		wcout << L"D parameter" << endl;
	}*/

	~D()
	{
		wcout << L"D destruct" << endl;
	}
};