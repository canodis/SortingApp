
/// <summary>
/// View model for the sorting result.
/// </summary>
public class SortResultViewModel
{
    public int[] SortedArray { get; set; }
    public TimeSpan ElapsedTime { get; set; }

    public SortResultViewModel(int[] sortedArray, TimeSpan elapsedTime)
    {
        SortedArray = sortedArray;
        ElapsedTime = elapsedTime;
    }
}
