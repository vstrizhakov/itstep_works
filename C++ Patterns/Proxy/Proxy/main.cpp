#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h>
#include "header.h"
#include <string>

using namespace std;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));

	Driver *d1 = new Driver("John", 10);
	Car car(d1);
	ProxyCar pc(d1);
	pc.DriveCar();
}