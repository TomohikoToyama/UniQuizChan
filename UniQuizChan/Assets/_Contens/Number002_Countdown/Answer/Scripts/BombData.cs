using UniRx;
public class BombData 
{
    public IReactiveProperty<int> BombTime => bombTime;
    private ReactiveProperty<int> bombTime = new ReactiveProperty<int>();

    public void ChangeTime(int num)
    {
        bombTime.Value = num;
    }
}
