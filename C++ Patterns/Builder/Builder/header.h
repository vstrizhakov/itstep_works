#pragma once
#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h> 
#include <vector>
#include <algorithm>
#include <numeric>
#include <functional>
#include <string>

using namespace std;

class PC
{
	vector<string> parts;
public:
	void AddPart(string part)
	{
		parts.push_back(part);
	}

	void Show()
	{
		cout << "System block:" << endl;
		for (int i = 0; i < parts.size(); i++)
		{
			cout << parts[i] << endl;
		}
	}
};

class ABuilder
{
public:
	virtual void BuildCPU() = 0;
	virtual void BuildMB() = 0;
	virtual void BuildHDD() = 0;
	virtual void BuildRAM() = 0;
	virtual PC GetPC() = 0;
};

class Builder1 :public ABuilder
{
	PC pc;
public:
	void BuildCPU()
	{
		pc.AddPart("CPU: Intel Core Duo");
	}

	void BuildMB()
	{
		pc.AddPart("Motherboard: ASUS");
	}

	void BuildHDD()
	{
		pc.AddPart("HDD: 1TB");
	}

	void BuildRAM()
	{
		pc.AddPart("RAM: DDR3200");
		pc.AddPart("RAM: DDR3200");
	}

	PC GetPC() { return pc; }
};

class Builder2 :public ABuilder
{
	PC pc;
public:
	void BuildCPU()
	{
		pc.AddPart("CPU: Intel Core Duo 2");
	}

	void BuildMB()
	{
		pc.AddPart("Motherboard: ASUS 2");
	}

	void BuildHDD()
	{
		pc.AddPart("HDD: 2TB");
	}

	void BuildRAM()
	{
		pc.AddPart("RAM: DDR1600");
		pc.AddPart("RAM: DDR1600");
	}

	PC GetPC() { return pc; }
};

class Builder3 :public ABuilder
{
	PC pc;
public:
	void BuildCPU()
	{
		pc.AddPart("CPU: Intel Core Duo 3");
	}

	void BuildMB()
	{
		pc.AddPart("Motherboard: ASUS 3");
	}

	void BuildHDD()
	{
		pc.AddPart("HDD: 500GB");
	}

	void BuildRAM()
	{
		pc.AddPart("RAM: DDR800");
		pc.AddPart("RAM: DDR800");
	}

	PC GetPC() { return pc; }
};

class Director
{
public:
	PC CreatePC(ABuilder* builder)
	{
		builder->BuildCPU();
		builder->BuildMB();
		builder->BuildRAM();
		builder->BuildHDD();
		return builder->GetPC();
	}
};
