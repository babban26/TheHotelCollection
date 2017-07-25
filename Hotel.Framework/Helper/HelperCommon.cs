using Hotel.Framework.Utils;
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hotel.Framework.Helper
{
    public class HelperCommon
    {
        // This function returns screen height 
        public static int GetScreenHeight(IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            return Int32.Parse(js.ExecuteScript("return screen.height").ToString());
        }

        // This function returns screen width 
        public static int GetScreenWidth(IWebDriver driver)
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            return Int32.Parse(js.ExecuteScript("return screen.width").ToString());
        }

        public static void SetWindowPosition(IWebDriver driver, int xCordinate, int yCordinate)
        {
            driver.Manage().Window.Position = new System.Drawing.Point(xCordinate, yCordinate);
        }

        public static void SetWindowSize(IWebDriver driver, int width, int height)
        {
            driver.Manage().Window.Size = new Size(width, height);
        }

        //This function will wait for the javascript function execution
        public static Boolean IsJavaScriptActive(IWebDriver driver)
        {
            Boolean javaScriptIsComplete = false;
            for (int i = 1; i <= 60; i++)
            {
                String state = ((IJavaScriptExecutor)driver).ExecuteScript(@"return document.readyState").ToString();
                javaScriptIsComplete = state.Equals("complete", StringComparison.InvariantCultureIgnoreCase) || state.Equals("loaded", StringComparison.InvariantCultureIgnoreCase);

                if (javaScriptIsComplete)
                {
                    break;
                }
                Thread.Sleep(1000);
            }
            return javaScriptIsComplete;

        }


        //This function will wait for the jQuery function execution
        public static Boolean IsJqueryActive(IWebDriver driver)
        {
            Boolean ajaxIsComplete = false;
            for (int i = 1; i <= 60; i++)
            {
                ajaxIsComplete = (bool)(driver as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0");
                if (ajaxIsComplete)
                {
                    break;
                }
                Thread.Sleep(1000);
            }
            return ajaxIsComplete;

        }


        // This function returns currently running browser
        public static string GetIEVersion(IWebDriver driver, IWebElement element)
        {
            // string result; 

            String currentIEVersion = null, ie10Result = null, ie11Result = null, ie9Result = null;

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            ie11Result = (string)js.ExecuteScript("return navigator.msMaxTouchPoints !== void 0", element).ToString().ToLower();

            ie10Result = (string)js.ExecuteScript("return navigator.appVersion.indexOf('MSIE 10')", element).ToString();

            ie9Result = (string)js.ExecuteScript("return navigator.appVersion.indexOf('MSIE 9')", element).ToString();

            if (ie11Result.Equals("true"))
            {
                currentIEVersion = "IE11";
            }
            else if (!ie10Result.Equals("-1"))
            {
                currentIEVersion = "IE10";
            }
            else if (!ie9Result.Equals("-1"))
            {
                currentIEVersion = "IE9";
            }

            return currentIEVersion;
        }

        // This functions checks if registry entry is present for IE11 on system otherwise set accordingly
        public static Boolean CheckIE11RegistryPresence()
        {

            Boolean regFlag = false;

            try
            {
                string bit64keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BFCACHE";  // FEATURE_BFCACHE subkey may or may not be present, and should be created if it is not present

                string bit32keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BFCACHE"; // FEATURE_BFCACHE subkey may or may not be present, and should be created if it is not present

                string bit64_32_ValueName = "iexplore.exe";

                RegistryKey bit64IE11 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BFCACHE");

                RegistryKey bit32IE11 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BFCACHE");

                if (Environment.Is64BitOperatingSystem)
                {

                    if (Registry.GetValue(bit64keyName, bit64_32_ValueName, null) == null)
                    {

                        // Create 64 bit registry for IE 11 with ValueName = iexplore.exe and Value = 0       

                        bit64IE11.SetValue(bit64_32_ValueName, 0);

                        regFlag = true;

                    }
                    else
                    {
                        regFlag = true;                 // Registry Entry already present
                    }

                }
                else
                {
                    if (Registry.GetValue(bit32keyName, bit64_32_ValueName, null) == null)
                    {

                        // Create 64 bit registry for IE 11 with ValueName = iexplore.exe and Value = 0

                        bit32IE11.SetValue(bit64_32_ValueName, 0);

                        regFlag = true;

                    }
                    else
                    {
                        regFlag = true;                 // Registry Entry already present
                    }
                }

                return regFlag;
            }
            catch (Exception e)
            {
                Logger.log.Error(e);
                return regFlag;
            }


        }

        public class EventFire : EventFiringWebDriver
        {
            // This is to configure logger mechanism for Utilities.Config
            private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            string preFindMethod = string.Empty;
            //event handler::::

            public EventFire(IWebDriver driver)
                : base(driver)
            {
                this.Navigating += new EventHandler<WebDriverNavigationEventArgs>(this.BeforeNavigating);
                this.Navigated += new EventHandler<WebDriverNavigationEventArgs>(this.AfterNavigate);
                this.ElementClicking += new EventHandler<WebElementEventArgs>(Click);
                this.FindingElement += new EventHandler<FindElementEventArgs>(FindElementOperation);

            }

            void BeforeNavigating(object sender, WebDriverNavigationEventArgs e)
            {
                log.Info("Before Navigating to ::::::::::::::::::::::::: " + e.Driver.Url);
            }

            public void AfterNavigate(object sender, WebDriverNavigationEventArgs e)
            {
                log.Info("Navigated to ::::::::::::::::::::::::: " + e.Driver.Url);

            }

            public void FindElementOperation(object sender, FindElementEventArgs e)
            {
                string currentFindMethod = e.FindMethod.ToString();

                if (!preFindMethod.Equals(currentFindMethod))
                    log.Info("Interacting with element  :::::::::::::::::::: " + e.FindMethod);

                preFindMethod = currentFindMethod;

            }

            public void Click(object sender, WebElementEventArgs e)
            {
                log.Info("Interacting with element with Text :::::::::::::::::::: " + e.Element.Text);

            }

        }
       
    }
}
