using Kodris.SortingAlgorithms;
using KodrisProject.Utilities;

namespace Kodris.Utilities
{
    public class SortAlgorithmFactory
    {
        /// <summary>
        /// Creates an instance of the specified sorting algorithm.
        /// </summary>
        /// <param name="algorithmType">The type of sorting algorithm to create.</param>
        /// <returns>An instance of the specified sorting algorithm.</returns>
        /// <exception cref="ArgumentException">Thrown when an invalid sorting algorithm type is provided.</exception>
        public static ISortAlgorithm Create(SortingAlgorithmTypes algorithmType)
        {
            switch (algorithmType)
            {
                case SortingAlgorithmTypes.BubbleSort:
                    return new BubbleSort();
                case SortingAlgorithmTypes.MergeSort:
                    return new MergeSort();
                default:
                    throw new ArgumentException("Invalid sorting algorithm type");
            }
        }
    }
}