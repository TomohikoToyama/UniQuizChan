using UnityEngine;
using UnityEngine.UI;

public class BombView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    
    /// <summary>
    /// 導火線の見た目を変更する
    /// </summary>
    /// <param name="num"></param>
    public void ChangeFuse(int num)
    {
        _slider.value = num;
    }
    
}
