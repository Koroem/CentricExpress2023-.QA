using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QA
{
    [TestClass]
    public class LoginTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/");
        }

        [TestMethod]
        public void LoginSuccessful()
        {
            driver.FindElement(By.XPath("//input[@name='username']")).SendKeys("test123");
            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("test123");
            driver.FindElement(By.XPath("//input[@value='Log In']")).Click();

            var welcomeMessage=driver.FindElement(By.ClassName("smallText")).Text;
            Assert.IsTrue(welcomeMessage.Contains("Welcome"));
        }
        [TestMethod]
        public void LoginFailed() 
        {
            driver.FindElement(By.XPath("//input[@name='username']")).SendKeys("test123");
            driver.FindElement(By.XPath("//input[@value='Log In']")).Click();

            var errorMessage = driver.FindElement(By.ClassName("error")).Text;
            Assert.AreEqual("Please enter a username and password.",errorMessage);
        }
        [TestCleanup]
        public void Cleanup() { driver.Quit(); }

    }
}