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

char comparision(int n1, int n2) {
	if (n1 > n2) return '>';
	else if (n1 < n2) return '<';
	else return '=';
}

void sum(int t, int r, int t2, int r2) {
	int n = 0, s, st, st2, sum;
	if (r % r2 == 0) s = r;
	else if (r2 % r == 0) s = r2;
	else s = r * r2;
	st = s / r;
	st2 = s / r2;
	sum = (t * st) + (t2 * st2);
	for (; sum % 2 == 0 && s % 2 == 0; sum /= 2, s /= 2);
	if (sum > s) n = sum / s;
	sum -= n * s;
	if (sum == 0) sum++;
	cout << "�����: ";
	if (n != 0) cout << n << "*";
	cout << sum << "/" << s;
}

double sum(double n1, double n2) {
	return n1 + n2;
}

void create_array(int arr[], int size = 10) {
	for (int i = 0; i < size; i++) {
		arr[i] = rand() % 1001 - 500;
	}
}

void create_array(int arr[][10], int size = 5, int size2 = 5) {
	for (int j = 0; j < size2; j++) {
		for (int i = 0; i < size; i++) {
			arr[j][i] = rand() % 1001 - 500;
		}
	}
}

void create_array(int arr[][10][10], int size = 5, int size2 = 5, int size3 = 5) {
	for (int z = 0; z < size3; z++) {
		for (int j = 0; j < size2; j++) {
			for (int i = 0; i < size; i++) {
				arr[z][j][i] = rand() % 1001 - 500;
			}
		}
	}
}

void output_array(int arr[], int size = 10) {
	for (int i = 0; i < size; i++) {
		cout << setw(6) << arr[i];
	}
	cout << endl;
}
void output_array(int arr[][10], int size = 5, int size2 = 5) {
	for (int j = 0; j < size2; j++) {
		for (int i = 0; i < size; i++) {
			cout << setw(6) << arr[j][i];
		}
		cout << endl;
	}
	cout << endl;
}
void output_array(int arr[][10][10], int size = 5, int size2 = 5, int size3 = 5) {
	for (int z = 0; z < size3; z++) {
		for (int j = 0; j < size2; j++) {
			for (int i = 0; i < size; i++) {
				cout << setw(6) << arr[z][j][i];
			}
			cout << endl;
		}
		cout << endl;
	}
	cout << endl;
}

int find_max(int arr[], int size = 10) {
	int sum = -501;
	for (int i = 0; i < size; i++) {
		if (arr[i] > sum) sum = arr[i];
	}
	return sum;
}
int find_max(int arr[][10], int size = 5, int size2 = 5) {
	int sum = -501;
	for (int j = 0; j < size2; j++) {
		for (int i = 0; i < size; i++) {
			if (arr[j][i] > sum) sum = arr[j][i];
		}
	}
	return sum;
}
int find_max(int arr[][10][10], int size = 5, int size2 = 5, int size3 = 5) {
	int sum = -501;
	for (int z = 0; z < size3; z++) {
		for (int j = 0; j < size2; j++) {
			for (int i = 0; i < size; i++) {
				if (arr[z][j][i] > sum) sum = arr[z][j][i];
			}
		}
	}
	return sum;
}

int find_max(int n1, int n2) {
	if (n1 > n2) return n1;
	else if (n1 < n2) return n2;
	else return 0;
}

int find_max(int n1, int n2, int n3) {
	if (n1 > n2 && n1 > n3) return n1;
	else if (n2 > n1 && n2 > n3) return n2;
	else if (n3 > n1 && n3 > n2) return n3;
	else return 0;
}

bool check(char a) {
	const int size = 20;
	char glasn[size] = { '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�' };
	for (int i = 0; i < size; i++) {
		if (a == glasn[i]) return 1;
	}
	return 0;
}

