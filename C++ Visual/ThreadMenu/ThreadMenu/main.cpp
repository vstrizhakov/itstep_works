#include <Windows.h>
#include <string>
#include "resource.h"

using namespace std;

int r, g, b, gray;
COLORREF pcol;
HANDLE hArray[3];
int w, h;

DWORD WINAPI ThreadA(LPVOID lpv)
{
	HWND hPic = (HWND)lpv;
	HDC hDCLocale = GetDC(hPic);
	for (int i = 0; i < w / 3; i++)
	{
		for (int j = 0; j < h; j++)
		{
			pcol = GetPixel(hDCLocale, i, j);
			r = GetRValue(pcol);
			g = GetGValue(pcol);
			b = GetBValue(pcol);
			gray = (int)(r * 0.3 + g * 0.59 + b * 0.11);
			pcol = RGB(gray, gray, gray);
			SetPixelV(hDCLocale, i, j, pcol);
		}
	}
	return 0;
}

DWORD WINAPI ThreadB(LPVOID lpv)
{
	HWND hPic = (HWND)lpv;
	HDC hDCLocale = GetDC(hPic);
	for (int i = w / 3; i < 2 * w / 3; i++)
	{
		for (int j = 0; j < h; j++)
		{
			pcol = GetPixel(hDCLocale, i, j);
			r = GetRValue(pcol);
			g = GetGValue(pcol);
			b = GetBValue(pcol);
			gray = (int)(r * 0.3 + g * 0.59 + b * 0.11);
			pcol = RGB(gray, gray, gray);
			SetPixelV(hDCLocale, i, j, pcol);
		}
	}
	return 0;
}

DWORD WINAPI ThreadC(LPVOID lpv)
{
	HWND hPic = (HWND)lpv;
	HDC hDCLocale = GetDC(hPic);
	for (int i = 2 * w / 3; i < w; i++)
	{
		for (int j = 0; j < h; j++)
		{
			pcol = GetPixel(hDCLocale, i, j);
			r = GetRValue(pcol);
			g = GetGValue(pcol);
			b = GetBValue(pcol);
			gray = (int)(r * 0.3 + g * 0.59 + b * 0.11);
			pcol = RGB(gray, gray, gray);
			SetPixelV(hDCLocale, i, j, pcol);
		}
	}
	return 0;
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	HDC hDC;
	PAINTSTRUCT psPaint;
	static HBITMAP hBmp;
	BITMAP bmp;
	HBITMAP hBmpOld;
	HDC hDCMemory;
	RECT rect;
	static HANDLE hTA, hTB, hTC;
	switch (uMsg)
	{
	case WM_CLOSE:
		DestroyWindow(hWnd);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_CREATE:
		break;
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case ID_OPEN:
			hBmp = (HBITMAP)LoadImage(GetModuleHandle(NULL), TEXT("1.bmp"), IMAGE_BITMAP, 0, 0, LR_LOADFROMFILE | LR_DEFAULTSIZE);
			InvalidateRect(hWnd, NULL, TRUE);
			break;
		case ID_ONETHREAD:
			hDC = GetDC(hWnd);
			for (int i = 0; i < w; i++)
			{
				for (int j = 0; j < h; j++)
				{
					pcol = GetPixel(hDC, i, j);
					r = GetRValue(pcol);
					g = GetGValue(pcol);
					b = GetBValue(pcol);
					gray = (int)(r * 0.3 + g * 0.59 + b * 0.11);
					pcol = RGB(gray, gray, gray);
					SetPixelV(hDC, i, j, pcol);
				}
			}
			break;
		case ID_MULTITHREAD:
			hDC = GetDC(hWnd);
			hTA = CreateThread(NULL, 0, ThreadA, hWnd, 0, NULL);
			hTB = CreateThread(NULL, 0, ThreadB, hWnd, 0, NULL);
			hTC = CreateThread(NULL, 0, ThreadC, hWnd, 0, NULL);
			/*SetThreadPriority(hTA, THREAD_PRIORITY_HIGHEST);
			SetThreadPriority(hTB, THREAD_PRIORITY_HIGHEST);
			SetThreadPriority(hTC, THREAD_PRIORITY_HIGHEST);*/
			break;
		}
		break;
	case WM_PAINT:
		hDC = BeginPaint(hWnd, &psPaint);
		hDCMemory = CreateCompatibleDC(hDC);
		hBmpOld = (HBITMAP)SelectObject(hDCMemory, hBmp);
		GetObject(hBmp, sizeof(BITMAP), &bmp); // Заноим в bmp инф. о hBmp
		w = bmp.bmWidth;
		h = bmp.bmHeight;
		GetClientRect(hWnd, &rect);
		//StretchBlt(hDC, 0, 0, rect.right, rect.bottom, hDCMemory, 0, 0, w, h, SRCCOPY);
		BitBlt(hDC, 0, 0, w, h, hDCMemory, 0, 0, SRCCOPY);
		SelectObject(hDCMemory, hBmpOld);
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
	wc.lpszMenuName = MAKEINTRESOURCE(IDR_MENU1);
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