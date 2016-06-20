using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTest.PageObjectModel
{
    public class MainPage : BasePage
    {
        public Dictionary<string, string> leftMenuElemens { get; set; }

        public MainPage(IWebDriver driver) : base(driver)
        {
            leftMenuElemens = new Dictionary<string, string>
            {
                { "li.item1", "div.item1" },
                { "li.item2", "div.item5" },
                { "li.item3", "div.item3" },
                { "li.item4", "div.item4" },
                { "li.item5", "div.item2" }
            };
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl("http://abbyy-ls.ru/");
        }

        public IWebElement CheckLeftMenuElementAndPictureAccordance(KeyValuePair<string, string> element)
        {
            //Найти элемент меню и кликнуть на него -> Найти изображение -> Убедиться, что оно правильное
            Driver.FindElement(By.CssSelector(element.Key)).Click();
            Thread.Sleep(1000);
            var pictureBlock = Driver.FindElement(By.CssSelector(element.Value));
            return pictureBlock;
        }


        public override void MakeScreenshot()
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();
                ss.SaveAsFile(@"TestMainPageError.png", System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
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

            var languageSelectBox = Driver.FindElement(By.ClassName("lang-switcher"));
            var languageVariants = languageSelectBox.FindElements(By.ClassName("lang-switcher__item"));
            var languageVariantsHrefs = languageVariants.Select(v => v.GetAttribute("href")).ToArray();

            return languageVariants.Count();
        }

        public override IWebElement GetPhone()
        {
            var currentElement = Driver.FindElement(By.ClassName("call_phone_1"));
            return currentElement;
        }
    }
}
