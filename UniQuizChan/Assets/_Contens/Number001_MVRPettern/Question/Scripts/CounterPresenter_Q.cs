using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CounterPresenter_Q : MonoBehaviour
{
    private CounterModel_A model;
    [SerializeField] private CounterView_Q  view;
    // Start is called before the first frame update
    void Start()
    {
        model = new CounterModel_A();
        // Nullチェック
        if (null == view) view = FindObjectOfType<CounterView_Q>();

        // viewを参照 
        view
            // AddObservableが発火した時
            .AddObservable()
            // 購読してmodelのAddCountを実行する
            .Subscribe(_ => model.AddCount())
            .AddTo(this);
        
        // viewを参照 .
        view
            // ReduceObservableが発火した時.
            .ReduceObservable()
            // 購読してmodelのReduceCountを実行する
            .Subscribe(_ => model.ReduceCount())
            .AddTo(this);

        //  modelを参照する
        model
            // Counterの値に変化があった時
            .Counter
            // modelのCounterの値を引数にviewのDisplayCountを実行する
            .Subscribe(_ => view.DisplayCount(model.Counter.Value))
            .AddTo(this);
    }

}
