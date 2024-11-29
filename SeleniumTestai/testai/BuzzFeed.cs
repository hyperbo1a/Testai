using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestai.testai
{
    public class BuzzFeed
    {
        Functions veiksmai = new Functions();
        public void NaujienųSrautoTestai()
        {
            try
            {
                using (IWebDriver driver = new ChromeDriver())
                {
                    // Atidaromas OrangeHRM ir prisijungiama
                    veiksmai.PrisijungimasPrieOrangeHRM(driver, "https://opensource-demo.orangehrmlive.com/", "Admin", "admin123");

                    // Atidaromas naujienu puslapis
                    Console.WriteLine("\nAtidaromas Buzz langas");
                    driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/buzz/viewBuzz");
                    Thread.Sleep(2000);

                    // Pranesimas su paveiksleliu
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div/div[1]/div[2]/button[1]")).Click();
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div/div[2]/div/div/div/form/div[1]/div[2]/div/textarea")).SendKeys("labas 123");
                    driver.FindElement(By.CssSelector("input[type='file']")).SendKeys("C:/Users/sinke/Downloads/spriteee.PNG");
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div/div[2]/div/div/div/form/div[3]/button")).Click();
                    Console.WriteLine("\nPranesimas su paveiksleliu sukurtas");
                    Thread.Sleep(3000);

                    // Pamegti savo pranesima
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div/div[3]/div[1]/div/div[3]/div[1]/div")).Click();
                    Console.WriteLine("\nPranesimas pamegtas");
                    Thread.Sleep(5000);
                    // Pranesimo redagavimas
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div[2]/li/button")).Click();
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div[2]/li/ul/li[2]")).Click();
                    Console.WriteLine("\nAtidaromas pranesimo redagavimo langas");
                    Thread.Sleep(1000);

                    // Redaguojamas pranesimas
                    driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div[1]/div[2]/div/div/div/form/div[1]/div[2]/div/textarea")).Clear();
                    driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div[1]/div[2]/div/div/div/form/div[1]/div[2]/div/textarea")).SendKeys(" Naujas labas 123");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div[2]/div/div/div/form/div[3]/button")).Click();
                    Console.WriteLine("\nPranesimas atnaujintas");
                    Thread.Sleep(3000);

                    // Komentaro parasymas
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div/div[3]/div[1]/div/div[3]/div[1]/button[1]")).Click();
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div/div[3]/div[1]/div/div[4]/div/form/div/div[2]/input")).SendKeys("labas labas");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div/div[3]/div[1]/div/div[4]/div/form/div/div[2]/input")).SendKeys(Keys.Enter);
                    Console.WriteLine("\nKomentaras parasytas");
                    Thread.Sleep(2000);

                    // Pamegti komentara
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div/div[3]/div[1]/div/div[4]/div[2]/div[2]/div[2]/p[1]")).Click();
                    Console.WriteLine("\nKomentaras pamegtas sekmingai!");
                    Thread.Sleep(1000);

                    // Redaguoti komentara
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div/div[3]/div[1]/div/div[4]/div[2]/div[2]/div[2]/p[2]")).Click();
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div/div[3]/div[1]/div/div[4]/div[2]/div[2]/form/div/div[2]/input")).SendKeys("Vis gi ate");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div/div[3]/div[1]/div/div[4]/div[2]/div[2]/form/div/div[2]/input")).SendKeys(Keys.Enter);
                    Console.WriteLine("\nKomentaras atnaujintas");
                    Thread.Sleep(2000);

                    // Istrinti komentara
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div/div[3]/div[1]/div/div[4]/div[2]/div[2]/div[2]/p[3]")).Click();
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[3]/div/div/div/div[3]/button[2]")).Click();
                    Console.WriteLine("\nKomentaras istrintas");
                    Thread.Sleep(2000);

                    IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
                    jsExecutor.ExecuteScript("window.scrollTo(0, 0);");

                    // Istrinti pranesima
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div[2]/li/button/i")).Click();
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div[2]/li/ul/li[1]")).Click();
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[3]/div/div/div/div[3]/button[2]")).Click();
                    Console.WriteLine("\nPranesimas istrintas");
                    Thread.Sleep(2000);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nTestas atliktas");
                    Console.ResetColor();
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Klaida: " + e.Message);
                Console.ResetColor();
            }
            finally
            {

                Console.ResetColor();
            }
        }
    }
}