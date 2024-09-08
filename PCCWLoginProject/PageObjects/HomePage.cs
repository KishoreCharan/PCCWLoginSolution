using OpenQA.Selenium;
using PCCWLoginProject.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCWLoginProject.PageObjects
{
    public class HomePage:Base
    {

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div/p[@class='has-text-align-center']")]
        private IWebElement successmessageArea;
       
        public IWebElement getLoggedInMessageArea()
        {
            return successmessageArea;
        }
       
    }
}
