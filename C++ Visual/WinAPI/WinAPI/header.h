#pragma once

using namespace std;

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	HDC hDC;
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
		nUserReply = MessageBox(hWnd, TEXT("Вы уверены, что хотите закрыть программу?"), TEXT("Закрыть окно"), MB_YESNO | MB_ICONQUESTION);
		if (nUserReply == IDYES) DestroyWindow(hWnd);
		break;
	case WM_DESTROY:
		DeleteObject(hPen);
		PostQuitMessage(0);
		break;
	case WM_CREATE:
		SetClassLong(hWnd, GCL_HBRBACKGROUND, (LONG)CreateSolidBrush(RGB(18, 128, 232)));
		break;
	case WM_PAINT:
	{
		hDC = BeginPaint(hWnd, &psPaint);

		/* Вывод текста
		GetClientRect(hWnd, &rect);
		SetBkMode(hDC, TRANSPARENT);
		DrawText(hDC, TEXT("Hello, wordl!"), -1, &rect, DT_SINGLELINE | DT_CENTER | DT_VCENTER);
		*/

		//Рисование линии с заменой пера
		/*hPenOld = (HPEN)SelectObject(hDC, GetStockObject(WHITE_PEN));
		MoveToEx(hDC, 55, 151, NULL);
		LineTo(hDC, 100, 300);
		SelectObject(hDC, hPenOld);*/
		//Использоваение DC_PEN
		/*hPenOld = (HPEN)SelectObject(hDC, GetStockObject(DC_PEN));
		for (int i = 0; i < 256; i++)
		{
			SetDCPenColor(hDC, RGB(255-i, 125,i));
			MoveToEx(hDC, 10, i+10, NULL);
			LineTo(hDC, 100, i+ 10);
		}
		SelectObject(hDC, hPenOld);	*/

		//Использование нестандартных перьев
		/* Виды перьев
		PS_DASH
		PS_DOT
		PS_DASHDOT
		PS_DASHDOTDOT
		*/
		/*hPen = CreatePen(PS_DOT, 101, RGB(0, 255, 0));
		hPenOld = (HPEN)SelectObject(hDC, hPen);
		MoveToEx(hDC, 100, 50, NULL);
		LineTo(hDC, 100, 300);
		SelectObject(hDC, hPenOld);*/

		// Рисование квадрата
		/*hPen = CreatePen(PS_DOT, 5, RGB(0, 255, 0));
		hPenOld = (HPEN)SelectObject(hDC, hPen);
		POINT pt[5] = { 500, 100, 600, 100, 600, 200, 500, 200, 500, 100 };
		MoveToEx(hDC, pt[0].x, pt[0].y, NULL);
		for (int i = 0; i < 5; i++)
		{
			LineTo(hDC, pt[i].x, pt[i].y);
		}
		SelectObject(hDC, hPenOld);*/

		// Рисование треугольника пером
		/*hPen = CreatePen(PS_SOLID, 5, RGB(71, 155, 48));
		hPenOld = (HPEN)SelectObject(hDC, hPen);
		Rectangle(hDC, 50, 50, 550, 700);
		SelectObject(hDC, hPenOld);*/

		// Рисование прямоугольника кистью
		/*hPen = CreatePen(PS_SOLID, 5, RGB(71, 155, 48));
		hPenOld = (HPEN)SelectObject(hDC, hPen);
		hBrushOld = (HBRUSH)SelectObject(hDC, GetStockObject(DC_BRUSH));
		SetDCBrushColor(hDC, RGB(255, 0, 0));
		Rectangle(hDC, 50, 50, 550, 700);
		SelectObject(hDC, hPenOld);
		SelectObject(hDC, hBrushOld);*/

		// 
		/*hPen = CreatePen(PS_SOLID, 5, RGB(71, 155, 48));
		hPenOld = (HPEN)SelectObject(hDC, hPen);
		hBrush = (HBRUSH)CreateSolidBrush(RGB(147, 255, 0));
		hBrushOld = (HBRUSH)SelectObject(hDC, hBrush);
		Rectangle(hDC, 50, 50, 550, 700);
		SelectObject(hDC, hPenOld);
		SelectObject(hDC, hBrushOld);*/

		// Виды кисти
		/*
		HS_HORIZONTAl
		HS_VERTICAL
		HS_BDIAGONAL
		HS_FDIAGONAL
		HS_DIAGCROSS
		*/
		/*hPen = CreatePen(PS_SOLID, 5, RGB(71, 155, 48));
		hPenOld = (HPEN)SelectObject(hDC, hPen);
		hBrush = (HBRUSH)CreateHatchBrush(HS_CROSS, RGB(147, 255, 0));
		hBrushOld = (HBRUSH)SelectObject(hDC, hBrush);
		Rectangle(hDC, 50, 50, 550, 700);
		SelectObject(hDC, hPenOld);
		SelectObject(hDC, hBrushOld);*/

		HBITMAP hBmp = (HBITMAP)LoadImage(NULL, TEXT("1.bmp"), IMAGE_BITMAP, 0, 0, LR_LOADFROMFILE);
		hBrush = CreatePatternBrush(hBmp);
		hBrushOld = (HBRUSH)SelectObject(hDC, hBrush);
		Rectangle(hDC, 0, 0, 333, 333);
		SelectObject(hDC, hBrushOld);

		EndPaint(hWnd, &psPaint);
		break;
	}
	default:
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
	}

	return 0;
}