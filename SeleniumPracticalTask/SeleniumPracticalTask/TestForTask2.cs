using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPracticalTask
{
    public class TestsForTask2
    {

        [Test]
        public void Test1()
        {
            IWebDriver driver = new EdgeDriver();

            driver.Url = "https://www.epam.com";

            //maximize the window
            driver.Manage().Window.Maximize();

            //accept cookies
            var acceptButton = driver.FindElement(By.XPath("//button[@id = 'onetrust-accept-btn-handler']"));
            acceptButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(2))
            {
                PollingInterval = TimeSpan.FromSeconds(0.25),
                Message = "Cookies Banner has not been found"
            };

            //click search icon
            var searchIcon = driver.FindElement(By.ClassName("dark-iconheader-search__search-icon"));
            searchIcon.Click();

            var searchPanelWait = new WebDriverWait(driver, TimeSpan.FromSeconds(2))
            {
                PollingInterval = TimeSpan.FromSeconds(0.25),
                Message = "Search panel has not been found"
            };

            var searchPanel = searchPanelWait.Until(driver => driver.FindElement(By.ClassName("header-search__panel")));
            var searchInput = searchPanel.FindElement(By.Name("q"));

            //search for 'blockchain'
            var clickAndSendKeysActions = new Actions(driver);

            clickAndSendKeysActions.Click(searchInput)
                .Pause(TimeSpan.FromSeconds(1))
                .SendKeys("blockchain")
                .Perform();

            //click find button
            var findButton = searchPanel.FindElement(By.XPath("//div[@class='search-results__input-holder']/following-sibling::button"));
            findButton.Click();

            //validate that all links in a list contain the word 'blockchain'
            var elements = driver.FindElements(By.XPath("//a[contains(@href, 'blockchain')]"));
            System.Console.Write(elements.Count);
        }

        [Test]
        public void Test2()
        {
            IWebDriver driver = new EdgeDriver();

            driver.Url = "https://www.epam.com";

            //maximize the window
            driver.Manage().Window.Maximize();

            //accept cookies
            var acceptButton = driver.FindElement(By.XPath("//button[@id = 'onetrust-accept-btn-handler']"));
            acceptButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(2))
            {
                PollingInterval = TimeSpan.FromSeconds(0.25),
                Message = "Cookies Banner has not been found"
            };

            //click search icon
            var searchIcon = driver.FindElement(By.ClassName("dark-iconheader-search__search-icon"));
            searchIcon.Click();

            var searchPanelWait = new WebDriverWait(driver, TimeSpan.FromSeconds(2))
            {
                PollingInterval = TimeSpan.FromSeconds(0.25),
                Message = "Search panel has not been found"
            };

            var searchPanel = searchPanelWait.Until(driver => driver.FindElement(By.ClassName("header-search__panel")));
            var searchInput = searchPanel.FindElement(By.Name("q"));

            //search for 'cloud'
            var clickAndSendKeysActions = new Actions(driver);

            clickAndSendKeysActions.Click(searchInput)
                .Pause(TimeSpan.FromSeconds(1))
                .SendKeys("cloud")
                .Perform();

            //click find button
            var findButton = searchPanel.FindElement(By.XPath("//div[@class='search-results__input-holder']/following-sibling::button"));
            findButton.Click();

            //validate that all links in a list contain the word 'cloud'
            var elements = driver.FindElements(By.XPath("//a[contains(@href, 'cloud')]"));
            System.Console.Write(elements.Count);
        }

        [Test]

        public void Test3()
        {
            IWebDriver driver = new EdgeDriver();

            driver.Url = "https://www.epam.com";

            //maximize the window
            driver.Manage().Window.Maximize();

            //accept cookies
            var acceptButton = driver.FindElement(By.XPath("//button[@id = 'onetrust-accept-btn-handler']"));
            acceptButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(2))
            {
                PollingInterval = TimeSpan.FromSeconds(0.25),
                Message = "Cookies Banner has not been found"
            };

            //click search icon
            var searchIcon = driver.FindElement(By.ClassName("dark-iconheader-search__search-icon"));
            searchIcon.Click();

            var searchPanelWait = new WebDriverWait(driver, TimeSpan.FromSeconds(2))
            {
                PollingInterval = TimeSpan.FromSeconds(0.25),
                Message = "Search panel has not been found"
            };

            var searchPanel = searchPanelWait.Until(driver => driver.FindElement(By.ClassName("header-search__panel")));
            var searchInput = searchPanel.FindElement(By.Name("q"));

            //search for 'automation'
            var clickAndSendKeysActions = new Actions(driver);

            clickAndSendKeysActions.Click(searchInput)
                .Pause(TimeSpan.FromSeconds(1))
                .SendKeys("automation")
                .Perform();

            //click find button
            var findButton = searchPanel.FindElement(By.XPath("//div[@class='search-results__input-holder']/following-sibling::button"));
            findButton.Click();

            //validate that all links in a list contain the word 'automation'
            var elements = driver.FindElements(By.XPath("//a[contains(@href, 'automation')]"));
            System.Console.Write(elements.Count);
        }
    }
}
