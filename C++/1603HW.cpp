#include <iostream>
#include <Windows.h>
#include <conio.h>
#include <string.h>
#include <stdio.h>
#include <cstdlib>
#include <ctime>
#include <iomanip>	

using namespace std;

struct date {
	int day;
	int month;
	int year;
};

struct person {
	char name[50];
	char adress[20];
	int zipcode;
	int s_number;
	int salary;
	date birthday;
	date hireday;
};

void SetColor(int text, int background);
void GotoXY(int X, int Y);

void main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	SetColor(15, 0);
	enum months { januar, februar, march, april, may, jun, july, august, september, october, november, december };
	person ivan = { "Иван П. И.", "ул. Домодедова 17", 69071, 555555, 3964, 06, march, 1968 };
	person sergey = { "Сергей Г. К.", "ул. Героев 99", 69071, 666666, 74682, 13, januar, 1999 };
	person petya = { "Петя М. Л.", "ул. Домодедова 17", 69071, 777777, 6416, 27, december, 1986 };

	int day, month, year, n_day, n_month, n_year;
	int days[3] = {};
	cout << "---------------------------------------------------------------------------------------------------\n";
	cout << "Дата начала работы Ивана" << endl;
	do {
		cout << "Введите день(1-30): ";
		cin >> ivan.hireday.day;
	} while (ivan.hireday.day > 30 || ivan.hireday.day < 1);
	do {
		cout << "Введите месяц(1-12): ";
		cin >> ivan.hireday.month;
	} while (ivan.hireday.month > 12 || ivan.hireday.month < 1);
	do {
		cout << "Введите год(больше 0): ";
		cin >> ivan.hireday.year;
	} while (ivan.hireday.year < 0);
	cout << "---------------------------------------------------------------------------------------------------\n";
	cout << "Дата начала работы Сергея" << endl;
	do {
		cout << "Введите день(1-30): ";
		cin >> sergey.hireday.day;
	} while (sergey.hireday.day > 30 || sergey.hireday.day < 1);
	do {
		cout << "Введите месяц(1-12): ";
		cin >> sergey.hireday.month;
	} while (sergey.hireday.month > 12 || sergey.hireday.month < 1);
	do {
		cout << "Введите год(больше 0): ";
		cin >> sergey.hireday.year;
	} while (sergey.hireday.year < 0);
	cout << "---------------------------------------------------------------------------------------------------\n";
	cout << "Дата начала работы Пети" << endl;
	do {
		cout << "Введите день(1-30): ";
		cin >> petya.hireday.day;
	} while (petya.hireday.day > 30 || petya.hireday.day < 1);
	do {
		cout << "Введите месяц(1-12): ";
		cin >> petya.hireday.month;
	} while (petya.hireday.month > 12 || petya.hireday.month < 1);
	do {
		cout << "Введите год(больше 0): ";
		cin >> petya.hireday.year;
	} while (petya.hireday.year < 0);
	cout << "---------------------------------------------------------------------------------------------------\n";
	system("cls");
	int min_year, min_month, min_day;
	int pmonth, imonth, smonth;
	pmonth = (((petya.hireday.year * 12) + petya.hireday.month) * 30) + petya.hireday.day;
	imonth = (((ivan.hireday.year * 12) + ivan.hireday.month) * 30) + ivan.hireday.day;
	smonth = (((sergey.hireday.year * 12) + sergey.hireday.month) * 30) + sergey.hireday.day;
	if (pmonth >= imonth && pmonth >= smonth) {
		min_year = petya.hireday.year;
		min_month = petya.hireday.month;
		min_day = petya.hireday.day;
	}
	if (pmonth <= imonth && imonth >= smonth) {
		min_year = ivan.hireday.year;
		min_month = ivan.hireday.month;
		min_day = ivan.hireday.day;
	}
	if (smonth >= imonth && pmonth <= smonth) {
		min_year = sergey.hireday.year;
		min_month = sergey.hireday.month;
		min_day = sergey.hireday.day;
	}
	cout << "---------------------------------------------------------------------------------------------------\n";
	cout << "Иван работает с " << ivan.hireday.day << "." << ivan.hireday.month << "." << ivan.hireday.year << endl;
	cout << "Сергей работает с " << sergey.hireday.day << "." << sergey.hireday.month << "." << sergey.hireday.year << endl;
	cout << "Петя работает с " << petya.hireday.day << "." << petya.hireday.month << "." << petya.hireday.year << endl;
	cout << "---------------------------------------------------------------------------------------------------\n";
	int i = 2;
	while (i > 0) {
		if (i == 1) cout << "---------------------------------------------------------------------------------------------------\n";
		SetColor(12, 0);
		cout << "ВНИМАНИЕ! Веденная вами дата не может быть меньше " << min_day << "." << min_month << "." << min_year << endl;
		SetColor(15, 0);
		cout << "Введите день: ";
		cin >> n_day;
		cout << "Введите месяц: ";
		cin >> n_month;
		cout << "Введите год: ";
		cin >> n_year;
		if (n_year < min_year) i = 1;
		else if (n_year == min_year) {
			if (n_month < min_month) i = 1;
			else if (n_month == min_month) {
				if (n_day < min_day) i = 1;
				else i = 0;
			}
			else i = 0;
		}
		else i = 0;
	}
	cout << "---------------------------------------------------------------------------------------------------\n";
	//Иван
	day = n_day - ivan.hireday.day;
	year = n_year - ivan.hireday.year;
	month = n_month - (ivan.hireday.month + 1);
	if (day < 0) {
		day = 30 + day;
		month--;
	}
	if (month < 0) {
		month = 12 + month;
		year--;
	}
	cout << "Иван работает " << day << " дней " << month << " месяцев " << year << " лет" << endl;
	days[0] = (((year * 12) + month) * 30) + day;
	//Сергей
	day = n_day - sergey.hireday.day;
	year = n_year - sergey.hireday.year;
	month = n_month - (sergey.hireday.month + 1);
	if (day < 0) {
		day = 30 + day;
		month--;
	}
	if (month < 0) {
		month = 12 + month;
		year--;
	}
	cout << "Сергей работает " << day << " дней " << month << " месяцев " << year << " лет" << endl;
	days[1] = (((year * 12) + month) * 30) + day;
	//Петя
	day = n_day - petya.hireday.day;
	year = n_year - petya.hireday.year;
	month = n_month - (petya.hireday.month + 1);
	if (day < 0) {
		day = 30 + day;
		month--;
	}
	if (month < 0) {
		month = 12 + month;
		year--;
	}
	cout << "Петя работает " << day << " дней " << month << " месяцев " << year << " лет" << endl;
	days[2] = (((year * 12) + month) * 30) + day;
	cout << "---------------------------------------------------------------------------------------------------\n";
	SetColor(10, 0);
	int sum = 0;
	for (int i = 0; i < 3; i++) {
		if (days[i] > days[sum]) sum = i;
	}
	if (days[0] == days[1] && days[0] < days[2]) sum = 3;
	else if (days[0] == days[1] && days[0] > days[2]) sum = 7;
	else if (days[2] == days[1] && days[2] < days[0]) sum = 4;
	else if (days[2] == days[1] && days[2] > days[0]) sum = 8;
	else if (days[0] == days[2] && days[0] < days[1]) sum = 5;
	else if (days[0] == days[2] && days[0] > days[1]) sum = 9;
	else if (days[0] == days[1] && days[1] == days[2]) sum = 6;
	if (sum == 0) cout << "Иван";
	else if (sum == 1) cout << "Сергей";
	else if (sum == 2) cout << "Петя";
	else if (sum == 3) cout << "У Ивана и Сергея одинаковый стаж работы, но он меньше чем у Пети";
	else if (sum == 7) cout << "У Ивана и Сергея одинаковый стаж работы, но он больше чем у Пети";
	else if (sum == 4) cout << "У Сергея и Пети одинаковый стаж работы, но он меньше чем у Ивана";
	else if (sum == 8) cout << "У Сергея и Пети одинаковый стаж работы, но он больше чем у Ивана";
	else if (sum == 5) cout << "У Ивана и Пети одинаковый стаж работы, но он меньше чем у Сергея";
	else if (sum == 9) cout << "У Ивана и Пети одинаковый стаж работы, но он больше чем у Сергея";
	else if (sum == 6) cout << "У Ивана, Сергея и Пети одинаковый стаж работы";
	if (sum >= 0 && sum <= 2) cout << " имеет наибольший стаж работы" << endl;
	if (sum > 2) cout << endl;
	SetColor(15, 0);
	cout << "---------------------------------------------------------------------------------------------------\n";
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