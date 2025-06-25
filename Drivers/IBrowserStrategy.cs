using OpenQA.Selenium;

namespace SauceDemoTests.Drivers
{
    public interface IBrowserStrategy
    {
        IWebDriver GetDriver();
    }
}

