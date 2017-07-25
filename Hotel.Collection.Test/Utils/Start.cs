using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Hotel.Framework.Utils;
using Hotel.Framework.Helper;

namespace Hotel.Collection.Test.Utils
{
    [Binding]
    public class Start : Driver
    {
        Objects ob = null;

        [BeforeScenario()]
        public void setUp()
        {
            StepDefinationInitialise();

            ob = new Objects(browser.driver,browser.iWait);
           
            ob.ObjectInitialisation();

            Navigate("https://www.thehotelcollection.co.uk/");

            HelperCommon.IsJqueryActive(browser.driver);
        }

        [AfterScenario]
        public void TearDown()
        {
            Close();
        }

        [AfterScenario(Order = 1)]
        [Scope(Tag = "hooksExample")]
        public static void LogoutUser()
        {
            System.Console.WriteLine("Execute AfterScenario- LogoutUser");
            // Logout the user
        }
    }
}

