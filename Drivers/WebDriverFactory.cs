using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SauceDemoTests.Drivers
{
    public interface IBrowserStrategy
    {
        IWebDriver GetDriver();
    }

    public class ChromeStrategy : IBrowserStrategy
    {
        public IWebDriver GetDriver() => new ChromeDriver();
    }

    public class FirefoxStrategy : IBrowserStrategy
    {
        public IWebDriver GetDriver() => new FirefoxDriver();
    }

    public class WebDriverFactory
    {
        private static IWebDriver _driver;

        public static IWebDriver GetDriver(string browser)
        {
            if (_driver != null) return _driver;

            IBrowserStrategy strategy = browser.ToLower() switch
            {
                "chrome" => new ChromeStrategy(),
                _ => throw new ArgumentException("Unsupported browser")
            };

            _driver = strategy.GetDriver();
            return _driver;
        }

        public static void QuitDriver()
        {
            _driver?.Quit();
            _driver = null;
        }
    }
}
