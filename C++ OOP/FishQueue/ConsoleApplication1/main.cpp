#pragma once
#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>
#include <io.h>
#include <fcntl.h>

using namespace std;

enum ConsoleColor {
	Black, Blue, Green, Cyan, Red, Magenta, Brown, LightGray, DarkGray,
	LightBlue, LightGreen, LightCyan, LightRed, LightMagenta, Yellow, White
};

class Fish
{
private:
	wchar_t name[20];
	double weight;
	double price;
public:
	Fish(wchar_t *name = L"noname", double weight = 0, double price = 0)
	{
		if (weight >= 0 && price >= 0)
		{
			wcscpy(this->name, name);
			this->weight = weight;
			this->price = price;
		}
	}

	Fish(const Fish& f) {
		wcscpy(this->name, f.name);
		this->weight = f.weight;
		this->price = f.price;
	}

	Fish& operator=(Fish& f) {
		this->price = f.price;
		this->weight = f.weight;
		wcscpy(this->name, f.name);
		return *this;
	}

	friend wostream &operator<<(wostream &os, Fish &a)
	{
		os << "  Name : " << a.name << " | Weight : " << a.weight << " | Price : " << a.price << endl;
		return os;
	}
	void setName(wchar_t* name) {
		wcscpy(this->name, name);
	}
	void setWeight(double w) {
		this->weight = w;
	}
	void setPrice(double p) {
		this->price = p;
	}
	wchar_t* getName() {
		return this->name;
	}
	double getWeight() {
		return this->weight;
	}
	double getPrice() {
		return this->price;
	}
};

template <typename T>
class FQueue {
public:
	T *data;
	int size, last;
public:
	bool full() {
		return this->last == this->size;
	}
	bool empty() {
		return this->last == 0;
	}
	FQueue(int size = 10) {
		if (size > 0) {
			this->size = size;
			data = new T[this->size];
			this->last = 0;
		}
	}
	void add(T f) {
		if (!full()) {
			data[last++] = f;
		}
	}
	T extract() {
		T tmp;
		if (!empty()) {
			tmp = data[0];
			for (int i = 1; i < this->last; i++)
				data[i - 1] = data[i];
			last--;
			return tmp;
		}
		else {
			return tmp;
		}

	}

	FQueue(const FQueue &f) {
		data = new T[f.size];
		for (int i = 0; i < f.size; i++)
			data[i] = f.data[i];
		this->last = f.last;
		this->size = f.size;
	}

	~FQueue() {
		delete[] data;
	}

	FQueue& operator =(FQueue &f) {
		if (this == &f)
			return *this;
		T *tmp = new T[f.size];
		if (!tmp)
			return *this;
		for (int i = 0; i < f.size; i++) {
			tmp[i] = f.data[i];
		}
		if (data)
			delete[] data;
		data = tmp;
	}

	void fishSort() {
		T tmp;
		int j;
		for (int i = 0; i < size; i++) {
			tmp = data[i];
			for (j = i - 1; j >= 0 && data[j].getPrice() > tmp.getPrice(); j--)
				data[j + 1] = data[j];
			data[j + 1] = tmp;
		}
	}

	void sort() {
		T tmp;
		int j;
		for (int i = 0; i < size; i++) {
			tmp = data[i];
			for (j = i - 1; j >= 0 && data[j] > tmp; j--)
				data[j + 1] = data[j];
			data[j + 1] = tmp;
		}
	}

	int getLast() {
		return this->last;
	}

	bool wtf()
	{
		FILE* fin = fopen("queue.txt", "wb");
		if (!fin)
		{
			wcout << L"Ошибка открытия файла queue.txt для записи!" << endl;
			return 1;
		}
		fwrite(this->data, sizeof(this->data[0]), this->size, fin);
		fclose(fin);
		wcout << L"Очередь успешно записана в файл queue.txt" << endl;
		return 0;
	}

