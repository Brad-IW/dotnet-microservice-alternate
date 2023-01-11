# DotNET Microservice Kong/PostgreSQL Version

## Prerequisites

[Docker](https://docs.docker.com/get-docker/) installed and running.

## Installation Guide

1. Clone this repo and extract the files.
2. Open a terminal and navigate to the dotnet-microservice-alternate folder.
3. Run `docker-compose up`
    
    Once the compose file has finished its start up procedure the API will be available at `http://localhost/api/users`. If you are trying to access the API from another device replace `localhost` with the server ip address or domain name. 
    
4. After ensuring that the container has built and ran successfully, and that and the API is available and working, type `CTRL + C` (or `COMMAND + C` on Linux and Mac) into your terminal to stop the containers.
5. Run `docker-compose up -d` to run the container in the background.

## Test Plan

Make a GET web request (using a web browser, curl, postman, etc.) to `http://localhost:80/api/users`. After a few seconds this should return a list of all 1000 users within the API.

Make a GET web request to `http://localhost:80/api/users/10`. This should return the user with the ID of 10.
