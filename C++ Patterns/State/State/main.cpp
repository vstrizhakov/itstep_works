#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h> 
#include <string>
#include "header.h"

using namespace std;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));
	NormalState ns;
	Car car(&ns);
	car.UseCar();
}