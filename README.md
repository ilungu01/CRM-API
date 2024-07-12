In this project I used two design patters:
1.Factory Design Pattern was used to encapsulate the logic for creating an instance of CustomerService, which also included resolving dependencies such as repositories and validators.
2.The Repository Pattern separates the data access logic from the business logic. This separation ensures that the data access code is isolated in repository classes,
making the business logic easier to understand and maintain(and if in the future I want to change from MySQL to NoSQL db it wouldn't require to change the business logic).
