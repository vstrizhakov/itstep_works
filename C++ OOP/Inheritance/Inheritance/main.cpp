#include "header.h"

void main() {
	_setmode(_fileno(stdout), _O_U8TEXT);
	_setmode(_fileno(stdin), _O_U8TEXT);
	_setmode(_fileno(stderr), _O_U8TEXT);
	srand(time(NULL));
	Sphere s1;
	wcout << endl << s1 << endl;
	wcout << L"������� �����: " << s1.sqr() << endl;
	wcout << L"����� �����: " << s1.volume() << endl << endl;
}