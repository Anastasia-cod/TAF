using System;
using OpenQA.Selenium;
using Tests.BaseEntities;

namespace Tests.Pages
{
    public class LoginPage : BasePage
    {
        private static string END_POINT = "";
        
        // Описание элементов
        private static readonly By EmailInputBy = By.Id("name");
        private static readonly By PswInputBy = By.Id("password");
        private static readonly By RememberMeCheckboxBy = By.Id("rememberme");
        private static readonly By LoginInButtonBy = By.Id("button_primary");
        
        // Инициализация класса
        public LoginPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public LoginPage(IWebDriver? driver) : base(driver, false)
        {
        }
        
        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return LoginInButton().Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        // Методы
        public IWebElement EmailInput()
        {
            return Driver.FindElement(EmailInputBy);  
        }

        public IWebElement PswInput()
        {
            return Driver.FindElement(PswInputBy);
        }

        public IWebElement RememberMeCheckbox()
        {
            return Driver.FindElement(RememberMeCheckboxBy);  
        }

        public IWebElement LoginInButton()
        {
           return Driver.FindElement(LoginInButtonBy);
        }

        public DashboardPage SuccessfulLogin(string username, string psw)
        {
            Login(username, psw);
            return new DashboardPage(Driver);
        }

        public LoginPage IncorrectLogin(string username, string psw)
        {
            Login(username, psw);
            return this;
        }

        private void Login(string username, string psw)
        {
            EmailInput().SendKeys(username);
            PswInput().SendKeys(psw);
            LoginInButton().Click();
        }
    }
}