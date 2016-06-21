using OpenQA.Selenium;
using System.Linq;

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
		public abstract void MakeScreenshot();
		public abstract int GetNumberOfLanguages();
		public abstract IWebElement GetPhone();
	}
}
