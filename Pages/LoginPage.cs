using OpenQA.Selenium;

namespace SauceDemoTests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement Username => _driver.FindElement(By.XPath("//input[@id='user-name']"));
        public IWebElement Password => _driver.FindElement(By.XPath("//input[@id='password']"));
        public IWebElement LoginButton => _driver.FindElement(By.XPath("//input[@id='login-button']"));
        public IWebElement ErrorMessage => _driver.FindElement(By.XPath("//h3[@data-test='error']"));

        public void Login(string username, string password)
        {
            Username.Clear();
            Username.SendKeys(username);
            Password.Clear();
            Password.SendKeys(password);
            LoginButton.Click();
        }
    }
}
