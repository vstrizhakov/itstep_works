#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <string>
#include "header.h"

using namespace std;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));
	BaseSender* sender = new EmailSender;
	SuperMessage msg(sender, "Title", "Body", 10);
	msg.Send();
}