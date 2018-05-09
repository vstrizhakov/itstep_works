#include <iostream>
#include <iomanip>
#include <windows.h> 

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
	setlocale(LC_ALL, "rus");
	
	SetColor(14, 0);
	GotoXY(30, 0);
	cout << "ГЛАВНОЕ МЕНЮ\n";
	SetColor(15, 0);
	START:
	cout << "1 - Спортсмен начал тренировки, и в первый день пробежал 5 км. Каждый следующий день он пробегал на 10% больше, чем в предыдущий. Определить, в какой день после начала тренировок спортсмен пробежит 20 км.\n";
	cout << "2 - Найти наибольшее натуральное число, не превышающее 5000 и нацело делящееся на 39.\n";
	cout << "3 - Из заданного натурального числа вычли сумму его цифр. Из результатов вновь вычли сумму его цифр и д.т. Сколько таких действий необходимо произвести, чтобы получить 0?\n";
	cout << "Любой другой символ - Выход из программы.\n";
	char x;
	cout << "\nВаш выбор: ";
	cin >> x;
	cout << "\n";

	switch (x) {

	case '1': {

		SetColor(11, 0);
		cout << "-------------------------------------------------------------------------------\n";
		cout << " Спортсмен начал тренировки, и в первый день пробежал 5 км. Каждый следующий день он пробегал на 10% больше, чем в предыдущий. Определить, в какой день после начала тренировок спортсмен пробежит 20 км.\n";
		cout << "-------------------------------------------------------------------------------\n\n";
		SetColor(15, 0);
	START1:
		short d = 1;
		double p = 0.1, r = 5, s = 0;

		while (r <= 20) {
			r += r * p;
			d++;
			cout << fixed << setprecision(3) << "На " << d << " день спортсмен пробежал " << r << " км." << endl;
		}
		SetColor(10, 0);
		cout << "\nСпортсмен пробежал 20 км на " << d << " дней.\n\n";
		SetColor(15, 0);

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

		SetColor(11, 0);
		cout << "-------------------------------------------------------------------------------\n";
		cout << "Найти наибольшее натуральное число, не превышающее 5000 и нацело делящееся на 39.\n";
		cout << "-------------------------------------------------------------------------------\n\n";
		SetColor(15, 0);
	START2:
		int i = 5000;
		SetColor(10, 0);
		while (float(i % 39) != 0) {
			i--;
			if (i % 39 == 0) cout << i << endl << endl;
		}
		SetColor(15, 0);

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
		cout << "Из заданного натурального числа вычли сумму его цифр.Из результатов вновь вычли сумму его цифр и д.т.Сколько таких действий необходимо произвести, чтобы получить 0 ? \n";
		cout << "-------------------------------------------------------------------------------\n\n";
		SetColor(15, 0);
	START3:
		cout << "Введите число: ";
		_LONGLONG num;
		cin >> num;
		if (num < 0) {
			SetColor(12, 0);
			cout << "\nОшибка: введите число больше 0!\n\n";
			SetColor(15, 0);
			goto START3;
		}
		cout << endl;
		_LONGLONG n = num;
		int counter, s, m, r, j;
		for (j = 0; num > 0; j++) {
			n = num;
			counter = 0;

			for (counter; n; counter++) {
				n /= 10;
			}

			s = 0;
			m = 1;
			r = 0;

			for (int i = 0; i < counter; i++) {
				s = num / m % 10;
				m *= 10;
				r += s;
			}

			cout << j + 1 << " действие: сумма цифр числа " << num << " равна " << r << ". " << num << " - " << r << " = ";
			num -= r;
			cout << num << endl;
		}
		SetColor(10, 0);
		cout << "\nЧтобы получить 0, нужно произвести " << j << " таких действий." << endl << endl;
		SetColor(15, 0);

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
	default:
		cout << "Выход из программы...\n";
		break;
	}

}