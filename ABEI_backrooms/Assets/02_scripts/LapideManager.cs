using UnityEngine;

public class LapideManager : MonoBehaviour
{
    public LapideRotate[] lapides;
    public bool allRotateded;

    public Animator statueAnime;
    public AudioClip slide;
    public AudioSource source;
    void Update()
    {
        if (allRotateded)
            return;
        if (allRotated())
        {
            statueAnime.SetTrigger("lapidesRotatings");
            source.PlayOneShot(slide);
            allRotateded = true;
        }
        allRotated();
    }
    private bool allRotated() {
        for ( int i = 0; i < lapides.Length; ++i ) {
            if ( lapides[ i ].correctlyRotated == false ) {
                return false;
            }
        }
        allRotateded = true;
        return true;
    }
}