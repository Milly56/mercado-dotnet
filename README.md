<h1 align="center">🛒 mercado-dotnet</h1>

<p align="center">
  Sistema de supermercado fictício desenvolvido em C# para praticar orientação a objetos, herança, enums e boas práticas de arquitetura.
</p>

<p align="center">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white" alt="C#">
  <img src="https://img.shields.io/badge/.NET_10-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 10">
  <img src="https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white" alt="SQL Server">
  <img src="https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white" alt="Docker">
  <img src="https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black" alt="Swagger">
</p>

---

# 📖 Sobre o Projeto

O **mercado-dotnet** foi desenvolvido com o objetivo de praticar os principais conceitos do ecossistema C# e .NET, simulando o gerenciamento de um supermercado fictício. O sistema inclui cadastro de produtos, clientes, funcionários e pedidos, com separação clara de responsabilidades entre Models, Services, Repositories e Controllers.

---

# ✨ Funcionalidades

- ✅ Cadastro e gerenciamento de funcionários
- ✅ Cadastro e gerenciamento de produtos
- ✅ Cadastro de clientes
- ✅ Registro e controle de pedidos
- ✅ Controle de estoque por categoria
- ✅ Documentação automática com Swagger
- 🔲 Middlewares de tratamento de erros
- 🔲 Autenticação
- 🔲 Relatórios com LINQ
- 🔲 Eventos de estoque baixo com Delegates & Events

---

# 🛠️ Tecnologias Utilizadas

## Back-end
- C# com .NET 10
- ASP.NET Core Web API
- Entity Framework Core

## Banco de Dados
- SQL Server 2022

## Outras Ferramentas
- Docker & Docker Compose
- Swagger / Swashbuckle

---

# 📁 Estrutura do Projeto

```
mercado-dotnet/
├── Controllers/         # Recebe e responde requisições HTTP
├── Data/                # Contexto do banco de dados (Entity Framework)
│   └── AppDbContext.cs
├── DTOs/                # Objetos de transferência de dados
│   ├── Request/
│   │   └── FuncionarioRequestDto.cs
│   └── Response/
│       └── FuncionarioResponseDto.cs
├── Enums/               # Enumerações da aplicação
│   ├── Categoria.cs
│   └── Status.cs
├── Interfaces/          # Contratos para Services e Repositories
├── Middlewares/         # Interceptadores de requisição
├── Migrations/          # Histórico de migrações do banco de dados
├── Models/              # Entidades do domínio
│   ├── Produto.cs
│   ├── Cliente.cs
│   ├── Funcionario.cs
│   ├── Caixa.cs
│   ├── Gerente.cs
│   ├── Pedido.cs
│   └── ItemPedido.cs
├── Repositories/        # Acesso a dados
├── Services/            # Regras de negócio
├── appsettings.json
├── .env.example
├── Dockerfile
└── docker-compose.yml
```

---

# 🧱 Models

| Classe | Descrição |
|---|---|
| `Produto` | Nome, preço, estoque e categoria |
| `Cliente` | Nome, CPF, email e histórico de pedidos |
| `Funcionario` | Classe base com nome, CPF e salário |
| `Caixa` | Herda de `Funcionario` — total de vendas realizadas |
| `Gerente` | Herda de `Funcionario` — limite de desconto |
| `Pedido` | Cliente, funcionário, itens, data e status |
| `ItemPedido` | Produto, quantidade, preço unitário e total calculado |

---

# 📌 Enums

| Enum | Valores |
|---|---|
| `Categoria` | Bebidas, Limpeza, Higiene, Padaria, Carnes, Outros |
| `Status` | Aberto, Fechado, Cancelado |

---

# 📚 Conceitos Praticados

- Orientação a Objetos (POO)
- Herança e Encapsulamento
- Propriedades automáticas e calculadas
- Enums
- DTOs (Request e Response)
- Data Annotations (`[Required]`, `[StringLength]`, `[RegularExpression]`)
- Entity Framework Core com Migrations
- Separação de responsabilidades (Models, Services, Repositories)
- Containerização com Docker

---

# ▶️ Como Rodar

### Com Docker (recomendado)

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/mercado-dotnet.git

# Entre na pasta
cd mercado-dotnet

# Configure as variáveis de ambiente
cp .env.example .env

# Suba os containers
docker compose up --build -d
```

### Sem Docker

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/mercado-dotnet.git

# Entre na pasta
cd mercado-dotnet

# Configure a connection string no appsettings.json

# Rode as migrations
dotnet ef database update

# Rode o projeto
dotnet run
```

---

# 🔐 Variáveis de Ambiente

Crie um arquivo `.env` na raiz baseado no `.env.example`:

```env
SA_PASSWORD=suasenha
DB_CONNECTION=Server=sqlserver;Database=Supermercado;User Id=sa;Password=suasenha;TrustServerCertificate=True
```

> ⚠️ Nunca suba o `.env` para o repositório!

---

# 🗺️ Próximos Passos

- [x] Criar Models e Enums
- [x] Configurar Entity Framework Core e DbContext
- [x] Configurar Docker e docker-compose
- [x] Criar DTOs de Request e Response
- [x] Implementar Repositories
- [x] Implementar Services
- [x] Implementar Controllers com endpoints REST
- [ ] Adicionar Middlewares de tratamento de erros
- [ ] Adicionar autenticação
- [ ] Adicionar LINQ para buscas e filtros
- [ ] Implementar eventos de estoque baixo com Delegates & Events
- [ ] Adicionar operações assíncronas com Async/Await

---

# 📄 Licença

Este projeto está sob a licença **MIT**.  
Veja o arquivo [LICENSE](LICENSE) para mais detalhes.