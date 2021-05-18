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
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (null == countText)
            countText = GetComponent<Text>();

        startBtn
            .OnClickAsObservable()
            .Subscribe(_ =>
            {
                isStart.OnNext(true);
            })
            .AddTo(this);
    }

    public void DisplayTimer(int num)
    {
        if (num <= 0)
            countText.text = $"Game Over";
        else
        countText.text = $"Rest : {num} sec";
    }
    
    public void ChangeButton(bool flg)
    {
       mask.gameObject.SetActive(flg);
    }
}
