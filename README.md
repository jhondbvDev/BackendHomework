# BackendHomework

This project consists on an API for restaurant plates of different types in which the user would be able to create, edit, view and delete his own plates, also would be able to access a preloaded database of public plates (which he can not affect with any of the previous operations, except for viewing them). 

The project supports OpenAPI specification so the user would be able to access API an test it directly from Swagger.

![SwaggerEnpoints](https://github.com/jhondbvDev/BackendHomework/blob/master/README_Images/SwaggerEnpoints.png)

## Steps to run the project

As a quick note, this project is running on an InMemory database which improve the testing efforts speed since there is no need for a database engine to test this code. This implies that the data used on each execution of the project (if the API is restarted or shut down) will be erased, except for the public plates data which is seeded during the API start cicle. 

### Run it from code

1. Clone the project from this [repository](https://github.com/jhondbvDev/BackendHomework)
2. Execute the project from Visual Studio or your preferred platform
3. The server will start and you should be able to see the swagger enpoint after the load is finished
4. Start testing

### Run it from the executable file

In this [repository](https://github.com/jhondbvDev/BackendHomework) you will find a folder called "Other_Files" that stores the self-contained API build files, within these files there is an executable file called **BackendHomework.API.exe**, this file will start a local server. After this, you should be able to access the project from your browser and start testing directly using http://localhost:5000/swagger.

Is important to know that as this is a self-contained build, the selected architecture for it was win-64 so it will not work on other OS platforms, if you are on a win-64 system them it should work without issue and you don't need to install any .NET dependency on your own system.



