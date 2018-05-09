#include <Windows.h>
#include <string>

using namespace std;

#define SCREENX GetSystemMetrics(SM_CXSCREEN)
#define SCREENY GetSystemMetrics(SM_CYSCREEN)
#define START_BUTTON (WM_USER + 1)
#define END_BUTTON (WM_USER + 2)
#define RESET_BUTTON (WM_USER + 3)
#define PI 3.14

int timer = NULL;
double hourEndX, hourEndY;
double minuteEndX, minuteEndY;
double secondEndX, secondEndY;
int s = 0;
int m = 0;
int h = 0;
RECT clock;

void CALLBACK TimerProc(HWND hWnd, UINT uMsg, UINT_PTR idTimer, DWORD dwTimer)
{
	if (idTimer == timer)
	{
		s++;
		if (s >= 60)
		{
			s = 0;
			m++;
		}
		if (m >= 60)
		{
			m = 0;
			h++;
		}

		// Часовая стрелка
		hourEndX = 250 + (sin(2 * PI * (h * 60 + m) / 12 / 60)) * 50;
		hourEndY = 150 + (-cos(2 * PI * (h * 60 + m) / 12 / 60)) * 50;
		// Минутная стрекла
		minuteEndX = 250 + (sin(2 * PI * m / 60)) * 75;
		minuteEndY = 150 + (-cos(2 * PI * m / 60)) * 75;
		// Секундная стрелка
		secondEndX = 250 + (sin(2 * PI * s / 60)) * 75;
		secondEndY = 150 + (-cos(2 * PI * s / 60)) * 75;

		InvalidateRect(hWnd, &clock, TRUE);
	}
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	HDC hDC;
	PAINTSTRUCT psPaint;
	RECT rect;
	HBRUSH hBrush;
	HBRUSH hBrushOld;
	HPEN hPen;
	HPEN hPenOld;
	static bool flag;
	static HWND startButton, endButton, resetButton;
	static HBITMAP hBmp = (HBITMAP)LoadImage(NULL, TEXT("clock.bmp"), IMAGE_BITMAP, 0, 0, LR_LOADFROMFILE);
	switch (uMsg)
	{
	case WM_CLOSE:
		DestroyWindow(hWnd);
		return TRUE;
	case WM_DESTROY:
		PostQuitMessage(0);
		return TRUE;
	case WM_CREATE:
		startButton = CreateWindow(TEXT("BUTTON"), TEXT("Start"), WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON, 55, 300, 100, 30, hWnd, (HMENU)START_BUTTON, (HINSTANCE)GetWindowLong(hWnd, GWL_HINSTANCE), NULL);
		endButton = CreateWindow(TEXT("BUTTON"), TEXT("End"), WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON, 195, 300, 100, 30, hWnd, (HMENU)END_BUTTON, (HINSTANCE)GetWindowLong(hWnd, GWL_HINSTANCE), NULL);
		resetButton = CreateWindow(TEXT("BUTTON"), TEXT("Reset"), WS_VISIBLE | WS_CHILD | BS_DEFPUSHBUTTON, 335, 300, 100, 30, hWnd, (HMENU)RESET_BUTTON, (HINSTANCE)GetWindowLong(hWnd, GWL_HINSTANCE), NULL);
		clock.top = 50;
		clock.bottom = 250;
		clock.right = 350;
		clock.left = 150;
		hourEndX = minuteEndX = secondEndX = 250;
		hourEndY = 100;		
		minuteEndY = secondEndY = 75;		
		flag = false;
		return TRUE;
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case START_BUTTON:
			if (!flag)
			{
				timer = SetTimer(NULL, NULL, 1000, (TIMERPROC)TimerProc);
				EnableWindow(resetButton, FALSE);
				flag = true;
			}
			return TRUE;
		case END_BUTTON:
			if (flag)
			{
				KillTimer(NULL, timer);
				EnableWindow(resetButton, TRUE);
				flag = false;
			}
			return TRUE;
		case RESET_BUTTON:
			MessageBeep(MB_ICONASTERISK);
			s = m = h = 0;
			hourEndX = minuteEndX = secondEndX = 250;
			hourEndY = 100;
			minuteEndY = secondEndY = 75;
			InvalidateRect(hWnd, &clock, TRUE);

			return TRUE;
		}
		return TRUE;
	case WM_PAINT:

		GetClientRect(hWnd, &rect);
		hDC = BeginPaint(hWnd, &psPaint);
		// Рисуем часы
		hBrush = CreatePatternBrush(hBmp);		
		UnrealizeObject(hBrush); // Сбрасываем начальные координаты для кисти
		SetBrushOrgEx(hDC, 150, 50, NULL); // Устанавливаем свои начальные координаты для кисти
		hBrushOld = (HBRUSH)SelectObject(hDC, hBrush);
		FillRect(hDC, &clock, hBrush);
		SelectObject(hDC, hBrushOld);
		// Рисуем стрелки
		hPen = CreatePen(PS_SOLID, 4, RGB(0, 0, 0));
		hPenOld = (HPEN)SelectObject(hDC, hPen);
		// Часовая стрелка
		MoveToEx(hDC, 250, 150, NULL);
		LineTo(hDC, hourEndX, hourEndY);
		// Минутная стрелка
		MoveToEx(hDC, 250, 150, NULL);
		LineTo(hDC, minuteEndX, minuteEndY);
		// Секундная стрелка с менее толстым пером
		SelectObject(hDC, hPenOld);
		hPen = CreatePen(PS_SOLID, 2, RGB(0, 0, 0));
		hPenOld = (HPEN)SelectObject(hDC, hPen);

		MoveToEx(hDC, 250, 150, NULL);
		LineTo(hDC, secondEndX, secondEndY);

		SelectObject(hDC, hPenOld);

		EndPaint(hWnd, &psPaint);
		return TRUE;
	default:
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
	}

	return FALSE;
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
	hWnd = CreateWindow(szClassName, TEXT("Timer"), WS_CLIPCHILDREN | WS_SYSMENU | WS_MINIMIZEBOX | WS_CAPTION, (SCREENX / 2) - 250, (SCREENY / 2) - 200, 500, 400, NULL, NULL, hInst, NULL);
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