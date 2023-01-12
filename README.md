# DotNET Microservice Kong/PostgreSQL Version

## Prerequisites

[Docker](https://docs.docker.com/get-docker/) installed and running.
[Postman](https://www.postman.com/) if following along with the test plan.

## Installation Guide

1. Clone this repo and extract the files.
2. Open a terminal and navigate to the dotnet-microservice-alternate folder.
3. Run `docker-compose up --build`
    
    Once the compose file has finished its start up procedure the API will be available at `http://localhost/api/users`. If you are trying to access the API from another device replace `localhost` with the server ip address or domain name. 
    
4. After ensuring that the container has built and ran successfully, and that and the API is available and working, type `CTRL + C` (or `COMMAND + C` on Linux and Mac) into your terminal to stop the containers.
5. Run `docker-compose up -d --build` to run the container in the background.

## Test Plan

1. Open Postman and click import.
2. Click Choose Files and select the postman_collection.json from the repo. Click the import button.
3. Right click on the DotNET Microservice Tests collection and click Run collection.
4. Choose the Run manually option and press Run DotNET Microservice Tests.
   
   If everything went correctly, the GET, DELETE, and PUT methods will respond with 200 OK, while the POST method will respond with 201 Created.

   If something went wrong with the tests, or some other error occured, each service can be accessed individually.

   - Kong: Open `http://localhost:8002` in your web browser to access the GUI.
   - Postgres: Enter `docker exec -it api-db psql -U postgres` into your terminal to access the postgres psql terminal.
   - API: Access the API directly by going to `http://localhost:8050` 
