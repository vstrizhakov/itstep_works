#include "fish.h"
#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>
#include <fstream>
int main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));

	Fish f1("Ribaaa_1", 36, 120);
	Fish f2("Ribaaa_2", 10, 412);
	Fish f3("Ribaaa_3", 15.2, 486);
	Fish f4("Ribaaa_4", 145, 123);
	Fish f5("Ribaaa_5", 24, 1200);

	Fish arFish[5] = { f1,f2,f3,f4,f5 };
	ofstream out("fishes.txt", ios::out | ios::ate);
	for (int i = 0; i < 5; i++)
	{
		out << arFish[i].getName() << "|" << arFish[i].getWeight() << "|" << arFish[i].getPrice() << "\r\n";	
	}
	cout << endl;
	out.close();
	ifstream in("fishes.txt", ios::in);
	char str[255];
	while (!in.eof())
	{
		in.getline(str, 255, '|');
		cout << str << " ";
	}
	in.close();

}