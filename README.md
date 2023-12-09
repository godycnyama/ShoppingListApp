# ShoppingListApp
# Roulette Game API

## Overview

This project is a Roulette Game API based on .Net 7. It was designed following Clean Architecture principles. It consists of 5 projects namely Roulette.API, Roulette.Application, Roulette.Infrastructure, Roulette.Domain and Roulette.UnitTests.
A number of designs patterns were used during the implemantation of the solution. The CQRS and Mediator patterns were used to implement the API and business logic in the Roulette.API and Roulette.Application projects. The MediatR library was utilised to implement these two patterns. In the infrastructure layer (Roulette.Infrastructure), the unit of work and repository patterns were utilised to interact with the database while utilising Entity Framework Core. SQLite was used as the database, and the database file, roulette.db is located in the Roulette.API project. SOLID principles and clean code principles were used throughout the solution code base. Using MediatR library helped a lot in in writing loosely coupled, easily testable, clean code. MSTest was utilised as the test framework.

## Table of Contents

- [Features](#features)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Endpoints](#endpoints)

## Features

- Manage roulette game sessions.
- Manage bets placement.
- Manage roulette wheel spins and record the winning numbers.
- Manage accounts for players.
- Manage payouts. 

## Getting Started

Follow these steps to get started with the Roulette Game API:

1. **Prerequisites:**
   - [Visual Studio](https://visualstudio.microsoft.com/) installed on your system.
   - [.NET Core SDK 7](https://dotnet.microsoft.com/download/dotnet) for building and running the project.

2. **Clone the repository:**
   ```bash
   git clone https://github.com/godycnyama/DRVCAssessment.git
   ```

3. **Open the project:**
   - Open the solution file `RouletteGame.sln` in Visual Studio.

4. **Build the project:**
   - Build the solution to restore dependencies and compile the code.

5. **Run database migrations:**
   - Select Roulette.Infrastructure as your default project for migrations in Visual Studio Package Manager Console. At the same time making sure you have selected Roulette.API as your 
      startup project in Visual Studio.
     In Visual Studio Package Manager Console run the following command to create your initial migration.   
      ```bash
     add-migration rouletteDBMigration1
     ```
      To apply the migration you have created, run the following command in Visual Studio Package Manager Console.
     ```bash
     update-database
     ```

6. **Run the application:**
   - Start the application within Visual Studio by first selecting Roulette.API as your startup project or use the command  line with the following command:
     ```bash
     dotnet run
     ```

7. **Access the API:**
   - The API will be available at `https://localhost:7010` or `http://localhost:5105`.

8. **Access the API Swagger Documentation:**
   - The API Swagger documentation will be available at `https://localhost:7010/swagger/index.html`.

9. **Run unit tests:**
   - Run the unit tests within Visual Studio or use the command line with the following command:
     ```bash
     dotnet test
     ```

## Usage

The Roulette Game API follows RESTful principles and can be used by sending HTTP requests to its endpoints. You can interact with the API using your favorite HTTP client e.g Postman

## Endpoints

The API provides the following endpoints:

- `POST /roulette/api/accounts`: Create a new player account.
- `PUT /roulette/api/accounts`: Update player account.
- `GET /roulette/api/accounts`: Get player accounts.
- `GET /roulette/api/accounts/{id}`: Get player account by id.
- `DELETE /roulette/api/accounts/{id}`: Delete player account by id.
- `POST /roulette/api/sessions`: Create a new session.
- `PUT /roulette/api/sessions`: Update session.
- `GET /roulette/api/sessions`: Get sessions.
- `GET /roulette/api/sessions/{id}`: Get session by id.
- `DELETE /roulette/api/sessions/{id}`: Delete session by id.
- `POST /roulette/api/bets`: Create a new bet.
- `PUT /roulette/api/bets`: Update bet.
- `GET /roulette/api/bets`: Get bets.
- `GET /roulette/api/bets/{id}`: Get bet by id.
- `DELETE /roulette/api/bets/{id}`: Delete bet by id.
- `POST /roulette/api/spins`: Create a new spin.
- `PUT /roulette/api/spins`: Update spin.
- `GET /roulette/api/spins`: Get spins.
- `GET /roulette/api/spins/{id}`: Get spin by id.
- `DELETE /roulette/api/spins/{id}`: Delete spin by id.
- `POST /roulette/api/payouts`: Create a new payout.
- `PUT /roulette/api/payouts`: Update payout.
- `GET /roulette/api/payouts`: Get payouts.
- `GET /roulette/api/payouts/{id}`: Get payout by id.
- `DELETE /roulette/api/payouts/{id}`: Delete payout by id.
