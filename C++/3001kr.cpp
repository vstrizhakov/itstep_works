#include <iostream>
#include <iomanip>
#include <ctime>
#include <windows.h>
#include <conio.h>

using namespace std;

enum ConsoleColor {
	Black, Blue, Green, Cyan, Red, Magenta, Brown, LightGray, DarkGray,
	LightBlue, LightGreen, LightCyan, LightRed, LightMagenta, Yellow, White
};

void SetColor(int text, int background);
void GotoXY(int X, int Y);

template <typename T>
void print_array(T arr[], int size, int index) {
	for (int i = 0; i < size; i++) {
		if (i == index) SetColor(11, 0);
		cout << arr[i];
		SetColor(15, 0);
		cout << " ";
	}
	cout << endl;
}

template <typename T>
void sort_array_increase(T arr[], int size) {
	int j = 0;
	T temp;
	for (int i = 0; i < size; i++) {
		if (arr[i] < arr[i + 1]) {
			temp = arr[i];
			arr[i] = arr[i + 1];
			arr[i + 1] = temp;
			j++;
		}
	}
	if (j > 0) sort_array_increase(arr, size);
}

template <typename T>
void sort_array_decrease(T arr[], int size, int start) {
	int j = 0;
	T temp;
	for (int i = start; i < size; i++) {
		if (arr[i] > arr[i + 1]) {
			temp = arr[i];
			arr[i] = arr[i + 1];
			arr[i + 1] = temp;
			j++;
		}
	}
	if (j > 0) sort_array_decrease(arr, size, start);
}

template <typename T>
void shuffle_array(T arr[], int size, int i = 0) {
	T temp = 0, a, b;
	a = rand() % size;
	b = rand() % size;
	temp = arr[a];
	arr[a] = arr[b];
	arr[b] = temp;
	i++;
	if (i < size * 5) shuffle_array(arr, size, i);
}

template <typename T>
T find_number(T arr[], int size, T key, int i = 0) {
	if (arr[i] == key) {
		return i;
	}
	i++;
	if (i < size) find_number(arr, size, key, i);
}


void main() {
	setlocale(LC_ALL, "rus");
	srand(time(NULL));
	SetColor(15, 0);
	system("cls");
START:
	short en = 0, k = 1, enter = 0, l = 1;
	char sel = 0;
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
			switch (k) {
			case 1: {
				system("cls");
				do {
					if (enter == 80) {
						l++;
						if (l == 4) l = 1;
					}
					if (enter == 72) {
						l--;
						if (l == 0) l = 3;
					}
					if (enter == 13) {
						do {
							const int size1 = 20, size2 = 26;
							int numbers[size1] = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
							char chars[size2] = { 'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };
							int index_number = -1, rand_number;
							char rand_char;
							switch (l) {
							case 1: {
								system("cls");
								cout << "Оригинальным массив: ";
								print_array(numbers, size1, index_number);
								shuffle_array(numbers, size1);
								cout << "Перемешанный массив: ";
								print_array(numbers, size1, index_number);
								rand_number = rand() % 20 + 1;
								index_number = find_number(numbers, size1, rand_number);
								cout << "Массив с рандомной точкой: ";
								print_array(numbers, size1, index_number);
								sort_array_increase(numbers, index_number - 1);
								sort_array_decrease(numbers, size1 - 1, index_number + 1);
								cout << "Отсортированный массив: ";
								print_array(numbers, size1, index_number);
							}
									break;
							case 2: {
								system("cls");
								cout << "Оригинальным массив: ";
								print_array(chars, size2, index_number);
								shuffle_array(chars, size2);
								cout << "Перемешанный массив: ";
								print_array(chars, size2, index_number);
								rand_char = rand() % 26 + 65;
								index_number = find_number(chars, size2, rand_char);
								cout << "Массив с рандомной точкой: ";
								print_array(chars, size2, index_number);
								sort_array_increase(chars, index_number - 1);
								sort_array_decrease(chars, size2, index_number + 1);
								cout << "Отсортированный массив: ";
								print_array(chars, size2, index_number);
							}
									break;
							default:
								goto START;
								break;
							}
							cout << endl << "Хотите выполнить данную программу еще раз?\n1 - Да\tЛюбой другой символ - Выйти в меню выбора типа массива\nВаш выбор: ";
							cin >> sel;
						} while (sel == '1');
					}
					system("cls");
					cout << "Выберите, с каким массивом вы хотите работать\n";
					if (l == 1) SetColor(10, 0);
					cout << "Числа\n";
					SetColor(15, 0);
					if (l == 2) SetColor(10, 0);
					cout << "Буквы\n";
					SetColor(15, 0);
					if (l == 3) SetColor(10, 0);
					cout << "Выход в главное меню\n";
					SetColor(15, 0);
				} while (enter = getch());
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
		cout << "Программа\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------\n";
		if (k == 2) SetColor(10, 0);
		cout << "Выход из программы\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------\n";
	} while (en = getch());
}




void SetColor(int text, int background) {
	HANDLE hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(hStdOut, (WORD)((background << 4) | text));
}

void GotoXY(int X, int Y) {
	HANDLE hConsole;
	HANDLE hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
	COORD coord = { X, Y };
}