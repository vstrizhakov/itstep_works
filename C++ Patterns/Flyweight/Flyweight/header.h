#pragma once
#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h>
#include <algorithm>
#include <numeric>
#include <functional>
#include <map>
#include <utility>
#include <string>
#include <fstream>

using namespace std;

class BaseSymbol
{
protected:
	char symbol;
	int position;
	int size;
	string color;
public:
	virtual string DisplaySymbol(int size, string color) = 0;
	char GetChar()
	{
		return this->symbol;
	}
};

class Symbol :public BaseSymbol
{
public:
	Symbol(char symbol = 'a')
	{
		this->symbol = symbol;
		this->position = 0;
		this->size = 20;
		this->color = "blue";
	}

	virtual string DisplaySymbol(int size, string color)
	{
		string tmp;
		char *s = new char;
		tmp = "<span style='color:";
		tmp += color;
		tmp += "; font-size:";
		tmp += itoa(size, s, 10);
		tmp += ";'>";
		tmp += this->symbol;
		tmp += "</span>";
		return tmp;
	}
};

class CharFactory
{
protected:
	map<char, BaseSymbol*> pool;
public:
	BaseSymbol* GetSymbol(char key)
	{
		map<char, BaseSymbol*>::iterator it = pool.find(key);
		if (it == pool.end())
		{
			
			pool[key] = new Symbol(key);
			return pool[key];
		}
		else
		{
			return it->second;
		}
	}

	int GetPoolSize()
	{
		return this->pool.size();
	}

	void ShowPool()
	{
		map<char, BaseSymbol*>::iterator it = pool.begin();
		while (it != pool.end())
		{
			cout << it->first << endl;
			it++;
		}
		
	}
};