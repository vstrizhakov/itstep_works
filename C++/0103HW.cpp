#include <iostream>
#include <Windows.h>
#include <conio.h>
#include <stdio.h>
#include <cstdlib>
#include <iomanip>

using namespace std;

void SetColor(int text, int background);
void GotoXY(int X, int Y);

void cut_string(char *arr1, char *arr2, int size1, int size2) {
	int i = 0, j = 0;
	for (i = size1 - 1, j = 0; i < size2; i++, j++) {
		strcpy(arr2 + j, arr1 + i);
	}
	strcpy(arr2 + j, '\0');
}

void check_fail() {
	if (cin.fail()) {
		cin.clear();
		cin.ignore(cin.rdbuf()->in_avail());
	}
}

void search_all(char *str, char sym) {
	int q = 0;
	for (int i = 0; i < strlen(str); i++) {
		if (str[i] == sym) {
			q++;
			if (q == 1) cout << "Индексы всех совпадений: ";
			cout << i + 1 << " ";			
		}
		if (i == strlen(str) - 1) cout << endl;
	}
	if (q == 0) cout << "Совпадений не найдено." << endl;
}

void search(char *str, char sym) {
	int q = 0, i;
	for (i = 0; i < strlen(str); i++) {
		if (str[i] == sym) {
			q = i;
		}
	}
	if (q == 0) cout << "Совпадений не найдено." << endl;
	else cout << "Индекс последнего совпадения: " << q + 1 << endl;
}

void main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	SetColor(15, 0);
	srand(time(NULL));

	char string[129];
	cout << "---------------------------------------------------------------------------------------------------\n";
	cout << "Задание 1\n";
	cout << "---------------------------------------------------------------------------------------------------\n";
	cout << "Введите строку(до 128 символов): ";
	cin.getline(string, 129);
	cout << "Свободно символов в массиве: " << 128 - strlen(string) << endl;
	cout << "Занято символов в массиве: " << strlen(string) << endl;
	cout << "---------------------------------------------------------------------------------------------------\n";
	cout << "Задание 2\n";
	cout << "---------------------------------------------------------------------------------------------------\n";
	int x1, x2;
	do {
		cout << "Введите, с какого символа строки записать отрезок(1-" << strlen(string) << "): ";
		cin >> x1;
		check_fail();
		cin.ignore();
	} while (x1 < 1 || x1 > strlen(string));
	do {
		cout << "Введите, по какой символ строки записать отрезок(" << x1 << "-" << strlen(string) << "): ";
		cin >> x2;
		check_fail();
		cin.ignore();
	} while (x2 < x1 || x2 > strlen(string));
	char *string2 = new char[x2 - x1 + 2];
	strncpy(string2, string + x1 - 1, x2 - 1);
	*(string2 + x2 - 1) = '\0';
	cout << "Строка с " << x1 << "-го по " << x2 << "-й символ: " << string2 << endl;
	delete[] string2;
	string2 = nullptr;
	cout << "---------------------------------------------------------------------------------------------------\n";
	cout << "Задание 3\n";
	cout << "---------------------------------------------------------------------------------------------------\n";
	char *string4 = new char[x1 + strlen(string) - x2 + 1];
	char *string3 = new char[strlen(string) - x2 + 1];
	strncpy(string4, string, x1 - 1);
	*(string4 + x1 - 1) = '\0';
	strncpy(string3, string + x2, strlen(string) - x2 + 1);
	strcat(string4, string3);
	cout << "Строка без символов с " << x1 << "-го по " << x2 << "-й символ: " << string4 << endl;
	delete[] string4;
	delete[] string3;
	string4 = nullptr;
	string3 = nullptr;
	cout << "---------------------------------------------------------------------------------------------------\n";
	cout << "Задание 4\n";
	cout << "---------------------------------------------------------------------------------------------------\n";
	char key;
	for (int i = 0; i < 129; i++) {
		string[i] = NULL;
	}
	cout << "Введите строку: ";
	cin.getline(string, 100);
	cout << "Введите символ, который нужно искать: ";
	cin >> key;
	cin.ignore();
	search_all(string, key);
	cout << "---------------------------------------------------------------------------------------------------\n";
	cout << "Задание 5\n";
	cout << "---------------------------------------------------------------------------------------------------\n";
	for (int i = 0; i < 129; i++) {
		string[i] = NULL;
	}
	cout << "Введите строку: ";
	cin.getline(string, 100);
	cout << "Введите символ, который нужно искать: ";
	cin >> key;
	cin.ignore();
	search(string, key);
}

enum ConsoleColor {
	Black, Blue, Green, Cyan, Red, Magenta, Brown, LightGray, DarkGray,
	LightBlue, LightGreen, LightCyan, LightRed, LightMagenta, Yellow, White
};

void SetColor(int text, int background) {
	HANDLE hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(hStdOut, (WORD)((background << 4) | text));
}

void GotoXY(int X, int Y) {
	HANDLE hConsole;
	HANDLE hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
	COORD coord = { X, Y };
	SetConsoleCursorPosition(hStdOut, coord);
}