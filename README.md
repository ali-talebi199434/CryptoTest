# CryptoTest

### A simple ASP.Net MVC and NodeJS project for connecting to realtime public APIs on all cryptocurrency exchanges.

**before runnig the project make sure you have installed the items listed below**
<br/> &emsp; 1- **.Net6**
<br/> &emsp; 2- **NodeJS**
<br/> &emsp; 3- **MSSQL**
<br/> &emsp; 4- ***dotnet-ef*** dotnet tool
<br/>

**before running the project for the first time you need to restore nuget packages and install node modules and also create the database.**
<br/><br/>
1- open a command prompt in the root directory of the solution.
<br/>
2- enter this command to restore nuget packages: 
<br/> &emsp;
`dotnet restore`
<br/>
3- in command line go to DataLayer project directory
<br/>
4- enter this command to update the database
<br/> &emsp;
`dotnet ef database update --context CryptoTestContext`
<br/>
5- then get back to the parent directory and move to CryptoTest project directory and enter this command to install node modules:
<br/> &emsp;
`npm install`
<br/>
6- enter this command to run the project
<br/> &emsp;
`npm run dev`
<br/>

The browser will be launched and home page will apear, and it will start to communicate with server through a socket.
<br/>
When the server gets the connection request through the socket it will register a listener for trade events for default markets.
<br/>
As the server gets trade events, it will send the data back to client through the socket.
<br/>
The socket is created in ***app.js*** file in CryptoTest project directory and is run by NodeJS.

### Credentials
when you run the project, the admin user will be created automatically and it's username and password is set in ***appsettings.json*** file.
<br/>
### Crypto Markets
you can change the default set of crypto markets in ***appsettings.json*** file.
<br/>
