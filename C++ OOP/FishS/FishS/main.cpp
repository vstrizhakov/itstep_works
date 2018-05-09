#include "header.h"

void main() {
	_setmode(_fileno(stdout), _O_U16TEXT);
	_setmode(_fileno(stdin), _O_U16TEXT);
	_setmode(_fileno(stderr), _O_U16TEXT);
	srand(time(NULL));
	Fish f1("trout1", 2.5, 40);
	Fish f2("trout2", 3.4, 10);
	Fish f3("trout3", 1.5, 20);
	Fish f4("trout4", 0.7, 30);
	Fish f5("trout5", 6.9, 120);
	/*FILE *fout = fopen("fishes.txt", "wb+");
	if (!fout)
		wcout << L"Ошибка при открытии файла для записи" << endl;
	Fish f[5] = { f1, f2, f3, f4, f5 };

	fwrite(&f1, sizeof(f1), 1, fout);
	rewind(fout);
	Fish tmp;
	fread(&tmp, sizeof(tmp), 1, fout);
	wcout << tmp;
	fclose(fout);*/
	FILE *fout = fopen("array.txt", "wb+");
	if (!fout)
		wcout << L"Ошибка при открытии файла для записи" << endl;
	Fish f[5] = { f1, f2, f3, f4, f5 };
	fwrite(&f, sizeof(f1), 5, fout);

	int num = 0;
	wcout << L"Enter element number: ";
	wcin >> num;
	fseek(fout, (num - 1) * sizeof(f1), SEEK_SET);
	Fish tmp;
	fread(&tmp, sizeof(tmp), 1, fout);
	wcout << tmp;
	fclose(fout);
}
