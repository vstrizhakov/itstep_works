#pragma once
#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h>
#include <vector>
#include <functional>
#include <algorithm>

using namespace std;

class Card
{
	int pin;
	int balance;
public:
	Card(int pin, int balance)
	{
		this->pin = pin;
		this->balance = balance;
	}

	int GetPin()
	{
		return this->pin;
	}

	int GetBalance()
	{
		return this->balance;
	}

	void SetBalance(int balance)
	{
		this->balance = balance;
	}

	void Show()
	{
		cout << "Card: " << pin << " | Current balance: " << balance << endl;
	}
};

void ShowCard(Card* c);

class Bank
{
	vector<Card*> cards;
public:
	void AddCard(Card* c)
	{
		if (c->GetBalance() > 0)
		{
			cards.push_back(c);
		}
	}

	void ShowCards()
	{
		for_each(this->cards.begin(), this->cards.end(), ShowCard);
	}

	Card* CheckCard(Card* c)
	{
		vector<Card*>::iterator it = find(cards.begin(), cards.end(), c);
		if (it != cards.end())
			return *it;
		else
			return NULL;
	}
};

class ATM
{
protected:
	Bank* bank;
	int money;
public:
	ATM(Bank* bank = NULL)
	{
		this->bank = bank;
	}

	int InsertCard(Card* c)
	{
		Card* card = this->bank->CheckCard(c);
		if (c == NULL)
		{
			cout << "Unknown card!" << endl;
			return -2;
		}
		int pin;
		cout << "Enter pin code: ";
		cin >> pin;
		if (c->GetPin() != pin)
		{
			cout << "Wrong pin code!" << endl;
			return -1;
		}
		return 0;
	}

	int RequestMoney(Card* c)
	{
		int balance;
		cout << "Enter count of money:";
		cin >> balance;
		if (c->GetBalance() < balance)
		{
			cout << "Not enough money!" << endl;
			return -1;
		}
		this->money = balance;
		return 0;
	}

	void GetMoney(Card* c)
	{
		c->SetBalance(c->GetBalance() - this->money);
		cout << "Get money and you card!" << endl;
	}
};

class ATMFacade :public ATM
{
public:
	ATMFacade(Bank* bank) :ATM(bank) {}

	void ClientACtion(Card* c)
	{
		int res = this->InsertCard(c);
		if (!res)
		{
			res = this->RequestMoney(c);
			if (!res)
			{
				this->GetMoney(c);
			}
		}
	}
};