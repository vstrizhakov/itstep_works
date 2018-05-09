#include "header.h"

using namespace std;

void readFile(char* path)
{
	int i = 0;
	char str[255];
	double d = 0;
	ifstream in(path);
	in >> i;
	in >> str;
	in >> d;
	cout << i << str << d << endl;
	in.close();
}

void readImgBinary(char* path)
{
	char ch;
	ifstream in(path, ios::in | ios::binary);
	while (in.get(ch))
	{
		if (!in.eof()) cout << ch;
	}
	in.close();
}

void copyImgBinary(char* path)
{
	cout << "Copying image from " << path << "..." << endl;
	char ch;
	ifstream in(path, ios::in | ios::binary);
	ofstream out("2.jpg", ios::out | ios::binary);
	while (in.get(ch))
	{
		out.put(ch);
	}
	in.close();
	out.close();
	cout << "Copying finished in 2.jpg" << endl;
}

void main(int num, char *arg[])
{
	setlocale(LC_ALL, "rus");
	srand(time(NULL));
	copyImgBinary("images.jpg");
}