	bool rff()
	{
		FILE* fout = fopen("queue.txt", "rb");
		if (!fout)
		{
			wcout << L"Ошибка открытия файла queue.txt для чтения!" << endl;
			return 1;
		}
		fread(this->data, sizeof(this->data[0]), this->size, fout);
		fclose(fout);
		last = size;
		wcout << L"Очередь успешно считана из файла queue.txt" << endl;
		return 0;
	}

};

void main() {
	_setmode(_fileno(stdout), _O_U16TEXT);
	_setmode(_fileno(stdin), _O_U16TEXT);
	_setmode(_fileno(stderr), _O_U16TEXT);
	srand(time(NULL));
	FQueue<Fish> r(10);
	r.add(Fish(L"noname1", 5.55, 17));
	r.add(Fish(L"noname2", 1.77, 20));
	r.add(Fish(L"noname3", 0.82, 90));
	r.add(Fish(L"noname4", 7.13, 70));
	r.add(Fish(L"noname5", 9.97, 11));
	r.add(Fish(L"noname6", 11.2, 55));
	r.add(Fish(L"noname7", 7.52, 85)); 
	r.add(Fish(L"noname8", 4.75, 65));
	r.add(Fish(L"noname9", 3.78, 75));
	r.add(Fish(L"noname0", 8.69, 40));
	r.fishSort();
	FQueue<int> i(10);
	i.add(12);
	i.add(11);
	i.add(654);
	i.add(85);
	i.add(78);
	i.add(8);
	i.add(95);
	i.add(5);
	i.add(0);
	i.add(10);
	i.sort();
	FQueue<double> d(10);
	d.add(12.1);
	d.add(11.99);
	d.add(654.11);
	d.add(85.52);
	d.add(78.04);
	d.add(8.11);
	d.add(95.78);
	d.add(5.99);
	d.add(0.36);
	d.add(10.55);
	d.sort();
	FQueue<char> c(10);
	c.add(65);
	c.add(66);
	c.add(67);
	c.add(68);
	c.add(69);
	c.add(70);
	c.add(71);
	c.add(72);
	c.add(73);
	c.add(74);
	c.sort();


	wcout << L"~~~~~~~~~~~~ Тип данных: Fish ~~~~~~~~~~~~" << endl;
	wcout << L"Массив r(10):" << endl;
	if(!r.wtf())
		while (r.getLast())
			wcout << r.extract();
	FQueue<Fish> r2(10);
	wcout << L"Массив r2(10):" << endl;
	if(!r2.rff())
		while (r2.getLast())
			wcout << r2.extract();

	wcout << L"~~~~~~~~~~~~ Тип данных: int ~~~~~~~~~~~~" << endl;
	wcout << L"Массив i(10):" << endl;
	if (!i.wtf())
		while (i.getLast())
			wcout << L"  " << i.extract() << endl;
	FQueue<int> i2(10);
	wcout << L"Массив i2(10):" << endl;
	if (!i2.rff())
		while (i2.getLast())
			wcout << L"  " << i2.extract() << endl;

	wcout << L"~~~~~~~~~~~~ Тип данных: double ~~~~~~~~~~~~" << endl;
	wcout << L"Массив d(10):" << endl;
	if (!d.wtf())
		while (d.getLast())
			wcout << L"  " << d.extract() << endl;
	FQueue<double> d2(10);
	wcout << L"Массив d2(10):" << endl;
	if (!d2.rff())
		while (d2.getLast())
			wcout << L"  " << d2.extract() << endl;

	wcout << L"~~~~~~~~~~~~ Тип данных: char ~~~~~~~~~~~~" << endl;
	wcout << L"Массив c(10):" << endl;
	if (!c.wtf())
		while (c.getLast())
			wcout << L"  " << c.extract() << endl;
	FQueue<char> c2(10);
	wcout << L"Массив c2(10):" << endl;
	if (!c2.rff())
		while (c2.getLast())
			wcout << L"  " << c2.extract() << endl;
}