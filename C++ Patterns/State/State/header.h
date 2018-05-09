#pragma once
#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h> 
#include <string>

using namespace std;

class Car;

class BaseState
{
public:
	virtual void GetNextState(Car& car) = 0;
	virtual void Report(Car& car) = 0;
};

class Car
{
protected:
	BaseState* state;
	int fuel;
public:
	Car(BaseState* state = NULL)
	{
		this->state = state;
		this->fuel = 50;
	}

	void UseCar()
	{
		while (state)
		{
			this->state->Report(*this);
			Sleep(500);
		}
	}

	void SetState(BaseState* state)
	{
		this->state = state;
	}

	int GetFuel()
	{
		return this->fuel;
	}

	void SetFuel(int fuel)
	{
		this->fuel += fuel;
	}
};

class NormalState :public BaseState {
public:
	virtual void GetNextState(Car& car);
	virtual void Report(Car& car);
};

class OutOfFuelState :public BaseState {
public:
	virtual void GetNextState(Car& car);
	virtual void Report(Car& car);
};

class RefuelState :public BaseState {
public:
	virtual void GetNextState(Car& car);
	virtual void Report(Car& car);
};

void NormalState::GetNextState(Car& car)
{
	car.SetState(new OutOfFuelState);
}

void NormalState::Report(Car& car)
{
	cout << "Car is driving " << car.GetFuel() << " " << typeid(*this).name() << endl;
	while (car.GetFuel() > 0)
	{
		Sleep(1);
		car.SetFuel(-5);
		cout << "Car is driving " << car.GetFuel() << " " << typeid(*this).name() << endl;
	}
	NormalState::GetNextState(car);
}

void OutOfFuelState::GetNextState(Car& car)
{
	car.SetState(new RefuelState);
}

void OutOfFuelState::Report(Car& car)
{
	cout << "Car is stopped to refuel " << typeid(*this).name() << endl;
	OutOfFuelState::GetNextState(car);
}

void RefuelState::GetNextState(Car& car)
{
	car.SetState(new NormalState);
	car.SetFuel(50);
}

void RefuelState::Report(Car& car)
{
	cout << "Car is refuelling " << typeid(*this).name() << endl;
	RefuelState::GetNextState(car);
}