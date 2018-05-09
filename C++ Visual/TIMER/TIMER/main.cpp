#include <Windows.h>
#include <string>

using namespace std;

SYSTEMTIME st;
long time1, time2;

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	HDC hDC;
	PAINTSTRUCT psPaint;
	static DWORD ta, delta;
	static TCHAR text[100];
	switch (uMsg)
	{
	case WM_CLOSE:
		DestroyWindow(hWnd);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_CREATE:
		//GetSystemTimeAdjustment(&ta, &delta, false);
		GetLocalTime(&st);
		time1 = GetTickCount();
		for (int i = 0; i < 200000000; i++)
		{
			time2 = 0;
		}
		break;
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{

		}
		break;
	case WM_PAINT:
		BeginPaint(hWnd, &psPaint);
		/*wsprintf(text, TEXT("%d"), delta);
		SetWindowText(hWnd, text);*/
		/*wsprintf(text, TEXT("%d:%d:%d:%d:%d:%d:%d"), st.wYear, st.wMonth, st.wDay, st.wHour, st.wMinute, st.wSecond, st.wMilliseconds);
		SetWindowText(hWnd, text);*/
		time2 = GetTickCount();
		wsprintf(text, TEXT("%d"), time2 - time1);
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
	wc.lpszMenuName = NULL;
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