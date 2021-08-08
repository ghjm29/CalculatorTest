Feature: Calculator
	Simple calculator for adding two numbers

@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@Test
Scenario Outline:  Test subtraction, division and addition functionalities
	Given Open chrome browser and start application
	When I <operator> <value1> and <value2>
	Then <expectedValue> should be displayed
	Examples: 
	| operator | value1 | value2 | expectedValue |
	| Add      | 1      | 1      | 2             |
	| Subtract | 11     | 33     | -22           |
	| Divide   | 1000   | 2.5    | 400           |
	| Add      | -1234  | 1      | -1233         |


	# - , negative values? -1 + 3 = 2
	#Add
	#Subtract
	#Divide