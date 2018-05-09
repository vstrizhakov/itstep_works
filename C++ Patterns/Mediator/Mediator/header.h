#pragma once

using namespace std;

class AbMediator;

class AbChatter
{
protected:
	string name;
public:
	AbChatter(string name)
	{
		this->name = name;
	}

	string GetName()
	{
		return this->name;
	}

	virtual void SendMsg(AbMediator* abm, string msg) = 0;
	virtual void ReceiveMsg(AbChatter* abc, string msg) = 0;
};

class AbMediator
{
protected:
	vector<AbChatter*> chatters;
public:
	virtual void AddChatter(AbChatter* abc)
	{
		chatters.push_back(abc);
	}

	virtual void TransferMsg(AbChatter* abc, string msg) = 0;
};

class Chatter :public AbChatter
{
public:
	Chatter(string name) :AbChatter(name) {}

	virtual void SendMsg(AbMediator* abm, string msg)
	{
		abm->TransferMsg(this, msg);
	}

	virtual void ReceiveMsg(AbChatter* abc, string msg)
	{
		cout << this->GetName() << " received message from " << abc->GetName() << endl;
	}
};

class Mediator1 :public AbMediator
{
public:
	virtual void TransferMsg(AbChatter* abc, string msg)
	{
		vector<AbChatter*>::iterator it = chatters.begin();
		for (it; it != chatters.end(); it++)
		{
			if (*it != abc)
			{
				(*it)->ReceiveMsg(abc, msg);
			}
		}
	}
};

//class Mediator2 :public AbMediator
//{
//public:
//	virtual void TransferMsg(AbChatter* abc, string msg)
//	{
//		vector<AbChatter*>::iterator it = chatters.begin();
//		for (it; it != chatters.end(); it++)
//		{
//			if (*it != abc)
//			{
//				(*it)->ReceiveMsg(abc, msg);
//			}
//		}
//	}
//
//	virtual void SendMsg(AbMediator* abm, string msg)
//	{
//		int len = msg.length();
//		msg = to_string(len);
//		abm->TransferMsg(this, msg);
//	}
//};