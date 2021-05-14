using System;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class MouseSlash_A : MonoBehaviour
{
    public IObservable<int> Damage => _damagePoint; 
   private Subject<int> _damagePoint = new Subject<int>();
   [SerializeField] private CubeController_A _cubeController;
   float attackWeight;
   
   void Start()
    {
        if (null == _cubeController)
            _cubeController = FindObjectOfType<CubeController_A>().GetComponent<CubeController_A>();
        
        var test = this.UpdateAsObservable()
            .Where( input => Input.GetMouseButton (0))
            .Subscribe( flg =>
            {
                if (null == Camera.main) return;
                Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
                RaycastHit hit;
                Physics.Raycast(ray, out hit, Mathf.Infinity);
            });
        
        var mousePositionAsObservable = this.UpdateAsObservable().Select(_ => Input.mousePosition);
        mousePositionAsObservable.Buffer(2, 1).Select(mousePosition => mousePosition.First() - mousePosition.Last())
            .DistinctUntilChanged().Where(_ =>  Input.GetMouseButton(0)).Subscribe(accel =>
            {
                attackWeight = Math.Abs(accel.x) + Math.Abs(accel.y);
            })
            .AddTo(this);
       
        _cubeController
            .Hit
            .Where( _ => attackWeight > 0)
            .Subscribe(_ =>
            {
                _damagePoint.OnNext((int)attackWeight);
            })
            .AddTo(this);
    }
}
