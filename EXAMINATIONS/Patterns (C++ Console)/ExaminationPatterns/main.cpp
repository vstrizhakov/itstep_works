#include <iostream>
#include <fstream>
#include <iomanip>
#include <Windows.h>
#include <conio.h>
#include <vector>
#include <string>
#include <algorithm>
#include <stdio.h>
#include <conio.h>
#include <cmath>
#include <map>
#include "player.h"
#include "sponsor.h"
#include "coach.h"
#include "factory.h"
#include "club.h"

using namespace std;

vector<string> InitNames()
{
	vector<string> names;
	char c;
	string tmp;
	ifstream in("players.dat");
	while (!in.eof())
	{
		in.read((char*)&c, sizeof(c));
		//'\n' - �����������
		if (c == '\n' || in.eof())
		{
			names.push_back(tmp);
			tmp.clear();
			continue;
		}
		tmp += c;
	}
	in.close();
	return names;
}

vector<string> InitClubs()
{
	vector<string> clubs;
	char c;
	string tmp;
	ifstream in("clubs.dat");
	while (!in.eof())
	{
		in.read((char*)&c, sizeof(c));
		//'\n' - �����������
		if (c == '\n' || in.eof())
		{
			clubs.push_back(tmp);
			tmp.clear();
			continue;
		}
		tmp += c;
	}
	in.close();
	return clubs;
}

void ShowPlayer(Player* p)
{
	p->Show();
}

Club* PlayGame(Club* c1 = NULL, Club* c2 = NULL)
{
	Club* tmp;
	if (c1 == NULL && c2 == NULL)
	{
		tmp = NULL;
	}
	else
	{
		if (c2 == NULL) //��� ���������� ������ �� ��������������� (2^n), ���� ��� �� ������������
		{
			cout << setw(20) << c1->GetName() << " 0 : " << endl;
			tmp = c1;
		}
		else
		{
			//���� #1
			int c1Attack = c1->GetAttack();
			int c1Defend = c1->GetStrikersAndMiedlefielderDefend();
			int c1GoalkeeperDefend = c1->GetGoalkeeperDefend();
			int c1goals = 0;
			int c1rounds = 0;
			//���� #2
			int c2Attack = c2->GetAttack();
			int c2Defend = c2->GetStrikersAndMiedlefielderDefend();
			int c2GoalkeeperDefend = c2->GetGoalkeeperDefend();
			int c2goals = 0;
			int c2rounds = 0;

			for (int j = 0; j < 3; j++)
			{
				c1goals = 0;
				c2goals = 0;
				for (int i = 0; i < 5; i++)
				{
					//���� ���� #1 ��������� Strikers � Middlefielders ������ ����� #2 ��� ���� #2 ������� �� 1�� �������
					if (c2Defend == 0 || rand() % c1Attack > rand() % c2Defend)
					{
						//���� ������� ����� ����� #1 ��������� ������ Goalkeeper ����� #2
						if (rand() % (c1Attack / c1->GetSize()) > rand() % c2GoalkeeperDefend)
							c1goals++;
					}
					//���� ���� #2 ��������� Strikers � Middlefielders ������ ����� #1 ��� ���� #2 ������� �� 1�� �������
					if (c1Defend == 0 || rand() % c2Attack > rand() % c1Defend)
					{
						//���� ������� ����� ����� #2 ��������� ������ Goalkeeper ����� #1
						if (rand() % (c2Attack / c2->GetSize()) > rand() % c1GoalkeeperDefend)
							c2goals++;
					}
				}
				if (c1goals > c2goals)
					c1rounds++;
				else if (c1goals < c2goals)
					c2rounds++;
				else
				{
					c1rounds++;
					c2rounds++;
				}
				//���� �������� >= 3 ������, �� ���� ������, �� ������ ���
				if (c1rounds == c2rounds && j == 2)
					j--;
				//���� �����-�� ������� ��������� ������ 2 ������, ������� �� �����������
				if (c1rounds == 0 && c2rounds == 2)
					break;
				if (c1rounds == 2 && c2rounds == 0)
					break;
			}
			cout << setw(20) << c1->GetName() << " " << c1rounds << " : " << c2rounds << " " << c2->GetName() << endl;
			if (c1rounds > c2rounds)
				tmp = c1;
			else if (c2rounds > c1rounds)
				tmp = c2;
		}
	}
	return tmp;
}

