#include "header.h"

void main() {
	/*_setmode(_fileno(stdout), _O_U8TEXT);
	_setmode(_fileno(stdin), _O_U8TEXT);
	_setmode(_fileno(stderr), _O_U8TEXT);*/
	setlocale(LC_ALL, "rus");
	srand(time(NULL));
	FILE *fin = fopen("1.txt", "r");
	if (!fin) {
		cout << "Ошибка при открытии файла для чтения" << endl;
		return;
	}
	FILE *fout = fopen("2.txt", "w");
	if (!fout) {
		cout << "Ошибка при открытии файла для записи" << endl;
		return;
	}
	int buf;
	char a = 'a';
	while (!feof(fin)) {
		buf = fgetc(fin);
		if (buf == 'a')
			fputc('5', fout);
		else
			fputc(buf, fout);
		
	}
	fclose(fin);
	fclose(fout);
}