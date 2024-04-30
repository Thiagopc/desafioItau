# Use a base image from Microsoft that includes the .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Clear NuGet cache
RUN dotnet nuget locals all --clear

# Copy the solution file if it is part of a larger solution
COPY ./*.sln ./

# Copy csproj and restore as distinct layers
COPY ./desafioItau.api/*.csproj ./desafioItau.api/
RUN dotnet restore ./desafioItau.api/desafioItau.api.csproj

# Copy everything else and build
COPY . ./
RUN dotnet publish ./desafioItau.api/desafioItau.api.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "desafioItau.api.dll"]
