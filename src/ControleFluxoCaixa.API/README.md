# ControleFluxoCaixa API

## Descri��o
API para controle de fluxo de caixa di�rio com lan�amentos de d�bitos e cr�ditos e relat�rio de saldo di�rio consolidado.

## Requisitos
- .NET 8.0
- Angular
- Docker
- SQLite

## Como Rodar Localmente

### Backend
1. Clone o reposit�rio.
2. Navegue at� a pasta `ControleFluxoCaixa.Api`.
3. Execute `dotnet run`.

### Frontend
1. Navegue at� a pasta `controlefluxocaixa-frontend`.
2. Execute `ng serve`.

### Docker
1. Navegue at� a pasta raiz do projeto.
2. Execute `docker build -t controlefluxocaixa-api .`
3. Execute `docker run -d -p 80:80 controlefluxocaixa-api`

## Testes
1. Navegue at� a pasta `ControleFluxoCaixa.Testes`.
2. Execute `dotnet test`.
