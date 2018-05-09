#pragma once

using namespace std;

class Sponsor
{
	int balance;
public:
	Sponsor()
	{
		while (this->balance < 5000000)
		{
			int tmp = rand() * rand() * rand() * rand();
			this->balance = tmp % 5000000 + 5000000;
		}
	}

	int GetMoney()
	{
		return this->balance;
	}

	int InvestMoney()
	{
		int tmp = this->balance / (rand() % 3 + 1) - 100000;
		this->balance -= tmp;
		return tmp;
	}
};