#include <Windows.h>
#include <string>

using namespace std;

int TIMER;
RECT rMove;

void CALLBACK TimerProc(HWND hWnd, UINT uMsg, UINT_PTR idTimer, DWORD dwTimer)
{
	if (idTimer == TIMER)
	{
		MessageBeep(MB_ICONASTERISK);
		rMove.left++;
		rMove.right++;
		rMove.top++;
		rMove.bottom++;
		InvalidateRect(hWnd, NULL, TRUE);
	}
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	HDC hDC;
	PAINTSTRUCT psPaint;
	HBRUSH hBrush;
	HBRUSH hBrushOld;
	RECT rect;
	switch (uMsg)
	{
	case WM_CLOSE:
		DestroyWindow(hWnd);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_CREATE:
		rMove.left = 0;
		rMove.top = 0;
		rMove.bottom = 100;
		rMove.right = 100;
		TIMER = SetTimer(NULL, NULL, 500, (TIMERPROC)TimerProc);
		break;
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{

		}
		break;
	case WM_PAINT:
		hDC = BeginPaint(hWnd, &psPaint);
		hBrush = (HBRUSH)CreateSolidBrush(RGB(147, 255, 0));
		hBrushOld = (HBRUSH)SelectObject(hDC, hBrush);
		Rectangle(hDC, rMove.left, rMove.top, rMove.right, rMove.bottom);		
		FillRect(hDC, &rMove, hBrush);
		SelectObject(hDC, hBrushOld);
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