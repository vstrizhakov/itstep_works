#include <iostream>
#include <Windows.h>
#include <string>
#include "header.h"

using namespace std;

int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hInstPrev, LPSTR lpCmdLine, int nCmdShow)
{
	HWND hWnd; // Дескриптор окна
	MSG msg;
	WNDCLASSEX wc; // Класс окна
	TCHAR wndName[] = "L2 Clicker Bot"; // Название окна
	/* Инициализация класса окна */
	wc.cbSize = sizeof(wc);
	wc.style = CS_HREDRAW | CS_VREDRAW | CS_DROPSHADOW;
	wc.lpfnWndProc = WndProc;
	wc.cbWndExtra = 0;
	wc.cbClsExtra = 0;
	wc.hInstance = hInst;
	wc.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);
	wc.hbrBackground = (HBRUSH)GetStockObject(GRAY_BRUSH);
	wc.lpszMenuName = NULL;
	wc.lpszClassName = wndName;
	wc.hIconSm = LoadIcon(NULL, IDI_APPLICATION);
	/* Регистрация класса окна */
	if (!RegisterClassEx(&wc))
	{
		MessageBox(NULL, TEXT("Ошибка регистрации окна"), TEXT("Ошибка"), MB_OK);
		return 0;
	}
	/* Создание окна */
	hWnd = CreateWindow(wndName, wndName, WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, NULL, NULL, hInst, NULL);
	if (!hWnd)
	{
		MessageBox(NULL, TEXT("Ошибка регистрации окна"), TEXT("Ошибка"), MB_OK);
		return 0;
	}
	ShowWindow(hWnd, nCmdShow);
	/* Цикл обработки сообщений */
	/* MSG Struct */
	/*
	* HWND hWnd - дескриптор окна
	* UINT message - номер сообщения
	* WPARAM wParam - данные сообщения
	* LPARAM lParam - данные сообщения
	* DWORD time - время
	* POINT pt - координаты мыши в момент исполнения последнего события в координатной плоскости окна
	*/
	while (GetMessage(&msg, NULL, 0, 0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	return 0;
}