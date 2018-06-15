Feature: Shorten
		In order to test the integration
		As a developer 
		I want to ensure that shorten endpoint works correctly


Scenario: Shorten the Url
		Given Database contains the UrlMapping record with the seed Id set to integer generated randomly
		When I call shorten endpoint with the Url
		Then the result should be base64 encoded string of the next Id after the seed Id