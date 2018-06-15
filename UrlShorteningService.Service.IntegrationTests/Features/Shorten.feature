Feature: Shorten
		In order to test the integration
		As a developer 
		I want to ensure that shorten endpoint works correctly


Scenario: Shorten the Url
		Given Database contains the following UrlMapping record for the Url
		| Id      | Url                   |
		| 1234567 | http://www.google.com |
		When I call endpoint api/url/shorten with http://www.yahoo.com
		#"5BAO" is base64 encoded string of "1234568"
		Then The result should be 5BAO