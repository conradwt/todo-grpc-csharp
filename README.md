# ToDo gRPC C#

The purpose of this repository is to create a ToDo app with gRPC using the C# programming language.

## Getting Started

## Software requirements

- .Net 8.0.100-preview.7.23376.3 or newer

- Postman 10.17.3 or newer

Note: This tutorial was updated on macOS 13.5.1.

## Communication

- If you **need help**, use [Stack Overflow](http://stackoverflow.com/questions/tagged/grpc+csharp). (Tag 'grpc' and 'csharp')
- If you'd like to **ask a general question**, use [Stack Overflow](http://stackoverflow.com/questions/tagged/grpc+csharp).
- If you **found a bug**, open an issue.
- If you **have a feature request**, open an issue.
- If you **want to contribute**, submit a pull request.

## Quick Installation

1.  clone this repository

    ```zsh
    git clone git@github.com:conradwt/todo-grpc-csharp.git
    ```

2.  change the directory location

    ```zsh
    cd todo-grpc-csharp
    ```

3.  start the server

    ```zsh
    dotnet run
    ```

    Note: The REST API and gRPC service run on `https://localhost:7134`

## gRPC

1. list gRPC methods

   greet service:

   ```zsh
   grpcurl -proto Protos/greet.proto localhost:7134 list greet.Greeter
   ```

   todo service:

   ```zsh
   grpcurl -proto Protos/todo.proto localhost:7134 list todoit.ToDoIt
   ```

## REST API

1. create todo item

   ```zsh
   curl -XPOST https://localhost:7134/v1/todos \
    -H 'Content-Type: application/json' \
    -d '{
    "title": "REST create todo title",
    "description": "REST create todo description"
   }'
   ```

2. read todo item

   ```zsh
   curl -XGET https://localhost:7134/v1/todos \
    -H 'Content-Type: application/json' \
    -d '{"id": 1}'
   ```

   or

   ```zsh
   curl -XGET https://localhost:7134/v1/todos/1 \
    -H 'Content-Type: application/json'
   ```

3. update todo item

   ```zsh
   curl -XPUT https://localhost:7134/v1/todos \
   -H 'Content-Type: application/json' \
   -d '{
    "id": 6,
    "title": "REST API update todo title",
    "description": "REST API update todo description",
    "to_do_status": "IN PROGRESS"
   }'
   ```

4. list todo item

   ```zsh
   curl -XGET https://localhost:7134/v1/todos \
    -H 'Content-Type: application/json'
   ```

5. delete todo item

   ```zsh
   curl -XDELETE https://localhost:7134/v1/todos \
    -H 'Content-Type: application/json' \
    -d '{"id": 1}'
   ```

   or

   ```zsh
   curl -XDELETE https://localhost:7134/v1/todos/1 \
    -H 'Content-Type: application/json'
   ```

## Support

Bug reports and feature requests can be filed with the rest for the Phoenix project here:

- [File Bug Reports and Features](https://github.com/conradwt/todo-grpc-csharp/issues)
