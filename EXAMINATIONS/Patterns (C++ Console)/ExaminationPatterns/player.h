#pragma once

using namespace std;

vector<string> InitNames();
vector<string> names = InitNames();

class Player
{
protected:
	int attack;
	int defend;
	int price;
	string name;
public:
	Player()
	{
		this->name = names[rand() % names.size()];
	}

	string GetName()
	{
		return this->name;
	}

	int GetAttack()
	{
		return this->attack;
	}

	int GetDefend()
	{
		return this->defend;
	}

	int GetPrice()
	{
		return this->price;
	}

	void ReturnName()
	{
		names.push_back(this->name);
	}

	virtual Player* Clone() = 0;
	virtual void Randomize() = 0;
	virtual void Show() = 0;
};

class Striker :public Player
{
public:
	Striker()
	{
		this->attack = rand() % 16 + 5;
		this->defend = rand() % (this->attack / 5) + 1;
		this->price = (this->attack + this->defend) * 75000;
	}

	virtual Player* Clone()
	{
		return new Striker(*this);
	}

	virtual void Randomize()
	{
		int tmp = rand() % names.size();
		this->name = names[tmp];
		names.erase(find(names.begin(), names.end(), names[tmp]));
		this->attack = rand() % 16 + 5;
		this->defend = rand() % (this->attack / 5) + 1;
		this->price = (this->attack + this->defend) * 75000;
	}

	virtual void Show()
	{
		cout << "Роль: Нападающий   | Имя: " << setw(20) << this->name << " | Атака: " << setw(2) << this->attack << " | Защита: " << setw(2) << this->defend << " | Цена: " << this->price << endl;
	}
};

class Middlefielder :public Player
{
public:
	Middlefielder()
	{
		this->attack = rand() % 16 + 5;
		this->defend = rand() % (this->attack / 2) + 1;
		this->price = (this->attack + this->defend) * 50000;
	}

	virtual Player* Clone()
	{
		return new Middlefielder(*this);
	}

	virtual void Randomize()
	{
		int tmp = rand() % names.size();
		this->name = names[tmp];
		names.erase(find(names.begin(), names.end(), names[tmp]));
		this->attack = rand() % 16 + 5;
		this->defend = rand() % (this->attack / 2) + 1;
		this->price = (this->attack + this->defend) * 50000;
	}

	virtual void Show()
	{
		cout << "Роль: Полузащитник | Имя: " << setw(20) << this->name << " | Атака: " << setw(2) << this->attack << " | Защита: " << setw(2) << this->defend << " | Цена: " << this->price << endl;
	}
};

class Goalkeeper :public Player
{
public:
	Goalkeeper()
	{
		this->defend = rand() % 16 + 5;
		this->attack = rand() % (this->defend / 5) + 1;
		this->price = (this->attack + this->defend) * 50000;
	}

	virtual Player* Clone()
	{
		return new Goalkeeper(*this);
	}

	virtual void Randomize()
	{
		int tmp = rand() % names.size();
		this->name = names[tmp];
		names.erase(find(names.begin(), names.end(), names[tmp]));
		this->defend = rand() % 16 + 5;
		this->attack = rand() % (this->defend / 5) + 1;
		this->price = (this->attack + this->defend) * 50000;
	}

	virtual void Show()
	{
		cout << "Роль: Вратарь      | Имя: " << setw(20) << this->name << " | Атака: " << setw(2) << this->attack << " | Защита: " << setw(2) << this->defend << " | Цена: " << this->GetPrice() << endl;
	}
};