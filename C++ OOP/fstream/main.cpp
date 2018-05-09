#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>
#include <conio.h>
#include <fstream>
#include "header.h"

using namespace std;

void main()
{
	setlocale(LC_ALL, "rus");
	Fish f("YEGRES", 1258, 2.1);
	Fish f2;
	ofstream out("ar.txt", ios::out | ios::binary);
	if (!out)
	{
		cout << "Open file error";
		return;
	}
	out.write((char *)&f, sizeof(f));
	out.close();
	ifstream in("ar.txt", ios::in | ios::binary);
	in.read((char *)&f2, sizeof(f2));
	cout << f2;
	in.close();
}