using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitlevel0 : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("collision detect");
        if (col.transform.CompareTag("exit"))
        {
            SceneManager.LoadScene("Level_tbd");
        }
    }
}
