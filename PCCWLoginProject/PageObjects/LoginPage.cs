using OpenQA.Selenium;
using PCCWLoginProject.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace PCCWLoginProject.PageObjects
{

    public class LoginPage : Base
    {
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "section[id='login'] h2")]
        private IWebElement beforeloginpagearea;
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password;
        [FindsBy(How = How.Id, Using = "submit")]
        private IWebElement submit;

        public IWebElement getBeforeLoginPageArea()
        {
            return beforeloginpagearea;
        }
        public IWebElement getUserName()
        {
            return username;
        }
        public IWebElement getPassword()
        {
            return password;
        }
        public IWebElement getSubmitButton()
        {
            return submit;
        }

        public void enterUserName(string userName)
        {
            getUserName().SendKeys(userName);
        }
        public void enterPassword(string passWord)
        {
            getPassword().SendKeys(passWord);
        }
        public void clickSubmit()
        {
            getSubmitButton().Click();
        }
        public HomePage login(string user, string pass)
        {
            enterUserName(user);
            enterPassword(pass);
            clickSubmit();
            return new HomePage(driver);

        }
    }
}