FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /app/backend

COPY ./EmailProject.sln ./
COPY ./EmailProject.csproj ./EmailProject.csproj
RUN dotnet restore

COPY . ./
RUN dotnet publish "./EmailProject.csproj" -c Release -o "../out"

FROM mcr.microsoft.com/dotnet/aspnet:latest
WORKDIR /app/backend
COPY --from=build /app/out .
ENV ASPNETCORE_URLS=http://+:50010
ENTRYPOINT ["dotnet", "EmailProject.dll"]