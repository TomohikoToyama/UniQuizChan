using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;


public class CounterView_Q : MonoBehaviour
{

    [SerializeField] private Button _addButton;
    [SerializeField] private Button _reduceButton;
    [SerializeField] private Text   _counterText;

    private enum UIName
    {
        AddButton,
        ReduceButton,
        CounterText
    }
    
    public  IObservable<Unit> AddObservable()    => addTrigger; 
    public  IObservable<Unit> ReduceObservable() => reduceTrigger; 
    private Subject<Unit>   addTrigger    = new Subject<Unit>();
    private Subject<Unit>   reduceTrigger = new Subject<Unit>();
    
    void Start()
    {
        // Nullチェック.
        if (null == _addButton)  _addButton =GameObject.Find(UIName.AddButton.ToString()).GetComponent<Button>();
        if( null == _reduceButton) _reduceButton = GameObject.Find(UIName.ReduceButton.ToString()).GetComponent<Button>();
        if( null == _counterText) _counterText =GameObject.Find(UIName.CounterText.ToString()).GetComponent<Text>();
        
        //ここから記述
        #region Question
        // Addbuttonを参照
        
            // ボタンが押された時
            
            // 購読して、addTriggerを発行する
            
        
        // Browse to the Reducebutton
        
            // When the button is pressed
            
            // Publish an event to be subscribed and executed
           
        #endregion
        //ここまで
    }

    /// <summary>
    /// 数値表示用
    /// </summary>
    /// <param name="count"></param>
    public void DisplayCount(int count)
    {
        _counterText.text = "Current value is : " + count;
    }
}
