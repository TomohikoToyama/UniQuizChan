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
        if (null == damageLog)
            GameObject.Find("DamageLog").GetComponent<Text>();
        if (null == _slash)
            _slash = FindObjectOfType<MouseSlash_A>().GetComponent<MouseSlash_A>();
        
        // Browse to the _slash. 
        _slash
            // When fired Damage.    
            .Damage
            // Subscribe and excuete DisplayDamage.
            .Subscribe(  point =>
            {
                DisplayDamage(point);
            })
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
