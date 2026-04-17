# EXTRAVAGANZA – Full-Stack Web App (ASP.NET Core & Angular)

> 🚧 **Work in Progress:** I'm actively developing this project. It's not finished yet, but the core backend architecture is already set up.

This is a full-stack project built with ASP.NET Core (.NET 9) and Angular. My main goal here is to practice and implement **Clean Architecture** alongside scalable design patterns.

## 🏗️ Architecture

The backend is split into three main layers to keep dependencies clean and the codebase maintainable:

```text
 ┌─────────────────────────────────────────────────────────┐
 │                     Frontend (Angular)                  │
 │          (Routing, Components, Material Theme)          │
 └───────────────────────────┬─────────────────────────────┘
                             │ HTTP / REST
 ┌───────────────────────────▼─────────────────────────────┐
 │                      API Layer                          │
 │      (Controllers, DTOs, Exception Middleware)          │
 └───────────────────────────┬─────────────────────────────┘
                             │ Reference
 ┌───────────────────────────▼─────────────────────────────┐
 │             Infrastructure Layer (Data Access)          │
 │ (EF Core, Generic Repository, Database Seeding)         │
 └───────────────────────────┬─────────────────────────────┘
                             │ Implements Interfaces from
 ┌───────────────────────────▼─────────────────────────────┐
 │                      Core Layer                         │
 │ (Entities, Interfaces, Specifications, Business Rules)  │
 └─────────────────────────────────────────────────────────┘
```

## 💻 Tech Stack

- **Backend:** .NET 9 (Web API), Entity Framework Core
- **Patterns:** Clean Architecture, Generic Repository, Specification Pattern
- **Frontend:** Angular, Angular Material
- **Infrastructure:** Docker & Docker Compose

## 🚀 Roadmap

Here is what I've done so far:

**Done:**
- [x] Base Clean Architecture setup (Core, Infrastructure, API).
- [x] Generic Repository and Specification patterns for data access.
- [x] EF Core setup with migrations and initial database seeding.
- [x] Global Exception Handling middleware.
- [x] Pagination and DTO mapping.
- [x] Angular app scaffolding.
