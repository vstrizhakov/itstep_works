#include <Windows.h>
#include <string>
#include <io.h>
#include <stdio.h>
#include "resource.h"

using namespace std;
// Обработка сообщений оконной процедуры
LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam);

HWND hEdt; // Оконная процедура
static FILE *fdat;

// Функции для изменения размера окна измененния текста
void AdjustWindowSize(HWND hParent, HWND hDlg);
void ShiftWindow(HWND hChild, HWND hParent, int dX, int dY, int dW, int dH);

// Функция для инициализации структуры для открытия файла
void OfnInitialize(HWND hWnd);

/* Структура для работы с открытием файлов */
static OPENFILENAME ofn;
static TCHAR fileName[MAX_PATH];

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
	hWnd = CreateWindow(szClassName, TEXT("Notepad"), WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, NULL, NULL, hInst, NULL);
	if (!hWnd)
	{
		MessageBox(NULL, TEXT("Creating failure"), TEXT("ERROR"), MB_OK);
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

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	HDC hDC;
	RECT rect;
	HINSTANCE hInst = GetModuleHandle(NULL);
	/* Структура окна для работы со шрифтом */
	static CHOOSEFONT chf;
	static HFONT hFont;
	static LOGFONT lf;
	/* Структура для работы с окном выбора цвета */
	static CHOOSECOLOR cc;
	static COLORREF color;
	static COLORREF colors[16];

	PAINTSTRUCT psPaint;

	switch (uMsg)
	{
	case WM_CLOSE:
		DestroyWindow(hWnd);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_CREATE:
		hEdt = CreateWindow(TEXT("edit"), NULL, WS_CHILD | WS_VISIBLE | WS_HSCROLL | WS_VSCROLL | ES_LEFT | ES_MULTILINE | ES_AUTOHSCROLL | ES_AUTOVSCROLL | ES_WANTRETURN, 0, 0, 100, 100, hWnd, (HMENU)NULL, hInst, NULL);
		/* Инициализация структуры для открыти файла */
		OfnInitialize(hWnd);
		/* Инициализация структуры для работы со шрифтами */
		chf.lStructSize = sizeof(CHOOSEFONT);
		chf.hwndOwner = hWnd;
		chf.lpLogFont = &lf;
		chf.Flags = CF_SCREENFONTS | CF_INITTOLOGFONTSTRUCT;
		chf.nFontType = SIMULATED_FONTTYPE;
		/* Инициализация структуры для работы с цветом */
		cc.lStructSize = sizeof(cc);
		cc.hwndOwner = hWnd;
		cc.lpCustColors = colors;
		cc.Flags = CC_FULLOPEN | CC_RGBINIT;
		break;
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDM_OPEN:
			if (GetOpenFileName(&ofn))
			{				
				char fileNameChar[MAX_PATH] = "";
				long len = lstrlen(ofn.lpstrFile);
				WideCharToMultiByte(CP_ACP, 0, ofn.lpstrFile, -1, fileNameChar, len, 0, 0);
				fdat = fopen(fileNameChar, "rb");
				if (fdat)
				{
					int fd = _fileno(fdat);
					len = _filelength(fd);
					if (len > 1)
					{
						char *nBuf = new char[len];
						TCHAR *wBuf = new TCHAR[len];
						fread(nBuf, sizeof(char), len, fdat);
						MultiByteToWideChar(CP_ACP, 0, nBuf, -1, wBuf, len);
						SetWindowText(hEdt, wBuf);
						delete[] nBuf;
						delete[] wBuf;						
					}
					fclose(fdat);
				}
				else
				{
					MessageBox(hWnd, ofn.lpstrFile, TEXT("Error opening file"), MB_ICONERROR);
				}
			}
			else
			{
				
			}
			InvalidateRect(hWnd, NULL, TRUE);
			break;
		case IDM_SAVE:
			if (GetSaveFileName(&ofn))
			{
				char fileNameChar[MAX_PATH] = "";
				long len = lstrlen(ofn.lpstrFile);
				WideCharToMultiByte(CP_ACP, 0, ofn.lpstrFile, -1, fileNameChar, len + 1, 0, 0);
				fdat = fopen(fileNameChar, "wb");
				if (fdat)
				{
					len = SendMessage(hEdt, WM_GETTEXTLENGTH, 0, 0);
					TCHAR* wBuf = new TCHAR[len + 1];
					GetWindowText(hEdt, wBuf, len + 1);
					char *nBuf = new char[len + 1];
					WideCharToMultiByte(CP_ACP, 0, wBuf, -1, nBuf, len + 1, NULL, NULL);
					fwrite(nBuf, len, 1, fdat);
					delete[] wBuf;
					delete[] nBuf;
					fclose(fdat);
				}
				else
				{
					MessageBox(hWnd, ofn.lpstrFile, TEXT("Error saving file"), MB_ICONERROR);
				}
			}
			break;

		case IDM_FONT:
			if (ChooseFont(&chf))
				hFont = CreateFontIndirect(chf.lpLogFont);
			SendMessage(hEdt, WM_SETFONT, (WPARAM)hFont, TRUE);
			break;
		case IDM_COLOR:
			if (ChooseColor(&cc))
			{
				color = cc.rgbResult;
				SetClassLong(hWnd, GCL_HBRBACKGROUND, LONG(CreateSolidBrush(color)));
			}
			break;
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		default:
			break;
		}
		InvalidateRect(hWnd, NULL, true);
		break;
	case WM_SIZE:
		AdjustWindowSize(hWnd, hEdt);
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

void AdjustWindowSize(HWND hParent, HWND hDlg)
{
	RECT rcParent, rcDlg;
	GetClientRect(hParent, &rcParent);
	GetClientRect(hDlg, &rcDlg);
	int width = rcDlg.right - rcDlg.left;
	int height = rcDlg.bottom - rcDlg.top;
	int dW = rcParent.right - width;
	int dH = rcParent.bottom - height;
	ShiftWindow(hDlg, hParent, 0, 0, dW, dH);
}

void ShiftWindow(HWND hChild, HWND hParent, int dX, int dY, int dW, int dH)
{
	RECT rect;
	POINT point;

	GetWindowRect(hChild, &rect);
	int width = rect.right - rect.left + dW;
	int height = rect.bottom - rect.top + dH;
	point.x = rect.left + dX;
	point.y = rect.top + dY;
	ScreenToClient(hParent, &point);
	MoveWindow(hChild, point.x, point.y, width - 17, height - 17, true);
}

void OfnInitialize(HWND hWnd)
{
	static TCHAR szFilter[] = TEXT("Text Files (*.txt)\0*.txt\0All Files(*.*)\0*.*\0\0");
	ofn.lStructSize = sizeof(OPENFILENAME);
	ofn.hwndOwner = hWnd;
	ofn.hInstance = NULL;
	ofn.lpstrFilter = szFilter;
	ofn.lpstrCustomFilter = NULL;
	ofn.nMaxCustFilter = 0;
	ofn.nFilterIndex = 0;
	ofn.lpstrFile = fileName;
	ofn.lpstrFile[0] = '\0';
	ofn.nMaxFile = sizeof(fileName);
	ofn.lpstrFileTitle = NULL;
	ofn.nMaxFileTitle = _MAX_FNAME + _MAX_EXT;
	ofn.lpstrInitialDir = NULL;
	ofn.lpstrTitle = NULL;
	ofn.Flags = 0;
	ofn.nFileOffset = 0;
	ofn.nFileExtension = 0;
	ofn.lpstrDefExt = TEXT("txt");
	ofn.lCustData = 0;
	ofn.lpfnHook = NULL;
	ofn.lpTemplateName = NULL;
}