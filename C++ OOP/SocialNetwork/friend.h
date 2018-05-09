#pragma once
#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>
#include <conio.h>
#include "contact.h"

using namespace std;

class Friend :public Contact
{
public:
	char birthday[32];
	char address[64];

	Friend(char* firstname = "no firstname", char* surname = "no surname", char* sex = "N/S", char* phone = "no phone", char* email = "no email", char* birthday = "unknown birthday", char* address = "unknon address") :Contact(firstname, surname, sex, phone, email)
	{
		strcpy(this->birthday, birthday);
		strcpy(this->address, address);
	}

	virtual void Show()
	{
		printf("Firstname: %s | Surname: %s | Sex: %s | Phone number: %s | Email: %s | Birthday: %s | Address: %s\n----------------------------------------------------------------------------------------------------\n", this->firstname, this->surname, this->sex, this->phone, this->email, this->birthday, this->address);
	}
};