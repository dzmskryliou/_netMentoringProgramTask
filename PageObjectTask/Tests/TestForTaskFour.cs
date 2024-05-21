using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using PageObject.Pages;
using System.Threading;

namespace Tests
{

    public class TestsForTaskFour
    {
        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();

            var indexPage = new IndexPage(driver);
            indexPage.Open().InitialActions();
            indexPage.ClickNavLink("//a[@class = 'top-navigation__item-link js-op'][@href='/insights']");
            indexPage.ClickNextSlideBtn();
            indexPage.ClickNextSlideBtn();
            indexPage.ClickReadMoreOnSlider();
            indexPage.FindTextInTitle("Three Ways Leaders Impede Their Company’s");
            indexPage.FinishTheTest();


        }
    }
}