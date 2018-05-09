#include <iostream>
#include <Windows.h>
#include <iomanip>
#include <ctime>
#include <algorithm>
#include <vector>
#include "header.h"

using namespace std;

class sortFunctor
{
public:
	bool operator()(Fish& f1, Fish& f2)
	{
		return f1.getWeight() > f2.getWeight();
	}
};

char Names[7][15] = { "Êàğàñü", "Ùóêà", "Îêóíü", "Êàğï", "Òàğàíü", "Êğàñíîïåğêà", "Âåğõîâîäêà" };

void show(Fish& f)
{
	cout << f;
}

bool sortFish(Fish& f1, Fish& f2)
{
	if (f1.getPrice() < f2.getPrice())
		return false;
	else
		return true;
}

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	vector<Fish> v;
	for (int i = 0; i < 10; i++)
	{
		v.push_back(*(new Fish(Names[rand() % 7],
			(double)(rand() % 5 + 1),
			(double)(rand() % 100 + 1)
		)));
	}
	for_each(v.begin(), v.end(), show);
	cout << "****************************************************************************************************" << endl;
	//ÑÎĞÒÈĞÎÂÊÀ ÔÓÍÊÒÎĞÎÌ-ÏĞÅÄÈÊÀÒÎÌ
	cout << "ÑÎĞÒÈĞÎÂÊÀ ÔÓÍÊÒÎĞÎÌ-ÏĞÅÄÈÊÀÒÎÌ ÏÎ ÂÅÑÓ:" << endl;
	sortFunctor q;
	sort(v.begin(), v.end(), q);
	for (int i = 0; i < v.size(); i++)
	{
		cout << v.at(i);
	}
	cout << "****************************************************************************************************" << endl;
	//ÑÎĞÒÈĞÎÂÊÀ ÔÓÍÊÖÈÅÉ-ÏĞÅÄÈÊÀÒÎÂ
	cout << "ÑÎĞÒÈĞÎÂÊÀ ÔÓÍÊÖÈÅÉ-ÏĞÅÄÈÊÀÒÎÌ ÏÎ ÖÅÍÅ:" << endl;	
	sort(v.begin(), v.end(), sortFish);
	for (int i = 0; i < v.size(); i++)
	{
		cout << v.at(i);
	}
	return 0;
}