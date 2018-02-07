# DistributorApi! [![Build Status](https://travis-ci.org/magicnova/DistributorApi.svg?branch=master)](https://travis-ci.org/magicnova/DistributorApi)

 - Developed using Net Core V 2.14, it runs on Localhost:5000 by default.
 - Mongo database is required


## Important
- All routes of Distributor controller **needs** a token in the header.
- To create a token invoke this via POST - http://5000/auth    
- In the header add: Authorization  Bearer {Token}
- ApiFord an ApiToyota need to be running
## Routes


| URL | METHOD | DESC|
|--|--|--|
| /api/distributor | GET |Get all cars|
|/api/distributor/model/{brand}/{model}|GET|Get cars by model and brand|
|/api/distributor/transmission/{brand}/{transmission}|GET|Get cars by transmission and brand|
|/api/distributor/engine/{brand}/{engine}|GET|Get cars by engine and brand|
|/api/distributor/year/{brand}/{year}|GET|Get cars by year and brand|
|/api/distributor/{brand}/{id}|GET|Get cars by id and brand|
|/api/distributor/{brand}|POST| Create a new car (Only Ford)|
|/api/distributor/{brand}|UPDATE| Update an existing car (Only Ford)|
|/api/distributor/{brand}|DELETE| Delete a car (Only Ford)|
|/api/auth|POST| Create new token|

##Swagger
- It runs on localhost:5000/swagger
- before use methods from Distributor Controller is necessary to create the token. Use auth controller to create a new one.
- click authorization button and paste it.
