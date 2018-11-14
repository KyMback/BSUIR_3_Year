#include <windows.h>
#include <stdlib.h>
#include <string.h>
#include <setupapi.h>
#include <dbt.h>
#include <strsafe.h>
#include "notify.h"
#include "util.h"
#include <dontuse.h>
#include <conio.h>

#define CREATE_WINDOW_EVENT_NAME "windowCreateEvent"

int main(int argc, char* argv[])
{
	HANDLE window_create_event = CreateEvent(NULL, FALSE, FALSE, CREATE_WINDOW_EVENT_NAME);

	HANDLE thread_handle_ = CreateThread(NULL, 256, WindowThreadRoutine, (LPVOID)CREATE_WINDOW_EVENT_NAME, NULL, NULL);
	if (thread_handle_ == NULL)
	{
		printf("Couldn't create thread\n");
	}

	WaitForSingleObject(window_create_event, INFINITE);

	printf("1. Eject a USB device \n0. exit\n\n ");


	while (TRUE)
	{
		rewind(stdin);

		char key = _getch();

		if (key == '0') return 0;
		if (key != '1') continue;

		char drive_letter = 0;

		printf("Enter driver's letter, what you want to eject\n> ");

		if (!scanf_s("%c", &drive_letter))
		{
			printf("Invalid drive letter value was provided!\n");
			continue;
		}

		if (EjectDevice(drive_letter) == 1)
		{
			printf("Couldn't eject this drive\n");
			getchar();
		}
	}

	return 0;
}