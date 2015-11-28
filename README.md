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

### Part 1: [Introduction to unit tests](README_Part1.md)

**Step 0**: initial project, only code, no tests.

`git checkout step0`

**Step 1**: first (dummy) test. The test is red :)

`git checkout step1`

**Step 2**: make the dummy test passed!

`git checkout step2`

**Step 3**: Add 2 tests (basket is empty after initialization)

`git checkout step3`

**Step 4**: Add 1 test (add item into basket)

`git checkout step4`

**Step 5**: Refactored test (add SetUp)

`git checkout step5`

**Step 6**: Add 1 test (add several items into basket)

`git checkout step6`

**Step 7**: Add 2 tests (test get total price of basket)

`git checkout step7`

**Step 8**: Add 1 test (test description of the basket)

`git checkout step8`

**Step 9**: Latest changes.

`git checkout step9`


### Part 2: [Introduction to mocks with moq](README_Part2.md)

**Step 10**: Introduced access to database. Unit tests fail.

`git checkout step10`

**Step 11**: Make the unit tests passed (adding an interface, using dependency injection and using Mocks)

`git checkout step11`

**Step 12**: Add 2 units (to test when item is not available)

`git checkout step12`

**Step 13**: Add feature: remove the item from inventory when adding item to shopping cart. Update tests to verify that.

`git checkout step13`
