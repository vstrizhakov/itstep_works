#include <iostream>
#include <Windows.h>
#include <conio.h>
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

void towers(int number, int from, int to, int free)
 {
	SetConsoleOutputCP(1251);
	if (number != 0)
	{
		towers(number - 1, from, free, to);
		cout << "������� " << number << "-� ���� � " << from << "-�� ������� � ������� ��� �� " << to << "-� ��������" << endl;
		towers(number - 1, free, to, from);
	}
}

void main() {
	system("cls");
	SetColor(15, 0);
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
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
					cout << "-------------------------------------------------------------------------------\n";
					cout << "��������� �����\n";
					cout << "-------------------------------------------------------------------------------\n";
					int x, l;
					do {
						cout << "������� ���������� �����(x >= 3): ";
						cin >> x;
					} while (x < 3);
					do {
						cout << "�������, �� ����� �������� ��������� ������(2 ��� 3): ";
						cin >> k;
					} while (k != 2 && k != 3);
					(k == 2) ? towers(x, 1, 2, 3) : towers(x, 1, 3, 2);
					cout << endl << endl << "������ ��������� ������ ��������� ��� ���?\n1 - ��\t����� ������ ������ - ����� � ������� ����\n��� �����: ";
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
		cout << "-------------------------------------------------------------------------------\n";
		if (k == 1) SetColor(10, 0);
		cout << "��������� �1\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------\n";
		if (k == 2) SetColor(10, 0);
		cout << "����� �� ���������\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------\n";
	} while (en = getch());
}
