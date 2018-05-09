#include <iostream>
#include <Windows.h>
#include <conio.h>
#include <string.h>
#include <stdio.h>
#include <cstdlib>
#include <ctime>
#include <iomanip>
#include <io.h>
#include <fcntl.h>

using namespace std;

struct level {
	int x;
	int y;
	int mines;
} levels[4] = { { 8, 4, 5 },{ 9, 9, 10 },{ 15, 15, 35 } };

void SetColor(int text, int background);
void GotoXY(int X, int Y);

void check_fail() {
	if (cin.fail()) {
		cin.clear();
	}
	cin.ignore(cin.rdbuf()->in_avail());
}

template <typename type>
type **init_memory(type sym, short sizex, short sizey) {
	type **arr = new type*[sizey];
	for (int i = 0; i < sizey; i++) {
		*(arr + i) = new type[sizex];
	}
	for (int j = 0; j < sizey; j++) {
		for (int i = 0; i < sizex; i++) {
			*(*(arr + j) + i) = 0;
		}
	}
	return arr;
}

template <typename type>
void delete_memory(type **arr, short sizey) {
	for (int i = 0; i < sizey; i++) {
		delete[] * (arr + i);
	}
	delete[] arr;
}

void output_area(char **area, short **area2, short sizex, short sizey, short x, short y, short uc) {
	if (uc == 7 || uc == 8) uc += 2;
	else if (uc < 7) uc -= 1;
	SetColor(7, 8);
	for (int o = 0; o < sizex; o++) {
		if (o == 0) wprintf(L"\u250f\u2501\u2501\u2533");
		if (o > 0 && o < sizex - 1) wprintf(L"\u2501\u2501\u2533");
		if (o == sizex - 1) wprintf(L"\u2501\u2501\u2513");
	}
	wprintf(L"\n\u2503");
	for (int j = 0; j < sizey; j++) {
		for (int i = 0; i < sizex; i++) {
			if (i == 0 && j != 0) {
				SetColor(7, 8);
				wprintf(L"\u2523");
			}
			if (i == 0 && j > 0 && j < sizey) {
				SetColor(7, 8);
				for (int o = 0; o < sizex; o++) {
					if (o == 0) wprintf(L"\u2501\u2501");
					if (o > 0 && o < sizex - 1) wprintf(L"\u254B\u2501\u2501");
					if (o == sizex - 1) wprintf(L"\u254B\u2501\u2501\u252B\n\u2503");
				}
			}
			if (j == y && i == x) {
				if (i == 0) {
					SetColor(0, uc);
					if (*(*(area2 + j) + i) > 0 && *(*(area + j) + i) == 2) wprintf(L"%d ", *(*(area2 + j) + i));
					else if ();
					else wprintf(L"  ");
					SetColor(7, 8);
				}
				if (i > 0 && i < sizex - 1) {
					wprintf(L"\u2503");
					SetColor(0, uc);
					if (*(*(area2 + j) + i) > 0 && *(*(area + j) + i) == 2) wprintf(L"%d ", *(*(area2 + j) + i));
					else wprintf(L"  ");
					SetColor(7, 8);
				}
				if (i == sizex - 1) {
					wprintf(L"\u2503");
					SetColor(0, uc);
					if (*(*(area2 + j) + i) > 0 && *(*(area + j) + i) == 2) wprintf(L"%d ", *(*(area2 + j) + i));
					else wprintf(L"  ");
					SetColor(7, 8);
				}
			}
			else if (*(*(area + j) + i) < 2) {
				if (i == 0) {
					if (*(*(area2 + j) + i) > 0 && *(*(area + j) + i) == 2) {
						SetColor(8, 7);
						wprintf(L"%d", *(*(area2 + j) + i));
						SetColor(7, 8);
						wprintf(L"\u2503");
					}
					else {
						SetColor(8, 7);
						wprintf(L"  ");
						SetColor(7, 8);
					}
				}
				if (i > 0 && i < sizex - 1) {
					if (*(*(area2 + j) + i) > 0 && *(*(area + j) + i) == 2) {
						SetColor(8, 7);
						wprintf(L"\u2503");
						SetColor(7, 8);
						wprintf(L"%d", *(*(area2 + j) + i));
						SetColor(8, 7);
						wprintf(L"\u2503");
					}
					else {
						wprintf(L"\u2503");
						SetColor(8, 7);
						wprintf(L"  ");
						SetColor(7, 8);
					}
				}
				if (i == sizex - 1) {
					if (*(*(area2 + j) + i) > 0 && *(*(area + j) + i) == 2) {
						wprintf(L"\u2503%d", *(*(area2 + j) + i));
					}
					else {
						wprintf(L"\u2503");
						SetColor(8, 7);
						wprintf(L"  ");
						SetColor(7, 8);
					}
				}
			}
			else if (*(*(area + j) + i) == 4 || *(*(area + j) + i) == 5) {
				if (i == 0) {
					SetColor(12, 8);
					wprintf(L"P ");
					SetColor(7, 8);
				}
				if (i > 0 && i < sizex - 1) {
					SetColor(7, 8);
					wprintf(L"\u2503");
					SetColor(12, 8);
					wprintf(L"P ");
					SetColor(7, 8);
				}
				if (i == sizex - 1) {
					SetColor(7, 8);
					wprintf(L"\u2503");
					SetColor(12, 8);
					wprintf(L"P ");
					SetColor(7, 8);
				}
			}
			else if (*(*(area + j) + i) == 6 || *(*(area + j) + i) == 7) {
				if (i == 0) {
					(*(*(area + j) + i) == 6) ? SetColor(0, 7) : SetColor(12, 7);
					wprintf(L"\u25CF ");
				}
				if (i > 0 && i < sizex - 1) {
					SetColor(7, 8);
					wprintf(L"\u2503");
					(*(*(area + j) + i) == 6) ? SetColor(0, 7) : SetColor(12, 7);
					wprintf(L"\u25CF ");
				}
				if (i == sizex - 1) {
					SetColor(7, 8);
					wprintf(L"\u2503");
					(*(*(area + j) + i) == 6) ? SetColor(0, 7) : SetColor(12, 7);
					wprintf(L"\u25CF ");
				}
				SetColor(7, 8);
			}
			else {
				if (i == 0) {
					SetColor(0, 8);
					if (*(*(area2 + j) + i) > 0) wprintf(L"%d ", *(*(area2 + j) + i));
					else wprintf(L"  ");
					SetColor(7, 8);
				}
				if (i > 0 && i < sizex - 1) {
					SetColor(7, 8);
					wprintf(L"\u2503");
					SetColor(0, 8);
					if (*(*(area2 + j) + i) > 0)  wprintf(L"%d ", *(*(area2 + j) + i));
					else wprintf(L"  ");
					SetColor(7, 8);
				}
				if (i == sizex - 1) {
					SetColor(7, 8);
					wprintf(L"\u2503");
					SetColor(0, 8);
					if (*(*(area2 + j) + i) > 0) wprintf(L"%d ", *(*(area2 + j) + i));
					else wprintf(L"  ");
					SetColor(7, 8);
				}
			}
			if (i == sizex - 1 && j < sizey - 1) {
				SetColor(7, 8);
				wprintf(L"\u2503");
			}
		}
		if (j != sizey - 1) wprintf(L"\n");
	}
	SetColor(7, 8);
	wprintf(L"\u2503\n");
	for (int o = 0; o < sizex; o++) {
		if (o == 0) wprintf(L"\u2517\u2501\u2501\u253B");
		if (o > 0 && o < sizex - 1) wprintf(L"\u2501\u2501\u253B");
		if (o == sizex - 1) wprintf(L"\u2501\u2501\u251B");
	}
	wprintf(L"\n");
	SetColor(15, 0);
}

