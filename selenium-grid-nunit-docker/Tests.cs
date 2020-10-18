using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace selenium_grid_nunit_docker
{
    [TestFixture]
    [Parallelizable]
    public class ChromeTests : Hooks
    {
        public ChromeTests() : base(BrowserType.Chrome){ }

        [Test]
        public void TestUsingChrome()
        {
            Driver.Navigate().GoToUrl("http://www.google.com");
            Driver.FindElement(By.Name("q")).SendKeys("selenium");
            Thread.Sleep(600);
            Driver.FindElement(By.Name("btnK")).Click();
            Assert.That(Driver.PageSource.Contains("selenium"), Is.EqualTo(true), "The text selenium doesn't exist");
        }
    }

    [TestFixture]
    [Parallelizable]
    public class FirefoxTests : Hooks
    {
        public FirefoxTests() : base(BrowserType.Firefox) { }

        [Test]
        public void TestUsingFirefox()
        {
            Driver.Navigate().GoToUrl("http://www.google.com");
            Driver.FindElement(By.Name("q")).SendKeys("selenium");
            Thread.Sleep(600);
            Driver.FindElement(By.Name("btnK")).Click();
            Assert.That(Driver.PageSource.Contains("selenium"), Is.EqualTo(true), "The text selenium doesn't exist");
        }

    }

}
