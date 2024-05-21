using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SpecFlowTask.Drivers;

namespace SpecFlowTask.Pages

{
    public class PageObjects
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

        public void AcceptCookies()
        {
            var acceptCookies = driver.FindElement(By.XPath("//button[@id = 'consent-accept']"));
            acceptCookies.Click();
        }

        public void HoveringMenu()
        {
            var navMenu = driver.FindElement(By.XPath("//li[@class= 'menu-item menu-item-type-custom menu-item-object-custom menu-item-has-children']"));
            Actions action = new Actions(driver);
            action.MoveToElement(navMenu).Perform();
        }

        public void ClickingSubMenuItem()
        {
            var subMenuItem = driver.FindElement(By.XPath("//li[@id = 'menu-item-1067']/a"));
            subMenuItem.Click();
        }

        public void ClickingSearchDocsField()
        {
            var searchDocksPanel = driver.FindElement(By.XPath("//form[@id = 'rtd-search-form']/input"));
            searchDocksPanel.Click();
        }


        public void SearchForItem(string searchItem)
        {
            driver.FindElement(By.XPath("//input[@class = 'search__outer__input']")).SendKeys(searchItem + Keys.Enter);
        }

        public void SelectFirstItem()
        {
            var firstResultPage = driver.FindElement(By.XPath("//div[@id = 'search-results']/ul/li[1]/a"));
            firstResultPage.Click();
            Console.WriteLine("The link is opened");
        }

        public void PageLoadCheck(string pageTitle)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(5))
    .Until(driver => driver.Title.Contains(pageTitle));
           
        }
    }
}
