#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h>
#include "header.h"
#include <vector>
#include <functional>
#include <algorithm>

using namespace std;

void ShowCard(Card* c)
{
	c->Show();
}

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));
	//////////////without facade////////////
	Card card1(1111, 10000);
	Card card2(2222, 20000);
	Card card3(3333, 30000);
	Card card4(4444, 40000);
	Bank bank;
	Bank bank2;
	bank.AddCard(&card1);
	bank.AddCard(&card2);
	bank.AddCard(&card3);
	bank.AddCard(&card4);
	bank.ShowCards();
	ATMFacade atm(&bank);
	atm.ClientACtion(&card3);
	card3.Show();
}