using UnityEngine;

public class BombSound : MonoBehaviour
{
    [SerializeField] private AudioSource _source; 
    // fuseClip = 0, exposionCLip = 1
   public enum ClipName
    {
        fuseClip = 0, 
        exposionCLip = 1
    }
    [SerializeField] private AudioClip[] _clips = new AudioClip[2];
    
    public void PlaySE(int num)
    {
        _source.clip = _clips[num];
        _source.Play();
    }
}
