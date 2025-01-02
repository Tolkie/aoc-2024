using shared;

var inputLines = FileHelper.GetInputLines();

var data = new List<List<int>>();

const string numberSeparator = " ";

foreach (var numbers in inputLines.Select(line => line.Split(numberSeparator)))
{
    data.Add(numbers.Select(int.Parse).ToList());
}

var validReports = 0;
var validReportsDampened = 0;

foreach (var report in data)
{
    if ((IsAscending(report) || IsDescending(report)) && HasSafeSteps(report))
    {
        validReports++;
    }
    else
    {
        for (var i = 0; i < report.Count; i++)
        {
            var reportCopy = report.Where((_, index) => index != i).ToList();
            if ((IsAscending(reportCopy) || IsDescending(reportCopy)) && HasSafeSteps(reportCopy))
            {
                validReportsDampened++;
                break;
            }
        }
    }
}

FileHelper.WriteOutput(validReports.ToString(), "output_1.txt");
FileHelper.WriteOutput((validReports + validReportsDampened).ToString(), "output_2.txt");
return;

bool HasSafeSteps(List<int> report)
{
    for (var i = 1; i < report.Count; i++)
    {
        var step = Math.Abs(report[i] - report[i - 1]);

        if (step == 0 || step > 3)
        {
            return false;
        }
    }
    
    return true;
}

bool IsAscending(List<int> report)
{
    for (var i = 1; i < report.Count; i++)
    {
        if (report[i] < report[i - 1])
        {
            return false;
        }
    }
    
    return true;
}

bool IsDescending(List<int> report)
{
    for (var i = 1; i < report.Count; i++)
    {
        if (report[i] > report[i - 1])
        {
            return false;
        }
    }
    
    return true;
}
