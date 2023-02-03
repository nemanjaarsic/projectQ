# projectQ
## Run app
Best way to test the app is to run it in a docker container.
To do that clone the repository and from location of the `Docker-compose.yml` file run following command
```
docker compose up
```

To test the app do the follwing
* Frontend
Client UI is located on follwing address `http://localhost:3000`. From there you can send new emails and see email history of a user.

***Note:** it is recomended to use firefox brawser with `CORS Everywhere` addon other wise CORS might cause problems*
* Backend
Swagger for backend is on following address `http://localhost:50010/swagger/index.html`. From there you can send requests to server
* Database
Database has some initial data, five users and one email.
To see what is in database run following commands:
Start terminal in container
```
docker exec -it {container id} /bin/sh
```
Connect to database and 
```
psql postgresql://{user}:{pass}@localhost:5432/postgres
\l - list databases
\c {database name} - connect to database
\dt or \dt+ - list tables
```
Simple query example:
```
SELECT * FROM "Users";
```
*Note: query is case insensitive and quate marks on table name are necesery* 
