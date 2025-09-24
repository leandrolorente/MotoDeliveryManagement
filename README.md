# MotoDeliveryManagement

Sistema de gerenciamento de locação de motos para entregadores, desenvolvido em .NET 8 com arquitetura limpa (Clean Architecture).

## 📋 Sobre o Projeto

O MotoDeliveryManagement é uma API REST que permite o gerenciamento completo de motos, entregadores e locações para empresas de delivery. O sistema oferece funcionalidades para cadastro de motos, gestão de entregadores e controle de locações com diferentes planos de aluguel.

## 🚀 Funcionalidades

### 🏍️ Gestão de Motos
- Cadastro de novas motos
- Consulta de motos existentes
- Consulta por ID específico
- Atualização de placa
- Remoção de motos

### 👨‍💼 Gestão de Entregadores
- Cadastro de entregadores
- Validação de CNH (tipos A e B)
- Upload de foto da CNH
- Validação de CNPJ único

### 📅 Sistema de Locação
- Locação de motos por período
- Planos de locação (7, 15, 30, 45, 50 dias)
- Cálculo automático de valores
- Sistema de multas por devolução antecipada ou tardia
- Consulta de locações por ID

## 🏗️ Arquitetura

O projeto segue os princípios da Clean Architecture, organizado em camadas:

```
MotoDeliveryManagement/
├── MotoDelivery.API/           # Camada de apresentação (Controllers, Swagger)
├── MotoDelivery.Application/   # Camada de aplicação (Commands, Queries, Handlers)
├── MotoDelivery.Domain/        # Camada de domínio (Entidades, Regras de negócio)
├── MotoDelivery.Infrastructure/ # Camada de infraestrutura (Repositories, DbContext)
└── MotoDelivery.SharedKernel/  # Componentes compartilhados
```

## 🛠️ Tecnologias Utilizadas

- **.NET 8** - Framework principal
- **ASP.NET Core** - API REST
- **Entity Framework Core** - ORM
- **PostgreSQL** - Banco de dados
- **MediatR** - Padrão Mediator para CQRS
- **RabbitMQ** - Sistema de mensageria
- **Swagger/OpenAPI** - Documentação da API
- **Docker** - Containerização

## 📦 Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/get-started) e Docker Compose
- [PostgreSQL](https://www.postgresql.org/) (ou usar via Docker)

## 🚀 Como Executar

### 1. Clone o repositório
```bash
git clone https://github.com/leandrolorente/MotoDeliveryManagement.git
cd MotoDeliveryManagement
```

### 2. Executar com Docker (Recomendado)

#### Iniciar os serviços (PostgreSQL + RabbitMQ)
```bash
docker-compose up -d
```

#### Configurar string de conexão
Ajuste a string de conexão no `appsettings.json` ou `appsettings.Development.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=moto_delivery_db;Username=admin;Password=admin"
  }
}
```

#### Executar migrations
```bash
dotnet ef database update --project MotoDelivery.Infrastructure --startup-project MotoDelivery.API
```

#### Executar a aplicação
```bash
dotnet run --project MotoDelivery.API
```

### 3. Executar sem Docker

#### Instalar PostgreSQL localmente
Configure a string de conexão para sua instância local do PostgreSQL.

#### Restaurar dependências
```bash
dotnet restore
```

#### Executar migrations
```bash
dotnet ef database update --project MotoDelivery.Infrastructure --startup-project MotoDelivery.API
```

#### Executar a aplicação
```bash
dotnet run --project MotoDelivery.API
```

## 📚 Documentação da API

Após executar a aplicação, acesse:
- **Swagger UI**: `https://localhost:7xxx/swagger` (HTTPS)
- **Swagger UI**: `http://localhost:5xxx/swagger` (HTTP)

### Principais Endpoints

#### Motos
- `POST /motos` - Cadastrar nova moto
- `GET /motos` - Listar todas as motos
- `GET /motos/{id}` - Consultar moto por ID
- `PUT /motos/{id}/placa` - Atualizar placa da moto
- `DELETE /motos/{id}` - Remover moto

#### Entregadores
- `POST /entregadores` - Cadastrar entregador
- `POST /entregadores/{id}/cnh` - Enviar foto da CNH

#### Locações
- `POST /locacao` - Realizar locação
- `GET /locacao/{id}` - Consultar locação
- `PUT /locacao/{id}/devolucao` - Realizar devolução

## 💰 Planos de Locação

| Plano (dias) | Valor Diária | Multa por Devolução Antecipada |
|--------------|--------------|--------------------------------|
| 7 dias       | R$ 30,00     | 20% sobre dias não utilizados  |
| 15 dias      | R$ 28,00     | 40% sobre dias não utilizados  |
| 30 dias      | R$ 22,00     | Sem multa                      |
| 45 dias      | R$ 20,00     | Sem multa                      |
| 50 dias      | R$ 18,00     | Sem multa                      |

**Multa por atraso**: R$ 50,00 por dia excedido (todos os planos)

## 🔧 Configuração do Banco de Dados

### Docker Compose (Incluído)
O projeto já inclui configuração completa do PostgreSQL via Docker Compose.

### Configuração Manual
```sql
-- Criar banco de dados
CREATE DATABASE moto_delivery_db;

-- Criar usuário (opcional)
CREATE USER admin WITH PASSWORD 'admin';
GRANT ALL PRIVILEGES ON DATABASE moto_delivery_db TO admin;
```

## 🐰 RabbitMQ

O sistema utiliza RabbitMQ para mensageria. Com Docker Compose:
- **Console de gerenciamento**: `http://localhost:15672`
- **Usuário**: `guest`
- **Senha**: `guest`

## 🧪 Testes

```bash
# Executar testes (quando disponíveis)
dotnet test
```

## 📝 Variáveis de Ambiente

Principais configurações que podem ser ajustadas:

```bash
# String de conexão do banco
ASPNETCORE_ConnectionStrings__DefaultConnection="Host=localhost;Port=5432;Database=moto_delivery_db;Username=admin;Password=admin"

# Ambiente de execução
ASPNETCORE_ENVIRONMENT=Development

# Porta da aplicação
ASPNETCORE_URLS=http://+:5000;https://+:5001
```

## 🤝 Contribuindo

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 👨‍💻 Autor

**Leandro Lorente**
- GitHub: [@leandrolorente](https://github.com/leandrolorente)

## 📞 Suporte

Se você encontrar algum problema ou tiver dúvidas, por favor:
1. Verifique se já existe uma [issue](https://github.com/leandrolorente/MotoDeliveryManagement/issues) similar
2. Crie uma nova issue descrevendo o problema detalhadamente
3. Inclua logs de erro e informações do ambiente

---

⭐ **Se este projeto foi útil para você, considere dar uma estrela!**