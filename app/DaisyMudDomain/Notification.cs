namespace DaisyMudDomain;

public record Notification
{
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public string Date { get; set; } = "";
}