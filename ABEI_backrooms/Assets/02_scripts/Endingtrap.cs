using UnityEngine;
using UnityEngine.SceneManagement;
public class Endingtrap : MonoBehaviour
{
    public GameObject blackscreen;
    public AudioSource painsource;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "lvl2enddoor")
        {
            blackscreen.SetActive(true);
            painsource.Play();
            Invoke("loadEnding", 8f);
        }
    }

    void loadEnding()
    {
        SceneManager.LoadScene("Ending");
    }
}