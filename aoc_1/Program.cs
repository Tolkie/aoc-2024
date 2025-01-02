using shared;


var inputLines = FileHelper.GetInputLines();

var firstList = new List<int>();
var secondList = new List<int>();

const string numberSeparator = "   ";

foreach (var numbers in inputLines.Select(line => line.Split(numberSeparator)))
{
    firstList.Add(int.Parse(numbers[0]));
    secondList.Add(int.Parse(numbers[1]));
}

firstList.Sort();
secondList.Sort();

var totalDifference = 0;
var similarityScore = 0;
for (var i = 0; i < firstList.Count; i++)
{
    totalDifference += Math.Abs(firstList[i] - secondList[i]);
    similarityScore += firstList[i] * secondList.Count(x => x == firstList[i]);
}

FileHelper.WriteOutput(totalDifference.ToString(), "output_1.txt");
FileHelper.WriteOutput(similarityScore.ToString(), "output_2.txt");