void check_empty(char **area, short **area2, short sizex, short sizey, short x, short y, short &free) {
	free--;
	if (*(*(area2 + y) + x) == 0) {
		if (x == 0 && y == 0 || x == sizex - 1 && y == 0 || x == 0 && y < sizey - 1 || x == sizex - 1 && y < sizey - 1 || y == 0 || x > 0 && x < sizex - 1 && y > 0 && y < sizey - 1) {
			if (*(*(area + y + 1) + x) == 0) {
				*(*(area + y + 1) + x) += 2;
				check_empty(area, area2, sizex, sizey, x, y + 1, free);
			}
		}
		if (x == sizex - 1 && y == sizey - 1 || x == 0 && y == sizey - 1 || x == 0 && y > 0 || x == sizex - 1 && y > 0 || y == sizey - 1 || x > 0 && x < sizex - 1 && y > 0 && y < sizey - 1) {
			if (*(*(area + y - 1) + x) == 0) {
				*(*(area + y - 1) + x) += 2;
				check_empty(area, area2, sizex, sizey, x, y - 1, free);
			}
		}
		if (x == sizex - 1 && y == sizey - 1 || x == sizex - 1 && y == 0 || x == sizex - 1 || y == 0 && x > 0 || y == sizey - 1 && x > 0 || x > 0 && x < sizex - 1 && y > 0 && y < sizey - 1) {
			if (*(*(area + y) + x - 1) == 0) {
				*(*(area + y) + x - 1) += 2;
				check_empty(area, area2, sizex, sizey, x - 1, y, free);
			}
		}
		if (x == 0 && y == 0 || x == 0 && y == sizey - 1 || x == 0 || y == 0 && x < sizex - 1 || y == sizey - 1 && x < sizex - 1 || x > 0 && x < sizex - 1 && y > 0 && y < sizey - 1) {
			if (*(*(area + y) + x + 1) == 0) {
				*(*(area + y) + x + 1) += 2;
				check_empty(area, area2, sizex, sizey, x + 1, y, free);
			}
		}
		if (x == 0 && y == 0 || x == 0 && y > 0 && y < sizey - 1 || y == 0 && x > 0 && x < sizex - 1 || x > 0 && x < sizex - 1 && y > 0 && y < sizey - 1) {
			if (*(*(area + y + 1) + x + 1) == 0) {
				*(*(area + y + 1) + x + 1) += 2;
				check_empty(area, area2, sizex, sizey, x + 1, y + 1, free);
			}
		}
		if (x == sizex - 1 && y == sizey - 1 || x == sizex - 1 && y > 0 && y < sizey - 1 || y == sizey - 1 && x > 0 && x < sizex - 1 || x > 0 && x < sizex - 1 && y > 0 && y < sizey - 1) {
			if (*(*(area + y - 1) + x - 1) == 0) {
				*(*(area + y - 1) + x - 1) += 2;
				check_empty(area, area2, sizex, sizey, x - 1, y - 1, free);
			}
		}
		if (x == sizex - 1 && y == 0 || x == sizex - 1 && y > 0 && y < sizey - 1 || y == 0 && x > 0 && x < sizex - 1 || x > 0 && x < sizex - 1 && y > 0 && y < sizey - 1) {
			if (*(*(area + y + 1) + x - 1) == 0) {
				*(*(area + y + 1) + x - 1) += 2;
				check_empty(area, area2, sizex, sizey, x - 1, y + 1, free);
			}
		}
		if (x == 0 && y == sizey - 1 || x == 0 && y > 0 && y < sizey - 1 || y == sizey - 1 && x > 0 && x < sizex - 1 || x > 0 && x < sizex - 1 && y > 0 && y < sizey - 1) {
			if (*(*(area + y - 1) + x + 1) == 0) {
				*(*(area + y - 1) + x + 1) += 2;
				check_empty(area, area2, sizex, sizey, x + 1, y - 1, free);
			}
		}
	}
}

