#include <iostream>
#include <Windows.h>
#include <iomanip>
#include <ctime>
#include <algorithm>
#include <set>
#include <string>
#include <functional>
#include <list>
#include "header.h"

using namespace std;

void show(const Fish a)
{
	cout << a << "  ";
}

bool p1(const int& a)
{
	return a % 2 == 1;
}

class Fcomp
{
public:
	bool operator()(Fish f1, Fish f2)
	{
		return f1.getPrice() < f2.getPrice();
	}
};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));

	/*set<int> s;
	for (int i = 0; i < 100; i++)
	{
		s.insert(rand() % 50);
	}
	for_each(s.begin(), s.end(), show);
	list<int> ml;
	set<int>::iterator sit = s.begin();
	while (sit != s.end())
	{
		sit = find_if(sit, s.end(), p1);
		if (sit != s.end())
		{
			ml.push_back(*sit);
			sit++;
		}
	}
	cout << endl;
	for_each(ml.begin(), ml.end(), show);*/

	set<Fish, Fcomp> s1;
	
	s1.insert(*(new Fish("Fish1", rand() % 5, rand() % 100)));
	s1.insert(*(new Fish("Fish2", rand() % 5, rand() % 100)));
	s1.insert(*(new Fish("Fish3", rand() % 5, rand() % 100)));
	s1.insert(*(new Fish("Fish4", rand() % 5, rand() % 100)));
	s1.insert(*(new Fish("Fish5", rand() % 5, 100)));
	
	for_each(s1.begin(), s1.end(), show);
	return 0;
}