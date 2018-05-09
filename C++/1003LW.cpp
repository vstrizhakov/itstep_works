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

struct shop {
	char category[16];
	char name[16];
	char firm[12];
	double prc;
};

void header() {
	system("cls");
	GotoXY(0, 0);
	cout << "====================================================================================================";
	GotoXY(1, 1);
	cout << "Категория";
	GotoXY(27, 1);
	cout << "|";
	GotoXY(29, 1);
	cout << "Название";
	GotoXY(54, 1);
	cout << "|";
	GotoXY(56, 1);
	cout << "Фирма";
	GotoXY(81, 1);
	cout << "|";
	GotoXY(83, 1);
	cout << "Цена";
	GotoXY(0, 2);
	cout << "====================================================================================================";
}

void foot(short y, short x) {
	GotoXY(0, y + x);
	cout << "====================================================================================================";
	GotoXY(0, y + x + 1);
}

void output(shop *arr, int size) {
	header();
	int i = 0;
	for (i = 3; i < size + 3; i++) {
		GotoXY(1, i);
		cout << (arr + i - 3)->category;
		GotoXY(27, i);
		cout << "|";
		GotoXY(29, i);
		cout << (arr + i - 3)->name;
		GotoXY(54, i);
		cout << "|";
		GotoXY(56, i);
		cout << (arr + i - 3)->firm;
		GotoXY(81, i);
		cout << "|";
		GotoXY(83, i);
		cout << fixed << setprecision(2) << (arr + i - 3)->prc;
	}
	foot(i, 0);
}

void output_certain(shop *arr, int index, int y) {
	GotoXY(1, y);
	cout << (arr + index)->category;
	GotoXY(27, y);
	cout << "|";
	GotoXY(29, y);
	cout << (arr + index)->name;
	GotoXY(54, y);
	cout << "|";
	GotoXY(56, y);
	cout << (arr + index)->firm;
	GotoXY(81, y);
	cout << "|";
	GotoXY(83, y);
	cout << (arr + index)->prc;
}

char *strdup_(char *arr2, int size) {
	char *arr = new char[size];
	int i = 0;
	for (i = 0; i < size; i++) {
		*(arr + i) = *(arr2 + i);
	}
	*(arr + i) = '\0';
	for (int j = 0; j < size; j++) {
		for (int i = 192; i <= 223; i++) {
			if (*(arr + j) == char(i)) *(arr + j) = i + 32;
		}
	}
	for (int j = 0; j < size; j++) {
		for (int i = 65; i <= 90; i++) {
			if (*(arr + j) == char(i)) *(arr + j) = i + 32;
		}
	}
	return arr;
}

void search_name(shop *arr, int size, char *search) {
	char *search_name = strdup_(search, strlen(search)), *name;
	int i = 0, t = 0;
	for (i = 0; i < size; i++) {
		name = strdup_((arr + i)->name, strlen((arr + i)->name));
		if (strcmp(name, search_name) == 0) {
			header();
			output_certain(arr, i, 3);
			t++;
		}
	}
	if (t == 0) {
		system("cls");
		cout << "====================================================================================================";
		cout << "Поиск по названию\n";
		cout << "====================================================================================================";
		cout << "Фильм с таким названием не найден!\n";
		foot(4, 0);
	}
	else foot(4, 0);
}

void search_category(shop *arr, int size, char *search) {
	char *search_name = strdup_(search, strlen(search)), *name;
	short z = 0;
	header();
	int i = 0;
	for (i = 0; i < size; i++) {
		name = strdup_((arr + i)->category, strlen((arr + i)->category));
		if (strcmp(name, search_name) == 0) {
			output_certain(arr, i, 3 + z);
			z++;
		}
	}
	if (z == 0) {
		system("cls");
		cout << "====================================================================================================";
		cout << "Поиск по режиссеру\n";
		cout << "====================================================================================================";
		cout << "Фильм с таким режиссером не найден!\n";
		foot(z, 4);
	}
	else foot(z, 3);

}

