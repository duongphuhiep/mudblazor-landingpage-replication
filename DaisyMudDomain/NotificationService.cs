using Microsoft.Extensions.Logging;

namespace DaisyMudDomain;

public class NotificationService(ILogger<NotificationService> _logger)
{
    private readonly SemaphoreSlim _semaphore = new(1, 1);
    private Notification[]? _cachedNotifications;

    public async ValueTask<Notification[]> GetNotifications(CancellationToken cancellationToken)
    {
        if (_cachedNotifications is null)
        {
            await _semaphore.WaitAsync(cancellationToken);
            try
            {
                _cachedNotifications ??= await GetNotificationsInDatabase(cancellationToken);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        return _cachedNotifications;
    }

    private async ValueTask<Notification[]> GetNotificationsInDatabase(CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetNotificationsInDatabase");

        //Simulate getting data from external sources
        await Task.Delay(SimulationOptions.DelaySeconds * 1000, cancellationToken);

        return
        [
            new Notification
            {
                Title = "v8: Riding the Momentum of v7",
                Author = "The MudBlazor Team",
                Date = "Jan 19, 2025"
            },
            new Notification
            {
                Title = "v7 Is Here",
                Author = "The MudBlazor Team",
                Date = "Jun 29, 2024"
            },
            new Notification
            {
                Title = "MudBlazor is here to stay",
                Author = "Jonny Larsson",
                Date = "Jan 13, 2022"
            }
        ];
    }
}