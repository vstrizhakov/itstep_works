#include<iostream>
using namespace std;

void Show(int arr[3][2], int cols, int rows) {
	for (int i = 0; i < rows; i++) {
		for (int j = 0; j < cols; j++) {
			cout << arr[i][j];
		}
		cout << "\n";
	}
}

int main() {
	int arr[2][2] = { 1, 2, 3, 4 };
	Show(arr, 2, 2);
	return 0;
}