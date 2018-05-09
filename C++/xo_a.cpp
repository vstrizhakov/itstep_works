#include <iostream>
#include <Windows.h>
#include <string>
#include <cstdlib>
#include <ctime>
#include <conio.h>

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

char xo[3][3] = { 3, 3, 3, 3, 3, 3, 3, 3, 3 };
string error[2] = { "Ошибка: такой клеточки не существует!",
					"Ошибка: данная клеточка уже занята!" };
short l = 0, rounds = 0, winr = 0, losr = 0, draw = 0, winr_1 = 0, winr_2 = 0, losr_1 = 0, losr_2 = 0, drawpl = 0, drawcom = 0, winrcom = 0, losrcom;

void xo_output(int k, string name, string name_1, string name_2, int h) {
	setlocale(LC_ALL, "rus");
	GotoXY(25, 0);
	SetColor(12, 0);
	cout << ">>>КРЕСТИКИ НОЛИКИ<<<\n";
	SetColor(11, 0);

	GotoXY(2, 1);
	cout << "--";
	GotoXY(4, 1);
	cout << "--";
	GotoXY(6, 1);
	cout << "-";

	GotoXY(1, 2);
	cout << "|";
	GotoXY(1, 4);
	cout << "|";
	GotoXY(1, 6);
	cout << "|";
	for (int i = 0; i < 3; i++) {
		for (int j = 0; j < 3; j++) {
			if (xo[i][j] == 3) {
				GotoXY(2 + j + j, 2 + i + i);
				cout << " ";
			}
			if (xo[i][j] == 1) {
				GotoXY(2 + j + j, 2 + i + i);
				cout << "x";
			}
			if (xo[i][j] == 2) {
				GotoXY(2 + j + j, 2 + i + i);
				cout << "o";
			}
			if (xo[i][j] == 5 || xo[i][j] == 6 || xo[i][j] == 7) {
				GotoXY(2 + j + j, 2 + i + i);
				SetColor(12, 0);
				cout << "+";
				SetColor(11, 0);
			}
			if (j != 0) {
				GotoXY(2 + j*1.5, 2 + i + i);
				cout << "|";
			}
		}
		if (i != 0) {
			GotoXY(2, 2 + i * 1.5);
			cout << "-----";
		}
	}
	GotoXY(2, 7);
	cout << "--";
	GotoXY(4, 7);
	cout << "--";
	GotoXY(6, 7);
	cout << "-";

	GotoXY(7, 2);
	cout << "|";
	GotoXY(7, 4);
	cout << "|";
	GotoXY(7, 6);
	cout << "|";
	SetColor(15, 0);

	switch (k) {
	case 1: {
		GotoXY(25, 4);
		cout << "Ход №" << h;
		if ((h - 1) % 2 == 0) {
			GotoXY(32, 4);
			cout << " игрока " << name_1 << " (x)";
		}
		else {
			GotoXY(32, 4);
			cout << " игрока " << name_2 << " (o)";
		}
	}
			break;
	case 2: {
		GotoXY(25, 4);
		cout << "Ход №" << h;
		if ((h - 1) % 2 == 0) {
			GotoXY(31, 4);
			cout << " игрока " << name << " (x)";
		}
	}
			break;
	}
}

void xo_null() {
	for (int i = 0; i < 3; i++) {
		for (int j = 0; j < 3; j++) {
			xo[i][j] = 3;
		}
	}
}

