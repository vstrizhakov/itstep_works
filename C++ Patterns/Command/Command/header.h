#pragma once
#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h>
#include <vector>
#include <functional>
#include <algorithm>
#include "header.h"

using namespace std;

class Calculator
{
	double result;
public:
	Calculator()
	{
		this->result = 0;
	}

	void Action(char operator_, double operand)
	{
		switch (operator_)
		{

		case '+':
		{
			this->result += operand;
			break;
		}

		case '-':
		{
			this->result -= operand;
			break;
		}

		case '*':
		{
			this->result *= operand;
			break;
		}

		case '/':
		{
			this->result /= operand;
			break;
		}

		}
		cout << "Result: " << result << endl;
	}
};

class Command
{
public:
	virtual void Execute() = 0;
	virtual void Unexecute() = 0;
};

class CalcCommand :public Command
{
	char operator_;
	double operand;
	Calculator* calculator;
public:
	CalcCommand(Calculator* calculator, char operator_, double operand)
	{
		this->operator_ = operator_;
		this->calculator = calculator;
		this->operand = operand;
	}

	void SetOperator(char operator_)
	{
		this->operator_ = operator_;
	}

	void SetOperand(double operand)
	{
		this->operand = operand;
	}

	char GetOperator()
	{
		return this->operator_;
	}

	double GetOperand()
	{
		return this->operand;
	}

	virtual void Execute()
	{
		calculator->Action(this->operator_, this->operand);
	}

	virtual void Unexecute()
	{
		char undo;
		switch (operator_)
		{

		case '+':
		{
			undo = '-';
			break;
		}

		case '-':
		{
			undo = '+';
			break;
		}

		case '*':
		{
			undo = '/';
			break;
		}

		case '/':
		{
			undo = '*';
			break;
		}

		}
		calculator->Action(undo, this->operand);
	}
};

class User
{
	Calculator calculator;
	vector<Command*> commands;
	int operations;
public:
	User()
	{
		this->operations = 0;
	}

	void Compute(char operator_, double operand)
	{
		Command* command = new CalcCommand(&calculator, operator_, operand);
		command->Execute();
		commands.push_back(command);
		operations++;
	}

	void Undo(int count)
	{
		cout << "Undo " << count << " command(s)" << endl;
		for (int i = 0; i < count; i++)
		{
			if (operations > 0)
			{
				commands[--operations]->Unexecute();
			}
		}
	}

	void Redo(int count)
	{
		cout << "Redo " << count << " command(s)" << endl;
		for (int i = 0; i < count; i++)
		{
			if (operations <= commands.size())
			{
				commands[operations++]->Execute();
			}
		}
	}
};