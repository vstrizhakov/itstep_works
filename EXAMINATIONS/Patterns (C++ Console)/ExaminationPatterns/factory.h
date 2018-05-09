#pragma once

using namespace std;

vector<string> InitClubs();
vector<string> clubs = InitClubs();

class AbstractFactory
{
public:
	virtual Sponsor* CreateSponsor() = 0;
	virtual Coach* CreateCoach(Sponsor* sponsor) = 0;
	virtual Player* CreateStriker() = 0;
	virtual Player* CreateMiddlefielder() = 0;
	virtual Player* CreateGoalkeeper() = 0;	
	virtual string CreateName() = 0;
};

class ClubFactory :public AbstractFactory
{
	static Player* StaticStriker;
	static Player* StaticMiddlefielder;
	static Player* StaticGoalkeeper;
public:
	static void InitPlayers()
	{
		if (StaticStriker == NULL)
			StaticStriker = new Striker;
		if (StaticMiddlefielder == NULL)
			StaticMiddlefielder = new Middlefielder;
		if (StaticGoalkeeper == NULL)
			StaticGoalkeeper = new Goalkeeper;
	}

	virtual Sponsor* CreateSponsor()
	{
		return new Sponsor;
	}

	virtual Coach* CreateCoach(Sponsor* sponsor)
	{
		return new Coach(sponsor);
	}

	virtual Player* CreateStriker()
	{
		return StaticStriker->Clone();
	}

	virtual Player* CreateMiddlefielder()
	{
		return StaticMiddlefielder->Clone();
	}

	virtual Player* CreateGoalkeeper()
	{
		return StaticGoalkeeper->Clone();
	}

	virtual string CreateName()
	{
		string tmp = clubs[rand() % clubs.size()];
		clubs.erase(find(clubs.begin(), clubs.end(), tmp));
		return tmp;
	}
};