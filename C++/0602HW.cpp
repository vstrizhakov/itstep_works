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

void create_array(int *n, int size) {
	for (int i = 0; i < size; i++) {
		*(n + i) = rand() % 41 - 20;
	}
}

void output_array(int *n, int size) {
	for (int i = 0; i < size; i++) {
		cout << *(n + i) << " ";
	}
	cout << endl;
}

void shuffle_array(int *a, int size) {
	int temp;
	for (int i = 0; i < size - 1; i += 2) {
		temp = *(a + i);
		*(a + i) = *(a + i + 1);
		*(a + i + 1) = temp;
	}
}

void unify(int *n, int *n2, int *n3, int size, int size2) {
	int j = 0;
	for (int i = 0; i < size; i++, j++) {
		*(n3 + j) = *(n + i);
	}
	for (int i = 0; i < size2; i++, j++) {
		*(n3 + j) = *(n2 + i);
	}
}

void sort(int *arr, int size, int j = 0) {
	int temp;
	for (int i = 0; i < size - 1; i++) {
		if (*(arr + i) > *(arr + i + 1)) {
			temp = *(arr + i);
			*(arr + i) = *(arr + i + 1);
			*(arr + i + 1) = temp;
			j++;
		}
	}
	if (j > 0) sort(arr, size);
}

int common(int *n, int  *n2, int *n3, int size, int size2) {
	int z = 0, d, o;
	for (int j = 0; j < size; j++) {
		for (int i = 0; i < size2; i++) {
			if (*(n + j) == *(n2 + i)) {
				for (o = 0, d = 0; o < z; o++) {
					if (*(n3 + o) == *(n + j)) d++;
				}
				if (d == 0) {
					*(n3 + z) = *(n + j);
					z++;
				}
			}
		}
	}
	return z;
}

int except(int *n, int *n2, int *n3, int size, int size2) {
	int t = 0, d, o, z;
	for (int j = 0; j < size2; j++) {
		z = 0;
		for (int i = 0; i < size; i++) {
			if (*(n + j) != *(n2 + i)) z++;
			if (z == size) {
				for (o = 0, d = 0; o < t; o++) {
					if (*(n3 + o) == *(n + j)) d++;
				}
				if (d == 0) {
					*(n3 + t) = *(n + j);
					t++;
				}
			}
		}
	}
	return t;
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
			if (k == 7) k = 1;
		}
		if (en == 72) {
			k--;
			if (k == 0) k = 6;
		}
		if (en == 13) {
			char sel;
			switch (k) {
			case 1: {
				do {
					system("cls");
					cout << "-------------------------------------------------------------------------------\n";
					cout << "1. ��� ������ ����� �����. ���������������� �����������, ��������� ������� �������� ������� � ������� � ��������� ���������(�.�.�� �������� �������, ������� ����� �� ������ ������, ��������� � ����������, ������� ����� �� �������� ������).\n";
					cout << "-------------------------------------------------------------------------------\n";
					const int x = 20;
					int n[x] = {};
					int size;
					do {
						cout << "������� ���������� ���������(1-20): ";
						cin >> size;
					} while (size < 1 || size > 20);
					create_array(n, size);
					output_array(n, size);
					shuffle_array(n, size);
					output_array(n, size);

					cout << endl << "������ ��������� ������ ��������� ��� ���?\n1 - ��\t����� ������ ������ - ����� � ������� ����\n��� �����: ";
					cin >> sel;
				} while (sel == '1');
			}
					break;
			case 2: {
				do {
					system("cls");
					cout << "-------------------------------------------------------------------------------\n";
					cout << "2. ���� ��� �������, ������������� �� �����������: �[n] � B[m].����������� ������ C[n + m], ��������� �� ��������� �������� � � �, ������������� �� �����������.\n";
					cout << "-------------------------------------------------------------------------------\n";
					const int x = 10;
					int A[x] = {}, B[x] = {}, AB[x + x], size, size2;
					do {
						cout << "������� ���������� ��������� ������� �������(1-10): ";
						cin >> size;
					} while (size < 1 || size > 10);
					do {
						cout << "������� ���������� ��������� ������� �������(1-10): ";
						cin >> size2;
					} while (size2 < 1 || size2 > 10);
					cout << "������ ������:\n";
					create_array(A, size);
					output_array(A, size);
					cout << "������ ��������������� ������:\n";
					sort(A, size);
					output_array(A, size);
					cout << "������ ������:\n";
					create_array(B, size2);
					output_array(B, size2);
					cout << "������ ��������������� ������:\n";
					sort(B, size2);
					output_array(B, size2);
					cout << "����� ������:\n";
					unify(A, B, AB, size, size2);
					output_array(AB, size + size2);
					cout << "����� ��������������� ������:\n";
					sort(AB, size + size2);
					output_array(AB, size + size2);

					cout << endl << "������ ��������� ������ ��������� ��� ���?\n1 - ��\t����� ������ ������ - ����� � ������� ����\n��� �����: ";
					cin >> sel;
				} while (sel == '1');
			}
					break;
			case 3: {
				do {
					system("cls");
					cout << "-------------------------------------------------------------------------------\n";
					cout << "���� ��� ������� : �[n] � B[m]. ���������� ������� ������ ������, � ������� ����� ������� : \n - �������� ����� ��������; \n - ����� �������� ���� ��������; \n - �������� ������� A, ������� �� ���������� � B; \n - �������� ������� B, ������� �� ���������� � A;\n - �������� �������� A � B, ������� �� �������� ������ ��� ���(�� ���� ����������� ����������� ���� ���������� ���������).\n";
					cout << "-------------------------------------------------------------------------------\n";
					const int x = 10;
					int A[x] = {}, B[x] = {}, AB[x + x] = {}, size, size2, AE[x + x] = {}, BE[x + x] = {};
					do {
						cout << "������� ���������� ��������� ������� �������(1-10): ";
						cin >> size;
					} while (size < 1 || size > 10);
					do {
						cout << "������� ���������� ��������� ������� �������(1-10): ";
						cin >> size2;
					} while (size2 < 1 || size2 > 10);
					cout << "������ ������:\n";
					create_array(A, size);
					output_array(A, size);
					cout << "������ ������:\n";
					create_array(B, size2);
					output_array(B, size2);
					cout << "�������� ����� ��������:\n";
					unify(A, B, AB, size, size2);
					output_array(AB, size + size2);
					cout << "����� �������� ���� ��������:\n";
					int amount = common(A, B, AB, size, size2);
					if (amount > 0) output_array(AB, amount);
					else cout << " �����������\n";
					cout << "�������� ������� A, ������� ��� � B:\n";
					except(A, B, AE, size, size2);
					output_array(AB, except(A, B, AB, size, size2));
					cout << "�������� ������� B, ������� ��� � A:\n";
					except(B, A, BE, size, size2);
					output_array(AB, except(B, A, AB, size, size2));
					cout << "�������� ��������� A � B, ������� �� �������� ������ ��� ���:\n";
					unify(AE, BE, AB, except(A, B, AE, size, size2), except(B, A, BE, size, size2));
					output_array(AB, except(A, B, AE, size, size2) + except(B, A, BE, size, size2));
					cout << endl << "������ ��������� ������ ��������� ��� ���?\n1 - ��\t����� ������ ������ - ����� � ������� ����\n��� �����: ";
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
		cout << "��������� �2\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------\n";
		if (k == 3) SetColor(10, 0);
		cout << "��������� �3\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------\n";
		if (k == 4) SetColor(10, 0);
		cout << "����� �� ���������\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------\n";
	} while (en = getch());
}
