## UrlShorteningService

Url shortening service to shorten the url. Easy deployment supporting azure.

### Projects

#### UrlShorteningService
Web application project containing the UI, Web api controller to handle shortening requests, HttpHandler for retrieval requests 
and Base62Encoder for encoding URLs. Easily deployable through Visual Studio.

#### UrlShorteningService.Database
Database project containing the schema for the database. Easily deployable through Visual Studio.

#### UrlShorteningService.Tests
Unit test project

#### UrlShorteningService.Deployment
Deployment project to deploy to azure resource group through Visual Studio. Requires a valida zure subscription. Deployment creates 
necessary infrastructure then deploys the webapp and the database. For database deployment a valid path to 'sqlpackage.exe' is 
required to deploy the database, on the machine the script is running.

