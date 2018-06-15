Feature: Lengthen
		In order to test the integration
		As a developer 
		I want to ensure that lengthen endpoint works correctly


Scenario: Lengthen the Url
		Given Database contains the UrlMapping record for the Url
		And The Id of the record has been converted to base64 encoded string
		When I call lengthen endpoint with the base64 encoded string
		Then the result should be the Url stored in the UrlMapping record