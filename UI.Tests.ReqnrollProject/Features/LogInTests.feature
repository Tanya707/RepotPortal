	@mytag
Feature: LogInTests

Background:
Given Open Log In Page

Scenario: LogInButtonTest
	Then Is Log In Button Displayed

Scenario: LogInTestSuperadmin
	When Log In Superadmin
	Then Is Launches Button Displayed

Scenario: LogInTestDefaultUser
	When Log In DefaultUser
	Then Is Launches Button Displayed

Scenario: FilterByLaunchName
	When Log In Superadmin
	And CLick On Launches Button
	And Click On Filter By Button
	And Enter Launch Name '<launchName>'
	Then Check Launch Names '<launchName>' contains

	Examples:
    | launchName     | 
    | Demo Api Tests |
	| Demo Api		 |
	| Api Tests		 |
	| Api Tests		 |
	| Tests		     |
	| Demo		     |


Scenario: FilterByTotal
	When Log In Superadmin
	And CLick On Launches Button
	And Click On Filter By Button
	And Choose Filter By Total
	And Select Equal
	And Enter Second Filter Field 'Total' '<total>'
	Then Check Total Values '<total>' contains

	Examples:
    | total | 
    | 10    |
	| 15    |
	| 20	|
	| 25	|
	| 30	|


Scenario: FilterByPassed
	When Log In Superadmin
	And CLick On Launches Button
	And Click On Filter By Button
	And Choose Filter By Passed
	And Select Equal
	And Enter Second Filter Field 'Passed' '<passed>'
	Then Check Passed Values '<passed>' contains

	Examples:
    | passed | 
    | 10     |
	| 5      |
	| 20	 |
	| 1	     |
	| 30	 |

Scenario Outline: FilterByLaunchNameAndTotal
	When Log In Superadmin
	And CLick On Launches Button
	And Click On Filter By Button
	And Enter Launch Name '<launchName>'
	And Click On Filter By Button
	And Choose Filter By Total
	And Select Equal
	And Enter Second Filter Field 'Total' '<total>'
	Then Check Launch Names '<launchName>' contains
	Then Check Total Values '<total>' contains

	Examples:
	| launchName     | total |
    | Demo Api Tests |   10  |
    | Demo Api       |   15  |
	| Api Tests      |   20  |
    | Tests	         |   25  |
	| Demo		     |   30  |
