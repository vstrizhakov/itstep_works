#pragma once
#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>
#include <io.h>
#include <fcntl.h>

using namespace std;

class CPU
{
public:
	wchar_t name[64];
	double f;
	CPU(wchar_t* n = L"unknown", double f = 0)
	{
		wcscpy(this->name, n);
		if (f > 0)
			this->f = f;
		else
			this->f = 0;
	}
	friend wostream& operator<<(wostream& os, const CPU& c)
	{
		os << L"CPU: Name: " << c.name << L" | Frequency: " << c.f;
		return os;
	}
};

class RAM
{
public:
	int ram;
	RAM(int ram = 0)
	{
		if (ram > 0)
			this->ram =ram;
		else
			this->ram = 0;
	}
	friend wostream& operator<<(wostream& os, const RAM& r)
	{
		os << L"RAM: " << r.ram;
		return os;
	}
};

class HDD
{
public:
	int hdd;
	HDD(int hdd = 0)
	{
		if (hdd > 0)
			this->hdd = hdd;
		else
			this->hdd = 0;
	}
	friend wostream& operator<<(wostream& os, const HDD& h)
	{
		os << L"HDD: " << h.hdd;
		return os;
	}
};

class Motherboard
{
public:
	wchar_t name[128];
	Motherboard(wchar_t* name = L"unknown") {
		wcscpy(this->name, name);
	}
	friend wostream& operator<<(wostream& os, const Motherboard& m)
	{
		os << L"Motherboard: " << m.name;
		return os;
	}
};

class PC1
{
public:
	CPU* cm;
	RAM* ram;
	HDD* hdd;
	Motherboard* mb;

	PC1() {}
	PC1(CPU* c, RAM* r, HDD* h, Motherboard* m)
	{
		cm = new CPU;
		cm->f = c->f;
		wcscpy(cm->name, c->name);
		ram = new RAM;
		ram->ram = r->ram;
		hdd = new HDD;
		hdd->hdd = h->hdd;
		mb = new Motherboard;
		wcscpy(mb->name, m->name);
	}
	friend wostream& operator<<(wostream& os, const PC1 pc)
	{
		os << *pc.cm << endl;
		os << *pc.ram << endl;
		os << *pc.hdd << endl;
		os << *pc.mb << endl;
		return os;
	}
};