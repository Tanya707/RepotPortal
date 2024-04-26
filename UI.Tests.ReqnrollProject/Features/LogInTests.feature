	@mytag
Feature: LogInTests

Background:
Given Open Log In Page
Rule: Is Log In Button Displayed

Scenario: LogInButtonTest
	Then Is Log In Button Displayed

Scenario: LogInTestSuperadmin
	When Log In Superadmin
	Then Is Launches Button Displayed

Scenario: LogInTestDefaultUser
	When Log In DefaultUser
	Then Is Launches Button Displayed

Scenario: LogInTest
	When I can log in with such data:
	| UserName   | Password |
	| superadmin | erebus   |
	| default    | 1q2w3e   |
