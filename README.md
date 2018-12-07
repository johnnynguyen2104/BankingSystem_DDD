
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

## How Far That I've Gotten ?

I completed the test's requirements.

## Technologies

ASP.Net Core, Entity Framework Core, FluentValidations, MediatR, Nunit, NBuilder, Shouldly, Sql Server. 

## How to build code

1. Open project with Visual Studio 2015(install .NET) or 2017z.

2. After the project are openned, you will see the project details on the Solution Explorer, then right-click on the solution the choose Build to build and restore necessary package.

3. If the solution was built successfuly, the project now ready to run but before running project you should check you connectionString on the webconfig.config file on the BankingSystem project is correct or not, if not, change it then open Package Manager Console, choose Default project to "BankingSystem.DAL" and set the BankingSystem project as default then type 'Update-Database' command to create database and Seed data.

4. Now, the project ready to run. All you should do is deploy the web project to the server or running it on your local machine.

## What is concurrency problem ?

The concurrency problem happend when a data are modified from 2 differences source and it cause the missing and update wrong data information.

### Solution

I used EF6 for this project. Firstly, I create a RowVersion(TimeStamp type) for the table that I need to handle Concurrency problem. Then, everytime I update a data, EF will automatically add an condition to our update query for comparing the RowVersion in db is same as the version in source data.

You can read this <a href="http://www.entityframeworktutorial.net/EntityFramework5/handle-concurrency-in-entity-framework.aspx">Link</a> for more information.

### Testing

After you finish the Build step above, you can run BankingSystem.Tests project to see the test results and make sure you install all the tools for Nunit Runner 3.

The purpose of all my Unit test are to prove my logic is corrected and this is a way to document my code, etc...

The way I wrote those test cases are Exception cases => Functional cases => Successful cases.

### Biggest Challenges

My biggest challenges in this assignment is handling different currencies and make it work corrtecly by creating Unit Test. 

### Improvements
There are many improvement for this project following below:

+ Creating more unit test for this project such as Presentation Layer, DAL, Service Layer.

+ Creating more log so I can easier to trace problems.

+ Creating concurrency test + performance test.

Thanks for reading this.;)


