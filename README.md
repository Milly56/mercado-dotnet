# 🛒 mercado-dotnet

Sistema de supermercado fictício desenvolvido em C# para praticar orientação a objetos, herança, enums e boas práticas de arquitetura. O projeto simula cadastro de produtos, clientes, funcionários e pedidos, separando responsabilidades em Models e Services.

---

## 🚀 Tecnologias

- **C#** — linguagem principal
- **.NET** — plataforma de desenvolvimento

---

## 📁 Estrutura do Projeto

```
mercado-dotnet/
├── Controllers/         # Recebe e responde requisições HTTP
├── Data/                # Contexto do banco de dados (Entity Framework)
├── Enums/               # Enumerações da aplicação
│   ├── Categoria.cs
│   └── StatusPedido.cs
├── Interfaces/          # Contratos para Services e Repositories
├── Middlewares/         # Interceptadores de requisição (ex: autenticação, erros)
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
- Separação de responsabilidades (Models, Services, Repositories)

---

## ▶️ Como rodar

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/mercado-dotnet.git

# Entre na pasta
cd mercado-dotnet

# Rode o projeto
dotnet run
```

---

## 🗺️ Próximos passos

- [x] Criar Models e Enums
- [ ] Criar Interfaces para Services e Repositories
- [ ] Implementar Services (regras de negócio)
- [ ] Implementar Repositories (acesso a dados)
- [ ] Configurar Data (Entity Framework / DbContext)
- [ ] Implementar Controllers (endpoints REST)
- [ ] Adicionar Middlewares (tratamento de erros, autenticação)
- [ ] Adicionar LINQ para buscas e filtros
- [ ] Implementar eventos de estoque baixo com Delegates & Events
- [ ] Adicionar operações assíncronas com Async/Await
- [ ] Configurar Dockerfile e docker-compose

---

> Projeto desenvolvido para fins de aprendizado de C# e .NET.