void bomb_generation(char **arr, short sizex, short sizey, short mines) {
	for (int j = 0; j < sizey; j++) {
		for (int i = 0; i < sizex; i++) {
			*(*(arr + j) + i) = 0;
		}
	}
	short o = 0;
	while (o < mines) {
		short rand1 = rand() % sizey, rand2 = rand() % sizex;
		if (*(*(arr + rand1) + rand2) == 0 && o < mines) {
			*(*(arr + rand1) + rand2) = 1;
			o++;
		}
	}
}

void amount_generation(char **arr, short **arr2, short sizex, short sizey) {
	for (int j = 0; j < sizey; j++) {
		for (int i = 0; i < sizex; i++) {
			if (*(*(arr + j) + i) != 1) {
				if (i == 0 && j < sizey - 1 || i == 0 && j == 0 || j == 0 && i < sizex - 1 || i > 0 && j > 0 && i < sizex - 1 && j < sizey - 1) {
					if (*(*(arr + j + 1) + i + 1) == 1 || *(*(arr + j + 1) + i + 1) == 5) *(*(arr2 + j) + i) += 1;
				}
				if (i == 0 && j == 0 || i == sizex - 1 && j == 0 || i == 0 && j < sizey - 1 || i == sizex - 1 && j < sizey - 1 || j == 0 || i > 0 && j > 0 && i < sizex - 1 && j < sizey - 1) {
					if (*(*(arr + j + 1) + i) == 1 || *(*(arr + j + 1) + i) == 5) *(*(arr2 + j) + i) += 1;
				}
				if (i == 0 && j == 0 || i == 0 && j == sizey - 1 || i == 0 || j == 0 && i < sizex - 1 || j == sizey - 1 && i < sizex - 1 || i > 0 && j > 0 && i < sizex - 1 && j < sizey - 1) {
					if (*(*(arr + j) + i + 1) == 1 || *(*(arr + j) + i + 1) == 5) *(*(arr2 + j) + i) += 1;
				}
				if (i == sizex - 1 && j == sizey - 1 || i == sizex - 1 && j > 0 || j == sizey - 1 && i > 0 || i > 0 && j > 0 && i < sizex - 1 && j < sizey - 1) {
					if (*(*(arr + j - 1) + i - 1) == 1 || *(*(arr + j - 1) + i - 1) == 5) *(*(arr2 + j) + i) += 1;
				}
				if (i == sizex - 1 && j == sizey - 1 || i == 0 && j == sizey - 1 || i == 0 && j > 0 || i == sizex - 1 && j > 0 || j == sizey - 1 || i > 0 && j > 0 && i < sizex - 1 && j < sizey - 1) {
					if (*(*(arr + j - 1) + i) == 1 || *(*(arr + j - 1) + i) == 5) *(*(arr2 + j) + i) += 1;
				}
				if (i == sizex - 1 && j == sizey - 1 || i == sizex - 1 && j == 0 || i == sizex - 1 || j == 0 && i > 0 || j == sizey - 1 && i > 0 || i > 0 && j > 0 && i < sizex - 1 && j < sizey - 1) {
					if (*(*(arr + j) + i - 1) == 1 || *(*(arr + j) + i - 1) == 5) *(*(arr2 + j) + i) += 1;
				}
				if (i == sizex - 1 && j == 0 || i == sizex - 1 && j < sizey - 1 || j == 0 && i > 0 || i > 0 && j > 0 && i < sizex - 1 && j < sizey - 1) {
					if (*(*(arr + j + 1) + i - 1) == 1 || *(*(arr + j + 1) + i - 1) == 5) *(*(arr2 + j) + i) += 1;
				}
				if (i == 0 && j == sizey - 1 || i == 0 && j > 0 || j == sizey - 1 && i < sizex - 1 || i > 0 && j > 0 && i < sizex - 1 && j < sizey - 1) {
					if (*(*(arr + j - 1) + i + 1) == 1 || *(*(arr + j - 1) + i + 1) == 5) *(*(arr2 + j) + i) += 1;
				}
			}
		}
	}
}

