using Core.Utilites.Configuration;
using Core.Wrappers;
using OpenQA.Selenium;
using Tests.BaseEntities;
using Tests.Pages;
using Tests.Steps;

namespace Tests.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class LoginTest : BaseTest
    {
        [Test]
        [SmokeTest]
        public void Test1()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            loginSteps.LogIn();

            Driver.Navigate().GoToUrl(Configurator.AppSettings.URL + "index.php?/admin/overview");
            new DashboardPage(Driver, true);

            Assert.IsTrue(new DashboardPage(Driver).IsPageOpened());
            Assert.AreEqual(Driver.Title, "All Projects - TestRail");
        }

        [Test]
        [Regression]
        public void Test2()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            loginSteps.LogIn();

            Assert.IsTrue(new DashboardPage(Driver).IsPageOpened());
            Assert.AreEqual(Driver.Title, "All Projects - TestRail");
        }

        [Test]
        [SmokeTest]
        public void Test3()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            loginSteps.LogIn();

            var start = DateTime.Now;
            new UIElement(Driver, WaitService.GetVisibleElement(By.Id("sidebar-projects-add")));
            var stop = DateTime.Now;
            Console.Out.WriteLine(stop.Ticks - start.Ticks);
        }

        [Test]
        [SmokeTest]
        public void Test4()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            loginSteps.LogIn();

            var start = DateTime.Now;
            WaitService?.ExistsElement(By.Id("sidebar-projects-add"));
            var stop = DateTime.Now;
            Console.Out.WriteLine(stop.Ticks - start.Ticks);
        }
    }
}