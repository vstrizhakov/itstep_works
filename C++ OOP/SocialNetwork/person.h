#pragma once
#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>
#include <conio.h>

using namespace std;

class Person
{
public:
	char firstname[32];
	char surname[32];
	char sex[7];

	virtual void Show() = 0;

	Person(char* firstname = "no firstname", char* surname = "no surname", char* sex = "N/S")
	{
		strcpy(this->firstname, firstname);
		strcpy(this->surname, surname);
		strcpy(this->sex, sex);
	}
};