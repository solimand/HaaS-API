# Introduction
Hotel as a Service is a service for hotel management. The project implement basic CRUD operations. 

## Deployment
- cd \<proj-folder\>
- ```docker compose up```
- The container exposes the port ```5167``` on ```localhost``` interface

## Endpoints 
- GET ```/``` -> hello world page
- GET ```/hotels``` -> get the list of the hotels (READ)
- POST ```/hotels``` -> add an hotel to the list (CREATE)
- DEL ```/hotels/{id}``` -> remove the hotel by ID (DELETE)
- PUT ```/hotels/{id}``` -> edit the characteristics of an hotel (UPDATE)

## HOW to try
In the [Postman folder](postman/) there is a collection that you can import to run the CRUD operations on the running container. **NOTE**: you have to change the address of the container accordingly to you configuration. 

## Tools used
- docker (client/server) version 20.10.21
- dotnet sdk 7.0.100
- VS code (developing)
- Visual Studio 2019 (nuget manager and database explorer)
- Linux Threadripper 6.0.10-arch2-1\
&nbsp;&nbsp;OR\
  Microsoft Windows 10 Pro OS:10.0.19045 N/A Build 19045