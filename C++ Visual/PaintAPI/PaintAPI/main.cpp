#include <Windows.h>
#include <string>
#include <vector>

using namespace std;

class Point
{	
public:
	int x;
	int y;
	Point(int x = 0, int y = 0)
	{
		this->x = x;
		this->y = y;
	}
};

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	static HDC hDCS;
	HDC hDC;
	static int x, y;
	static BOOL flag = false;
	static vector<Point> line;
	static vector<vector<Point>> lines;
	vector<Point>::iterator it;
	TCHAR text[100];
	RECT rect;
	PAINTSTRUCT paintPs;
	HPEN hPen;
	HPEN hPenOld;

	switch (uMsg)
	{
	case WM_CLOSE:		
		DestroyWindow(hWnd);
		break;
	case WM_DESTROY:
		ReleaseDC(hWnd, hDCS);
		DeleteObject(hPen);
		PostQuitMessage(0);
		break;
	case WM_CREATE:
		hDCS = GetDC(hWnd);
		break;
	case WM_LBUTTONDOWN:
		flag = true;
		x = LOWORD(lParam);
		y = HIWORD(lParam);
		hPen = CreatePen(PS_DOT, 5, RGB(rand() % 255, rand() % 255, rand() % 255));
		hPenOld = (HPEN)SelectObject(hDCS, hPen);
		MoveToEx(hDCS, x, y, NULL);
		line.push_back(Point(x, y));
		break;
	case WM_LBUTTONUP:
		if (flag)
		{
			flag = false;
			lines.push_back(line);
			line.clear();
		}
		break;
	case WM_MOUSEMOVE:
		if (flag)
		{
			x = LOWORD(lParam);
			y = HIWORD(lParam);
			LineTo(hDCS, x, y);
			line.push_back(Point(x, y));
		}
		
		break;
	case WM_PAINT:
		hDC = BeginPaint(hWnd, &paintPs);
		for (int i = 0; i < lines.size(); i++)
		{
			hPen = CreatePen(PS_DOT, 5, RGB(rand() % 255, rand() % 255, rand() % 255));
			hPenOld = (HPEN)SelectObject(hDC, hPen);
			it = lines[i].begin();
			MoveToEx(hDC, it->x, it->y, NULL);
			for (it + 1; it < lines[i].end(); it++)
			{
				LineTo(hDC, it->x, it->y);
			}
		}
		EndPaint(hWnd, &paintPs);
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