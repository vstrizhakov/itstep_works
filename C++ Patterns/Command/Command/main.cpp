#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h>
#include "header.h"
#include <vector>
#include <functional>
#include <algorithm>

using namespace std;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));
	User user;
	user.Compute('+', 100);
	user.Compute('*', 543);
	user.Compute('/', 221);
	user.Compute('-', 20);
	user.Undo(2);
	user.Redo(1);
}