# System Design Document

---

## **Architecture**

The system will be developed using the **MVC (Model–View–Controller)** architectural pattern for clear separation of concerns.  
Additionally, it will follow **Clean Architecture** to ensure maintainability, scalability, and testability.

### **Layers**

#### **UI Layer**
- **Controllers**  
  Handle HTTP requests, interact with the service layer, and return responses (Views or JSON for APIs).
- **Views**  
  Razor views to render HTML pages.
- **ViewModels**  
  Objects specifically designed to pass structured data between Controllers and Views.

#### **Core Layer**
- **Domain**
  - **Entities**: Core business models (e.g., `Post`, `Comment`, `User`, etc.).
  - **RepositoryContracts**: Interfaces that define data access operations without implementation details.
- **Services**
  - **Business Logic Implementation**: Contains rules and workflows independent of frameworks.
  - **ServiceContracts**: Interfaces for the service layer, ensuring abstraction and testability.

#### **Infrastructure Layer**
- **Data**
  - **DbContext**: EF Core DbContext managing entity sets and database interactions.
- **Repositories**
  - Concrete implementations of repository contracts for data persistence using EF Core.
# System Design Document

---

## **Architecture**

The system will be developed using the **MVC (Model–View–Controller)** architectural pattern for clear separation of concerns.  
Additionally, it will follow **Clean Architecture principles** to ensure maintainability, scalability, and testability.

### **Layers**

#### **UI Layer**
- **Controllers**  
  Handle HTTP requests, interact with the service layer, and return responses (Views or JSON for APIs).
- **Views**  
  Razor views to render HTML pages.
- **ViewModels**  
  Objects specifically designed to pass structured data between Controllers and Views.

#### **Core Layer**
- **Domain**
  - **Entities**: Core business models (e.g., `Post`, `Comment`, `User`, etc.).
  - **RepositoryContracts**: Interfaces that define data access operations without implementation details.
- **Services**
  - **Business Logic Implementation**: Contains rules and workflows independent of frameworks.
  - **ServiceContracts**: Interfaces for the service layer, ensuring abstraction and testability.

#### **Infrastructure Layer**
- **Data**
  - **DbContext**: EF Core DbContext managing entity sets and database interactions.
- **Repositories**
  - Concrete implementations of repository contracts for data persistence using EF Core.

---

## **Storage**

- **Relational Database: SQL Server**  
  Reason:  
  - Well-suited for structured schema-based entities.  
  - Supports complex relationships, constraints, and indexing.  
  - Native integration with Entity Framework Core.

---

## **Tools & Packages**

