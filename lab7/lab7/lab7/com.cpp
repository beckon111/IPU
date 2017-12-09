#include "com.h"

int getch_(){return _kbhit() ? _getch() : -1;}

void COM(HANDLE readEnd, HANDLE writeEnd, HANDLE hFile, HANDLE writeStart) //вызов из мейн
{
	char buffer[100];
	int size; 
	
	while(true)
	{
		if(WaitForSingleObject(writeStart, 1) != WAIT_TIMEOUT) //busy
		{
			WaitForSingleObject(writeEnd, INFINITE);
			size = read(hFile, buffer);
			printf("\nMess: ");
			for(int i = 0; i < size; i++) printf("%c", buffer[i]);

			if (!strcmp(buffer, "q\0")) {
				printf("\n");
				SetEvent(readEnd);
				return;
			}
			printf("\n");
			SetEvent(readEnd);			
		}

		if(getch_() == '+')
		{			
			SetEvent(writeStart);
			printf("\nprint: ");
			if (!write(hFile, buffer))
			{
				SetEvent(writeEnd);
				WaitForSingleObject(readEnd, INFINITE);
				return;
			}
			else
			{
				SetEvent(writeEnd);
				WaitForSingleObject(readEnd, INFINITE);
			}
		}
	}
}

int read(HANDLE hFile, char* buffer)         //чтение из файла
{
	int size;
	DWORD numberOfBytesRead;

	ReadFile(hFile, &size, 1 * sizeof(int), &numberOfBytesRead, NULL);	//read size
	ReadFile(hFile, buffer, size * sizeof(char), &numberOfBytesRead, NULL);	//read info
	buffer[size] = '\0';

	return size;
}

bool write(HANDLE hFile, char* buffer)       //запись в файл
{
	char symb;
	int i = 0;
	DWORD numberOfBytesWrite;

	while(true)
	{
		scanf("%c", &symb);
		if(symb == '\n')
		{ 
			buffer[i] = '\0';
			WriteFile(hFile, &i, 1 * sizeof(int), &numberOfBytesWrite, NULL);	//write size
			WriteFile(hFile, buffer, i * sizeof(char), &numberOfBytesWrite, NULL);	//write info

			if (!strcmp(buffer, "q\0")){
				return false;
			}
			return true;
		}
		else {
			buffer[i] = symb;
		}
		i++;
	}
}