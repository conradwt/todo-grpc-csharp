using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using ToDoGrpc.Data;
using ToDoGrpc.Models;

namespace ToDoGrpc.Services;

public class ToDoService : ToDoIt.ToDoItBase {
  private readonly AppDbContext _dbContext;

  public ToDoService(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public override async Task<CreateToDoResponse> CreateToDo(CreateToDoRequest request, ServerCallContext context)
  {
    if (request.Title == string.Empty || request.Description == string.Empty)
      throw new RpcException(new Status(StatusCode.InvalidArgument, "You must supply a valid object"));


    var toDoItem = new ToDoItem
    {
      Title = request.Title,
      Description = request.Description,
    };

    await _dbContext.AddAsync(toDoItem);
    await _dbContext.SaveChangesAsync();

    return await Task.FromResult(new CreateToDoResponse
    {
      Id = toDoItem.Id
    });
  }

  public override async Task<ReadToDoResponse> ReadToDo(ReadToDoRequest request, ServerCallContext context)
  {
    if (request.Id <= 0)
      throw new RpcException(new Status(StatusCode.InvalidArgument, "resource index must be greater than 0"));


    var toDoItem = await _dbContext.ToDoItems.FirstOrDefaultAsync(t => t.Id == request.Id);

    if (toDoItem != null) {
      return await Task.FromResult(new ReadToDoResponse
      {
        Id = toDoItem.Id,
        Title = toDoItem.Title,
        Description = toDoItem.Description,
        ToDoStatus = toDoItem.ToDoStatus
      });
    }

    throw new RpcException(new Status(StatusCode.NotFound, $"No task with id {request.Id}"));
  }

  public override async Task<GetAllResponse> ListToDo(GetAllRequest request, ServerCallContext context)
  {
    var response = new GetAllResponse();
    var toDoItems = await _dbContext.ToDoItems.ToListAsync();

    foreach(var toDo in toDoItems)
    {
      response.ToDo.Add(new ReadToDoResponse{
        Id = toDo.Id,
        Title = toDo.Title,
        Description = toDo.Description,
        ToDoStatus = toDo.ToDoStatus
      });
    }

    return await Task.FromResult(response);
  }
}