double physic(double r1, double r2, char a) {
	if (a == '1') return (r1 * r2) / (r1 + r2);
	else return r1 + r2;
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
					cout << "��������� �������������� �����\n";
					cout << "-------------------------------------------------------------------------------\n";
					int n1, n2;
					cout << "������� ������ �����: ";
					cin >> n1;
					cout << "������� ������ �����: ";
					cin >> n2;
					cout << endl << n1 << " " << comparision(n1, n2) << " " << n2;
					cout << endl << endl << "������ ��������� ������ ��������� ��� ���?\n1 - ��\t����� ������ ������ - ����� � ������� ����\n��� �����: ";
					cin >> sel;
				} while (sel == '1');
			}
					break;
			case 2: {
				char x;
				do {
					system("cls");
					cout << "-------------------------------------------------------------------------------\n";
					cout << "�������� �������������� �����/������������ ������\n";
					cout << "-------------------------------------------------------------------------------\n";
					cout << "1 - �������� �������������� �����\n";
					cout << "2 - �������� ����������� ������\n";
					do {
						cout << "��� �����: ";
						cin >> x;
					} while (x != '1' && x != '2');
					switch (x) {
					case '1':
						system("cls");
						cout << "-------------------------------------------------------------------------------\n";
						cout << "�������� �������������� �����\n";
						cout << "-------------------------------------------------------------------------------\n";
						double n1, n2;
						cout << "������� ������ �����: ";
						cin >> n1;
						cout << "������� ������ �����: ";
						cin >> n2;
						cout << "�����: " << sum(n1, n2);
						break;
					case '2':
						int x, y, x2, y2;
						char z, z2;
						system("cls");
						cout << "-------------------------------------------------------------------------------\n";
						cout << "�������� ������������ ������\n";
						cout << "-------------------------------------------------------------------------------\n";
						do {
							cout << "������� ������ �����(1/2): ";
							cin >> x >> z >> y;
						} while (z != '/');
						do {
							cout << "������� ������ �����(1/2): ";
							cin >> x2 >> z2 >> y2;
						} while (z != '/');
						sum(x, y, x2, y2);
						break;
					}

					cout << endl << endl << "������ ��������� ������ ��������� ��� ���?\n1 - ��\t����� ������ ������ - ����� � ������� ����\n��� �����: ";
					cin >> sel;
				} while (sel == '1');
			}
					break;
			case 3: {
				char x;
				do {
					system("cls");
					cout << "-------------------------------------------------------------------------------\n";
					cout << "���������� ������������� ��������\n";
					cout << "-------------------------------------------------------------------------------\n";
					cout << "1 - ���������� ������������� �������� � ���������� �������\n";
					cout << "2 - ���������� ������������� �������� � ��������� �������\n";
					cout << "3 - ���������� ������������� �������� � ���������� �������\n";
					cout << "4 - ���������� ������������� �������� ���� �����\n";
					cout << "5 - ���������� ������������� �������� ���� �����\n";
					do {
						cout << "��� �����: ";
						cin >> x;
					} while (x != '1' && x != '2' && x != '3' && x != '4' && x != '5');
					const int size = 10;
					int num1[size] = {};
					int num2[size][size] = {};
					int num3[size][size][size] = {};
					switch (x) {
					case '1':
						system("cls");
						cout << "-------------------------------------------------------------------------------\n";
						cout << "���������� ������������� �������� � ���������� �������\n";
						cout << "-------------------------------------------------------------------------------\n";
						create_array(num1);
						output_array(num1);
						cout << "\n������������ �������� � ���� ���������� �������: " << find_max(num1);
						break;
					case '2':
						system("cls");
						cout << "-------------------------------------------------------------------------------\n";
						cout << "���������� ������������� �������� � ��������� �������\n";
						cout << "-------------------------------------------------------------------------------\n";
						create_array(num2);
						output_array(num2);
						cout << "������������ �������� � ���� ��������� �������: " << find_max(num2);
						break;
					case '3':
						system("cls");
						cout << "-------------------------------------------------------------------------------\n";
						cout << "���������� ������������� �������� � ���������� �������\n";
						cout << "-------------------------------------------------------------------------------\n";
						create_array(num3);
						output_array(num3);
						cout << "������������ �������� � ���� ���������� �������: " << find_max(num3);
						break;
					case '4':
						system("cls");
						cout << "-------------------------------------------------------------------------------\n";
						cout << "���������� ������������� �������� ���� �����\n";
						cout << "-------------------------------------------------------------------------------\n";
						int n1, n2;
						cout << "������� ������ �����: ";
						cin >> n1;
						cout << "������� ������ �����: ";
						cin >> n2;
						(find_max(n1, n2) > 0) ? cout << "������������ �������� �� ���� �����: " << find_max(n1, n2) : cout << "��� ����� ����������";
						break;
					case '5':
						system("cls");
						cout << "-------------------------------------------------------------------------------\n";
						cout << "���������� ������������� �������� ���� �����\n";
						cout << "-------------------------------------------------------------------------------\n";
						int x1, x2, x3;
						cout << "������� ������ �����: ";
						cin >> x1;
						cout << "������� ������ �����: ";
						cin >> x2;
						cout << "������� ������ �����: ";
						cin >> x3;
						(find_max(x1, x2, x3) > 0) ? cout << "������������ �������� �� ���� �����: " << find_max(x1, x2, x3) : cout << "��� ����� ����������";
						break;
					}

					cout << endl << endl << "������ ��������� ������ ��������� ��� ���?\n1 - ��\t����� ������ ������ - ����� � ������� ����\n��� �����: ";
					cin >> sel;
				} while (sel == '1');
			}
					break;
			case 4: {
				do {
					system("cls");
					cout << "-------------------------------------------------------------------------------\n";
					cout << "�������� ������� �� ������� ����� �������� ��������\n";
					cout << "-------------------------------------------------------------------------------\n";
					char a;
					cout << "������� ������: ";
					cin >> a;
					(check(a) == 1) ? cout << "������ " << a << " �������� ������� ������ �������� ��������" : cout << "������ " << a << " �� �������� ������� ������ �������� ��������";
					cout << endl << endl << "������ ��������� ������ ��������� ��� ���?\n1 - ��\t����� ������ ������ - ����� � ������� ����\n��� �����: ";
					cin >> sel;
				} while (sel == '1');
			}
					break;
			case 5: {
				do {
					system("cls");
					cout << "-------------------------------------------------------------------------------\n";
					cout << "���������� ������������� ����\n";
					cout << "-------------------------------------------------------------------------------\n";
					char a;
					double r1, r2;
					do {
						cout << "������� ��� ����������(1 - ������������/2 - ����������������): ";
						cin >> a;
					} while (a != '1' && a != '2');
					cout << "������� ������������� ������� ���������: ";
					cin >> r1;
					cout << "������� ������������� ������� ���������: ";
					cin >> r2;
					cout << "������������� ���� ����� " << physic(r1, r2, a) << " ��";
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
		cout << "��������� �2\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------\n";
		if (k == 3) SetColor(10, 0);
		cout << "��������� �3\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------\n";
		if (k == 4) SetColor(10, 0);
		cout << "��������� �4\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------\n";
		if (k == 5) SetColor(10, 0);
		cout << "��������� �5\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------\n";
		if (k == 6) SetColor(10, 0);
		cout << "����� �� ���������\n";
		SetColor(15, 0);
		cout << "-------------------------------------------------------------------------------\n";
	} while (en = getch());
}
