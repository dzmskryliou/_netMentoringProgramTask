using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPracticalTask
{

    public class TestsForTask1
    {
        [Test]
        public void Test1()
        {
            IWebDriver driver = new EdgeDriver();

            driver.Url = "https://www.epam.com";

            //maximize the window
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            //accept cookies
            var clickTheButton = driver.FindElement(By.XPath("//button[@id = 'onetrust-accept-btn-handler']"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            clickTheButton.Click();

            //click on Careers link
            driver.FindElement(By.XPath("//a[@class = 'top-navigation__item-link js-op'][@href='/careers']")).Click();

            // clear field to empty it from any previous data 
            driver.FindElement(By.Id("new_form_job_search-keyword")).Clear();

            //enter keyword or job Id
            driver.FindElement(By.Id("new_form_job_search-keyword")).SendKeys(".net");

            //select all locations       
            var expandDropdown = driver.FindElement(By.XPath("//form/div[@class ='recruiting-search__column']/div[@class = 'recruiting-search__location']"));
            expandDropdown.Click();

            IWebElement AllLocations = driver.FindElement(By.XPath("//div[@class = 'os-content']//li[@title = 'All Locations']"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

            driver.FindElement(By.XPath("//div[@class = 'os-content']//li[@title = 'All Locations']"));
            wait.Until(d => AllLocations.Displayed);

            AllLocations.Click();

            //select 'remote checkbox
            var selectRemote = driver.FindElement(By.XPath("//p[@class = 'job-search__filter-items job-search__filter-items--remote']"));
            selectRemote.Click();

            //submit the form
            var clickFind = driver.FindElement(By.XPath("//form[@id = 'jobSearchFilterForm']/button"));
            clickFind.Click();

            //sort the opportunities by date
            var sortByDate = driver.FindElement(By.XPath("//label[@class = 'search-result__sorting-label list']"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            sortByDate.Click();

            //select the latest opportunity
            var latestOpportunity = driver.FindElement(By.XPath("//li[1]/descendant::div[@class = 'search-result__item-controls']/a"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            latestOpportunity.Click();

            //Validate that the programming language mentioned in the step above is on a page


            //var enteredText = driver.FindElements(By.XPath("//*[contains(text(), '.Net') | ]"));
            var TextOnThePage = driver.FindElement(By.XPath("//*[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '.net')]"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            System.Console.WriteLine("The text is on the page");
        }
    }
}
