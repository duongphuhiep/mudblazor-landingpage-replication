using Microsoft.Extensions.Logging;

namespace DaisyMudDomain;

public class StatsService(ILogger<StatsService> _logger)
{
    public async ValueTask<StatsData> GetStats(CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetStats");

        //Simulate getting data from external sources
        await Task.Delay(SimulationOptions.DelaySeconds * 1000, cancellationToken);

        return new StatsData("16.6M", "9.2k", "451", "5.1k");
    }
}