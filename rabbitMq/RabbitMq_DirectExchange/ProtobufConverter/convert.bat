set protocPath=%userprofile%\.nuget\packages\google.protobuf.tools\3.19.1\tools\windows_x64\protoc.exe
%protocPath% tst.proto --csharp_out=out --proto_path=source