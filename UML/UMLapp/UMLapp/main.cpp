#include <iostream>
#include <Windows.h>
#include <iomanip>
#include <ctime>
#include <algorithm>
#include <vector>
#include <functional>
#include <string>
#include "header.h"

using namespace std;

void ShowCategories(Category& c)
{
	c.Show();
}

void ShowProducts(Product& p)
{
	if (p.GetCatId() == 5)
		p.Show();
}

int Category::count_cat_id = 0;
int Product::count_product_id = 0;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));

	string cat_names[10] = { "Ноутбуки", "Процессоры", "Наушники", "Мониторы", "Компьютерные мыши", "Материнские платы", "Жёсткие диски", "Видеокарты", "Переносные зарядки", "Клавиатуры" };
	vector<Category> categories;
	for (int i = 0; i < 10; i++)
		categories.push_back(*(new Category(cat_names[i])));
	for_each(categories.begin(), categories.end(), ShowCategories);
	vector<Product> products;
	for (int i = 0; i < 100; i++)
		products.push_back(*(new Product("Товар", rand() % 5000 + 750, rand() % 10)));
	for_each(products.begin(), products.end(), ShowProducts);

}