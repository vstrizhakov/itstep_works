#pragma once
#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>
#include <conio.h>

using namespace std;

class Prototype
{
protected:
	int x, y;
public:
	int GetX()
	{
		return this->x;
	}

	int GetY()
	{
		return this->y;
	}

	void SetX(int x)
	{
		this->x = x;
	}

	void SetY(int y)
	{
		this->y = y;
	}

	virtual void Show()
	{
		cout << "(" << this->x << ";" << this->y << ")" << endl;
	}

	virtual Prototype* Clone() = 0;
};

class Rect :public Prototype
{
protected:
	int width, height;
public:
	void SetWidth(int w)
	{
		this->width = w;
	}

	void SetHeight(int h)
	{
		this->height = h;
	}

	int GetWidth()
	{
		return this->width;
	}

	int GetHeight()
	{
		return this->height;
	}

	virtual void Show()
	{
		cout << "(" << this->x << ";" << this->y << ") Width: " << this->width << " | Height: " << this->height << endl;
	}

	virtual Prototype* Clone()
	{
		return new Rect(*this);
	}
};

class Circle :public Prototype
{
protected:
	int radius;
public:
	void SetRaius(int r)
	{
		this->radius = r;
	}

	int GetRadius()
	{
		return this->radius;
	}

	virtual void Show()
	{
		cout << "(" << this->x << ";" << this->y << ") Radius: " << this->radius << endl;
	}

	virtual Prototype* Clone()
	{
		return new Circle(*this);
	}
};

class Client
{
	static Prototype* fig1;
	static Prototype* fig2;
public:
	static void Init()
	{
		if (fig1 != NULL && fig2 != NULL)
		{
			fig1 = new Rect;
			fig2 = new Circle;
		}
	}

	static Prototype* GetRect()
	{
		return fig1->Clone();
	}

	static Prototype* GetCircle()
	{
		return fig2->Clone();
	}
};