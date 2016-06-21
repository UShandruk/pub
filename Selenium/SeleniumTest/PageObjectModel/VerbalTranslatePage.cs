using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace SeleniumTest.PageObjectModel
{
	public class VerbalTranslatePage : BasePage
	{
		public VerbalTranslatePage(IWebDriver driver)
			: base(driver)
		{
			
		}

		public SelectElement SelectEventType()
		{
			SelectElement select = new SelectElement(webdriver.FindElement(By.Name("submitted[event_type]")));
			return select;
		}

		public override void OpenPage()
		{
			webdriver.Navigate().GoToUrl("http://abbyy-ls.ru/interpreting_offer");
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

			var languageSelectBox = webdriver.FindElement(By.ClassName("lang-switcher"));
			var languageVariants = languageSelectBox.FindElements(By.ClassName("lang-switcher__item"));
			var languageVariantsHrefs = languageVariants.Select(v => v.GetAttribute("href")).ToArray();

			return languageVariants.Count();
		}

		public override IWebElement GetPhone()
		{
			var currentElement = webdriver.FindElement(By.ClassName("call_phone_1"));
			return currentElement;
		}
	}
}
