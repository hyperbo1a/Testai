using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestai.testai
{
    public class NaujaAtaskaita
    {
        Functions veiksmai = new Functions();
        public void SukurtiAtaskaitą()
        {
            try
            {
                using (IWebDriver driver = new ChromeDriver())
                {
                    // Atidaromas OrangeHRM ir prisijungiama
                    veiksmai.PrisijungimasPrieOrangeHRM(driver, "https://opensource-demo.orangehrmlive.com/", "Admin", "admin123");

                    // Atidaromas ataskaitų langas
                    Console.WriteLine("\nAtidaromas ataskaitos kurimo langas");
                    driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/pim/definePredefinedReport");
                    Thread.Sleep(3000);

                    // Ataskaitos pavadinimas
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div/div/div[2]/input")).SendKeys("Testine ataskaitaaa");
                    // Priskiriami 2 kriterijai
                    for (int i = 0; i < 2; i++)
                    {
                        veiksmai.PasirinkimoLangelis(driver, "//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[1]/div[1]/div[2]/div/div/div[2]/i", 1);
                        driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[1]/div[2]/div[2]/button")).Click();
                        Thread.Sleep(1000);
                    }
                    Console.WriteLine("\nKriterijai prideti");

                    // Istrinti kriterijus
                    for (int i = 0; i < 2; i++)
                    {
                        driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[3]/button")).Click();
                        Thread.Sleep(1000);
                    }
                    Console.WriteLine("\nKriterijai istrinti");

                    // Pazymeti įtraukti
                    veiksmai.PasirinkimoLangelis(driver, "//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[2]/div/div[2]/div/div/div[2]/i", 2);
                    Console.WriteLine("Pasirinktas įtrauktis");
                    Thread.Sleep(2000);

                    // Pridedami stulpeliai Personal
                    IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
                    int div = 5;
                    int scroll = 150;
                    for (int i = 0; i < 4; i++)
                    {
                        veiksmai.PasirinkimoLangelis(driver, "//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[3]/div/div[1]/div/div[2]/div/div", i + 1);
                        Thread.Sleep(1000);
                        for (int j = 0; j < 4; j++)
                        {
                            veiksmai.PasirinkimoLangelis(driver, "//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[3]/div/div[2]/div[1]/div[2]/div/div/div[2]/i", 1);
                            driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[3]/div/div[2]/div[2]/div[2]/button")).Click();
                            Thread.Sleep(1000);
                        }
                        driver.FindElement(By.XPath($"//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[3]/div/div[{div}]/div/label/span")).Click();
                        div += 3;
                        jsExecutor.ExecuteScript($"window.scrollTo(0, {scroll});");
                        scroll += 100;
                        Thread.Sleep(1000);
                    }
                    Console.WriteLine("\nStulpeliai prideti");
                    Thread.Sleep(2000);

                    // Istrinti stulpeli is kiekvienos grupes
                    div = 4;
                    for (int i = 0; i < 4; i++)
                    {
                        driver.FindElement(By.XPath($"//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[3]/div/div[{div}]/div/span[4]/i")).Click();
                        div += 3;
                        Thread.Sleep(1000);
                    }
                    Console.WriteLine("\nStulpeliai istrinti");
                    Thread.Sleep(2000);

                    // Istrinti grupe
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[3]/div/div[12]/button")).Click();
                    Console.WriteLine("\nGrupė ištrinta");
                    Thread.Sleep(5000);

                    // Issaugoti ataskaita
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/form/div[4]/button[2]")).Click();
                    Console.WriteLine("\nAtaskaita issaugota");
                    Thread.Sleep(5000);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nTestas atliktas. Ataskaita sukurta.");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nKlaida: {ex.Message}");
            }
            finally
            {
                Console.ResetColor();
            }
        }
    }
}
