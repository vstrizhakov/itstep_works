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

struct timer {
	unsigned hh : 5;
	unsigned mm : 6;
	unsigned ss : 6;
};

void show_timer(timer & T) {
	(T.hh >= 10) ? cout << T.hh : cout << "0" << T.hh;
	cout << ":";
	(T.mm >= 10) ? cout << T.mm : cout << "0" << T.mm;
	cout << ":";
	(T.ss >= 10) ? cout << T.ss : cout << "0" << T.ss;
	cout << endl;
}

void reset_timer(timer & T, int x) {
	T.hh = x;
	if (x == 0) {
		T.ss = x;
		T.mm = x;
	}
	else {
		T.ss = 0;
		T.mm = 0;
	}
}

void inc_timer(timer & T) {
	T.ss++;
	if (T.ss == 60) {
		T.ss = 0;
		T.mm++;
		if (T.mm == 60) {
			T.mm = 0;
			T.hh++;
			if (T.hh == 24) {
				reset_timer(T, 0);
			}
		}
	}
}

void dec_timer(timer & T) {
	if (T.ss == 0) {
		T.ss = 59;
		if (T.mm == 0) {
			T.mm = 59;
			if (T.hh == 0) {
				reset_timer(T, 24);
			}
			else T.hh--;
		}
		else T.mm--;
	}
	else T.ss--;
}


void main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	SetColor(15, 0);
	srand(time(NULL));

	timer timeh = {};

	short k = 1;
	char en = 0;
	short shh, smm, sss, fhh, fmm, fss;
	do {
		if (en == 80) {
			k++;
			if (k == 3) k = 1;
		}
		if (en == 72) {
			k--;
			if (k == 0) k = 2;
		}
		if (en == 13) {
			switch (k) {
			case 1: {
				int i = 0;
				timeh = {};
				do {
					system("cls");
					if (i > 0) {
						SetColor(12, 0);
						cout << "Время, от которого будет идти отсчет должно быть больше, чем время, до которого будет идти отсчет\n";
						SetColor(15, 0);
					}
					cout << "---------------------------------------------------------------------------------------------------\n";
					cout << "Введите время, от которого будет идти отсчет\n";
					cout << "---------------------------------------------------------------------------------------------------\n";
					do {
						cout << "Введите кол-во часов(0-24): ";
						cin >> shh;
					} while (shh < 0 || shh > 24);
					do {
						cout << "Введите кол-во минут(0-60): ";
						cin >> smm;
					} while (smm < 0 || smm > 60);
					do {
						cout << "Введите кол-во секунд(0-60): ";
						cin >> sss;
					} while (sss < 0 || sss > 60);
					system("cls");
					cout << "---------------------------------------------------------------------------------------------------\n";
					cout << "Введите время, до которого будет идти отсчет\n";
					cout << "---------------------------------------------------------------------------------------------------\n";
					do {
						cout << "Введите кол-во часов(0-24): ";
						cin >> fhh;
					} while (fhh < 0 || fhh > 24);
					do {
						cout << "Введите кол-во минут(0-60): ";
						cin >> fmm;
					} while (fmm < 0 || fmm > 60);
					do {
						cout << "Введите кол-во секунд(0-60): ";
						cin >> fss;
					} while (fss < 0 || fss > 60);
					timeh.hh = shh;
					timeh.mm = smm;
					timeh.ss = sss;
					i++;
				} while ((((timeh.hh * 60) + timeh.mm) * 60) + timeh.ss > (((fhh * 60) + fmm) * 60) + fss);
				while ((((timeh.hh * 60) + timeh.mm) * 60) + timeh.ss < (((fhh * 60) + fmm) * 60) + fss) {
					if (kbhit()) break;
					Sleep(650);
					system("cls");
					inc_timer(timeh);
					show_timer(timeh);
				}
				system("pause");
				break;
			}
			case 2: {
				timeh = {};
				int i = 0;
				do {
					system("cls");
					if (i > 0) {
						SetColor(12, 0);
						cout << "Время, от которого будет идти отсчет должно быть больше, чем время, до которого будет идти отсчет\n";
						SetColor(15, 0);
					}
					cout << "---------------------------------------------------------------------------------------------------\n";
					cout << "Введите время, от которого будет идти отсчет\n";
					cout << "---------------------------------------------------------------------------------------------------\n";
					do {
						cout << "Введите кол-во часов(0-24): ";
						cin >> shh;
					} while (shh < 0 || shh > 24);
					do {
						cout << "Введите кол-во минут(0-60): ";
						cin >> smm;
					} while (smm < 0 || smm > 60);
					do {
						cout << "Введите кол-во секунд(0-60): ";
						cin >> sss;
					} while (sss < 0 || sss > 60);
					system("cls");
					cout << "---------------------------------------------------------------------------------------------------\n";
					cout << "Введите время, до которого будет идти отсчет\n";
					cout << "---------------------------------------------------------------------------------------------------\n";
					do {
						cout << "Введите кол-во часов(0-24): ";
						cin >> fhh;
					} while (fhh < 0 || fhh > 24);
					do {
						cout << "Введите кол-во минут(0-60): ";
						cin >> fmm;
					} while (fmm < 0 || fmm > 60);
					do {
						cout << "Введите кол-во секунд(0-60): ";
						cin >> fss;
					} while (fss < 0 || fss > 60);
					timeh.hh = shh;
					timeh.mm = smm;
					timeh.ss = sss;
					i++;
				} while ((((timeh.hh * 60) + timeh.mm) * 60) + timeh.ss < (((fhh * 60) + fmm) * 60) + fss);
				while ((((timeh.hh * 60) + timeh.mm) * 60) + timeh.ss > (((fhh * 60) + fmm) * 60) + fss) {
					if (kbhit()) break;
					Sleep(650);
					system("cls");
					dec_timer(timeh);
					show_timer(timeh);
				}
				system("pause");
				break;
			}
			}
		}
		system("cls");
		cout << "---------------------------------------------------------------------------------------------------\n";
		cout << "Выберите режим\n";
		cout << "---------------------------------------------------------------------------------------------------\n";
		if (k == 1) SetColor(10, 0);
		cout << " - Секундомер" << endl;
		SetColor(15, 0);
		if (k == 2) SetColor(10, 0);
		cout << " - Таймер" << endl;
		SetColor(15, 0);
	} while (en = getch());


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