using UnityEngine;

public class BombSound : MonoBehaviour
{
    [SerializeField] private AudioSource _source; 
   
    public enum ClipName
    {
        fuseClip = 0,    //導火線の火の音 
        exposionCLip = 1 //爆発音
    }
    [SerializeField] private AudioClip[] _clips = new AudioClip[2];
    
    /// <summary>
    /// 爆弾の効果音を再生する
    /// </summary>
    /// <param name="num"></param>
    public void PlaySE(int num)
    {
        _source.clip = _clips[num];
        _source.Play();
    }
}
