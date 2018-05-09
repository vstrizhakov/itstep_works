#pragma once

using namespace std;

class Coach
{
protected:
	int bank;
	Sponsor *sponsor;
public:
	Coach(Sponsor *s)
	{
		this->sponsor = s;
		this->bank = this->sponsor->investMoney();
	}

	Coach() {}

	void setBank(int b)
	{
		this->bank -= b;
	}

	int getBank()
	{
		return this->bank;
	}
};