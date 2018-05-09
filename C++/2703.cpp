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

struct video {
	char name[26];
	char producer[24];
	char genre[24];
	double rate;
	double price;
};

void header() {
	system("cls");
	GotoXY(0, 0);
	cout << "====================================================================================================";
	GotoXY(1, 1);
	cout << "Название фильма";
	GotoXY(27, 1);
	cout << "|";
	GotoXY(29, 1);
	cout << "Режиссер";
	GotoXY(54, 1);
	cout << "|";
	GotoXY(56, 1);
	cout << "Жанр";
	GotoXY(81, 1);
	cout << "|";
	GotoXY(83, 1);
	cout << "Рейтинг";
	GotoXY(91, 1);
	cout << "|";
	GotoXY(93, 1);
	cout << "Цена";
	GotoXY(0, 2);
	cout << "====================================================================================================";
}

void foot(short y, short x) {
	GotoXY(0, y + x);
	cout << "====================================================================================================";
	GotoXY(0, y + x + 1);
}

void output(video *arr, int size) {
	header();
	int i = 0;
	for (i = 3; i < size + 3; i++) {
		GotoXY(1, i);
		cout << (arr + i - 3)->name;
		GotoXY(27, i);
		cout << "|";
		GotoXY(29, i);
		cout << (arr + i - 3)->producer;
		GotoXY(54, i);
		cout << "|";
		GotoXY(56, i);
		cout << (arr + i - 3)->genre;
		GotoXY(81, i);
		cout << "|";
		GotoXY(83, i);
		cout << (arr + i - 3)->rate;
		GotoXY(91, i);
		cout << "|";
		GotoXY(93, i);
		cout << fixed << setprecision(2) << (arr + i - 3)->price;
	}
	foot(i, 0);
}

void write_to_file(FILE * file, video *arr, int size) {
	int i = 0;
	fprintf(file, "Название\t\tРежиссер\tЖанр\tРейтинг\tЦена\n");
	for (i = 3; i < size + 3; i++) {
		fprintf(file, "%s\t%s\t%s\t%.2F\t%.2F\n", (arr + i - 3)->name, (arr + i - 3)->producer, (arr + i - 3)->genre, (arr + i - 3)->rate, (arr + i - 3)->price);
	}
}

void output_certain(video *arr, int index, int y) {
	GotoXY(1, y);
	cout << (arr + index)->name;
	GotoXY(27, y);
	cout << "|";
	GotoXY(29, y);
	cout << (arr + index)->producer;
	GotoXY(54, y);
	cout << "|";
	GotoXY(56, y);
	cout << (arr + index)->genre;
	GotoXY(81, y);
	cout << "|";
	GotoXY(83, y);
	cout << (arr + index)->rate;
	GotoXY(91, y);
	cout << "|";
	GotoXY(93, y);
	cout << fixed << setprecision(2) << (arr + index)->price;
}

char *strdup_(char *arr2, int size) {
	char *arr = new char[size];
	int i = 0;
	for (i = 0; i < size; i++) {
		*(arr + i) = *(arr2 + i);
	}
	*(arr + i) = '\0';
	for (int j = 0; j < size; j++) {
		for (int i = 192; i <= 223; i++) {
			if (*(arr + j) == char(i)) *(arr + j) = i + 32;
		}
	}
	for (int j = 0; j < size; j++) {
		for (int i = 65; i <= 90; i++) {
			if (*(arr + j) == char(i)) *(arr + j) = i + 32;
		}
	}
	return arr;
}

void search_name(FILE *p, video *arr, int size, char *search) {
	char *search_name = strdup_(search, strlen(search)), *name;
	int i = 0, t = 0;
	fprintf(p, "Тип поиска: поиск по названию\tЗапрос: %s\tРезультаты:\n", search);
	for (i = 0; i < size; i++) {
		name = strdup_((arr + i)->name, strlen((arr + i)->name));
		if (strcmp(name, search_name) == 0) {
			header();
			output_certain(arr, i, 3);
			fprintf(p, "%s\t%s\t%s\t%.2F\t%.2F\n", (arr + i)->name, (arr + i)->producer, (arr + i)->genre, (arr + i)->rate, (arr + i)->price);
			t++;
		}
	}
	if (t == 0) {
		system("cls");
		cout << "====================================================================================================";
		cout << "Поиск по названию\n";
		cout << "====================================================================================================";
		cout << "Фильм с таким названием не найден!\n";
		foot(4, 0);
		fprintf(p, "Результатов нет :с\n");
	}
	else foot(4, 0);
	fprintf(p, "====================================================================================================\n");
}

