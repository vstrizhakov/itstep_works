#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>
#include <io.h>
#include <fcntl.h>
#include <conio.h>
#include "sponsor.h"
#include "player.h"
#include "coach.h"
#include "club.h"

using namespace std;

void game(Club c1, Club c2)
{
	int att1 = c1.getTotalAttack();
	int def1 = c1.getTotalDefense();
	int att2 = c2.getTotalAttack();
	int def2 = c2.getTotalDefense();
	int goal1 = 0, goal2 = 0;
	for (int i = 0; i < 5; i++)
	{
		int a1 = rand() % att1;
		int a2 = rand() % att2;
		int d1 = rand() % def1;
		int d2 = rand() % def2;
		if (a1 - d2 - c2.getGoalkeeperSkill() > 0)
			goal1++;
		if (a2 - d1 - c1.getGoalkeeperSkill() > 0)
			goal2++;
	}
	wprintf(L"%20s : %s\n", c1.getName(), c2.getName());
	wprintf(L"%20d : %d\n", goal1, goal2);

	FILE *out = fopen("score.txt", "w");
	fprintf(out, "%s", c1.getName());
	fclose(out);
}

void main(int num, char *arg[])
{
	_setmode(_fileno(stdout), _O_U8TEXT);
	_setmode(_fileno(stdin), _O_U8TEXT);
	_setmode(_fileno(stderr), _O_U8TEXT);
	srand(time(NULL));
	Sponsor s1;
	Coach coach(&s1);
	Club club(&coach);
	Sponsor s2;
	Coach coach2(&s2);
	Club club2(&coach2);

	club.teamFactory();
	club.sortTeam();
	club.optimizeTeam();
	club.sortTeam();
	club.showTeam();

	club2.teamFactory();
	club2.sortTeam();
	club2.optimizeTeam();
	club2.sortTeam();
	club2.showTeam();

	game(club, club2);
}