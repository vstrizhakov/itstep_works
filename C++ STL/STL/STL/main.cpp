#include <iostream>
#include <Windows.h>
#include <iomanip>
#include <ctime>
#include <algorithm>
#include <vector>

using namespace std;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));

	vector<int> v1;
	for (int i = 0; i < 10; i++)
	{
		//Не все коллекции STL допускают обращение через индекс
		v1.push_back(i);
	}
	v1.resize(15);
	for (int i = 10; i < 15; i++)
	{
		//v1[i] = 555;
		v1.push_back(555);
	}
	for (int i = 0; i < v1.size(); i++)
	{
		cout << v1[i] << "  ";
	}
	cout << endl;
	vector<int>::iterator it;
	for (it = v1.begin(); it < v1.end(); it++)
	{
		cout << *it << " ";
	}
	vector<int>::iterator it1;
	it = v1.begin();
	it1 = it + 5;
	for (it; it < it1; it++)
	{
		cout << *it << " ";
	}
	cout << endl;
	vector<int>::reverse_iterator rit;
	for (rit = v1.rbegin(); rit < v1.rend(); rit++)
	{
		cout << *rit << " ";
	}
	cout << endl << endl;
	/*while (!v1.empty())
	{
		cout << v1[v1.size() - 1] << " ";
		v1.pop_back();		
	}
	cout << v1.size();*/
	v1.erase(v1.begin() + 5);
	for (rit = v1.rbegin(); rit < v1.rend(); rit++)
	{
		cout << *rit << " ";
	}
	cout << endl << endl;
	return 0;
}