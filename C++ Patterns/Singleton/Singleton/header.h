#pragma once
#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>
#include <conio.h>

using namespace std;

class Singleton
{
private:
	Singleton() {}
	Singleton(const Singleton &s);
	Singleton& operator=(Singleton &s);
	static Singleton *ps;
public:
	static Singleton* GetInstance()
	{
		if (!ps)
		{
			ps = new Singleton();
		}
		else
		{
			cout << "Instance of the class is alreade created!" << endl;
		}
		return ps;
	}
};