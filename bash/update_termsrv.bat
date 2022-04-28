: start restart bash
start D:\repos\Learning\bash\reboot.bat

: stop service
net stop TermService

timeout 10

del C:\Windows\System32\termsrv.dll /f

copy D:\repos\Learning\bash\termsrv.dll C:\Windows\System32\termsrv.dll

: start service
net start TermService

timeout 120