#language: en

Feature: Login
	In order to validate my user
	As a customer
	I want to login in the website with my credentials

@AutomationFlow
Scenario: Going to the Authentication page
	Given that i'm on the main page of My Store
	When i click in Sign in functionality
	Then the authentication page should be displayed

@AutomationFlow
Scenario: Creating an Account
	Given i'm on authenticator page
	And i want to create a Account
	When i type my e-mail on Email address field
	And click on Create an account button
	Then the CREATE AN ACCOUNT page should be displayed

@AutomationFlow
Scenario: Filling all the fields and creating an account
	Given i'm at CREATE AN ACCOUNT page
	When i fill all the fields with my information
	And click on Register button
	Then will be redirected to My Accounte page

@AutomationFlow
Scenario: Login into the website
	Given i'm on authenticator page
	When i fill my e-mail on Email address field
	And i fill my password on Password field 
	And click on "Sing In" button
	Then the login should be made
