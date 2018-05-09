#pragma once

using namespace std;

wchar_t names[30][20] = { L"Lionel Messi",L"Cristiano Ronaldo",L"Franck Ribéry",L"Sergio Ramos",L"Gerard Piqué ",
L"Mario Gomez",L"Carlos Tévez",L"Vincent Kompany",L"Giorgio Chiellini",L"Yaya Touré",L"Andrea Pirlo",L"Iker Casillas",
L"Gianluigi Buffon",L"Edinson Cavani",L"Juan Mata",L"Mesut Özil",L"Gareth Bale",L"Thiago Silva",L"Nemanja Vidić",L"Philipp Lahm",
L"Wayne Rooney",L"David Silva",L"Sergio Agüero",L"Schweinsteiger",L"Arjen Robben",L"Zlatan Ibrahimović",L"Xavi",L"Robin van Persie",
L"Andres Iniesta",L"Falcao" };

class Player
{
protected:
	int skill;
	int price;
	wchar_t name[20];
public:
	virtual double Striker() = 0;
	virtual double Goalkeeper() = 0;
	virtual double Middlefielder() = 0;

	Player()
	{
		this->skill = rand() % 10 + 1;
		this->price = this->skill * 30000;
		wcscpy(this->name, names[rand() % 30]);
	}

	int getPrice()
	{
		return this->price;
	}

	int getSkill()
	{
		return this->skill;
	}

	wchar_t* getName()
	{
		return this->name;
	}
};

class PStriker :public Player
{
public:
	virtual double Striker()
	{
		return this->skill;
	}

	virtual double Goalkeeper()
	{
		return 0;
	}

	virtual double Middlefielder()
	{
		return 0;
	}
};

class PGoalkeeper :public Player
{
public:
	virtual double Striker()
	{
		return 0;
	}

	virtual double Goalkeeper()
	{
		return this->skill;
	}

	virtual double Middlefielder()
	{
		return 0;
	}
};

class PMiddlefielder :public Player
{
public:
	virtual double Striker()
	{
		return 0;
	}

	virtual double Goalkeeper()
	{
		return 0;
	}

	virtual double Middlefielder()
	{
		return this->skill;
	}
};