void search_firm(shop *arr, int size, char *search) {
	char *search_name = strdup_(search, strlen(search)), *name;
	short z = 0;
	header();
	int i = 0;
	for (i = 0; i < size; i++) {
		name = strdup_((arr + i)->firm, strlen((arr + i)->firm));
		if (strcmp(name, search_name) == 0) {
			output_certain(arr, i, 3 + z);
			z++;
		}
	}
	if (z == 0) {
		system("cls");
		cout << "====================================================================================================";
		cout << "Поиск по жанру\n";
		cout << "====================================================================================================";
		cout << "Фильм с таким жанром не найден!\n";
		foot(z, 4);
	}
	else foot(z, 3);
}

void copy(shop *arr, shop *arr2, int size) {
	for (int i = 0; i < size; i++) {
		*(arr2 + i) = *(arr + i);
	}
}

void check_fail() {
	if (cin.fail()) {
		cin.clear();
		cin.ignore(cin.rdbuf()->in_avail());
	}
}

void mp(shop *arr, int size, char *search) {
	char *search_name = strdup_(search, strlen(search)), *name;
	header();
	short i = 0, sum = 0, z = 0;
	for (i = 0; i < size; i++) {
		if ((arr + i)->prc >= (arr + sum)->prc) sum = i;
	}
	for (i = 0; i < size; i++) {
		name = strdup_((arr + i)->category, strlen((arr + i)->category));
		if (strcmp(name, search_name) == 0) {
			if ((arr + i)->prc <=  (arr + sum)->prc) {
				sum = i;
				z++;
			}
		}
	}
	if (z != 0) {
		output_certain(arr, sum, 3);
		foot(4, 0);
	}
	else {
		system("cls");
		cout << "====================================================================================================";
		cout << "Самый недорогой товар среди категории\n";
		cout << "====================================================================================================";
		cout << "Товар из такой категории не найден!\n";
		foot(z, 4);
	}
}

void input_product(shop *arr) {
	do {
		cout << "Введите категорию товара(от 1 до 15 символов): ";
		cin.getline((arr->category), 26);
		check_fail();
	} while (strlen(arr->category) == 0);
	do {
		cout << "Введите название товара(от 1 до 15 символов): ";
		cin.getline((arr->name), 24);
		check_fail();
	} while (strlen(arr->name) == 0);
	do {
		cout << "Введите фирму товара(от 1 до 12 символов): ";
		cin.getline((arr->firm), 24);
		check_fail();
	} while (strlen(arr->firm) == 0);
	do {
		cout << "Введите цену товара(от 0 до 500000): ";
		cin >> arr->prc;
		check_fail();
	} while (arr->prc < 0 || arr->prc > 500000);
}

shop *add_product(shop *arr, int size) {
	shop *price_temp = new shop[size];
	copy(arr, price_temp, size);
	delete[] arr;
	arr = nullptr;
	arr = new shop[size + 1];
	copy(price_temp, arr, size);
	input_product(arr + size);
	return arr;
}

