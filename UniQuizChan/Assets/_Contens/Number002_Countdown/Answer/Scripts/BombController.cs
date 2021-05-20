using UniRx.Triggers;
using UniRx;
using UnityEngine;
public class BombController : MonoBehaviour
{

    [SerializeField] private BombSound _bombSound;
    private BombData _bombData;
    [SerializeField] private BombView _bombView;
    [SerializeField] private CountdownTimer _countdownTimer;
    
    // 1フレーム目で処理を行う
    void Start()
    {
        // BombDataを生成
        _bombData = new BombData(_countdownTimer.GetLimitTime());
        
        // 毎フレーム読み込んで
        this.UpdateAsObservable()
            // _countdownTimerから経過時間を取得
            .Select(_ => _countdownTimer.GetElapsedTime())
            // 値が前回と変わっているなら
            .DistinctUntilChanged()
            // 経過時間を爆弾の時間に反映する
            .Subscribe(_ => _bombData.BombTime.Value = _countdownTimer.GetElapsedTime()
            ).AddTo(this);

        // 
        _bombData
            
            .BombTime
            // countdownTimerから開始してるか取得し、開始してるなら
            .Where(_ => _countdownTimer.GetIsStart())
            .Subscribe(_ =>
            {
                // bombViewの導火線にボムの時間を設定する
                _bombView.ChangeFuse( _bombData.BombTime.Value);
                
                // countdownTimerのタイムリミット未満の場合、導火線の音を鳴らす
                if(_bombData.BombTime.Value < _countdownTimer.GetLimitTime())
                    _bombSound.PlaySE((int)(BombSound.ClipName.fuseClip));
                // タイムリミットを過ぎたら爆発音を鳴らす
                else
                    _bombSound.PlaySE((int)(BombSound.ClipName.exposionCLip));
                    
            }).AddTo(this);
            
    }

    
}
