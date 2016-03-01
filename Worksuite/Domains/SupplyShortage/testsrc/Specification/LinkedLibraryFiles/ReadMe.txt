This folder simply serves as a holder for Linked In Files from the Specification Library.

The reason why we are doing this is because the test runner ignores common test methods that are defined in a different assembly.

So to get the 'common' tests in our library to be ran, we'll have to copy the code, but then we will have duplicated code starting to build up.

So our best shot is to keep the code common in the library, but link them into any specific test projects we need to re-use it.