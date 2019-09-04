Feature: ShortenTheUrlThenGetBackOriginalUrl
		In order to test the functinality
		As a consumer of the service
		I want to ensure that endpoints of the service work correctly

Scenario: Shorten the url then get back the original url
			Given Database contains the following UrlMap records
			| Id		| Url                   |
			| 1			| http://www.google.com |
			| 12		| http://www.google.com |
			| 123		| http://www.google.com |
			| 1234		| http://www.google.com |
			| 12345		| http://www.google.com |
			| 123456	| http://www.google.com |
			When I call shorten endpoint api/url/shorten with http://www.supposedlyverylongurl.com
			Then I get an encoded string representing next database record id which is 123457
			When I call lengthen endpoint api/url/lengthen with the received encoded string
			Then I get the original url back http://www.supposedlyverylongurl.com