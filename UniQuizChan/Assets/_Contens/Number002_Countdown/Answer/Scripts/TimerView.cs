using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{

    [SerializeField] private Button startBtn;
    [SerializeField] private Text countText;
    [SerializeField] private Image mask;
    public IObservable<bool> IsStart => isStart;
    Subject<bool> isStart = new Subject<bool>();
    
    
    // 1フレーム目に実行する処理
    void Start()
    {
        if (null == countText)
            countText = GetComponent<Text>();

        //スタートボタンを参照
        startBtn
            //ボタンが押されたら    
            .OnClickAsObservable()
            //購読し、isStartにTrueを発行する
            .Subscribe(_ => isStart.OnNext(true) )
            .AddTo(this);
    }

    /// <summary>
    /// 時間切れになったらゲームオーバー表示
    /// 時間が残っているなら残り時間を表示
    /// </summary>
    /// <param name="num"></param>
    public void DisplayTimer(int num)
    {
        if (num <= 0)
            countText.text = $"Game Over";
        else
            countText.text = $"Rest : {num} sec";
    }
    
    /// <summary>
    /// タイマーがスタートしたらボタンを見えなくする
    /// </summary>
    /// <param name="flg"></param>
    public void ChangeButton(bool flg)
    {
       mask.gameObject.SetActive(flg);
    }
}
