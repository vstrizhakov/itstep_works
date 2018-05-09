#pragma once
#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <string>
#include <vector>
#include <conio.h>

using namespace std;

// классы юнитов
class UnitC     // юнит с самым низким рангом
{
public:
	virtual void Work()=0;
	virtual UnitC* Clone() = 0;
	virtual void randomize() = 0;
};

class UnitB     // юнит среднего ранга
{
public:
	virtual void Protect(UnitC* c)=0;
	virtual UnitB* Clone() = 0;
	virtual void randomize() = 0;
};

class UnitA     // юнит с самым высоким рангом
{
public:
	virtual void Rule(UnitB* b)=0;
	virtual void randomize() = 0;
};

class AbstractFactioty
{

public:
	virtual UnitA* CreateUnitA() = 0;
	virtual UnitB* CreateUnitB() = 0;
	virtual UnitC* CreateUnitC() = 0;
};

class Peasant : public UnitC
{
protected:
	int health;
public:
	Peasant()
	{
		this->health = rand() % 50 + 50;
	}
	void Work()
	{
		cout << typeid(Peasant).name() << " works..." << endl;
	}

	virtual Peasant* Clone()
	{
		return new Peasant(*this);
	}

	void SetHealth(int health)
	{
		this->health = health;
	}

	int GetHealth()
	{
		return this->health;
	}

	virtual void randomize()
	{
		this->health = rand() % 50 + 50;
	}
};

class Palladin : public UnitB
{
protected:
	int health, attack, defend;
public:
	Palladin()
	{
		this->health = rand() % 80 + 20;
		this->attack = rand() % 50 + 50;
		this->defend = rand() % 10 + 40;
	}

	void Protect(UnitC* c)
	{
		cout << typeid(Palladin).name() << " protects" << typeid(Peasant).name() << " from berserks" << endl;
	}

	virtual Palladin* Clone()
	{
		return new Palladin(*this);
	}

	void SetHealth(int health)
	{
		this->health = health;
	}

	void SetAttack(int attack)
	{
		this->attack = attack;
	}

	void SetDefend(int defend)
	{
		this->defend = defend;
	}

	int GetHealth()
	{
		return this->health;
	}

	int GetAttack()
	{
		return this->attack;
	}

	int GetDefend()
	{
		return this->defend;
	}

	virtual void randomize()
	{
		this->health = rand() % 80 + 20;
		this->attack = rand() % 50 + 50;
		this->defend = rand() % 10 + 40;
	}
};

class Mage : public UnitA
{
protected:
	int health, attack, defend;
	Mage()
	{
		this->health = rand() % 10 + 50;
		this->attack = rand() % 500 + 500;
		this->defend = rand() % 40 + 40;
	}
	Mage(const Mage& s);
	Mage& operator =(Mage &s);
	static Mage* pm;
public:
	static Mage* GetInstance()
	{
		if (!pm)
			pm = new Mage();
		return pm;
	}

	void Rule(UnitB* b)
	{
		cout << typeid(Mage).name() << " rules over" << typeid(Palladin).name() << " against orcs" << endl;
	}

	void SetHealth(int health)
	{
		this->health = health;
	}

	void SetAttack(int attack)
	{
		this->attack = attack;
	}

	void SetDefend(int defend)
	{
		this->defend = defend;
	}

	int GetHealth()
	{
		return this->health;
	}

	int GetAttack()
	{
		return this->attack;
	}

	int GetDefend()
	{
		return this->defend;
	}

	virtual void randomize()
	{
		this->health = rand() % 80 + 20;
		this->attack = rand() % 50 + 50;
		this->defend = rand() % 10 + 40;
	}
};


class Slave : public UnitC
{
protected:
	int health;
public:
	Slave()
	{
		this->health = rand() % 50 + 50;
	}

	void Work()
	{
		cout << typeid(Slave).name() << " Slave..." << endl;
	}

	virtual Slave* Clone()
	{
		return new Slave(*this);
	}

