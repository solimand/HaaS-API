# Introduction
Hotel as a Service is a service for hotel management. The project implement basic CRUD operations. 

## Deployment
- cd \<proj-folder\>
- ```docker compose up -d```
- The ```mysqlserver``` container exposes the port ```1433``` to everyone in the default docker network.
- The ```myhotel``` container maps the port ```5167``` (of the running application) to the same localhost port. 

## Endpoints 
- GET ```/``` -> hello world page
- GET ```/hotels``` -> get the list of the hotels (READ)
- POST ```/hotels``` -> add an hotel to the list (CREATE)
- DEL ```/hotels/{id}``` -> remove the hotel by ID (DELETE)
- PUT ```/hotels/{id}``` -> edit the characteristics of an hotel (UPDATE)

## HOW to try
In the [Postman folder](postman/) there is a collection that you can import to run the CRUD operations on the running container. **NOTE**: you have to change the port accordingly to the cofiguration in the docker compose.  

## Tools used
- docker (client/server) version 20.10.21
- dotnet sdk 7.0.100
- VS code (developing)
- Visual Studio 2019 (nuget manager)
- SSMS (database explorer)
- Linux Threadripper 6.0.10-arch2-1\
&nbsp;&nbsp;OR\
  Microsoft Windows 10 Pro OS:10.0.19045 N/A Build 19045

## TODOs
- Create a secret for the SQL server DB
- View
  - Create views with Razor