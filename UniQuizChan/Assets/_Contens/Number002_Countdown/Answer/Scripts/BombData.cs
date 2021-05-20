using UniRx;
public class BombData 
{
    public IReactiveProperty<int> BombTime => bombTime;
    private ReactiveProperty<int> bombTime = new ReactiveProperty<int>();

    public BombData(int limitTime)
    {
        bombTime.Value = limitTime;
    }
    /// <summary>
    /// 爆弾の時間を変更する
    /// </summary>
    /// <param name="num"></param>
    public void ChangeTime(int num)
    {
        bombTime.Value = num;
    }
}
