// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using System.Collections;
using System.Data;
using System.IO.IsolatedStorage;
using YMTDotNetTrainingBatch2.ConsoleApp;

//EfCoreExample example = new EfCoreExample();
//example.Delete();

// Testing LINQ 

// Where

LINQPractice linqPractice = new LINQPractice();
int[] result = linqPractice.Filter([1, 2, 3, 4, 5], 4); // [1, 2, 3, 5]

Console.WriteLine("Filtered : [{0}]", string.Join(",", result));

// Select

int[] result2 = linqPractice.AddAll([1, 2, 3, 4, 5], 3); // [4, 5, 6, 7, 8]
Console.WriteLine("Added Values : [{0}]", string.Join(",", result2));


// OrderBy

int[] result3 = linqPractice.sortAsc([5, 4, 3, 2, 1]); // [1, 2, 3, 4, 5]
Console.WriteLine("Sorted by ascending order : [{0}]", string.Join(",", result3));

// OrderByDescending

int[] result4 = linqPractice.sortDesc([1, 2, 3, 4, 5]); // [5, 4, 3, 2, 1]
Console.WriteLine("Sorted by descending order : [{0}]", string.Join(",", result4));

// First

int firstItem = linqPractice.getFirst(result4); // 5

// FirstOrDefault

int item = linqPractice.getFirstOrDefault([1, 2, 3]); // 1
Console.WriteLine("First item : " + item);
int nonExistent = linqPractice.getFirstOrDefault([]); //0

// Min and Max

int maximum = linqPractice.getMax([1, 2, 3, 4, 5]); // 5
int minimum = linqPractice.getMin([1, 2, 3, 4, 5]); // 1
Console.WriteLine("Maximum : " + maximum + "\n" + "Minimum : " + minimum);

// Average

double avg = linqPractice.getAvg([1, 2, 3, 4, 5]); //3.0
Console.WriteLine("Average of [1, 2, 3, 4, 5] : " + avg);

// Count

int length = linqPractice.getCount([1, 2, 3, 4, 5]); // 5
Console.WriteLine("Length of the array : " + length);

// Sum

int sumResult = linqPractice.getSum([1, 2, 3, 4, 5]); // 15
Console.WriteLine("Sum of [1, 2, 3, 4, 5] : " + sumResult);