#pragma once

using namespace std;

wchar_t clubs[10][20] = { L"Барселона", L"Реал Мадрид", L"Манчестер Юнайтед", L"Ювентус", L"Бавария", L"Галатасарай", L"Милан", L"Ливерпуль", L"Интер", L"Марсель" };

class Club
{
protected:
	wchar_t name[20];
	Coach *coach;
	Player *team[15];
	int goalkeeperSkill;
	int it;
public:
	Club(Coach *c)
	{
		wcscpy(this->name, clubs[rand() % 10]);
		this->coach = c;
	}
	
	bool checkNames(Player *p)
	{
		for (int i = 0; i < it; i++)
			if (wcscmp(team[i]->getName(), p->getName()) == 0)
				return true;
		return false;
	}

	wchar_t* getName()
	{
		return this->name;
	}

	void teamFactory()
	{
		bool done = false;
		this->it = 0;
		team[it] = new PGoalkeeper;
		this->goalkeeperSkill = team[it]->getSkill();
		coach->setBank(team[it++]->getPrice());
		int count = 0;
		while (!done)
		{
			if (rand() % 2)
			{
				PStriker *st = new PStriker;
				if (checkNames(st))
					continue;
				if (coach->getBank() > st->getPrice())
				{
					coach->setBank(st->getPrice());
					team[it++] = st;
				}
			}
			else
			{
				PMiddlefielder *st = new PMiddlefielder;
				if (checkNames(st))
					continue;
				if (coach->getBank() > st->getPrice())
				{
					coach->setBank(st->getPrice());
					team[it++] = st;
				}
			}
			count++;
			if (count >= 50)
				done = true;
			if (it >= 15)
				done = true;
			if (coach->getBank() <= 100000)
				done = true;
		}
	}	

	double getAvgSkill()
	{
		int sum = 0;
		for (int i = 0; i < it; i++)
			sum += team[i]->getSkill();
		return (double)sum / it;
	}

	double getAttackSkill()
	{
		int j = 0, sum = 0;
		for (int i = 0; i < it; i++)
		{
			if (typeid(*team[i]) != typeid(PStriker))
				continue;
			j++;
			sum += team[i]->getSkill();
		}			
		return (double)sum / j;
	}

	double getDefenseSkill()
	{
		int j = 0, sum = 0;
		for (int i = 0; i < it; i++)
		{
			if (typeid(*team[i]) == typeid(PStriker))
				continue;
			j++;
			sum += team[i]->getSkill();
		}
		return (double)sum / j;
	}

	void sortTeam()
	{
		Player* tmp;
		int i, j;
		for (i = 1; i < it; i++)
		{
			tmp = this->team[i];
			for (j = i - 1; j >= 0 && team[j]->getSkill() > tmp->getSkill(); j--)
				team[j + 1] = team[j];
			team[j + 1] = tmp;
		}
	}

	void optimizeTeam()
	{
		double avg = getAvgSkill();
		if (this->coach->getBank() < 10000)
			return;
		if (getAttackSkill() > getDefenseSkill())
		{
			int o = 0;
			while (true)
			{
				if (o >= 50)
					break;
				o++;
				PMiddlefielder *mf = new PMiddlefielder;
				if (mf->getSkill() < avg)
				{
					delete mf;
					continue;
				}
				if (checkNames(mf))
				{
					delete mf;
					continue;
				}
				if (mf->getPrice() < this->coach->getBank())
				{
					if (typeid(*team[0]) != typeid(PGoalkeeper))
					{
						delete team[0];
						team[0] = mf;
					}
					else
					{
						delete team[1];
						team[1] = mf;
					}
					this->coach->setBank(mf->getPrice());
					break;
				}
				else
					delete mf;
			}
		}
		else
		{	
			int o = 0;
			while (true)
			{
				if (o >= 50)
					break;
				o++;
				PStriker *mf = new PStriker;
				if (mf->getSkill() < avg)
				{
					delete mf;
					continue;
				}
				if (checkNames(mf))
				{
					delete mf;
					continue;
				}
				if (mf->getPrice() < this->coach->getBank())
				{				
					if (typeid(*team[0]) != typeid(PGoalkeeper))
					{
						delete team[0];
						team[0] = mf;
					}
					else
					{
						delete team[1];
						team[1] = mf;
					}
					this->coach->setBank(mf->getPrice());
					break;
				}
				else
					delete mf;
			}
		}
	}

	int getTotalAttack()
	{
		int j = 0, sum = 0;
		for (int i = 0; i < it; i++)
		{
			if (typeid(*team[i]) != typeid(PStriker))
				continue;
			j++;
			sum += team[i]->getSkill();
		}
		return sum;
	}

	int getTotalDefense()
	{
		int j = 0, sum = 0;
		for (int i = 0; i < it; i++)
		{
			if (typeid(*team[i]) == typeid(PStriker))
				continue;
			j++;
			sum += team[i]->getSkill();
		}
		return sum;
	}

	int getGoalkeeperSkill()
	{
		return this->goalkeeperSkill;
	}

	void showTeam()
	{
		wcout << L"* * * * * * * * * * " << this->name << L" * * * * * * * * * *" << endl << endl;
		for (int i = 0; i < it; i++)
		{
			wprintf(L"Name: %20s | Skill: %2d | Price: %6d\n", this->team[i]->getName(), this->team[i]->getSkill(), this->team[i]->getPrice());
		}
		wcout << fixed << setprecision(2) << L"Средний скилл команды: " << this->getAvgSkill() << endl;
		wcout << fixed << setprecision(2) << L"Средний скилл атаки команды: " << this->getAttackSkill() << endl;
		wcout << fixed << setprecision(2) << L"Средний скилл защиты команды: " << this->getDefenseSkill() << endl;
		wcout << L"Остаток денег: " << coach->getBank() << endl;
	}
};