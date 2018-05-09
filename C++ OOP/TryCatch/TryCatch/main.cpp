#include "header.h"

void main()
{
	_setmode(_fileno(stdout), _O_U8TEXT);
	_setmode(_fileno(stdin), _O_U8TEXT);
	_setmode(_fileno(stderr), _O_U8TEXT);
	srand(time(NULL));

	int a = 10, b = 0;
	try
	{
		if (b == 0)
			throw "zero divide is forbidden";
		int div = a / b;
		wcout << div << endl;
	}
	catch (exception p)
	{
		wcout << L"Error" << endl;
	}
	catch (...)
	{
		wcout << L"Error" << endl;
	}
}