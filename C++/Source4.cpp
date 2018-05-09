#include <iostream>
#include <iomanip>
#include <windows.h> 

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
	setlocale(LC_ALL, "rus");

	//Задание 1

	/*int i, b, c, x = 0, y = 1, r = 0;
	for (i = 1000; i <= 9999; i++) {
	b = (i / 1000) + (i / 100 % 10);
	c = (i / 10 % 10) + (i % 10);
	if (b == c) {
	while (r < 80) {
	GotoXY(r, 0);
	cout << "n (sum)";
	r += 10;
	}
	GotoXY(x, y);
	cout << i << "(" << b << ")" << endl;
	x += 10;
	if (x == 80) {
	y++;
	x = 0;
	}
	}
	}*/

	//Задание 2

	/*int d;
	float z, sum = 0;
	cout << "Введите тариф $/час (не больше 10): ";
	cin >> z;
	z = z * 8 * 0.7;
	for (d = 1; sum < 5000; d++) {
	sum += z;
	}
	cout << "Работник заработает на автомобиль за $5000 за:\nлет\t- " << d / 22 / 12 << "\nмесяцев\t- " << (d / 22) - (d / 22 / 12 * 12) << endl;*/
	
	//Задание 3

	/*int x = 5, y = 4, r;
	GotoXY(7, 0);
	cout << "x кратно 3";
	GotoXY(26, 0);
	cout << "|";
	GotoXY(33, 0);
	cout << "x кратно 5";
	GotoXY(0, 1);
	cout << "---------------------------------------------------";
	GotoXY(7, 2);
	cout << "y = 3 * (x - x * 2)";
	GotoXY(26, 2);
	cout << "|";
	GotoXY(33, 2);
	cout << "y = 2 * x - 10";
	GotoXY(0, 3);
	cout << "---------------------------------------------------";
	for (x; x <= 50; x++) {
	if (x % 3 == 0) {
	GotoXY(7, y);
	r = 3 * (x - x * 2);
	cout << "x = " << x << " y = " << r;
	}
	if (x % 5 == 0) {
	GotoXY(33, y);
	r = 2 * x - 10;
	cout << "x = " << x << " y = " << r << endl;
	}
	GotoXY(26, y);
	cout << "|" << endl;
	y++;
	}*/

	//Задание 4

	/*int stage = 1;
	float i, sum = 0;
	for (i = 10; sum < 300; i *= 1.5) {
	sum += i;
	stage++;
	cout << "За " << int(sum / 60) % 60 << " минут " << int(sum) % 60 << " секунд человек подымется на " << stage << " этаж.\n";
	}
	SetColor(10, 0);
	cout << "\nЗа 5 минут человек подымется на " << stage << " этаж.\n\n";
	SetColor(15, 0);
	i = 10;
	sum = 0;
	for (stage = 1; stage < 20; stage++) {
	sum += i;
	cout << "Человек подымется до " << stage+1 << " этажа за " << int(i / 3600) << " часов " << int(i / 60) % 60 << " минут " << int(i) % 60 << " секунд. Всего: " << int(sum / 3600) << " часов " << int(sum / 60) % 60 << " минут " << int(sum) % 60 << " секунд\n";
	i *= 1.5;
	}
	SetColor(10, 0);
	cout << "\nЧеловек подымется до 20 этажа за " << int(sum / 3600) << " часов " << int(sum / 60) % 60 << " минут " << int(sum) % 60 << " секунд\n";
	SetColor(15, 0);*/

	//задание 5

	/*float ivanov = 50, petrov = 50;
	double iv = 0.1, pet = 0.05;
	int i = 0;
	for (i = 1; petrov <= ivanov; i++) {
	petrov += petrov * 0.05;
	ivanov += 50 * 0.1;
	cout << "На " << i << " месяц вклад Иванова составил " << ivanov << "$, ";
	cout << "а вклад Петрова составил " << petrov << "$" << endl;
	}
	SetColor(10, 0);
	cout << "\nНа " << i << " месяц вклад Петрова превысит вклад Иванова.\n\n";
	SetColor(15, 0);*/

}
