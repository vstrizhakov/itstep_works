#include <Windows.h>
#include <string>
#include "resource.h"
using namespace std;

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	HDC hDC;
	PAINTSTRUCT psPaint;
	STARTUPINFO si;
	static PROCESS_INFORMATION pi;
	BOOL result;

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
		case ID_START:
			ZeroMemory(&si, sizeof(si));
			si.cb = sizeof(si);
			result = CreateProcess(TEXT("C:\\Windows\\notepad.exe"), NULL, NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi);
			if (!result)
			{
				break;
			}
			break;
		}
		break;
	case WM_PAINT:
		BeginPaint(hWnd, &psPaint);

		EndPaint(hWnd, &psPaint);
		break;
	default:
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
	}

	return 0;
}

int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hIntPrev, LPSTR lpCmdLine, int nCmdShow)
{
	HWND hWnd; // ���������� ����
	MSG msg;
	WNDCLASSEX wc; // �����(���) ����
	TCHAR szClassName[] = TEXT("MainWindow"); // ��� ����
											  // ������������� ������ ����
	wc.cbSize = sizeof(wc);
	wc.style = CS_HREDRAW | CS_VREDRAW;
	wc.lpfnWndProc = WndProc;
	wc.cbWndExtra = 0;
	wc.cbClsExtra = 0;
	wc.hInstance = hInst;
	wc.hIcon = LoadIcon(NULL, IDI_APPLICATION); // ���� NULL, ����� ����������� ���
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);
	wc.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
	wc.lpszMenuName = MAKEINTRESOURCE(IDR_MENU1);
	wc.lpszClassName = szClassName;
	wc.hIconSm = LoadIcon(NULL, IDI_APPLICATION);
	// ����������� ������ ����
	if (!RegisterClassEx(&wc))
	{
		MessageBox(NULL, TEXT("Register failure"), TEXT("ERROR"), MB_OK);
		return 0;
	}
	// �������� ����
	hWnd = CreateWindow(szClassName, TEXT("HEADER"), WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, NULL, NULL, hInst, NULL);
	if (!hWnd)
	{
		MessageBox(NULL, TEXT("Register failure"), TEXT("ERROR"), MB_OK);
		return 0;
	}

	ShowWindow(hWnd, nCmdShow);
	// ���� ��������� ���������
	/*
	struct MSG
	{
	HWND hwnd, - ���������� ����
	UINT message, - ����� ���������
	WPARAM wParam, - ������ ���������
	LPARAM lParam, - ������ ���������
	DWORD time, - �����
	POINT pt - ���������� ���� � ������ ���������� ���������� ������� � ������������ ��������� ����
	}
	*/
	while (GetMessage(&msg, NULL, 0, 0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	return msg.wParam;
}