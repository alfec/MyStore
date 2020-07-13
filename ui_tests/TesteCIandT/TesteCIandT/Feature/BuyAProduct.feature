#language: en

Feature: BuyAProduct
	As a customer
	I want to buy a product on the website


Scenario: View product details
	Given that i search for some product
	When i choose one product
	And i click on the photo
	Then the product detail page will be displayed on screen


Scenario: Add a product to the cart from the product page
	Given i'm on the product page
	When i click on "Add to cart" button
	Then a pop up will be shown 
	And a message of success will be displayed


Scenario: View the total value of the 
	Given the pop up is displayed
	When i click "Proceed to checkout"
	Then the total price will be shown


Scenario: Go to step 2 login into the payment flow
	Given that i'm wanna go to the step two
	When I click on "Proceed to checkout"
	Then the step two will be displayed 
	And the fields to do my login too

Scenario: Doing the log in and going to step three
	Given that i'm on the step 2
	When i fill my e-mail on "Email address" field
	And i fill my password on "Password" field 
	And press the "Sing In" button
	Then the step three will be displayed

Scenario: Checking my adress and going to step four
	Given that i'm on the step 3
	And my adress is correct
	When i click at "Proceed to checkout"
	Then the step four will be displayed
