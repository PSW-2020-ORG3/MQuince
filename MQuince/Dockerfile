FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

COPY MQuince.APIGateway/MQuince.APIGateway.csproj MQuince.APIGateway/
COPY MQuince.Infrastructure/MQuince.Infrastructure.csproj MQuince.Infrastructure/
COPY MQuince.Review.Domain/MQuince.Review.Domain.csproj MQuince.Review.Domain/
COPY MQuince.Scheduler.Domain/MQuince.Scheduler.Domain.csproj MQuince.Scheduler.Domain/
COPY MQuince.Core/MQuince.Core.csproj MQuince.Core/

RUN dotnet restore MQuince.APIGateway/MQuince.APIGateway.csproj

COPY . .

FROM build AS publish

ARG DATABASE_USERNAME
ARG DATABASE_PASSWORD
ARG DATABASE_DOMAIN
ARG DATABASE_SCHEMA
ARG DATABASE_PORT
ARG STAGE
ARG PORT

ENV DATABASE_USERNAME = $DATABASE_USERNAME
ENV DATABASE_PASSWORD = $DATABASE_PASSWORD
ENV DATABASE_DOMAIN = $DATABASE_DOMAIN
ENV DATABASE_SCHEMA = $DATABASE_SCHEMA
ENV DATABASE_PORT = $DATABASE_PORT
ENV STAGE = $STAGE
ENV PORT = $PORT

WORKDIR /app/MQuince.APIGateway
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install -g dotnet-ef --version 3.1.0
#RUN dotnet ef migrations add Initial
#WORKDIR /app
# WORKDIR /app/MQuince.WebAPI
RUN dotnet ef migrations add Init
WORKDIR /app
COPY MQuince.APIGateway/clientapp out/clientapp
#COPY MQuince.WebAPI.Integration.Testing/MQuince.WebAPI.Integration.Testing.csproj out
RUN dotnet publish MQuince.APIGateway/MQuince.APIGateway.csproj -c Release -o out



FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
#RUN useradd -ms /bin/bash defaultuser
WORKDIR /app
#ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000
COPY --from=publish /app/out .
COPY --from=publish /app/MQuince.APIGateway/Migrations .
#ENTRYPOINT ["dotnet", "MQuince.WebAPI.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet MQuince.APIGateway.dll