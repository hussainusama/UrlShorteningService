Feature: Lengthen
		In order to test the integration
		As a developer 
		I want to ensure that lengthen endpoint works correctly


Scenario: Lengthen the Url
		Given Database contains the following UrlMapping record for the Url
		| Id      | Url                   |
		| 1234567 | http://www.google.com |
		#"5BAN" is base64 encoded string of "1234567"
		When I call endpoint api/url/lengthen with 5BAN 
		Then The result should be http://www.google.com