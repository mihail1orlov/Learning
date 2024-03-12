using ClosedXML.Excel;
using Newtonsoft.Json;

string jsonFilePath = "C:\\tmp\\faults\\Surface2dPoints.json";
string json = File.ReadAllText(jsonFilePath);

var points = JsonConvert.DeserializeObject<List<Point>>(json);

using (var workbook = new XLWorkbook())
{
    var worksheet = workbook.AddWorksheet("Points");

    worksheet.Cell(1, 1).Value = "Md";
    worksheet.Cell(1, 2).Value = "Tvd";
    worksheet.Cell(1, 3).Value = "Vs";
    worksheet.Cell(1, 4).Value = "Thl";
    worksheet.Cell(1, 5).Value = "East";
    worksheet.Cell(1, 6).Value = "North";

    int row = 2;
    foreach (var point in points)
    {
        worksheet.Cell(row, 1).Value = point.Md;
        worksheet.Cell(row, 2).Value = point.Tvd;
        worksheet.Cell(row, 3).Value = point.Vs;
        worksheet.Cell(row, 4).Value = point.Thl;
        worksheet.Cell(row, 5).Value = point.East;
        worksheet.Cell(row, 6).Value = point.North;
        row++;
    }

    workbook.SaveAs("C:\\tmp\\faults\\Surface2dPoints.xlsx");
}

Console.WriteLine("Excel file was created!!!");

public class Point
{
    public double Md { get; set; }
    public double Tvd { get; set; }
    public double Vs { get; set; }
    public double Thl { get; set; }
    public double East { get; set; }
    public double North { get; set; }
}