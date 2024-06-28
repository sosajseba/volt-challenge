using System.Diagnostics;
using VoltChallenge.Services.Implementations;

Stopwatch stopWatch = new();
stopWatch.Start();

string? electricityFilePath = Environment.GetEnvironmentVariable("HOUSEHOLD_FILE_PATH");
string? solarFilePath = Environment.GetEnvironmentVariable("SOLAR_FILE_PATH");
string? reportFilePath = Environment.GetEnvironmentVariable("REPORT_FILE_PATH");

if (string.IsNullOrEmpty(electricityFilePath) || string.IsNullOrEmpty(solarFilePath) || string.IsNullOrEmpty(reportFilePath))
{
    Console.WriteLine("Error: You must configure HOUSEHOLD_FILE_PATH, SOLAR_FILE_PATH and REPORT_FILE_PATH env vars.");
    return;
}

Console.WriteLine($"Generating report...");

ReportService reportService = new();

await reportService.GenerateReportAsync(electricityFilePath, solarFilePath, reportFilePath);

stopWatch.Stop();

TimeSpan ts = stopWatch.Elapsed;

string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

Console.WriteLine($"Report generated!");
Console.WriteLine($"Execution time: {elapsedTime}");