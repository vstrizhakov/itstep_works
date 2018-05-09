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
T avg(T n1, T n2) {
	return (n1 + n2) / 2;
}

template <typename T>
T avg(T n1, T n2, T n3) {
	return (n1 + n2 + n3) / 3;
}

template <typename T>
T avg(T arr[], int size) {
	T sum = 0;
	for (int i = 0; i < size; i++) {
		sum += arr[i];
	}
	return sum / size;
}

template <typename T>
void input(T type) {
	T a, b, c;
	cout << "Введите первое число: ";
	cin >> a;
	if (type >= 2) {
		cout << "Введите второе число: ";
		cin >> b;
	}
	if (type >= 3) {
		cout << "Введите третье число: ";
		cin >> c;
	}
	if (type == 2) cout << "Среднее арифметрическое двух чисел: " << avg(T(a), T(b));
	if (type == 3) cout << "Среднее арифметрическое трех чисел: " << avg(T(a), T(b), T(c));
}

template <typename T>
void create_array(T arr[], int size) {
	for (int i = 0; i < size; i++) {
		arr[i] = double(rand() % 1000 + 1000) / 100;
	}
}

template <typename T>
T avg_array(T arr[], int size) {
	T sum = 0;
	for (int i = 0; i < size; i++) {
		sum += arr[i];
	}
	return sum / T(size);
}

template <typename T>
void output_array(T arr[], int size) {
	for (int i = 0; i < size; i++) {
		cout << arr[i] << "  ";
	}
}

bool find(int number, int numeral) {
	for (int i = 1000; i > 0; i /= 10) {
		int a = number / i % 10;
		if (a == numeral) return true;
	}
	return false;
}

void shuffle_array(int arr[], int size) {
	int temp;
	for (int i = 0; i < size - 1; i += 2) {
		temp = arr[i];
		arr[i] = arr[i + 1];
		arr[i + 1] = temp;
	}
}

