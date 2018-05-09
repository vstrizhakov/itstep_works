#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>
#include <conio.h>
#include <algorithm>
#include <vector>
#include <set>
#include <string>
#include <functional>
#include "circle.h"

using namespace std;

void SetColor(int text, int background) {
	HANDLE hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(hStdOut, (WORD)((background << 4) | text));
}

void show(Circle& c)
{
	cout << c << endl;
}

vector<Circle> createCircles(vector<Circle>& circles, int n)
{
	for (int i = 0; i < n; i++)
		circles.push_back(*(new Circle));
	vector<Circle>::iterator it = circles.begin();
	vector<Circle>::iterator itf;
	Circle temp;
	vector<Circle> InnerCircles;
	vector<Circle> tempInnerCircles;
	while (it != circles.end())
	{
		temp = *it;
		itf = circles.begin();
		tempInnerCircles.clear();
		while (itf != circles.end())
		{
			itf = find_if(itf, circles.end(), temp);
			if (itf == it)
			{
				itf++;
				continue;
			}
			if (itf != circles.end())
			{
				tempInnerCircles.push_back(*itf);
				it->setInnerCircle(it->getInnerCircle() + 1);
				itf++;
			}
		}
		if (tempInnerCircles.size() > InnerCircles.size()) InnerCircles = tempInnerCircles;
		it++;
	}
	return InnerCircles;
}

class WholeSquare
{
	double sqr;
public:
	WholeSquare()
	{
		this->sqr = 0;
	}

	void operator()(Circle& c)
	{
		this->sqr += 3.14 * c.getRadius() * c.getRadius();
	}

	double getSquare()
	{
		return this->sqr;
	}
};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));
	SetColor(15, 0);

	vector<Circle> circles;
	vector<Circle> innerCircles;
	set<Circle> temp_circles;
	vector<Circle>::iterator it;
	Circle CircleWithMaxCountOfInnerCircles;	
	WholeSquare square;
	short k = 1, en = 0, max = 2, min = 1;
	do
	{
		if (en == 72)
		{
			k--;
			if (k == 0)
				k = max;
		}
		if (en == 80)
		{
			k++;
			if (k == max + 1)
				k = min;
		}
		if (en == 13)
		{
			switch (k)
			{
			case 1: {
				system("cls");
				if (innerCircles.size() != 0) innerCircles.clear();
				innerCircles = createCircles(circles, 200);
				for_each(circles.begin(), circles.end(), show);
				it = circles.begin();
				while (it != circles.end())
				{
					temp_circles.insert(*it++);
				}
				CircleWithMaxCountOfInnerCircles = *temp_circles.begin();
				temp_circles.clear();
				square = for_each(innerCircles.begin(), innerCircles.end(), square);
				cout << "****************************************************************************************************" << endl;
				cout << "200 circles generated!" << endl;
				cout << "Press any key to continue..." << endl;
				getch();
				max = 6;
				break;
			}					
			case 2: {
				if (max == 2) exit(0);
				system("cls");
				for_each(circles.begin(), circles.end(), show);
				cout << "****************************************************************************************************" << endl;
				cout << "Press any key to continue..." << endl;
				getch();
				break;
			}
			case 3: {
				system("cls");
				cout << "M-Circle with maximum number of inner circles: " << CircleWithMaxCountOfInnerCircles << endl;
				cout << "****************************************************************************************************" << endl;
				cout << "Press any key to continue..." << endl;
				getch();
				break;
			}
			case 4: {
				system("cls");
				cout << "M-Circle with maximum number of inner circles: " << CircleWithMaxCountOfInnerCircles << endl;
				cout << "****************************************************************************************************" << endl;
				cout << "Description of circles that are inner circles of M-Circle:" << endl;
				for_each(innerCircles.begin(), innerCircles.end(), show);
				cout << "****************************************************************************************************" << endl;
				cout << "Press any key to continue..." << endl;
				getch();
				break;
			}
			case 5: {
				system("cls");
				cout << "Description of circles that are inner circles of M-Circle:" << endl;
				cout << "****************************************************************************************************" << endl;
				cout << "Square of all inner circles of M-Circle: " << square.getSquare() << endl;
				cout << "****************************************************************************************************" << endl;
				cout << "Press any key to continue..." << endl;
				getch();
				break;
			}
			default:
				exit(0);
				break;
			}
		}
		system("cls");
		if (k == 1) SetColor(10, 0);
		cout << "Generate 200 circles" << endl;
		SetColor(15, 0);
		if (k == 2) SetColor(10, 0);
		if (max < 3) SetColor(14, 0);
		cout << "Show all 200 circles" << endl;
		SetColor(15, 0);		
		if (k == 3) SetColor(10, 0);
		if (max < 3) SetColor(14, 0);
		cout << "Show M-Circle with maximum number of inner circles" << endl;
		SetColor(15, 0);
		if (k == 4) SetColor(10, 0);
		if (max < 3) SetColor(14, 0);
		cout << "Show description of circles that are inner circles of M-Circle" << endl;
		SetColor(15, 0);
		if (k == 5) SetColor(10, 0);
		if (max < 3) SetColor(14, 0);
		cout << "Show square of all inner circles of M-Circle" << endl;
		SetColor(15, 0);
		if (k == max) SetColor(10, 0);
		cout << "Exit" << endl;
		SetColor(15, 0);
	} while (en = getch());

	return 0;
}