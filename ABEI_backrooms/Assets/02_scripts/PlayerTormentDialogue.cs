using System;
using UnityEngine;

public class PlayerTormentDialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "dialogue")
        {
            other.GetComponent<DialogGenerator>().StartDialogue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "dialogue")
        {
            dialogueBox.SetActive(false);
            //other.GetComponent<DialogGenerator>().textComponent.text = string.Empty;
        }
    }
}