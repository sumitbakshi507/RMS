using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Immutable;
using System.Diagnostics;

namespace ConsoleApp.Tests
{
    class Program
    {
        private static IWebDriver browser;
        private static string baseUrl = @"http://localhost:8001/swagger/index.html";
        private static bool IsFilled =false;
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Tests!");
            browser = new ChromeDriver();
            //set browser time out time to 60 seconds
            browser.Navigate().GoToUrl(baseUrl);
            ExpandPost();

            Console.WriteLine("Press Key to Start");
            var key = Console.ReadKey();
            for (var i = 0; i < 1000; i++)
            {
                Console.WriteLine("Starting :" + (i +1));
                Send("sb3@"+ i + ".com", "98714"+ i);
                Console.WriteLine("Done :" + (i + 1));
            }

            Console.WriteLine("Done");

            Console.WriteLine("Press Enter to Close");
            Console.ReadLine();
            browser.Close();
            browser.Dispose();
        }

        private static void ExpandPost()
        {
            var spanId = "operations-Candidate-post_Candidate_UpdateProfile";

            WebDriverWait wait = new WebDriverWait(browser, new TimeSpan(0, 0, 5));
            var wait2 = new WebDriverWait(browser, TimeSpan.FromSeconds(60))
                            .Until(ExpectedConditions.ElementExists((By.Id(spanId))));

            browser.FindElement(By.Id(spanId)).Click();

            var buttonClass = "try-out__btn";
            browser.FindElement(By.ClassName(buttonClass)).Click();
        }

        private static void Send(string email, string number)
        {
            var JobPostId = browser.FindElement(By.XPath("//input[@placeholder='JobPostId']"));
            var Email = browser.FindElement(By.XPath("//input[@placeholder='Email']"));
            var Mobile = browser.FindElement(By.XPath("//input[@placeholder='Mobile']"));
            var CoverLetter = browser.FindElement(By.XPath("//input[@placeholder='CoverLetter']"));
            var Source = browser.FindElement(By.XPath("//input[@placeholder='Source']"));
            var file = browser.FindElement(By.XPath("//input[@type='file']"));

            if (!IsFilled) {
                JobPostId.Clear();
                JobPostId.SendKeys("1");
                CoverLetter.Clear();
                CoverLetter.SendKeys("Test Letter");
                Source.Clear();
                Source.SendKeys("SB");
                file.Clear();
                file.SendKeys(@"C:\Users\Sumit\Documents\Payment Provider V1.docx");
            }
            Email.Clear();
            Email.SendKeys(email);
            Mobile.Clear();
            Mobile.SendKeys(number);

            var btnId = "opblock-control__btn";
            browser.FindElement(By.ClassName(btnId)).Click();

            if (!IsFilled) {
                IsFilled = true;
            }
        }
    }
}
