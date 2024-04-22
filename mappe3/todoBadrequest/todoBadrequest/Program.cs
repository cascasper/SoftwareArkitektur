using todoBadrequest;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<TodoTask> tasks = new List<TodoTask>();

app.MapGet("/", () => "todo med fejlhåndtering");
app.MapGet("/api/tasks", () => tasks);

app.MapGet("/api/tasks/{id}", (int id) => tasks[id]);

app.MapPost("/api/tasks", (TodoTask newTask) =>
{
    /*her er fejlhåndteringen af 400 bad request*/
    if (newTask == null)
    {
        return Results.BadRequest("New task cannot be null.");
    }

    if (string.IsNullOrWhiteSpace(newTask.Text))
    {
        return Results.BadRequest("Task text cannot be empty.");
    }   
    tasks.Add(newTask);
    return Results.Ok(newTask);
});

app.MapPut("/api/tasks/{id}", (int id, TodoTask updatedTask) =>
{
    tasks[id] = updatedTask;
    return Results.Ok(updatedTask);
});

app.MapDelete("/api/tasks/{id}", (int id) =>
{
    tasks.RemoveAt(id);
    return Results.Ok();
});

app.Run();