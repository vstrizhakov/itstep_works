#pragma once
#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>
#include <io.h>
#include <fcntl.h>

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

	Fish operator+(const Fish &f) {
		Fish tmp;
		(this->price > f.price) ? strcpy(tmp.name, this->name) : strcpy(tmp.name, f.name);
		tmp.weight = this->weight + f.weight;
		tmp.price = this->price + f.price;
		return tmp;
	}

	Fish operator*(const Fish &f) {
		Fish tmp;
		(this->price > f.price) ? strcpy(tmp.name, this->name) : strcpy(tmp.name, f.name);
		tmp.weight = this->weight * f.weight;
		tmp.price = this->price * f.price;
		return tmp;
	}

	friend wostream &operator<<(wostream &os, Fish &a)
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

template <class T>
class Calc {
	T x, y;
public:
	T add(T x, T y);
	T mult(T x, T y);
};
template <class T>
T Calc<T>::add(T x, T y) {
	return x + y;
}
template <class T>
T Calc<T>::mult(T x, T y) {
	return x * y;
}