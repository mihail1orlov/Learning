cd Consumer
dotnet build
cd bin\Debug\net6.0
start Consumer.exe info
timeout 2
start Consumer.exe warning
timeout 2
Consumer.exe error