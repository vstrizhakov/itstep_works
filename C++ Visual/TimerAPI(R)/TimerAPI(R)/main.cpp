#include <Windows.h>
#include <string>
#include <time.h>

using namespace std;

#define TIMER_SEC 1
int TIMER_SEC1;
SYSTEMTIME st;
TCHAR text[100];
TCHAR text1[100];

void CALLBACK TimerProc(HWND hWnd, UINT uMsg, UINT_PTR idTimer, DWORD dwTimer)
{
	
	if (idTimer == TIMER_SEC1)
	{
		MessageBeep(MB_ICONASTERISK);
		GetLocalTime(&st);
		wsprintf(text1, TEXT("H: %d M: %d S:%d"), st.wHour, st.wDay, st.wSecond);
		InvalidateRect(hWnd, NULL, TRUE);
	}
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	HDC hDC;
	PAINTSTRUCT psPaint;
	RECT rect;
	switch (uMsg)
	{
	case WM_CLOSE:
		KillTimer(NULL, TIMER_SEC1);
		DestroyWindow(hWnd);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_CREATE:
		TIMER_SEC1 = SetTimer(NULL, NULL, 1000, (TIMERPROC)TimerProc);
		break;
	case WM_KEYDOWN:
		if (wParam == VK_RETURN)
		{
			SetTimer(hWnd, TIMER_SEC, 1000, NULL);
		}
		else if (wParam == VK_ESCAPE)
		{
			KillTimer(hWnd, TIMER_SEC);
		}
		break;
	case WM_TIMER:
		GetLocalTime(&st);
		wsprintf(text, TEXT("H: %d M: %d S: %d"), st.wHour, st.wMinute, st.wSecond);
		InvalidateRect(hWnd, NULL, TRUE);
		break;
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{

		}
		break;
	case WM_PAINT:
		hDC = BeginPaint(hWnd, &psPaint);
		GetClientRect(hWnd, &rect);
		DrawText(hDC, text1, -1, &rect, DT_SINGLELINE | DT_CENTER | DT_VCENTER);
		SetWindowText(hWnd, text);
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