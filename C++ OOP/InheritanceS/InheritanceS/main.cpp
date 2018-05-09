#include "header.h"
#include "subheader.h"

void main() {
	_setmode(_fileno(stdout), _O_U8TEXT);
	_setmode(_fileno(stdin), _O_U8TEXT);
	_setmode(_fileno(stderr), _O_U8TEXT);
	srand(time(NULL));
	/*A oa, *pa;
	B ob, *pb;
	C oc, *pc;
	pa = &oa;
	pa->fa();
	pa = &ob;
	pa->fa();
	pa = &oc;
	pa->fa();*/
	wcout << sizeof(Empty) << endl;
	wcout << sizeof(MC1) << endl;
	wcout << sizeof(MC2) << endl;
	wcout << sizeof(Virt1) << endl;
	wcout << sizeof(Virt2) << endl;
}
