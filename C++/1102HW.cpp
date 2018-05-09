#include <iostream>
#include <Windows.h>
#include <conio.h>
#include <cstdlib>
#include <ctime>

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

int f(int *x) {
	if (*x > 1) {
		int x2 = *x - 1;
		int *ix2 = &x2;
		*x = *x*f(ix2);
	}
	return *x;
}

double to_grade(double *n, int *s) {
	double sum = *n;
	double *isum = &sum;
	if (*s > 1) {
		int s2 = *s - 1;
		int *is2 = &s2;
		*isum *= to_grade(n, is2);
	}
	return *isum;
}

void check(double *a, double *b) {
	if (*a == 0) cout << "Делить на ноль нельзя!" << endl;
	else if (*b == 0) cout << "Делить на ноль нельзя!" << endl;
	else cout << *a << " / " << *b << " = " <<  *a / *b << endl;
}

void main() {
	system("cls");
	SetColor(15, 0);
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));

	short en = 0, k = 1;
	do {
		if (en == 80) {
			k++;
			if (k == 7) k = 1;
		}
		if (en == 72) {
			k--;
			if (k == 0) k = 6;
		}
		if (en == 13) {
			char sel;
			switch (k) {
			case 1: {
				do {
					system("cls");
					cout << "-------------------------------------------------------------------------------\n";
					cout << "Сумма двух чисел\n";
					cout << "-------------------------------------------------------------------------------\n";
					double a = 0, b = 0;
					double *ia = &a, *ib = &b;
					double *iia = ia, *iib = ib;
					cout << "Введите первое число: ";
					cin >> *ia;
					cout << "Введите второе число: ";
					cin >> *ib;
					double c = *ia + *ib;
					double *ic = &c;
					double *iic = ic;
					cout << "Сумма чисел " << *iia << " и " << *iib << " равна " << *iic;
					cout << endl << "Хотите выполнить данную программу еще раз?\n1 - Да\tЛюбой другой символ - Выйти в главное меню\nВаш выбор: ";
					cin >> sel;
				} while (sel == '1');
			}
					break;
			case 2: {
				do {
					system("cls");
					cout << "-------------------------------------------------------------------------------\n";
					cout << "Калькулятор\n";
					cout << "-------------------------------------------------------------------------------\n";
					double a = 0, b = 0;
					double *ia = &a, *ib = &b;
					char sym;
					char *isym = &sym;
					cout << "Введите первое число: ";
					cin >> *ia;
					do {
						cout << "Введите операцию(+ или - или * или /): ";
						cin >> *isym;
					} while (sym != '+' && sym != '-' && sym != '*' && sym != '/');
					cout << "Введите второе число: ";
					cin >> *ib;					
					double c;
					double *ic = &c;
					switch (*isym) {
					case '+':
						*ic = *ia + *ib;
						break;
					case '-':
						*ic = *ia - *ib;
						break;
					case '*':
						*ic = *ia * *ib;
						break;
					case '/':
						*ic = *ia / *ib;
						break;
					}					
					cout << "Ответ: " << *ic;
						
					cout << endl << "Хотите выполнить данную программу еще раз?\n1 - Да\tЛюбой другой символ - Выйти в главное меню\nВаш выбор: ";
					cin >> sel;
				} while (sel == '1');
			}
					break;
			case 3: {
				do {
					system("cls");
					cout << "-------------------------------------------------------------------------------\n";
					cout << "Факториал числа\n";
					cout << "-------------------------------------------------------------------------------\n";
					int x;
					int *ix = &x;
					cout << "Введите число: ";
					cin >> *ix;
					cout << "Факториал данного числа равен " << f(ix) << endl;
					cout << endl << "Хотите выполнить данную программу еще раз?\n1 - Да\tЛюбой другой символ - Выйти в главное меню\nВаш выбор: ";
					cin >> sel;
				} while (sel == '1');
			}
					break;
			case 4: {
				do {
					system("cls");
					cout << "-------------------------------------------------------------------------------\n";
					cout << " Cтепень числа\n";
					cout << "-------------------------------------------------------------------------------\n";
					double x;
					int g;
					double *ix = &x;
					int *ig = &g;
					cout << "Введите число: ";
					cin >> *ix;
					cout << "Введите степень, в которую нужно возвести чило: ";
					cin >> *ig;
					cout << "Число " << *ix << " в степени " << *ig << " равно " << to_grade(ix, ig);
					cout << endl << "Хотите выполнить данную программу еще раз?\n1 - Да\tЛюбой другой символ - Выйти в главное меню\nВаш выбор: ";
					cin >> sel;
				} while (sel == '1');
			}
					break;
			case 5: {
				do {
					system("cls");
					cout << "-------------------------------------------------------------------------------\n";
					cout << "Произвести проверку на нуль при делении\n";
					cout << "-------------------------------------------------------------------------------\n";
					double a, b;
					double *ia = &a, *ib = &b;
					cout << "Введите первое число: ";
					cin >> *ia;
					cout << "Введите второе число: ";
					cin >> *ib;
					check(ia, ib);
					cout << endl << "Хотите выполнить данную программу еще раз?\n1 - Да\tЛюбой другой символ - Выйти в главное меню\nВаш выбор: ";
					cin >> sel;
				} while (sel == '1');
			}
					break;
			default:
				exit(0);
				break;
			}
		}
		system("cls");
		cout << "-------------------------------------------------------------------------------\n";
		if (k == 1) SetColor(10, 0);
		cout << "Программа №1\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------\n";
		if (k == 2) SetColor(10, 0);
		cout << "Программа №2\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------\n";
		if (k == 3) SetColor(10, 0);
		cout << "Программа №3\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------\n";
		if (k == 4) SetColor(10, 0);
		cout << "Программа №4\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------\n";
		if (k == 5) SetColor(10, 0);
		cout << "Программа №5\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------\n";
		if (k == 6) SetColor(10, 0);
		cout << "Выход из программы\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------\n";
	} while (en = getch());
}
