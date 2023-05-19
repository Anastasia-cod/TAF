using Core;
using Core.Utilites.Configuration;
using OpenQA.Selenium;

namespace Tests.BaseEntities
{
    public class BaseTest
    {
        public static readonly string? BaseUrl = Configurator.AppSettings.URL;

        [ThreadStatic] protected static IWebDriver? Driver;
        protected WaitService? WaitService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void Setup()
        {
            Driver = new Browser().Driver;
            WaitService = new WaitService(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Driver?.Quit();
        }
    }
}