#include "header.h"
#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h>
#include <algorithm>
#include <numeric>
#include <functional>
#include <set>
#include <utility>
#include <fstream>

using namespace std;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));

	string text = "lazy dog is sleeping on the wet straw";
	CharFactory cf;
	BaseSymbol* c;
	ofstream out("index.html");
	for (string::iterator it = text.begin(); it != text.end(); it++)
	{
		c = cf.GetSymbol((*it));
		cout << (c->GetChar());
		out << c->DisplaySymbol(70, "red");
	}
	out.close();
	cf.ShowPool();
}