void search_producer(FILE *p, video *arr, int size, char *search) {
	char *search_name = strdup_(search, strlen(search)), *name;
	short z = 0;
	header();
	int i = 0;
	fprintf(p, "Тип поиска: поиск по режиссеру\tЗапрос: %s\tРезультаты:\n", search);
	for (i = 0; i < size; i++) {
		name = strdup_((arr + i)->producer, strlen((arr + i)->producer));
		if (strcmp(name, search_name) == 0) {
			output_certain(arr, i, 3 + z);
			fprintf(p, "%s\t%s\t%s\t%.2F\t%.2F\n", (arr + i)->name, (arr + i)->producer, (arr + i)->genre, (arr + i)->rate, (arr + i)->price);
			z++;
		}
	}
	if (z == 0) {
		system("cls");
		cout << "====================================================================================================";
		cout << "Поиск по режиссеру\n";
		cout << "====================================================================================================";
		cout << "Фильм с таким режиссером не найден!\n";
		foot(z, 4);
		fprintf(p, "Результатов нет :с\n");
	}
	else foot(z, 3);
	fprintf(p, "====================================================================================================\n");
}

void search_genre(FILE *p, video *arr, int size, char *search) {
	char *search_name = strdup_(search, strlen(search)), *name;
	short z = 0;
	header();
	int i = 0;
	fprintf(p, "Тип поиска: поиск по жанру\tЗапрос: %s\tРезультаты:\n", search);
	for (i = 0; i < size; i++) {
		name = strdup_((arr + i)->genre, strlen((arr + i)->genre));
		if (strcmp(name, search_name) == 0) {
			output_certain(arr, i, 3 + z);
			fprintf(p, "%s\t%s\t%s\t%.2F\t%.2F\n", (arr + i)->name, (arr + i)->producer, (arr + i)->genre, (arr + i)->rate, (arr + i)->price);
			z++;
		}
	}
	if (z == 0) {
		system("cls");
		cout << "====================================================================================================";
		cout << "Поиск по жанру\n";
		cout << "====================================================================================================";
		cout << "Фильм с таким жанром не найден!\n";
		foot(z, 4);
		fprintf(p, "Результатов нет :с\n");
	}
	else foot(z, 3);
	fprintf(p, "====================================================================================================\n");
}

void copy(video *arr, video *arr2, int size) {
	for (int i = 0; i < size; i++) {
		*(arr2 + i) = *(arr + i);
	}
}

void check_fail() {
	if (cin.fail()) {
		cin.clear();
		cin.ignore(cin.rdbuf()->in_avail());
	}
}

void mp(FILE *p, video *arr, int size, char *search) {
	char *search_name = strdup_(search, strlen(search)), *name;
	header();
	short i = 0, sum = 0, z = 0;
	fprintf(p, "Тип поиска: самый популярный фильм в жанре\tЗапрос: %s\tРезультаты:\n", search);
	for (i = 0; i < size; i++) {
		if ((arr + i)->rate <= (arr + sum)->rate) sum = i;
	}
	for (i = 0; i < size; i++) {
		name = strdup_((arr + i)->genre, strlen((arr + i)->genre));
		if (strcmp(name, search_name) == 0) {
			if ((arr + i)->rate >= (arr + sum)->rate) {
				sum = i;
				z++;
			}
		}
	}
	if (z != 0) {
		output_certain(arr, sum, 3);
		fprintf(p, "%s\t%s\t%s\t%.2F\t%.2F\n", (arr + sum)->name, (arr + sum)->producer, (arr + sum)->genre, (arr + sum)->rate, (arr + sum)->price);
		foot(4, 0);
	}
	else {
		system("cls");
		cout << "====================================================================================================";
		cout << "Самый популярный фильм в жанре\n";
		cout << "====================================================================================================";
		cout << "Фильм с таким жанром не найден!\n";
		foot(z, 4);
	}
	fprintf(p, "====================================================================================================\n");
}

void input_film(video *arr) {
	do {
		cout << "Введите название фильма(от 1 до 25 символов): ";
		cin.getline((arr->name), 26);
		check_fail();
	} while (strlen(arr->name) == 0);
	do {
		cout << "Введите режиссера фильма(от 1 до 23 символов): ";
		cin.getline((arr->producer), 24);
		check_fail();
	} while (strlen(arr->producer) == 0);
	do {
		cout << "Введите жанр фильма(от 1 до 23 символов): ";
		cin.getline((arr->genre), 24);
		check_fail();
	} while (strlen(arr->genre) == 0);
	do {
		cout << "Введите рейтинг фильма(от 0 до 10): ";
		cin >> arr->rate;
		check_fail();
	} while (arr->rate < 0 || arr->rate > 10);
	do {
		cout << "Введите цену билета(от 0 до 100): ";
		cin >> arr->price;
		check_fail();
	} while (arr->price < 0 || arr->price > 99);
}

