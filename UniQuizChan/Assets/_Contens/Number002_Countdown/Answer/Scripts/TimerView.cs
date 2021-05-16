using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{

    [SerializeField] private Button startBtn;
    [SerializeField] private Text countText;
    public IReactiveProperty<bool> IsStart => IsStart;
    ReactiveProperty<bool> isStart = new ReactiveProperty<bool>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (null == countText)
            countText = GetComponent<Text>();

        startBtn
            .OnClickAsObservable()
            .Where( x => !isStart.Value)
            .Subscribe(_ =>
            {
                isStart.Value = true;
                startBtn.gameObject.SetActive(false);
            })
            .AddTo(this);
    }

    public void DisplayTimer(int num)
    {
        countText.text = $"Rest : {num} sec";
    }
}
