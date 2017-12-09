#include "com.h"

int main(int argc, TCHAR* argv[])
{
	if(argc == 1)          
	{
		HANDLE readEnd = CreateEvent(NULL, FALSE, FALSE, "readEnd");        //создаем события
		HANDLE writeEnd = CreateEvent(NULL, FALSE, FALSE, "writeEnd");      //
		HANDLE writeStart = CreateEvent(NULL, FALSE, FALSE, "writeStart");  //

		HANDLE hFile = CreateFile("COM1", GENERIC_WRITE | GENERIC_READ, 0, NULL, OPEN_EXISTING, 0, NULL);  //открытие порта
		if (hFile == NULL){
			printf("Error\n");
			exit(GetLastError());
		}

		STARTUPINFO si = {};
		si.cb = sizeof si;
		PROCESS_INFORMATION pi = {};
		if(! CreateProcess(argv[0], " COM2", NULL, NULL, FALSE, CREATE_NEW_CONSOLE, NULL, NULL, &si, &pi)){
			printf("Error while creating process!\n");
			return 1;
		}
		
		puts("COM1 ready to use");
		COM(readEnd, writeEnd, hFile, writeStart);
		
		WaitForSingleObject(pi.hProcess, INFINITE);   //синхронизация
		CloseHandle(pi.hThread); 
		CloseHandle(pi.hProcess);

		CloseHandle(hFile);  //закрытие порта
	}
	else
	{
		HANDLE hFile = CreateFile("COM2", GENERIC_READ | GENERIC_WRITE, 0, NULL, OPEN_EXISTING, 0, NULL);   //открытие порта (синхр)
		if (hFile == NULL){
			printf("Error\n");
			exit(GetLastError());
		}
		HANDLE readEnd = OpenEvent(EVENT_ALL_ACCESS, FALSE, "readEnd");       //получаем доступ к событиям другого процесса
		HANDLE writeEnd = OpenEvent(EVENT_ALL_ACCESS, FALSE, "writeEnd");     //
		HANDLE writeStart = OpenEvent(EVENT_ALL_ACCESS, FALSE, "writeStart"); //
		
		puts("COM2 ready to use");
		COM(readEnd, writeEnd, hFile, writeStart);

		CloseHandle(hFile);   //закрытие порта
	}
	return 0;
}