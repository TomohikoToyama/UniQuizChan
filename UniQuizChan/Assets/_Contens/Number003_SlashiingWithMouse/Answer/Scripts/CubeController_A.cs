using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class CubeController_A : MonoBehaviour
{
    private ObservableMouseTrigger mouse;
    private readonly int invincibleTime = 500;
    public IObservable<bool> Hit => _hit;
    private Subject<bool> _hit = new Subject<bool>();
   
    // 1フレーム目にする処理
    void Start()
    {
        mouse = GetComponent<ObservableMouseTrigger>();
        
        // mouseを参照する
        mouse
            // マウスが乗っかった時    
            .OnMouseEnterAsObservable()
            // 前回の実行から0.5秒経過していれば
            .ThrottleFirst(TimeSpan.FromMilliseconds(invincibleTime),Scheduler.MainThread)
            //購読し、_hitをtrueで通知する
            .Subscribe(_ => _hit.OnNext(true))
            .AddTo(this);
        // mouseを参照する
        mouse
            // マウスが離れた時    
            .OnMouseExitAsObservable()
            //購読し、_hitをfalseで通知する
            .Subscribe(_ => _hit.OnNext(false))
            .AddTo(this);
    }

}
