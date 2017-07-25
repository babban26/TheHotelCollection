using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Framework.Helper;
using OpenQA.Selenium.Support.Events;
using Hotel.Framework.Browsers;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;


namespace Hotel.Framework.Utils
{
   public class BrowserInit
    {
        public IWebDriver driver;
        internal string driverName = string.Empty;
        internal string driverPath = string.Empty;
        public IWait<IWebDriver> iWait = null;
        int screenHeight, screenWidth;
        BrowsersSelection browser = new BrowsersSelection();


        public BrowserInit()
        {

            try
            {
                string rootPath = AppDomain.CurrentDomain.BaseDirectory;  //Environment.CurrentDirectory;  

                if (Convert.ToBoolean(browser.SelectBrowser(BrowserCollection.firefox.ToString(), "BrowserSelection.xml")) == true)
                {
                   // driver = new FirefoxDriver(new FirefoxBinary(@"C:\Program Files\Mozilla Firefox\firefox.exe"), new FirefoxProfile());

                    driver = new FirefoxDriver();

                    String BrowserName = BrowserCollection.firefox.ToString();

                   
                    screenHeight = HelperCommon.GetScreenHeight(driver);

                    screenWidth = HelperCommon.GetScreenWidth(driver);

                    HelperCommon.SetWindowPosition(driver, 0, 0);

                    HelperCommon.SetWindowSize(driver, screenWidth, screenHeight);

                }
                else if (Convert.ToBoolean(browser.SelectBrowser(BrowserCollection.chrome.ToString(), "BrowserSelection.xml")) == true)
                {
                   // driverPath = rootPath + "\\chromedriver.exe";
                    driverPath = rootPath;
                    driverName = "webdriver.chrome.driver";

                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--disable-extensions");
                    //System.Environment.SetEnvironmentVariable(driverName, driverPath);
                    driver = new ChromeDriver(driverPath, options);  //driver = new ChromeDriver(baseDir + "\\DLLs");

                    HelperCommon.EventFire ef = new HelperCommon.EventFire(driver);
                    driver = ef;
                   
                    String BrowserName = BrowserCollection.chrome.ToString();

                    screenHeight = HelperCommon.GetScreenHeight(driver);

                    screenWidth = HelperCommon.GetScreenWidth(driver);

                    HelperCommon.SetWindowPosition(driver, 0, 0);

                    HelperCommon.SetWindowSize(driver, screenWidth, screenHeight);

                    Console.WriteLine("Is Driver null :: " + (driver == null));

                    iWait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));



                }
                else if (Convert.ToBoolean(browser.SelectBrowser(BrowserCollection.ie.ToString(), "BrowserSelection.xml")) == true)
                {
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    options.EnsureCleanSession = true;
                    options.EnableNativeEvents = true;
                    options.IgnoreZoomLevel = true;
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    driverName = "webdriver.ie.driver";
                    driverPath = rootPath + "/IEDriverServer.exe";

                    driver = new InternetExplorerDriver(options);
                    screenHeight = HelperCommon.GetScreenHeight(driver);

                    screenWidth = HelperCommon.GetScreenWidth(driver);

                    HelperCommon.SetWindowPosition(driver, 0, 0);

                    HelperCommon.SetWindowSize(driver, screenWidth, screenHeight);

                    String BrowserName = BrowserCollection.ie.ToString();

                    // Add code to add Registry in IE 11
                    String IEVersion = HelperCommon.GetIEVersion(driver, driver.FindElement(By.TagName("html")));

                    if (IEVersion.Equals("IE11"))
                        HelperCommon.CheckIE11RegistryPresence();

                }
                else if (Convert.ToBoolean(browser.SelectBrowser(BrowserCollection.phantom.ToString(), "BrowserSelection.xml")) == true)
                {

                    driver = new PhantomJSDriver();

                    String BrowserName = BrowserCollection.phantom.ToString();

                    screenHeight = HelperCommon.GetScreenHeight(driver);

                    screenWidth = HelperCommon.GetScreenWidth(driver);

                    HelperCommon.SetWindowPosition(driver, 0, 0);

                    HelperCommon.SetWindowSize(driver, screenWidth, screenHeight);

                }
                else
                    throw new NoBrowserSelectedException();


                iWait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(60.00));

            }
            catch (NoBrowserSelectedException ex)
            {
                Logger.log.Error("Error In Browser Selection.");
                Logger.log.Error(ex);
            }
            catch (Exception ex)
            {
                Logger.log.Error("Error In Browser Initialization.");
                Logger.log.Error(ex);
            }




        }

        public class NoBrowserSelectedException : Exception
        {
            public override String Message
            {
                get
                {
                    return "Please select any browser by setting flag in Base.Config file as true";
                }
            }
        }

    }
}
