using Core.Utilites.Configuration;
using OpenQA.Selenium;
using Tests.Pages;

namespace Tests.Steps
{
    public class LoginSteps
    {
        private IWebDriver? _driver;
        
        public LoginSteps(IWebDriver? driver)
        {
            _driver = driver;
        }

        public void LogIn()
        {
            LoginPage loginPage = new LoginPage(_driver, true);
            
            loginPage.EmailInput().SendKeys(Configurator.Admin?.Username);
            loginPage.PswInput().SendKeys(Configurator.Admin?.Password);
            loginPage.LoginInButton().Click();
        }
    }
}