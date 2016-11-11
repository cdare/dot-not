Feature: Challenge
	Users must complete a challenge to get points
	A challenge is completed by sumbitting a flag

@mytag
Scenario Outline: Sumbit a flag
	Given I have entered <flag> in the text box
	When I press sumbit
	Then the result will be <result>
	And I will get <points> points

	Examples:
		| flag                                 | result  | points |
		| dea9f426-2d1b-484c-ad45-32bd64537ea8 | success | 1      |
		| 9ae24bd2-6f2c-4787-ae2d-d5185ad5b7ac | fail    | 2      |