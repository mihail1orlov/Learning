: create dir
mkdir DemoApp

: change directory
cd DemoApp

: create new console project
dotnet new console

: build and run
dotnet build
dotnet run

: create Dockerfile
(echo FROM mcr.microsoft.com/dotnet/core/sdk:latest && echo COPY . /app && echo WORKDIR /app && echo RUN ["dotnet", "restore"] && echo RUN ["dotnet", "build"] && echo ENTRYPOINT ["dotnet", "run", "--no-launch-profile"]) > Dockerfile

: docker
docker build --tag demodocker .
docker run --rm -it demodocker