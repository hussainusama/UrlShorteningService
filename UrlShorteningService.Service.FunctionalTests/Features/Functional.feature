Feature: Functional
		In order to test the functionality
		As a consumer of the service 
		I want to ensure that service functions correctly

Scenario: Shorten the Url and then get the original Url back
		Given The service is deployed successfully
		When I call endpoint api/url/shorten with argument http://www.yahoo.com
		Then I receive the shortened Url
		When I call endpoint api/url/lengthen with the received shortened Url
		Then The result should be http://www.yahoo.com