void xo_check(string name, string name_1, string name_2, int h, char sym, int i) {
	if (xo[0][0] == xo[0][1] && xo[0][1] == xo[0][2] && xo[0][2] != 3 ||
		xo[1][0] == xo[1][1] && xo[1][1] == xo[1][2] && xo[1][2] != 3 ||
		xo[2][0] == xo[2][1] && xo[2][1] == xo[2][2] && xo[2][2] != 3 ||
		xo[0][0] == xo[1][0] && xo[1][0] == xo[2][0] && xo[2][0] != 3 ||
		xo[0][1] == xo[1][1] && xo[1][1] == xo[2][1] && xo[2][1] != 3 ||
		xo[0][2] == xo[1][2] && xo[1][2] == xo[2][2] && xo[2][2] != 3 ||
		xo[0][0] == xo[1][1] && xo[1][1] == xo[2][2] && xo[2][2] != 3 ||
		xo[0][2] == xo[1][1] && xo[1][1] == xo[2][0] && xo[2][0] != 3) {
		system("cls");
		l++;
		string win;
		if (i == 1) {
			if ((h - 1) % 2 != 0) {
				win = name_1;
				winr_1++;
			}
			else {
				win = name_2;
				winr_2++;
			}
			winr++;
			losr++;
			xo_output(0, "", name_1, name_2, h);
		}
		else if (i == 2) {
			if ((h - 1) % 2 != 0) {
				win = name;
				winrcom++;
			}
			else {
				win = "компьютер";
				losrcom++;
			}
			winr++;
			losr++;
			xo_output(0, name, "", "", h);
		}
		GotoXY(25, 4);
		SetColor(10, 0);
		cout << "Победил " << win << " (" << sym << ")!\n";
		GotoXY(32, 5);
		cout << "Ходов: " << h - 1;
		SetColor(15, 0);
		do {
			GotoXY(0, 8);
			cout << "Нажмите enter клавишу, чтобы перейти в главное меню...";
		} while (getch() != 13);
		xo_null();
		rounds++;
	}
}

void xo_input(string name, string name_1, string name_2, int h, int sym) {
	int enter = 0, x = 1, y = 1;
	do {
		if (enter == 80) {
			y++;
			if (y == 4) y = 1;
		}
		if (enter == 72) {
			y--;
			if (y == 0) y = 3;
		}
		if (enter == 77) {
			x++;
			if (x == 4) x = 1;
		}
		if (enter == 75) {
			x--;
			if (x == 0) x = 3;
		}
		if (enter == 13) {
			if (xo[y - 1][x - 1] != 3) {
				system("cls");
				xo_output(1, "", name_1, name_2, h);
				GotoXY(0, 8);
				SetColor(12, 0);
				cout << error[1];
				SetColor(15, 0);
			}
			else {
				xo[y - 1][x - 1] = sym;
				break;
			}
		}
		xo[y - 1][x - 1] += 4;
		if (name == "") {
			xo_output(1, "", name_1, name_2, h);
		}
		else {
			xo_output(2, name, "", "", h);
		}		
		xo[y - 1][x - 1] -= 4;
	} while (enter = getch());
}

