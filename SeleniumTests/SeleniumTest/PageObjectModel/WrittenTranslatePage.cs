using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace SeleniumTest.PageObjectModel
{
	public class WrittenTranslatePage : BasePage
	{
		public WrittenTranslatePage(IWebDriver driver)
			: base (driver)
		{

		}

		public SelectElement SelectOriginalLanguage()
		{
			SelectElement select = new SelectElement(webdriver.FindElement(By.Name("from-lang")));
			return select;
		}

		public SelectElement SelectTargetLanguage()
		{
			SelectElement select = new SelectElement(webdriver.FindElement(By.Name("to-lang")));
			return select;
		}

		public override void OpenPage()
		{
			webdriver.Navigate().GoToUrl("http://abbyy-ls.ru/doc-calculator");
		}


		public override int GetNumberOfLanguages()
		{
			string[] languageUrlAddresses = new string[]
			{
				"http://abbyy-ls.com/interpreting_offer",
				"http://abbyy-ls.de/interpreting_offer",
				"http://abbyy-ls.kz/interpreting_offer",
				"http://abbyy-ls.com.ua/interpreting_offer"
			};

			IWebElement languageSelectBox = webdriver.FindElement(By.ClassName("lang-switcher"));
			var languageVariants = languageSelectBox.FindElements(By.ClassName("lang-switcher__item"));
			string[] languageVariantsHrefs = languageVariants.Select(v => v.GetAttribute("href")).ToArray();

			return languageVariants.Count();
		}

		public override IWebElement GetPhone()
		{
			IWebElement currentElement = webdriver.FindElement(By.ClassName("call_phone_1"));
			return currentElement;
		}
	}
}
