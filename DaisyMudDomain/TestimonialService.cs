using Microsoft.Extensions.Logging;

namespace DaisyMudDomain;

public class TestimonialService(ILogger<TestimonialService> _logger)
{
    public async ValueTask<Testimonial[]> GetTestimonials(CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetTestimonials");

        //Simulate getting data from external sources
        await Task.Delay(SimulationOptions.DelaySeconds * 1000, cancellationToken);

        return
        [
            new Testimonial("Brian", "EvoDynamic",
                "Coming of an Angular project back to .NET, Blazor was the ideal choice and MudBlazor was the icing on the cake. . . not \"mud\" but a rich creamy sweet chocolate. Developer"),
            new Testimonial("Developer Team", "Wunderminds",
                "Saving us from tons of tiny details and allowing us to deliver sharp looking modern web applications, MudBlazor is the king of open source UI frameworks that no one should miss when building apps with Blazor!"),
            new Testimonial("", "Wave Master",
                "Comprehensive, ambitious, fresh and clean. Some really cool implementations. The development and improvement of components is really fast, and if a course correction is needed, they will do it. Garderoben, henon and all the other contributors are approachable. They are getting stuff done!"),
            new Testimonial("Karakoulak Spyridon", "Arhs Group",
                "Best open source component library for Blazor out there and easy to understand!"),
            new Testimonial("Hayden Ravenscroft", "Mail Solutions UK Ltd",
                "A comprehensive library. Takes the hassle out of designing for Blazor. Used in many ongoing projects at the Mail Solutions Group. The MudBlazor team has a real gem here."),
            new Testimonial("Frederik", "Xuntar",
                "Very practical, convenient and user-friendly library that has massively helped us in developing our applications. Great community as well!")
        ];
    }
}