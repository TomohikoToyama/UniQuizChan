using UniRx;

public class TimerData
{
    public IReactiveProperty<int> ElapsedTime => _elapsedTime;
    private ReactiveProperty<int> _elapsedTime = new ReactiveProperty<int>();
    public IReactiveProperty<bool> IsStart => isStart;
    ReactiveProperty<bool> isStart = new ReactiveProperty<bool>();
    
    /// <summary>
    /// タイマーの時間を設定する
    /// </summary>
    /// <param name="num"></param>
    public TimerData(int num)
    {
        _elapsedTime.Value = num;
    }
    /// <summary>
    /// 経過時間を増やす
    /// </summary>
    public void ChangeTime()
    {
        _elapsedTime.Value += 1;
    }

    /// <summary>
    /// タイマーの開始を設定する
    /// </summary>
    /// <param name="flg"></param>
    public void TimerStart(bool flg)
    {
        isStart.Value = flg;
    }
}
