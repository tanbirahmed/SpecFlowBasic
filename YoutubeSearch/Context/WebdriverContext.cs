using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace YoutubeSearch.Context
{
    public class WebdriverContext
    {
        public ChromeDriver driver; //decalre chrome driver object

        public WebdriverContext()  //decalare a constructor to initalize this object
        {
            driver = new ChromeDriver(); //POCO object for webdriver
        } 
    }
}
