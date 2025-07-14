using Microsoft.Extensions.Logging;

namespace ToolsPack.Blazor;

public static class TaskExtensions
{
    public static async void FireAndForget(this Task task, ILogger? logger = null)
    {
        try
        {
            await task;
        }
        catch (Exception ex)
        {
            if (logger is null)
                Console.WriteLine($"FireAndForget unhandled exception {ex}");
            else
                logger.LogError(task.Exception, "FireAndForget unhandled exception");
        }
    }
}