void check_fail()
{
	if (cin.fail())
	{
		cin.clear();
		cin.ignore(cin.rdbuf()->in_avail());
	}
	else
	{
		cin.ignore(cin.rdbuf()->in_avail());
	}
}

map<int, int> InitDegrees()
{
	map<int, int> tmp;
	tmp.insert(make_pair(2, 1));
	tmp.insert(make_pair(4, 2));
	tmp.insert(make_pair(8, 3));
	tmp.insert(make_pair(16, 4));
	tmp.insert(make_pair(32, 5));
	tmp.insert(make_pair(64, 6));
	return tmp;
}

Player* ClubFactory::StaticGoalkeeper = NULL;
Player* ClubFactory::StaticMiddlefielder = NULL;
Player* ClubFactory::StaticStriker = NULL;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));
	//�������������� ��������� Striker, Middlefielder, Goalkeeper
	ClubFactory::InitPlayers();
	//�������������� ����������� ���-�� ������ � �� ������� ��� ����� 2
	map<int, int> degrees = InitDegrees();
	vector<vector<Club*>> qualifyRounds;
	vector<Club*> tmp;
	//���-�� ������ 2/4/8/16/3264, ������ ��� �� ������� ���-�� �� ������ ����/��������
	int teamsCount = 0;
	do
	{
		cout << "������� ���������� ������� (2/4/16/32/64): ";
		cin >> teamsCount;
		check_fail();
	} while (!degrees[teamsCount]);
	//������� ������ �� 1-�� ���������� ���
	for (int i = 0; i < teamsCount; i++)
		tmp.push_back(new Club);
	qualifyRounds.push_back(tmp);
	//������� ������ ������
	for (int i = 0; i < teamsCount; i++)
		qualifyRounds[0][i]->ShowTeam();
	cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
	//�������� 1-�� ���������� ���
	cout << "~~~~~~~~~~~~~~~~~~~~ 1-� ���� ~~~~~~~~~~~~~~~~~~~~" << endl;
	tmp.clear();
	for (int i = 0; i < teamsCount; i += 2)
	{
		try //����������� ��� ������ �� ��������������� (2^n), �� ���� ��� �� ������������
		{
			if (i + 1 > teamsCount - 1)
				throw 1;
			tmp.push_back(PlayGame(qualifyRounds[0][i], qualifyRounds[0][i + 1]));
		}
		catch (int)
		{
			tmp.push_back(PlayGame(qualifyRounds[0][i]));
		}
	}
	qualifyRounds.push_back(tmp);
	//���������� ��������� ���������� ����, ���� ���������� ������ > 2. ���-�� ���������� ����� ������� �� ���-�� ������
	int j = 0;
	for (j = 1; j < degrees[teamsCount] && teamsCount > 2; j++)
	{
		cout << "~~~~~~~~~~~~~~~~~~~~ " << j + 1 << "-� ���� ~~~~~~~~~~~~~~~~~~~~" << endl;
		tmp.clear();
		for (int i = 0; i < teamsCount / pow(2, j); i += 2)
		{
			try //����������� ��� ������ �� ��������������� (2^n), �� ���� ��� �� ������������+
			{
				if (i + 1 > teamsCount / pow(2, j))
					throw 1;
				tmp.push_back(PlayGame(qualifyRounds[j][i], qualifyRounds[j][i + 1]));
			}
			catch (int)
			{
				tmp.push_back(PlayGame(qualifyRounds[j][i]));
			}
		}
		qualifyRounds.push_back(tmp);
	}
	cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
	cout << setw(25) << "����������: " << qualifyRounds[j][0]->GetName() << endl;
}