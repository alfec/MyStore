#language: en

Feature: Search
	As a customer
	I want to search produtcs on the Website


Scenario: Use the search bar to find products
	Given I am on the My Store page
    When I type "Dress" in the “Search bar”
    And press Enter on keyboard
    Then all related products should be displayed in result page


Scenario: Sorting products by lowest price
	Given that I search some product 
	When i click on "Sort By" field
	And choose "Price: Lowest first" 
	Then the result page should be reordered
	And display the lower price to the highest


Scenario: Sorting products by highest price
	Given that I search some product 
	When i click on "Sort By" field
	And choose "Price: highest first" 
	Then the result page should be reordered
	And display the highest price to the lower
