## Setting up

* Pull sql server docker image
    ```docker pull mcr.microsoft.com/mssql/server:2019-CU10-ubuntu-20.04```
    
* Run docker image
```
  docker run --name mssql -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=kcsb!0gpassw0rd' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-CU10-ubuntu-20.04
```

* Create initial database
```
    docker exec -it mssql /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P kcsb!0gpassw0rd
    create database kcsblog
    go
```

* Install the dotnet ef tool to be able to run the migrations

```dotnet tool install --global dotnet-ef```

* Check if your dbcontext is properly set-up for the EF-core. If you can see it in this screen, everything is fine

```
  cd kcs.Blog.Infrastructre 
  dotnet ef dbcontext list
```

* Add the initial migration 

```dotnet ef migrations add DB_Init```

* Update the database

```dotnet ef database update --startup-project ../kcs.Blog.Api```

* If you want the run the application in a docker container, you need to get the SQLServer container IP, run

```docker network inspect bridge```
  
* find the IPv4Address
* change the localhost in connectionstring to the IPv4 Address

## Usage

You need to get a JWT token and set authorization header to be able to access the endpoints

Sample users for acquiring JWT token: 
```
  name: test1
  password: password1
  
  name: test2
  password: password2
```
sample usage: ```{baseUrl}/api/auth?name=test1&password=password1```

the service should return the JWT token if username and password matches, from now on you can access the endpoints using Bearer token

For Healthcheck: ```{baseUrl}/health```
