# Clean Architecture in ASP.NET Core (.NET 8)

This project demonstrates how to implement Clean Architecture principles in an ASP.NET Core API using .NET 8. The solution is organized into distinct layers to ensure separation of concerns, testability, and maintainability.

---

## **Detailed Layers in Clean Architecture**

Clean Architecture emphasizes organizing the application into layers, each with specific responsibilities. Here's a detailed explanation of each layer in this solution:

### **1. Domain Layer**
- **Purpose**: Represents the core business logic and rules of the application. It is the most critical layer.
- **Contents**:
  - **Entities**: Core objects of the system (e.g., `User`, `Order`).
  - **Value Objects**: Immutable objects representing concepts (e.g., `Money`, `Email`).
  - **Aggregates**: Groups of entities treated as a single unit (e.g., `Order` with `OrderItems`).
  - **Domain-Specific Exceptions**: Encapsulate domain-related errors.
- **Dependencies**: **None** – The Domain Layer is completely independent of any other layers or frameworks.

---

### **2. Application Layer**
- **Purpose**: Orchestrates the business logic by defining use cases and facilitating communication between the Domain Layer and external layers.
- **Contents**:
  - **Use Cases**: Define application-specific business logic (e.g., `CreateUserCommand`, `GetUserQuery`).
  - **Services**: Contain reusable application logic.
  - **Commands and Queries**: Separate operations into command and query models (CQRS pattern).
  - **DTOs (Data Transfer Objects)**: Define the data shape exchanged between layers.
  - **Interfaces**: Define contracts (e.g., repository interfaces) implemented by the Infrastructure Layer.
- **Dependencies**: References the **Domain Layer**.

---

### **3. Infrastructure Layer**
- **Purpose**: Handles external interactions such as data persistence, third-party services, or system integrations.
- **Contents**:
  - **Data Access**: Implements repository interfaces defined in the Application Layer.
  - **External Services**: Integrates with APIs or libraries (e.g., email sending, payment gateways).
  - **Configurations**: Includes database and other external system configurations.
- **Dependencies**: References both the **Domain Layer** and **Application Layer**.

---

### **4. API Layer**
- **Purpose**: Serves as the entry point for the application, exposing functionality via HTTP endpoints.
- **Contents**:
  - **Controllers**: Handle incoming HTTP requests and send appropriate responses.
  - **Middleware**: Implements cross-cutting concerns (e.g., logging, authentication).
  - **Dependency Injection Configuration**: Configures application services and repositories.
- **Dependencies**: References the **Application Layer**.

---

## **Key Principles in Clean Architecture**

1. **Dependency Rule**: Inner layers do not depend on outer layers. For example:
   - The **Domain Layer** does not depend on the **Application Layer** or **Infrastructure Layer**.
   - The **Application Layer** depends on the **Domain Layer** but not on the **Infrastructure Layer**.

2. **Separation of Concerns**: Each layer is responsible for a specific aspect of the application:
   - Core business logic resides in the **Domain Layer**.
   - Application logic and orchestration reside in the **Application Layer**.
   - External integrations are implemented in the **Infrastructure Layer**.
   - User interactions and API endpoints are managed in the **API Layer**.

3. **Testability**: Each layer can be tested independently because dependencies are explicitly defined and inversion of control (IoC) is used.

4. **Framework Independence**: The core of the application (Domain and Application Layers) does not depend on any specific framework, making it easier to adapt or extend the application in the future.

---
