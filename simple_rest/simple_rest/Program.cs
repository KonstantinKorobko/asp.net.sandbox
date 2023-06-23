using System;
using System.Text.RegularExpressions;

List<Person> users = new List<Person>
{
    new() { Id = Guid.NewGuid().ToString(), Name = "Tom", Age = 37 },
    new() { Id = Guid.NewGuid().ToString(), Name = "Bob", Age = 41 },
    new() { Id = Guid.NewGuid().ToString(), Name = "Sam", Age = 24 }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (context) =>
{
    var responce = context.Response;
    var request = context.Request;
    var path = request.Path;

    string expressionForGuid = @"^/api/users/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";

    if ((path == "api/users") && (request.Method == "GET"))
    {
        await GetAllPeaple(responce);
    }
    else if (Regex.IsMatch(path, expressionForGuid) && (request.Method == "GET"))
    {
        string? id = path.Value?.Split("/")[3];
        await GetPerson(id, responce);
    }
    else if ((path == "api/users") && (request.Method == "POST"))
    {
        await CreatePersone(responce, request);
    }
    else if ((path == "api/users") && (request.Method == "PUT"))
    {
        await UpdatePersone(responce, request);
    }
    else if (Regex.IsMatch(path, expressionForGuid) && (request.Method == "DELETE"))
    {
        string? id = path.Value?.Split("/")[3];
        await DeletePersone(id, responce);
    }
    else
    {
        responce.ContentType = "text/html; charset=utf-8";
        await responce.SendFileAsync("html/index.html");
    }
});

app.Run();

async Task CreatePersone(HttpResponse response, HttpRequest request)
{
    try
    {
        var user = await request.ReadFromJsonAsync<Person>();
        if (user != null)
        {
            user.Id = Guid.NewGuid().ToString();
            users.Add(user);
            await response.WriteAsJsonAsync(user);
        }
        else
        {
            throw new Exception("Incorrect data.");
        }
    }
    catch (Exception)
    {
        response.StatusCode = 400;
        await response.WriteAsJsonAsync(new { message = "Incorrect data." });
    }
}
async Task UpdatePersone(HttpResponse response, HttpRequest request)
{
    try
    {
        Person? userData = await request.ReadFromJsonAsync<Person>();
        if (userData != null)
        {
            var user = users.FirstOrDefault(u => u.Id == userData.Id);
            if (user != null)
            {
                user.Age = userData.Age;
                user.Name = userData.Name;
                await response.WriteAsJsonAsync(user);
            }
            else
            {
                response.StatusCode = 404;
                await response.WriteAsJsonAsync(new { message = "User not found." });
            }
        }
        else
        {
            throw new Exception("Incorrect data.");
        }
    }
    catch (Exception)
    {
        response.StatusCode = 400;
        await response.WriteAsJsonAsync(new { message = "Incorrect data." });
    }
}
async Task DeletePersone (string? id, HttpResponse response)
{
    Person? user = users.FirstOrDefault (u => u.Id == id);
    if (user != null)
    {
        users.Remove(user);
        await response.WriteAsJsonAsync(user);
    }
    else 
    {
        response.StatusCode = 404;
        await response.WriteAsJsonAsync(new { message = "User not found." });
    }
}
async Task GetAllPeaple(HttpResponse response)
{
    await response.WriteAsJsonAsync(users);
}
async Task GetPerson(string? id, HttpResponse response)
{
    Person? user = users.FirstOrDefault((u) => u.Id == id);
    if (user != null)
    {
        await response.WriteAsJsonAsync(user);
    }
    else
    {
        response.StatusCode = 404;
        await response.WriteAsJsonAsync(new { message = "User not found" });
    }
}

public class Person
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public int Age { get; set; }
};
