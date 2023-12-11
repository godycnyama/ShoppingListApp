# ShoppingListApp API

## Overview

This project is a ShoppingListApp API based on .Net 7 and minimal api concepts. It was designed following Clean Architecture principles. It consists of 5 projects namely ShoppingListApp.API, ShoppingListApp.Application, ShoppingListApp.Infrastructure, ShoppingListApp.Domain and ShoppingListApp.UnitTests.
Besides Clean Architecture, Vertical slice architecture was used to implemement ShoppingListApp.Application, which is the business logic layer.
A number of designs patterns were used during the implementation of the solution, one of them being the  Mediator pattern used in the business logic layer, ShoppingListApp.Application. The MediatR library was utilised to implement the mediator pattern as well as to implement the vertical slice architecture in ShoppingListApp.Application. In the infrastructure layer (ShoppingListApp.Infrastructure), the unit of work and repository patterns were utilised to interact with the database while utilising Entity Framework Core. SQL Server (running in a Docker container) is used as the database. Furthermore, to serve shopping item images, Minio (running in a Docker containter) is used. SOLID principles and clean code principles are used throughout the solution code base. Using MediatR and Carter libraries helped a lot in in writing loosely coupled, easily testable, clean code. MSTest was utilised as the test framework.
The ShoppingListApp API also runs in a Docker container. Docker compose is used to start all the 3 containers to run the api.

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
   - [.NET Core SDK 7](https://dotnet.microsoft.com/download/dotnet) for building and running the project.

2. **Clone the repository:**
   ```bash
   git clone https://github.com/godycnyama/ShoppingListApp.git
   ```

3. **Open the project:**
   - Open the solution file `ShoppingListApp.sln` in Visual Studio.

4. **Build the project:**
   - Build the solution to restore dependencies and compile the code.
     
5. **Run the application:**
   - Start the application by running the following commands on the command line, after navigating to the root directory
       ```bash
     docker-compose up -d
     ```
    - Alternatively, you may start the app in Visual Studio by choosing Docker Compose.
       
7. **Access the API:**
   - The API will be available at `https://localhost:59078`.This may vary depending on the computer its' running on.

8. **Access the API Swagger Documentation:**
   - The API Swagger documentation will be available at `https://localhost:59078/swagger/index.html`.This may vary depending on the computer its' running on.

9. **Run unit tests:**
   - Run the unit tests within Visual Studio or use the command line with the following command:
     ```bash
     dotnet test
     ```
   - Some of the unit tests are failing. Due to time constraints, l could not debug and fix the failing tests.

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

## Security
- This API is OAuth2.0 secured using Auth0 as the authentication provider. In order for one to test it, one needs to attach a Bearer Token to the authorization header. I can make a manually generated token available for testing purposes.
