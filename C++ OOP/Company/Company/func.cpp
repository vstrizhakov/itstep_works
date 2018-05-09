//#include "subheader.h"
//
//void check_fail()
//{
//	if (wcin.fail())
//	{
//		wcin.clear();
//		wcin.ignore(wcin.rdbuf()->in_avail());
//	}
//}
//
//config read_config()
//{
//	FILE* f = fopen("config.txt", "rb");
//	config tmp;
//	if (!f)
//	{
//		f = fopen("config.txt", "wb");
//		tmp.teamnumber = 0;
//		fwrite(&tmp, sizeof(tmp), 1, f);
//	}
//	else
//	{
//		fread(&tmp, sizeof(tmp), 1, f);
//	}
//	fclose(f);
//	return tmp;
//}
//
//Employer* factory(config& null)
//{
//	Employer* tmp;
//	int r = rand() % 101;
//	if (r % 2 == 0)
//	{
//		tmp = new Programmer(Names[rand() % 20], null.teamnumber * 100 + is, 0, rand() % 1001 + 20);
//	}
//	else if (r % 2 == 1 && r > 70)
//		tmp = new Manager(Names[rand() % 20], null.teamnumber * 100 + is, 0, rand() % 5001 + 500);
//	else if (r % 5 == 0 && r % 7 == 0)
//		tmp = new Boss(Names[rand() % 20], null.teamnumber * 100 + is, 0, rand() % 10001 + 10000);
//	else
//		tmp = new Programmer(Names[rand() % 20], null.teamnumber * 100 + is, 0, rand() % 1001 + 20);
//	return tmp;
//}
//
//void SetConfig(config& null)
//{
//	FILE *in = fopen("config.txt", "w");
//	fwrite(&null, sizeof(null), 1, in);
//	fclose(in);
//}
//
//void SaveTeam(int team)
//{
//	char FileName[255];
//	itoa(team, FileName, 10);
//	// Функция itoa преобразует целое число value в строку string в формате radix.
//	//К цифрам числа value подбираются ANSI символы типа char и записываются в строку string.
//	strcat(FileName, ".txt");
//	FILE *out = fopen(FileName, "w");
//	for (int i = 0; i < is; i++)
//		fwrite(Staff[i], sizeof(Staff[i]), 1, out);
//	fclose(out);
//}