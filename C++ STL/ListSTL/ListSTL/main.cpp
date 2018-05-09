#include <iostream>
#include <Windows.h>
#include <iomanip>
#include <ctime>
#include <algorithm>
#include <list>
#include <string>
#include <functional>

using namespace std;

class Child
{
	string name;
	int age;
	string sex;
	bool hasFriend;
public:
	Child(string name = "N/S", int age = 0, string sex = "N/S")
	{
		this->age = age;
		this->sex = sex;
		this->name = name;
		this->hasFriend = false;
	}

	friend ostream& operator<<(ostream& os, Child& c)
	{
		os << "Name: " << c.name << " | Sex: " << c.sex << " | Age: " << c.age << " | Has friend: " << c.hasFriend;
		return os;
	}

	void setAge(int age)
	{
		this->age = age;
	}

	void setSex(string sex)
	{
		this->sex = sex;
	}

	void setName(string name)
	{
		this->name = name;
	}

	void setHasFriend(bool hasFriend)
	{
		this->hasFriend = hasFriend;
	}

	int getAge()
	{
		return this->age;
	}

	string getSex()
	{
		return this->sex;
	}

	string getName()
	{
		return this->name;
	}

	bool getHasFriend()
	{
		return this->hasFriend;
	}
};

class Match
{
	int mage;
	string msex;
public:
	Match(int mage = 0, string msex = "N/S")
	{
		this->mage = mage;
		this->msex = msex;
	}

	bool operator()(Child& c1)
	{
		if (!c1.getHasFriend() && c1.getAge() == mage && c1.getSex() != msex)
			return true;
		else
			return false;
	}
};

void show(Child& c)
{
	cout << c << endl;
}

int myRand(int& a)
{
	return rand() % a;
}

bool q(Child& c)
{
	return !c.getHasFriend();
}

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));

	string boys[10] = { "Alexandr", "Vladimir", "Nikita", "Dmitry", "Ivan", "Sergey", "Konstantin", "Danil", "Artem", "Denis" };
	string girls[10] = { "Sasha", "Eva", "Sofia", "Dasha", "Anna", "Masha", "Lera", "Kristina", "Leila", "Angelina" };

	list<Child> kids;
	list<Child> friends;
	list<Child>::iterator itf;
	for (int i = 0; i < 5; i++)
	{
		string iname, isex;
		int iage = 0;
		iname = girls[rand() % 10];
		isex = "girl";
		iage = rand() % 5 + 6;
		kids.push_back(*(new Child(iname, iage, isex)));
		iname = boys[rand() % 10];
		isex = "boy";
		iage = rand() % 5 + 6;
		kids.push_front(*(new Child(iname, iage, isex)));
	}
	//random_shuffle(kids.begin(), kids.end(), myRand); - ÒÎËÜÊÎ ÄËß ÂÅÊÒÎÐÎÂ
	for_each(kids.begin(), kids.end(), show);
	cout << "******************************************************************************" << endl;
	list<Child>::iterator it = kids.begin();
	while (it != kids.end() && !it->getHasFriend())
	{
		itf = find_if(kids.begin(), kids.end(), Match(it->getAge(), it->getSex()));
		if (itf == kids.end())
		{
			it++;
			continue;
		}
		if (!itf->getHasFriend())
		{
			it->setHasFriend(true);
			itf->setHasFriend(true);
			friends.push_back(*it);
			friends.push_back(*itf);
		}
		it++;
	}
	
	for_each(friends.begin(), friends.end(), show);
	cout << "******************************************************************************" << endl;
	it = kids.begin();
	while (it != kids.end())
	{
		it = find_if(it, kids.end(), q);
		if (it != kids.end())
		{
			cout << *it << endl;
			it++;
		}
	}
}