// Program.cs — Minimal Agent with Ollama 

using Microsoft.Agents.AI;

using Microsoft.Extensions.AI;

using OllamaSharp;



// 1. Create the Ollama chat client 

IChatClient chatClient = new OllamaApiClient(

    new Uri("http://localhost:11434/"), "llama3.2");



// 2. Create an AIAgent from the chat client 

AIAgent agent = chatClient.AsAIAgent(

    name: "InsuranceHelper",

    instructions: "You are an insurance underwriting assistant. " +

        "Help users with property and general insurance queries. " +

        "Keep answers concise and professional.");



// 3. Non-streaming: get complete response 

Console.WriteLine(await agent.RunAsync(

    "What factors affect property insurance premiums?"));



// 4. Streaming: token by token 

await foreach (var update in agent.RunStreamingAsync(

    "Explain the difference between replacement cost and ACV."))

{

    Console.Write(update);

}