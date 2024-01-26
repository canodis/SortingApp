using Kodris.SortingAlgorithms;

namespace Kodris.Utilities
{
    public class SortExecutor
    {
        /// <summary>
        /// Executes the specified sorting algorithm on the given integer array.
        /// </summary>
        /// <param name="sortAlgorithm">The sorting algorithm to execute.</param>
        /// <param name="array">The integer array to be sorted.</param>
        public void Execute(ISortAlgorithm sortAlgorithm, int[] array)
        {
            sortAlgorithm.Sort(array);
        }
    }
}