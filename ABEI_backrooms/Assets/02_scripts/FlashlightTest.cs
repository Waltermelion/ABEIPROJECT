using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightTest : MonoBehaviour
{
    public GameObject Flashlight;
    bool FlashlightLigada = false;

    // Start is called before the first frame update
    void Start()
    {
        Flashlight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (FlashlightLigada == false)
            {
                Flashlight.gameObject.SetActive(true);
                FlashlightLigada = true;
            }
            else
            {
                Flashlight.gameObject.SetActive(false);
                FlashlightLigada = false;
            }
        }
    }
}