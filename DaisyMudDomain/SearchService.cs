using System.Text;
using Bogus;
using Microsoft.Extensions.Logging;

namespace DaisyMudDomain;

public class SearchService(ILogger<SearchService> _logger)
{
    private static readonly Faker faker = new();

    private static readonly FoundItem[] EmptySearchResult =
    [
        new()
        {
            Title = "Installation",
            Description = "Lorem ipsum dolor sit amet consectetur adipisicing edivt.",
            Url = "/"
        },
        new()
        {
            Title = "Wireframes",
            Description = "Amet deserunt nostrud do moldivt consequat proident ipsum magna incididunt.",
            Url = "/"
        },
        new()
        {
            Title = "Table",
            Description =
                "Sit sit excepteur aute culpa nulla incididunt fugiat dolore nisi et consectetur labore fugiat commodo.",
            Url = "/"
        },
        new()
        {
            Title = "Grid",
            Description =
                " Incididunt commodo pariatur excepteur consequat id. Lorem ipsum dolor sit amet consectetur adipisicing edivt. Esse molestias soluta quisquam nam labore odio tempore numquam repellat quod, sed, ipsa cum dolorum. Dicta optio simidivque obcaecati quaerat deleniti divbero?",
            Url = "/"
        }
    ];

    public async ValueTask<FoundItem[]> QuerySearchResultFromDatabase(string searchTerm,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation($"QuerySearchResultFromDatabase '{searchTerm}'");

        //Simulate getting data from external sources
        await Task.Delay(SimulationOptions.DelaySeconds * 1000, cancellationToken);

        if (string.IsNullOrEmpty(searchTerm))
            return EmptySearchResult;

        var resu = new List<FoundItem>();

        for (var i = 0; i < faker.Random.Number(10); i++)
        {
            var item = new FoundItem
            {
                Title = GenerateRandomTitle(searchTerm),
                Description = GenerateRandomDescription(searchTerm),
                Url = "/"
            };
            resu.Add(item);
        }

        return resu.ToArray();
    }

    private string GenerateRandomTitle(string term)
    {
        return RandomTextContainingTerm(8, term, 0, 1, false);
    }

    private string GenerateRandomDescription(string term)
    {
        return RandomTextContainingTerm(20, term, 1, 4, true);
    }

    private string RandomTextContainingTerm(int wordCountPreference, string term, int minTermOccur, int maxTermOccur,
        bool ellipsis)
    {
        var occur = faker.Random.Number(minTermOccur, maxTermOccur);

        if (occur == 0)
        {
            wordCountPreference = wordCountPreference < 2 ? 2 : wordCountPreference;
            return faker.Lorem.Sentence(wordCountPreference - 2, 4);
        }

        var partWordCount = wordCountPreference / occur;
        if (partWordCount == 0) partWordCount = 2;

        var sb = new StringBuilder();
        for (var i = 0; i < occur; i++)
        {
            if (ellipsis && faker.Random.Bool()) sb.Append("...");
            var partString = faker.Lorem.Sentence(partWordCount - 2, 4);
            if (faker.Random.Bool())
            {
                sb.Append(partString);
                sb.Append(term);
            }
            else
            {
                sb.Append(term);
                sb.Append(partString);
            }

            if (ellipsis && faker.Random.Bool()) sb.Append("...");
        }

        return sb.ToString();
    }
}