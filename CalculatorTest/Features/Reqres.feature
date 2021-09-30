Feature: Reqres
	Simple calculator for adding two numbers

@mytag
Scenario Outline: Test Reqres API
	Given I'm a customer
	When I click the api <api> 
	Then <api> request and expected response will be provided
	When I send a request to the api using the request
	Then actual response should be as expected
	Examples: 
	| api        |
	| LIST USERS |