# ControleFluxoCaixa API

## Descrição
API para controle de fluxo de caixa diário com lançamentos de débitos e créditos e relatório de saldo diário consolidado.

## Requisitos
- .NET 8.0
- Angular
- Docker
- SQLite

## Como Rodar Localmente

### Backend
1. Clone o repositório.
2. Navegue até a pasta `ControleFluxoCaixa.Api`.
3. Execute `dotnet run`.

### Frontend
1. Navegue até a pasta `controlefluxocaixa-frontend`.
2. Execute `ng serve`.

### Docker
1. Navegue até a pasta raiz do projeto.
2. Execute `docker build -t controlefluxocaixa-api .`
3. Execute `docker run -d -p 80:80 controlefluxocaixa-api`

## Testes
1. Navegue até a pasta `ControleFluxoCaixa.Testes`.
2. Execute `dotnet test`.
