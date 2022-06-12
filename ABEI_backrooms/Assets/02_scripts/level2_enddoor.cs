using UnityEngine;
using UnityEngine.SceneManagement;
public class level2_enddoor : MonoBehaviour
{
    public GameObject enemies;
    public Animator wall;
    public AudioSource wallsource;
    private bool dopen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "lvl2enddoor")
        {
            enemies.SetActive(true);
            if (!dopen)
            {
                wall.SetTrigger("OpenDoor");
                wallsource.Play();
                dopen = true;
                Invoke("LoadLastLevel",2f);
            }
        }
    }
    private void LoadLastLevel()
    {
        SceneManager.LoadScene("Level_theTorment");
    }
}