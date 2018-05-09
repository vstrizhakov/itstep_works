#include <iostream>        
#include <windows.h> 
#include <cstdlib>
#include <ctime>
#include <iomanip>

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

void main() {
	setlocale(LC_ALL, "Russian");
START:
	SetColor(14, 0);
	cout << "ГЛАВНОЕ МЕНЮ\n";
	SetColor(15, 0);
	cout << "1 - ";
	cout << "2 - ";
	cout << "3 - ";
	cout << "4 - ";
	cout << "5 - ";
	cout << "Любой другой символ - Выйти из программы\n";
	cout << "Ваш выбор: ";
	char x;
	int sum = 0, a = 0, y = 0;
	cin >> x;
	cout << "\n";

	switch (x) {

	case '1': {

		SetColor(11, 0);
		cout << "-------------------------------------------------------------------------------\n";
		cout << "";
		cout << "-------------------------------------------------------------------------------\n";
		SetColor(15, 0);
	START1:

		cout << "Желаете использовать данную программу еще раз?\n1 - Да\tЛюбой другой символ - Перейти в главное меню\n";
		cout << "Ваш выбор: ";
		cin >> x;
		cout << "\n";
		switch (x) {
		case '1':
			goto START1;
			break;
		default:
			goto START;
			break;
		}

		break;
	}
	case '2': {
		_LONGLONG b, t;
		SetColor(11, 0);
		cout << "-------------------------------------------------------------------------------\n";
		cout << "";
		cout << "-------------------------------------------------------------------------------\n";
		SetColor(15, 0);
	START2:

		cout << "Желаете использовать данную программу еще раз?\n1 - Да\tЛюбой другой символ - Перейти в главное меню\n";
		cout << "Ваш выбор: ";
		cin >> x;
		cout << "\n";
		switch (x) {
		case '1':
			goto START2;
			break;
		default:
			goto START;
			break;
		}

		break;
	}
	case '3': {

		float c = 0;
		SetColor(11, 0);
		cout << "-------------------------------------------------------------------------------\n";
		cout << "";
		cout << "-------------------------------------------------------------------------------\n";
		SetColor(15, 0);
	START3:


		cout << "Желаете использовать данную программу еще раз?\n1 - Да\tЛюбой другой символ - Перейти в главное меню\n";
		cout << "Ваш выбор: ";
		cin >> x;
		cout << "\n";
		switch (x) {
		case '1':
			goto START3;
			break;
		default:
			goto START;
			break;
		}
		break;
	}
	case '4': {

		SetColor(11, 0);
		cout << "-------------------------------------------------------------------------------\n";
		cout << "";
		cout << "-------------------------------------------------------------------------------\n";
		SetColor(15, 0);
	START4:
		

		cout << "Желаете использовать данную программу еще раз?\n1 - Да\tЛюбой другой символ - Перейти в главное меню\n";
		cout << "Ваш выбор: ";
		cin >> x;
		cout << "\n";
		switch (x) {
		case '1':
			goto START4;
			break;
		default:
			goto START;
			break;
		}

		break;
	}
	case '5': {
		_LONGLONG summ;
		SetColor(11, 0);
		cout << "-------------------------------------------------------------------------------\n";
		cout << "";
		cout << "-------------------------------------------------------------------------------\n";
		SetColor(15, 0);
	START5:
		
		cout << "Желаете использовать данную программу еще раз?\n1 - Да\tЛюбой другой символ - Перейти в главное меню\n";
		cout << "Ваш выбор: ";
		cin >> x;
		cout << "\n";
		switch (x) {
		case '1':
			goto START5;
			break;
		default:
			goto START;
			break;
		}

		break;
	}
	default:
		cout << "Выход из программы...\n";
		break;
	}
}
