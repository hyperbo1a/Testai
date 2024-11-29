using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestai
{
    public class Functions
    {
        public void PasirinkimoLangelis(IWebDriver driver, string xpath, int arrowCount)
        {
            IWebElement element = driver.FindElement(By.XPath(xpath));
            element.Click();

            Actions actions = new Actions(driver);
            for (int i = 0; i < arrowCount; i++)
            {
                actions.SendKeys(Keys.ArrowDown).Perform();
            }
            actions.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(1000);
        }

        public void PrisijungimasPrieOrangeHRM(IWebDriver driver, string url, string username, string password)
        {
            Console.WriteLine("\nAtidaromas OrangeHRM puslapis");

            driver.Navigate().GoToUrl(url);
            Thread.Sleep(2000);

            driver.FindElement(By.Name("username")).SendKeys(username);
            driver.FindElement(By.Name("password")).SendKeys(password);
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            Thread.Sleep(2000);

            Console.WriteLine("\nPrisijungta sėkmingai!");
        }
        public bool WaitForFile(string directory, string fileName, int timeoutSeconds)
        {
            int waited = 0;
            while (waited < timeoutSeconds)
            {
                if (File.Exists(Path.Combine(directory, fileName)))
                {
                    return true;
                }
                Thread.Sleep(1000);
                waited++;
            }
            return false;
        }
        public void ExecuteTestIfUserExists(string? userURL, Action<string> testAction)
        {
            if (!string.IsNullOrEmpty(userURL))
            {
                testAction(userURL);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDarbuotojas dar nėra sukurtas. Pirmiausiai sukurti darbuotoją. (atlikite pirma testa)");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
