#pragma once

using namespace std;

class Sponsor
{
protected:
	int balance;
public:
	Sponsor()
	{
		while (this->balance < 5000000)
		{
			int p = rand() * rand() * rand();
			this->balance = p % 5000000 + 5000000;
		}
	}

	int investMoney()
	{
		int part = rand() % 3 + 2;
		int money = this->balance / part;
		this->balance -= money;
		return money;
	}

	int getBalance()
	{
		return this->balance;
	}
};