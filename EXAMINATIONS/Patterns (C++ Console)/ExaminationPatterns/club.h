#pragma once

using namespace std;

void ShowPlayer(Player* p);

class Club
{
	string name;
	Sponsor* sponsor;
	Coach* coach;
	vector<Player*> team;
	int attack;
	int strikersAndMiddlefielderDefend;
	int goalkeeperDefend;
public:
	~Club()
	{
		delete this->coach;
		delete this->sponsor;
		vector<Player*>::iterator it = team.begin();
		for (it; it != team.end(); it++)
			delete *it;

	}

	Club(AbstractFactory* factory = new ClubFactory)
	{
		this->name = factory->CreateName();
		this->sponsor = factory->CreateSponsor();
		this->coach = factory->CreateCoach(this->sponsor);
		this->attack = 0;
		this->strikersAndMiddlefielderDefend = 0;
		this->goalkeeperDefend = 0;
		Player* tmpGoalkeeper = factory->CreateGoalkeeper();
		tmpGoalkeeper->Randomize();
		this->attack += tmpGoalkeeper->GetAttack();
		this->goalkeeperDefend += tmpGoalkeeper->GetDefend();
		coach->SetBank(tmpGoalkeeper->GetPrice());
		team.push_back(tmpGoalkeeper);
		while (team.size() < 5 && coach->GetBank() > 300000)
		{
			if (rand() % 2)
			{
				Player* tmpStriker = factory->CreateStriker();
				tmpStriker->Randomize();
				if (coach->GetBank() >= tmpStriker->GetPrice())
				{
					coach->SetBank(tmpStriker->GetPrice());
					this->attack += tmpStriker->GetAttack();
					this->strikersAndMiddlefielderDefend += tmpStriker->GetDefend();
					team.push_back(tmpStriker);
					tmpStriker = nullptr;
				}
				else
				{
					tmpStriker->ReturnName();
					delete tmpStriker;
				}
			}
			else
			{
				Player* tmpMiddlefielder = factory->CreateMiddlefielder();
				tmpMiddlefielder->Randomize();
				if (coach->GetBank() >= tmpMiddlefielder->GetPrice())
				{
					coach->SetBank(tmpMiddlefielder->GetPrice());
					this->attack += tmpMiddlefielder->GetAttack();
					this->strikersAndMiddlefielderDefend += tmpMiddlefielder->GetDefend();
					team.push_back(tmpMiddlefielder);
					tmpMiddlefielder = nullptr;
				}
				else
				{
					tmpMiddlefielder->ReturnName();
					delete tmpMiddlefielder;
				}
			}
		}
	}

	void ShowTeam()
	{
		cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Клуб " << this->name << " ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;		
		for_each(team.begin(), team.end(), ShowPlayer);
		cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
		cout << setw(36) << "Количество игроков: " << this->team.size() << endl;
		cout << setw(36) << "Общая атака игроков: " << this->attack << endl;
		cout << setw(36) << "Общая защита игроков: " << this->strikersAndMiddlefielderDefend + this->goalkeeperDefend << endl;
		cout << setw(36) << "Общая стоимость игроков: " << this->GetTotalPrice() << endl;
		cout << setw(36) << "Начальный/конечный баланс тренера: " << this->coach->GetBank() + this->GetTotalPrice() << "/" << this->coach->GetBank() << endl;
		cout << setw(35) << "Начальный/конечный баланс спонсора: " << this->sponsor->GetMoney() + this->coach->GetBank() + this->GetTotalPrice() << "/" << this->sponsor->GetMoney() << endl;
	}

	int GetAttack()
	{
		return this->attack;
	}

	string GetName()
	{
		return this->name;
	}

	int GetStrikersAndMiedlefielderDefend()
	{
		return this->strikersAndMiddlefielderDefend;
	}

	int GetGoalkeeperDefend()
	{
		return this->goalkeeperDefend;
	}

	int GetSize()
	{
		return this->team.size();
	}

	int GetTotalPrice()
	{
		int total = 0;
		for (int i = 0; i < team.size(); i++)
		{
			total += team[i]->GetPrice();
		}
		return total;
	}
};