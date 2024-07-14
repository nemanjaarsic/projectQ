# projectQ
## Run app
### Local
To run locally clone the repository and do the following
* Frontend

```
cd Frontend
npm start
```
* Backend

```
cd Backend
dotnet run
```

Or open solution in visual studio code and press run button (http/https)

***Note:** Ports and db connection string are configured to run in docker environment, that will need to be changed for app to work locally. `BASE_URL` on frontend and `DB_CONNECTION_STRING` on backend*
### Docker
Best way to test the app is to run it in a docker container.
To do so, clone the repository and from the location of the `Docker-compose.yml` file run following command:
```
docker compose up
```

To use the app do following:
* Frontend

Client UI is located on follwing address `http://localhost:3000`. From there you can send new emails and see email history of a user.

***Note:** it is recomended to use firefox browser with `CORS Everywhere` addon otherwise CORS might cause problems*
* Backend

Swagger for backend is on following address `http://localhost:50010/swagger/index.html`. From there you can send requests to server
* Database

Database has some initial data, five users and one email.
To see what is in database run following commands:

```
docker container ls
docker inspect {container Id} | grep Id
docker exec -it {container id} /bin/sh
psql postgresql://{user}:{pass}@localhost:5432/postgres
\l
\c {database name}
\dt
SELECT * FROM "Users";
```

Command description:

`docker container ls` - list container to see some main details

`docker inspect {container id} | grep Id` - *inspect* will show all details of the specified container. With *gerp Id* it will show only the Id

`docker exec -it {container id} /bin/sh` - opens terminal in the container

`psql postgresql://{user}:{pass}@localhost:5432/postgres` - connect to the server and a database

`\l` - list databases

`\c {database name}` - connect to the specified database

`\dt or \dt+` - list tables or list tables with more details

`\d+ {table_name}` - list table columns and indexes

`SELECT * FROM "Users";` - simple query example. *Query is case insensitive and quote marks on table name are necesery* 

