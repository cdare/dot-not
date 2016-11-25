Feature: HttpChallenge
	Users must manipulate a HTTP request to win the challenge

Scenario Outline: HeaderChallengeIsSolved
	Given the Challenge ID is <id>
	And the <name> header is <value>
	When I send an HTTP request to Challenge <id>
	Then I should see "<result>" in the response

	Examples: 
		| id | name          | value  | result     |
		| 4    | X-Forwarded-For | 82.101.23.43 | flag_unsuccessful |
		| 4    | X-Forwarded-For | 127.0.0.1 | flag_success |
		| 5    | User-Agent		 | Mozilla/4.0 | flag_unsuccessful |
		| 5    | User-Agent	     | Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; T312461 | flag_success |


	
