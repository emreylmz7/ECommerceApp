# Ollie Shop - E-Commerce Application

**Ollie Shop** is a modern e-commerce platform built using **ASP.NET Core Web API**. This application enables users to easily list products, shop, and manage their orders. It also provides a robust authentication and authorization system, ensuring a secure shopping experience. The project is powered by microservices architecture and integrates a wide range of modern technologies.

![FireShot Capture 027 - OllieShop - Cheap and Quality - localhost](https://github.com/user-attachments/assets/77f20b8b-6ba8-41f6-9425-85be0c686ca5)

## Ollie Shop Project Overview

### Key Features
- **User-Friendly Interface**: Easily list products, make purchases, and manage shopping carts.
- **Admin Dashboard**: Comprehensive management interface for administrators to oversee user accounts, product listings, and orders.
- **User Dashboard**: Personalized interface for users to manage their profiles, view order history, and track current orders.
- **Real-Time Updates**: **SignalR** enables real-time notifications and updates between the server and clients.
- **Secure Authentication**: **JWT** ensures secure user login and role-based access control.
- **Data Integrity**: **Fluent Validation** ensures the accuracy and integrity of data.
- **Efficient Data Handling**: **DTO** and **AutoMapper** are used to optimize data transfer and object mapping.

### Implemented Design Patterns
- **Onion Architecture**: Code is organized into layers to improve scalability, maintainability, and testability.
- **CQRS (Command Query Responsibility Segregation)**: Separates read and write operations to enhance performance and scalability.
- **Mediator Design Pattern**: Promotes loose coupling by centralizing communication between components.
- **Repository Pattern**: Abstracts data access, separating business logic from data access code, improving testability and flexibility.

### Utilized Technologies
- **JWT (Json Web Token)**: Used for secure authentication and authorization.
- **SignalR**: Provides real-time communication and notifications.
- **DTO (Data Transfer Object)**: Optimizes data transfer and improves performance.
- **Fluent Validation**: Defines validation rules to ensure data integrity.
- **Identity Server**: Manages user authentication, authorization, and account management.
- **AutoMapper**: Simplifies object-to-object mapping for better maintainability.
- **Redis, MongoDB, PostgreSQL**: Integrated for caching and data storage.
- **Docker**: Ensures the application is containerized, making it scalable and portable.
- **Ocelot API Gateway**: Manages microservices through a centralized API Gateway.

### Project Features

- **Microservices Architecture**: Each functional feature (product management, order management, user management, etc.) is developed as an independent microservice.
- **API Gateway (Ocelot)**: Centralized management of microservices through a single gateway.
- **Role-Based Authorization**: Different authorization levels for admin, users, and guests.
- **E-Commerce Scenario**: A full-featured e-commerce platform that includes product management, shopping cart, and order processes.
- **Admin and User Dashboards**: Dedicated dashboards for both admins and users to manage their respective functionalities and data.

### Screenshots
Check out the following screenshots of the project:

![FireShot Capture 028 - OllieShop - Cheap and Quality - localhost](https://github.com/user-attachments/assets/456e9753-c216-457a-8db0-34bc31aa6f03)
![FireShot Capture 032 - OllieShop - Cheap and Quality - localhost](https://github.com/user-attachments/assets/2c2cbf29-1060-4e91-b588-d6efb55ce680)
![FireShot Capture 031 - OllieShop - Cheap and Quality - localhost](https://github.com/user-attachments/assets/e3b7e39a-0a90-434c-864b-a431c6fe3830)
![FireShot Capture 030 - OllieShop - Cheap and Quality - localhost](https://github.com/user-attachments/assets/f1e6c916-bf6d-4e97-b2d5-7d3cecfdb329)
![FireShot Capture 029 -  - localhost](https://github.com/user-attachments/assets/a44caa8c-d935-4235-a208-8bec4fe738c3)
![FireShot Capture 043 - Ollie Admin Dashboard - localhost](https://github.com/user-attachments/assets/e8855c64-a4cb-4ced-a35f-444616861ecd)
![FireShot Capture 042 - Ollie Admin Dashboard - localhost](https://github.com/user-attachments/assets/634f9c83-f9c7-48f0-be7d-e96b4587768e)
![FireShot Capture 041 - OllieShop - Cheap and Quality - localhost](https://github.com/user-attachments/assets/f05209a8-f73e-4498-b9f6-a1eeb18789d6)
![FireShot Capture 040 - OllieShop - Cheap and Quality - localhost](https://github.com/user-attachments/assets/6442efa1-32c2-46c3-bf67-3c267df652e9)
![FireShot Capture 039 - Vertical Navbar - Mazer Admin Dashboard - localhost](https://github.com/user-attachments/assets/740bdf88-dab0-4e52-a891-bcc8f7c79acc)
![FireShot Capture 038 - Vertical Navbar - Mazer Admin Dashboard - localhost](https://github.com/user-attachments/assets/678c68b0-3ade-46c3-a136-82a305d70448)
![FireShot Capture 037 - Vertical Navbar - Mazer Admin Dashboard - localhost](https://github.com/user-attachments/assets/bdc33bf1-968b-4c8d-9758-1ca2337e8c88)
![FireShot Capture 036 - Vertical Navbar - Mazer Admin Dashboard - localhost](https://github.com/user-attachments/assets/a0748549-3d0a-42b1-a2fa-809054c4df43)
![FireShot Capture 035 - Ollie Admin Dashboard - localhost](https://github.com/user-attachments/assets/eb468417-8ab1-44fe-959e-d2152232485f)
![FireShot Capture 034 - Ollie Admin Dashboard - localhost](https://github.com/user-attachments/assets/0154bbe2-5890-4110-a56a-c7b573a579f5)
![FireShot Capture 033 - Ollie Admin Dashboard - localhost](https://github.com/user-attachments/assets/7473549d-29a9-4d5b-9750-52b4c93a47ad)



### Setup and Installation

Follow these steps to run the project locally:

#### Requirements
- .NET 6.0 SDK
- Docker
- PostgreSQL and MongoDB
- Redis


