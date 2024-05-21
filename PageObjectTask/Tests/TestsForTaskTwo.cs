using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using PageObject.Pages;

namespace Tests
{
    public class TestsForTaskTwo
    {

       [Test]

        [TestCase("blockchain")]
        [TestCase("cloud")]
        [TestCase("automation")]
            public void CompareTest(string a)
        {
            IWebDriver driver = new EdgeDriver();
            var indexPage = new IndexPage(driver);
            indexPage.Open().InitialActions();
            indexPage.Search(a);
            indexPage.TextInLinkCount($"//a[contains(@href, '{a}')]");
            indexPage.FinishTheTest();
        }
    }
}
