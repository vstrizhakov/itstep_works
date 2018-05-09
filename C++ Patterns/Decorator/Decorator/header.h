#pragma once

using namespace std;

class Text
{
protected:
	string text;
public:

	virtual void Display()
	{
		cout << this->text << endl;
	}

	virtual void CreateFile_(string file)
	{
		ofstream out(file);
		out << this->text << endl;
		out.close();
	}

	void SetText(string text)
	{
		this->text = text;
	}

	string GetText()
	{
		return this->text;
	}
};

class AbDecorator :public Text
{
protected:
	Text* dtext;
public:
	AbDecorator(Text* dtext)
	{
		this->dtext = dtext;
	}
};

class BoldDecorator : public AbDecorator
{
public:
	BoldDecorator(Text* dtext) :AbDecorator(dtext)
	{
		SetText("<b>" + dtext->GetText() + "</b>");
	}
};

class ItalicDecorator :public AbDecorator
{
public:
	ItalicDecorator(Text* dtext) :AbDecorator(dtext)
	{
		SetText("<i>" + dtext->GetText() + "</i>");
	}
};

class BigDecorator :public AbDecorator
{
public:
	BigDecorator(Text* dtext) :AbDecorator(dtext)
	{
		SetText("<big>" + dtext->GetText() + "</big>");
	}
};