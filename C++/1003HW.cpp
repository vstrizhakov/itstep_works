#include <iostream>
#include <Windows.h>
#include <conio.h>
#include <string.h>
#include <stdio.h>
#include <cstdlib>
#include <ctime>
#include <iomanip>	

using namespace std;

void SetColor(int text, int background);
void GotoXY(int X, int Y);

void sort(char *arr, int size) {
	int temp;
	for (int j = 1; j > 0; ) {
		j = 0;
		for (int i = 0; i < size - 1; i++) {
			if (*(arr + i) > *(arr + i + 1)) {
				temp = *(arr + i);
				*(arr + i) = *(arr + i + 1);
				*(arr + i + 1) = temp;
				j++;
			}
		}
	}
}

void main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	SetColor(15, 0);
	char f1[100], f2[100], f3[100], f4[100], f5[100];
	cout << "Введите первую фамилию: ";
	gets_s(f1);
	cout << "Введите вторую фамилию: ";
	gets_s(f2);
	cout << "Введите третью фамилию: ";
	gets_s(f3);
	cout << "Введите четвертую фамилию: ";
	gets_s(f4);
	cout << "Введите пятую фамилию: ";
	gets_s(f5);
	int sum = 0, f_size[5];
	f_size[0] = strlen(f1);
	f_size[1] = strlen(f2);
	f_size[2] = strlen(f3);
	f_size[3] = strlen(f4);
	f_size[4] = strlen(f5);
	for (int i = 0; i < 5; i++) {
		if (f_size[i] > f_size[sum]) sum = i;
	}
	if ((f_size[0] == f_size[1] && f_size[0] >= f_size[sum]) || (f_size[1] == f_size[2] && f_size[1] >= f_size[sum]) ||
		(f_size[2] == f_size[3] && f_size[2] >= f_size[sum]) || (f_size[3] == f_size[4] && f_size[3] >= f_size[sum]) ||
		(f_size[4] == f_size[0] && f_size[0] >= f_size[sum]) || (f_size[0] == f_size[2] && f_size[0] >= f_size[sum]) ||
		(f_size[0] == f_size[3] && f_size[0] >= f_size[sum]) || (f_size[1] == f_size[3] && f_size[1] >= f_size[sum]) ||
		(f_size[1] == f_size[4] && f_size[1] >= f_size[sum]) || (f_size[2] == f_size[4] && f_size[2] >= f_size[sum])) {
		sum = 5;
	}
	if (sum == 0) cout << "Самая длинная фамилия: " << f1 << endl;
	if (sum == 1) cout << "Самая длинная фамилия: " << f2 << endl;
	if (sum == 2) cout << "Самая длинная фамилия: " << f3 << endl;
	if (sum == 3) cout << "Самая длинная фамилия: " << f4 << endl;
	if (sum == 4) cout << "Самая длинная фамилия: " << f5 << endl;
	if (sum == 5) cout << "Самой длинной фамилии нет" << endl;
	char fsym[5];
	fsym[0] = f1[0];
	fsym[1] = f2[0];
	fsym[2] = f3[0];
	fsym[3] = f4[0];
	fsym[4] = f5[0];
	sort(fsym, 5);
	for (int i = 0; i < 5; i++) {
		cout << i + 1 << ". ";
		if (fsym[i] == f1[0]) cout << f1 << endl;
		else if (fsym[i] == f2[0]) cout << f2 << endl;
		else if (fsym[i] == f3[0]) cout << f3 << endl;
		else if (fsym[i] == f4[0]) cout << f4 << endl;
		else if (fsym[i] == f5[0]) cout << f5 << endl;
	}
	cout << endl;
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