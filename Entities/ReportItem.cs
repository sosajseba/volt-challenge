using System.Text.Json.Serialization;

namespace VoltChallenge.Entities;

public class ReportItem
{
    [JsonPropertyName("timestamp")]
    public DateTime TimeStamp { get; set; }
    [JsonPropertyName("total_consumption")]
    public string? Consumption { get; set; }
    [JsonPropertyName("saving")]
    public string? Saving { get; set; }
}