void open_bomb(char **arr, short sizex, short sizey) {
	for (int j = 0; j < sizey; j++) {
		for (int i = 0; i < sizex; i++) {
			if (*(*(arr + j) + i) == 1) *(*(arr + j) + i) = 6;
			if (*(*(arr + j) + i) == 5) *(*(arr + j) + i) = 7;
		}
	}
}

void game(short i, short uc) {
	short free = levels[i].x * levels[i].y, steps = 0, flags = levels[i].mines;
	int start_time = 0, present_time = 0;
	char **area = init_memory(' ', levels[i].x, levels[i].y);
	short **area2 = init_memory(short(1), levels[i].x, levels[i].y);
	bomb_generation(area, levels[i].x, levels[i].y, levels[i].mines);
	short en = 0, x = 0, y = 0, status = 1;
	do {
		if (en == 77) {
			x++;
			if (x == levels[i].x) x = 0;
		}
		if (en == 75) {
			x--;
			if (x < 0) x = levels[i].x - 1;
		}
		if (en == 80) {
			y++;
			if (y == levels[i].y) y = 0;
		}
		if (en == 72) {
			y--;
			if (y < 0) y = levels[i].y - 1;
		}
		if (en == 32) {
			if (*(*(area + y) + x) == 0 || *(*(area + y) + x) == 1) {
				*(*(area + y) + x) += 4;
				flags--;
			}
			else if (*(*(area + y) + x) == 4 || *(*(area + y) + x) == 5) {
				*(*(area + y) + x) -= 4;
				flags++;
			}
		}
		if (en == 13) {

			if (*(*(area + y) + x) == 1) {
				if (free == levels[i].x * levels[i].y) {
					while (true) {
						short tempx = rand() % levels[i].x, tempy = rand() % levels[i].y;
						if (*(*(area + tempy) + tempx) == 0) {
							*(*(area + tempy) + tempy) = *(*(area + y) + x);
							break;
						}
					}
				}
				else status = 0;
			}
			if (free == levels[i].x * levels[i].y) {
				amount_generation(area, area2, levels[i].x, levels[i].y);
				start_time = time(NULL);
			}
			if (status != 0 && *(*(area + y) + x) < 2) {
				*(*(area + y) + x) += 2;
				check_empty(area, area2, levels[i].x, levels[i].y, x, y, free);
				steps++;
			}

		}
		system("cls");
		(free < levels[i].x * levels[i].y) ? present_time = (time(NULL) - start_time) : present_time = 0;
		wprintf(L"ПРОШЕДШЕЕ ВРЕМЯ: %d\nКОЛИЧЕСТВО ХОДОВ: %d\nОСТАВШИЕСЯ ФЛАЖКИ: %d\n", present_time, steps, flags);
		if (free == levels[i].mines || status == 0) {
			GotoXY(30, 1);
			if (free == levels[i].mines) {
				SetColor(10, 0);
				wprintf(L"Вы выиграли!\n\n");
			}
			else {
				SetColor(12, 0);
				wprintf(L"Вы проиграли!\n\n");
			}
			SetColor(15, 0);
			open_bomb(area, levels[i].x, levels[i].y);
		}
		output_area(area, area2, levels[i].x, levels[i].y, x, y, uc);
		if (free == levels[i].mines || status == 0) {
			GotoXY(0, levels[i].y * 2 + 6);
			system("pause");
			break;
		}
	} while (en = getch());
	delete_memory(area, levels[i].y);
	delete_memory(area2, levels[i].y);
}

