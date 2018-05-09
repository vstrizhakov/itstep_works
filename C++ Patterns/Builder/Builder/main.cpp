#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h> 
#include <vector>
#include <algorithm>
#include <numeric>
#include <functional>
#include <string>
#include "header.h"

using namespace std;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));

	Director* director = new Director;
	ABuilder* b1 = new Builder1;
	ABuilder* b2 = new Builder1;
	ABuilder* b3 = new Builder3;
	PC pc = director->CreatePC(b1);
	pc.Show();

}