Feature: Calculator
	Simple calculator for adding two numbers

@Test
Scenario Outline:  Test subtraction, division and addition functionalities
	Given Open chrome browser and start application
	When I <operator> <value1> and <value2>
	Then <expectedValue> should be displayed
	Examples: 
	| operator | value1     | value2     | expectedValue |
	| Add      | 999999999  | 999999999  | 2e+9          |
	| Add      | 1          | 1          | 2             |
	| Add      | 0.00000000 | 0.00000001 | 1e-8          |
	| Add      | 0.1        | 1          | 1.1           |
	| Add      | -10.1      | 10         | -0.1          |
	| Add      | -10        | -10        | -20           |
	| Add      | 1000       | 1          | 2000          |
	| Subtract | 999999999  | 999999999  | 0             |
	| Subtract | 100        | 1          | 99            |
	| Subtract | 0.00000000 | 0.00000001 | -1e-8         |
	| Subtract | 0.1        | 1          | -0.9          |
	| Subtract | -10.1      | 10         | -20.1         |
	| Subtract | -10        | -10        | 0             |
	| Subtract | 1000       | 1          | 2000          |
	| Divide   | 999999999  | 999999999  | 1             |
	| Divide   | 100        | 1          | 100           |
	| Divide   | 0.00000000 | 0.00000001 | 0             |
	| Divide   | 0.1        | 1          | 0.1           |
	| Divide   | -10.1      | 10         | -1.01         |
	| Divide   | -10        | -10        | 1             |
	| Divide   | 1000       | 1          | 2000          |
