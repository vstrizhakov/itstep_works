#pragma once
#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>
#include <conio.h>
#include "person.h"

using namespace std;

class Contact :public Person
{
public:
	char phone[32];
	char email[64];

	Contact(char* firstname = "no firstname", char* surname = "no surname", char* sex = "N/S", char* phone = "no phone", char* email = "no email") :Person(firstname, surname, sex)
	{
		strcpy(this->phone, phone);
		strcpy(this->email, email);
	}

	virtual void Show()
	{
		printf("Firstname: %s | Surname: %s | Sex: %s | Phone number: %s | Email: %s\n----------------------------------------------------------------------------------------------------\n", this->firstname, this->surname, this->sex, this->phone, this->email);
	}

	virtual void write()
	{

	}
};