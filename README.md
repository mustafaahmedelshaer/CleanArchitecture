Overview
The master branch is now using .NET 6. If you need a previous version use one of these tagged commits:
This is a solution template for creating a Single Page App (SPA) with Angular and ASP.NET Core following the principles of Clean Architecture. Create a new project based on this template by clicking the above Use this template button or by installing and running the associated NuGet package (see Getting Started for full details).



In Clean architecture, the Domain and Application layers remain at the center of the design which is known as the Core of the system.

![pic2-1](https://github.com/mustafaahmedelshaer/CleanArchitecture/assets/74098034/65643e4e-273b-4daf-8b6c-af806966c44d)


The domain layer contains enterprise logic and the Application layer contains business logic. Enterprise logic can be shared across many systems but the business logic will typically only be used within the system. The core will be independent of data access and other infrastructure concerns. And we can achieve this using interfaces and abstraction within the Core and implement them by other layers outside of the Core.

In Clean Architecture all dependencies flow inwards and Core has no dependency on any other layer. And Infrastructure and Presentation layer depends on Core.  

Benefits of Clean Architecture
Independent of Database and Frameworks.
Independent of the presentation layer. Anytime we can change the UI without changing the rest of the system and business logic.
Highly testable, especially the core domain model and its business rules are extremely testable.


