#include <iostream>
#include <Windows.h>
#include <conio.h>
#include <cstdlib>
#include <ctime>
#include <iomanip>

using namespace std;

void SetColor(int text, int background);
void GotoXY(int X, int Y);

int main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	SetColor(15, 0);

	const int size = 10;
	_LONGLONG x, k, sum = 0, j1, i1, sum1 = 0, amount[size] = {};

	//Ввод данных
	do {
		cout << "Введите количество роботов, прилетевших на планету(больше 3): ";
		cin >> x;
	} while (x < 3);
	do {
		cout << "Введите количество лет(1-10 включительно): ";
		cin >> k;
	} while (k < 1 || k > 10);
	//Записываем роботов, прилетевших на планету, как первых собранных, для дальнейшего списывания через 3 года
	amount[0] = x;
	//Вывод статистикти
	system("cls");
	cout << "-------------------------------------------------------------------------------\n";
	cout << "Количество роботов, прилетевших на планету: " << x << "\n";
	cout << "-------------------------------------------------------------------------------\n";
	cout << "Количество лет, которые роботы будут производиться: " << k << "\n";
	cout << "-------------------------------------------------------------------------------\n";
	GotoXY(0, 6);
	cout << "                                   Статистика                                  \n";
	//Распределение роботов по группам с максимальной выгодой
	for (int year = 0, r = 0; year < k; year++, r += 6) {
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
		//Записываем результаты в массив, чтобы потом использовать их для списывания роботов спустя 3 года
		amount[year + 1] = sum1;
		//Рисуем таблицу для статистики
		GotoXY(0, 7);
		cout << "-------------------------------------------------------------------------------";
		GotoXY(16, 8);
		cout << "Год: ";
		GotoXY(22 + r, 8);
		cout << year + 1;
		GotoXY(0, 9);
		cout << "-------------------------------------------------------------------------------";
		GotoXY(0, 11);
		cout << "Кол-во роботов в\nначале года";
		GotoXY(0, 14);
		cout << "Групп из 3 роботов";
		GotoXY(0, 16);
		cout << "Групп из 5 роботов";
		GotoXY(0, 18);
		cout << "Новых роботов в\nэтом году";
		GotoXY(0, 21);
		cout << "Списанных роботов в\nэтом году";
		GotoXY(0, 24);
		cout << "Осталось роботов в\nэтом году";
		for (int i = 0; i <= 14; i++) {
			GotoXY(20, 11 + i);
			cout << "|";
		}

		GotoXY(22 + r, 11);
		cout << x; //Количество роботов в начале года
		GotoXY(22 + r, 14);
		cout << i1; //Количество групп роботов по 3 робота
		GotoXY(22 + r, 16);
		cout << j1; //Количество групп роботов по 5 роботов
		GotoXY(22 + r, 18);
		cout << i1 * 5 + j1 * 9; //Количесто новых роботов в этом году
		GotoXY(22 + r, 21);
		(year >= 2) ? cout << amount[year - 2] : cout << "0"; //Начинаем списывать роботов, которым уже 3 года, если количество лет больше или равно 3
		GotoXY(22 + r, 24);
		x += i1 * 5 + j1 * 9;
		if (year >= 2) x -= amount[year - 2];
		cout << x;  //Всего роботов по окончанию года		
	}

	GotoXY(0, 26);
	return 0;
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