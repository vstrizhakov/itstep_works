#pragma once

using namespace std;

class Coach
{
	int bank;
public:
	Coach(Sponsor* s)
	{
		this->bank = s->InvestMoney();
	}

	Coach()
	{
		this->bank = 0;
	}

	void SetBank(int b)
	{
		this->bank -= b;
	}

	int GetBank()
	{
		return this->bank;
	}
};