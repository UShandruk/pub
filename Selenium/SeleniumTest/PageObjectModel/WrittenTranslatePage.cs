using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.PageObjectModel
{
    public class WrittenTranslatePage : BasePage
    {
        public WrittenTranslatePage(IWebDriver driver) : base (driver)
        {

        }

        public SelectElement SelectOriginalLanguage()
        {
            SelectElement select = new SelectElement(Driver.FindElement(By.Name("from-lang")));
            return select;
        }

        public SelectElement SelectTargetLanguage()
        {
            SelectElement select = new SelectElement(Driver.FindElement(By.Name("to-lang")));
            return select;
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl("http://abbyy-ls.ru/doc-calculator");
        }

        public override void MakeScreenshot()
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();
                ss.SaveAsFile(@"TestWrittenTranslatePageError.png", System.Drawing.Imaging.ImageFormat.Png);
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
