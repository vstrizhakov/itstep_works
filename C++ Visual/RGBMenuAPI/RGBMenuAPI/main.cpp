#include <Windows.h>
#include <string>
#include "resource.h"

using namespace std;

RECT rcWork;
int prev_rgb[3] = { 0, 0, 0 }, rgb[3];
enum userMsg { UM_CHANGE = WM_USER + 1 };

BOOL CALLBACK SetColorBySliderDlgProc(HWND hDlg, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	static HWND hRedSB, hGreenSB, hBlueSB;
	int nCtrlID, index;
	static HWND hCtrl, hEdRed, hEdGreen, hEdBlue;
	static HWND hStRed, hStGreen, hStBlue;
	static LOGFONT lf;
	HFONT hFont;
	TCHAR text[5];
	switch (uMsg)
	{
	case WM_INITDIALOG:
		hRedSB = GetDlgItem(hDlg, IDC_SBRED);
		hGreenSB = GetDlgItem(hDlg, IDC_SBGREEN);
		hBlueSB = GetDlgItem(hDlg, IDC_SBBLUE);

		hStRed = GetDlgItem(hDlg, IDC_STRED);
		hStGreen = GetDlgItem(hDlg, IDC_STGREEN);
		hStBlue = GetDlgItem(hDlg, IDC_STBLUE);

		hEdRed = GetDlgItem(hDlg, IDC_EDRED);
		hEdGreen = GetDlgItem(hDlg, IDC_EDGREEN);
		hEdBlue = GetDlgItem(hDlg, IDC_EDBLUE);

		wsprintf(text, TEXT("%d"), rgb[0]);
		SetWindowText(hEdRed, text);
		wsprintf(text, TEXT("%d"), rgb[1]);
		SetWindowText(hEdGreen, text);
		wsprintf(text, TEXT("%d"), rgb[2]);
		SetWindowText(hEdBlue, text);

		lf.lfHeight = 18;
		lstrcpy((LPWSTR)&lf.lfFaceName, TEXT("Impact"));
		hFont = CreateFontIndirect(&lf);
		SendMessage(hStRed, WM_SETFONT, (WPARAM)hFont, TRUE);
		SendMessage(hStGreen, WM_SETFONT, (WPARAM)hFont, TRUE);
		SendMessage(hStBlue, WM_SETFONT, (WPARAM)hFont, TRUE);

		// Позиция и диапазон бегунков
		SetScrollRange(hRedSB, SB_CTL, 0, 255, FALSE);
		SetScrollRange(hGreenSB, SB_CTL, 0, 255, FALSE);
		SetScrollRange(hBlueSB, SB_CTL, 0, 255, FALSE);
		SetScrollPos(hRedSB, SB_CTL, prev_rgb[0], TRUE);
		SetScrollPos(hGreenSB, SB_CTL, prev_rgb[1], TRUE);
		SetScrollPos(hBlueSB, SB_CTL, prev_rgb[2], TRUE);
		return TRUE;
	case WM_CTLCOLORSTATIC:
		if ((HWND)lParam == hStRed)
		{
			SetTextColor((HDC)wParam, RGB(rgb[0], 0, 0));
			SetBkMode((HDC)wParam, TRANSPARENT);
			return (DWORD)GetSysColorBrush(COLOR_3DFACE);
		}
		if ((HWND)lParam == hStGreen)
		{
			SetTextColor((HDC)wParam, RGB(0, rgb[1], 0));
			SetBkMode((HDC)wParam, TRANSPARENT);
			return (DWORD)GetSysColorBrush(COLOR_3DFACE);
		}
		if ((HWND)lParam == hStBlue)
		{
			SetTextColor((HDC)wParam, RGB(0, 0, rgb[2]));
			SetBkMode((HDC)wParam, TRANSPARENT);
			return (DWORD)GetSysColorBrush(COLOR_3DFACE);
		}
		
		return TRUE;
	case WM_VSCROLL:
		hCtrl = (HWND)lParam;
		nCtrlID = GetDlgCtrlID(hCtrl);
		index = nCtrlID - IDC_SBRED;
		switch (LOWORD(wParam))
		{
		case SB_LINEUP:
			rgb[index] = max(0, rgb[index] - 1);
			break;
		case SB_LINEDOWN:
			rgb[index] = min(255, rgb[index] + 1);
			break;
		case SB_PAGEUP:
			rgb[index] -= 15;
			break;
		case SB_PAGEDOWN:
			rgb[index] += 15;
			break;
		case SB_THUMBTRACK:
			rgb[index] = HIWORD(wParam);
			break;
		}
		SetScrollPos(hCtrl, SB_CTL, rgb[index], TRUE);
		SendMessage(GetParent(hDlg), UM_CHANGE, 0, 0);
		SendMessage(hDlg, WM_CTLCOLORSTATIC, nCtrlID, 0);
		wsprintf(text, TEXT("%d"), rgb[index]);
		if (index == 0)
		{			
			SetWindowText(hEdRed, text);
			InvalidateRect(hStRed, NULL, TRUE);
		}
		if (index == 1)
		{
			SetWindowText(hEdGreen, text);
			InvalidateRect(hStGreen, NULL, TRUE);
		}
		if (index == 2)
		{
			SetWindowText(hEdBlue, text);
			InvalidateRect(hStBlue, NULL, TRUE);
		}
		return TRUE;
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDOK:
			prev_rgb[0] = rgb[0];
			prev_rgb[1] = rgb[1];
			prev_rgb[2] = rgb[2];
			EndDialog(hDlg, FALSE);
			return TRUE;
		case IDCANCEL:
			rgb[0] = prev_rgb[0];
			rgb[1] = prev_rgb[1];
			rgb[2] = prev_rgb[2];
			SendMessage(GetParent(hDlg), UM_CHANGE, 0, 0);
			EndDialog(hDlg, FALSE);
			return TRUE;
		default:
			return TRUE;
		}
		break;
	}
	return FALSE;
}

