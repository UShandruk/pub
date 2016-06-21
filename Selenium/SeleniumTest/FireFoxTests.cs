using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Threading;
using SeleniumTest.PageObjectModel;

namespace SeleniumTest
{
	[TestFixture]
	class FireFoxTests
	{
		// Проверка главной страницы сайта

		[Test]
		public void TestMainPage()
		{
			using (var driver = new FirefoxDriver(new FirefoxOptions()))
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
					mainPage.MakeScreenshot();
					throw;
				}
			}
		}


		// Проверка страницы рассчета письменного перевода

		[Test]
		public void TestWrittenTranslatePage()
		{
			using (var driver = new FirefoxDriver(new FirefoxOptions()))
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
					writtenTranslatePage.MakeScreenshot();
					throw;
				}
			}
		}


		// Проверка страницы рассчета устного перевода

		[Test]
		public void TestVerbalTranslatePage()
		{
			using (var driver = new FirefoxDriver(new FirefoxOptions()))
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
					verbalTranslatePage.MakeScreenshot();
					throw;
				}
			}
		}


		// Проверка контактной информации

		[Test]
		public void TestContactInformation()
		{
			using (var driver = new FirefoxDriver(new FirefoxOptions()))
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
						page.MakeScreenshot();
						throw;
					}
				}
			}
		}
	}
}