void calculate(int x) {
	if (x % 2 == 0) {
		cout << "X кратен 2, f(x) = (3 * (x * x)) - (2 * x) = " << 3 * x * x - 2 * x << endl;
	}
	if (x % 3 == 0) {
		cout << "X кратен 3, f(x) = x - (1.5 * (x * x)) = " << x - 1.5 * x * x << endl;
	}
	if (x % 2 != 0 && x % 3 != 0) {
		cout << "Х не кратен ни 2, ни 3" << endl;
	}
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
			if (k == 6) k = 1;
		}
		if (en == 72) {
			k--;
			if (k == 0) k = 5;
		}
		if (en == 13) {
			switch (k) {
			case 1: {
			S1:
				system("cls");
				cout << "Выберите действие\n";
				cout << "1 - Среднее арифметическое между двумя числами\n";
				cout << "2 - Среднее арифметическое между тремя числами\n";
				cout << "3 - Среднее арифметическое между элементами массива\n";
				char x;
				do {
					cout << "Ваш выбор(1, 2, или 3): ";
					cin >> x;
				} while (x != '1' && x != '2' && x != '3');
				switch (x) {
				case '1':
					system("cls");
					cout << "-------------------------------------------------------------------------------\n";
					cout << "Среднее арифметическое между двумя числами\n";
					cout << "-------------------------------------------------------------------------------\n";
					cout << "1 - Числа целочиленного типа\n";
					cout << "2 - Числа вещественного типа\n";
					do {
						cout << "Ваш выбор(1 или 2): ";
						cin >> x;
					} while (x != '1' && x != '2');
					cout << endl;
					if (x == '1') input(2);
					if (x == '2') input(2.0);
					break;
				case '2':
					system("cls");
					cout << "-------------------------------------------------------------------------------\n";
					cout << "Среднее арифметическое между тремя числами\n";
					cout << "-------------------------------------------------------------------------------\n";
					cout << "1 - Числа целочиленного типа\n";
					cout << "2 - Числа вещественного типа\n";
					do {
						cout << "Ваш выбор(1 или 2): ";
						cin >> x;
					} while (x != '1' && x != '2');
					cout << endl;
					if (x == '1') input(3);
					if (x == '2') input(3.0);
					break;
				case '3':
					system("cls");
					cout << "-------------------------------------------------------------------------------\n";
					cout << "Среднее арифметическое между элементами массива\n";
					cout << "-------------------------------------------------------------------------------\n";
					int a;
					const int size = 20;
					int i_array[size] = {};
					double d_array[size] = {};
					do {
						cout << "Введите размер массива(от 1 до 20 включительно): ";
						cin >> a;
					} while (a < 1 || a > 20);
					system("cls");
					cout << "-------------------------------------------------------------------------------\n";
					cout << "Среднее арифметическое между элементами массива\n";
					cout << "-------------------------------------------------------------------------------\n";
					cout << "1 - Числа целочиленного типа\n";
					cout << "2 - Числа вещественного типа\n";
					do {
						cout << "Ваш выбор(1 или 2): ";
						cin >> x;
					} while (x != '1' && x != '2');
					cout << endl;
					if (x == '1') {
						create_array(i_array, a);
						output_array(i_array, a);
						cout << endl << avg_array(i_array, a);
					}
					if (x == '2') {
						create_array(d_array, a);
						output_array(d_array, a);
						cout << endl << avg_array(d_array, a);
					}
					break;
				}

				cout << endl << endl << "Хотите выполнить данную программу еще раз?\n1 - Да\tЛюбой другой символ - Выйти в главное меню\nВаш выбор: ";
				char sel;
				cin >> sel;
				if (sel == '1') {
					goto S1;
				}
			}
					break;
			case 2: {
			S2:
				system("cls");
				cout << "-------------------------------------------------------------------------------\n";
				cout << "Функция, которая меняе каждые два соседних элемента местами\n";
				cout << "-------------------------------------------------------------------------------\n";
				const int size = 20;
				int numbers[size] = {};
				int a;
				do {
					cout << "Введите размер массива(от 1 до 20 включительно): ";
					cin >> a;
				} while (a < 1 || a > 20);
				create_array(numbers, a);
				output_array(numbers, a);
				shuffle_array(numbers, a);
				cout << endl;
				output_array(numbers, a);
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
				cout << "-------------------------------------------------------------------------------\n";
				cout << "Функция, которая ищет цифру в числе\n";
				cout << "-------------------------------------------------------------------------------\n";

				int  a;
				do {
					cout << "Введите, какую цифру нужно найти(0-9 включительно): ";
					cin >> a;
				} while (a < 0 || a > 10);
				int b = rand() % 9000 + 1000;
				cout << "Сгенерированное число: " << b << endl;
				(find(b, a) == 1) ? cout << "В числе " << b << " есть цифра " << a : cout << "В числе " << b << " нет цифры " << a;

				cout << endl << endl << "Хотите выполнить данную программу еще раз?\n1 - Да\tЛюбой другой символ - Выйти в главное меню\nВаш выбор: ";
				char sel;
				cin >> sel;
				if (sel == '1') {
					goto S3;
				}
			}
					break;
			case 4: {
			S4:
				system("cls");
				cout << "-------------------------------------------------------------------------------\n";
				cout << "Функция, которая вычисляет значения в зависимости от Х.\n";
				cout << "-------------------------------------------------------------------------------\n";
				cout << "f(x) = (3 * (x * x)) - (2 * x), если х кратно 2\n";
				cout << "f(x) = x - (1.5 * (x * x)), если х кратно 3\n";
				int x;
				cout << "Введите х: ";
				cin >> x;
				calculate(x);
				cout  << endl << "Хотите выполнить данную программу еще раз?\n1 - Да\tЛюбой другой символ - Выйти в главное меню\nВаш выбор: ";
				char sel;
				cin >> sel;
				if (sel == '1') {
					goto S4;
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
		cout << "Программа №2 - Я не понял как ее нужно делать, но сделал хотя бы так (каждые 2 элемента массива меняются местами)\n";
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
		cout << "Выход из программы\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------\n";
	} while (en = getch());
}
