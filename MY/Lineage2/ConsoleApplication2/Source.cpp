#include <iostream>
#include <windows.h>
#include <iomanip>
#include <cmath>
#include <Magick++.h>

using namespace std;
using namespace Magick;

inline int GetFilePointer(HANDLE FileHandle) {
	return SetFilePointer(FileHandle, 0, 0, FILE_CURRENT);
}

bool SaveBMPFile(TCHAR *filename, HBITMAP bitmap, HDC bitmapDC, int width, int height) {
	bool Success = 0;
	HDC SurfDC = NULL;
	HBITMAP OffscrBmp = NULL;
	HDC OffscrDC = NULL;
	LPBITMAPINFO lpbi = NULL;
	LPVOID lpvBits = NULL;
	HANDLE BmpFile = INVALID_HANDLE_VALUE;
	BITMAPFILEHEADER bmfh;
	if ((OffscrBmp = CreateCompatibleBitmap(bitmapDC, width, height)) == NULL)
		return 0;
	if ((OffscrDC = CreateCompatibleDC(bitmapDC)) == NULL)
		return 0;
	HBITMAP OldBmp = (HBITMAP)SelectObject(OffscrDC, OffscrBmp);
	BitBlt(OffscrDC, 0, 0, width, height, bitmapDC, 0, 0, SRCCOPY);
	if ((lpbi = (LPBITMAPINFO)(new char[sizeof(BITMAPINFOHEADER) + 256 * sizeof(RGBQUAD)])) == NULL)
		return 0;
	ZeroMemory(&lpbi->bmiHeader, sizeof(BITMAPINFOHEADER));
	lpbi->bmiHeader.biSize = sizeof(BITMAPINFOHEADER);
	SelectObject(OffscrDC, OldBmp);
	if (!GetDIBits(OffscrDC, OffscrBmp, 0, height, NULL, lpbi, DIB_RGB_COLORS))
		return 0;
	if ((lpvBits = new char[lpbi->bmiHeader.biSizeImage]) == NULL)
		return 0;
	if (!GetDIBits(OffscrDC, OffscrBmp, 0, height, lpvBits, lpbi, DIB_RGB_COLORS))
		return 0;
	if ((BmpFile = CreateFile(filename,
		GENERIC_WRITE,
		FILE_SHARE_READ, NULL,
		CREATE_ALWAYS,
		FILE_ATTRIBUTE_NORMAL,
		NULL)) == INVALID_HANDLE_VALUE)
		return 0;
	DWORD Written;
	bmfh.bfType = 19778;
	bmfh.bfReserved1 = bmfh.bfReserved2 = 0;
	if (!WriteFile(BmpFile, &bmfh, sizeof(bmfh), &Written, NULL))
		return 0;
	if (Written < sizeof(bmfh))
		return 0;
	if (!WriteFile(BmpFile, &lpbi->bmiHeader, sizeof(BITMAPINFOHEADER), &Written, NULL))
		return 0;
	if (Written < sizeof(BITMAPINFOHEADER))
		return 0;
	int PalEntries;
	if (lpbi->bmiHeader.biCompression == BI_BITFIELDS)
		PalEntries = 3;
	else PalEntries = (lpbi->bmiHeader.biBitCount <= 8) ?
		(int)(1 << lpbi->bmiHeader.biBitCount) : 0;
	if (lpbi->bmiHeader.biClrUsed)
		PalEntries = lpbi->bmiHeader.biClrUsed;
	if (PalEntries) {
		if (!WriteFile(BmpFile, &lpbi->bmiColors, PalEntries * sizeof(RGBQUAD), &Written, NULL))
			return 0;
		if (Written < PalEntries * sizeof(RGBQUAD))
			return 0;
	}
	bmfh.bfOffBits = GetFilePointer(BmpFile);
	if (!WriteFile(BmpFile, lpvBits, lpbi->bmiHeader.biSizeImage, &Written, NULL))
		return 0;
	if (Written < lpbi->bmiHeader.biSizeImage)
		return 0;
	bmfh.bfSize = GetFilePointer(BmpFile);
	SetFilePointer(BmpFile, 0, 0, FILE_BEGIN);
	if (!WriteFile(BmpFile, &bmfh, sizeof(bmfh), &Written, NULL))
		return 0;
	if (Written < sizeof(bmfh))
		return 0;
	return 1;
}
bool ScreenCapture(int x, int y, int width, int height, TCHAR *filename) {
	HDC hDc = CreateCompatibleDC(0);
	HBITMAP hBmp = CreateCompatibleBitmap(GetDC(0), width, height);
	SelectObject(hDc, hBmp);
	BitBlt(hDc, 0, 0, width, height, GetDC(0), x, y, SRCCOPY);
	bool ret = SaveBMPFile(filename, hBmp, hDc, width, height);
	DeleteObject(hBmp);
	return ret;
}

void LeftClick()
{
	INPUT    Input = { 0 };
	// left down 
	Input.type = INPUT_MOUSE;
	Input.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
	::SendInput(1, &Input, sizeof(INPUT));

	// left up
	::ZeroMemory(&Input, sizeof(INPUT));
	Input.type = INPUT_MOUSE;
	Input.mi.dwFlags = MOUSEEVENTF_LEFTUP;
	::SendInput(1, &Input, sizeof(INPUT));
}

int main(int argc, char **argv) {
	//InitializeMagick(*argv);
	////WinExec("s.cmd", SW_SHOW);
	//ScreenCapture(27, 712, 16, 15, L"picture.png");
	//system("convert picture.bmp -resize 15x20\! rpicture.bmp");
	//system("convert templ.png templ.png rpicture.bmp +append appen.png");
	////system("tesseract appen.png o -l eng+rus");
	//Image image("box.png");
	//FILE *f = fopen("o.txt", "r");
	//int mails;
	//char txt[256];
	//fscanf(f, "%d", &mails);
	//cout << mails << endl;
	//fclose(f);
	//if (!mails) {
	//	//mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, 0, 0, 0, 0);
	//	//mouse_event(MOUSEEVENTF_MOVE, 15, 375, 0, 0);
	//	//mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
	//	//mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
	//	SetCursorPos(15,720);
	//	LeftClick();
	//	for (int i = 0, j = 0; !i; j++) {
	//		ScreenCapture(21, 215, 12, 12, L"box_read.png");
	//		Image box("box_read.png");
	//		int w = box.columns(), h = box.rows(), error = 0;
	//		Quantum *pixels, *pixels_box;
	//		for (int i = 0; i < h; i++) {
	//			for (int j = 0; j < w; j++) {
	//				pixels = image.getPixels(i, j, 1, 1);
	//				pixels_box = box.getPixels(i, j, 1, 1);
	//				if (*pixels != *pixels_box) error++;
	//			}
	//		}
	//		if (!error) {
	//			mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, 0, 0, 0, 0);
	//			mouse_event(MOUSEEVENTF_MOVE, 100, 115, 0, 0);
	//			mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
	//			mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
	//			mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
	//			mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
	//			i++;
	//		}
	//	}
	//}
	/*for (int i = 0; i < 5; i++)
	{
		mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
		mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
		Sleep(1000);
	}*/

	HWND wnd1 = FindWindowA("l2UnrealWWindowsViewportWindow", NULL);
	SendMessage(wnd1, WM_ACTIVATE, 0, 0);
	SendMessage(wnd1, WM_LBUTTONUP, 0, MAKELPARAM(300, 500));
	cout << "Clicked";

	return 0;
}