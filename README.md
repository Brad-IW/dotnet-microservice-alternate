# DotNET Microservice Kong/PostgreSQL Version

## Installation Guide

This guide assumes that [Docker](https://docs.docker.com/get-docker/) has already been installed and initialised.

1. Clone this repo and extract the files.
2. Open a terminal and navigate to the dotnet-microservice-alternate folder.
3. Run `docker-compose up`
    
    Once the compose file has finished its start up procedure the API will be available at `http://localhost/api/users`. If you are trying to access the API from another device replace `localhost` with the server ip address or domain name. 
    
4. After ensuring that the container has built and ran successfully, and that and the API is available and working, type `CTRL + C` (or `COMMAND + C` on Linux and Mac) into your terminal to stop the containers.
5. Run `docker-compose up -d` to run the container in the background.
