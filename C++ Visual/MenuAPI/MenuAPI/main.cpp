#include <Windows.h>
#include <string>
#include "resource1.h"

using namespace std;

BOOL CALLBACK AboutDlgProc(HWND hDlg, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	switch (uMsg)
	{
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDOK:
			EndDialog(hDlg, 0);
			return TRUE;
		}
		return TRUE;
	}
	return FALSE;
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	HDC hDC;
	PAINTSTRUCT psPaint;
	static HINSTANCE hInst;
	switch (uMsg)
	{
	case WM_CLOSE:
		DestroyWindow(hWnd);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_CREATE:
		// ��������� ����������� ������ ����������
		hInst = GetModuleHandle(NULL);
		break;
	case WM_PAINT:
		BeginPaint(hWnd, &psPaint);

		EndPaint(hWnd, &psPaint);
		break;
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDM_OPEN:
			MessageBox(hWnd, TEXT("OPENED"), TEXT("OPENED"), MB_OK);
			break;
		case IDM_SAVE:
			MessageBox(hWnd, TEXT("OPENED"), TEXT("OPEN"), MB_OK);
			break;
		case IDM_EXIT:
			SendMessage(hWnd, WM_DESTROY, 0, 0);
			break;
		case IDM_COLOR:
			MessageBox(hWnd, TEXT("OPENED"), TEXT("OPEN"), MB_OK);
			break;
		case ID_ABOUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUT), hWnd, AboutDlgProc);
			break;
		default:
			break;
		}
		InvalidateRect(hWnd, NULL, true);
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