using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace PageObject.Pages;

public class IndexPage
{
    private static string Url { get; } = "https://www.epam.com";

    private readonly IWebDriver driver;

    public IndexPage(IWebDriver driver) => this.driver = driver ?? throw new ArgumentException(nameof(driver));

    public IndexPage Open()
    {
        driver.Url = Url;
        return this;
    }

    public void InitialActions()
    {
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

        var acceptButton = driver.FindElement(By.XPath("//button[@id = 'onetrust-accept-btn-handler']"));
        acceptButton.Click();
    }

    public void Search(string phrase)
    {
        var searchIcon = driver.FindElement(By.ClassName("dark-iconheader-search__search-icon"));
        searchIcon.Click();

        var searchPanelWait = new WebDriverWait(driver, TimeSpan.FromSeconds(2))
        {
            PollingInterval = TimeSpan.FromSeconds(0.25),
            Message = "Search panel has not been found"
        };

        var searchPanel = searchPanelWait.Until(driver => driver.FindElement(By.ClassName("header-search__panel")));
        var searchInput = searchPanel.FindElement(By.Name("q"));

        var clickAndSendKeysActions = new Actions(driver);

        clickAndSendKeysActions.Click(searchInput)
            .Pause(TimeSpan.FromSeconds(1))
            .SendKeys(phrase)
            .Perform();

        var findButton = searchPanel.FindElement(By.XPath("//div[@class='search-results__input-holder']/following-sibling::button"));
        findButton.Click();

    }

    public void ClickNavLink(string link)
    {
        driver.FindElement(By.XPath(link)).Click();
    }

    public void KeyWordOrLanguage(string programmingLanguage)
    {
        driver.FindElement(By.Id("new_form_job_search-keyword")).Clear();

        var searchKey = driver.FindElement(By.Id("new_form_job_search-keyword"));
        var clickAndSendKeysActions = new Actions(driver);

        clickAndSendKeysActions.Click(searchKey)
            .Pause(TimeSpan.FromSeconds(1))
            .SendKeys(programmingLanguage)
            .Perform();
    }
    public void SelectLocation()
    {      
        var expandDropdown = driver.FindElement(By.XPath("//form/div[@class ='recruiting-search__column']/div[@class = 'recruiting-search__location']"));
        expandDropdown.Click();

        IWebElement AllLocations = driver.FindElement(By.XPath("//div[@class = 'os-content']//li[@title = 'All Locations']"));
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

        driver.FindElement(By.XPath("//div[@class = 'os-content']//li[@title = 'All Locations']"));
        wait.Until(d => AllLocations.Displayed);

        AllLocations.Click();
    }

    public void SelectRemote()
    {
        var selectRemote = driver.FindElement(By.XPath("//p[@class = 'job-search__filter-items job-search__filter-items--remote']"));
        selectRemote.Click();
    }

    public void SubmitSearchForm()
    {
        var clickFind = driver.FindElement(By.XPath("//form[@id = 'jobSearchFilterForm']/button"));
        clickFind.Click();
    }

    public void SortTheResultsByDate()
    {
        var sortByDate = driver.FindElement(By.XPath("//label[@class = 'search-result__sorting-label list']"));
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        sortByDate.Click();
    }

    public void SelectLatestOpportunity()
    {
        var latestOpportunity = driver.FindElement(By.XPath("//li[1]/descendant::div[@class = 'search-result__item-controls']/a"));
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        latestOpportunity.Click();
    }

    public void ProgrammingLanguageMentioned()
    {
        var TextOnThePage = driver.FindElement(By.XPath("//*[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '.net')]"));
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        System.Console.WriteLine("The text is on the page");
    }

    public void TextInLinkCount(string partOfLink)
    {
        var elements = driver.FindElements(By.XPath(partOfLink));
        System.Console.Write(elements.Count);
    }

    public void ClickNextSlideBtn()
    {
        var clickNextBtn = driver.FindElement(By.XPath("//button[@class = 'slider__right-arrow slider-navigation-arrow']"));
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        clickNextBtn.Click();

    }

    public void DownloadTheFile()
    {
        var downloadButton = driver.FindElement(By.XPath("//a[@class = 'button-ui-23 btn-focusable'][1]"));
        downloadButton.Click();
    }

    public void OpenLocalInstance()
    {
        driver.SwitchTo().NewWindow(WindowType.Tab);
        driver.Navigate().GoToUrl("file:///C:/Users/Dzmitry_Skryliou/Downloads/");
    }

    public void FindDownloadedFile()
    {
        var downloadedElement = driver.FindElement(By.XPath("//a[contains(@href, 'EPAM_Corporate_Overview_Q4_EOY')]"));
        Console.WriteLine("Document was downloaded");
    }

    public void ClickReadMoreOnSlider()
    {
        var clickReadMore = driver.FindElement(By.XPath("//div[@class = 'owl-item active']//a[@class = 'custom-link link-with-bottom-arrow color-link body-text font-900 slider-cta-link']"));
        clickReadMore.Click();
    }

    public void FindTextInTitle(string textToFind)
    {
        var element = driver.FindElement(By.XPath($"//p/span/span[@class='museo-sans-light' and contains(text(), '{textToFind}')]"));
        System.Console.WriteLine("Article does not contain text from the slider title");
    }

    public void FinishTheTest()
    {
        driver.Quit();
    }
}