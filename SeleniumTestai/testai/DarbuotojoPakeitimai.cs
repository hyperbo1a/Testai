using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestai.testai
{
    public class DarbuotojoPakeitimai
    {
        Functions veiksmai = new Functions();
        public void AtnaujintiDarbuotoją(string userURL)
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                try
                {
                    Random random = new Random();
                    // Atidaromas OrangeHRM ir prisigiama
                    veiksmai.PrisijungimasPrieOrangeHRM(driver, "https://opensource-demo.orangehrmlive.com/", "Admin", "admin123");

                    // Atidaroma darbuotojo asmeninis puslapis
                    Console.WriteLine("\nAtidaromas darbuotojo duomenų puslapis");
                    driver.Navigate().GoToUrl(userURL);
                    Thread.Sleep(3000);

                    // Pakeičiame darbuotojo asmeninius duomenis
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[1]/form/div[2]/div[1]/div[2]/div/div[2]/input")).SendKeys($"{random.Next(1, 100)}");
                    
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[1]/form/div[2]/div[2]/div[1]/div/div[2]/input")).SendKeys($"{random.Next(100000, 999999)}");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[1]/form/div[2]/div[2]/div[2]/div/div[2]/div/div/input")).SendKeys("2020-10-17");

                    veiksmai.PasirinkimoLangelis(driver, "//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[1]/form/div[3]/div[1]/div[1]/div/div[2]/div/div", 5);
                    veiksmai.PasirinkimoLangelis(driver, "//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[1]/form/div[3]/div[1]/div[2]/div/div[2]/div/div", 1);
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[1]/form/div[3]/div[2]/div[1]/div/div[2]/div/div/input")).SendKeys("2009-12-29");

                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[1]/form/div[3]/div[2]/div[2]/div/div[2]/div[1]/div[2]/div/label")).Click();


                    Console.WriteLine("\nDarbuotojo duomenys pakeisti");
                    Thread.Sleep(2000);

                    // Papildomi laukeliai
                    veiksmai.PasirinkimoLangelis(driver, "//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[2]/div/form/div[1]/div/div[1]/div/div[2]/div/div", 1);
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[2]/div/form/div[2]/button")).Click();
                    Console.WriteLine("\nPapildomi laukeliai pakeisti");
                    Thread.Sleep(2000);

                    // Pridedami du failai 
                    for (int i = 0; i <= 1; i++)
                    {
                        driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/div/div[2]/div[3]/div[1]/div/button")).Click();
                        Thread.Sleep(10000);
                        driver.FindElement(By.CssSelector("input[type='file']")).SendKeys("C:\\Users\\sinke\\Downloads\\spriteee.PNG");
                        Thread.Sleep(10000);
                        driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/div/div[2]/div[3]/div/form/div[3]/button[2]")).Click();
                        Thread.Sleep(10000);
                    }
                    Thread.Sleep(2000);
                    Console.WriteLine("\nFailai pridėti");

                    // Atnaujinti informacija apie faila
                    int count = 0;
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[3]/div[3]/div/div[2]/div[1]/div/div[8]/div/button[1]")).Click();
                    Thread.Sleep(3000);
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[3]/div/form/div[3]/div/div/div/div[2]/textarea")).SendKeys("Atnaujintas");
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[3]/div/form/div[4]/button[2]")).Click();
                    Console.WriteLine("\nInformacija apie failą atnaujinta");
                    Thread.Sleep(3000);
                    count++;

                    // Istrinti faila
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[3]/div[3]/div/div[2]/div[2]/div/div[8]/div/button[2]")).Click();
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[3]/div/div/div/div[3]/button[2]")).Click();
                    Console.WriteLine("Failas istrintas");
                    Thread.Sleep(3000);
                    count++;

                    // Atsiusti faila
                    driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div/div/div/div[2]/div[3]/div[3]/div/div[2]/div[1]/div/div[8]/div/button[3]")).Click();
                    string downloadFileName = "spriteee.PNG";
                    int waitTime = 10;
                    bool fileExists = veiksmai.WaitForFile("C:\\Users\\sinke\\Downloads", downloadFileName, waitTime);
                    if (fileExists)
                    {
                        Console.WriteLine("Failas atsiustas");
                        count++;
                    }
                    else
                    {
                        Console.WriteLine("Filas nerastas.");
                    }

                    // Rezultatas
                    if (count == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nTestas atliktas. Darbuotojo informacija atnaujinta.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nTestas nepavyko. Darbuotojo informacija nebuvo atnaujinta.");
                    }
                    Thread.Sleep(3000);
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
}
