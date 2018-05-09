#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>
#include <fstream>
#include <conio.h>
#include "person.h"
#include "contact.h"
#include "friend.h"

using namespace std;

char db[255] = "db.txt";
char list[255] = "list.txt";
char Log[255] = "log.dat";

fstream out;
fstream out1;
fstream out2;

void check_fail()
{
	if (cin.fail())
	{
		cin.clear();
		cin.ignore(cin.rdbuf()->in_avail());
	}
	else
		cin.ignore(cin.rdbuf()->in_avail());
}

void init()
{
	out.open(db, ios::out | ios::in | ios::binary | ios::ate);
	out1.open(list, ios::out | ios::in | ios::ate);
	out2.open(Log, ios::out | ios::in | ios::ate);
}

void exit()
{
	out.close();
	out1.close();
	out2.close();
}


void search(char* tmp)
{
	out.seekg(0, ios::beg);
	int num = 1, id;
	Friend f1;
	Contact c1;
	while (!out.eof())
	{
		out.read((char*)&id, sizeof(id));
		if (id == 1)
		{
			out.read((char *)&f1, sizeof(f1));
			if (!out.eof())
			{
				if (strstr(f1.firstname, tmp) != NULL
					|| strstr(f1.surname, tmp) != NULL
					|| strstr(f1.sex, tmp) != NULL
					|| strstr(f1.phone, tmp) != NULL
					|| strstr(f1.email, tmp) != NULL
					|| strstr(f1.birthday, tmp) != NULL
					|| strstr(f1.address, tmp) != NULL)
				{
					cout << num++ << ". ";
					f1.Show();
				}
			}
		}
		else
		{
			out.read((char *)&c1, sizeof(c1));
			if (!out.eof())
			{
				if (strstr(c1.firstname, tmp) != NULL
					|| strstr(c1.surname, tmp) != NULL
					|| strstr(c1.sex, tmp) != NULL
					|| strstr(c1.phone, tmp) != NULL
					|| strstr(c1.email, tmp) != NULL)
				{
					cout << num++ << ". ";
					c1.Show();
				}
			}
		}
	}
	if (num == 1)
		cout << "~~~~~~~~~~~~~~~~~~~~ Результатов по вашему запросу не найдено! ~~~~~~~~~~~~~~~~~~~~";
}

int contactList()
{
	Friend f1;
	Contact c1;
	int id = 0, num = 0;
	out.seekg(0, ios::beg);
	while (!out.eof())
	{
		out.read((char *)&id, sizeof(id));
		if (id == 1)
		{
			out.read((char *)&f1, sizeof(f1));
			if (!out.eof())
			{
				cout << ++num << ". ";
				f1.Show();
			}
		}
		else
		{
			out.read((char *)&c1, sizeof(c1));
			if (!out.eof())
			{
				cout << ++num << ". ";
				c1.Show();
			}
		}
	}
	return num;
}

