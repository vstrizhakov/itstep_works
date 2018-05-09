#include "header.h"

void main(int num, char *arg[])
{
	_setmode(_fileno(stdout), _O_U8TEXT);
	_setmode(_fileno(stdin), _O_U8TEXT);
	_setmode(_fileno(stderr), _O_U8TEXT);
	srand(time(NULL));
	if (num > 1)
	{
		if (num == 3)
		{
			FILE* fout = fopen(arg[1], "rb");
			if (!fout)
			{
				wcout << L"Error in open file '" << arg[1] << L"'" << endl;
				return;
			}
			FILE* fin = fopen(arg[2], "wb");
			if (!fin)
			{
				wcout << L"Error in open file '" << arg[1] << L"'" << endl;
				return;
			}
			char buf[256];
			while (!feof(fout)) {
				fread(buf, sizeof(buf), 1, fout);
				fwrite(buf, sizeof(buf), 1, fin);
				wcout << buf;
			}
			fclose(fout);
			fclose(fin);
		}
		if (num < 3)
			wcout << L"unexpected '" << arg[1] << L"' " << endl << L"Type 'help' for more information" << endl;
		if (num > 3) {
			wcout << L"unexpected ";
			for (int i = 0; i < num; i++)
				wcout << L"'" << arg[i] << "' ";
			wcout << endl << L"Type 'help' for more information" << endl;
		}
	}
	else
	{
		wcout << L"Type 'help' for more information" << endl;
	}
}