void main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	SetColor(15, 0);
	srand(time(NULL));
	int size = 15;
	shop *price = new shop[size];
	*(price + 0) = { "Материнские", "H81-mk", "Asus", 1372 };
	*(price + 1) = { "Материнские", "Asus Z97", "Asus", 3850 };
	*(price + 2) = { "Материнские", "H81M-VG4", "ASRock", 1288 };
	*(price + 3) = { "Материнские", "GA-F2A8", "Gigabyte", 3999 };
	*(price + 4) = { "Материнские", "Biostar A780LB", "Biostar", 1428 };
	*(price + 5) = { "Процессор", "G3220", "Intel", 1792 };
	*(price + 6) = { "Процессор", "AMD A4", "AMD", 1024 };
	*(price + 7) = { "Процессор", "Core i7-4790", "Intel", 10672 };
	*(price + 8) = { "Процессор", "A8", "AMD", 3306 };
	*(price + 9) = { "Монитор", "20M35A-B", "LG", 2958 };
	*(price + 10) = { "Ноутбуки", "Aspire", "Acer", 10444};
	*(price + 11) = { "Ноутбуки", "IdeaPad G700A", "Lenovo", 12963};
	*(price + 12) = { "Планшеты", "IdeaTab MIIX2", "Lenovo", 13050};
	*(price + 13) = { "Планшеты", "Q88", "VastKing", 2987};
	*(price + 14) = { "Планшеты", "Transformer Pad", "Asus", 10150};
	char search[16];
	short en = 0, k = 1;
	do {
		if (en == 80) {
			k++;
			if (k == 8) k = 1;
		}
		if (en == 72) {
			k--;
			if (k == 0) k = 7;
		}
		if (en == 13) {
			switch (k) {
			case 1: {
				system("cls");
				output(price, size);
				cout << "Нажмите любую клавишу, чтобы перейти в гланое меню\n";
				getch();
				break;
			}
			case 2: {
				system("cls");
				cout << "====================================================================================================";
				cout << "Поиск по названию\n";
				cout << "====================================================================================================";
				cout << "Введите название: ";
				cin.getline(search, 26);
				search_name(price, size, search);
				cout << "Нажмите любую клавишу, чтобы перейти в гланое меню\n";
				getch();
				break;
			}
			case 3: {
				system("cls");
				cout << "====================================================================================================";
				cout << "Поиск по категории\n";
				cout << "====================================================================================================";
				cout << "Введите категорию: ";
				cin.getline(search, 26);
				search_category(price, size, search);
				cout << "Нажмите любую клавишу, чтобы перейти в гланое меню\n";
				getch();
				break;
			}
			case 4: {
				system("cls");
				cout << "====================================================================================================";
				cout << "Поиск по фирме\n";
				cout << "====================================================================================================";
				cout << "Введите фирму: ";
				cin.getline(search, 26);
				search_firm(price, size, search);
				cout << "Нажмите любую клавишу, чтобы перейти в гланое меню\n";
				getch();
				break;
			}
			case 5: {
				system("cls");
				cout << "====================================================================================================";
				cout << "Самый популярный фильм в категории\n";
				cout << "====================================================================================================";
				cout << "Введите категорию: ";
				cin.getline(search, 26);
				mp(price, size, search);
				cout << "Нажмите любую клавишу, чтобы перейти в гланое меню\n";
				getch();
				break;
			}
			case 6: {
				system("cls");
				short i = 0, y = '1';
				do {
					output(price, size);
					cout << "Добавить товар\n";
					cout << "====================================================================================================";
					if (i > 0) {
						cout << "Нажмите 1, чтобы добавить еще один товар; любую клавишу, чтобы выйти в главное меню\n";
						y = getch();
					}
					if (y != '1') break;
					price = add_product(price, size);
					cin.ignore();
					size++;
					i++;
				} while (true);
				break;
			}
			default:
				exit(0);
				break;
			}
		}
		system("cls");
		cout << "====================================================================================================";
		if (k == 1) SetColor(10, 0);
		cout << "Показ всех записей\n";
		SetColor(15, 0);
		if (k == 2) SetColor(10, 0);
		cout << "Поиск по наванию\n";
		SetColor(15, 0);
		if (k == 3) SetColor(10, 0);
		cout << "Поиск по категории\n";
		SetColor(15, 0);
		if (k == 4) SetColor(10, 0);
		cout << "Поиск по фирме\n";
		SetColor(15, 0);
		if (k == 5) SetColor(10, 0);
		cout << "Самый недорогой товар в категории\n";
		SetColor(15, 0);
		if (k == 6) SetColor(10, 0);
		cout << "Добавить товар\n";
		SetColor(15, 0);
		if (k == 7) SetColor(10, 0);
		cout << "Выход\n";
		SetColor(15, 0);
		cout << "====================================================================================================";
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