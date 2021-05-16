using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    private int limitTime = 60;
    private TimerData  _timerData;
    private TimerView  _timerView;
    private TimerSound _timerSound;
    // Start is called before the first frame update
    void Start()
    {
        _timerData = new TimerData(0);
        _timerView = FindObjectOfType<TimerView>().GetComponent<TimerView>();
        _timerSound = GetComponent<TimerSound>();
        
        
        _timerData
            .ElapsedTime
            .Where( y => _timerView.IsStart.Value)
            .Subscribe( _ =>{
                _timerSound.PlaySE(); 
            })
            .AddTo(this);
         

        Observable
            .Interval(System.TimeSpan.FromSeconds(1)) //0秒後から1秒間隔で実行
            .Where( y => _timerView.IsStart.Value)
            .Subscribe(x =>
            {
                _timerData.ChangeTime();
            });

    }

   
}
