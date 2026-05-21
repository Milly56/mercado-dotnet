# 🛒 mercado-dotnet

Sistema de supermercado fictício desenvolvido em C# para praticar orientação a objetos, herança, enums e boas práticas de arquitetura. O projeto simula cadastro de produtos, clientes, funcionários e pedidos, separando responsabilidades em Models e Services.

---

## 🚀 Tecnologias

- **C#** — linguagem principal
- **.NET 10** — plataforma de desenvolvimento
- **Entity Framework Core** — ORM para acesso ao banco de dados
- **SQL Server 2022** — banco de dados relacional
- **Docker & Docker Compose** — containerização da aplicação e banco

---

## 📁 Estrutura do Projeto

```
mercado-dotnet/
├── Controllers/         # Recebe e responde requisições HTTP
├── Data/                # Contexto do banco de dados (Entity Framework)
│   └── AppDbContext.cs
├── Enums/               # Enumerações da aplicação
│   ├── Categoria.cs
│   └── StatusPedido.cs
├── Interfaces/          # Contratos para Services e Repositories
├── Middlewares/         # Interceptadores de requisição (ex: autenticação, erros)
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

## 🧱 Models

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

## 📌 Enums

| Enum | Valores |
|---|---|
| `Categoria` | Hortifruti, Laticinios, Bebidas, Padaria, Carnes, Limpeza, Higiene |
| `StatusPedido` | Aberto, Finalizado, Cancelado |

---

## 📚 Conceitos praticados

- Orientação a Objetos (POO)
- Herança e Encapsulamento
- Propriedades automáticas e calculadas
- Enums
- Data Annotations (`[EmailAddress]`, `[Required]`)
- Entity Framework Core com Migrations
- Separação de responsabilidades (Models, Services, Repositories)
- Containerização com Docker

---

## ▶️ Como rodar

### Com Docker (recomendado)

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/mercado-dotnet.git

# Entre na pasta
cd mercado-dotnet

# Configure as variáveis de ambiente
cp .env.example .env

# Suba os containers
docker-compose up --build -d
```

### Sem Docker

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/mercado-dotnet.git

# Entre na pasta
cd mercado-dotnet

# Configure a connection string no appsettings.Development.json

# Rode as migrations
dotnet ef database update

# Rode o projeto
dotnet run
```

---

## 🔐 Variáveis de Ambiente

Crie um arquivo `.env` na raiz baseado no `.env.example`:

```env
SA_PASSWORD=suasenha
DB_CONNECTION=Server=sqlserver;Database=Supermercado;User Id=sa;Password=suasenha;TrustServerCertificate=True;
```

> ⚠️ Nunca suba o `.env` para o repositório!

---

## 🗺️ Próximos passos

- [x] Criar Models e Enums
- [x] Configurar Entity Framework Core e DbContext
- [x] Configurar Docker e docker-compose
- [ ] Criar Interfaces para Services e Repositories
- [ ] Implementar Repositories (acesso a dados)
- [ ] Implementar Services (regras de negócio)
- [ ] Implementar Controllers (endpoints REST)
- [ ] Adicionar Middlewares (tratamento de erros, autenticação)
- [ ] Adicionar LINQ para buscas e filtros
- [ ] Implementar eventos de estoque baixo com Delegates & Events
- [ ] Adicionar operações assíncronas com Async/Await

---

> Projeto desenvolvido para fins de aprendizado de C# e .NET.