using UnityEngine;
public class StatuePlayAudio : MonoBehaviour
{
    public AudioClip slide;
    public AudioSource source;
        
    void PlaySlideAudio()
    {
        source.PlayOneShot(slide);
    }
}