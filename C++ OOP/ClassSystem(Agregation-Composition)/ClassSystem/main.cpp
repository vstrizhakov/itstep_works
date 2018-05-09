#include "header.h"
#include "subheader.h"

void main() {
	_setmode(_fileno(stdout), _O_U8TEXT);
	_setmode(_fileno(stdin), _O_U8TEXT);
	_setmode(_fileno(stderr), _O_U8TEXT);
	srand(time(NULL));
	CPU cpu1(L"CPU1", 1.8), cpu2(L"CPU2", 4.2);
	HDD hdd1(256), hdd2(512);
	RAM ram1(4), ram2(8);
	Motherboard mb1(L"MOTHERBOARD1"), mb2(L"MOTHERBOARD2");
	PC1 pc(&cpu1, &ram1, &hdd1, &mb1);
	wcout << pc << endl;
}