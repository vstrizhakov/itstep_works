#include <iostream>
#include <windows.h>
#include <stdio.h>
#include <iomanip>

using namespace std;

void main() {

	setlocale(LC_ALL, "russian");
	
	//������� �1

	/*_LONGLONG seconds;
	cout << "������� ���������� ������: ";
	cin >> seconds;
	printf("%I64i ������ ��� %I64i ���(-��/-�), %I64i �����(-�/-�), %I64i ������(-�/-�)\n", seconds, seconds / 3600, seconds % 3600 / 60, seconds % 60);*/

	//������� �2

	/*double number;
	cout << "������� �����: ";
	cin >> number;
	cout << "��� " << int(number) << " ��� "  << int(number * 100) % 100 << " ���.\n";*/

	//������� �3

	/*double time, speed, distance, minute, seconds, total_seconds;

	cout << "���������� ����...\n������� ������(������): ";
	cin >> distance;
	cout << "\n������� �����(���.���): ";
	cin >> time;

	cout << "\n���������: " << distance << " �\n";

	seconds = (time - int(time)) * 100;
	minute = int(time)*60;
	total_seconds = minute + seconds;
	
	cout << "�����: " << int(total_seconds / 60) << " ��� " << int(total_seconds) % 60<< " ���\n";

	speed = distance / total_seconds;
	cout << "�� ������ �� ��������� " << fixed << setprecision(2) << speed / 1000 * 3600 << " ��/�\n";*/

	//������� �4

	/*float time, price, total;
	int total_seconds, seconds, minute;
	cout << "������� ���� ����� ������: ";
	cin >> price;
	cout << "������� ����������������� ������: ";
	cin >> time;

	seconds = (time - int(time)) * 100;
	minute = int(time);
	total_seconds = (minute * 60) + seconds;

	cout << "\n�����: " << total_seconds / 60 << " ����� " << total_seconds % 60 << " ������\n";

	if (seconds > 60) {
		minute += 2;
	}
	else if (seconds > 0) {
		minute++;
	}

	total = price * minute;

	cout << "���������� �����, �� ������� ��������� �����: " << minute << "\n�������� �����, �� ������� ��� ���������� ������: " << fixed << setprecision(2) << total << endl;*/

	//������� �5

	/*int days;
	cout << "������� ���������� ����: ";
	cin >> days;

	cout << days / 7 << " ������(-�/-�) " << days % 7 << " ����(-�/-��)" << endl;*/

}
