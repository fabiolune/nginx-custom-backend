FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src

COPY . .

RUN dotnet publish -r linux-arm	  -c Release -o /artifacts/linux-arm
RUN dotnet publish -r linux-arm64 -c Release -o /artifacts/linux-arm64
RUN dotnet publish -r linux-x64   -c Release -o /artifacts/linux-x64

FROM alpine as temp
COPY --from=build /artifacts /artifacts