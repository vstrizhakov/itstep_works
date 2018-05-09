#pragma once
#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h>
#include <vector>
#include <algorithm>
#include <functional>
#include <string>
#include "header.h"

using namespace std;

//observer
class Shop
{
protected:
	string name;
public:
	virtual void Notify(int price) = 0;
};

//publisher
class Product
{
	string name;
	int price;
	vector<Shop*> shops;
public:
	Product(string name, int price)
	{
		this->name = name;
		this->price = price;
	}

	void Subscribe(Shop* shop)
	{
		shops.push_back(shop);
	}

	void Unsubscribe(Shop* shop)
	{
		shops.erase(remove(shops.begin(), shops.end(), shop));
	}

	void ChangePrice(int price)
	{
		this->price = price;
	}

	void NotifyAll()
	{
		vector<Shop*>::iterator it = shops.begin();
		for (it; it != shops.end(); it++)
		{
			(*it)->Notify(this->price);
		}
	}
};

class RealShop :public Shop
{
protected:
	string name;
	int price;
public:
	RealShop(string name)
	{
		this->name = name;
		this->price = 0;
	}

	virtual void Notify(int price)
	{
		this->price = price;
		cout << name << " received new price: " << this->price << endl;
	}
};