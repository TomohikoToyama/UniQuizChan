using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class DamageView_A : MonoBehaviour
{
    [SerializeField] private Text damageLog;
    [SerializeReference] private MouseSlash _slash;
    
    // Start is called before the first frame update
    void Start()
    {
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
