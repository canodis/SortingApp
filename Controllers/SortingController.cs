using System;
using KodrisProject.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Kodris.Utilities;
using Kodris.SortingAlgorithms;
using Kodris.Services;

public class SortingController : Controller
{
    private readonly SortingDbContext _context;
    SortingService _sortingService;

    public SortingController(SortingDbContext context)
    {
        _context = context;
        _sortingService = new SortingService(_context);
    }

    public IActionResult History()
    {
        var history = _context.SortingHistories.ToList();
        return View(history);
    }


    /// <summary>
    /// Executes a sorting algorithm on an array of integers, records the history, and returns the result.
    /// </summary>
    /// <param name="numbers">A string of integers to be sorted, separated by commas and spaces.</param>
    /// <param name="algorithm">The selected sorting algorithm.</param>
    /// <returns>Returns the sorted array and execution time if successful, or an error view with a message if there's an issue.</returns>
    [HttpPost]
    public async Task<IActionResult> Execute(string numbers, string algorithm)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            int[] array = ParseNumbers(numbers);
            if (array.Length < 2)
            {
                throw new Exception("Please enter at least 2 numbers.");
            }
            if (IsSorted(array))
            {
                throw new Exception("The numbers are already sorted.");
            }
            ISortAlgorithm sortAlgorithm = SortAlgorithmFactory.Create(Enum.Parse<SortingAlgorithmTypes>(algorithm));
            new SortExecutor().Execute(sortAlgorithm, array);

            stopwatch.Stop();

            var viewModel = new SortResultViewModel(array, stopwatch.Elapsed);
            string output = string.Join(", ", array);

            await _sortingService.SaveSortHistory(algorithm, numbers, output);

            return View("Result", viewModel);
        }
        catch (Exception ex)
        {
            return View("Error", ex.Message);
        }
    }

    /// <summary>
    /// Parses a string containing comma-separated or space-separated integers into an array of integers.
    /// </summary>
    /// <param name="numbers">The input string containing integers.</param>
    /// <returns>An array of integers parsed from the input string.</returns>
    private int[] ParseNumbers(string numbers)
    {
        char[] delimiters = new char[] { ',', ' ' };
        return numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                      .Select(int.Parse)
                      .ToArray();
    }

    /// <summary>
    /// Checks if an array of integers is sorted in ascending order.
    /// </summary>
    /// <param name="array">The array of integers to check for sorting.</param>
    /// <returns>True if the array is sorted in ascending order; otherwise, false.</returns>
    private bool IsSorted(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1])
            {
                return false;
            }
        }
        return true;
    }
}
