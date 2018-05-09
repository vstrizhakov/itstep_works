#pragma once
#include <iostream>
#include <ctime>
#include <iomanip>
#include <algorithm>
#include <list>
#include <string>
#include <functional>

using namespace std;

class Point
{
protected:
	double x, y;
public:
	Point()
	{
		this->x = rand() % 500 + 1;
		this->y = rand() % 500 + 1;
	}

	friend ostream& operator<<(ostream& os, Point& p)
	{
		os << "X: " << p.x << " | Y: " << p.y;
		return os;
	}
};

class Circle :public Point
{
	double radius;
	int innerCircle;
public:
	Circle() :Point()
	{
		int maxRadius = 50;
		if (this->x < 50 || this->y < 50)
			(this->x < this->y) ? maxRadius = this->x : maxRadius = this->y;
		this->radius = rand() % maxRadius + 1;
		this->innerCircle = 0;
	}

	friend ostream& operator<<(ostream& os, const Circle& c)
	{
		os << "X: " << c.x << " | Y: " << c.y << " | Radius: " << c.radius << " | Inner circles: " << c.innerCircle;
		return os;
	}

	bool operator()(Circle& c)
	{
		double distance = sqrt((c.x - this->x) * (c.x - this->x) + (c.y - this->y) * (c.y - this->y));
		return distance <= this->radius;
	}

	int getInnerCircle() const
	{
		return this->innerCircle;
	}

	void setInnerCircle(int innerCircle)
	{
		this->innerCircle = innerCircle;
	}

	double getRadius()
	{
		return this->radius;
	}

	double getX()
	{
		return this->x;
	}

	double getY()
	{
		return this->y;
	}

	bool operator<(const Circle& c) const
	{
		return c.innerCircle < this->innerCircle;
	}
};