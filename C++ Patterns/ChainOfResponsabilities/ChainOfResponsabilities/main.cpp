#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h>
#include <string>
#include <map>
#include "header.h"

using namespace std;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));

	Handler500* h500 = new Handler500(100);
	Handler200* h200 = new Handler200(200);
	Handler100* h100 = new Handler100(1000);
	Handler50* h50 = new Handler50(500);
	Handler20* h20 = new Handler20(2);

	h500->SetHandler(h200);
	h200->SetHandler(h100);
	h100->SetHandler(h50);
	h50->SetHandler(h20);
	h20->SetHandler();

	Request rq(1130);
	h500->HandleRequest(&rq);
	rq.Show();

}