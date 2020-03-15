using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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
    [TestFixture]   
	public class Tests
	{
		private IWebDriver driver;
		private BasePage page;
		
		[SetUp]
		public void InitTests()
		{
			driver = GetWebDriver();
		}
		
		private IWebDriver GetWebDriver()
		{
			switch (ConfigurationManager.AppSettings["browser"].ToUpper())
			{
				case "FIREFOX":
					//только для версий 46 и ниже
					return new FirefoxDriver();
				
				case "CHROME":
					return new ChromeDriver();
				
				case "IE":
					//требует донастройки браузера, см. https://github.com/SeleniumHQ/selenium/wiki/InternetExplorerDriver, раздел RequiredConfiguration
					return new InternetExplorerDriver();
				
				default:
					return new ChromeDriver();
			};
		}
		
		[Test]
		public void TestMainPage()
		{
			MainPage mainPage = new MainPage(driver);
			
			mainPage.OpenPage();
			foreach (KeyValuePair<string, string> element in mainPage.leftMenuElemens)
			{
				IWebElement pictureBlock = mainPage.CheckLeftMenuElementAndPictureAccordance(element);
				Assert.IsTrue(pictureBlock.Displayed);
			}
		}
		
		// Проверка страницы рассчета письменного перевода
		
		[Test]
		public void TestWrittenTranslatePage()
		{
			WrittenTranslatePage writtenTranslatePage = new WrittenTranslatePage(driver);
			
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
		
		
		// Проверка страницы рассчета устного перевода
		
		[Test]
		public void TestVerbalTranslatePage()
		{
			VerbalTranslatePage verbalTranslatePage = new VerbalTranslatePage(driver);
			
			verbalTranslatePage.OpenPage();
			
			SelectElement select = verbalTranslatePage.SelectEventType();
			Assert.IsNotNull(select);
			select.SelectByText("деловые переговоры");
		}


        // Проверка контактной информации на странице рассчета устного перевода

        [Test]
		public void TestContactInformation()
		{
			VerbalTranslatePage verbalTranslatePage = new VerbalTranslatePage(driver);			
    		verbalTranslatePage.OpenPage();
			Assert.AreEqual(4, verbalTranslatePage.GetNumberOfLanguages());
			Thread.Sleep(1000);
			IWebElement currentElement = verbalTranslatePage.GetPhone();
			Assert.IsTrue(currentElement.Displayed);
		}


        // Проверка контактной информации на главной странице

        [Test]
        public void TestContactInformationOnMainPage()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.OpenPage();
            Assert.AreEqual(4, mainPage.GetNumberOfLanguages());
            Thread.Sleep(1000);
            IWebElement currentElement = mainPage.GetPhone();
            Assert.IsTrue(currentElement.Displayed);
        }

        // Проверка контактной информации на странице рассчета письменного перевода

        [Test]
        public void TestContactInformationOnWrittenTranslatePage()
        {
            WrittenTranslatePage writtenTranslatePage = new WrittenTranslatePage(driver);
            writtenTranslatePage.OpenPage();
            Assert.AreEqual(4, writtenTranslatePage.GetNumberOfLanguages());
            Thread.Sleep(1000);
            IWebElement currentElement = writtenTranslatePage.GetPhone();
            Assert.IsTrue(currentElement.Displayed);
        }

        [TearDown]
		public void FinalizeTest()
		{
			if (TestContext.CurrentContext.Result.Status == TestStatus.Failed)
			{
				MakeScreenshot(TestContext.CurrentContext.Test.Name);
			}
			
			driver.Quit();
		}
		
		public void MakeScreenshot(string testName)
		{
			string fileName = String.Format("../../{0}_{1}.png", DateTime.Now.ToString("yyyy-MM-dd-HH-mm"), testName);
			
			try
			{
				Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
				ss.SaveAsFile(fileName, System.Drawing.Imaging.ImageFormat.Png);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}
