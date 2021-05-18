using UniRx;

public class TimerData
{
    public IReactiveProperty<int> ElapsedTime => _elapsedTime;
    private ReactiveProperty<int> _elapsedTime = new ReactiveProperty<int>();
    public IReactiveProperty<bool> IsStart => isStart;
    ReactiveProperty<bool> isStart = new ReactiveProperty<bool>();
    
    public TimerData(int num)
    {
        _elapsedTime.Value = num;
    }
    public void ChangeTime()
    {
        _elapsedTime.Value += 1;
    }

    public void TimerStart(bool flg)
    {
        isStart.Value = flg;
    }
}
