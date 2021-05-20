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
    
    // 1フレーム目にする処理
    void Awake()
    {
        _timerData = new TimerData(0);

        // _timerViewを参照
        _timerView
            // IsStartに変化があった時
            .IsStart
            // 購読し。
            .Subscribe(flg =>
            {
                //_timerDataのTimerStartにIsStartの値を流す
                _timerData.TimerStart(flg);
                //_timerViewのChangeButtonにIsStartの値を流す
                _timerView.ChangeButton(flg);
            })
            .AddTo(this);

        
        // _timerDataを参照
        _timerData
            // IsStartに変化があった時   
            .IsStart
            // IsStartの値がfalseなら    
            .Where(_ => !_timerData.IsStart.Value)
            // 購読し
            .Subscribe(flg =>
            {
                //_timerDataのTimerStartにIsStartの値を流す
                _timerData.TimerStart(flg);
                //_timerViewのChangeButtonにIsStartの値を流す
                _timerView.ChangeButton(flg);
            }).AddTo(this);

        // _timerDataを参照
        _timerData
            // ElapsedTimeに変化があった時    
            .ElapsedTime
            // _timerDataのIsStartがtrueなら
            .Where( _ => _timerData.IsStart.Value)
            .Subscribe( _ =>{
                
                //経過時間がlimitTime以上なら
                if (_timerData.ElapsedTime.Value > limitTime)
                {
                    //_timerDataのTimerStartをfalseにする
                    _timerData.TimerStart(false);
                    // _timerDataのElapsedTime値を0にする
                    _timerData.ElapsedTime.Value = 0;
                }
                else
                {
                    //_timerSoundのPlaySEを実行する
                    _timerSound.PlaySE(); 
                    //_timerViewのDisplayTimerを実行する
                    _timerView.DisplayTimer(limitTime - _timerData.ElapsedTime.Value);
                    
                }
            })
            .AddTo(this);
        
        Observable
            // 0秒後から1秒間隔で実行
            .Interval(System.TimeSpan.FromSeconds(1))
            // _timerDataでタイマー開始されているなら
            .Where( _ => _timerData.IsStart.Value)
            // 購読し、_timerDataの時間変更処理をする
            .Subscribe(x => _timerData.ChangeTime());
    }

    /// <summary>
    /// 経過時間を取得
    /// </summary>
    /// <returns></returns>
    public int GetElapsedTime()
    {
        var timeCount = _timerData.ElapsedTime.Value;
        return timeCount;
    }

    /// <summary>
    /// タイマーが開始しているかを取得
    /// </summary>
    /// <returns></returns>
    public bool GetIsStart()
    {
        if (null != _timerData.IsStart.Value && _timerData.IsStart.Value )
            return true;
        else
            return false;
    }

    /// <summary>
    /// 時間切れ時間を取得
    /// </summary>
    /// <returns></returns>
    public int GetLimitTime()
    {
        return limitTime;
    }

}
