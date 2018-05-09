#include <Windows.h>
#include <string>
#include <time.h>

using namespace std;

#define UM_FINISH (WM_USER + 1)
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
	MyData* pData;
	int nLimit;
	static TCHAR text1[100], text2[100];
	static int nTextY = 50;
	static int i = 0;
	switch (uMsg)
	{
	case WM_CLOSE:
		DestroyWindow(hWnd);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_CREATE:
		nLimit = rand() % 10000 + 1;
		d1.hParent = hWnd;
		d1.nLimit = nLimit;
		hTA = CreateThread(NULL, 0, ThreadA, &d1, 0, NULL);
		if (!hTA)
		{
			MessageBox(hWnd, TEXT("Creating thread1 failure"), TEXT("ERROR"), MB_OK);
			break;
		}
		nLimit = rand() % 10000 + 1;
		d2.hParent = hWnd;
		d2.nLimit = nLimit;
		hTB = CreateThread(NULL, 0, ThreadB, &d2, 0, NULL);
		if (!hTB)
		{
			MessageBox(hWnd, TEXT("Creating thread2 failure"), TEXT("ERROR"), MB_OK);
			break;
		}
		break;
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{

		}
		break;
	case UM_FINISH:
		pData = (MyData*)wParam;
		if (i == 0)
			wsprintf(text1, TEXT("From %s sum is %d for limit %d"), pData->name, pData->nSum, pData->nLimit);
		else
			wsprintf(text2, TEXT("From %s sum is %d for limit %d"), pData->name, pData->nSum, pData->nLimit);
		i++;
		nTextY += 50;
		InvalidateRect(hWnd, NULL, FALSE);
		return TRUE;
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
	MyData* pmd = (MyData*)lpv;
	for (int i = 0; i < pmd->nLimit; i++)
	{
		pmd->nSum += i;
	}
	lstrcpy(pmd->name, TEXT("Thread A"));
	SendMessage(pmd->hParent, UM_FINISH, (WPARAM)pmd, 0);
	return FALSE;
}

DWORD WINAPI ThreadB(LPVOID lpv)
{
	MyData* pmd = (MyData*)lpv;
	for (int i = 0; i < pmd->nLimit; i++)
	{
		pmd->nSum += i;
	}
	lstrcpy(pmd->name, TEXT("Thread B"));
	SendMessage(pmd->hParent, UM_FINISH, (WPARAM)pmd, 0);
	return FALSE;
}