HSBank Application with DotNet Core
===================

This application was built with DotNet Core 2.2 and Angular 6.0

## Dependencies

* [MySQL 8.0](https://dev.mysql.com/downloads/mysql/)
* [DotNet Core SDK 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)
* [Angular CLI 6.0](https://angular.io/)



## Documentation

Created a project using
~~~
dotnet new angular
~~~
This creates a template with server-side implementation and client-side implementation into one bundle.

The above command generates a template for both server side implementation (C#) and client side implementation (Angular 6.0)

### Download all the necessary libraries using 
~~~
dotnet restore
~~~

### Build the project using
~~~
dotnet build
~~~

### Run the project using 
~~~
dotnet run
~~~


## DB Configuration

The application expects to find the MySQL instance to be on __localhost__, with port __3306__.
You can change the server address in the __appsettings.Development.json__.
- All db scripts are in DB folder

<pre>

 "ConnectionString": {
    "DB": "server=<b>localhost</b>;port=<b>3306</b>;user=root;password=Bankuser123;database=HSBank"
}
</pre>


 
## Project Assumptions

- A registration page and forgot password is already provided for new user registration and change of password
- MySQL server is used as RDBMS. The user __root__ is provided and its password is __Bankuser123__ to access it.
- AccountId in Accounts table is not alpha-numeric (ex. ICICI1234567890) however a simple integer value (ex. 1).
- All users have subscribed within last 6 months only.
- The 3 month timespan while displaying best performer is considered as the first day of the first month to the last day of the third month (ex. 1-March to 31-May) 
