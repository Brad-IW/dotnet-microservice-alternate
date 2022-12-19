FROM postgres:15.1-alpine

ENV POSTGRES_PASSWORD docker
ENV POSTGRES_DB userdb

COPY deploy.sql /docker-entrypoint-initdb.d/
