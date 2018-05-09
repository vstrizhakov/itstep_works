#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>
#include <conio.h>
#include "header.h"

using namespace std;

Singleton* Singleton::ps = NULL;

void main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));

	Singleton *s1 = Singleton::GetInstance();
	Singleton *s2 = Singleton::GetInstance();
}