int main()
{
	setlocale(LC_ALL, "rus");
	short k = 1, en = 0;
	do
	{
		if (en == 80)
		{
			k++;
			if (k == 7) k = 1;
		}
		if (en == 72)
		{
			k--;
			if (k == 0) k = 6;
		}
		if (en == 13)
		{
			switch (k)
			{

			case 1:
			{
				init();
				system("cls");
				cout << "--------------------------------------------------------------------------------------------------------------\n";
				cout << "Add new contact\n";
				cout << "--------------------------------------------------------------------------------------------------------------\n";
				char fname[32] = "";
				char lname[32] = "";
				char sex[32] = "";
				char phone[32] = "";
				char email[64] = "";
				char bday[32] = "";
				char address[64] = "";

				do
				{
					cout << "Enter firstname: ";
					cin.getline(fname, 32);
					check_fail();
				} while (cin.fail());

				do
				{
					cout << "Enter lastname: ";
					cin.getline(lname, 32);
					check_fail();
				} while (cin.fail());

				do
				{
					cout << "Enter sex: ";
					cin.getline(sex, 32);
					check_fail();
				} while (cin.fail());

				do
				{
					cout << "Enter phone: ";
					cin.getline(phone, 32);
					check_fail();
				} while (cin.fail());

				do
				{
					cout << "Enter email: ";
					cin.getline(email, 64);
					check_fail();
				} while (cin.fail());

				int f = 0;
				do
				{
					cout << "Is it your friend? (0/1): ";
					cin >> f;
					check_fail();
				} while (f > 1 || f < 0);

				if (f == 1)
				{
					do
					{
						cout << "Enter bday: ";
						cin.getline(bday, 32);
						check_fail();
					} while (cin.fail());

					do
					{
						cout << "Enter address: ";
						cin.getline(address, 64);
						check_fail();
					} while (cin.fail());
				}
				out.write((char *)&f, sizeof(f));
				if (f == 1)
				{
					Friend *c = new Friend(fname, lname, sex, phone, email, bday, address);
					out.write((char *)c, sizeof(*c));
					delete c;
				}
				else
				{
					Contact *c = new Contact(fname, lname, sex, phone, email);
					out.write((char *)c, sizeof(*c));
					delete c;
				}
				exit();
				system("pause");
				break;
			}

			case 2:
			{
				system("cls");
				init();
				Friend f1;
				Contact c1;
				int id = 0;
				char tmp[64] = "";
				out.seekg(0, ios::beg);
				cout << "Enter template of search: ";
				cin >> tmp;
				search(tmp);
				system("pause");
				exit();
				break;
			}

			case 3:
			{
				system("cls");
				init();
				int num = contactList();
				exit();
				int edit = 0;
				do
				{
					cout << "Enter item num what you want to edit(1-" << num << "): ";
					cin >> edit;
					check_fail();
				} while (edit > num || edit < 1);
				Friend friends[100];
				Contact contacts[100];
				Friend f1;
				Contact c1;
				int a = 0, fi = 0, ci = 0;
				bool isFriend = false;
				init();
				out.seekg(0, ios::beg);
				for (int i = 0; i < num; i++)
				{
					out.read((char *)&a, sizeof(a));
					if (a == 1)
					{
						out.read((char *)&f1, sizeof(f1));
						if (i != edit - 1)
							friends[fi++] = f1;
					}
					else
					{
						out.read((char *)&c1, sizeof(c1));
						if (i != edit - 1)
							contacts[ci++] = c1;
					}
				}
				exit();
				init();
				out.seekg(0, ios::beg);
				for (int i = 0; i < edit; i++)
				{
					out.read((char *)&a, sizeof(a));
					if (a == 1)
					{
						out.read((char *)&f1, sizeof(f1));
						isFriend = true;
					}
					else
					{
						out.read((char *)&c1, sizeof(c1));
						isFriend = false;
					}
				}
				exit();
				cout << "Firstname - 1" << endl;
				cout << "Lastname - 2" << endl;
				cout << "Phone - 3" << endl;
				cout << "Email - 4" << endl;
				int ch;
				do
				{
					cout << "What do you want to edit: ";
					cin >> ch;
					check_fail();
				} while (ch > 4 || ch < 1);
				char temp[64];
				do
				{
					cout << "Enter new info: ";
					cin.getline(temp, 64);
					check_fail();
				} while (cin.fail());
				switch (ch)
				{
				case 1:
					(isFriend) ? strcpy(f1.firstname, temp) : strcpy(c1.firstname, temp);
					break;
				case 2:
					(isFriend) ? strcpy(f1.surname, temp) : strcpy(c1.surname, temp);
					break;
				case 3:
					(isFriend) ? strcpy(f1.phone, temp) : strcpy(c1.phone, temp);
					break;
				case 4:
					(isFriend) ? strcpy(f1.email, temp) : strcpy(c1.email, temp);
					break;
				}
				if (isFriend)
				{
					friends[fi++] = f1;
					for (int i = 0; i < fi; i++)
						friends[i].Show();
				}
				else
				{
					contacts[ci++] = c1;
					for (int i = 0; i < ci; i++)
						contacts[i].Show();
				}
				system("pause");
				init();
				out.seekp(0, ios::beg);
				edit = 1;
				for (int i = 0; i < fi; i++)
				{
					out.write((char *)&edit, sizeof(edit));
					out.write((char *)&friends[i], sizeof(friends[i]));
				}
				edit = 0;
				for (int i = 0; i < ci; i++)
				{
					out.write((char *)&edit, sizeof(edit));
					out.write((char *)&contacts[i], sizeof(contacts[i]));
				}
				exit();
				break;
			}

			case 4:
			{
				init();
				exit();
				break;
			}

			case 5:
			{
				system("cls");
				init();
				contactList();
				exit();
				system("pause");
				break;
			}

			default:
			{
				exit(0);
				break;
			}
			}
		}
		system("cls");
		if (k == 1) cout << "-> ";
		cout << "Add new contact" << endl;
		if (k == 2) cout << "-> ";
		cout << "Find contatct" << endl;
		if (k == 3) cout << "-> ";
		cout << "Edit contact" << endl;
		if (k == 4) cout << "-> ";
		cout << "Remove contact" << endl;
		if (k == 5) cout << "-> ";
		cout << "My contacts" << endl;
		if (k == 6) cout << "-> ";
		cout << "Exit" << endl;
	} while (en = getch());

	return 0;
}