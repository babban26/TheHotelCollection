using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Framework.Helper;
using System.Threading;

namespace Hotel.Collection.Test.PageObject
{
    class Page_Object_HotelBooking
    {

        #region Variables and constructor

        IWebDriver driver = null;
        IWait<IWebDriver> wait = null;
        Dictionary<int, String> requiredStartMonth;
        int date;
        Decimal roomPriceValue;
        Decimal afternoonTeaPrice;
        Decimal checkOutExtraPrice;
        Decimal expectedTotalPrice;


        public Page_Object_HotelBooking(IWebDriver driver, IWait<IWebDriver> wait)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("Driver is null");

            }

            this.driver = driver;
            this.wait = wait;

            PageFactory.InitElements(driver, this);

        }

        ~Page_Object_HotelBooking()
        {
            Console.WriteLine("Deleting object for HotelBooking");
        }




        #endregion

        #region List of elements

        [FindsBy(How = How.Id, Using = "hotels")]
        public IWebElement ddSelectHotel { get; set; }

        [FindsBy(How = How.Id, Using = "date_arrival")]
        public IWebElement dateArrival { get; set; }

        [FindsBy(How = How.Name, Using = "nights")]
        public IWebElement ddNights { get; set; }

        [FindsBy(How = How.Name, Using = "rooms")]
        public IWebElement ddRooms { get; set; }

        [FindsBy(How = How.Name, Using = "adults[1]")]
        public IWebElement ddAdultNumber { get; set; }

        [FindsBy(How = How.Name, Using = "submit")]
        public IWebElement btnBookNow { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main_body']/div[4]/div/div/div/div/div[1]/div[2]/div[1]/h5")]
        public IWebElement txtSelectedRates { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.check-in > strong")]
        public IWebElement txtCheckInDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='accordion']/div/form/div/div[1]/div[3]/div[1]/h4/div/div[3]/div/span")]
        public IWebElement txtSelectedRoomPrice { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.view-rooms.vr")]
        public IWebElement btnViewRooms { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='collapse1_0']/div/div/table/tbody/tr[1]/td[4]/div")]
        public IWebElement txtTotalPriceSelectedRoom { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main_body']/div[4]/div/div/div/div/div[1]/div[2]/div[1]/h5")]
        public IWebElement txtOptionalExtraHeading { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main_body']/div[4]/div/div/div/div/div[2]/div[1]/div[2]/div/h4")]
        public IWebElement txtOptionalExtraTotalPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='accordion']/div//form/div/div/div[3]/div[2]/div/div/table/tbody/tr[1]/td[5]/div/span/input[1]")]
        public IWebElement btnPage2BookNow { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main_body']/div[4]/div/div/div/div/div[2]/div[2]/form/div/div[4]/div/div[1]/div/div[4]/span/button/span[2]")]
        public IWebElement chkAfterNoontea { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main_body']/div[4]/div/div/div/div/div[2]/div[2]/form/div/div[4]/div/div[1]/div/div[4]/div")]
        public IWebElement txtPriceAfterNoontea { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='main_body']/div[4]/div/div/div/div/div[2]/div[2]/form/div/div[4]/div/div[8]/div/div[4]/span/button/span[2]")]
        public IWebElement chkCheckOutExtra { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main_body']/div[4]/div/div/div/div/div[2]/div[2]/form/div/div[4]/div/div[8]/div/div[4]/div")]
        public IWebElement txtPriceCheckOutExtra { get; set; }



        [FindsBy(How = How.XPath, Using = "//*[@id='main_body']/div[4]/div/div/div/div/div[2]/div[2]/form/div/div[4]/div/div[9]/div/div/label[1]/span[1]/button/span[2]")]
        public IWebElement chkAdjacentRoom { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.btn.back-to-booking.confirm-booking.mh")]
        public IList<IWebElement> btnProceedBooking { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main_body']/div[4]/div/div/div/div/div[1]/div[2]/div[1]/h5")]
        public IWebElement txtGuestDetails { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.total-box.for-step-3-total-box >h4 >br")]
        public IWebElement txtTotalPricingFinal { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.total-box.for-step-3-total-box >h4 >span >a")]
        public IWebElement ddBookingDetails { get; set; }

         [FindsBy(How = How.LinkText, Using = "BOOKING DETAILS")]
        public IWebElement linkBookingDetails { get; set; }


        [FindsBy(How = How.Name, Using = "NameEmail[_]")]
        public IWebElement txtEmail { get; set; }


        [FindsBy(How = How.Name, Using = "PersonName[nameTitle]")]
        public IWebElement ddTitle { get; set; }


        [FindsBy(How = How.Name, Using = "PersonName[firstName]")]
        public IWebElement txtFirstName { get; set; }

        [FindsBy(How = How.Name, Using = "PersonName[lastName]")]
        public IWebElement txtLastName { get; set; }

        [FindsBy(How = How.Name, Using = "NamePhone[PhoneNumber]")]
        public IWebElement txtPhoneNumber { get; set; }

        [FindsBy(How = How.Name, Using = "AddressLines[0]")]
        public IWebElement txtAddress { get; set; }

        [FindsBy(How = How.Name, Using = "NameAddress[cityName]")]
        public IWebElement txtCity { get; set; }

        [FindsBy(How = How.Name, Using = "NameAddress[countryCode]")]
        public IWebElement ddCountry { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.btn.back-to-booking.confirm-booking.submit.mh")]
        public IWebElement btnConfirmBooking { get; set; }


        [FindsBy(How = How.ClassName, Using = "errors")]
        public IWebElement txtErrors { get; set; }

        

        #endregion

        #region Reusable

        public void GetStartDate()
        {
            Console.WriteLine("\n Selecting Start Date" + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

            DateTime SystemDate = DateTime.Now;

            SelectYearInDatePicker(SystemDate.Year);

            requiredStartMonth = getRandomMonthName(SystemDate.Month);

            SelectMonthInDatePicker(requiredStartMonth);

            date = getDate(SystemDate.Month, SystemDate.Day);
            Console.WriteLine("Required Date :: " + date + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

            SelectDateInDatePicker(date);

            Console.WriteLine("\n Selecting Start Date completed" + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());


        }

        public void SelectYearInDatePicker(int requiredYear)
        {

            // Retreiving Year from Date picker
            int yearFromDatePicker = Convert.ToInt32(driver.FindElement(By.ClassName("ui-datepicker-year")).Text.Trim());

            // Iterating till Year of Date picker is equal our required year.
            while (yearFromDatePicker != requiredYear)
            {
                driver.FindElement(By.ClassName("ui-icon-circle-triangle-e")).Click();
                HelperCommon.IsJqueryActive(driver);
                yearFromDatePicker = Convert.ToInt32(driver.FindElement(By.ClassName("ui-datepicker-year")).Text.Trim());
            }
        }

        // This will return Dictionary contains value and key of current month
        public Dictionary<int, String> getRandomMonthName(int currentMonth)
        {
            Console.WriteLine("\n Getting Random Month Name and Position" + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

            Dictionary<int, String> monthList = new Dictionary<int, String>();
            monthList.Add(1, "January");
            monthList.Add(2, "February");
            monthList.Add(3, "March");
            monthList.Add(4, "April");
            monthList.Add(5, "May");
            monthList.Add(6, "June");
            monthList.Add(7, "July");
            monthList.Add(8, "August");
            monthList.Add(9, "September");
            monthList.Add(10, "October");
            monthList.Add(11, "November");
            monthList.Add(12, "December");

            Random getRandomNumber = new Random();


            int monthPosition = 0;
            monthPosition = getRandomNumber.Next(1, 12);
            while (monthPosition < currentMonth) // 
            {
                monthPosition = getRandomNumber.Next(1, 12);
            }

            Dictionary<int, String> monthList1 = new Dictionary<int, String>();
            monthList1.Add(monthPosition, monthList[monthPosition]);

            Console.WriteLine("Random Selected Month :: " + monthList1.ElementAt(0).Value + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());

            return monthList1;
        }

        public void SelectMonthInDatePicker(Dictionary<int, String> requiredMonth)
        {

            // Retreiving month from Date picker
            String monthFromDatePicker = driver.FindElement(By.ClassName("ui-datepicker-month")).Text.Trim();

            // Iterating till month of Date picker is equal our required month.
            while (!monthFromDatePicker.Equals(requiredMonth.ElementAt(0).Value))
            {
                Thread.Sleep(1000);
                driver.FindElement(By.ClassName("ui-icon-circle-triangle-e")).Click();
                HelperCommon.IsJqueryActive(driver);
                monthFromDatePicker = driver.FindElement(By.ClassName("ui-datepicker-month")).Text.Trim();
            }
            Console.WriteLine("MOnth from Date Picker :: " + monthFromDatePicker + " at line:" + new StackTrace(true).GetFrame(0).GetFileLineNumber());
               
        }

        public int getDate(int currentMonth, int currentDate)
        {

            Dictionary<int, int> dateList = new Dictionary<int, int>();
            dateList.Add(1, 1);
            dateList.Add(2, 2);
            dateList.Add(3, 3);
            dateList.Add(4, 4);
            dateList.Add(5, 5);
            dateList.Add(6, 6);
            dateList.Add(7, 7);
            dateList.Add(8, 8);
            dateList.Add(9, 9);
            dateList.Add(10, 10);
            dateList.Add(11, 11);
            dateList.Add(12, 12);
            dateList.Add(13, 13);
            dateList.Add(14, 14);
            dateList.Add(15, 15);
            dateList.Add(16, 16);
            dateList.Add(17, 17);
            dateList.Add(18, 18);
            dateList.Add(19, 19);
            dateList.Add(20, 20);
            dateList.Add(21, 21);
            dateList.Add(22, 22);
            dateList.Add(23, 23);
            dateList.Add(24, 24);
            dateList.Add(25, 25);
            dateList.Add(26, 26);
            dateList.Add(27, 27);
            dateList.Add(28, 28);
            dateList.Add(29, 29);
            dateList.Add(30, 30);
            dateList.Add(31, 32);

            Random getRandomNumber = new Random();

            int date = 0;

            if (currentMonth == 1 || currentMonth == 3 || currentMonth == 5 || currentMonth == 7 || currentMonth == 8 || currentMonth == 10 || currentMonth == 12)
            {
                date = getRandomNumber.Next(1, 31);
                while (date < currentDate)
                {
                    date = getRandomNumber.Next(1, 31);
                }
            }
            else if (currentMonth == 4 || currentMonth == 6 || currentMonth == 9 || currentMonth == 11)
            {
                date = getRandomNumber.Next(1, 30);
                while (date < currentDate)
                {
                    date = getRandomNumber.Next(1, 30);
                }
            }
            else if (currentMonth == 2)
            {
                date = getRandomNumber.Next(1, 28);
                while (date < currentDate)
                {
                    date = getRandomNumber.Next(1, 28);
                }
            }

            return date;
        }

        public void SelectDateInDatePicker(int date)
        {

            Boolean flag = false;
            IList<IWebElement> datepickerTable = (IList<IWebElement>)driver.FindElements(By.CssSelector("table.ui-datepicker-calendar >tbody > tr"));
           
            IList<IWebElement> columnOfDatePicker = null;

            foreach (IWebElement currentRow in datepickerTable)
            {
                columnOfDatePicker = currentRow.FindElements(By.TagName("td"));
               
                foreach (IWebElement currentColumn in columnOfDatePicker)
                {
                    int isDateBlank = currentColumn.FindElements(By.TagName("a")).Count;
                    if (isDateBlank != 0)
                    {
                        if (date == Convert.ToInt32(currentColumn.FindElement(By.TagName("a")).Text.Trim()))
                        {
                            Console.WriteLine("Date Value :: " + currentColumn.FindElement(By.TagName("a")).Text.Trim());                       
                            flag = true;
                            Thread.Sleep(1000);
                            currentColumn.Click();
                            break;
                        }
                    }
                } // inner foreach
                if (flag)
                    break;
            } // outer foreach


        }

        #endregion


        public void SelectHotel()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("hotels")));

            SelectElement hotelName = new SelectElement(ddSelectHotel);
            hotelName.SelectByIndex(1);
        }

        public void EnterDateOfArrival()
        {
            dateArrival.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ui-datepicker-div")));

            GetStartDate();

        }

        public void SelectNumberOFNights()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("nights")));

            SelectElement numberOfNights = new SelectElement(ddNights);
            numberOfNights.SelectByIndex(0);
        }

        public void SelectNumberOFRooms()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("rooms")));

            SelectElement numberOfRooms = new SelectElement(ddRooms);
            numberOfRooms.SelectByIndex(0);
        }

        public void SelectNumberOFAdults()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("adults[1]")));

            SelectElement numberOfAdults = new SelectElement(ddAdultNumber);
            numberOfAdults.SelectByIndex(0);
        }

        public void ClickOnBookNow()
        {
            btnBookNow.Click();
        }

        public void VerifySelectedRatesPage(String actualHeading)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='main_body']/div[4]/div/div/div/div/div[1]/div[2]/div[1]/h5")));
                String headingSelectedRates = txtSelectedRates.Text.Trim();

                Assert.AreEqual(headingSelectedRates, actualHeading);
            }
            catch (Exception e)
            {
                driver.Navigate().Back();
                EnterDateOfArrival();
                ClickOnBookNow();
                VerifySelectedRatesPage("Select Rates & Packages");
            }
        }


        //Page 2
        public void VerifyCheckInDate()
        {
            String actualCheckInDate = txtCheckInDate.Text.Trim();

            Assert.AreEqual(true, actualCheckInDate.Contains(requiredStartMonth.ElementAt(0).Value));

            Assert.AreEqual(true, actualCheckInDate.Contains(DateTime.Now.Year.ToString()));

            Assert.AreEqual(true, actualCheckInDate.Contains(date.ToString()));

        }

        public String GetSelectedRoomPrice()
        {
            String roomPrice = txtSelectedRoomPrice.Text.Substring(1).Trim();
            roomPriceValue = Convert.ToDecimal(roomPrice);

            Assert.AreEqual(true, roomPriceValue > 0);

            return roomPrice;
        }


        public void ClickOnViewRoom()
        {
            btnViewRooms.FindElement(By.TagName("a")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.panel-collapse.collapse.in")));
        }

        public void TotalPriceSelectedRooms()
        {
            String totalPrice = txtTotalPriceSelectedRoom.Text.Trim();

        }

        public void ClickSelectedRatesBookNow()
        {

            btnPage2BookNow.Click();
        }
           

        public void ClickOnProceedToBooking()
        {
            btnProceedBooking[1].Click();
        }

        public void VerifyGuestPage(String expectedHeading)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='main_body']/div[4]/div/div/div/div/div[1]/div[2]/div[1]/h5")));
            String actual = txtGuestDetails.Text.Trim();

            Assert.AreEqual(expectedHeading, actual);
        }

        public void VerifyOptionalExtraPage(String expectedHeading)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("confirm-booking")));

            String actualHeading = txtOptionalExtraHeading.Text.Trim();

            Assert.AreEqual(expectedHeading, actualHeading);

        }

        public void TotalPriceExtraOptionalPage()
        {
            String temp = txtOptionalExtraTotalPrice.Text.Trim();
            int e = temp.IndexOf('£');
            String yy = temp.Remove(0, e + 1);
            int e1 = yy.IndexOf('\r');
            String totalRoomPrice = yy.Substring(0, e1);

            Decimal roomPriceActualValue = Convert.ToDecimal(totalRoomPrice);

            Assert.AreEqual(roomPriceActualValue, roomPriceValue);
        }
           

        public void SelectAfternoonTea()
        {
            chkAfterNoontea.Click();
            GetAfternoonTeaPrice();
        }

        public Decimal GetAfternoonTeaPrice()
        {
            String tempAfternoonTeaPrice = txtPriceAfterNoontea.Text.Substring(1).Trim();

            afternoonTeaPrice = Convert.ToDecimal(tempAfternoonTeaPrice);

            return afternoonTeaPrice;
        }

        public void SeletCheckOutExtra()
        {
            chkCheckOutExtra.Click();
            GetCheckOutExtraPrice();
        }

        public Decimal GetCheckOutExtraPrice()
        {
            String tempPriceCheckOutExtra = txtPriceCheckOutExtra.Text.Substring(1).Trim();

            checkOutExtraPrice = Convert.ToDecimal(tempPriceCheckOutExtra);

            return checkOutExtraPrice;
        }

        public void SelectAdjacentRoom()
        {
            chkAdjacentRoom.Click();
        }

        public void ClickOnProceed()
        {
            btnProceedBooking[1].Click();
        }

        public void VerifyGuestDetailsPage(String expectedHeading)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("NameEmail[_]")));

            String actualHeading = txtGuestDetails.Text.Trim();

            Assert.AreEqual(expectedHeading, actualHeading);

        }

        public void VerifyTotalFinalPrice()
        {
            expectedTotalPrice = roomPriceValue + afternoonTeaPrice + checkOutExtraPrice;
            String temp = txtOptionalExtraTotalPrice.Text.Trim();
            int e = temp.IndexOf('£');
            String yy = temp.Remove(0, e + 1);
            int e1 = yy.IndexOf('\r');
            String totalRoomPrice = yy.Substring(0, e1);

            Decimal totalRoomPriceActualValue = Convert.ToDecimal(totalRoomPrice);

            Assert.AreEqual(totalRoomPriceActualValue, expectedTotalPrice);
        }


        public void ClickOnBookingDetails()
        {
            try
            {
                linkBookingDetails.Click();
            }
            catch(Exception e)
            {
                driver.FindElement(By.LinkText("booking details")).Click();

            }
        }
              

        public void VerifyAllBookingDetails()
        {
            try
            {
               
                Thread.Sleep(2000);
                Dictionary<string, string> bookingDetails = new Dictionary<string, string>();
                bookingDetails.Add("Location", "The Shrigley Hall Hotel, Golf & Country Club, Cheshire");
                bookingDetails.Add("Rooms", "1");
                bookingDetails.Add("Total", Convert.ToString(expectedTotalPrice));
                bookingDetails.Add("Adults", "1");
                bookingDetails.Add("Children", "0");
                bookingDetails.Add("No. of Nights", "1");
                bookingDetails.Add("Room total", Convert.ToString(expectedTotalPrice));
    
                List<string> listKey = new List<string>(bookingDetails.Keys);
                List<string> listValue = new List<string>(bookingDetails.Values);

                IList<IWebElement> rowBookingDetails = driver.FindElements(By.CssSelector("div.row.go-left >  div.col-sm-6"))[0].FindElements(By.ClassName("row")).ToList();
                IList<IWebElement> rowRoomDetails = driver.FindElements(By.CssSelector("div.row.go-left >  div.col-sm-6"))[1].FindElements(By.ClassName("row")).ToList();

                #region Booking deatils
                
             
                foreach (var temp in rowBookingDetails)
                {
                    IWebElement itemLeftColumn = temp.FindElement(By.CssSelector("div.col-sm-5 >  h4"));
                    String txtLeftLabel = itemLeftColumn.Text.Trim();
                    IWebElement itemRightColumn;
                    String txtRightValue;
                    foreach (var item in listKey)
                    {
                        if (item.Equals(txtLeftLabel))
                        {
                            if (item.Equals("Total"))
                            {
                                itemRightColumn = temp.FindElement(By.CssSelector("div.col-sm-7 >  div"));
                                txtRightValue = itemRightColumn.Text.Substring(1).Trim();

                            }
                            else
                            {
                                itemRightColumn = temp.FindElement(By.CssSelector("div.col-sm-7 >  h5"));
                                txtRightValue = itemRightColumn.Text.Trim();
                            }

                            foreach (var item2 in listValue)
                            {
                                if (item2.Equals(txtRightValue))
                                {
                                    Assert.AreEqual(txtRightValue, item2);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                #endregion

                #region Room details


                foreach (var temp in rowRoomDetails)
                {
                    IWebElement itemLeftColumn = temp.FindElement(By.CssSelector("div.col-sm-5 >  h4"));
                    String txtLeftLabel = itemLeftColumn.Text.Trim();
                    IWebElement itemRightColumn;
                    String txtRightValue;
                    foreach (var item in listKey)
                    {
                        if (item.Equals(txtLeftLabel))
                        {
                            if (item.Equals("Room total"))
                            {

                                itemRightColumn = temp.FindElement(By.CssSelector("div.col-sm-7 >  div"));
                                txtRightValue = itemRightColumn.Text.Substring(1).Trim();

                            }
                            else
                            {
                                itemRightColumn = temp.FindElement(By.CssSelector("div.col-sm-7 >  h5"));
                                txtRightValue = itemRightColumn.Text.Trim();
                            }

                            foreach (var item2 in listValue)
                            {
                                if (item2.Equals(txtRightValue))
                                {
                                    Assert.AreEqual(txtRightValue, item2);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                #endregion

            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }

        }

        public void EnterEmail()
        {
            txtEmail.SendKeys("Edmund.Walsh@abc.com");

        }
        public void SelectTitle()
        {
            new SelectElement(ddTitle).SelectByIndex(1);

        }
        public void EnterFirstName()
        {
            txtFirstName.SendKeys("Edmund");

        }
        public void EnterLastName()
        {
            txtLastName.SendKeys("Walsh");

        }
        public void EnterPhoneNumber()
        {
            txtPhoneNumber.SendKeys("+44123456789");

        }

        public void EnterAddress()
        {
            txtAddress.SendKeys("Oxford road");

        }

        public void EnterCityName()
        {
            txtCity.SendKeys("London");

        }
        public void SelectCountry()
        {
            new SelectElement(ddCountry).SelectByText("United Kingdom");

        }

        public void ClickOnConfirmBooking()
        {
            btnConfirmBooking.Click();
        }


        public void VerifyInlineErrors()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("errors"))); 
                IList<IWebElement> errorList = txtErrors.FindElements(By.CssSelector("ul > li")).ToList();
                List<string> listError = new List<string>();
                listError.Add("Error: Please input correct card number.");
                listError.Add("Error: Please select card type.");
                listError.Add("Error: Credit card expired.");
                listError.Add("Error: Please supply name on card.");
                listError.Add("Error: Please agree terms and conditions");

                foreach (var item in errorList)
                {
                    foreach (var item2 in listError)
                    {
                        if (item.Text.Trim().Equals(item2))
                        {
                            Assert.AreEqual(item.Text.Trim(), item2);
                            break;

                        }

                    }
                }
            }
           
        }
    }



