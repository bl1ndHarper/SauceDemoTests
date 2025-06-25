using OpenQA.Selenium;

namespace SauceDemoTests.Drivers
{
    public static class WebDriverFactory
    {
        private static IWebDriver? _driver;

        public static IWebDriver GetDriver(string browser)
        {
            if (_driver != null) return _driver;

            IBrowserStrategy strategy = browser.ToLower() switch
            {
                "chrome" => new ChromeStrategy(),
                "firefox" => new FirefoxStrategy(),
                _ => throw new ArgumentException($"Unsupported browser: {browser}")
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
