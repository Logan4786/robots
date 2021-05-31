using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace PjeApplication.entities
{
    public class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(Browser browser, string pathdriver, bool headlees){
            
            IWebDriver webDriver = null;

            switch(browser){
                case Browser.FIREFOX:
                    FirefoxOptions optFirefox = new FirefoxOptions();
                    if(headlees){
                        optFirefox.AddArgument("--headless");
                    }
                    webDriver = new FirefoxDriver(pathdriver, optFirefox);
                    break;
                case Browser.CHROME:
                    ChromeOptions optChrome = new ChromeOptions();
                    if(headlees){
                        optChrome.AddArgument("--headless");
                    }
                    webDriver = new ChromeDriver(pathdriver, optChrome);
                    break;
            }
            return webDriver;
        }
    }
}