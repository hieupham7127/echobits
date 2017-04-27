using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Net;


namespace FbController2 {
    class WebDriver {
        #region [Webdriver's Basic Settings]
        public IWebDriver driver;

        public WebDriver() {
            ChangeBrowser("", "");
        }
        public WebDriver(String s) {
            ChangeBrowser(s, @"C:\Libraries\");
        }

        public WebDriver(String s, String link) {
            ChangeBrowser(s, link);
        }

        public void OpenWebsite(string link) {
            driver.Url = link;
            //driver.Manage().Window.Maximize();
        }

        public void ChangeBrowser(String s, String link) {
            // need downloading for other browsers except Firefox            
            driver = null;
            try {
                // Selenium WebDriver version provided needs to be runable with current version of Web Browser
                // Ex: Selenium WebDriver 2.45.0 for Firefox 36.0
                if (s.ToLower().Contains("firefox")) driver = new FirefoxDriver();
                else if (s.ToLower().Contains("chrome")) driver = new ChromeDriver(link);
                else if (s.ToLower().Contains("ie")) driver = new InternetExplorerDriver(link);
                else driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), DesiredCapabilities.Firefox());
            }
            catch (WebException e) {
                driver = new FirefoxDriver();
                throw (e);
            }
        }

        public void CloseBroswer() {
            driver.Close();
        }
        #endregion

        #region [Email's Implementation]
        public void GmailLogIn(string id, string pass) {
            driver.Url = "http://gmail.com";

            // Automatically sign in into gmail
            var input = driver.FindElement(By.Id("Email"));
            input.SendKeys(id);

            var password = driver.FindElement(By.Id("Passwd"));
            password.SendKeys(pass);

            var btSignIn = driver.FindElement(By.Id("signIn"));
            btSignIn.Click();
        }
        #endregion
    }

    #region [Google Tools]
    class GoogleTools {
        private WebDriver browser;
        private IWebDriver driver;
        private string information;
        private string section;

        public GoogleTools() {
            this.browser = new WebDriver();
            this.driver = browser.driver;
            browser.OpenWebsite("http://google.com");
            information = null;
            section = null;
        }

        public GoogleTools(WebDriver browser) {
            this.browser = browser;
            this.driver = browser.driver;
            information = null;
            section = null;
        }

        public void setInformation(string information) {
            this.information = information;
        }

        public string getInformation() {
            return information;
        }

        public void setSection(string section) {
            this.section = section;
        }

        public string getSection() {
            return section;
        }

        public bool ChoosingSection() {
            var sections = driver.FindElements(By.CssSelector("a.q.qs"));

            for (int i = 0; i < sections.Count; i++)
                if (sections[i].Text.Equals(section)) {
                    /*          
                    sections[i].Click();
                    cannot execute and will encounter Error : element is not clickable                                         
                    Solution
                        * 1. Try to Click on the parent element instead.                   
                        * 2. Try .Submit() instead of .Click()
                        * 3. Try to execute the JavaScript that will be executed on the OnClick event of the element you are trying to click.                     
                        * 4. Try .SendKeys(Key.Enter) instead
                    */
                    sections[i].SendKeys(Keys.Enter);
                    return true;
                }
            /* click first image
            var gallery = driver.FindElement(By.Id("rg_s"));
            var image = gallery.FindElements(By.TagName("a"))[0];
            image.Click();
            */
            return false;
        }

        public void SearchInformation() { // accurate section "Web", "Video", "Images",...
            //driver.Url = "http://google.com";
            // type plural sight into search box of Google.com
            var searchBox = driver.FindElement(By.Id("lst-ib")); // ID of search box gbqfq
            searchBox.SendKeys(information);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10)); // the elements don't exist yet because of connecting time       
            /* another way
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var sections = wait.Until(d => {
                                return driver.FindElements(By.CssSelector("a.q.qs"));
                            });*/

            var btSearch = driver.FindElement(By.Name("btnG")); // ID of search button lsb
            btSearch.Click();
        }
    }
    #endregion
}