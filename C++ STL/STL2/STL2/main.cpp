#include <iostream>
#include <Windows.h>
#include <iomanip>
#include <ctime>
#include <algorithm>
#include <vector>
#include <numeric>

using namespace std;

class MySort
{
public:
	bool operator()(int& a)
	{
		return a % 5 == 0;
	}
};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));

	vector<int> v;
	for (int i = 0; i < 1000; i++)
		v.push_back(rand() % 1000);
	vector<int>::iterator it;
	it = v.begin();
	MySort ms;
	it = find_if(it, v.end(), ms);
	if (it != v.end())
	{
		cout << *it << endl;
	}
	int c1 = 0;
	c1 = count_if(v.begin(), v.end(), ms);
	cout << c1 << endl;
	int sum = accumulate(v.begin(), v.end(), 0);
	
	return 0;
}