#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h>
#include <string>
#include <vector>
#include <algorithm>
#include "header.h"

using namespace std;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));

	Chatter* ch1 = new Chatter("name1");
	Chatter* ch2 = new Chatter("name2");
	Chatter* ch3 = new Chatter("name3");
	Chatter* ch4 = new Chatter("name4");
	AbMediator* m1 = new Mediator1;
	m1->AddChatter(ch1);
	m1->AddChatter(ch2);
	m1->AddChatter(ch3);
	m1->AddChatter(ch4);
	ch1->SendMsg(m1, "Lol");
}