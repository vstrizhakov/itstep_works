#include <Windows.h>
#include <string>

using namespace std;

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	static HDC hDCS;
	HDC hDC;
	PAINTSTRUCT psPaint;
	static int x, y;
	TCHAR text[100];
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
		hDCS = GetDC(hWnd);
		break;
	case WM_LBUTTONDOWN: //RBUTTONDOWN
		x = LOWORD(lParam);
		y = HIWORD(lParam);
		InvalidateRect(hWnd, NULL, true);
		break;
	case WM_PAINT:
		hDC = BeginPaint(hWnd, &psPaint);
		GetClientRect(hWnd, &rect);
		wsprintf(text, TEXT("x = %d y = %d"), x, y);
		TextOut(hDC, 20, 20, text, lstrlen(text));
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