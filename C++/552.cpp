#include<iostream>
using namespace std;
void main()
{
	setlocale(LC_ALL, "Russian");
	int a,c;
	char b;
	cout << "������� ���. �������� � ������ � �������" << endl;
	cin >> a;
	cout << "������� ������" << endl;
	cin >> b;
	c = a / 2;
	
	for (int i = 1; i <= c; i++)
	{
		for (int t = 1; t <= i; t++)
		{
					cout << b<<"";
		}
		cout<< endl;

	}
	
	for (int i = 1; i <= c; i++)
	{
		for (int q = c; q >= i; q--)
		{
			cout << b << "";
		}
		cout << endl;
	}
	system("pause");
}




