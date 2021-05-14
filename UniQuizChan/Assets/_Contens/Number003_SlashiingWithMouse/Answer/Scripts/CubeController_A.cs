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
   
    // Start is called before the first frame update
    void Start()
    {
        mouse = GetComponent<ObservableMouseTrigger>();
        mouse
            .OnMouseEnterAsObservable()
            .ThrottleFirst(TimeSpan.FromMilliseconds(invincibleTime),Scheduler.MainThread)
            .Subscribe(_ => _hit.OnNext(true))
            .AddTo(this);
        mouse
            .OnMouseExitAsObservable()
            .Subscribe(_ => _hit.OnNext(false))
            .AddTo(this);
    }

}
