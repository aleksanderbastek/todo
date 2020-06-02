# Todo app backend

### To run this project open `PROJECT_DIRECTORY/backend` in your terminal and run following commands:
- `docker-compose -f docker-compose.debug.yml build`
- `docker-compose -f docker-compose.debug.yml up`

### Then you can access following services:
- Backend: [http://localhost:5000](http://localhost:5000)
- GraphQL endpoint: [http://localhost:5000/graphql](http://localhost:5000/graphql)
- GraphQL Playground: [http://localhost:5000/graphql/playground](http://localhost:5000/graphql/playground)
- GraphQL Voyager: [http://localhost:5000/graphql/voyager](http://localhost:5000/graphql/voyager)

## Example queries for quick start:
- "Hello world! :)"
```graphql
query {
	sayHelloWorld
}
```
- "Hello Janusz!"
```graphql
query {
	sayHelloFor(name: "Janusz")
}
```
- Mix your queries:
```graphql
query {
	sayHelloWorld
	sayHelloFor(name: "Janusz")
}
```
- Complex query example:
```graphql
query {
	userDataById(id: "2464342443646") {
		id
		accountDetails {
			creationDate
			isAdministrator
			lastLoginTime
		}
		info {
			name
			age
		}
	}
}
```
## Example mutation:
```graphql
mutation {
	changeHelloWord(newName: "Siemaneczko") {
		success
		newName
	}
}
```

### Play with GraphQL and try its syntax and code autocompletion!