#include <iostream>
#include <Windows.h>
#include <conio.h>
#include <string.h>
#include <stdio.h>
#include <cstdlib>
#include <ctime>
#include <iomanip>

using namespace std;

struct computer {
	unsigned : 2;
	unsigned atx : 1;
	unsigned video : 1;
	unsigned sound : 1;
	unsigned battery : 1;
	unsigned om : 1;
	unsigned usb : 1;
	unsigned hdd;
};

struct students {
	char surname[16];
	short group;
	unsigned session : 1;
};

void SetColor(int text, int background);
void GotoXY(int X, int Y);

char *check_error(unsigned t) {
	char *status;
	if (t == 0) {
		status = "Ок\n";
	}
	else {
		status = "Ошибка!\n";
	}
	return status;
}

void input(students stud[], short x = 15) {
	stud[0] = { "Горелов" };
	stud[1] = { "Николаев" };
	stud[2] = { "Алексеев" };
	stud[3] = { "Новиков" };
	stud[4] = { "Федоров" };
	stud[5] = { "Смирнов" };
	stud[6] = { "Захаров" };
	stud[7] = { "Зайцев" };
	stud[8] = { "Соловьев" };
	stud[9] = { "Павлов" };
	stud[10] = { "Семенов" };
	stud[11] = { "Егоров" };
	stud[12] = { "Маркин" };
	stud[13] = { "Большаков" };
	stud[14] = { "Федосеев" };
	for (int i = 0; i < x; i++) {
		stud[i].group = rand() % 3 + 1;
		stud[i].session = rand() % 2;
	}
}

void _0(students stud[], short x = 15) {
	int o;
	for (int j = 1; j <= 3; j++) {
		o = 0;
		for (int i = 0; i < x; i++) {
			if (stud[i].group == j) o++;
		}
		if (o > 0) {
			printf("2.ДОЛЖНИКИ(ГРУППА %d)\n==========================================================================================\n", j);
			printf("%20s\tСДАЧА ЗАЧЕТОВ\n==========================================================================================\n", "ФАМИЛИЯ");
			for (int i = 0; i < x; i++) {
				if (stud[i].session == 1 && stud[i].group == j) printf("%20s\t%2d\n", stud[i].surname, stud[i].session);
			}
			printf("==========================================================================================\n");
		}
	}
}

void output(students stud[], short x = 15) {
	printf("%20s\tГРУППА\tСДАЧА ЗАЧЕТОВ\n==========================================================================================\n", "ФАМИЛИЯ");
	for (int i = 0; i < x; i++) {
		printf("%20s\t%2d\t%2d\n", stud[i].surname, stud[i].group, stud[i].session);
	}
	printf("==========================================================================================\n");
}

void sort(students stud[], short x = 15) {
	int j = 1;
	students temp;
	while (j > 0) {
		j = 0;
		for (int i = 0; i < x - 1; i++) {
			if (stud[i].surname[0] > stud[i + 1].surname[0]) {
				temp = stud[i];
				stud[i] = stud[i + 1];
				stud[i + 1] = temp;
				j++;
			}
		}
	}
}

void main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	SetColor(15, 0);
	srand(time(NULL));
	short en = 0, y = 1;
	do {
		if (en == 80) {
			y++;
			if (y == 4) y = 0;
		}
		if (en == 72) {
			y--;
			if (y == 0) y = 3;
		}
		if (en == 13) {
			switch (y) {
			case 1: {
				system("cls");
				computer comp = { 1, 1, 0, 1, 0, 1, 1 };
				printf("СОСТОЯНИЕ КОМПЬЮТЕРА\n");
				printf("ATX: %s", check_error(comp.atx));
				printf("Видеокарта: %s", check_error(comp.atx));
				printf("Звуковая карта: %s", check_error(comp.sound));
				printf("Батарея: %s", check_error(comp.battery));
				printf("Оперативная память: %s", check_error(comp.om));
				printf("USB-порты: %s", check_error(comp.usb));
				printf("HDD: %s", check_error(comp.hdd));
				printf("Нажмите любую клавишу, чтобы перейти в главное меню...\n");
				getch();
				break;
			}
			case 2: {
				system("cls");
				students stud[15];
				input(stud);
				printf("==========================================================================================\n");
				printf("СПИСОК СТУДЕНТОВ\n==========================================================================================\n");
				output(stud);
				printf("1.СДАВШИЕ ЭКЗАМЕН\n==========================================================================================\n");
				printf("%20s\tГРУППА\tСДАЧА ЗАЧЕТОВ\n==========================================================================================\n", "ФАМИЛИЯ");
				for (int i = 0; i < 15; i++) {
					if (stud[i].session == 0) printf("%20s\t%2d\t%2d\n", stud[i].surname, stud[i].group, stud[i].session);
				}
				printf("==========================================================================================\n");
				_0(stud);
				sort(stud);
				printf("3.В АЛФАВИТНОМ ПОРЯДКЕ\n");
				printf("==========================================================================================\n");
				output(stud);
				printf("Нажмите любую клавишу, чтобы перейти в главное меню...\n");
				getch();
				break;
			}
			default:
				exit(0);
				break;
			}
		}
		system("cls");
		if (y == 1) SetColor(10, 0);
		printf("Конфигурация компьютера\n");
		SetColor(15, 0);
		if (y == 2) SetColor(10, 0);
		printf("Учет сдачи билетов\n");
		SetColor(15, 0);
		if (y == 3) SetColor(10, 0);
		printf("Выход\n");
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