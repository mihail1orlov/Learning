: Install Service

:sc create WorkerServerTmp BinPath= C:\Services\WorkerServer\WorkerServer.exe start= auto

set serviceName=WorkerServer
set path=%cd%\%serviceName%.exe
echo sc.exe create %serviceName%Tmp BinPath= %path% start= auto