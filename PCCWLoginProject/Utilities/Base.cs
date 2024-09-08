using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using PCCWLoginProject.PageObjects;
using System.Configuration;
using WebDriverManager.DriverConfigs.Impl;

namespace PCCWLoginProject.Utilities
{
    public class Base
    {
        public IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            String browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);
           /* new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();*/
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            enterUrl("https://practicetestautomation.com/practice-test-login/");
            LoginPage loginPage = new LoginPage(getDriver());
            string ActualBeforeLoginPageMessage = loginPage.getBeforeLoginPageArea().Text;
            StringAssert.Contains("Test login", ActualBeforeLoginPageMessage);
            Console.WriteLine(ActualBeforeLoginPageMessage);

        }
        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;

                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;


            }

        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
        public IWebDriver getDriver()
        {
            return driver;
        }
        public void enterUrl(String url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}