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

template <typename T>
void create_array(T arr[], int size) {
	for (int i = 0; i < size; i++) {
		arr[i] = double(rand() % 10000) / 100;
	}
}

template <typename T>
void output_array(T arr[], int size) {
	for (int i = 0; i < size; i++) {
		cout << arr[i] << "  ";
	}
	cout << endl;
}

template <typename T>
void find_linear(T arr[], int size, T key) {
	int amount = 0;
	for (int i = 0; i < size; i++) {
		if (arr[i] == key) {
			amount++;
		}
	}
	(amount > 0) ? cout << "Число(номер символа) " << key << " повторяется " << amount << " раз" << endl : cout << "Число(номер символа) не найден(-о)!" << endl;
}

template <typename T>
void find_binary(T arr[], int size, T key, int start = 0) {
	int i = 0, p;
	while (i == 0) {
		p = (size - start) / 2;
		if (arr[p] < key) {
			start = p + 1;
		}
		else if (arr[p] > key) {
			size = p - 1;
		}
		else {
			cout << "Найден(-о) число(номер массива) " << key << endl;
			i = 1;
		}

		if (start > size) {
			i = 1;
			cout << "Число(номер массива) не найден(-о)!" << endl;
		}
	}
}

int bin_to_dec(int number) {
	_LONGLONG i;
	int sum = 0, j;
	for (i = 1, j = 0; i < 10000000000000000000; i *= 10, j++) {
		int n = number / i % 10, s_n = 2;
		for (int y = 1; y < j; y++) {
			s_n *= 2;
		}
		if (j == 0) s_n = 1;
		sum += n * s_n;
	}
	return sum;
}

void main() {
	system("cls");
	SetColor(15, 0);
	setlocale(LC_ALL, "rus");
	srand(time(NULL));

	short en = 0, k = 1;
	do {
		if (en == 80) {
			k++;
			if (k == 5) k = 1;
		}
		if (en == 72) {
			k--;
			if (k == 0) k = 4;
		}
		if (en == 13) {
			switch (k) {
			case 1: {
				const int size = 20;
				int i_array[size] = {};
				double d_array[size] = {};
				char c_array[size] = {};
			S1:
				system("cls");
				cout << "Выберите тип массива\n";
				cout << "1 - int\n";
				cout << "2 - double\n";
				cout << "3 - char\n";
				char x;
				int s;
				do {
					cout << "Ваш выбор(1, 2, или 3): ";
					cin >> x;
				} while (x != '1' && x != '2' && x != '3');
				system("cls");
				do {
					cout << "Введите размер массива(1-20 включительно): ";
					cin >> s;
				} while (s < 1 || s > 20);
				int i_key;
				double d_key;
				char c_key;
				switch (x) {
				case '1':
					create_array(i_array, s);
					output_array(i_array, s);
					cout << "Введите число, который хотите найти: ";
					cin >> i_key;
					find_linear(i_array, s, i_key);
					break;
				case '2':
					create_array(d_array, s);
					output_array(d_array, s);
					cout << "Введите число, который хотите найти: ";
					cin >> d_key;
					find_linear(d_array, s, d_key);
					break;
				case '3':
					create_array(c_array, s);
					output_array(c_array, s);
					cout << "Введите символ, который хотите найти: ";
					cin >> c_key;
					find_linear(c_array, s, c_key);
					break;
				}

				cout << endl << "Хотите выполнить данную программу еще раз?\n1 - Да\tЛюбой другой символ - Выйти в главное меню\nВаш выбор: ";
				char sel;
				cin >> sel;
				if (sel == '1') {
					goto S1;
				}
			}
					break;
			case 2: {
				const int size = 20;
				int i_array[size] = {};
				double d_array[size] = {};
				char c_array[size] = {};
			S2:
				system("cls");
				cout << "Выберите тип массива\n";
				cout << "1 - int\n";
				cout << "2 - double\n";
				cout << "3 - char\n";
				char x;
				int s;
				do {
					cout << "Ваш выбор(1, 2, или 3): ";
					cin >> x;
				} while (x != '1' && x != '2' && x != '3');
				system("cls");
				do {
					cout << "Введите размер массива(1-20 включительно): ";
					cin >> s;
				} while (s < 1 || s > 20);
				int i_key;
				double d_key;
				char c_key;
				switch (x) {
				case '1':
					create_array(i_array, s);
					output_array(i_array, s);
					cout << "Введите число, который хотите найти: ";
					cin >> i_key;
					find_binary(i_array, s, i_key);
					break;
				case '2':
					create_array(d_array, s);
					output_array(d_array, s);
					cout << "Введите число, который хотите найти: ";
					cin >> d_key;
					find_binary(d_array, s, d_key);
					break;
				case '3':
					create_array(c_array, s);
					output_array(c_array, s);
					cout << "Введите символ, который хотите найти: ";
					cin >> c_key;
					find_binary(c_array, s, c_key);
					break;
				}

				cout << endl << endl << "Хотите выполнить данную программу еще раз?\n1 - Да\tЛюбой другой символ - Выйти в главное меню\nВаш выбор: ";
				char sel;
				cin >> sel;
				if (sel == '1') {
					goto S2;
				}
			}
					break;
			case 3: {
			S3:
				system("cls");
				cout << "Введите двоичное число: ";
				int x;
				cin >> x;
				cout << "Десятичное число: " << bin_to_dec(x);
				cout << endl << endl << "Хотите выполнить данную программу еще раз?\n1 - Да\tЛюбой другой символ - Выйти в главное меню\nВаш выбор: ";
				char sel;
				cin >> sel;
				if (sel == '1') {
					goto S3;
				}
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
		cout << "Выход из программы\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------\n";
	} while (en = getch());
}
