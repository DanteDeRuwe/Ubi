
# Ubi

My solution to the "everybody codes" challenge (to be found [here](https://github.com/iChoosr-BVBA/everybody-codes))
This is an application that consists of a Web API, CLI and Web application. It displays camera's around the Dutch city of Utrecht.

> **about the name**: "Ubi" is the Latin word for "where". I felt this was quite fitting for an application that is all about finding camera locations.


## Run Locally

Clone the project

```bash
  git clone https://github.com/DanteDeRuwe/Ubi.git
```

### Web API

This is a .NET Web API project. From the repository root, run

```bash
cd src/Ubi.Api && dotnet run
```

This will spin up the web API at https://localhost:5001 and the Open API specification at https://localhost:5001/swagger

### CLI

This is a .NET console application. From the repository root, run

```bash
cd src/Ubi.Cli && dotnet run --name <name here>
```
The name parameter will filter the camera names.

### Web application
This is a React application created with `create-react-app`

Make sure the web API is running and then, from the repository root, run
```bash
cd src/ubi-web && yarn start
```
## Running Tests

To run unit tests for the web api, run

```bash
  cd test/Ubi.UnitTests && dotnet test
```


## API Reference

#### Get all cameras

```http
  GET /api/cameras
```



## License

[MIT](https://choosealicense.com/licenses/mit/)


## Acknowledgements

 - [Challenge repo](https://github.com/iChoosr-BVBA/everybody-codes)

  