	void SetHealth(int health)
	{
		this->health = health;
	}

	int GetHealth()
	{
		return this->health;
	}

	virtual void randomize()
	{
		this->health = rand() % 80 + 20;
	}
};

class Berserk : public UnitB
{
protected:
	int health, attack, defend;
public:
	Berserk()
	{
		this->health = rand() % 80 + 20;
		this->attack = rand() % 50 + 50;
		this->defend = rand() % 10 + 40;
	}

	void Protect(UnitC* c)
	{
		cout << typeid(Berserk).name() << " Berserk" << typeid(Slave).name() << " Slave" << endl;
	}

	virtual Berserk* Clone()
	{
		return new Berserk(*this);
	}

	virtual void Show()
	{
		cout << "H: " << this->health << " A: " << this->attack << " D: " << this->defend << endl;
	}

	void SetHealth(int health)
	{
		this->health = health;
	}

	void SetAttack(int attack)
	{
		this->attack = attack;
	}

	void SetDefend(int defend)
	{
		this->defend = defend;
	}

	int GetHealth()
	{
		return this->health;
	}

	int GetAttack()
	{
		return this->attack;
	}

	int GetDefend()
	{
		return this->defend;
	}

	virtual void randomize()
	{
		this->health = rand() % 80 + 20;
		this->attack = rand() % 50 + 50;
		this->defend = rand() % 10 + 40;
	}
};

class Shaman : public UnitA
{
protected:
	int health, attack, defend;
	Shaman()
	{
		this->health = rand() % 10 + 50;
		this->attack = rand() % 500 + 500;
		this->defend = rand() % 40 + 40;
	}
	Shaman(const Shaman& s);
	Shaman& operator =(Shaman &s);
	static Shaman *ps;
public:
	static Shaman* GetInstance()
	{
		if (!ps)
			ps = new Shaman();
		return ps;
	}

	void Rule(UnitB* b)
	{
		cout << typeid(Shaman).name() << " Shaman over" << typeid(Berserk).name() << " Berserk" << endl;
	}

	void SetHealth(int health)
	{
		this->health = health;
	}

	void SetAttack(int attack)
	{
		this->attack = attack;
	}

	void SetDefend(int defend)
	{
		this->defend = defend;
	}

	int GetHealth()
	{
		return this->health;
	}

	int GetAttack()
	{
		return this->attack;
	}

	int GetDefend()
	{
		return this->defend;
	}

	virtual void randomize()
	{
		this->health = rand() % 80 + 20;
		this->attack = rand() % 50 + 50;
		this->defend = rand() % 10 + 40;
	}
};

class HumanFactory : public AbstractFactioty          // люди
{
public:
	//create peasant (созд крестьян)
	UnitC* CreateUnitC()
	{
		return new Peasant;
	}
	//create palladin создаём воинов
	UnitB* CreateUnitB()
	{
		return new Palladin;
	}
	//create mage
	UnitA* CreateUnitA()
	{
		return Mage::GetInstance();
	}
};

class OrcFactory : public AbstractFactioty          // орки
{
public:
	//create Slave
	UnitC* CreateUnitC()
	{
		return new Slave;
	}
	//create Berserk 
	UnitB* CreateUnitB()
	{
		return new Berserk;
	}
	//create Shaman
	UnitA* CreateUnitA()
	{
		return Shaman::GetInstance();
	}
};

template<typename T>
vector<T*> GenerateUnits(T* u, int num);

class Client
{
protected:
	UnitA* oa;
	UnitB* ob;
	UnitC* oc;
public:
	Client(AbstractFactioty* factory)
	{
		oa = factory->CreateUnitA();
		ob = factory->CreateUnitB();
		oc = factory->CreateUnitC();
	}
	
	UnitA* GetA()
	{
		return this->oa;
	}

	UnitB* GetB()
	{
		return this->ob;
	}

	UnitC* GetC()
	{
		return this->oc;
	}
};