void set_area() {
	short z = 1;
	do {
		system("cls");
		SetColor(0, 7);
		wprintf(L"====================================================================================================\n");
		wprintf(L"Настройки особого поля                                                                              \n");
		wprintf(L"====================================================================================================\n");
		SetColor(12, 0);
		wprintf(L"МИНИМАЛЬНЫЙ размер поля: 3х3, МАКСИМАЛЬНЫЙ размер поля: 15x15\nПри слишком больших значениях и значениях ниже 0 будут применены мин. размеры поля\nПри небольших значениях, но больше 30x25 будут применены макс. размеры\n");
		SetColor(15, 0);
		_LONGLONG x = 0, y = 0, mines = 0;
		wprintf(L"Введите высоту поля(не равно 0): ");
		wscanf(L"%d", &y);
		check_fail();
		wprintf(L"Введите ширину поля(не равно 0): ");
		wscanf(L"%d", &x);
		check_fail();
		wprintf(L"Введите количество мин на поле(не равно 0): ");
		wscanf(L"%d", &mines);
		check_fail();
		levels[3].x = x;
		levels[3].y = y;
		levels[3].mines = mines;
		if (levels[3].x > 15) levels[3].x = 15;
		else if (levels[3].x < 3) levels[3].x = 2;
		if (levels[3].y > 15) levels[3].y = 15;
		else if (levels[3].y < 3) levels[3].y = 2;
		if (levels[3].mines >= levels[3].y * levels[3].x) levels[3].mines = levels[3].y * levels[3].x - 1;
		else if (levels[3].mines < 0) levels[3].mines = 0;
		system("cls");
		wprintf(L"====================================================================================================\n");
		wprintf(L"Настройки особого поля                                                                              \n");
		wprintf(L"====================================================================================================\n");
		wprintf(L"Ваши настройки: %d (высота), %d (ширина), %d (мины)\nВы уверены, что хотите начать игру с такими настройками?", levels[3].y, levels[3].x, levels[3].mines);
		short ent = 0;
		do {
			if (ent == 77) {
				z++;
				if (z == 3) z = 1;
			}
			if (ent == 75) {
				z--;
				if (z == 0) z = 2;
			}
			if (ent == 13) break;
			GotoXY(20, 6);
			if (z == 1) SetColor(15, 10);
			wprintf(L" Да ");
			SetColor(15, 0);
			GotoXY(30, 6);
			if (z == 2) SetColor(15, 10);
			wprintf(L" Нет ");
			SetColor(15, 0);
		} while (ent = getch());
	} while (z == 2);
}

