
# Banking System Project

## Introduction

This is a Banking system base CQRS design. This project I focus on some basic functionalities such as Balance, Withdraw, Deposit.

## Objectives

I designed the architecture for this project base on CQRS(Command Query Responsibility Segregation), Repository pattern and few software principals such as SOLID, Seperate of concern. Moreover, this project represent for solving the concurrency problem and adapt some non-functional requirements such as:

1. Maintainability.
2. Readability.
3. Testability.
4. Performance.
5. Scalable

## How Far Did I Get?

I completed the test's requirements.

## Technologies

ASP.Net Core, Entity Framework Core, FluentValidations, MediatR, Nunit, NBuilder, Shouldly, Sql Server. 

## How to build code

  1. Clone the repository (skip this step if you have the project on your machine)
  
  2. Running EF Migration to create a test database, set active WepApi project and run update-database on Package Management Console with Persistent project as th target or you can use the backup file.  
  
  3. At the root directory contains project's solution , restore required packages by running:
     ```
     dotnet restore
     ```
  4. Next, build the solution by running:
     ```
     dotnet build
     ```
  5. Next, within the `BankingSystem\BankingSystem.WebApi` directory, launch the Web API by running:
     ```
     dotnet run
     ```
  6. Once the WebApi has started, within the `BankingSystem\BankingSystem.ClientTest` directory, launch the client console app by running:
     ```
	 dotnet run
	 ```
  7. On the client console app, you can select a option to test.

## What is concurrency problem ?

The concurrency problem happend when a data are modified from 2 differences source and it cause the missing and update wrong data information (Last Win).

### Database Structure & Concurrency Solution

The Database contains three main tables (Account, AccountStatement, Transaction). The Account table have a relationship (one to many) with Statment & Transaction.

The designed idea is we will calculate the current balance base on the accoount's transactions because there is not "Current State" concept in Banking, Finance, Insurrance or Trading, etc... field, if we calculate the current balance eveytime the user do a deposit or withdrawal and store it back to current balance column, that'd be totally wrong because users may have some arguements with our system in the future relate to their balance, we can't just reply on the "CurrentBalance" column.

So if you understand the idea above, you'd think we should calculate current balance from transaction?. That's correct but what's gonna happen if we have too much transactions? surely our system will be slowing down because of the summation, that why we need the AccountStatement. 

The AccountStatement is acted as a Snapshot for the Transaction table, every month (or every week, depend on the volumn of transacions) we will take a snapshot for every account and store it into a new Statement and calculate the ClosingBalance with the fomula below:

```
 (ClosingBalance from last Statement + Deposited Transactions since the last Statement) - Withdrawn Transactions since the last Statement
```
The fomula above also apply for current balance calculation and everytime the user make a deposit or withdrawal, we will update the LastActivity column in the Account table to prevent the concurrency user problem.

### Testing

After you finish the Build step above, you can run BankingSystem.Test project to see the test results and make sure you install all the tools for Nunit Runner 3.

The purpose of all my Unit test are to prove my logic is corrected and this is also a way to document my code & logic, etc...

### Biggest Challenges

- Handling concurrency with stateless bank account.
- Applying CQRS.

### Improvements
There are many improvement for this project following below:

+ Creating more unit test for this project.

+ Implementing a function to create a statement for each account as a snapshot. 

+ Adding more document for all the layers.

+ Completely seperate DbContext out of Application Layer & Api.

+ Implement Authentication.

+ Creating appsetting.json file for some environments (STAG, PROD, etc...). 

### References
* [CQRS](https://martinfowler.com/bliki/CQRS.html)
* [MediatR](https://github.com/jbogard/MediatR)
* [FluentValidation](https://github.com/JeremySkinner/FluentValidation)
 
Thanks for reading this.;)



