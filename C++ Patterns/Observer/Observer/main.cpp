#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h>
#include <vector>
#include <algorithm>
#include <string>
#include "header.h"

using namespace std;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));
	RealShop shop1("Shop1");
	RealShop shop2("Shop2");
	RealShop shop3("Shop3");
	RealShop shop4("Shop4");

	Product product1("Product1", 1000);
	Product product2("Product2", 2000);
	Product product3("Product3", 3000);
	Product product4("Product4", 4000);
	product1.Subscribe(&shop1);
	product2.Subscribe(&shop1);
	product3.Subscribe(&shop1);
	product4.Subscribe(&shop1);

	product1.Subscribe(&shop2);
	product2.Subscribe(&shop2);
	product3.Subscribe(&shop2);
	product4.Subscribe(&shop2);

	product1.Subscribe(&shop3);
	product2.Subscribe(&shop3);
	product3.Subscribe(&shop3);
	product4.Subscribe(&shop3);

	product1.Subscribe(&shop4);
	product2.Subscribe(&shop4);
	product3.Subscribe(&shop4);
	product4.Subscribe(&shop4);
	
	product1.ChangePrice(500);
	product2.ChangePrice(100);
	product1.Unsubscribe(&shop4);
	product1.NotifyAll();
	product2.NotifyAll();

}