- **Entity Framework Core (ORM)**  
  Benefits:  
  - Query database using LINQ (C# syntax).  
  - Automatic object–relational mapping.  
  - Schema evolution and versioning with EF Core migrations.  

- **ASP.NET Core Identity**  
  - Manages users, roles, claims, login, registration, and password hashing.  
  - Provides extensibility for adding custom user fields.  

- **Authentication**  
  - **Phase 1**: Cookie-based authentication (default with Identity).  
  - **Phase 2**: Add support for JWT Bearer tokens and OAuth 2.0 for API scenarios and third-party integrations.  

- **xUnit**  
  - Testing framework for unit and integration tests.  
  - Ensures reliability and correctness of core business logic.  

---

## **Database Schema**

### **Posts (Resource)**
- `PostId` (PK)  
- `Title`  
- `URL` (resource link)  
- `Description` (optional)  
- `UserId` (FK → User)  
- `CreatedAt` (datetime)

---

### **Comments**
- `CommentId` (PK)  
- `Text`  
- `PostId` (FK → Post)  
- `UserId` (FK → User)  
- `ParentCommentId` (nullable, self-FK for threaded replies)  
- `CreatedAt` (datetime)

---

### **Votes**
- `UserId` (FK → User)  
- `PostId` (FK → Post)  
- `CreatedAt` (datetime)  
*(Composite PK: `UserId`, `PostId` → ensures a user can only vote once per post)*

---

### **Tags**
- `TagId` (PK)  
- `Name`

---

### **PostTags**
- `PostId` (FK → Post)  
- `TagId` (FK → Tag)  
*(Composite PK: `PostId`, `TagId`)*

---

### **Notifications**
- `NotificationId` (PK)  
- `UserId` (FK → User) → receiver of the notification  
- `Message` (e.g., *"UserX commented on your post"*)  
- `PostId` (nullable FK → Post)  
- `CommentId` (nullable FK → Comment)  
- `IsRead` (boolean, default = false)  
- `CreatedAt` (datetime)

---

## **Controllers & Route Design**

### **AccountController**
Handles authentication, authorization, and account profile management.

**Routes**
- `GET  /account/login` → Show login page  
- `POST /account/login` → Submit login credentials  
- `GET  /account/register` → Show registration page  
- `POST /account/register` → Register a new user  
- `GET  /account/logout` → Logout current user  
- `GET  /account/profile` → Show user profile  
- `GET  /account/settings` → Show account settings page  
- `POST /account/settings` → Update account details (e.g., username, email)  
- `GET  /account/reset-password` → Show reset password form  
- `POST /account/confirm-new-password` → Submit new password  

*password & OAuth login will be added in **Phase 2***  

---

### **PostController**
Handles CRUD operations for posts and feed management.

**Routes**
- `GET  /post/feed` → Get posts feed (AJAX-based)  
- `GET  /notifications` → Get notifications for logged-in user  
- `POST /notifications/{id}` → Mark notification as read  
- `GET  /post/create` → Show create post form (authorized users only)  
- `POST /post/create` → Create a new post  
- `GET  /post/edit/{id}` → Show edit form for post  
- `POST /post/edit/{id}` → Update post  
- `POST /post/delete/{id}` → Delete post  
- `GET  /post/{id}` → View specific post (also from notifications)  

---

### **CommentController**
Handles CRUD operations for comments.

**Routes**
- `POST /comment/create` → Add a new comment (authorized users only)  
- `POST /comment/edit/{id}` → Edit existing comment  
- `POST /comment/delete/{id}` → Delete comment  

---

### **AdminController**
Admin-only actions for content and user management.

**Routes**
- `GET /admin/dashboard` → Admin overview dashboard  
- `GET /admin/post-management` → Manage posts (approve/reject/remove)  
- `GET /admin/user-management` → Manage user accounts (roles, bans, etc.)  

---

## **Storage**

- **Relational Database: SQL Server**  
  Reason:  
  - Well-suited for structured schema-based entities.  
  - Supports complex relationships, constraints, and indexing.  
  - Native integration with Entity Framework Core.

---

## **Tools & Packages**

- **Entity Framework Core (ORM)**  
  Benefits:  
  - Query database using LINQ (C# syntax).  
  - Automatic object–relational mapping.  
  - Schema evolution and versioning with EF Core migrations.  

- **ASP.NET Core Identity**  
  - Manages users, roles, claims, login, registration, and password hashing.  
  - Provides extensibility for adding custom user fields.  

- **Authentication**  
  - **Phase 1**: Cookie-based authentication (default with Identity).  
  - **Phase 2**: Add support for JWT Bearer tokens and OAuth 2.0 for API scenarios and third-party integrations.  

- **xUnit**  
  - Testing framework for unit and integration tests.  
  - Ensures reliability and correctness of core business logic.  

---

## **Database Schema**

### **Posts (Resource)**
- `PostId` (PK)  
- `Title`  
- `URL` (resource link)  
- `Description` (optional)  
- `UserId` (FK → User)  
- `CreatedAt` (datetime)

---

### **Comments**
- `CommentId` (PK)  
- `Text`  
- `PostId` (FK → Post)  
- `UserId` (FK → User)  
- `ParentCommentId` (nullable, self-FK for threaded replies)  
- `CreatedAt` (datetime)

---

### **Votes**
- `UserId` (FK → User)  
- `PostId` (FK → Post)  
- `CreatedAt` (datetime)  
*(Composite PK: `UserId`, `PostId` → ensures a user can only vote once per post)*

---

### **Tags**
- `TagId` (PK)  
- `Name`

---

### **PostTags**
- `PostId` (FK → Post)  
- `TagId` (FK → Tag)  
*(Composite PK: `PostId`, `TagId`)*

---

### **Notifications**
- `NotificationId` (PK)  
- `UserId` (FK → User) → receiver of the notification  
- `Message` (e.g., *"UserX commented on your post"*)  
- `PostId` (nullable FK → Post)  
- `CommentId` (nullable FK → Comment)  
- `IsRead` (boolean, default = false)  
- `CreatedAt` (datetime)

---

## **Deployment**

- **Initial Deployment**:  
  - Hosted on **MosterASP** shared hosting for cost-effectiveness.  
- **Future Deployment**:  
  - Migrate to **Microsoft Azure** for scalability, better performance, CI/CD pipelines, monitoring, and integrated services.


