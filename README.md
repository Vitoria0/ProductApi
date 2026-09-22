# ProductApi

API REST de estudo e como base inicial para projetos .NET, com CRUD de produtos e arquitetura em camadas inspirada em DDD.

## Objetivo

Este projeto foi desenvolvido como uma base prática para estudos de .NET e como ponto de partida para futuros projetos. A solução mantém um escopo pequeno, mas organiza responsabilidades e dependências de forma que possa evoluir com o crescimento da aplicação.

## Arquitetura

A solução é dividida em quatro projetos:

```text
API
↓
Application
↓
Domain
↑
Infrastructure
```

- **API**: expõe os endpoints HTTP, recebe as requisições e retorna as respostas da aplicação.
- **Application**: concentra os casos de uso, serviços, DTOs e contratos necessários para orquestrar as operações.
- **Domain**: contém as entidades e as regras centrais do negócio, sem depender de banco de dados ou frameworks de infraestrutura.
- **Infrastructure**: implementa a persistência, o contexto do Entity Framework Core, os repositórios e as migrations.

## Decisões arquiteturais

A separação em camadas mantém cada responsabilidade no lugar adequado e facilita a evolução da solução. O domínio permanece independente da infraestrutura, evitando que as regras de negócio dependam de banco de dados ou frameworks específicos.

A camada **Application** organiza os casos de uso, enquanto a **Infrastructure** concentra detalhes técnicos de persistência. A **API** fica responsável apenas pela comunicação HTTP e pelo encaminhamento das operações para a aplicação.

Interfaces e Dependency Injection reduzem o acoplamento entre as camadas e facilitam a substituição de implementações. O Repository Pattern separa os casos de uso dos detalhes de acesso a dados. O Entity Framework Core fornece o mapeamento entre as entidades e o SQL Server, além do controle das migrations.

No ambiente de desenvolvimento, o SQL Server pode ser executado via Docker. Essa abordagem facilita a criação de um banco local reproduzível sem exigir uma instalação permanente do SQL Server na máquina.

## Tecnologias

- .NET 10
- ASP.NET Core Web API
- C#
- SQL Server
- Docker
- Entity Framework Core
- OpenAPI / Swagger
- Dependency Injection
- Repository Pattern
- Entity Framework Migrations

## Funcionalidades

- CRUD de produtos
- Persistência no SQL Server
- API REST
- Documentação OpenAPI/Swagger em ambiente de desenvolvimento
- Migrations do Entity Framework Core
- Execução do SQL Server via Docker no ambiente de desenvolvimento

## Estrutura da solução

```text
ProductApi
├── ProductApi.Api             # Camada HTTP e configuração da aplicação
├── ProductApi.Application     # Casos de uso, serviços, DTOs e interfaces
├── ProductApi.Domain          # Entidades e regras de negócio
└── ProductApi.Infrastructure  # Persistência, repositórios e migrations
```

## Propósito

A solução foi intencionalmente mantida simples para servir como uma base reutilizável e evolutiva. Ela oferece uma estrutura inicial clara para experimentar recursos do ecossistema .NET e adicionar novos casos de uso sem perder a separação entre negócio, aplicação, comunicação e infraestrutura.
