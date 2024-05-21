using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using SpecFlowTask.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowTask.Pages
{
    public class HomePage
    {
        private readonly EdgeDriver driver = WebDriverManager.Driver;

        public void AcceptCookies()
        {
            var acceptCookies = driver.FindElement(By.XPath("//button[@id = 'consent-accept']"));
            acceptCookies.Click();
        }
    }
}
