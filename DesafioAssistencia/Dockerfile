# Usando a imagem oficial do .NET SDK para construir o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar os arquivos da solução e restaurar as dependências
WORKDIR /app
COPY *.sln .
COPY DesafioAssistencia.csproj ./DesafioAssistencia/
WORKDIR /app/DesafioAssistencia
RUN dotnet restore


# Copiar todos os arquivos e compilar o projeto
COPY . .
WORKDIR /app/DesafioAssistencia
RUN dotnet build --no-restore -c Release
RUN dotnet publish --no-build -c Release -o /out

# Criar a imagem final para execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .
CMD ["dotnet", "DesafioAssistencia.dll"]
