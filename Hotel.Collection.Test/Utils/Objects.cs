using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Collection.Test.PageObject;

namespace Hotel.Collection.Test.Utils
{
    class Objects
    {

        IWebDriver driver = null;
        IWait<IWebDriver> wait = null;

        public Objects(IWebDriver driver, IWait<IWebDriver> wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        
        ~Objects()
        {
        }

        public static Page_Object_HotelBooking poHotelBooking;


        public void ObjectInitialisation()
        {
            poHotelBooking = new Page_Object_HotelBooking(driver, wait);
        }
    }
}
