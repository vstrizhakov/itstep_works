#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <string>
#include <vector>
#include <conio.h>
#include <algorithm>
#include <functional>
#include "header.h"

using namespace std;

template<typename T>
vector<T*> GenerateUnits(T* u, int num)
{
	vector<T*> units;
	for (int i = 0; i < num; i++)
	{
		T* tmp = u->Clone();
		tmp->randomize();
		units.push_back(tmp);
	}
	return units;
}

void ShowBerserkers(Berserk* b)
{
	b->Show();
}

Mage* Mage::pm = NULL;
Shaman* Shaman::ps = NULL;

int main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));

	HumanFactory* hfactory = new HumanFactory;
	OrcFactory* ofactory = new OrcFactory;
	Client *ch = new Client(hfactory);
	Client *co = new Client(ofactory);
	Palladin *p = (Palladin*)ch->GetB();
	vector<Palladin*> palladins = GenerateUnits(p, 100);
	delete p;
	Berserk *b = (Berserk*)co->GetB();
	vector<Berserk*> berserkers = GenerateUnits(b, 100);
	delete b;
	Peasant *ps = (Peasant*)ch->GetC();
	vector<Peasant*> peasants = GenerateUnits(ps, 50);
	delete ps;
	Slave *sp = (Slave*)co->GetC();
	vector<Slave*> slaves = GenerateUnits(sp, 50);
	delete sp;
	Mage *mage = (Mage*)ch->GetA();
	Shaman *sham = (Shaman*)co->GetA();
	int step = 0;
	int move = 0;
	int strike_h = 0;
	int strike_o = 0;
	for_each(berserkers.begin(), berserkers.end(), ShowBerserkers);
	while (step < 100)
	{
		move = rand() % 2;
		if (move == 0)
		{
			move = rand() % 2;
			if (move == 0)
			{
				vector<Palladin*>::iterator it = palladins.begin();
				while (it < palladins.end())
				{
					strike_h += (*it)->GetAttack();
					it++;
				}
			}
			else
			{
				strike_h += mage->GetAttack();
			}
			move = rand() % 3;
			switch (move)
			{

			case 0:
			{
				break;
			}

			case 1:
			{
				vector<Berserk*>::iterator it = berserkers.begin();
				while (strike_h > 0 && it != berserkers.end())
				{
					int def_b = (*it)->GetDefend();
					int hlt_b = (*it)->GetHealth();
					strike_h -= hlt_b;
					hlt_b -= hlt_b - hlt_b * def_b / 100;
					if (hlt_b < 0) hlt_b = 0;
					def_b = 0;
					(*it)->SetDefend(def_b);
					(*it)->SetHealth(hlt_b);
					it++;
				}
				break;
			}

			case 2:
			{
				break;
			}

			}
		}
		else
		{

		}
		step++;
	}
	cout << "*******************************************************************************************************" << endl;
	for_each(berserkers.begin(), berserkers.end(), ShowBerserkers);
}