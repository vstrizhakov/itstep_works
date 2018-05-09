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

void main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	SetColor(15, 0);
	srand(time(NULL));
	short k = 1, en = 0;
	do {
		if (en == 80) {
			k++;
			if (k == 5) k = 1;
		}
		if (en == 72) {
			k--;
			if (k == 0) k = 4;
		}
		if (en == 13) {
			FILE *path;
			switch (k) {
			case 1: {
				system("cls");
				path = fopen("logs.txt", "w");
				printf("���� ������ ��� ������\n");
				fprintf(path, "\t\t\t\t�������\t\t�������\t\t���������\n");
				int i = 0;
				for (i = 0; i <= 100; i += 5) {
					fprintf(path, "\t\t\t\t%d\t\t%.2f\t\t%.2f\n", i, i + 273.15, (i * 1.8) + 32);
				}
				if (i == 105) printf("��� ������ �������� � ���� �������\n");
				printf("���� ������\n");
				fclose(path);
				printf("������� ����� ������� ��� �����������...");				
				getch();
				break;
			}
			case 2: {
				system("cls");
				float usd, eur;
				path = fopen("logs.txt", "a");
				if (!path) printf("���� ������ ��� ��������\n");
				else {
					printf("���� ������ ��� ��������\n");
					printf("������� ���� ������ � �������: ");
					scanf("%f", &usd);
					printf("������� ����  ������ � ����: ");
					scanf("%f", &eur);
					fprintf(path, "\t\t\t\t1 uah = %.2f usd\t1 uah = %.2f eur\n", usd, eur);
					fprintf(path, "\t\t\t\tUAH\t\tUSD\t\tEUR\n");
					int i = 0;
					for (i = 5; i <= 100; i += 5) {
						fprintf(path, "\t\t\t\t%d\t\t%.2f\t\t%.2f\n", i, i / usd, i / eur);
					}
					if (i == 105) printf("��� ������ �������� � ���� �������\n");
					fclose(path);
					printf("���� ������\n");
				}
				printf("������� ����� ������� ��� �����������...");				
				getch();
				break;
			}
			case 3: {
				system("cls");
				path = fopen("logs.txt", "r");
				if (!path) printf("���� �� ������\n");
				else {
					printf("���� ������ ��� ������\n");
					char *get;
					char b[128];
					do {
						get = fgets(b, sizeof(b), path);
						if(get)	cout << b;
					} while (get);
					fclose(path);
					printf("���� ������\n");
				}
				printf("������� ����� ������� ��� �����������...");
				getch();
				break;
			}
			default:
				exit(0);
				break;
			}
		}
		system("cls");
		if (k == 1) SetColor(10, 0);
		printf("��������� ��������\n");
		SetColor(15, 0);
		if (k == 2) SetColor(10, 0);
		printf("��������� �����\n");
		SetColor(15, 0);
		if (k == 3) SetColor(10, 0);
		printf("��������� ����\n");
		SetColor(15, 0);
		if (k == 4) SetColor(10, 0);
		printf("�����\n");
		SetColor(15, 0);
	} while (en = getch());
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