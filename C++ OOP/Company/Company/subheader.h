#pragma once
#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>
#include <io.h>
#include <fcntl.h>
#include <conio.h>

using namespace std;

int Days[12] = { 23, 21, 22, 24, 23, 24, 23, 21, 22, 21, 21, 21 };
int index = 0;

class Employer
{
protected:
	wchar_t name[20];
	int tn;
public:
	Employer(wchar_t* name = L"noname", int tn = 0)
	{
		wcscpy(this->name, name);
		this->tn = tn;
	}

	int getTn()
	{
		return this->tn;
	}

	virtual void show()
	{
		wprintf(L"Employer: %s | TN: %d", this->name, this->tn);
	}

	virtual void write(FILE *f) {
		fwrite(this->name, sizeof(this->name), 1, f);
		fwrite(&this->tn, sizeof(tn), 1, f);
	}

	virtual void read(FILE *f) {
		fread(this->name, sizeof(this->name), 1, f);
		fread(&this->tn, sizeof(tn), 1, f);
	}

	//×ÈÑÒÎ ÂÈÐÒÓÀËÜÍÛÅ ÌÅÒÎÄÛ
	virtual double salary() = 0;
	virtual double bonus() = 0;
	virtual double tax(double sum) = 0;
};

class Programmer :public Employer
{
protected:
	int time;
	double hour_rate;
public:
	Programmer(wchar_t* name = L"noname", int n = 0, double time = 0, double hour_rate = 0) :Employer(name, n)
	{
		this->time = time;
		this->hour_rate = hour_rate;
	}

	virtual double salary()
	{
		double sum = 0;
		if (time > 0)
			sum = double(this->time * this->hour_rate);
		return sum;
	}

	virtual double bonus()
	{
		if (this->time > 180)
			return this->time * this->hour_rate;
		else if (this->time > 100)
			return this->time * this->hour_rate / 2;
		else return 0.0;
	}

	virtual double tax(double sum)
	{
		return 0.1 * sum;
	}

	virtual void show()
	{
		wprintf(L"Programmer: %20s | TN: %5d | Working time: %3d | Pay per hour: %4.2F$", this->name, this->tn, this->time, this->hour_rate);
	}

	virtual void write(FILE *f) {
		fwrite(this->name, sizeof(this->name), 1, f);
		fwrite(&this->tn, sizeof(tn), 1, f);
		fwrite(&this->time, sizeof(this->time), 1, f);
		fwrite(&this->hour_rate, sizeof(this->hour_rate), 1, f);
	}

	virtual void read(FILE *f) {
		fread(this->name, sizeof(this->name), 1, f);
		fread(&this->tn, sizeof(tn), 1, f);
		fread(&this->time, sizeof(this->time), 1, f);
		fread(&this->hour_rate, sizeof(this->hour_rate), 1, f);
	}
};

class Manager :public Employer
{
protected:
	int days;
	double month_rate;
public:
	Manager(wchar_t* name = L"noname", int n = 0, int days = 0, int month_rate = 0) :Employer(name, n)
	{
		this->days = days;
		this->month_rate = month_rate;
	}
	
	virtual double salary()
	{
		double sum = 0;
		if(days > 0)
			sum = this->days * this->month_rate / Days[index - 1];
		return sum;
	}

	virtual double bonus()
	{
		if (this->days > 10)
			return this->days * this->month_rate * 0.25;
		else
			return 0.0;
	}

	virtual double tax(double sum)
	{
		return 0.25 * sum;
	}

	virtual void show()
	{
		wprintf(L"Manager: %23s | TN: %5d | Working days: %3d | Pay per month: %4.2F$", this->name, this->tn, this->days, this->month_rate);
	}

	virtual void write(FILE *f) {
		fwrite(this->name, sizeof(this->name), 1, f);
		fwrite(&this->tn, sizeof(tn), 1, f);
		fwrite(&this->days, sizeof(this->days), 1, f);
		fwrite(&this->month_rate, sizeof(this->month_rate), 1, f);
	}

	virtual void read(FILE *f) {
		fread(this->name, sizeof(this->name), 1, f);
		fread(&this->tn, sizeof(tn), 1, f);
		fread(&this->days, sizeof(this->days), 1, f);
		fread(&this->month_rate, sizeof(this->month_rate), 1, f);
	}
};

class Boss :public Employer
{
protected:
	int days;
	double dayRate;
public:
	Boss(wchar_t* name = L"noname", int n = 0, int days = 0, int dayRate = 0) :Employer(name, n)
	{
		this->days = days;
		this->dayRate = dayRate;
	}

	virtual double salary()
	{
		double sum = 0;
		if (days > 0)
			sum = this->days * this->dayRate;
		return sum;
	}

	virtual double bonus()
	{
		if (this->days = 12)
			return this->days * this->dayRate;
		else if (this->days > 5)
			return this->days * this->dayRate / 4;
		else
			return 0.0;
	}

	virtual double tax(double sum)
	{
		return 0.30 * sum;
	}

	virtual void show()
	{
		wprintf(L"Boss: %26s | TN: %5d | Working days: %3d | Pay per day: %4.2F$", this->name, this->tn, this->days, this->dayRate);
	}

	virtual void write(FILE *f) {
		fwrite(this->name, sizeof(this->name), 1, f);
		fwrite(&this->tn, sizeof(tn), 1, f);
		fwrite(&this->days, sizeof(this->days), 1, f);
		fwrite(&this->dayRate, sizeof(this->dayRate), 1, f);
	}

	virtual void read(FILE *f) {
		fread(this->name, sizeof(this->name), 1, f);
		fread(&this->tn, sizeof(tn), 1, f);
		fread(&this->days, sizeof(this->days), 1, f);
		fread(&this->dayRate, sizeof(this->dayRate), 1, f);
	}
};

struct config
{
	int teamnumber;
};

Employer* Staff[100];

struct db
{
	int month;
	int tn;
	double s;
	double b;
	double t;
}Archive[500];
int ia = 0;

void SetConfig(config& null);
void check_fail();
config read_config();
Employer* factory(config& null);
void SaveTeam(int team);