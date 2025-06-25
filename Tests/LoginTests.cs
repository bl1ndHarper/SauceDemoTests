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
            _logger.Info($"[UC1] Starting test in browser: {browser}");

            InitDriver(browser);

            _logger.Info("[UC1] Clearing Username and Password fields (leave empty)");
            _loginPage.Username.Clear();
            _loginPage.Password.Clear();

            _logger.Info("[UC1] Clicking Login button");
            _loginPage.LoginButton.Click();

            string actualMessage = _loginPage.ErrorMessage.Text;
            _logger.Info($"[UC1] Actual error message: '{actualMessage}'");
            _logger.Info("[UC1] Expecting error message to contain: 'Username is required'");

            actualMessage.Should().Contain("Username is required");

            _logger.Info($"[UC1] Passed on {browser}");
        }

        [Theory]
        [InlineData("chrome")]
        [InlineData("firefox")]
        public void UC2_LoginWithUsernameOnly_ShouldShowPasswordRequired(string browser)
        {
            _logger.Info($"[UC2] Starting test in browser: {browser}");

            InitDriver(browser);

            _logger.Info("[UC2] Typing valid username");
            _loginPage.Username.SendKeys("standard_user");

            _logger.Info("[UC2] Clearing Password field (leave empty)");
            _loginPage.Password.Clear();

            _logger.Info("[UC2] Clicking Login button");
            _loginPage.LoginButton.Click();

            string actualMessage = _loginPage.ErrorMessage.Text;
            _logger.Info($"[UC2] Actual error message: '{actualMessage}'");
            _logger.Info("[UC2] Expecting error message to contain: 'Password is required'");

            actualMessage.Should().Contain("Password is required");

            _logger.Info($"[UC2] Passed on {browser}");
        }

        [Theory]
        [InlineData("chrome")]
        [InlineData("firefox")]
        public void UC3_ValidCredentials_ShouldLoginSuccessfully(string browser)
        {
            _logger.Info($"[UC3] Starting test in browser: {browser}");

            InitDriver(browser);

            _logger.Info("[UC3] Logging in with valid credentials");
            _loginPage.Login("standard_user", "secret_sauce");

            _logger.Info("[UC3] Checking for 'Swag Labs' title on dashboard");
            var logo = _driver.FindElement(By.XPath("//div[@class='app_logo']"));
            string actualText = logo.Text;

            _logger.Info($"[UC3] Actual logo text: '{actualText}'");
            _logger.Info("[UC3] Expecting: 'Swag Labs'");

            actualText.Should().Be("Swag Labs");

            _logger.Info($"[UC3] Passed on {browser}");
        }

        private void InitDriver(string browser)
        {
            _driver = WebDriverFactory.GetDriver(browser);
            _logger.Info($"[INIT] Navigating to https://www.saucedemo.com/");
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            _loginPage = new LoginPage(_driver);
        }

        public void Dispose()
        {
            _logger.Info("[CLEANUP] Quitting browser session");
            WebDriverFactory.QuitDriver();
        }
    }
}
