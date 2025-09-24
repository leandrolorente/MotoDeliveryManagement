# 🏍️ MotoDeliveryManagement

Sistema de gerenciamento de entrega por motocicletas desenvolvido em .NET 8 com arquitetura limpa (Clean Architecture).

## 📋 Sobre o Projeto

O MotoDeliveryManagement é uma API para gerenciar motocicletas, entregadores e locações em um sistema de delivery. O sistema permite:

- **Gestão de Motocicletas**: Cadastro, consulta, atualização e remoção de motos
- **Gestão de Entregadores**: Cadastro de entregadores com validação de CNH
- **Sistema de Locações**: Controle de aluguel de motocicletas por entregadores
- **Mensageria**: Notificações via RabbitMQ
- **Persistência**: Banco de dados PostgreSQL com Entity Framework Core

## 🏗️ Arquitetura

O projeto segue os princípios da Clean Architecture, organizado em camadas:

```
├── MotoDelivery.API/              # Camada de apresentação (Controllers, Swagger)
├── MotoDelivery.Application/      # Camada de aplicação (Commands, Queries, Handlers)
├── MotoDelivery.Domain/           # Camada de domínio (Entidades, Regras de negócio)
├── MotoDelivery.Infrastructure/   # Camada de infraestrutura (Repositories, DbContext)
├── MotoDelivery.SharedKernel/     # Componentes compartilhados
└── docker-compose.yml             # Configuração do Docker
```

### Principais Tecnologias

- **.NET 8**: Framework principal
- **ASP.NET Core**: API Web
- **Entity Framework Core**: ORM para acesso a dados
- **PostgreSQL**: Banco de dados relacional
- **RabbitMQ**: Message broker para comunicação assíncrona
- **MediatR**: Padrão Mediator para CQRS
- **Swagger/OpenAPI**: Documentação da API
- **Docker**: Containerização

## 🚀 Como Executar

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/get-started) (para PostgreSQL e RabbitMQ)
- [Git](https://git-scm.com/)

### 1. Clonar o Repositório

```bash
git clone https://github.com/leandrolorente/MotoDeliveryManagement.git
cd MotoDeliveryManagement
```

### 2. Executar Dependências com Docker

```bash
# Iniciar PostgreSQL e RabbitMQ
docker-compose up -d
```

Isso iniciará:
- **PostgreSQL** na porta `5432` (usuário: `admin`, senha: `admin`, database: `moto_delivery_db`)
- **RabbitMQ** na porta `5672` com Management UI na porta `15672`

### 3. Configurar a Aplicação

Verifique a string de conexão no `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=moto_delivery_db;Username=admin;Password=admin"
  }
}
```

### 4. Executar Migrações

```bash
# Navegar até o projeto API
cd MotoDelivery.API

# Executar migrações do Entity Framework
dotnet ef database update
```

### 5. Executar a Aplicação

```bash
# A partir da pasta MotoDelivery.API
dotnet run
```

A API estará disponível em:
- **HTTP**: `http://localhost:5000`
- **HTTPS**: `https://localhost:5001`
- **Swagger**: `http://localhost:5000/swagger`

## 📋 API Endpoints

### 🏍️ Motocicletas (`/motos`)

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| `POST` | `/motos` | Cadastrar uma nova moto |
| `GET` | `/motos?placa=` | Consultar motos (filtro por placa opcional) |
| `PUT` | `/motos/{id}/placa` | Modificar placa de uma moto |
| `DELETE` | `/motos/{id}` | Remover uma moto |

### 👤 Entregadores (`/entregadores`)

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| `POST` | `/entregadores` | Cadastrar um novo entregador |
| `POST` | `/entregadores/{id}/cnh` | Enviar foto da CNH |

### 📦 Locações (`/locacao`)

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| `POST` | `/locacao` | Alugar uma moto |
| `GET` | `/locacao/{id}` | Consultar locação por ID |
| `PUT` | `/locacao/{id}/devolucao` | Informar data de devolução |

## 🏗️ Estrutura do Banco de Dados

### Principais Entidades

- **Motos**: `Id`, `Identificador`, `Ano`, `Modelo`, `Placa`
- **Entregadores**: `Id`, `Identificador`, `Nome`, `CNPJ`, `DataNascimento`, `NumeroCNH`, `TipoCNH`
- **Locações**: `Id`, `EntregadorId`, `MotoId`, `DataInicio`, `DataTermino`, `DataPrevisaoTermino`, `Plano`

## 🔧 Desenvolvimento

### Estrutura de Comandos e Consultas (CQRS)

O projeto utiliza o padrão CQRS com MediatR:

- **Commands**: Para operações de escrita (Create, Update, Delete)
- **Queries**: Para operações de leitura (Get, List)
- **Handlers**: Processam os commands e queries

### Executar Testes

```bash
# A partir da raiz do projeto
dotnet test
```

### Build da Aplicação

```bash
# Build da solução completa
dotnet build

# Build com configuração de Release
dotnet build --configuration Release
```

### Executar com Docker

```bash
# Build da imagem Docker
docker build -t moto-delivery-api -f MotoDelivery.API/Dockerfile .

# Executar container
docker run -p 8080:8080 moto-delivery-api
```

## 🌐 Acessos Importantes

Após executar o docker-compose:

- **API**: http://localhost:5000/swagger
- **RabbitMQ Management**: http://localhost:15672 (usuário: `guest`, senha: `guest`)
- **PostgreSQL**: `localhost:5432` (usuário: `admin`, senha: `admin`)

## 📝 Exemplos de Uso

### Cadastrar uma Moto

```bash
curl -X POST "http://localhost:5000/motos" \
  -H "Content-Type: application/json" \
  -d '{
    "identificador": "MOTO001",
    "ano": 2024,
    "modelo": "Honda CG 160",
    "placa": "ABC-1234"
  }'
```

### Consultar Motos

```bash
curl -X GET "http://localhost:5000/motos"
```

### Cadastrar Entregador

```bash
curl -X POST "http://localhost:5000/entregadores" \
  -H "Content-Type: application/json" \
  -d '{
    "identificador": "ENT001",
    "nome": "João Silva",
    "cnpj": "12345678000195",
    "dataNascimento": "1990-01-15",
    "numeroCnh": "12345678901",
    "tipoCnh": "A",
    "imagemCnh": "base64_image_string_here"
  }'
```

## 🤝 Contribuição

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está sob licença MIT. Veja o arquivo `LICENSE` para mais detalhes.

## 👨‍💻 Autor

**Leandro Lorente** - [GitHub](https://github.com/leandrolorente)

---

⭐ Se este projeto te ajudou, considere dar uma estrela no repositório!