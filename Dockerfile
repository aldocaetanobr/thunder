FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app

COPY . . 

RUN dotnet restore ThunderTasks.sln

RUN dotnet publish ThunderTasks.sln -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

WORKDIR /app

COPY --from=build /out .

EXPOSE 5197

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

ENTRYPOINT ["dotnet", "ThunderTasks.dll"]
