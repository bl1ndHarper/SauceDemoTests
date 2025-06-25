# EPAM .Net Automated Testing Task — SauceDemo Login Form

This project is a solution to a practical task involving automated testing of the login form at https://www.saucedemo.com.  
Implemented using C#, Selenium WebDriver, and xUnit.

## Completed Tasks

Mandatory requirements:
- Developed three functional UI tests:
  - UC1: Login with empty credentials
  - UC2: Login with username only
  - UC3: Login with valid credentials
- Applied Page Object Model (POM)
- Used Selenium WebDriver
- Used xUnit test framework
- Added logging of test steps and outcomes

Optional extensions (implemented additionally):
- Parameterized tests for both Chrome and Firefox
- Strategy pattern for browser creation abstraction
- Singleton pattern for WebDriver instance management
- Adapter pattern for pluggable logging (via custom ILoggerAdapter)
- Step-by-step logging using Serilog
- Used FluentAssertions for readable and strict assertions

## Folder Structure

SauceDemoTests/
├── Drivers/ // Browser strategies and WebDriver factory
│ ├── ChromeStrategy.cs
│ ├── FirefoxStrategy.cs
│ ├── IBrowserStrategy.cs
│ └── WebDriverFactory.cs
├── Logging/ // Logging adapter interface and Serilog implementation
│ ├── ILoggerAdapter.cs
│ └── SerilogAdapter.cs
├── Pages/
│ └── LoginPage.cs // Page Object for login form
├── Tests/
│ └── LoginTests.cs // UI tests for login functionality

## Applied Design Patterns

- Strategy – for flexible browser driver management
- Singleton – for managing a single WebDriver instance
- Adapter – to abstract logging implementation
- Page Object Model – for separating test logic and UI locators

This implementation provides a structured and extendable solution with additional architectural improvements and optional tasks implementation.