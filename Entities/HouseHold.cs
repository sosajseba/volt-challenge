using System.Text.Json.Serialization;

namespace VoltChallenge.Entities;

public class HouseHold
{
    [JsonPropertyName("timestamp")]
    public DateTime TimeStamp { get; set; }
    [JsonPropertyName("electricity_consumption")]
    public double ElectricityConsumption { get; set; }
}