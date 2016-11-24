Feature: Challenge
	Users must complete a challenge to get points
	A challenge is completed by finding a flag

Scenario: Challenge4IsSolved
	Given the Challenge ID is 4
	And the X-Forwarded-For header is 127.0.0.1
	When I send an HTTP request to Challenge 4
	Then I should see "flag_success" in the response

Scenario: Challenge4IsNotSolved
	Given the Challenge ID is 4
	Given the X-Forwarded-For header is 82.101.23.43
	When I send an HTTP request to Challenge 4
	Then I should see "flag_unsuccessful" in the response

Scenario: Challenge5IsSolved
	Given the Challenge ID is 5
	Given the User-Agent header is "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; T312461"
	When I send an HTTP request to Challenge 5
	Then I should see "flag_success" in the response

Scenario: Challenge5IsNotSolved
	Given the Challenge ID is 5
	When I send an HTTP request to Challenge 5
	Then I should see "flag_unsuccessful" in the response

Scenario Template: HeaderChallengeIsSolved
	Given the Challenge ID is {id}
	And the {name} header is {value}
	When I send an HTTP request to Challenge {id}
	Then I should see "{result}" in the response

Examples: 
	| <id> | <name>          | <value>   | <result>     |
	| 4    | X-Forwarded-For | 82.101.23.43 | flag_unsuccessful |
	| 4    | X-Forwarded-For | 127.0.0.1 | flag_success |
	| 5    | User-Agent		 | Mozilla/4.0 | flag_unsuccessful |
	| 5    | User-Agent	     | Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; T312461 | flag_success |


	
