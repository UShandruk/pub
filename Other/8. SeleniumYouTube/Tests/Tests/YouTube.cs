using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Tests
{
    public class YouTubeTests
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        [Description("Авторизация")]
        public void AuthorizationTest()
        {
            // 1. Зайти на сайт youtube
            driver.Navigate().GoToUrl("https://www.youtube.com/");

            // 2. Сменить язык интерфейса на английский
            IWebElement btnSettings = driver.FindElement(By.XPath("//*[@aria-label='Настройки']"));
            btnSettings.Click();
            IWebElement menuItemLanguage = driver.FindElement(By.Id("language"));
            menuItemLanguage.Click();

                // пункт подменю "English (UK)" не виден без прокрутки
                Thread.Sleep(2000);
                string script = "document.querySelector('#settings > ytd-account-settings > div > div.container.style-scope.ytd-account-settings').scrollTop=500";
                IJavaScriptExecutor jsExecutor = driver as IJavaScriptExecutor;
                jsExecutor.ExecuteScript(script);
                string script2 = "document.querySelector('#settings > ytd-account-settings > div > div.container.style-scope.ytd-account-settings > paper-item:nth-child(21) > p').click()";
                jsExecutor.ExecuteScript(script2);
                Thread.Sleep(2000);
            
            // 3. Авторизоваться            
            IWebElement btnSignIn = driver.FindElement(By.XPath("//*[@id='buttons']/ytd-button-renderer"));
            btnSignIn.Click();
            Thread.Sleep(3000);
            
            IWebElement inputEmail = driver.FindElement(By.Name("identifier"));
            inputEmail.Click();
            inputEmail.SendKeys("htmfdsg@gmail.com");
            Thread.Sleep(2000);

            driver.FindElement(By.Id("identifierNext")).Click();
            Thread.Sleep(2000);

            IWebElement inputPassword = driver.FindElement(By.Name("password"));
            inputPassword.Click();
            inputPassword.SendKeys("8Zaf2X7sw");
            driver.FindElement(By.Id("passwordNext")).Click();
            Thread.Sleep(5000);

            // 4.1 Проверить успешность выполнения пункта 2 (язык)
            string languageActual = driver.FindElement(By.TagName("html")).GetAttribute("lang");
            Assert.AreEqual("en-GB", languageActual);

            // 4.2 Проверить успешность выполнения пункта 3 (успешная авторизация)
            // Если появилась кнопка с аватаром - значит авторизация пройдена успешно. 
            var btnAccount = driver.FindElement(By.Id("avatar-btn"));

            ////5. * Загрузить видео на свой канал
            //var btnAddVideoOrPost = driver.FindElement(By.XPath("//*[@aria-label='Create a video or post']"));
            //btnAddVideoOrPost.Click();
            //Thread.Sleep(500);

            //driver.FindElement(By.TagName("paper-item")).Click();
            //Thread.Sleep(2000);
            //driver.FindElement(By.XPath("//*[@id='upload-prompt-box']")).Click();

            //IWebElement fileInput = driver.FindElement(By.Name("uploadfile"));
            //fileInput.SendKeys("C:/path/to/file.jpg");

            ////6. * Проверить, что видео загрузилось
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}