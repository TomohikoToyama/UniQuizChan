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
    
   // 1フレーム目の処理
   void Start()
    {
        //Nullチェック
        if (null == _cubeController)
            _cubeController = FindObjectOfType<CubeController_A>().GetComponent<CubeController_A>();
        
        // 毎フレームマウスの位置を取得する
        var mousePositionAsObservable = this.UpdateAsObservable().Select(_ => Input.mousePosition);
        
        // マウスの位置を参照し
        mousePositionAsObservable
            // 2フレーム毎に1フレーム目の位置と2フレーム目の位置を比較し引く    
            .Buffer(2, 1).Select(mousePosition => mousePosition.First() - mousePosition.Last())
            // 前回と値が同じであれば読み込まず
            .DistinctUntilChanged()
            // マウスの左クリックが押されている時に
            .Where(_ =>  Input.GetMouseButton(0))
            // 購読し、xとyの絶対値を足してattackWeightに代入する。
            .Subscribe(accel => attackWeight = Math.Abs(accel.x) + Math.Abs(accel.y) )
            .AddTo(this);
       
        // _cubeControllerを参照する
        _cubeController
            // Hitが発火した時    
            .Hit
            // trueであり、attackWeightが0以上であれば
            .Where( flag => flag && attackWeight > 0)
            // 購読し、attackWeightの値を通知する
            .Subscribe(_ => _damagePoint.OnNext((int)attackWeight) )
            .AddTo(this);
    }
}