void main() {
	srand(time(NULL));
	SetColor(15, 0);
	setlocale(LC_ALL, "rus");
	string name = "", name_1 = "", name_2 = "";
MAIN:
	short k = 1;
	l = 0;
	int en = 0;
	do {

		if (en == 80) {
			k++;
			if (k == 4) k = 1;
		}
		if (en == 72) {
			k--;
			if (k == 0) k = 3;
		}
		if (en == 13) {
			system("cls");
			switch (k) {
			case 1: {
				short i = 0, j = 0, h = 1;
				system("cls");
				if (name_1 == "" && name_2 == "") {
					GotoXY(29, 0);
					SetColor(12, 0);
					cout << ">>>КРЕСТИКИ НОЛИКИ<<<\n";
					SetColor(12, 0);
					cout << "Пожалуйста, вводите все данные на английском языке!" << endl;
					SetColor(15, 0);
					cout << "Введите имя игрока (x): ";
					cin >> name_1;
					cout << "Введите имя игрока (o): ";
					cin >> name_2;
				}
			START:
				system("cls");
				xo_input("", name_1, name_2, h, 1);
				h++;
				xo_check("", name_1, name_2, h, 'x', 1);
				if (l != 0) goto MAIN;
				short count = 0;
				for (int j = 0; j <= 2; j++) {
					for (int i = 0; i <= 2; i++) {
						if (xo[j][i] != 3) count++;
					}
				}
				if (count == 9) {
					system("cls");
					xo_output(0, "", name_1, name_2, h);
					GotoXY(30, 4);
					SetColor(10, 0);
					cout << "НИЧЬЯ!\n";
					SetColor(15, 0);
					draw++;
					drawpl++;
					do {
						GotoXY(0, 8);
						cout << "Нажмите enter клавишу, чтобы перейти в главное меню...";
					} while (getch() != 13);
					xo_null();
					rounds++;
				}
				else {
					system("cls");
					xo_input("", name_1, name_2, h, 2);
					h++;
					xo_check("", name_1, name_2, h, 'o', 1);
					if (l != 0) goto MAIN;
					system("cls");
					goto START;
				}
			}
					break;
			case 2: {
				short order = 1;
				en = 0;
				do {
					if (en == 80) {
						order++;
						if (order == 5) order = 1;
					}
					if (en == 72) {
						order--;
						if (order == 0) order = 4;
					}
					if (en == 13) {
						short i = 0, j = 0, h = 1;
						if (name == "") {
							system("cls");
							GotoXY(29, 0);
							SetColor(12, 0);
							cout << ">>>КРЕСТИКИ НОЛИКИ<<<\n";
							SetColor(12, 0);
							cout << "Пожалуйста, вводите все данные на английском языке!" << endl;
							SetColor(15, 0);
							cout << "Введите ваше имя: ";
							cin >> name;
						}
						system("cls");

					START_2:
						xo_input(name, "", "", h, 1);
						h++;
						xo_check(name, "", "", h, 'x', 2);
						if (l != 0) goto MAIN;
						short count = 0;
						for (int j = 0; j <= 2; j++) {
							for (int i = 0; i <= 2; i++) {
								if (xo[j][i] != 3) count++;
							}
						}
						if (count == 9) {
							system("cls");
							xo_output(0, name, "", "", h);
							GotoXY(30, 4);
							SetColor(10, 0);
							cout << "НИЧЬЯ!\n";
							SetColor(15, 0);
							draw++;
							drawcom++;
							do {
								GotoXY(0, 8);
								cout << "Нажмите enter клавишу, чтобы перейти в главное меню...";
							} while (getch() != 13);
							xo_null();
							rounds++;
						}
						else {
							int life = rand() % 100 + 1;
							if (life <= 70 && order == 1) {
								goto GEN;
							}
							if (life <= 50 && order == 2) {
								goto GEN;
							}
							if (life <= 30 && order == 3) {
								goto GEN;
							}
							if (life <= 10 && order == 4) {
								goto GEN;
							}
							if ((xo[0][0] == xo[0][1] || xo[0][1] == xo[0][2] || xo[0][0] == xo[0][2]) && ((xo[0][0] != 3 && xo[0][1] != 3) || (xo[0][2] != 3 && xo[0][1] != 3) || (xo[0][0] != 3 && xo[0][2] != 3)) && (xo[0][0] != 1 && xo[0][1] != 1 && xo[0][2] != 1)) {
								for (int i = 0; i < 3; i++) xo[0][i] = 2;
							}
							else if ((xo[1][0] == xo[1][1] || xo[1][1] == xo[1][2] || xo[1][0] == xo[1][2]) && ((xo[1][0] != 3 && xo[1][1] != 3) || (xo[1][1] != 3 && xo[1][2] != 3) || (xo[1][0] != 3 && xo[1][2] != 3)) && (xo[1][0] != 1 && xo[1][1] != 1 && xo[1][2] != 1)) {
								for (int i = 0; i < 3; i++) xo[1][i] = 2;
							}
							else if ((xo[2][0] == xo[2][1] || xo[2][1] == xo[2][2] || xo[2][0] == xo[2][2]) && ((xo[2][0] != 3 && xo[2][1] != 3) || (xo[2][2] != 3 && xo[2][1] != 3) || (xo[2][0] != 3 && xo[2][2] != 3)) && (xo[2][0] != 1 && xo[2][1] != 1 && xo[2][2] != 1)) {
								for (int i = 0; i < 3; i++) xo[2][i] = 2;
							}
							else if ((xo[0][0] == xo[1][0] || xo[1][0] == xo[2][0] || xo[0][0] == xo[2][0]) && ((xo[0][0] != 3 && xo[1][0] != 3) || (xo[2][0] != 3 && xo[1][0] != 3) || (xo[0][0] != 3 && xo[2][0] != 3)) && (xo[0][0] != 1 && xo[1][0] != 1 && xo[2][0] != 1)) {
								for (int i = 0; i < 3; i++) xo[i][0] = 2;
							}
							else if ((xo[0][1] == xo[1][1] || xo[1][1] == xo[2][1] || xo[0][1] == xo[2][1]) && ((xo[0][1] != 3 && xo[1][1] != 3) || (xo[2][1] != 3 && xo[1][1] != 3) || (xo[0][1] != 3 && xo[2][1] != 3)) && (xo[0][1] != 1 && xo[1][1] != 1 && xo[2][1] != 1)) {
								for (int i = 0; i < 3; i++) xo[i][1] = 2;
							}
							else if ((xo[0][2] == xo[1][2] || xo[1][2] == xo[2][2] || xo[0][2] == xo[2][2]) && ((xo[0][2] != 3 && xo[1][2] != 3) || (xo[2][2] != 3 && xo[1][2] != 3) || (xo[0][2] != 3 && xo[2][2] != 3)) && (xo[0][2] != 1 && xo[2][2] != 1 && xo[1][2] != 1)) {
								for (int i = 0; i < 3; i++) xo[i][2] = 2;
							}
							else if ((xo[0][0] == xo[1][1] || xo[1][1] == xo[2][2] || xo[0][0] == xo[2][2]) && ((xo[0][0] != 3 && xo[1][1] != 3) || (xo[1][1] != 3 && xo[2][2] != 3) || (xo[0][0] != 3 && xo[2][2] != 3)) && (xo[0][0] != 1 && xo[1][1] != 1 && xo[2][2] != 1)) {
								for (int i = 0; i < 3; i++) xo[i][i] = 2;
							}
							else if ((xo[0][2] == xo[1][1] || xo[1][1] == xo[2][0] || xo[0][2] == xo[2][0]) && ((xo[0][2] != 3 && xo[1][1] != 3) || (xo[2][0] != 3 && xo[0][2] != 3) || (xo[2][0] != 3 && xo[1][1] != 3)) && (xo[0][2] != 1 && xo[1][1] != 1 && xo[2][0] != 1)) {
								if (xo[0][2] != 1) xo[0][2] = 2;
								if (xo[1][1] != 1) xo[1][1] = 2;
								if (xo[2][0] != 1) xo[2][0] = 2;
							}
							else {
								if ((xo[0][0] == xo[0][1] || xo[0][1] == xo[0][2] || xo[0][0] == xo[0][2]) && ((xo[0][0] != 3 && xo[0][1] != 3) || (xo[0][2] != 3 && xo[0][1] != 3) || (xo[0][0] != 3 && xo[0][2] != 3)) && (xo[0][0] != 2 && xo[0][1] != 2 && xo[0][2] != 2)) {
									for (int i = 0; i < 3; i++) {
										if (xo[0][i] != 1) xo[0][i] = 2;
									}
								}
								else if ((xo[1][0] == xo[1][1] || xo[1][1] == xo[1][2] || xo[1][0] == xo[1][2]) && ((xo[1][0] != 3 && xo[1][1] != 3) || (xo[1][1] != 3 && xo[1][2] != 3) || (xo[1][0] != 3 && xo[1][2] != 3)) && (xo[1][0] != 2 && xo[1][1] != 2 && xo[1][2] != 2)) {
									for (int i = 0; i < 3; i++) {
										if (xo[1][i] != 1) xo[1][i] = 2;
									}
								}
								else if ((xo[2][0] == xo[2][1] || xo[2][1] == xo[2][2] || xo[2][0] == xo[2][2]) && ((xo[2][0] != 3 && xo[2][1] != 3) || (xo[2][2] != 3 && xo[2][1] != 3) || (xo[2][0] != 3 && xo[2][2] != 3)) && (xo[2][0] != 2 && xo[2][1] != 2 && xo[2][2] != 2)) {
									for (int i = 0; i < 3; i++) {
										if (xo[2][i] != 1) xo[2][i] = 2;
									}
								}
								else if ((xo[0][0] == xo[1][0] || xo[1][0] == xo[2][0] || xo[0][0] == xo[2][0]) && ((xo[0][0] != 3 && xo[1][0] != 3) || (xo[2][0] != 3 && xo[1][0] != 3) || (xo[0][0] != 3 && xo[2][0] != 3)) && (xo[0][0] != 2 && xo[1][0] != 2 && xo[2][0] != 2)) {
									for (int i = 0; i < 3; i++) {
										if (xo[i][0] != 1) xo[i][0] = 2;
									}
								}
								else if ((xo[0][1] == xo[1][1] || xo[1][1] == xo[2][1] || xo[0][1] == xo[2][1]) && ((xo[0][1] != 3 && xo[1][1] != 3) || (xo[2][1] != 3 && xo[1][1] != 3) || (xo[0][1] != 3 && xo[2][1] != 3)) && (xo[0][1] != 2 && xo[1][1] != 2 && xo[2][1] != 2)) {
									for (int i = 0; i < 3; i++) {
										if (xo[i][1] != 1) xo[i][1] = 2;
									}
								}
								else if ((xo[0][2] == xo[1][2] || xo[1][2] == xo[2][2] || xo[0][2] == xo[2][2]) && ((xo[0][2] != 3 && xo[1][2] != 3) || (xo[2][2] != 3 && xo[1][2] != 3) || (xo[0][2] != 3 && xo[2][2] != 3)) && (xo[0][2] != 2 && xo[2][2] != 2 && xo[1][2] != 2)) {
									for (int i = 0; i < 3; i++) {
										if (xo[i][2] != 1) xo[i][2] = 2;
									}
								}
								else if ((xo[0][0] == xo[1][1] || xo[1][1] == xo[2][2] || xo[0][0] == xo[2][2]) && ((xo[0][0] != 3 && xo[1][1] != 3) || (xo[1][1] != 3 && xo[2][2] != 3) || (xo[0][0] != 3 && xo[2][2] != 3)) && (xo[0][0] != 2 && xo[1][1] != 2 && xo[2][2] != 2)) {
									for (int i = 0; i < 3; i++) {
										if (xo[i][i] != 1) xo[i][i] = 2;
									}
								}
								else if ((xo[0][2] == xo[1][1] || xo[1][1] == xo[2][0] || xo[0][2] == xo[2][0]) && ((xo[0][2] != 3 && xo[1][1] != 3) || (xo[2][0] != 3 && xo[0][2] != 3) || (xo[2][0] != 3 && xo[1][1] != 3)) && (xo[0][2] != 2 && xo[1][1] != 2 && xo[2][0] != 2)) {
									if (xo[0][2] != 1) xo[0][2] = 2;
									if (xo[1][1] != 1) xo[1][1] = 2;
									if (xo[2][0] != 1) xo[2][0] = 2;
								}
								else {
								GEN:
									int j = rand() % 3;
									int i = rand() % 3;
									if (xo[j][i] != 1 && xo[j][i] != 2) {
										xo[j][i] = 2;
									}
									else {
										GotoXY(30, 5);
										goto GEN;
									}
								}
							}

							xo_check(name, "", "", h, 'o', 2);
							if (l != 0) goto MAIN;
							h++;
							system("cls");
							goto START_2;
						}
					}
					system("cls");
					GotoXY(29, 0);
					SetColor(12, 0);
					cout << ">>>КРЕСТИКИ НОЛИКИ<<<";
					SetColor(15, 0);
					GotoXY(36, 1);
					if (order == 1) SetColor(10, 0);
					cout << "Легкий";
					SetColor(15, 0);
					GotoXY(36, 2);
					if (order == 2) SetColor(10, 0);
					cout << "Средний";
					SetColor(15, 0);
					GotoXY(36, 3);
					if (order == 3) SetColor(10, 0);
					cout << "Сложный";
					SetColor(15, 0);
					GotoXY(35, 4);
					if (order == 4) SetColor(10, 0);
					cout << "Нереальный";
					SetColor(15, 0);
				} while (en = getch());
			}
					break;
			default: {
				system("cls");
				GotoXY(29, 0);
				SetColor(12, 0);
				cout << ">>>КРЕСТИКИ НОЛИКИ<<<" << endl;
				SetColor(15, 0);
				if (rounds > 0) {
					SetColor(11, 0);
					cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Статистика~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
					SetColor(15, 0);
					cout << "Игр сыграно: " << rounds << endl;
					cout << "Всего побед: " << winr << endl;
					cout << "Всего поражений: " << losr << endl;
					cout << "Всего ничьих: " << draw << endl;
					cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
					if (name != "") {
						cout << "Побед игрока " << name << " против компьютера: " << winrcom << endl;
						cout << "Проигрышей игрока " << name << " против компьютера: " << losrcom << endl;
						cout << "Ничьих в игре против компьютера: " << drawcom << endl;
						cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
					}
					if (name_1 != "" && name_2 != "") {
						cout << "Побед игрока " << name_1 << " против игрока " << name_2 << ": " << winr_1 << endl;
						cout << "Побед игрока " << name_2 << " против игрока " << name_1 << ": " << winr_2 << endl;
						cout << "Ничьих в игре друг против друга: " << drawpl << endl;
						cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
					}
				}
				GotoXY(25, 15);
				cout << "Вы точно хотите выйти?" << endl;
				k = 1;
				en = 0;
				do {
					if (en == 77) {
						k++;
						if (k == 3) k = 1;
					}
					if (en == 75) {
						k--;
						if (k == 0) k = 2;
					}
					if (en == 13) {
						switch (k) {
						case 1:
							GotoXY(28, 17);
							cout << "Выход через ";
							for (int i = 0; i < 3; i++) {
								GotoXY(40, 17);
								cout << 3 - i << "...";
								Sleep(1000);
							}
							cout << endl;
							exit(1);
							break;
						case 2:
							goto MAIN;
							break;
						}
					}
					GotoXY(30, 16);
					if (k == 1) SetColor(10, 0);
					cout << "Да";
					SetColor(15, 0);
					GotoXY(37, 16);
					if (k == 2) SetColor(10, 0);
					cout << "Нет";
					SetColor(15, 0);

				} while (en = getch());
			}
					 break;
			}
		}
		system("cls");
		GotoXY(29, 0);
		SetColor(12, 0);
		cout << ">>>КРЕСТИКИ НОЛИКИ<<<";
		GotoXY(30, 1);
		SetColor(11, 0);
		cout << "Выберите режим игры";
		SetColor(15, 0);
		GotoXY(30, 2);
		if (k == 1) SetColor(10, 0);
		cout << "Игрок против игрока";
		SetColor(15, 0);
		GotoXY(28, 3);
		if (k == 2) SetColor(10, 0);
		cout << "Игрок против компьютера";
		SetColor(15, 0);
		GotoXY(37, 4);
		if (k == 3) SetColor(10, 0);
		cout << "Выход";
		SetColor(15, 0);
	} while (en = getch());
}