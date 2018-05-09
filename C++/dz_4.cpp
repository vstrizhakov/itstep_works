#include <iostream>
#include <windows.h>
#include <stdio.h>
#include <iomanip>

using namespace std;

void main() {

	setlocale(LC_ALL, "russian");
	
	//Задание №1

	/*_LONGLONG seconds;
	cout << "Введите количество секунд: ";
	cin >> seconds;
	printf("%I64i секунд это %I64i час(-ов/-а), %I64i минут(-ы/-а), %I64i секунд(-ы/-а)\n", seconds, seconds / 3600, seconds % 3600 / 60, seconds % 60);*/

	//Задание №2

	/*double number;
	cout << "Введите число: ";
	cin >> number;
	cout << "Это " << int(number) << " грн "  << int(number * 100) % 100 << " коп.\n";*/

	//Задание №3

	/*double time, speed, distance, minute, seconds, total_seconds;

	cout << "Вычисление бега...\nВведите длинну(метров): ";
	cin >> distance;
	cout << "\nВведите время(мин.сек): ";
	cin >> time;

	cout << "\nДистанция: " << distance << " м\n";

	seconds = (time - int(time)) * 100;
	minute = int(time)*60;
	total_seconds = minute + seconds;
	
	cout << "Время: " << int(total_seconds / 60) << " мин " << int(total_seconds) % 60<< " сек\n";

	speed = distance / total_seconds;
	cout << "Вы бежали со скоростью " << fixed << setprecision(2) << speed / 1000 * 3600 << " км/ч\n";*/

	//Задание №4

	/*float time, price, total;
	int total_seconds, seconds, minute;
	cout << "Укажите цену одной минуты: ";
	cin >> price;
	cout << "Укажите продолжительность звонка: ";
	cin >> time;

	seconds = (time - int(time)) * 100;
	minute = int(time);
	total_seconds = (minute * 60) + seconds;

	cout << "\nВремя: " << total_seconds / 60 << " минут " << total_seconds % 60 << " секунд\n";

	if (seconds > 60) {
		minute += 2;
	}
	else if (seconds > 0) {
		minute++;
	}

	total = price * minute;

	cout << "Количество минут, за которые взымается плата: " << minute << "\nДенежная сумма, на которую был произведен звонок: " << fixed << setprecision(2) << total << endl;*/

	//Задание №5

	/*int days;
	cout << "Введите количество дней: ";
	cin >> days;

	cout << days / 7 << " недель(-и/-я) " << days % 7 << " день(-я/-ей)" << endl;*/

}
