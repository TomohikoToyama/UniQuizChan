using UniRx;

public class CounterModel_A
{
    public  IReactiveProperty<int> Counter => countNumber;
    private ReactiveProperty<int> countNumber = new ReactiveProperty<int>();
    
    /// <summary>
    /// Add count value.
    /// </summary>
    public void AddCount()
    {
        countNumber.Value += 1;
    }

    /// <summary>
    /// Reduce count value.
    /// </summary>
    public void ReduceCount()
    {
        countNumber.Value -= 1;
    }
}
