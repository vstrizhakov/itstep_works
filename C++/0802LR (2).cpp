#include <iostream>
#include <Windows.h>
#include <conio.h>
#include <cstdlib>
#include <ctime>
#include <iomanip>

using namespace std;

void SetColor(int text, int background);
void GotoXY(int X, int Y);

void create_array(int arr[][6], int size, int size2);
void output_array(int arr[][6], int size, int size2);
void create_array(double *arr, int size);
void output_array(double *arr, int size);
void create_array(bool *arr, int size);
void output_array(bool *arr, int size);
int find_max(int arr[][6], int size);
double total(double *arr, bool *arr2, int size);
void create_table_1(int num[][10], int n);
void create_table_2(int num[][10], int score[][10], int n);
void create_table_3(int num[][10], int gww[][3], int n);
void output_table_1(int num[][10], int n);
void sort_table_2(int num[][10], int n);
void output_table_2(int num[][10], int n);
void output_table_3(int gww[][3], int n);

void main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	SetColor(15, 0);
	srand(time(NULL));

	short en = 0, k = 1;
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
			char sel;
			switch (k) {
			case 1: {
				do {
					system("cls");
					cout << "---------------------------------------------------------------------------------------------------\n";
					cout << "Программа, которая выводит номер строки двумерного массива 5Х5, заполненного случайными числами, сумма элементов которой максимальна\n";
					cout << "---------------------------------------------------------------------------------------------------\n";
					int size;
					cout << "Введите размер: ";
					cin >> size;
					int *arr = new int[size];
					create_array(arr, size);
					output_array(arr, size);
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
		cout << "---------------------------------------------------------------------------------------------------\n";
		if (k == 1) SetColor(10, 0);
		cout << "Создать массив\n";
		SetColor(15, 0);
		cout << "---------------------------------------------------------------------------------------------------\n";
		SetColor(12, 0);
		cout << "ВНИМАНИЕ!";
		SetColor(15, 0);
		cout << " Программа корректно отображается при разрешении консоли 100x30!" << endl;
		cout << "---------------------------------------------------------------------------------------------------\n";
		if (k == 2) SetColor(10, 0);
		cout << "Выход из программы\n";
		SetColor(15, 0);
		cout << "---------------------------------------------------------------------------------------------------\n";
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

void create_array(int *arr, int size) {
	for (int i = 0; i < size; i++) {
		*(arr + i) = rand() % 41 - 20;
	}
}

void output_array(int *arr, int size) {
	for (int i = 0; i < size; i++) {
		cout << *(arr + i) << " ";
	}
	cout << endl;
}
