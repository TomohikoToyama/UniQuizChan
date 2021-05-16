using UnityEngine;

public class TimerSound : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    private AudioSource _source;
    
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
        _source.playOnAwake = false;
        _source.clip = _clip;
    }

    public void PlaySE()
    {
        _source.Play();
    }
    
}
