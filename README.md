# How to implement global exception handling in .NET Core

## Introduction of Global Exception
We often come up with exceptions in our application and we have two ways in general to handle those exception.

 - Handle at controller/service level everywhere in application

 - Handle from one place and control the application

Those approaches are fine and work well , I would like to talk about second one today

## Pros and Cons of Global Exception
Let’s see pros and cons of this approach

### Pro (s) :
- Code becomes easy to manage because we don’t need to look into n different try-catch blocks , just look from one place and deal them.
- More readable because a few lines of code managing the whole exceptions of application
- Removes repeated code (try-catch everywhere)
- It gives us more control so we can catch exceptions and return response of our own type , in most cases we return Internal Server Error. Additionally it is a good approach to log those exceptions (Check my post on How to add logs via NLog or my friend Milan post on Logging with Serilog in .NET Core)

### Con (s) :
- A global exception handler can make it harder because sometime it will catch the exception at broad level and deal with it accordingly without digging down to exact lower-level exception
- If you are on short time and you need to implement exception handling then global exception handling is the best solution.

## How to Implement it via Middleware

Step 1 : Create Middleware
Step 2 : Register the Middleware as a Service and then use it in Middleware in Program.cs

Refer: https://mwaseemzakir.substack.com/p/ep-12-how-to-implement-global-exception
