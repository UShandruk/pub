using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace SeleniumTest.PageObjectModel
{
	public abstract class BasePage
	{
		protected IWebDriver webdriver { get; set; }

		protected IWebElement[] languageSwitcherElements;
		public BasePage(IWebDriver driver)
		{
			webdriver = driver;
			languageSwitcherElements = driver.FindElements(By.ClassName("lang-switcher__item")).ToArray();
		}
		public abstract void OpenPage();

		public abstract int GetNumberOfLanguages();
		public abstract IWebElement GetPhone();

		public void WaitForElement(string selector)
		{
			Thread.Sleep(2000);
		}
	}
}
