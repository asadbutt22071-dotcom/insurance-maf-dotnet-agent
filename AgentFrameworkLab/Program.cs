// Program.cs — Console Interactive Agent

using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using OllamaSharp;

IChatClient chatClient = new OllamaApiClient(
    new Uri("http://localhost:11434/"), "llama3.2");

AIAgent agent = chatClient.AsAIAgent(
    name: "LogisticsAgent",
    instructions: "You are a logistics assistant.");

Console.WriteLine("Logistics Assistant (type 'exit' to quit)");
Console.WriteLine("==========================================");

while (true)
{
    Console.Write("\nYou: ");
    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input) || input.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
        break;

    var response = await agent.RunAsync(input);
    Console.WriteLine($"Agent: {response}");
}
