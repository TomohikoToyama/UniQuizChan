using UniRx;

public class CounterModel_Q
{
    public  IReactiveProperty<int> Counter => countNumber;
    private ReactiveProperty<int> countNumber = new ReactiveProperty<int>();
    
    /// <summary>
    /// 数値を上昇する
    /// </summary>
    public void AddCount()
    {
        countNumber.Value += 1;
    }

    /// <summary>
    /// 数値を減少する
    /// </summary>
    public void ReduceCount()
    {
        countNumber.Value -= 1;
    }
}
