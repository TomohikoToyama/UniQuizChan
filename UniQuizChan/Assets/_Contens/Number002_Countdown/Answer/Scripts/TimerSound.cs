using UnityEngine;

public class TimerSound : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    private AudioSource _source;
    
    // 最初の1フレーム目の処理
    void Start()
    {
        _source = GetComponent<AudioSource>();
        _source.playOnAwake = false;
        _source.clip = _clip;
    }

    /// <summary>
    /// タイマーの音を再生する
    /// </summary>
    public void PlaySE()
    {
        _source.Play();
    }
    
}
