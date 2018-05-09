#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>
#include <conio.h>
#include "header.h"

using namespace std;

Prototype* Client::fig1 = NULL;
Prototype* Client::fig2 = NULL;

void main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));
	Client::Init();
	Prototype* r1 = Client::GetRect();
	r1->SetY(100);
	r1->SetX(234);
	
	r1->Show();
}