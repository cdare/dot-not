Feature: XssChallenges

Scenario Outline: ExploitSimplReflectedXss
	Given I am on the search page
	When I search for "<script>"
	Then I should see "<script>" in the response

Scenario Outline: ExploitXss
	Given I am attempting Challenge <ID>
	When I search for <term>
	Then I should see <result> in the response
	
	Examples:
	| ID | term      | result       |
	| 1  | <script>  | <script>     |
	| 2  | <script>  | %3Cscript%3E |
	| 2  | onclick=" | onclick="    |	

Scenario Outline: SubmitXssAnswer
	Given I am on the result submit page for Challenge <ID>
	When I sumbit <answer>
	Then the flag result will be <result>

	Examples: 
	| ID | answer   | result  |
	| 1  | test     | fail    |
	| 1  | <script> | success |


	