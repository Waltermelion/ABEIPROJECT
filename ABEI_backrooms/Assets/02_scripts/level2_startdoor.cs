using System;
using UnityEngine;
public class level2_startdoor : MonoBehaviour
{
    public GameObject enemies;
    public GameObject wall;
    public AudioSource wallsource;
    [SerializeField] private ParticleSystem ruble;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "lvl2startdoor")
        {
            enemies.SetActive(true);
            wallsource.Play();
            wall.GetComponent<MeshRenderer>().enabled = false;
            ruble.Play();
        }
    }
}
