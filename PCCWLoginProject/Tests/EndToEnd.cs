using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PCCWLoginProject.PageObjects;
using PCCWLoginProject.Utilities;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCWLoginProject.Tests
{
    public class EndToEnd:Base
    {   

    
        [Test]
        public void EndToEndTest()
        {
            String ExpectedTitle = "Logged In Successfully | Practice Test Automation";
            String ExpectedMessage = "Congratulations student. You successfully logged in!";

            LoginPage loginPage = new LoginPage(getDriver());
            HomePage homePage=loginPage.login("student", "Password123");      
            String ActualTitle = driver.Title;
            String ActualMessage = homePage.getLoggedInMessageArea().Text;          
            StringAssert.Contains(ExpectedTitle, ActualTitle);
            StringAssert.Contains(ExpectedMessage, ActualMessage);
            Console.WriteLine(ActualTitle);
            Console.WriteLine(ActualMessage);
        }

    }
}
