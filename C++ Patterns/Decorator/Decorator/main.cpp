#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h>
#include <string>
#include <fstream>
#include "header.h"

using namespace std;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));
	Text* t = new Text;
	t->SetText("BOLD OR BIG OR ITALIC TEXT");
	t->Display();
	Text* tbold = new BoldDecorator(t);
	tbold->Display();
	Text* titalic = new ItalicDecorator(tbold);
	titalic->Display();
	titalic->CreateFile_("index.html");
}