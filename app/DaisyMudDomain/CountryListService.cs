using Microsoft.Extensions.Logging;

namespace DaisyMudDomain;

public class CountryListService(ILogger<CountryListService> _logger)
{
    public async ValueTask<string[]> GetCountryList(CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetCountryList");

        //Simulate getting data from external sources
        await Task.Delay(SimulationOptions.DelaySeconds * 1000, cancellationToken);

        return
        [
            "United_States",
            "United_Kingdom",
            "Sweden",
            "Germany",
            "Egypt",
            "Brazil",
            "South_Africa",
            "Russia"
        ];
    }
}