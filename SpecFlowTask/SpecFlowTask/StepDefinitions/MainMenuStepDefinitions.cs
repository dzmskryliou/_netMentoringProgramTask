using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using SpecFlowTask.Core;
using SpecFlowTask.Drivers;
using SpecFlowTask.Pages;

namespace SpecFlowTask.StepDefinitions
{
    [Binding]
    public sealed class MainMenuStepDefinitions
    {


        [Given("I open official SpecFlow web site")]
        public static void OpenTheHomePage()
        {
            var basePage = new BasePage();
            var homePage = new HomePage();
            
            basePage.Open("https://specflow.org/");
            basePage.MaximizeTheWindow();
            homePage.AcceptCookies();
        }


        [When("I hover the menu item from the main menu")]
        public static void HoverMenuItem()
        {


            var mainMenu = new MainMenu();

            mainMenu.HoveringMenu();
        }

        [When("I click subMenuIte option from the main menu")]

        public static void ClickSubmenuItem()
        {

            var mainMenu = new MainMenu();

            mainMenu.ClickingSubMenuItem();
        }

        [When("I click on the 'search docs' field")]

        public static void ClickSearchDocks()
        {

            var searchOption = new Search();

            searchOption.ClickingSearchDocsField();
        }

        [When("I type searchItem in the popup window")]

        public static void EnterSearchParam()
        {

            var searchOption = new Search();

            searchOption.SearchForItem("Installation");
        }

        [When("I select the searchItem result from the suggestions")]
        public static void OpenThePage()
        {
            var firstResultPage = WebDriverManager.Driver.FindElement(By.XPath("//div[@id = 'search-results']/ul/li[1]/a"));
            firstResultPage.Click();
        }

        [Then("Page with searchItem title should be opened")]
        public static void ThenTheResultShouldBe()
        {
            var basePage = new BasePage();

            basePage.PageLoadCheck("Installation");
        }
    }
}
