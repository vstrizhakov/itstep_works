#include <iostream>
#include <Windows.h>
#include <conio.h>
#include <string.h>
#include <stdio.h>
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

void check_fail() {
	if (cin.fail()) {
		cin.clear();
		cin.ignore(cin.rdbuf()->in_avail());
	}
	else {
		cin.ignore(cin.rdbuf()->in_avail());
	}
}

void gen_a(int arr[][8]) {
	int c = 0;
	for (int j = 0; j < 8; j++) {
		for (int i = 0; i < 8; i++) {
			if (j <= i) arr[j][i] = rand() % 91 + 9;
		}
	}
}

void gen_b(int arr[][8]) {
	for (int j = 0; j < 8; j++) {
		for (int i = 0; i < 8; i++) {
			if (j < 8 - i) arr[j][i] = rand() % 91 + 9;
		}
	}
}

void gen(int arr[][10]) {
	for (int j = 0; j < 10; j++) {
		for (int i = 0; i < 10; i++) {
			arr[j][i] = rand() % 91 + 9;
		}
	}
}

void output(int arr[][8]) {
	for (int j = 0; j < 8; j++) {
		for (int i = 0; i < 8; i++) {
			if (arr[j][i] != 0) cout << setw(3) << arr[j][i];
			else cout << setw(3) << " ";
		}
		cout << endl;
	}
	cout << endl;
}

int find_max(int arr[][8]) {
	int sum = 0;
	for (int j = 0; j < 8; j++) {
		for (int i = 0; i < 8; i++) {
			if (arr[j][i] > sum) sum = arr[j][i];
		}
	}
	return sum;
}

void main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	SetColor(15, 0);
	srand(time(NULL));
	short k = 1, en = 0;
	char s;
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
			switch (k) {
			case 1: {
				do {
					system("cls");
					const int x = 8;
					int A[x][x] = {}, B[x][x] = {};
					gen_a(A);
					gen_b(B);
					printf("Вариант А:\n");
					output(A);
					printf("Самое большое значение: %d\n\n", find_max(A));
					printf("Вариант Б:\n");
					output(B);
					printf("Самое большое значение: %d\n\n", find_max(B));
					printf("0 - Запустить эту программу еще раз\nЛюбой другой символ - Выход из программы\nВаш выбор: ");
					cin >> s;
				} while (s == '0');
				break;
			}
			case 2: {
				do {
					system("cls");
					int arr[10][10] = {};
					gen(arr);
					printf("Оригинальный массив:\n");
					for (int j = 0; j < 10; j++) {
						for (int i = 0; i < 10; i++) {
							printf("%3d", arr[j][i]);
						}
						cout << endl;
					}
					cout << endl;
					printf("Транспонированный массив:\n");
					for (int j = 0; j < 10; j++) {
						for (int i = 0; i < 10; i++) {
							printf("%3d", arr[i][j]);
						}
						cout << endl;
					}
					cout << endl;
					printf("0 - Запустить эту программу еще раз\nЛюбой другой символ - Выход из программы\nВаш выбор: ");
					cin >> s;
				} while (s == '0');
				break;
			}
			case 3: {
				do {
					system("cls");
					int arr[10][10] = {};
					int s = 900, t = 0;
					for (int j = 0; j < 10; j++) {
						for (int i = 0; i < 10; i++) {
							for (s;; s++) {
								t = 0;
								for (int o = 2; o < s; o++) {
									if (s % o == 0) {
										t++;
										break;
									}
								}
								if (t == 0) {
									arr[j][i] = s;
									s++;
									break;
								}
							}
						}
					}
					printf("Простые числа начиная с 900(матрица 10 на 10):\n");
					for (int j = 0; j < 10; j++) {
						for (int i = 0; i < 10; i++) {
							printf("%6d", arr[j][i]);
						}
						printf("\n");
					}
					printf("0 - Запустить эту программу еще раз\nЛюбой другой символ - Выход из программы\nВаш выбор: ");
					cin >> s;
				} while (s == '0');
				break;
			}
			case 4: {
				do {
					system("cls");
					double rain[20] = {};
					double avg[10] = {}, sum = 0;
					for (int i = 0; i < 20; i++) {
						rain[i] = rand() % 100 + 1;
					}
					for (int i = 0, j = 0; i < 19; i += 2, j++) {
						avg[j] = (rain[i] + rain[i + 1]) / 2;
						sum += avg[j];
					}
					sum /= 10;
					printf("\t\tОсадки в Киеве за 10 лет\n\n");
					printf("Среднее кол-во осадков за 10 лет: %.2F\n\n", sum);
					printf("\tянварь-июнь\tиюль-декабрь\tсреднее\n");
					for (int i = 0, j = 0; i < 19; i += 2, j++) {
						printf("%d\t%2.F(%3.2F)\t%2.F(%3.2F)\t%3.1F\n", j + 1, rain[i], rain[i] - sum, rain[i + 1], rain[i + 1] - sum, avg[j]);
					}
					printf("0 - Запустить эту программу еще раз\nЛюбой другой символ - Выход из программы\nВаш выбор: ");
					cin >> s;
				} while (s == '0');
				break;
			}
			case 5: {
				do {
					system("cls");
					const int x = 5;
					int g[x][x] = {};
					for (int j = 0; j < x; j++) {
						for (int i = 0; i < x; i++) {
							g[j][i] = rand() % 41 - 20;
						}
					}
					int a[x*x];
					int b[x*x];
					int aa = 0, ba = 0;
					for (int j = 0; j < x; j++) {
						for (int i = 0; i < x; i++) {
							if (g[j][i] > 0) {
								a[aa] = g[j][i];
								aa++;
							}
							if (g[j][i] < 0) {
								b[ba] = g[j][i];
								ba++;
							}
						}
					}
					int amax = 0, bmin = 0;
					for (int i = 0; i < aa; i++) {
						if (a[i] > a[amax]) amax = i;
					}
					for (int i = 0; i < ba; i++) {
						if (b[i] < b[bmin]) bmin = i;
					}
					printf("Массив А:\n");
					for (int j = 0; j < x; j++) {
						for (int i = 0; i < x; i++) {
							printf("%4d", g[j][i]);
						}
						printf("\n");
					}
					printf("Массив B:\n");
					for (int i = 0; i < aa; i++) {
						if (i == amax) SetColor(10, 0);
						printf("%4d", a[i]);
						SetColor(15, 0);
					}
					printf("\n");
					printf("Массив C:\n");
					for (int i = 0; i < ba; i++) {
						if (i == bmin) SetColor(12, 0);
						printf("%4d", b[i]);
						SetColor(15, 0);
					}
					printf("\n");
					printf("0 - Запустить эту программу еще раз\nЛюбой другой символ - Выход из программы\nВаш выбор: ");
					cin >> s;
				} while (s == '0');
				break;
			}
			default:
				exit(0);
				break;
			}
		}
		system("cls");
		if (k == 1) SetColor(10, 0);
		printf("Задание 1\n");
		SetColor(15, 0);
		if (k == 2) SetColor(10, 0);
		printf("Задание 2\n");
		SetColor(15, 0);
		if (k == 3) SetColor(10, 0);
		printf("Задание 3\n");
		SetColor(15, 0);
		if (k == 4) SetColor(10, 0);
		printf("Задание 4\n");
		SetColor(15, 0);
		if (k == 5) SetColor(10, 0);
		printf("Задание 5\n");
		SetColor(15, 0);
		if (k == 6) SetColor(10, 0);
		printf("Выход\n");
		SetColor(15, 0);
	} while (en = getch());
}