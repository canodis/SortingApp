namespace Kodris.SortingAlgorithms
{
    public class MergeSort : ISortAlgorithm
    {
        public void Sort(int[] array)
        {
            if (array.Length <= 1)
                return;

            int mid = array.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[array.Length - mid];

            for (int i = 0; i < mid; i++)
                left[i] = array[i];
            for (int i = mid; i < array.Length; i++)
                right[i - mid] = array[i];

            Sort(left);
            Sort(right);
            Merge(array, left, right);
        }

        private void Merge(int[] arr, int[] left, int[] right)
        {
            int leftIndex = 0, rightIndex = 0, arrIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] <= right[rightIndex])
                {
                    arr[arrIndex] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    arr[arrIndex] = right[rightIndex];
                    rightIndex++;
                }
                arrIndex++;
            }

            while (leftIndex < left.Length)
            {
                arr[arrIndex] = left[leftIndex];
                leftIndex++;
                arrIndex++;
            }

            while (rightIndex < right.Length)
            {
                arr[arrIndex] = right[rightIndex];
                rightIndex++;
                arrIndex++;
            }
        }
    }
}