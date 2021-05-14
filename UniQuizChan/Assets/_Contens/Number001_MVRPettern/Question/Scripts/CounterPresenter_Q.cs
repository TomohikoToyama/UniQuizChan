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

        //ここから記述
        #region Question
        // viewを参照 
        
            // AddObservableが発火した時
            
            // 購読してmodelのAddCountを実行する
            
        
        // viewを参照 .
        
            // ReduceObservableが発火した時.
            
            // 購読してmodelのReduceCountを実行する
            

        //  modelを参照する
        
            // Counterの値に変化があった時
            
            // modelのCounterの値を引数にviewのDisplayCountを実行する
        #endregion
        //ここまで    
    }

}
