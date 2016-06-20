using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SeleniumTest.PageObjectModel;

namespace SeleniumTest
{
    [TestFixture]
    public class ChromeTests
    {
        [Test]
        public void TestMainPage() //Проверка главной страницы сайта
        {
            using (var driver = new ChromeDriver())
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

        [Test]
        public void TestWrittenTranslatePage() //Проверка страницы рассчета письменного перевода
        {
            using (var driver = new ChromeDriver())
            {
                WrittenTranslatePage writtenTranslatePage = new WrittenTranslatePage(driver);

                try
                {
                    writtenTranslatePage.OpenPage();

                    //Найти и кликнуть на выбор языка оригинала "русский"
                    SelectElement select = writtenTranslatePage.SelectOriginalLanguage();
                    Assert.IsNotNull(select);
                    select.SelectByText("Русский");

                    Thread.Sleep(1000);

                    //Найти и кликнуть на выбор языка перевода "английский"
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

        [Test]
        public void TestVerbalTranslatePage() //Проверка страницы рассчета устного перевода
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
                    verbalTranslatePage.MakeScreenshot();
                    throw;
                }
            }
        }

        [Test]
        public void TestContactInformation() //Проверка контактной информации
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
                        page.MakeScreenshot();
                        throw;
                    }
                }
            }
        }
    }
}
