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
	cout << "������� ����\n";
	SetColor(15, 0);
START:
	cout << "1 - ��������� ����� ����������, � � ������ ���� �������� 5 ��. ������ ��������� ���� �� �������� �� 10% ������, ��� � ����������. ����������, � ����� ���� ����� ������ ���������� ��������� �������� 20 ��.\n";
	cout << "2 - ����� ���������� ����������� �����, �� ����������� 5000 � ������ ��������� �� 39.\n";
	cout << "3 - �� ��������� ������������ ����� ����� ����� ��� ����. �� ����������� ����� ����� ����� ��� ���� � �.�. ������� ����� �������� ���������� ����������, ����� �������� 0?\n";
	cout << "����� ������ ������ - ����� �� ���������.\n";
	char x;
	cout << "\n��� �����: ";
	cin >> x;
	cout << "\n";

	switch (x) {

	case '1': {

		SetColor(11, 0);
		cout << "-------------------------------------------------------------------------------\n";
		cout << "������, ����� ����������, � ������ ���� �������� n ��. ������ ��������� ���� �� ���������� ������ �� m% �� ������� ����������� ���. ������� ���������� �� �������� �� k ����.\n";
		cout << "-------------------------------------------------------------------------------\n\n";
		SetColor(15, 0);
	START1:


		cout << "������� ������������ ������ ��������� ��� ���?\n1 - ��\t����� ������ ������ - ������� � ������� ����\n";
		cout << "��� �����: ";
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
		cout << "������������� ���� ������ n ���� ������� �������. ����������, ������� ��� ����� ����� m �����, ���� ������������� ���� k ���.\n";
		cout << "-------------------------------------------------------------------------------\n\n";
		SetColor(15, 0);
	START2:


		cout << "������� ������������ ������ ��������� ��� ���?\n1 - ��\t����� ������ ������ - ������� � ������� ����\n";
		cout << "��� �����: ";
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
		cout << "��������� ������ �������� ������������� �� 1/n ������� �������. ����� ������� ��� ��������� ������ ���������� � m ���?\n";
		cout << "-------------------------------------------------------------------------------\n\n";
		SetColor(15, 0);
	START3:


		cout << "������� ������������ ������ ��������� ��� ���?\n1 - ��\t����� ������ ������ - ������� � ������� ����\n";
		cout << "��� �����: ";
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
		cout << "��� ���� � ������ n ����������, ��������� � ����� � �����������, ���������� ��� ������ ������ ��� �� m/l, ��� m ������  l, ������, � ������� �� �����. ���������� ����� ������� ������ ��� ���������� �� ������ ������� k �����������\n";
		cout << "-------------------------------------------------------------------------------\n\n";
		SetColor(15, 0);
	START4:


		cout << "������� ������������ ������ ��������� ��� ���?\n1 - ��\t����� ������ ������ - ������� � ������� ����\n";
		cout << "��� �����: ";
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
		SetColor(11, 0);
		cout << "-------------------------------------------------------------------------------\n";
		cout << "��� ���� � ������ n ����������, ��������� � ����� � �����������, ���������� ��� ������ ������ ��� �� m/l, ��� m ������  l, ������, � ������� �� �����. ���������� ����� ������� ������ ��� ���������� �� ������ ������� k �����������\n";
		cout << "-------------------------------------------------------------------------------\n\n";
		SetColor(15, 0);
	START5:


		cout << "������� ������������ ������ ��������� ��� ���?\n1 - ��\t����� ������ ������ - ������� � ������� ����\n";
		cout << "��� �����: ";
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
		cout << "����� �� ���������...\n";
		break;
	}

}
