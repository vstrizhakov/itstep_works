#include "header.h"

void main() {
	_setmode(_fileno(stdout), _O_U16TEXT);
	_setmode(_fileno(stdin), _O_U16TEXT);
	_setmode(_fileno(stderr), _O_U16TEXT);
	srand(time(NULL));
	Fish f1("54564", 23, 15.99);
	Fish f2("456", 10, 2);
	Fish f3 = f1 + f2;
	Fish f4 = f1 * f2;
	wcout << f3 << endl << endl;
	wcout << f4 << endl;
}
