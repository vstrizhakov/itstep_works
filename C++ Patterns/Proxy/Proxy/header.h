#pragma once
#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h>
#include <string>

using namespace std;

class Driver
{
	string name;
	int age;
public:
	Driver(string name = (string)"no name", int age = 0)
	{
		this->name = name;
		this->age = age;
	}
	
	int GetAge()
	{
		return this->age;
	}
};

class BaseCar
{
public:
	virtual void DriveCar() = 0;
};

class Car :public BaseCar
{
	Driver* driver;
public:
	Car(Driver* driver = NULL)
	{
		this->driver = driver;
	}

	void DriveCar()
	{
		cout << "The car is driving..."  << endl;
	}
};

class ProxyCar :public BaseCar
{
protected:
	Driver* driver;
	BaseCar* car;
public:
	ProxyCar(Driver* driver)
	{
		this->driver = driver;
		car = new Car(driver);
	}

	virtual void DriveCar()
	{
		if (this->driver->GetAge() <= 20)
			cout << "Driver is not allowed to drive a car" << endl;
		else
			car->DriveCar();
	}
};