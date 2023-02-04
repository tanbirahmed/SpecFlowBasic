using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SepcflowSelenium.StepDefinitions
{
    [Binding]
    public class YoutubeSearchFeatureSteps : IDisposable //used to remove unused resources
    {
        private String searchKeyword;

        private ChromeDriver chromeDriver;

        public YoutubeSearchFeatureSteps() => chromeDriver = new ChromeDriver();

        //Instantiate the chrome driver

        [Given(@"I have navigated to youtube website")]
        public void GivenIHaveNavigatedToYoutubeWebsite()
        {
            chromeDriver.Navigate().GoToUrl("https://www.youtube.com");
            //go to youtube using the URL
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains("youtube"));
            //verify if you are at youtube by checking the title to see if it contains youtube        
        }

        [Given(@"I have entered (.*) as search keyword")]
        public void GivenIHaveEnteredBangladeshAsSearchKeyword(String searchString)
        {
            this.searchKeyword = searchString.ToLower();
            // assigns search string from scenerio to the search keyword variable
            var searchInputBox = chromeDriver.FindElement(By.XPath("/html/body/ytd-app/div[1]/div/ytd-masthead/div[3]/div[2]/ytd-searchbox/form/div[1]/div[1]/input"));
            //find search box with full xpath and assign it to new variable
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/ytd-app/div[1]/div/ytd-masthead/div[3]/div[2]/ytd-searchbox/form/div[1]/div[1]")));
            //wait 2 seconds for the search box to render and see if search box is visible
            searchInputBox.SendKeys(searchKeyword);
            //send search keyword string to search inputbox
        }

        [When(@"I press the search button")]
                public void WhenIPressTheSearchButton()
{
                var searchButton = chromeDriver.FindElement(By.CssSelector("button#search-icon-legacy"));
                   //find the search button using the css selector. Xpath can also be used
                    searchButton.Click();
                    //click on the search button
}

        [Then(@"I should navigate to search results page")]
    public void ThenIShouldNavigateToSearchResultsPage()
    {

        System.Threading.Thread.Sleep(5000); //pause thread for 5 seconds
        // After search is complete the keyword should be present in url as well as page title`
        Assert.IsTrue(chromeDriver.Url.ToLower().Contains(searchKeyword));
        Assert.IsTrue(chromeDriver.Title.ToLower().Contains(searchKeyword));

        
        }


    public void Dispose()
    {
          if (chromeDriver != null)
        {
            chromeDriver.Dispose();
            chromeDriver = null;
        }
    }
}
}