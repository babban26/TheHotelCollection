Feature: PublicBooking


@mytag
Scenario: Public Hotel Booking
	Given I am on homepage
	When I select hotel name 
	And I enter date of arrival
	And I select number of nights
	And I select number of rooms
	And I select number of adults
	And Click on book now button
	Then I should navigate to select Rates and Packages page
	And Verify check-in date 
	And Price of hotel should not be zero
	When I click on view rooms
	And Click on Book now button from page two
	Then Verify I navigate to optional extra page
	And Total Price of the selected room
	When I select option for Afternoon tea
	And option for Late checkout
	And Special requirement  for Adjacent Room
	And I click on proceed to Booking
	Then Verify I navigate to Guest details page
	And Verify the Total Price
	When I click on Booking details 
	Then Verify all the details of the hotel and rooms
	When I Enter the  email
	And Select the Title
	And Enter the first name
	And Enter last name
	And Enter the Phone number
	And Enter the address
	And Enter the city
	And Select the Country
	And I click on confirm booking
	Then verify all the required inline Errors