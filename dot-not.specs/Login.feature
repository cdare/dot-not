Feature: Login
	As a user
	I can login and win points

@mytag
Scenario: Successful Login
	Given The user "Test_User" has an account
	When he logs in
	Then he should see "Welcome, Test_User"

Scenario: Failed Login
	Given The user "Test_User" has an account
	When he logs in with an incorrect password
	Then he should see "Login Failed"