video *add_film(video *arr, int size) {
	video *films_temp = new video[size];
	copy(arr, films_temp, size);
	delete[] arr;
	arr = nullptr;
	arr = new video[size + 1];
	copy(films_temp, arr, size);
	input_film(arr + size);
	return arr;
}

void read_from_file(FILE *p) {
	char *r;
	char read[128];
	do {
		r = fgets(read, sizeof(read), p);
		if (r) cout << read;
	} while (r);
}

void search_from_file(FILE *p, char *search) {
	char *search_tag = strdup_(search, strlen(search)), *r, *rb;
	char read[128];
	short z = 0;
	do {
		r = fgets(read, sizeof(read), p);
		if (r) {
			for (int i = 0; i < strlen(read); i++) {
				rb = strdup_(read + i, strlen(read));
				if (strncmp(rb, search_tag, strlen(search_tag)) == 0) {
					printf("%s", read);
					z++;
					break;
				}
			}
		}
	} while (r);
	if (z == 0) printf("Результатов нет :с\n");
}

void main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	SetColor(15, 0);
	srand(time(NULL));
	FILE *p;
	char *path = "logs.txt", *path2 = "search_logs.txt";
	int size = 10;
	video *films = new video[size];
	*(films + 0) = { "Достучаться до небес", "Томас Ян", "драма", 8.65, 25.50 };
	*(films + 1) = { "Леон", "Люк Бессон", "триллер, драма", 8.69, 30.55 };
	*(films + 2) = { "1+1", "Оливье Накаш", "комедия", 5.87, 23.50 };
	*(films + 3) = { "Один дома", "Крис Коламбус", "комедия", 8.24, 25.20 };
	*(films + 4) = { "Изгой", "Роберт Земекис", "драма", 8.30, 20.50 };
	*(films + 5) = { "Темный рыцарь", "Кристофор Нолан", "фантастика", 8.50, 25.10 };
	*(films + 6) = { "Такси", "Люк Бессон", "комедия", 7.90, 22.50 };
	*(films + 7) = { "22 пули: Бессмертный", "Люк Бессон", "боевик, драма", 7.13, 21.50 };
	*(films + 8) = { "Аватар", "Джеймс Кэмерон", "фантастика", 7.96, 24.40 };
	*(films + 9) = { "Терминатор 2: Судный день", "Джеймс Кэмерон", "фантастика, боевик", 8.31, 35.55 };
	char search[26];
	short en = 0, k = 1;
	do {
		if (en == 80) {
			k++;
			if (k == 10) k = 1;
		}
		if (en == 72) {
			k--;
			if (k == 0) k = 9;
		}
		if (en == 13) {
			switch (k) {
			case 1: {
				system("cls");
				output(films, size);
				p = fopen(path, "w");
				if (!p) {
					printf("Ошибка открытия файла %s для записи!\n", path);
				}
				else {
					write_to_file(p, films, size);
					printf("Файл %s открыт для записи!\nДанные, которые будут записаны в него указаны выше\n", path);
					printf("Данные успешно записаны в файл %s\n", path);
					fclose(p);
					printf("Файл закрыт!\n");
				}
				cout << "Нажмите любую клавишу, чтобы перейти в гланое меню\n";
				getch();
				break;
			}
			case 2: {
				system("cls");
				p = fopen(path, "r");
				if (!p) {
					printf("Ошибка открытия файла %s для чтения!\n", path);
				}
				else {
					printf("Файл %s открыт для чтения!\nСчитывание данных...\n\n", path);
					read_from_file(p);
					printf("\nДанные успешно считаны из файла %s\n", path);
					fclose(p);
					printf("Файл закрыт!\n");
				}
				cout << "Нажмите любую клавишу, чтобы перейти в гланое меню\n";
				getch();
				break;
			}
			case 3: {
				system("cls");
				cout << "====================================================================================================";
				cout << "Поиск по названию\n";
				cout << "====================================================================================================";
				cout << "Введите название: ";
				cin.getline(search, 26);
				p = fopen(path2, "a");
				if (!p) p = fopen(path2, "w");
				if (p) {
					search_name(p, films, size, search);
					printf("Файл %s успешно открыт для дозаписи!\nРезультаты поиска успешно записаны в %s\n", path2, path2);
				}
				else printf("Ошибка при открытии файла %s для дозаписи\n", path2);
				fclose(p);
				printf("Файл %s успешно закрыт!\n", path2);
				cout << "Нажмите любую клавишу, чтобы перейти в гланое меню\n";
				getch();
				break;
			}
			case 4: {
				system("cls");
				cout << "====================================================================================================";
				cout << "Поиск по режиссеру\n";
				cout << "====================================================================================================";
				cout << "Введите режиссера: ";
				cin.getline(search, 26);
				p = fopen(path2, "a");
				if (!p) p = fopen(path2, "w");
				if (p) {
					search_producer(p, films, size, search);
					printf("Файл %s успешно открыт для дозаписи!\nРезультаты поиска успешно записаны в %s\n", path2, path2);
				}
				else printf("Ошибка при открытии файла %s для дозаписи\n", path2);
				fclose(p);
				printf("Файл %s успешно закрыт!\n", path2);
				cout << "Нажмите любую клавишу, чтобы перейти в гланое меню\n";
				getch();
				break;
			}
			case 5: {
				system("cls");
				cout << "====================================================================================================";
				cout << "Поиск по жанру\n";
				cout << "====================================================================================================";
				cout << "Введите жанр: ";
				cin.getline(search, 26);
				p = fopen(path2, "a");
				if (!p) p = fopen(path2, "w");
				if (p) {
					search_genre(p, films, size, search);
					printf("Файл %s успешно открыт для дозаписи!\nРезультаты поиска успешно записаны в %s\n", path2, path2);
				}
				else printf("Ошибка при открытии файла %s для дозаписи\n", path2);
				fclose(p);
				printf("Файл %s успешно закрыт!\n", path2);
				cout << "Нажмите любую клавишу, чтобы перейти в гланое меню\n";
				getch();
				break;
			}
			case 6: {
				system("cls");
				cout << "====================================================================================================";
				cout << "Самый популярный фильм в жанре\n";
				cout << "====================================================================================================";
				cout << "Введите жанр: ";
				cin.getline(search, 26);
				p = fopen(path2, "a");
				if (!p) p = fopen(path2, "w");
				if (p) {
					mp(p, films, size, search);
					printf("Файл %s успешно открыт для дозаписи!\nРезультаты поиска успешно записаны в %s\n", path2, path2);
				}
				else printf("Ошибка при открытии файла %s для дозаписи\n", path2);
				fclose(p);
				printf("Файл %s успешно закрыт!\n", path2);
				cout << "Нажмите любую клавишу, чтобы перейти в гланое меню\n";
				getch();
				break;
			}
			case 7: {
				system("cls");
				short i = 0, y = '1';
				do {
					output(films, size);
					cout << "Добавить фильм\n";
					cout << "====================================================================================================";
					if (i > 0) {
						p = fopen(path, "w");
						if (!p) {
							printf("Ошибка открытия файла %s для записи!", path);
						}
						else {
							write_to_file(p, films, size);
							printf("Файл %s открыт для записи!\nФайл будет перезаписан с данными, которые вы ввели\n", path);
							printf("Данные успешно записаны в файл %s\n", path);
							fclose(p);
							printf("Файл успешно закрыт!\n");
						}
						cout << "Нажмите 1, чтобы добавить еще один фильм; любую клавишу, чтобы выйти в главное меню\n";
						y = getch();
					}
					if (y != '1') break;
					films = add_film(films, size);
					cin.ignore();
					size++;
					i++;
				} while (true);
				break;
			}
			case 8: {
				system("cls");
				cout << "====================================================================================================";
				printf("Поиск записи в файле\n", path);
				cout << "====================================================================================================";
				p = fopen(path, "r");
				if (!p) {
					printf("Ошибка открытия файла %s для записи!", path);
				}
				else {
					printf("Файл %s открыт для чтения!\n\nВведите запрос(название/жанр/продюссер/рейтинг/билет): ", path);
					cin.getline(search, 26);
					printf("Поиск успешно проведен: \n", path);
					search_from_file(p, search);
					fclose(p);
					printf("\nФайл успешно закрыт!\n");
				}
				cout << "Нажмите любую клавишу, чтобы перейти в гланое меню\n";
				getch();
				break;
			}
			default:
				exit(0);
				break;
			}
		}
		system("cls");
		cout << "====================================================================================================";
		if (k == 1) SetColor(10, 0);
		cout << "Записать данные в файл\n";
		SetColor(15, 0);
		if (k == 2) SetColor(10, 0);
		cout << "Считать данные из файла\n";
		SetColor(15, 0);
		if (k == 3) SetColor(10, 0);
		cout << "Поиск по наванию\n";
		SetColor(15, 0);
		if (k == 4) SetColor(10, 0);
		cout << "Поиск по режиссеру\n";
		SetColor(15, 0);
		if (k == 5) SetColor(10, 0);
		cout << "Поиск по жанру\n";
		SetColor(15, 0);
		if (k == 6) SetColor(10, 0);
		cout << "Самый популярный фильм в жанре\n";
		SetColor(15, 0);
		if (k == 7) SetColor(10, 0);
		cout << "Добавить фильм\n";
		SetColor(15, 0);
		if (k == 8) SetColor(10, 0);
		printf("Поиск записи в файле\n", path);
		SetColor(15, 0);
		if (k == 9) SetColor(10, 0);
		cout << "Выход\n";
		SetColor(15, 0);
		cout << "====================================================================================================";
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