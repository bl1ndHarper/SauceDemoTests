using SauceDemoTests.Drivers;
using SauceDemoTests.Pages;
using FluentAssertions;
using Xunit;
using Serilog;
using OpenQA.Selenium;
using SauceDemoTests.Logging;
using OpenQA.Selenium.BiDi.Communication;

namespace SauceDemoTests.Tests
{
    public class LoginTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly ILoggerAdapter _logger;

        public LoginTests()
        {
            _logger = new SerilogAdapter();
            _driver = WebDriverFactory.GetDriver("chrome");
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            _loginPage = new LoginPage(_driver);
        }

        [Fact]
        public void UC1_LoginWithEmptyCredentials_ShouldShowUsernameRequired()
        {
            _loginPage.Username.Clear();
            _loginPage.Password.Clear();
            _loginPage.LoginButton.Click();

            _loginPage.ErrorMessage.Text.Should().Contain("Username is required");
            _logger.Info("Test UC1 passed");
        }

        [Fact]
        public void UC2_LoginWithUsernameOnly_ShouldShowPasswordRequired()
        {
            _loginPage.Username.SendKeys("standard_user");
            _loginPage.Password.Clear();
            _loginPage.LoginButton.Click();

            _loginPage.ErrorMessage.Text.Should().Contain("Password is required");
            _logger.Info("Test UC2 passed");
        }

        [Fact]
        public void UC3_ValidCredentials_ShouldLoginSuccessfully()
        {
            _loginPage.Login("standard_user", "secret_sauce");

            var logo = _driver.FindElement(By.XPath("//div[@class='app_logo']"));
            logo.Text.Should().Be("Swag Labs");
            _logger.Info("Test UC3 passed");
        }

        public void Dispose()
        {
            WebDriverFactory.QuitDriver();
        }
    }
}
