#include <Windows.h>
#include <string>
#include <time.h>

using namespace std;

TCHAR text1[100] = L"123";
TCHAR text2[100] = L"456";
struct MyData
{
	HWND hParent;
	int nLimit;
	long nSum;
	TCHAR name[100];
} d1, d2;
DWORD WINAPI ThreadA(LPVOID);
DWORD WINAPI ThreadB(LPVOID);

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	HDC hDC;
	PAINTSTRUCT psPaint;
	static HANDLE hTA, hTB;
	int nLimit1, nLimit2;
	switch (uMsg)
	{
	case WM_CLOSE:
		DestroyWindow(hWnd);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_CREATE:
		nLimit1 = rand() % 10000 + 1;
		hTA = CreateThread(NULL, 0, ThreadA, &nLimit1, 0, NULL);
		if (!hTA)
		{
			MessageBox(hWnd, TEXT("Creating thread1 failure"), TEXT("ERROR"), MB_OK);
			break;
		}
		nLimit2 = rand() % 10000 + 1;
		hTB = CreateThread(NULL, 0, ThreadB, &nLimit2, 0, NULL);
		if (!hTB)
		{
			MessageBox(hWnd, TEXT("Creating thread2 failure"), TEXT("ERROR"), MB_OK);
			break;
		}
		WaitForSingleObject(hTA, INFINITE);
		WaitForSingleObject(hTB, INFINITE);
		break;
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{

		}
		break;
	case WM_PAINT:
		hDC = BeginPaint(hWnd, &psPaint);
		TextOut(hDC, 50, 50, text1, lstrlen(text1));
		TextOut(hDC, 50, 100, text2, lstrlen(text2));
		EndPaint(hWnd, &psPaint);
		break;
	default:
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
	}

	return 0;
}

int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hIntPrev, LPSTR lpCmdLine, int nCmdShow)
{
	HWND hWnd; // Дескриптор окна
	MSG msg;
	WNDCLASSEX wc; // Класс(тип) окна
	TCHAR szClassName[] = TEXT("MainWindow"); // Имя окна
											  // Инициализация класса окна
	srand(time(NULL));
	wc.cbSize = sizeof(wc);
	wc.style = CS_HREDRAW | CS_VREDRAW;
	wc.lpfnWndProc = WndProc;
	wc.cbWndExtra = 0;
	wc.cbClsExtra = 0;
	wc.hInstance = hInst;
	wc.hIcon = LoadIcon(NULL, IDI_APPLICATION); // Если NULL, тогда стандартный вид
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);
	wc.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
	wc.lpszMenuName = NULL;
	wc.lpszClassName = szClassName;
	wc.hIconSm = LoadIcon(NULL, IDI_APPLICATION);
	// Регистрация класса окна
	if (!RegisterClassEx(&wc))
	{
		MessageBox(NULL, TEXT("Register failure"), TEXT("ERROR"), MB_OK);
		return 0;
	}
	// Создание окна
	hWnd = CreateWindow(szClassName, TEXT("HEADER"), WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, NULL, NULL, hInst, NULL);
	if (!hWnd)
	{
		MessageBox(NULL, TEXT("Register failure"), TEXT("ERROR"), MB_OK);
		return 0;
	}

	ShowWindow(hWnd, nCmdShow);
	// Цикл обработки сообщений
	/*
	struct MSG
	{
	HWND hwnd, - дескриптор окна
	UINT message, - номер сообщение
	WPARAM wParam, - данные сообщения
	LPARAM lParam, - данные сообщения
	DWORD time, - время
	POINT pt - координаты мыши в момент исполнения последнего события в координатной плоскости окна
	}
	*/
	while (GetMessage(&msg, NULL, 0, 0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	return msg.wParam;
}

DWORD WINAPI ThreadA(LPVOID lpv)
{
	int* pmd = (int*)lpv;
	long nSum = 0;
	for (int i = 0; i < *pmd; i++)
	{
		nSum += i;
	}
	wsprintf(text1, TEXT("From Thread A sum is %d for limit %d"), nSum, *pmd);
	return FALSE;
}

DWORD WINAPI ThreadB(LPVOID lpv)
{
	int* pmd = (int*)lpv;
	long nSum = 0;
	for (int i = 0; i < *pmd; i++)
	{
		nSum += i;
	}
	wsprintf(text2, TEXT("From Thread B sum is %d for limit %d"), nSum, *pmd);
	return FALSE;
}
