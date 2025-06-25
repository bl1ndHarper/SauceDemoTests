using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceDemoTests.Drivers
{
    public class ChromeStrategy : IBrowserStrategy
    {
        public IWebDriver GetDriver() => new ChromeDriver();
    }
}
