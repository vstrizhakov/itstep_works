#include "subheader.h"

wchar_t Names[20][20] = { L"Vladimir", L"Ivan",L"Sergey",L"Michael",L"Nikita",L"Ilya",L"Simon",L"Ronald",L"Andrey",L"Denis",L"Artem",L"Evgeniy",L"Vitaly",L"Danil",L"Aleksey",L"Alexandr",L"John",L"Robert",L"Peter",L"Arkady" };
int is = 0;
int id[3] = { 0, 1, 2 };

struct buf
{
	wchar_t name[20];
	int tn;
	int time;
	double rate;
};

void check_fail()
{
	if (wcin.fail())
	{
		wcin.clear();
		wcin.ignore(wcin.rdbuf()->in_avail());
	}
}

config read_config()
{
	FILE* f = fopen("config.txt", "rb");
	config tmp;
	if (!f)
	{
		f = fopen("config.txt", "wb");
		tmp.teamnumber = 0;
		fwrite(&tmp, sizeof(tmp), 1, f);
	}
	else
	{
		fread(&tmp, sizeof(tmp), 1, f);
	}
	fclose(f);
	return tmp;
}

Employer* factory(config& null)
{
	Employer* tmp;
	int r = rand() % 101;
	if (r % 2 == 0)
		tmp = new Programmer(Names[rand() % 20], (null.teamnumber + 1) * 100 + is, rand() % 24, rand() % 1001 + 20);
	else if (r % 2 == 1 && r < 70)
		tmp = new Manager(Names[rand() % 20], (null.teamnumber + 1) * 100 + is, rand() % 10 + 5, rand() % 5001 + 500);
	else if (r % 5 == 0 && r > 70)
		tmp = new Boss(Names[rand() % 20], (null.teamnumber + 1) * 100 + is, rand() % 22 + 10, rand() % 10001 + 10000);
	else
		tmp = new Programmer(Names[rand() % 20], (null.teamnumber + 1) * 100 + is, rand() % 24, rand() % 1001 + 20);
	return tmp;
}

void SetConfig(config& null)
{
	FILE *in = fopen("config.txt", "wb");
	fwrite(&null, sizeof(null), 1, in);
	fclose(in);
}

void SaveTeam(int team)
{
	char FileName[255];
	itoa(team, FileName, 10);
	// Функция itoa преобразует целое число value в строку string в формате radix.
	//К цифрам числа value подбираются ANSI символы типа char и записываются в строку string.
	strcat(FileName, ".txt");
	FILE *out = fopen(FileName, "wb");
	for (int i = 0; i < is; i++)
	{
		if (typeid(*Staff[i]) == typeid(Programmer))
			fwrite(&id[0], sizeof(int), 1, out);
		else if (typeid(*Staff[i]) == typeid(Manager))
			fwrite(&id[1], sizeof(int), 1, out);
		else if (typeid(*Staff[i]) == typeid(Boss))
			fwrite(&id[2], sizeof(int), 1, out);
		Staff[i]->write(out);
	}
	fclose(out);
}

void readTeam(int team)
{
	char FileName[255];
	itoa(team, FileName, 10);
	strcat(FileName, ".txt");
	FILE* in = fopen(FileName, "rb");
	is = -1;
	int i;
	while (!feof(in))
	{
		is++;
		fread(&i, sizeof(int), 1, in);
		if (i == 0)
			Staff[is] = new Programmer;
		else if (i == 1)
			Staff[is] = new Manager;
		else if (i == 2)
			Staff[is] = new Boss;
		Staff[is]->read(in);
	}
	fclose(in);
}

void clr() {
	for (int i = 0; i < is; i++)
		delete Staff[i];
	is = 0;
}

void main()
{
	_setmode(_fileno(stdout), _O_U8TEXT);
	_setmode(_fileno(stdin), _O_U8TEXT);
	_setmode(_fileno(stderr), _O_U8TEXT);
	srand(time(NULL));
	config null = read_config();
	short en = 0, k = 1;
	int num;
	do {
		if (en == 72)
		{
			k--;
			if (k == 0) k = 5;
		}
		if (en == 80)
		{
			k++;
			if (k == 6) k = 1;
		}
		if (en == 13)
		{
			switch (k)
			{
			case 1:
			{
				int team = null.teamnumber + 1;
				num = rand() % 10 + 5;
				wcout << endl;
				for (int i = 0; i < num; i++)
					Staff[is++] = factory(null);
				for (int i = 0; i < is; i++)
				{
					Staff[i]->show();
					wcout << endl;
				}
				SaveTeam(team);
				null.teamnumber = team;
				SetConfig(null);
				clr();
				wcout << endl << L"Staff hired. Please, click button to continue" << endl;
				system("pause");
				break;
			}
			case 2:
			{
				int team = null.teamnumber;
				wcout << L"Select team from 1 to " << team << ": ";
				do
				{
					wcin >> team;
					check_fail();
				} while (team < 1 || team > null.teamnumber);
				readTeam(team);
				for (int i = 0; i < is; i++)
				{
					Staff[i]->show();
					wcout << endl;
				}
				system("pause");
				break;
			}
			case 3:
			{
				wcout << L"Enter month: ";
				do
				{
					wcin >> index;
					check_fail();
				} while (index < 1 || index > 12);
				for (int i = 0; i < is;i++)
				{
					double s = Staff[i]->salary();
					double b = Staff[i]->bonus();
					double t = Staff[i]->tax(s + b);
					db Db;
					Db.month = index;
					Db.s = s;
					Db.b = b;
					Db.t = t;
					Archive[ia++] = Db;
					Staff[i]->show();
					wprintf(L" | S: %5.2F |  B: %5.2F | T: %5.2F\n", Archive[i].s, Archive[i].b, Archive[i].t);
				}
				system("pause");
				break;
			}
			case 4:
			{
				wcout << L"Enter month: ";
				do
				{
					wcin >> index;
					check_fail();
				} while (index < 1 || index > 12);
				for (int i = 0; i < ia; i++)
				{
					if (Archive[i].month == index)
					{
						Staff[i]->show();
						wprintf(L" | S: %5.2F |  B: %5.2F | T: %5.2F\n", Archive[i].s, Archive[i].b, Archive[i].t);
					}					
				}
				system("pause");
				break;
			}
			default:
				exit(0);
				break;
			}
		}
		system("cls");
		if (k == 1)
		{
			wcout << L" -> ";
		}
		wcout << L"1. Hire staff" << endl;
		if (k == 2)
		{
			wcout << L" -> ";
		}
		wcout << L"2. Select project" << endl;
		if (k == 3)
		{
			wcout << L" -> ";
		}
		wcout << L"3. Accrue salary" << endl;
		if (k == 4)
		{
			wcout << L" -> ";
		}
		wcout << L"4. Show reports" << endl;
		if (k == 5)
		{
			wcout << L" -> ";
		}
		wcout << L"0. Exit programm" << endl;
		wcout << L"---------------------------" << endl;
		wcout << L"Select action:" << endl;
	} while (en = getch());
}
