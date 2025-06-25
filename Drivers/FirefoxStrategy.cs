using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SauceDemoTests.Drivers
{
    public class FirefoxStrategy : IBrowserStrategy
    {
        public IWebDriver GetDriver() => new FirefoxDriver();
    }
}
