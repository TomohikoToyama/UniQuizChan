using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class DamageView_A : MonoBehaviour
{
    [SerializeField] private Text damageLog;
    [SerializeReference] private MouseSlash_A _slash;
    
    // Start is called before the first frame update
    void Start()
    {
        // Null チェック
        if (null == damageLog)
            GameObject.Find("DamageLog").GetComponent<Text>();
        if (null == _slash)
            _slash = FindObjectOfType<MouseSlash_A>().GetComponent<MouseSlash_A>();
        
        // _slashを参照する. 
        _slash
            // Damageが発火した時    
            .Damage
            // 購読し、DisplayDamageを実行する.
            .Subscribe(  point => DisplayDamage(point) )
            .AddTo(this);
    }

    /// <summary>
    /// Display damage value
    /// </summary>
    /// <param name="point"></param>
    private void DisplayDamage(int point)
    {
        damageLog.text = point + " Damage!!";
    }
    
}
