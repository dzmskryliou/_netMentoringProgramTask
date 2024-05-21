using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using PageObject.Pages;
using System.Reflection.Metadata;

namespace Tests
{

    public class TestsForTaskThree
    {
        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();

            var indexPage = new IndexPage(driver);
            indexPage.Open().InitialActions();
            indexPage.ClickNavLink("//a[@class = 'top-navigation__item-link js-op'][@href='/about']");
            indexPage.DownloadTheFile();
            indexPage.OpenLocalInstance();
            indexPage.FindDownloadedFile();
            indexPage.FinishTheTest();

        }
    }
}