using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SpecFlowTask.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowTask.Core
{
    public class BasePage   
    {
        private readonly EdgeDriver driver = WebDriverManager.Driver;
        public void Open(string Url)
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void MaximizeTheWindow()
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        public void PageLoadCheck(string pageTitle)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(5))
    .Until(driver => driver.Title.Contains(pageTitle));

        }
    }
}