void show_(wchar_t *str) {
	for (int i = 0, j = 1, x = 0; i < wcslen(str); i++, x++) {
		GotoXY(42 + x, j);
		if (*(str + i) == '-') {
			for (int p = 0; p < 58 - x % 58; p++) {
				wprintf(L" ");
			}
			j++;
			GotoXY(42, j);
			wprintf(L" %c", *(str + i));
			x = 1;
		}
		else if (i == wcslen(str) - 1) {
			GotoXY(42 + x, j);
			wprintf(L"%c", *(str + i));
			for (int p = 0; p < 57 - x % 58; p++) {
				wprintf(L" ");
			}
			j++;
			x = 1;
		}
		else if (x == 58) {
			j++;
			GotoXY(42, j);
			wprintf(L" %c", *(str + i));
			x = 1;
		}
		else wprintf(L"%c", *(str + i));
	}
}

void show_set(short x, short s) {
	for (int i = 0, j = 0; i <= 15; i++) {
		if (i != 7 && i != 8) j++;
		else i = 9;
		GotoXY(40 + j * 4, 5);
		SetColor(15, i);
		wprintf(L"  ");
		if (j == x) {
			SetColor(15, 0);
			GotoXY(40 + j * 4, 7);
			wcout << L"\u25B2\u25B2";
		}
		if (j == s) {
			SetColor(7, 0);
			GotoXY(39 + j * 4, 4);
			wcout << L"\u250F\u2501\u2501\u2513";
			GotoXY(39 + j * 4, 6);
			wcout << L"\u2517\u2501\u2501\u251B";
			GotoXY(39 + j * 4, 5);
			wcout << L"\u2503";
			GotoXY(42 + j * 4, 5);
			wcout << L"\u2503";
		}
	}
}

