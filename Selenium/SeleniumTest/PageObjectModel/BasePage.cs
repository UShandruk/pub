using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.PageObjectModel
{
    public abstract class BasePage
    {
        protected IWebDriver Driver { get; set; }

        protected IWebElement[] languageSwitcherElements;
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            languageSwitcherElements = driver.FindElements(By.ClassName("lang-switcher__item")).ToArray();
        }
        public abstract void OpenPage();
        public abstract void MakeScreenshot();
        public abstract int GetNumberOfLanguages();        
        public abstract IWebElement GetPhone();
    }
}
