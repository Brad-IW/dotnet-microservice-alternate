#!/bin/sh
result=0
correct=200

while [ "$result" -ne "$correct" ]
do
    result=`curl -s -o /dev/null -w "%{http_code}" http://kong:8001/`
    sleep 1
done

curl -i -X POST http://kong:8001/services \
    -H "Content-Type: application/json" \
    -d '{ "port": 80, "protocol": "http", "name": "UsersAPIService", "path": "/api/Users", "host": "api"}'

curl -i -X POST http://kong:8001/services/UsersAPIService/routes \
    -H "Content-Type: application/json" \
    -d '{ "name": "UsersAPIRoute", "protocols": [ "http", "https" ], "paths": [ "/api/users" ] }'

