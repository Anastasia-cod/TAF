using OpenQA.Selenium;

namespace Tests.BaseEntities
{
    public abstract class BasePage
    {
        protected static int WAIT_FOR_PAGE_LOADING_TIME = 60;
        [ThreadStatic] protected static IWebDriver? Driver;

        public BasePage()
        {
        }

        protected abstract void OpenPage();
        public abstract bool IsPageOpened();

        public BasePage(IWebDriver? driver, bool openPageByUrl)
        {
            Driver = driver;

            if (openPageByUrl)
            {
                OpenPage();
            }
        }
    }
}