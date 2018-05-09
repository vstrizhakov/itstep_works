#include <iostream>
#include <Windows.h>
#include <conio.h>
#include <string.h>
#include <stdio.h>
#include <cstdlib>
#include <ctime>
#include <iomanip>	

using namespace std;

void SetColor(int text, int background);
void GotoXY(int X, int Y);

void reverse(char *string) {
	for (int j = 1; j < strlen(string); j++) {
		for (int i = 0; i < strlen(string) - j; i++) {
			int temp = *(string + i);
			*(string + i) = *(string + i + 1);
			*(string + i + 1) = temp;
		}
	}
}

void main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	SetColor(15, 0);

	char string[100] = {}, line[100] = {}, string1[100] = {}, string2[100] = {}, key, *result;
	int numresult;
	cout << "===============================================================================\n";
	cout << "������� 1\n";
	cout << "===============================================================================\n";
	cout << "������� �����: ";
	gets_s(string);
	strcpy_s(line, string);
	reverse(string);
	cout << "����� ��������: " << string << endl;
	int error = 0;
	for (int i = 0; i < strlen(string) && error == 0; i++) {
		if (string[i] != line[i]) error++;
		if (i == strlen(string) - 1 && error == 0) cout << "����� " << string << " �������� �����������" << endl;
	}
	if (error > 0) cout << "����� " << line << " �� �������� �����������" << endl;
	cout << "===============================================================================\n";
	cout << "������� 2.1\n";
	cout << "===============================================================================\n";
	cout << "������� ������ ������: ";
	gets_s(string1);
	cout << "������� ������ ������: ";
	gets_s(string2);
	strcpy_s(string, string1);
	strcat_s(string, " ");
	strcat_s(string, string2);
	cout << "����������� ������: " << string << endl;
	cout << "===============================================================================\n";
	cout << "������� 2.2\n";
	cout << "===============================================================================\n";
	cout << "������� ������: ";
	gets_s(string);
	cout << "�������, ��� ������ ���� ����������: ";
	cin >> key;
	result = strchr(string, key);
	cout << "������, � ������� ������ ��� ���� ���������� \"" << key << "\": " << result << endl;
	cin.ignore();
	cout << "===============================================================================\n";
	cout << "������� 2.3\n";
	cout << "===============================================================================\n";
	cout << "������� ������ ������: ";
	gets_s(string);
	cout << "������� ������ ������: ";
	gets_s(line);
	numresult = strcmp(string, line);
	if (numresult == 0) cout << "������ ����� �� �������� ����" << endl;
	else if (numresult == 1) cout << "������ \"" << string << "\" ������ ������ \"" << line << "\" �� �������� ����" << endl;
	else if (numresult == -1) cout << "������ \"" << string << "\" ������ ������ \"" << line << "\" �� �������� ����" << endl;
	cout << "===============================================================================\n";
	cout << "������� 2.4\n";
	cout << "===============================================================================\n";
	cout << "������� ������ ������: ";
	gets_s(string);
	cout << "������� ������ ������: ";
	gets_s(line);
	numresult = _strcmpi(string, line);
	if (numresult == 0) cout << "������� ����� �� �������� ����" << endl;
	else if (numresult > 0) cout << "������ \"" << string[0] << "\" ������ ������� \"" << line[0] << "\" �� �������� ���� �� " << numresult << endl;
	else if (numresult < 0) cout << "������ \"" << string[0] << "\" ������ ������� \"" << line[0] << "\" �� �������� ���� �� " << numresult * -1 << endl;
	cout << "===============================================================================\n";
	cout << "������� 2.5\n";
	cout << "===============================================================================\n";
	cout << "������� ������: ";
	gets_s(string);
	strcpy_s(line, string);
	cout << "������������� ������: " << line << endl;
	cout << "===============================================================================\n";
	cout << "������� 2.6\n";
	cout << "===============================================================================\n";
	cout << "������� ������: ";
	gets_s(string);
	cout << "������� �������, ������� ����� �����: ";
	gets_s(line);
	int r = strcspn(string, line);
	if (r == strlen(string)) cout << "�� ���� �� ���� �������� �� ������" << endl;
	else cout << "������ " << string[r] << " ������ � " << r + 1<< " ������" << endl;
	cout << "===============================================================================\n";
	cout << "������� 2.7\n";
	cout << "===============================================================================\n";
	cout << "������� ������: ";
	gets_s(string);
	result = _strdup(string);
	cout << "������������� ������: " << result << endl;
	free(result);
	cout << "===============================================================================\n";
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