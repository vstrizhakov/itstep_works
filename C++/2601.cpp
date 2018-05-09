#include <iostream>
#include <Windows.h>
#include <conio.h>
#include <cstdlib>

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

void create_array(_LONGLONG arr[][10], int size, int size2, _LONGLONG input, int j, int i, int kind, int p) {
	arr[j][i] = input;
	if (kind == 1) {
		input = input * 2;
	}
	else {
		
		input = input + p;
		p++;
	}
	i++;
	if (i == size) {
		j++;
		i = 0;
	}
	if (j < size2 && i < size) create_array(arr, size, size2, input, j, i, kind, p);
}

void print_array(_LONGLONG arr[][10], int size, int size2) {
	for (int j = 0; j < size2; j++) {
		for (int i = 0; i < size; i++) {
			cout << arr[j][i] << "  ";
		}
		cout << endl;
	}
}

void main() {
	system("cls");
	SetColor(15, 0);
	setlocale(LC_ALL, "rus");

	short en = 0, k = 1;
	do {
		if (en == 80) {
			k++;
			if (k == 4) k = 1;
		}
		if (en == 72) {
			k--;
			if (k == 0) k = 3;
		}
		if (en == 13) {
			switch (k) {
			case 1: {
			S1:
				system("cls");
				int j = 0, i = 0, x;
				const int size = 10;
				_LONGLONG number[size][size] = {};
				do {
					cout << "\nВведите количество строк(1-10 включительно): ";
					cin >> j;
				} while (j < 1 || j > 10);
				do {
					cout << "\nВведите количество столбцов(1-10 включительно): ";
					cin >> i;
				} while (i < 1 || i > 10);
				cout << "\nВведите первоначальное значение: ";
				cin >> x;
				cout << endl;
				create_array(number, i, j, x, 0, 0, 1, 1);
				print_array(number, i, j);

				cout << endl << "Хотите выполнить данную программу еще раз?\n1 - Да\tЛюбой другой символ - Выйти в главное меню\nВаш выбор: ";
				char sel;
				cin >> sel;
				if (sel == '1') {
					goto S1;
				}
			}
					break;
			case 2: {
			S2:
				system("cls");
				int j = 0, i = 0, x;
				const int size = 10;
				_LONGLONG number[size][size] = {};
				do {
					cout << "\nВведите количество строк(1-10 включительно): ";
					cin >> j;
				} while (j < 1 || j > 10);
				do {
					cout << "\nВведите количество столбцов(1-10 включительно): ";
					cin >> i;
				} while (i < 1 || i > 10);
				cout << "\nВведите первоначальное значение: ";
				cin >> x;
				cout << endl;
				create_array(number, i, j, x, 0, 0, 2, 1);
				print_array(number, i, j);

				cout << endl << "Хотите выполнить данную программу еще раз?\n1 - Да\tЛюбой другой символ - Выйти в главное меню\nВаш выбор: ";
				char sel;
				cin >> sel;
				if (sel == '1') {
					goto S2;
				}
			}
					break;
			case 3:
				exit(0);
				break;
			}
		}
		system("cls");
		cout << "-------------------------------------------------------------------------------";
		if (k == 1) SetColor(10, 0);
		cout << "\nПрограмма №1\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------";
		if (k == 2) SetColor(10, 0);
		cout << "\nПрограмма №2\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------";
		if (k == 3) SetColor(10, 0);
		cout << "\nВыход из программы\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------";
	} while (en = getch());
}
