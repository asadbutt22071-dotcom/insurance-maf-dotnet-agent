// Program.cs — ASP.NET Core Minimal API + Agent 
using Microsoft.AspNetCore.Builder;
using Microsoft.Agents.AI;

using Microsoft.Extensions.AI;

using OllamaSharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;



var builder = WebApplication.CreateBuilder(args);



// Register IChatClient in DI 

builder.Services.AddSingleton<IChatClient>(

    new OllamaApiClient(

        new Uri("http://localhost:11434/"), "llama3.2"));



var app = builder.Build();



app.MapPost("/api/chat", async (

    IChatClient chatClient, ChatRequest request) =>

{

    AIAgent agent = chatClient.AsAIAgent(

        name: "InsuranceHelper",

        instructions: "You are an insurance assistant.");



    var response = await agent.RunAsync(request.Message);

    return Results.Ok(new { reply = response.ToString() });

});



app.Run();



record ChatRequest(string Message);