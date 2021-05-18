using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombView : MonoBehaviour
{
    [SerializeField] private Slider _slider;


    public void ChangeFuse(int num)
    {
        _slider.value = num;
    }
    
    
}
