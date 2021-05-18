using UniRx.Triggers;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class BombController : MonoBehaviour
{

    [SerializeField] private BombSound _bombSound;
    private BombData _bombData;
    [SerializeField] private BombView _bombView;
    [SerializeField] private CountdownTimer _countdownTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        _bombData = new BombData();
        this.UpdateAsObservable()
            .Select(_ => _countdownTimer.GetElapsedTime())
            .DistinctUntilChanged()
            .Subscribe(_ =>
                {

                    _bombData.BombTime.Value = _countdownTimer.GetElapsedTime();

                }
            ).AddTo(this);

        
        _bombData
            .BombTime
            .Where(_ => _countdownTimer.GetIsStart())
            .Subscribe(_ =>
            {
                _bombView.ChangeFuse( _bombData.BombTime.Value);
                if(_bombData.BombTime.Value < 16)
                    _bombSound.PlaySE((int)(BombSound.ClipName.fuseClip));
                else
                    _bombSound.PlaySE((int)(BombSound.ClipName.exposionCLip));
                    
            }).AddTo(this);
            
    }

    
}