void main() {
	_setmode(_fileno(stdout), _O_U16TEXT);
	_setmode(_fileno(stdin), _O_U16TEXT);
	_setmode(_fileno(stderr), _O_U16TEXT);
	SetColor(15, 0);
	srand(time(NULL));
	short enter = 0, l = 1, max = 0, x = 0, uc = 5;
	do {
		if (enter == 80) {
			if (x == 0) {
				l++;
				if (l == 8) l = 1;
			}
			else {
				x++;
				if (x == max + 1) x = 1;
			}
		}
		if (enter == 72) {
			if (x == 0) {
				l--;
				if (l == 0) l = 7;
			}
			else {
				x--;
				if (x == 0) x = max;
			}
		}
		if (enter == 77) {
			if (x == 0) {
				x++;
				if (x == max + 1) x = 0;
			}
		}
		if (enter == 75) {
			if (x != 0) {
				x = 0;
			}
		}
		if (enter == 13) {
			switch (l) {
			case 1: {
				if (x == 4) set_area();
				if (x) game(x - 1, uc);
				break;
			}
			case 2: {
				break;
			}
			case 3: {
				uc = x;
				break;
			}
			case 4: {
				break;
			}
			case 5: {
				break;
			}
			case 6: {
				break;
			}
			default:
				exit(0);
				break;
			}
		}
		system("cls");
		SetColor(0, 7);
		if (l == 1) {
			max = 4;
			GotoXY(40, 0);
			SetColor(0, 8);
			wprintf(L" \u25BA");
			SetColor(0, 7);
			GotoXY(42, 0);
			wprintf(L" Выберите уровень сложности:                              ");
			GotoXY(42, 1);
			if (x == 1) SetColor(0, 8);
			wprintf(L"  Новичок                                                 ");
			SetColor(0, 7);
			GotoXY(42, 2);
			if (x == 2) SetColor(0, 8);
			wprintf(L"  Бывалый                                                 ");
			SetColor(0, 7);
			GotoXY(42, 3);
			if (x == 3) SetColor(0, 8);
			wprintf(L"  Эксперт                                                 ");
			SetColor(0, 7);
			GotoXY(42, 4);
			if (x == 4) SetColor(0, 8);
			wprintf(L"  Особый                                                  ");
			SetColor(0, 7);
			SetColor(0, 8);
		}
		GotoXY(0, 0);
		wprintf(L"%40s\n", L"Играть");
		SetColor(0, 7);
		if (l == 2) {
			max = 0;
			GotoXY(40, 1);
			SetColor(0, 8);
			wprintf(L" \u25BA");
			SetColor(0, 7);
			GotoXY(42, 0);
			wprintf(L" ОБЩИЕ СВЕДЕНИЯ ОБ ИГРЕ:                                  ");
			wchar_t rules[] = L"- Начните с открытия одной ячейки. - Число в ячейке показывает, сколько мин скрыто вокруг данной ячейки. Это число поможет понять вам, где находятся безопасные ячейки, а где находятся бомбы. - Если рядом с открытой ячейкой есть пустая ячейка, то она откроется автоматически. - Если вы открыли ячейку с миной, то игра проиграна. - Что бы пометить ячейку, в которой находится бомба, нажмите ПРОБЕЛ. - Если в ячейке указано число, оно показывает, сколько мин скрыто в восьми ячейках вокруг данной. Это число помогает понять, где находятся безопасные ячейки. - Игра продолжается до тех пор, пока вы не откроете все не заминированные ячейки. - Над полем отображается Ваша статистика : количествово ходов, количество использованных флажков, количество прошедших секунд. После окончания игры по ним будет составлят рейтинг и таблица рекордов. ВНИМАНИЕ!!! Прошедшее время считается НЕ в реальном времене и обновляется по нажатию любой клавиши. То есть, считается даже тогда, когда игрок неактивен. - Все действия игрока во время игры записываются во внешний файл с названием 'play_%номер игры%.txt' вместе с результатами игры. - Существует две таблицы рекордов : по прошедшему времени('timetable.txt') и по количеству ходов('stepstable.txt')";
			show_(rules);
			SetColor(0, 8);
		}
		GotoXY(0, 1);
		wprintf(L"%40s\n", L"Общие сведения об игре");
		SetColor(0, 7);
		if (l == 3) {
			max = 13;
			GotoXY(40, 2);
			SetColor(0, 8);
			wprintf(L" \u25BA");
			SetColor(0, 7);
			GotoXY(42, 0);
			wprintf(L" Настройка цвета указателя                                ");
			GotoXY(42, 2);
			show_(L" - Выберите цвет селектора, которым хотите управлять:");
			show_set(x, uc);
			SetColor(0, 8);
		}
		GotoXY(0, 2);
		wprintf(L"%40s\n", L"Настройка цвета указателя");
		SetColor(0, 7);
		GotoXY(0, 3);
		if (l == 4) SetColor(0, 8);
		wprintf(L"%40s\n", L"Таблица рекордов по времени");
		SetColor(0, 7);
		GotoXY(0, 4);
		if (l == 5) SetColor(0, 8);
		wprintf(L"%40s\n", L"Таблица рекордов по количеству ходов");
		SetColor(0, 7);
		GotoXY(0, 5);
		if (l == 6) SetColor(0, 8);
		wprintf(L"%40s\n", L"Поиск по логам игры");
		SetColor(0, 7);
		GotoXY(0, 6);
		if (l == 7) SetColor(0, 8);
		wprintf(L"%40s\n", L"Выход");
		SetColor(15, 2);
		GotoXY(0, 7);
		wprintf(L"Для управления используйте (← → ↑ ↓)    ");
		GotoXY(0, 8);
		wprintf(L"Для выбора нажмите ENTER                ");
		SetColor(15, 0);
	} while (enter = getch());

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