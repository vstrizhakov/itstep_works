#pragma once
#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>

using namespace std;

class Fish {
private:
	char name[20];
	double weight;
	double price;
public:
	Fish(char *name = "noname", double weight = 0, double price = 0)
	{
		if (weight >= 0 && price >= 0)
		{
			strcpy(this->name, name);
			this->weight = weight;
			this->price = price;
		}
	}

	Fish(const Fish& f) {
		strcpy(this->name, f.name);
		this->weight = f.weight;
		this->price = f.price;
	}

	Fish& operator=(Fish& f) {
		this->price = f.price;
		this->weight = f.weight;
		strcpy(this->name, f.name);
		return *this;
	}

	friend ostream& operator<<(ostream& os, const Fish& a)
	{
		os << "  Name : " << a.name << "  Weight : " << a.weight << "  Price : " << a.price << endl;
		return os;
	}
	void setName(char *name) {
		strcpy(this->name, name);
	}
	void setWeight(double w) {
		this->weight = w;
	}
	void setPrice(double p) {
		this->price = p;
	}
	char* getName() {
		return this->name;
	}
	double getWeight() {
		return this->weight;
	}
	double getPrice() {
		return this->price;
	}
};