using System.Data.SqlTypes;
using UniRx;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    private readonly  int limitTime = 16;
    private TimerData  _timerData;
    private bool timerFlg;
    [SerializeField] private TimerView  _timerView;
    [SerializeField] private TimerSound _timerSound;
    
    // Start is called before the first frame update
    void Awake()
    {
        _timerData = new TimerData(0);

        _timerView
            .IsStart
            .Subscribe(flg =>
            {
                _timerData.TimerStart(flg);
                _timerView.ChangeButton(flg);
            })
            .AddTo(this);

        _timerData
            .IsStart
            .Where(_ => !_timerData.IsStart.Value)
            .Subscribe(flg =>
            {
                _timerData.TimerStart(flg);
                _timerView.ChangeButton(flg);
            }).AddTo(this);

        _timerData
            .ElapsedTime
            .Where( _ => _timerData.IsStart.Value)
            .Subscribe( _ =>{
                
                if (_timerData.ElapsedTime.Value > limitTime)
                {
                    _timerData.TimerStart(false);
                    _timerData.ElapsedTime.Value = 0;
                }
                else
                {
                    _timerSound.PlaySE(); 
                    _timerView.DisplayTimer(limitTime - _timerData.ElapsedTime.Value);
                    
                }
            })
            .AddTo(this);
         

        Observable
            .Interval(System.TimeSpan.FromSeconds(1)) //0秒後から1秒間隔で実行
            .Where( _ => _timerData.IsStart.Value)
            .Subscribe(x =>
            {
                _timerData.ChangeTime();
            });
    }

    public int GetElapsedTime()
    {
        var timeCount = _timerData.ElapsedTime.Value;
        return timeCount;
    }

    public bool GetIsStart()
    {
        if (null != _timerData.IsStart.Value && _timerData.IsStart.Value )
            return true;
        else
            return false;
    }
   
}
