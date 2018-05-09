#include "header.h"

void main() {
	/*_setmode(_fileno(stdout), _O_U8TEXT);
	_setmode(_fileno(stdin), _O_U8TEXT);
	_setmode(_fileno(stderr), _O_U8TEXT);*/
	setlocale(LC_ALL, "rus");
	srand(time(NULL));
	char file[255];
	char dir[255] = "serGey";
	char line[255] = "";
	cin.getline(file, 255);
	if (_mkdir(dir) == -1) {
		wcout << L"Directory creation error!" << endl;
		return;
	}
	FILE* fout = fopen(file, "a+");	
	cout << L"Enter a text line: ";
	cin.ignore();
	cin.getline(line, 255);
	fputs(line, fout);
	fclose(fout);
	strcat(dir, "\\");
	strcat(dir, file);
	rename(file, dir);
}
