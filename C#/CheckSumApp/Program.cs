using CheckSumApp;

var checkSum = new CheckSum();
var path = @"D:\soft\WinPE10_Sergei_Strelec_x86_x64_2016.03.25.iso";
var cs = checkSum.Get(path);
Console.WriteLine(cs);