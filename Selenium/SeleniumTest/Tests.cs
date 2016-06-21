using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using NUnit.Framework;
using SeleniumTest.PageObjectModel;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace SeleniumTest
{
	public class Tests
	{
		private IWebDriver GetWebDriver()
		{
			switch (ConfigurationManager.AppSettings["browser"].ToUpper())
			{
				case "FIREFOX":
					return new FirefoxDriver();
				case "CHROME":
					return new ChromeDriver();
				case "IE":
					return new InternetExplorerDriver();
				default:
					return new ChromeDriver();
			};

		}

		[Test]
		public void TestMainPage()
		{
			using (var driver = GetWebDriver())
			{
				MainPage mainPage = new MainPage(driver);

				try
				{
					mainPage.OpenPage();
					foreach (var element in mainPage.leftMenuElemens)
					{
						var pictureBlock = mainPage.CheckLeftMenuElementAndPictureAccordance(element);
						Assert.IsTrue(pictureBlock.Displayed);
					}

				}

				catch
				{
					mainPage.MakeScreenshot("TestMainPage");
					throw;
				}
			}
		}


		// Проверка страницы рассчета письменного перевода

		[Test]
		public void TestWrittenTranslatePage()
		{
			using (var driver = new ChromeDriver())
			{
				WrittenTranslatePage writtenTranslatePage = new WrittenTranslatePage(driver);

				try
				{
					writtenTranslatePage.OpenPage();

					// Найти и кликнуть на выбор языка оригинала "русский"

					SelectElement select = writtenTranslatePage.SelectOriginalLanguage();
					Assert.IsNotNull(select);
					select.SelectByText("Русский");

					Thread.Sleep(1000);

					// Найти и кликнуть на выбор языка перевода "английский"

					select = writtenTranslatePage.SelectTargetLanguage();
					Assert.IsNotNull(select);
					select.SelectByText("Английский");
				}

				catch
				{
					writtenTranslatePage.MakeScreenshot("TestWrittenTranslatePage");
					throw;
				}
			}
		}


		// Проверка страницы рассчета устного перевода

		[Test]
		public void TestVerbalTranslatePage()
		{
			using (var driver = new ChromeDriver())
			{
				VerbalTranslatePage verbalTranslatePage = new VerbalTranslatePage(driver);
				try
				{
					verbalTranslatePage.OpenPage();

					SelectElement select = verbalTranslatePage.SelectEventType();
					Assert.IsNotNull(select);
					select.SelectByText("деловые переговоры");
				}

				catch
				{
					verbalTranslatePage.MakeScreenshot("TestVerbalTranslatePage");
					throw;
				}
			}
		}


		// Проверка контактной информации

		[Test]
		public void TestContactInformation()
		{
			using (var driver = new ChromeDriver())
			{
				MainPage mainPage = new MainPage(driver);
				WrittenTranslatePage writtenTranslatePage = new WrittenTranslatePage(driver);
				VerbalTranslatePage verbalTranslatePage = new VerbalTranslatePage(driver);

				List<BasePage> pages = new List<BasePage>
				{
					mainPage,
					writtenTranslatePage,
					verbalTranslatePage
				};

				foreach (BasePage page in pages)
				{
					try
					{
						page.OpenPage();
						Assert.AreEqual(4, page.GetNumberOfLanguages());
						Thread.Sleep(1000);
						var currentElement = page.GetPhone();
						Assert.IsTrue(currentElement.Displayed);
					}
					catch
					{
						page.MakeScreenshot("TestContactInformation");
						throw;
					}
				}
			}
		}
	}
}
