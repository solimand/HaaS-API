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