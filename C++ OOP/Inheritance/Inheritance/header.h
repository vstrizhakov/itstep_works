#pragma once
#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>
#include <io.h>
#include <fcntl.h>

using namespace std;

class Point
{
protected:
	int x, y;
public:
	Point()
	{
		this->x = this->y = 0;
		wcout << L"default point" << endl;
	}

	Point(int x, int y)
	{
		this->x = x;
		this->y = y;
		wcout << L"parameter point" << endl;
	}

	friend wostream& operator<<(wostream& wos, const Point& p)
	{
		wos << L"Point(" << p.x << L";" << p.y << L")";
		return wos;
	}

	~Point()
	{
		wcout << L"point destruct" << endl;
	}

	double sqr()
	{
		return 0.0;
	}
};

class Circle : public Point
{
protected:
	int r;
public:
	Circle() :Point()
	{
		this->r = 0;
		wcout << L"default circle" << endl;
	}

	Circle(int x, int y, int r) :Point(x, y) 
	{
		if (r >= 0)
			this->r = r;
		else
			this->r = 0;
		wcout << L"parameter circle" << endl;
	}

	~Circle()
	{
		wcout << L"circle destruct" << endl;
	}
	
	friend wostream& operator<<(wostream& wos, const Circle& c)
	{
		wos << L"Point(" << c.x << L";" << c.y << L") | Radius: " << c.r;
		return wos;
	}

	double sqr()
	{
		return 3.14 * (this->r * this->r);
	}
};

class ColorCircle : public Circle
{
protected:
	wchar_t color[7];
public:
	ColorCircle()
	{
		wcscpy(this->color, L"#FFFFFF");
		wcout << L"default ColorCircle" << endl;
	}

	ColorCircle(int x, int y, int r, wchar_t *color) :Circle(x, y, r)
	{
		wcscpy(this->color, color);
		wcout << L"parameter ColorCircle" << endl;
	}

	~ColorCircle()
	{
		wcout << L"ColorCircle destruct" << endl;
	}

	friend wostream& operator<<(wostream& wos, const ColorCircle& c)
	{
		wos << L"Point(" << c.x << L";" << c.y << L") | Radius: " << c.r << L" | Color: " << c.color;
		return wos;
	}
};

class Sphere :public ColorCircle
{
public:
	Sphere()
	{
		wcout << L"default Sphere" << endl;
	}

	Sphere(int x, int y, int r, wchar_t *color) :ColorCircle(x, y, r, color)
	{
		wcout << L"parameter Sphere" << endl;
	}

	~Sphere()
	{
		wcout << L"Sphere destruct" << endl;
	}

	double sqr()
	{
		return 4 * 3.14 * this->r * this->r;
	}

	double volume()
	{
		return 4 / 3 * 3.14 * this->r * this->r * this->r;
	}
};