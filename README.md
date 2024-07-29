# School Management Project Using Clean Architecture

## Introduction
This project is a full-featured school management system designed with Clean Architecture principles. It is built to be scalable, maintainable, and efficient for managing various school tasks.

## Features

### CQRS Pattern
Separates write and query operations, making the system more scalable and easier to maintain.

### Mediator Pattern
Facilitates communication between classes without direct references, improving code flexibility.

### Fluent Validation
Provides an easy way to set up validations with custom error handling.

### Localization
Supports both Arabic and English languages, with responses tailored to the selected environment.

### Logging with Serilog
Logs errors to the database for easy tracking and debugging.

### Database Techniques
Uses views, stored procedures, and functions for optimized database operations.

### Pagination Schema
Efficiently organizes large responses.

### Confirmation Email System
Sends confirmation emails with account activation links.

### Reset Password System
Encrypts and decrypts reset password codes sent via email.

### Identity Management
Includes functionalities for user and role management.

### Role and Claims Manipulation
Allows modification of user roles and claims for access control.

### JWT Token Authentication
Implements token-based authentication with refresh tokens.

### Routing Schema
Uses organized routing classes for flexibility.

### Readable Response Schema
Provides detailed response structures with status codes, operation status, data, and metadata.

### Dependency Injection
Manages dependencies efficiently.

### SOLID Principles
Follows SOLID principles for robust and maintainable code.

## Project Structure

### Core
Contains core business logic and entities.

### Infrastructure
Handles data access and integration with external services.

### Application
Implements application services and use cases.

### API
Provides API endpoints for interacting with the system.

### Services
Includes various application services.
