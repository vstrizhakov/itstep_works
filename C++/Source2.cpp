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
		cout << " ��������� ����� ����������, � � ������ ���� �������� 5 ��. ������ ��������� ���� �� �������� �� 10% ������, ��� � ����������. ����������, � ����� ���� ����� ������ ���������� ��������� �������� 20 ��.\n";
		cout << "-------------------------------------------------------------------------------\n\n";
		SetColor(15, 0);
	START1:
		short d = 1;
		double p = 0.1, r = 5, s = 0;

		while (r <= 20) {
			r += r * p;
			d++;
			cout << fixed << setprecision(3) << "�� " << d << " ���� ��������� �������� " << r << " ��." << endl;
		}
		SetColor(10, 0);
		cout << "\n��������� �������� 20 �� �� " << d << " ����.\n\n";
		SetColor(15, 0);

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
		cout << "����� ���������� ����������� �����, �� ����������� 5000 � ������ ��������� �� 39.\n";
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
		cout << "�� ��������� ������������ ����� ����� ����� ��� ����.�� ����������� ����� ����� ����� ��� ���� � �.�.������� ����� �������� ���������� ����������, ����� �������� 0 ? \n";
		cout << "-------------------------------------------------------------------------------\n\n";
		SetColor(15, 0);
	START3:
		cout << "������� �����: ";
		_LONGLONG num;
		cin >> num;
		if (num < 0) {
			SetColor(12, 0);
			cout << "\n������: ������� ����� ������ 0!\n\n";
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

			cout << j + 1 << " ��������: ����� ���� ����� " << num << " ����� " << r << ". " << num << " - " << r << " = ";
			num -= r;
			cout << num << endl;
		}
		SetColor(10, 0);
		cout << "\n����� �������� 0, ����� ���������� " << j << " ����� ��������." << endl << endl;
		SetColor(15, 0);

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
	default:
		cout << "����� �� ���������...\n";
		break;
	}

}