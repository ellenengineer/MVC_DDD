#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ATS.WebApp/ATS.WebApp.csproj", "ATS.WebApp/"]
RUN dotnet restore "ATS.WebApp/ATS.WebApp.csproj"
COPY . .
WORKDIR "/src/ATS.WebApp"
RUN dotnet build "ATS.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ATS.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ATS.WebApp.dll"]