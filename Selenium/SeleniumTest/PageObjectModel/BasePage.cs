using OpenQA.Selenium;
using System;
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
		public void MakeScreenshot(string testName)
		{
			var fileName = String.Format("../../{0}_{1}.png", DateTime.Now.ToString("yyyy-MM-dd-HH-mm"), testName);

			try
			{
				Screenshot ss = ((ITakesScreenshot)webdriver).GetScreenshot();
				ss.SaveAsFile(fileName, System.Drawing.Imaging.ImageFormat.Png);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				throw;
			}
		}

		public abstract int GetNumberOfLanguages();
		public abstract IWebElement GetPhone();
	}
}
