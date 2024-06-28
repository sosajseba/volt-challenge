using System.Text.Json;
using VoltChallenge.Entities;
using VoltChallenge.Services.Support;

namespace VoltChallenge.Services.Implementations;

public class ReportService
{
    public async Task GenerateReportAsync(string householdFilePath, string solarFilePath, string outputFilePath)
    {
        using FileStream fsHousehold = File.OpenRead(householdFilePath);
        using FileStream fsSolar = File.OpenRead(solarFilePath);

        var householdEnumerator = JsonSerializer.DeserializeAsyncEnumerable<HouseHold>(fsHousehold).GetAsyncEnumerator();
        var solarEnumerator = JsonSerializer.DeserializeAsyncEnumerable<SolarOutput>(fsSolar).GetAsyncEnumerator();

        var results = new List<ReportItem>();

        while (await householdEnumerator.MoveNextAsync() && await solarEnumerator.MoveNextAsync())
        {
            var household = householdEnumerator.Current;
            var solar = solarEnumerator.Current;

            if (household is not null && solar is not null)
            {
                double consumption = household.ElectricityConsumption - solar.SolarOutputValue;
                double saving = ReportHelper.GetCost(household.TimeStamp, solar.SolarOutputValue);

                var reportItem = new ReportItem
                {
                    TimeStamp = household.TimeStamp,
                    Consumption = $"{consumption} kW",
                    Saving = $"${saving}"
                };

                results.Add(reportItem);
            }
        }

        await householdEnumerator.DisposeAsync();
        await solarEnumerator.DisposeAsync();

        await File.WriteAllTextAsync(outputFilePath, JsonSerializer.Serialize(results));
    }
}