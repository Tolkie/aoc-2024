using System.Text.RegularExpressions;
using shared;


var inputLines = FileHelper.GetInputLines();

var result = 0;
var secondResult = 0;

foreach (var line in inputLines)
{
    var instructions = ExtractValidMulInstructions(line);
    var filteredInstructions = ExtractValidMulInstructionsWithDo(line);
    
    result += ComputeInstructions(instructions);
    secondResult += ComputeInstructions(filteredInstructions);
}


FileHelper.WriteOutput(result.ToString(), "output_1.txt");
FileHelper.WriteOutput(secondResult.ToString(), "output_2.txt");
return;

List<string> ExtractValidMulInstructions(string input)
{
    var pattern = @"mul\(\d{1,3},\d{1,3}\)";
    var matches = Regex.Matches(input, pattern);
    return matches.Select(m => m.Value).ToList();
}

List<string> ExtractValidMulInstructionsWithDo(string input)
{
    var pattern = @"(mul\((\d+),(\d+)\)|do\(\)|don't\(\))";
    var matches = Regex.Matches(input, pattern);
    var instructions =  matches.Select(m => m.Value).ToList();

    var cleanedInstructions = new List<string>();
    var shouldAdd = true;
    
    foreach (var instruction in instructions)
    {
        if (shouldAdd && instruction != "do()" && instruction != "don't()")
        {
            cleanedInstructions.Add(instruction);
        }

        shouldAdd = instruction switch
        {
            "do()" => true,
            "don't()" => false,
            _ => shouldAdd
        };
    }

    return cleanedInstructions;
}

int ComputeInstructions(List<string> instructions)
{
    var multiplicationResult = 0;
    foreach (var instruction in instructions)
    {
        try
        {
            var values = instruction.Replace("mul(", "").Replace(")", "").Split(",").Select(int.Parse).ToList();
            multiplicationResult += values[0] * values[1];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
    }

    return multiplicationResult;
}

