using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using PageObject.Pages;

namespace Tests
{

    public class TestsForTaskOne
    {
        [Test]
        public void Test1()
        {
            IWebDriver driver = new EdgeDriver();

            var indexPage = new IndexPage(driver);
            indexPage.Open().InitialActions();
            indexPage.ClickNavLink("//a[@class = 'top-navigation__item-link js-op'][@href='/careers']");
            indexPage.KeyWordOrLanguage(".net");
            indexPage.SelectLocation();
            indexPage.SelectRemote();
            indexPage.SubmitSearchForm();
            indexPage.SortTheResultsByDate();
            indexPage.SelectLatestOpportunity();
            indexPage.ProgrammingLanguageMentioned();
            indexPage.FinishTheTest();
        }
    }
}
