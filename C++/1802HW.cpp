#include <iostream>
#include <Windows.h>
#include <conio.h>
#include <cstdlib>
#include <ctime>
#include <iomanip>

using namespace std;

void SetColor(int text, int background);
void GotoXY(int X, int Y);

double ***_allocation_memory(double ***arr, int layers, int rows, int cols) {
	***arr = new double*[layers];
	for (int i = 0; i < layers; i++) {
		*(arr + i) = new double*[rows];
	}
	for (int j = 0; j < rows; j++) {
		for (int i = 0; i < cols; i++) {
			*(*(arr + i) + j) = new double*[cols];
		}
	}
	return arr;
}

void main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	SetColor(15, 0);
	int ***_array
	int layer, rows, cols;
	cin >> layer >> rows >> cols;
	do {
		***_array = allocation_memory(layers, rows, cols);
	} while (!_array);
	cout << "Successful! :)" << endl;
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