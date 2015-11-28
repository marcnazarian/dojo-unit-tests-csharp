# dojo-unit-tests-csharp
Dojo to introduce unit tests in C# with NUnit and Moq


## What is it?

This small project aims to discover unit tests in C# with NUnit and Moq.


1) git clone the project

2) Open the solution in Visual Studio


The latest version of Part 1 is step9: 2 classes, 1 test class, 100% covered.


The latest version of Part 2 is step13: 4 classes, 1 test class. ShoppingItem is 100% covered, we should now test class InventoryService.


You can run the tests.


You can also checkout the different steps to run the dojo from beginning:


## Details

### Part 1: Introduction to unit tests [Detailed steps of part 1](README_Part1.md)

In this introduction, we will learn step by step how to write unit tests (test after).

The project contains only 2 classes: ShoppingBasket and ShoppingItem.

![The (simple) project to test](https://github.com/marcnazarian/dojo-unit-tests-csharp/blob/master/unit_tests_part_1.png "The project to test")

ShoppingItem is a very simple class with 4 properties.

ShoppingBasket contains some methods to get the number of items in the basket, to add an item into the basket, etc.

We will add unit tests step by step to cover this class.

### Part 2: Introduction to mocks with moq [Detailed steps of part 2](README_Part2.md)

In order to introduce the concept of mocks (test double), we add a feature in our simple application: the basket will now ask to a InventoryService if the item is available or not before adding the item into the basket.

![The project now access a database](https://github.com/marcnazarian/dojo-unit-tests-csharp/blob/master/unit_tests_part_2_1.png "The project now access a database")

This InventoryService will access a database (not implemented for the example) so that the unit tests written into Part 1 are failing. Then We realize that it becomes very hard to test. We then introduce the concept of mock (with Moq).

![Use of mocks to isolate the SUT from database access](https://github.com/marcnazarian/dojo-unit-tests-csharp/blob/master/unit_tests_part_2_2.png "Use of mocks to isolate the SUT from database access")

We make the tests passed, and add some more feature that again access the database, and test them.
