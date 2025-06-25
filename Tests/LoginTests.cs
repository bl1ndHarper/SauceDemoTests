#pragma warning disable S3881 // "IDisposable" should be implemented correctly
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

using SauceDemoTests.Drivers;
using SauceDemoTests.Pages;
using SauceDemoTests.Logging;
using FluentAssertions;
using Xunit;
using OpenQA.Selenium;

namespace SauceDemoTests.Tests
{
    public class LoginTests : IDisposable
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private readonly ILoggerAdapter _logger;

        public LoginTests()
        {
            _logger = new SerilogAdapter();
        }

        [Theory]
        [InlineData("chrome")]
        [InlineData("firefox")]
        public void UC1_LoginWithEmptyCredentials_ShouldShowUsernameRequired(string browser)
        {
            InitDriver(browser);
            _loginPage.Username.Clear();
            _loginPage.Password.Clear();
            _loginPage.LoginButton.Click();

            _loginPage.ErrorMessage.Text.Should().Contain("Username is required");
            _logger.Info($"[UC1] Passed on {browser}");
        }

        [Theory]
        [InlineData("chrome")]
        [InlineData("firefox")]
        public void UC2_LoginWithUsernameOnly_ShouldShowPasswordRequired(string browser)
        {
            InitDriver(browser);
            _loginPage.Username.SendKeys("standard_user");
            _loginPage.Password.Clear();
            _loginPage.LoginButton.Click();

            _loginPage.ErrorMessage.Text.Should().Contain("Password is required");
            _logger.Info($"[UC2] Passed on {browser}");
        }

        [Theory]
        [InlineData("chrome")]
        [InlineData("firefox")]
        public void UC3_ValidCredentials_ShouldLoginSuccessfully(string browser)
        {
            InitDriver(browser);
            _loginPage.Login("standard_user", "secret_sauce");

            var logo = _driver.FindElement(By.XPath("//div[@class='app_logo']"));
            logo.Text.Should().Be("Swag Labs");
            _logger.Info($"[UC3] Passed on {browser}");
        }

        private void InitDriver(string browser)
        {
            _driver = WebDriverFactory.GetDriver(browser);
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            _loginPage = new LoginPage(_driver);
        }

        public void Dispose()
        {
            WebDriverFactory.QuitDriver();
        }
    }
}
