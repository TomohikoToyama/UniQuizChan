using UniRx;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    private readonly  int limitTime = 61;
    private TimerData  _timerData;
    private bool timerFlg;
    [SerializeField] private TimerView  _timerView;
    [SerializeField] private TimerSound _timerSound;
    // Start is called before the first frame update
    void Start()
    {
        _timerData = new TimerData(0);

        
        _timerData
            .ElapsedTime
            .Where( _ => _timerView.IsStart.Value)
            .Subscribe( _ =>{
                _timerSound.PlaySE(); 
                _timerView.DisplayTimer( limitTime - _timerData.ElapsedTime.Value);
            })
            .AddTo(this);
         

        Observable
            .Interval(System.TimeSpan.FromSeconds(1)) //0秒後から1秒間隔で実行
            .Where( _ => _timerView.IsStart.Value)
            .Subscribe(x =>
            {
                _timerData.ChangeTime();
            });

    }

   
}
