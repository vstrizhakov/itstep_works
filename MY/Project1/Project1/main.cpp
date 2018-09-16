#include <iostream>
#include <Windows.h>
#include <string>
#include "header.h"

using namespace std;

int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hInstPrev, LPSTR lpCmdLine, int nCmdShow)
{
	HWND hWnd; // ���������� ����
	MSG msg;
	WNDCLASSEX wc; // ����� ����
	TCHAR wndName[] = "L2 Clicker Bot"; // �������� ����
	/* ������������� ������ ���� */
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
	/* ����������� ������ ���� */
	if (!RegisterClassEx(&wc))
	{
		MessageBox(NULL, TEXT("������ ����������� ����"), TEXT("������"), MB_OK);
		return 0;
	}
	/* �������� ���� */
	hWnd = CreateWindow(wndName, wndName, WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, NULL, NULL, hInst, NULL);
	if (!hWnd)
	{
		MessageBox(NULL, TEXT("������ ����������� ����"), TEXT("������"), MB_OK);
		return 0;
	}
	ShowWindow(hWnd, nCmdShow);
	/* ���� ��������� ��������� */
	/* MSG Struct */
	/*
	* HWND hWnd - ���������� ����
	* UINT message - ����� ���������
	* WPARAM wParam - ������ ���������
	* LPARAM lParam - ������ ���������
	* DWORD time - �����
	* POINT pt - ���������� ���� � ������ ���������� ���������� ������� � ������������ ��������� ����
	*/
	while (GetMessage(&msg, NULL, 0, 0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	return 0;
}