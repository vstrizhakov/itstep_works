#pragma once

using namespace std;

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	HDC hDc;
	PAINTSTRUCT psPaint;
	RECT rect;
	int nUserReply;
	HPEN hPen = NULL;
	HPEN hPenOld;
	HBRUSH hBrush;
	HBRUSH hBrushOld;
	
	switch (uMsg)
	{
	case WM_CLOSE:
	{
		DestroyWindow(hWnd);
		break;
	}
	case WM_DESTROY:
	{
		DeleteObject(hPen);
		PostQuitMessage(0);
		break;
	}
	case WM_CREATE:
	{
		SetClassLong(hWnd, GCL_HBRBACKGROUND, (LONG)CreateSolidBrush(RGB(199, 145, 255)));
		break;
	}
	case WM_PAINT:
	{
		hDc = BeginPaint(hWnd, &psPaint);

		EndPaint(hWnd, &psPaint);
		break;
	}
	default:
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
	}
	return 0;
}