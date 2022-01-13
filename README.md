## Cars-From-Frank

This project has been deployed to Azure under address https://carsfromfrankapi.azure-api.net/api/ .
The API access is restricted with API key though to prevent from calls outside of [frontend app](https://github.com/Raven351/Cars-From-Frank-Frontend).

## Running locally
This project uses MongoDB as database provider.

1. Git clone this repo.
2. Open the file `appsetings.json` fron inside the project and provide `ConnectiongString`, `DatabaseName and `CollectionName` for MongoDB.
3. Build project
4. Launch project either using Docker container or IIS container.
5. Project should be up and running. Go to [frontend app](https://github.com/Raven351/Cars-From-Frank-Frontend) and launch frontend side.
