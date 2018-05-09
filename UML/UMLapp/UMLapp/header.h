#pragma once
#include <iostream>
#include <Windows.h>
#include <iomanip>
#include <ctime>
#include <algorithm>
#include <vector>
#include <functional>
#include <string>

using namespace std;

class Category
{
	static int count_cat_id;
	int id;
	string name;
public:
	Category(string name = string("no category"))
	{
		this->id = count_cat_id++;
		this->name = name;
	}

	void Show()
	{
		cout << "Category id: " << id << " | Category name: " << name << endl;
	}
};

class Product
{
	static int count_product_id;
	int id;
	string name;
	int price;
	int category_id;
public:
	Product(string name = string("noname"), int price = 0, int cat_id = 0)
	{
		this->id = count_product_id++;
		this->name = name;
		this->price = price;
		this->category_id = cat_id;
	}

	int GetCatId()
	{
		return this->category_id;
	}

	void Show()
	{
		cout << "Product ID: " << this->id << " | Product name: " << this->name << " | Product price: " << this->price << " | Category ID: " << this->category_id << endl;
	}
};

class Order
{
	int product_id;
	int count;
public:
	Order(int product_id = 0, int count = 0)
	{

	}
};