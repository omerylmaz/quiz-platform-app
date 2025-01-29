# Quiz Platform App (Not Finished)

## Overview
The **Quiz Platform App** is a modular monolith web application built using **.NET (C#) for the backend**. The application allows users to create, manage, and participate in quizzes while integrating AI-generated questions.

## Features
- **User Management:**
  - Registration & authentication
  - Role-based access control (RBAC)
  - User achievements & subscriptions
- **Quiz Management:**
  - Create and organize quiz sets
  - AI-generated quiz support
  - Category-based quizzes
- **Subscription System:**
  - Various subscription plans
  - Payment integration for premium access
- **Notifications:**
  - User alerts and updates
  - Read/unread tracking

## Tech Stack
### Backend
- **Framework:** .NET 9 (C#)
- **Database:** PostgreSQL
- **Caching:** Redis
- **Messaging:** MassTransit InMemory
- **Authentication:** KeyCloak, JWT
- **Validation:** FluentValidation
- **CQRS Pattern:** MediatR with Pipelines
- **Logging:** Serilog
- **Architecture:** Clean Architecture with Domain-Driven Design (DDD)

### Deployment & Containerization
- **Docker Compose** for container orchestration
- **PostgreSQL** as the primary database
- **Redis** for caching
- **Seq** for logging visualization

## Database Schema
The application follows **Domain-Driven Design (DDD)** principles, dividing functionalities into multiple contexts:
- **User Management Context**
- **Subscription Management Context**
- **Quiz Management Context**
- **Notification Context**

### ER Diagram
![ER Diagram](https://github.com/user-attachments/assets/826846fa-333b-4b42-b648-a09a9a4fa7c7)

### Bounded Contexts
![Context Diagram](https://github.com/user-attachments/assets/00884e30-c212-42fb-af9c-3051a08f4804)

## Installation & Setup
### Prerequisites
- .NET 9 SDK
- Node.js & npm/yarn (for future frontend integration)
- PostgreSQL Database
- Docker & Docker Compose

## Docker Setup

Start all services except the .NET API:
```sh
docker-compose up -d quizapp.database quizapp.seq quizapp.redis
```
### Backend Setup
```sh
cd backend
# Install dependencies
dotnet restore
# Run database migrations
dotnet ef database update
# Start the backend server
dotnet run
```