BOOL CALLBACK SetColorByInputDlgProc(HWND hDlg, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	static TCHAR tRed[4], tGreen[4], tBlue[4];
	static HWND hRed, hGreen, hBlue;
	static int nRed, nGreen, nBlue;
	BOOL flag;
	HWND hParent; // Дескриптор родительского окна
	switch (uMsg)
	{
	case WM_INITDIALOG:
		hRed = GetDlgItem(hDlg, IDC_EDRED);
		hGreen = GetDlgItem(hDlg, IDC_EDGREEN);
		hBlue = GetDlgItem(hDlg, IDC_EDBLUE);
		SetDlgItemText(hDlg, IDC_EDRED, TEXT("0"));
		SetDlgItemText(hDlg, IDC_EDGREEN, TEXT("0"));
		SetDlgItemText(hDlg, IDC_EDBLUE, TEXT("0"));
		return TRUE;
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDOK:
			nRed = GetDlgItemInt(hDlg, IDC_EDRED, &flag, false);
			nGreen = GetDlgItemInt(hDlg, IDC_EDGREEN, &flag, false);
			nBlue = GetDlgItemInt(hDlg, IDC_EDBLUE, &flag, false);
			if (nRed > 255 || nRed < 0 || nGreen > 255 || nGreen < 0 || nBlue > 255 || nBlue < 0)
			{
				MessageBox(NULL, TEXT("Unknown color"), TEXT("Error!"), MB_ICONERROR);
			}
			else
			{
				hParent = GetParent(hDlg); // Получение дескриптора родительского окна для диалогового окна
				SetClassLong(hParent, GCL_HBRBACKGROUND, (LONG)CreateSolidBrush(RGB(nRed, nGreen, nBlue)));

				EndDialog(hDlg, 0);
			}
			return TRUE;
		case IDCANCEL:
			EndDialog(hDlg, 0);
			return TRUE;
		default:
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
		// Получение дескриптора нашего приложения
		SetClassLong(hWnd, GCL_HBRBACKGROUND, (LONG)CreateSolidBrush(RGB(255, 0, 0)));
		hInst = GetModuleHandle(NULL);
		break;
	case WM_PAINT:
		BeginPaint(hWnd, &psPaint);
		EndPaint(hWnd, &psPaint);
		break;
	case UM_CHANGE:
		SetClassLong(hWnd, GCL_HBRBACKGROUND, (LONG)CreateSolidBrush(RGB(rgb[0], rgb[1], rgb[2])));
		InvalidateRect(hWnd, NULL, TRUE);
		break;
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDS_INPUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_SETCOLOR), hWnd, SetColorByInputDlgProc);
			break;
		case IDS_SLIDER:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_SLIDERCOLOR), hWnd, SetColorBySliderDlgProc);
			break;
		default:
			break;
		}
		InvalidateRect(hWnd, NULL, TRUE);
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