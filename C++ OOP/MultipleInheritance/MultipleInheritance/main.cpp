#include "header.h"

void main() {
	_setmode(_fileno(stdout), _O_U8TEXT);
	_setmode(_fileno(stdin), _O_U8TEXT);
	_setmode(_fileno(stderr), _O_U8TEXT);
	srand(time(NULL));
	D O1;
	O1.B::a = 1;
}