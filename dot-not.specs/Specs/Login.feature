Feature: Login
	As a user
	I can login and win points

Scenario: Failed Registration when User Exists
	Given The user "Test_User" has an account
	When the user registers an account as "Test_User"
	Then the user should see "already taken"

Scenario: Successful Registration
	Given The user "Test_Register" does not exists
	When the user registers an account as "Test_Register"
	Then the user should see "Hello Test_Register"

Scenario: Successful Login
	Given The user "Test_User" has an account
	When the user logs in
	Then the user should see "Welcome, Test_User"

Scenario: Failed Login
	Given The user "Test_User" has an account
	When he logs in with an incorrect password
	Then the user should see "Login Failed"
