using System;
using TechTalk.SpecFlow;
using Hotel.Collection.Test.PageObject;
using Hotel.Collection.Test.Utils;

namespace Hotel.Collection.Test.Steps
{
    [Binding]
    public class PublicBookingSteps
    {
        [Given(@"I am on homepage")]
        public void GivenIAmOnHomepage()
        {
            Console.WriteLine("I am on Home Page");
        }
        
        [When(@"I select hotel name")]
        public void WhenISelectHotelName()
        {
            Objects.poHotelBooking.SelectHotel();
        }
        
        [When(@"I enter date of arrival")]
        public void WhenIEnterDateOfArrival()
        {
            Objects.poHotelBooking.EnterDateOfArrival();
        }
        
        [When(@"I select number of nights")]
        public void WhenISelectNumberOfNights()
        {
            Objects.poHotelBooking.SelectNumberOFNights();
        }
        
        [When(@"I select number of rooms")]
        public void WhenISelectNumberOfRooms()
        {
            Objects.poHotelBooking.SelectNumberOFRooms();
        }
        
        [When(@"I select number of adults")]
        public void WhenISelectNumberOfAdults()
        {
            Objects.poHotelBooking.SelectNumberOFAdults();
        }
        
        [When(@"Click on book now button")]
        public void WhenClickOnBookNowButton()
        {
            Objects.poHotelBooking.ClickOnBookNow();
        }
        
        [Then(@"I should navigate to select Rates and Packages page")]
        public void ThenIShouldNavigateToSelectRatesAndPackagesPage()
        {
            Objects.poHotelBooking.VerifySelectedRatesPage("Select Rates & Packages");
        }

        [Then(@"Verify check-in date")]
        public void ThenVerifyCheck_InDate()
        {
            Objects.poHotelBooking.VerifyCheckInDate();
        }

        [Then(@"Price of hotel should not be zero")]
        public void ThenPriceOfHotelShouldNotBeZero()
        {
            Objects.poHotelBooking.GetSelectedRoomPrice();
        }


        [When(@"I click on view rooms")]
        public void WhenIClickOnViewRooms()
        {
            Objects.poHotelBooking.ClickOnViewRoom();
        }

        [When(@"Click on Book now button from page two")]
        public void WhenClickOnBookNowButtonFromPageTwo()
        {
            Objects.poHotelBooking.ClickSelectedRatesBookNow();
        }


        [Then(@"Verify I navigate to optional extra page")]
        public void ThenVerifyINavigateToOptionalExtraPage()
        {
            Objects.poHotelBooking.VerifyOptionalExtraPage("Optional Extras");
           
        }

        [Then(@"Total Price of the selected room")]
        public void ThenTotalPriceOfTheSelectedRoom()
        {
            Objects.poHotelBooking.TotalPriceExtraOptionalPage();
        }

        [When(@"I select option for Afternoon tea")]
        public void WhenISelectOptionForAfternoonTea()
        {
            Objects.poHotelBooking.SelectAfternoonTea();
        }

        [When(@"option for Late checkout")]
        public void WhenOptionForLateCheckout()
        {
            Objects.poHotelBooking.SeletCheckOutExtra();
        }

        [When(@"Special requirement  for Late arrival")]
        public void WhenSpecialRequirementForLateArrival()
        {
           // Objects.poHotelBooking.SeletCheckOutExtra();
        }

        [When(@"Special requirement  for Adjacent Room")]
        public void WhenSpecialRequirementForAdjacentRoom()
        {
            Objects.poHotelBooking.SelectAdjacentRoom();
        }


        [When(@"I click on proceed to Booking")]
        public void WhenIClickOnProceedToBooking()
        {
            Objects.poHotelBooking.ClickOnProceed();
        }

        [Then(@"Verify I navigate to Guest details page")]
        public void ThenVerifyINavigateToGuestDetailsPage()
        {
            Objects.poHotelBooking.VerifyGuestDetailsPage("Guest Details");
        }

        [Then(@"Verify the Total Price")]
        public void ThenVerifyTheTotalPrice()
        {
            Objects.poHotelBooking.VerifyTotalFinalPrice();
        }

        [When(@"I click on Booking details")]
        public void WhenIClickOnBookingDetails()
        {
            Objects.poHotelBooking.ClickOnBookingDetails();
        }

        [Then(@"Verify all the details of the hotel and rooms")]
        public void ThenVerifyAllTheDetailsOfTheHotelAndRooms()
        {
            Objects.poHotelBooking.VerifyAllBookingDetails();
        }

        [When(@"I Enter the  email")]
        public void WhenIEnterTheEmail()
        {
            Objects.poHotelBooking.EnterEmail();
        }

        [When(@"Select the Title")]
        public void WhenSelectTheTitle()
        {
             Objects.poHotelBooking.SelectTitle();
        }

        [When(@"Enter the first name")]
        public void WhenEnterTheFirstName()
        {
             Objects.poHotelBooking.EnterFirstName();
        }

        [When(@"Enter last name")]
        public void WhenEnterLastName()
        {
             Objects.poHotelBooking.EnterLastName();
        }

        [When(@"Enter the Phone number")]
        public void WhenEnterThePhoneNumber()
        {
            Objects.poHotelBooking.EnterPhoneNumber();
        }

        [When(@"Enter the address")]
        public void WhenEnterTheAddress()
        {
             Objects.poHotelBooking.EnterAddress();
        }

        [When(@"Enter the city")]
        public void WhenEnterTheCity()
        {
            Objects.poHotelBooking.EnterCityName();
        }

        [When(@"Select the Country")]
        public void WhenSelectTheCountry()
        {
             Objects.poHotelBooking.SelectCountry();
        }

        [When(@"I click on confirm booking")]
        public void WhenIClickOnConfirmBooking()
        {
            Objects.poHotelBooking.ClickOnConfirmBooking();
        }

        [Then(@"verify all the required inline Errors")]
        public void ThenVerifyAllTheRequiredInlineErrors()
        {
            Objects.poHotelBooking.VerifyInlineErrors();
        }

    }
}
