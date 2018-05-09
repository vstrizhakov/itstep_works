#include <iostream>
#include <Windows.h>
#include <conio.h>
#include <cstdlib>
#include <ctime>
#include <iomanip>

using namespace std;

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
void main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	SetColor(15, 0);
	/*for (int x = 0; x < 10; x++) {
		for (int y = 0; y < 20; y++) {
			for (int z = 0; z < 200; z++) {
				if (x + y + z == 100 && x * 20 + y * 10 + z == 200) cout << "x " << x << " y " << y << " z " << z << endl;
			}
		}
	}*/
	_LONGLONG x, k, sum = 0, j1, i1, sum1 = 0;
	const int size = 10;
	_LONGLONG amount[size] = {};
	do {
		cout << "Введите количество роботов, прилетевших на планету(больше 3): ";
		cin >> x;
	} while (x < 3);
	do {
		cout << "Введите количество лет(1-10 включительно): ";
		cin >> k;
	} while (k < 1 || k > 10);
	system("cls");
	cout << "-------------------------------------------------------------------------------\n";
	cout << "                                   Статистика                                  \n";
	cout << "-------------------------------------------------------------------------------\n";
	cout << "-------------------------------------------------------------------------------\n";
	cout << "Количество роботов, прилетевших на планету: " << x << "\n";
	cout << "-------------------------------------------------------------------------------\n";
	cout << "Количество лет, которые роботы будут производиться: " << k << "\n";
	cout << "-------------------------------------------------------------------------------\n";
	amount[0] = x;
	for (int year = 0, r = 0; year < k; year++, r += 5) {
		for (int j = 0; j < x; j++) {
			for (int i = 0; i < x; i++) {
				sum = j * 9 + i * 5;
				if (x - (j * 5 + i * 3) < 3 && x - (j * 5 + i * 3) >= 0 && j * 9 + i * 5 >= sum1) {
					j1 = j;
					i1 = i;
					sum1 = j * 9 + i * 5;
				}

			}
		}
		amount[year + 1] = sum1;

		GotoXY(0, 9);
		cout << "-------------------------------------------------------------------------------";
		GotoXY(27, 10);
		cout << "Год: ";
		for (int i = 0, p = 0; i < k; i++, p += 5) {
			GotoXY(35 + p, 10);
			cout << i + 1;
		}
		GotoXY(0, 11);
		cout << "-------------------------------------------------------------------------------";
		GotoXY(0, 12);
		cout << "Кол-во роботов в начале года:";
		GotoXY(0, 14);
		cout << "Групп из 3 роботов:";
		GotoXY(0, 16);
		cout << "Групп из 5 роботов:";
		GotoXY(0, 18);
		cout << "Новых роботов в этом году:";
		GotoXY(0, 20);
		cout << "Списанных роботов в этом году:";
		GotoXY(0, 22);
		cout << "Осталось роботов в этом году:";
		for (int i = 0; i <= 10; i += 2) {
			GotoXY(31, 12 + i);
			cout << "|";
		}
		GotoXY(35 + r, 12);
		cout << x;
		GotoXY(35 + r, 14);
		cout << i1;
		GotoXY(35 + r, 16);
		cout << j1;
		GotoXY(35 + r, 18);
		cout << i1 * 5 + j1 * 9;
		GotoXY(35 + r, 20);
		(year >= 2) ? cout << amount[year - 2] : cout << "0";
		GotoXY(35 + r, 22);
		x += i1 * 5 + j1 * 9;
		if (year >= 2) x -= amount[year - 2];
		cout << x;

		GotoXY(0, 24);
	}
}