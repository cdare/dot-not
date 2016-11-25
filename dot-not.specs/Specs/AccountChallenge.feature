Feature: AccountChallenges

Scenario Outline: Bypass Direct Object Reference
	Given the admin ID is <id>
	When I browse to /account/<id>
	Then I the flag comment will be <comment>
	
	Examples:
		| id | comment      |
		| 1  | success      |
		| 2  | unsuccessful |

Scenario Outline: Bypass Hashed Cookie
	Given the admin ID is <id>
	And the user cookie is a md5 hash of <id>
	When I browse to /account/<id>
	Then I the flag comment will be <comment>
	
	Examples:
		| id | comment      |
		| 1  | success      |
		| 2  | unsuccessful |
