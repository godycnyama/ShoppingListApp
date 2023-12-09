# ShoppingListApp

## Overview

This project is a Roulette Game API based on .Net 7. It was designed following Clean Architecture principles. It consists of 5 projects namely Roulette.API, Roulette.Application, Roulette.Infrastructure, Roulette.Domain and Roulette.UnitTests.
A number of designs patterns were used during the implemantation of the solution. The CQRS and Mediator patterns were used to implement the API and business logic in the Roulette.API and Roulette.Application projects. The MediatR library was utilised to implement these two patterns. In the infrastructure layer (Roulette.Infrastructure), the unit of work and repository patterns were utilised to interact with the database while utilising Entity Framework Core. SQLite was used as the database, and the database file, roulette.db is located in the Roulette.API project. SOLID principles and clean code principles were used throughout the solution code base. Using MediatR library helped a lot in in writing loosely coupled, easily testable, clean code. MSTest was utilised as the test framework.

## Table of Contents

- [Features](#features)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Endpoints](#endpoints)

## Features

- Create shopping lists.
- Update shopping lists.
- Add and update and delete shopping list items.
- Delete shopping lists.
- Add photos to shopping list items. 

## Getting Started

Follow these steps to get started with the Shopping List API:

1. **Prerequisites:**
   - [Visual Studio](https://visualstudio.microsoft.com/) installed on your system.
   - [.NET Core SDK 8](https://dotnet.microsoft.com/download/dotnet) for building and running the project.

2. **Clone the repository:**
   ```bash
   git clone https://github.com/godycnyama/ShoppingListApp.git
   ```

3. **Open the project:**
   - Open the solution file `ShoppingListApp.sln` in Visual Studio.

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

The Shopping List API follows RESTful principles and can be used by sending HTTP requests to its endpoints. You can interact with the API using your favorite HTTP client e.g Postman

## Endpoints

The API provides the following endpoints:

- `POST /api/v1/shoppinglists`: Create a new shopping list.
- `PUT /api/v1/shoppinglists`: Update shopping list.
- `GET /api/v1/shoppinglists`: Get all shopping lists.
- `GET /api/v1/shoppinglists/{id}`: Get shopping list by id.
- `DELETE /api/v1/shoppinglists/{id}`: Delete shopping list by id.
- `POST /api/v1/shoppinglists/{shoppingListID}/items`: Add a shopping item to a shopping list.
- `PUT /api/v1/shoppinglists/{shoppingListID}/items`: Update item in shopping list.
- `DELETE /api/v1/shoppinglists/{shoppingListID}/items/{id}`: Delete item from shopping list.
- `POST /api/v1/shoppinglists/{shoppingListID}/items/{id}/photo`: Add photo to shopping list item.
- `GET /api/v1/shoppinglists/{shoppingListID}/items/{id}/photo/{fileName}`: Get shopping list item photo.
