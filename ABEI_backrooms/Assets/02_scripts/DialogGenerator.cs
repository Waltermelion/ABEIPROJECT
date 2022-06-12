using System.Collections;
using UnityEngine;
using TMPro;
public class DialogGenerator : MonoBehaviour
{
    public InputManager ipt;
    
    public TextMeshProUGUI textComponent;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;
    private int index;
    void Update()
    {
        if (ipt.onFoot.MouseClick.triggered)
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    public void StartDialogue()
    {
        dialogueBox.SetActive(true);
        textComponent.text = string.Empty;
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            //textComponent.text = string.Empty;
            dialogueBox.SetActive(false);
        }
    }
}