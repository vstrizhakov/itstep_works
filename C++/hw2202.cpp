#include <iostream>
#include <Windows.h>
#include <conio.h>
#include <cstdlib>
#include <ctime>
#include <iomanip>

using namespace std;

void SetColor(int text, int background);
void GotoXY(int X, int Y);

double ***allocation_memory(int layers, int rows, int cols) {
	double ***arr = new double**[layers];
	for (int i = 0; i < layers; i++) {
		*(arr + i) = new double*[rows];
	}
	for (int j = 0; j < layers; j++) {
		for (int i = 0; i < rows; i++) {
			*(*(arr + j) + i) = new double[cols];
		}
	}
	return arr;
}

void create_array(double ***arr, int layers, int rows, int cols) {
	for (int l = 0; l < layers; l++) {
		for (int j = 0; j < rows; j++) {
			for (int i = 0; i < cols; i++) {
				*(*(*(arr + l) + j) + i) = double(rand() % 9000 - 4500) / 100;
			}
		}
	}
}

void output_array(double ***arr, int layers, int rows, int cols) {
	for (int l = 0; l < layers; l++) {
		for (int j = 0; j < rows; j++) {
			for (int i = 0; i < cols; i++) {
				cout << setw(7) << *(*(*(arr + l) + j) + i);
			}
			cout << endl;
		}
		cout << endl;
	}
}

double find_average(double ***arr, int layers, int rows, int cols) {
	double sum = 0;
	for (int l = 0; l < layers; l++) {
		for (int j = 0; j < rows; j++) {
			for (int i = 0; i < cols; i++) {
				sum += *(*(*(arr + l) + j) + i);
			}
		}
	}
	return sum / (layers * rows * cols);
}

void delete_memory(double ***arr, int layers, int rows, int cols) {
	
	for (int j = 0; j < layers; j++) {
		for (int i = 0; i < rows; i++) {
			delete[] *(*(arr + j) + i);
		}
	}
	for (int i = 0; i < layers; i++) {
		delete[] *(arr + i);
	}
	delete[] arr;
}

void main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	SetColor(15, 0);
	srand(time(NULL));
	char s;
	double ***_array; 
	int layers, rows, cols;
	do {
		system("cls");
		cout << "Введите количество слоев: ";
		cin >> layers;
		cout << "Введите количество строк: ";
		cin >> rows;
		cout << "Введите количество столбцов: ";
		cin >> cols;
		system("cls");
		cout << "Трехмерный массив: слоев - " << layers << ", строк - " << rows << ", столбцов - " << cols << endl << endl;
		do {
			_array = allocation_memory(layers, rows, cols);
		} while (!_array);
		create_array(_array, layers, rows, cols);
		output_array(_array, layers, rows, cols);
		cout << fixed << setprecision(2) << "Среднее арифметическое всех чисел этого массива равно " << find_average(_array, layers, rows, cols) << endl << endl;
		delete_memory(_array, layers, rows, cols);
		_array = nullptr;
		cout << "0 - Запустить эту программу еще раз\tЛюбой другой символ - Выход из программы" << endl << "Ваш выбор: ";
		cin >> s;
	} while (s == '0');
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