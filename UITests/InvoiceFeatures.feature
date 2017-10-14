Feature: InvoiceFeatures
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add new invoice with minimum data
	Given User with Aministrator role is logged in
	When I press add
