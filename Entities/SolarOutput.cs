using System.Text.Json.Serialization;

namespace VoltChallenge.Entities;

public class SolarOutput
{
    [JsonPropertyName("timestamp")]
    public DateTime TimeStamp { get; set; }
    [JsonPropertyName("solar_output")]
    public double SolarOutputValue { get; set; }
}