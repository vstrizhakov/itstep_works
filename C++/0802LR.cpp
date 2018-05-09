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
			if (k == 6) k = 1;
		}
		if (en == 72) {
			k--;
			if (k == 0) k = 5;
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
					const int size = 5, size2 = 6;
					int numbers[size][size2] = {};
					create_array(numbers, size, size2);
					output_array(numbers, size, size2);
					cout << "Строка, сумма элементов которой максимальна: " << find_max(numbers, size) << endl;

					cout << endl << "Хотите выполнить данную программу еще раз?\n1 - Да\tЛюбой другой символ - Выйти в главное меню\nВаш выбор: ";
					cin >> sel;
				} while (sel == '1');
			}
					break;
			case 2: {
				do {
					system("cls");
					cout << "---------------------------------------------------------------------------------------------------\n";
					cout << "Функция, которая возвращает общую стоимость тех книг, которые остались в библиотеке\n";
					cout << "---------------------------------------------------------------------------------------------------\n";
					const int size = 12;
					double price[size] = {};
					bool available[size] = {};
					for (int i = 0; i < size; i++) {
						GotoXY(0, i + 4);
						cout << "Книга №" << i + 1;
					}
					create_array(price, size);
					output_array(price, size);
					create_array(available, size);
					output_array(available, size);
					cout << "Общая стоимость книг, оставшихся в библиотеке: " << total(price, available, size);

					cout << endl << endl << "Хотите выполнить данную программу еще раз?\n1 - Да\tЛюбой другой символ - Выйти в главное меню\nВаш выбор: ";
					cin >> sel;
				} while (sel == '1');
			}
					break;
			case 3: {
				do {
					system("cls");
					cout << "---------------------------------------------------------------------------------------------------\n";
					cout << "Исправить код\n";
					cout << "---------------------------------------------------------------------------------------------------\n";
					double a = 2.5, b = 5.2, res;
					double *p1 = &a, *p2 = &b;
					res = *p1 - *p2;
					cout << res;
					cout << "\n\nИсправленный код:\ndouble a = 2.5, b = 5.2, res;\ndouble *p1 = &a, *p2 = &b;\nres = *p1 - *p2;\ncout << res;\n";

					cout << endl << "Хотите выполнить данную программу еще раз?\n1 - Да\tЛюбой другой символ - Выйти в главное меню\nВаш выбор: ";
					cin >> sel;
				} while (sel == '1');
			}
					break;
			case 4: {
				do {
					system("cls");
					cout << "---------------------------------------------------------------------------------------------------\n";
					cout << "Турнирная таблица\n";
					cout << "---------------------------------------------------------------------------------------------------\n";
					const int size = 10, size2 = 2, size3 = 3;
					int num[size][size] = {};
					int score[size2][size] = {};
					int gww[size][size3] = {};
					int n;
					do {
						cout << "Введите размер турнирной таблицы(2-10): ";
						cin >> n;
					} while (n < 2 || n > 10);
					system("cls");
					cout << "---------------------------------------------------------------------------------------------------\n";
					cout << "Турнирная таблица\n";
					cout << "---------------------------------------------------------------------------------------------------\n";
					create_table_1(num, n);
					create_table_2(num, score, n);
					create_table_3(num, gww, n);
					output_table_1(num, n);
					cout << endl << endl;
					output_table_3(gww, n);
					cout << endl << endl;
					output_table_2(score, n);
					cout << endl << endl;
					cout << "Хотите выполнить данную программу еще раз?\n1 - Да\tЛюбой другой символ - Выйти в главное меню\nВаш выбор: ";
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
		cout << "Программа №1\n";
		SetColor(15, 0);
		cout << "---------------------------------------------------------------------------------------------------\n";
		if (k == 2) SetColor(10, 0);
		cout << "Программа №2\n";
		SetColor(15, 0);
		cout << "---------------------------------------------------------------------------------------------------\n";
		if (k == 3) SetColor(10, 0);
		cout << "Программа №3\n";
		SetColor(15, 0);
		cout << "---------------------------------------------------------------------------------------------------\n";
		if (k == 4) SetColor(10, 0);
		cout << "Программа №4\n";
		SetColor(15, 0);
		cout << "---------------------------------------------------------------------------------------------------\n";
		SetColor(12, 0);
		cout << "ВНИМАНИЕ!";
		SetColor(15, 0);
		cout << " Программа корректно отображается при разрешении консоли 100x30!" << endl;
		cout << "---------------------------------------------------------------------------------------------------\n";
		if (k == 5) SetColor(10, 0);
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

void create_array(int arr[][6], int size, int size2) {
	for (int j = 0; j < size; j++) {
		for (int i = 0; i < size2; i++) {
			if (i != 5)  arr[j][i] = rand() % 100 + 1;
			else {
				int sum = 0;
				for (int x = 0; x < size; x++) sum += arr[j][x];
				arr[j][5] = sum;
			}
		}
	}
}

void output_array(int arr[][6], int size, int size2) {
	for (int j = 0; j < size; j++) {
		for (int i = 0; i < size2; i++) {
			(i != 5) ? cout << setw(4) << arr[j][i] : cout << "    Сумма: " << arr[j][i];
		}
		cout << endl;
	}
	cout << endl;
}

void create_array(double *arr, int size) {
	for (int j = 0; j < size; j++) {
		*(arr + j) = double(rand() % 40100 + 10000) / 100;
	}
}

void output_array(double *arr, int size) {
	for (int j = 0; j < size; j++) {
		GotoXY(20, j + 4);
		cout << *(arr + j) << endl;
	}
	cout << endl;
}

void create_array(bool *arr, int size) {
	for (int j = 0; j < size; j++) {
		*(arr + j) = rand() % 2;
	}
}

void output_array(bool *arr, int size) {
	for (int j = 0; j < size; j++) {
		GotoXY(35, j + 4);
		(*(arr + j) == 0) ? cout << "Книга на руках" << endl : cout << "Книга в наличии" << endl;
	}
	cout << endl;
}

int find_max(int arr[][6], int size) {
	int s = 0;
	for (int i = 0; i < size; i++) {
		if (arr[i][5] > arr[s][5]) s = i;
	}
	return s + 1;
}

double total(double *arr, bool *arr2, int size) {
	double sum = 0;
	for (int i = 0; i < size; i++) {
		if (*(arr2 + i) == 1) sum += *(arr + i);
	}
	return sum;
}

void create_table_1(int num[][10], int n) {
	for (int j = 0; j < n; j++) {
		for (int i = 0; i < n; i++) {
			if (i < j) num[j][i] = rand() % 3;
			else if (i == j) num[j][i] = 0;
		}
	}
	for (int j = 0; j < n; j++) {
		for (int i = 0; i < n; i++) {
			if (i > j) {
				if (num[i][j] == 0) num[j][i] = 2;
				else if (num[i][j] == 1) num[j][i] = 1;
				else if (num[i][j] == 2) num[j][i] = 0;
			}
		}
	}
}

void create_table_2(int num[][10], int score[][10], int n) {
	int sum;
	for (int j = 0; j < n; j++) {
		sum = 0;
		for (int i = 0; i < n; i++) {
			sum += num[j][i];
		}
		score[0][j] = j + 1;
		score[1][j] = sum;
	}
}

void create_table_3(int num[][10], int gww[][3], int n) {
	int g, ww, w;
	for (int j = 0; j < n; j++) {
		g = 0;
		ww = 0;
		w = 0;
		for (int i = 0; i < n; i++) {
			if (num[j][i] == 0) g++;
			else if (num[j][i] == 1) ww++;
			else w++;
		}
		gww[j][0] = g - 1;
		gww[j][1] = ww;
		gww[j][2] = w;
	}
}

void output_table_1(int num[][10], int n) {
	for (int i = 0; i < n; i++) {
		(i == 0) ? cout << "       Ком " << i + 1 << "   " : cout << "Ком " << i + 1 << "   ";
		if (i == n - 1) cout << endl;
	}
	for (int j = 1; j < n + 1; j++) {
		for (int i = 0; i < n; i++) {
			if (i == 0) (j == 1) ? cout << "Ком " << j << " " : cout << "Ком " << j;
			if (i == j - 1) SetColor(15, 11);
			(j < 10 && j - 1 > 0 || i > 0) ? cout << setw(8) << num[j - 1][i] : cout << setw(7) << num[j - 1][i];
			if (i == j - 1) SetColor(15, 0);
		}
		cout << endl << endl;
	}
}

void sort_table_2(int num[][10], int n) {
	int z = 1, temp;
	for (int j = 1; j > 0;) {
		j = 0;
		for (int i = 0; i < n; i++) {
			if (num[1][i] < num[1][i + 1]) {
				temp = num[1][i];
				num[1][i] = num[1][i + 1];
				num[1][i + 1] = temp;
				temp = num[0][i];
				num[0][i] = num[0][i + 1];
				num[0][i + 1] = temp;
				j++;
			}
		}
	}
}

void output_table_2(int num[][10], int n) {
	sort_table_2(num, n);
	for (int i = 0; i < n; i++) {
		cout << "Место: " << i + 1 << "    Комманда: " << num[0][i] << "    Очков: " << num[1][i] << endl;
	}
}

void output_table_3(int gww[][3], int n) {
	for (int i = 0; i < n; i++) {
		cout << "Команда " << i + 1 << ":  проигрыши: " << gww[i][0] << ",  ничьи: " << gww[i][1] << ",  выигрыши: " << gww[i][2] << endl;
	}
}