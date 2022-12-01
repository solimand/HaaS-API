# Introduction
Hotel as a Service is a service for hotel management. The project implement basic CRUD operations. 

## Deployment
- cd \<proj-folder\>
- ```docker build -t aspnet-hotel -f Dockerfile .```
- ```docker run -it --rm --name testdotnet aspnet-hotel```

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
- VS code
- Linux Threadripper 6.0.10-arch2-1